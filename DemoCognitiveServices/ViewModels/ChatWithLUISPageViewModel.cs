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

namespace DemoCognitiveServices.ViewModels
{
    public class ChatWithLUISPageViewModel : BaseViewModel
    {
        /// <summary>
        /// Gets the luis endpoint service.
        /// </summary>
        /// <value>The luis endpoint service.</value>
        private ILuisEndpointService _luisEndpointService { get; }

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
        public ChatWithLUISPageViewModel(INavigationService navigationService,
                                         ILuisEndpointService luisEndpointService,
                                         IEventAggregator eventAggregator) : base(navigationService)
        {
            this._luisEndpointService = luisEndpointService;
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
        /// Adds the bot first message.
        /// </summary>
        private void AddBotFirstMessage()
        {
            var iceBreaker = new Message
            {
                From = "Bot Geuvânio",
                To = "Rodrigo Amaro",
                Id = Guid.NewGuid(),
                IsIncoming = true,
                MessageDateTime = DateTime.Now,
                Text = "Olá, seja bem vindo! Meu nome é Geuvânio e estou aqui para ajudá-lo !",
                HasIceBreaker = true,
                FromImage = "bot.png"
            };

            this.Messages.Add(iceBreaker);
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

            if (!this.Messages.Any(m => m.HasIceBreaker))
                AddBotFirstMessage();

            var botAnalysis = await this.CallLuisApi();

            if (botAnalysis != null)
            {
                var botAnswer = this.AnalysisClientMessageWithLuis(botAnalysis);
                BotResponseMessage(botAnswer);
            }

            this.OutGoingText = string.Empty;
            this.MoveToLastItemFromTheList();
        }

        /// <summary>
        /// Bots the response message.
        /// </summary>
        private void BotResponseMessage(string text)
        {
            var message = new Message
            {
                From = "Bot Geuvânio",
                To = "Rodrigo Amaro",
                Id = Guid.NewGuid(),
                IsIncoming = true,
                MessageDateTime = DateTime.Now,
                Text = text,
                FromImage = "bot.png"
            };

            this.Messages.Add(message);
            this.MoveToLastItemFromTheList();
        }

        /// <summary>
        /// Dos the text analysis.
        /// </summary>
        private async Task<LuisModelResponse> CallLuisApi() => await this._luisEndpointService.GetLuisResponse(this.OutGoingText);

        /// <summary>
        /// Analysises the client message with luis.
        /// </summary>
        /// <param name="data">Data.</param>
        private string AnalysisClientMessageWithLuis(LuisModelResponse data)
        {
            if (data == null) return string.Empty;

            if (data.TopScoringIntent.Intent.ToLower() == BotIntent.IntencaoCompra.GetDescription().ToLower())
                return "Olá vejo que você deseja comprar um de nossos produtos ! Vou te ajudar com isso.";

            if (data.TopScoringIntent.Intent.ToLower() == BotIntent.IndicandoProblemaComProduto.GetDescription().ToLower())
                return "Entendi o seu problema, vamos tentar ajudá-lo da melhor maneiro, OK?";

            return "Desculpe, mas eu não consegui entender você";
        }
    }
}
