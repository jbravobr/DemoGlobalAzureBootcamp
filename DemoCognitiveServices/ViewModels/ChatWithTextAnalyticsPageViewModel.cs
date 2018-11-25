using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using DemoCognitiveServices.Events;
using DemoCognitiveServices.Models;
using DemoCognitiveServices.Services.Interfaces;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using Prism.Services;

namespace DemoCognitiveServices.ViewModels
{
    public class ChatWithTextAnalyticsPageViewModel : BaseViewModel
    {
        /// <summary>
        /// Gets the sentiment service.
        /// </summary>
        /// <value>The sentiment service.</value>
        private ISentimentService _sentimentService { get; }

        /// <summary>
        /// Gets the event aggreagator.
        /// </summary>
        /// <value>The event aggreagator.</value>
        private IEventAggregator _eventAggreagator { get; }

        /// <summary>
        /// Gets or sets the messages.
        /// </summary>
        /// <value>The messages.</value>
        public ObservableCollection<Message> Messages { get; private set; }

        /// <summary>
        /// Gets or sets the bot messages.
        /// </summary>
        /// <value>The bot messages.</value>
        private List<BotMessage> BotMessages { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string OutGoingText { get; set; }

        /// <summary>
        /// Gets the send message command.
        /// </summary>
        /// <value>The send message command.</value>
        public DelegateCommand SendMessageCommand { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this
        /// <see cref="T:DemoCognitiveServices.ViewModels.ChatWithTextAnalyticsPageViewModel"/> send message command can execute.
        /// </summary>
        /// <value><c>true</c> if send message command can execute; otherwise, <c>false</c>.</value>
        private bool SendMessageCommandCanExecute() => !string.IsNullOrWhiteSpace(this.OutGoingText);

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:DemoCognitiveServices.ViewModels.ChatWithTextAnalyticsPageViewModel"/> class.
        /// </summary>
        /// <param name="navigationService">Navigation service.</param>
        public ChatWithTextAnalyticsPageViewModel(INavigationService navigationService,
                                                  ISentimentService sentimentService,
                                                  IEventAggregator eventAggregator) : base(navigationService)
        {
            this._sentimentService = sentimentService;
            this._eventAggreagator = eventAggregator;

            this.SendMessageCommand = new DelegateCommand(SendMessage, SendMessageCommandCanExecute)
                .ObservesProperty(() => this.OutGoingText);

            this.Messages = new ObservableCollection<Message>();
            this.BotMessages = BotMessageFactory.GenerateBotMessages();
        }

        /// <summary>
        /// Moves to last item from the list.
        /// </summary>
        private void MoveToLastItemFromTheList()
        {
            var lastItem = this.Messages.LastOrDefault();
            var index = this.Messages.IndexOf(lastItem);
            _eventAggreagator.GetEvent<ScrollListViewToLastItemEvent>().Publish(index);
        }

        /// <summary>
        /// Sends the message.
        /// </summary>
        private async void SendMessage()
        {
            var message = new Message
            {
                From = "Rodrigo Amaro",
                To = "Bot",
                Id = Guid.NewGuid(),
                IsIncoming = false,
                MessageDateTime = DateTime.Now,
                Text = this.OutGoingText,
                FromImage = "profile.jpg"
            };

            this.Messages.Add(message);
            MoveToLastItemFromTheList();

            var mood = await this.DoTextAnalysis();
            this.BotResponseMessage(mood);
            this.OutGoingText = string.Empty;
        }

        /// <summary>
        /// Bots the response message.
        /// </summary>
        private void BotResponseMessage(Mood mood)
        {
            if (this.Messages.Any(m => m.HasIceBreaker))
            {
                var iceBreaker = new Message
                {
                    From = "Bot Geuvânio",
                    To = "Rodrigo Amaro",
                    Id = Guid.NewGuid(),
                    IsIncoming = true,
                    MessageDateTime = DateTime.Now,
                    Text = this.BotMessages.FirstOrDefault(botMessage => botMessage.Id == new Random().Next(1, 100)).Text,
                    FromImage = "bot.png"
                };

                this.Messages.Add(iceBreaker);
                MoveToLastItemFromTheList();
            }
            else
            {
                var initialText = string.Empty;
                initialText = mood == Mood.Angry
                    ? "Vejo que o senhor está um pouco exaltado, fique calmo, pois logo irei depositar 100 milhões de reais na sua conta !"
                    : mood == Mood.Normal ? "Olá como posso ajudá-lo ?" : "Que bom que entrou uma pessoa feliz, não aguentava mais gente nervosa !";

                var iceBreaker = new Message
                {
                    From = "Bot Geuvânio",
                    To = "Rodrigo Amaro",
                    Id = Guid.NewGuid(),
                    IsIncoming = true,
                    MessageDateTime = DateTime.Now,
                    Text = initialText,
                    HasIceBreaker = true,
                    FromImage = "bot.png"
                };

                this.Messages.Add(iceBreaker);
                MoveToLastItemFromTheList();
            }
        }

        /// <summary>
        /// Dos the text analysis.
        /// </summary>
        private async Task<Mood> DoTextAnalysis()
        {
            var result = await this._sentimentService.GetSentiment(this.OutGoingText);
            return result <= 0.4 ? Mood.Angry : result > 0.4 && result <= 0.7 ? Mood.Normal : Mood.Happy;
        }
    }
}
