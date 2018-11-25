using DemoCognitiveServices.Common;
using Prism.Commands;
using Prism.Navigation;

namespace DemoCognitiveServices.ViewModels
{
    /// <summary>
    /// Main page view model.
    /// </summary>
    public class MainPageViewModel : BaseViewModel
    {
        /// <summary>
        /// Gets the text analytics command.
        /// </summary>
        /// <value>The text analytics command.</value>
        public DelegateCommand TextAnalyticsCommand { get; private set; }

        /// <summary>
        /// Gets the LUISC ommand.
        /// </summary>
        /// <value>The LUISC ommand.</value>
        public DelegateCommand LUISCommand { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:DemoCognitiveServices.ViewModels.MainPageViewModel"/> class.
        /// </summary>
        /// <param name="navigationService">Navigation service.</param>
        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            TextAnalyticsCommand = new DelegateCommand(TextAnalytics);
            LUISCommand = new DelegateCommand(LUIS);
        }

        /// <summary>
        /// Texts the analytics.
        /// </summary>
        private void TextAnalytics() => _navigationService.NavigateAsync(PageName.ChatWithTextAnalyticsPage);

        /// <summary>
        /// Luis this instance.
        /// </summary>
        private void LUIS() => _navigationService.NavigateAsync(PageName.ChatWithLUISPage);
    }
}