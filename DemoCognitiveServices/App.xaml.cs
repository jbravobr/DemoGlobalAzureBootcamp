using Xamarin.Forms.Xaml;
using Prism;
using Prism.Ioc;
using DemoCognitiveServices.Services;
using DemoCognitiveServices.Services.Interfaces;
using DemoCognitiveServices.Views;
using Syncfusion.Licensing;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DemoCognitiveServices
{
    public partial class App
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DemoCognitiveServices.App"/> class.
        /// </summary>
        public App()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:DemoCognitiveServices.App"/> class.
        /// </summary>
        /// <param name="initializer">Initializer.</param>
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        /// <summary>
        /// Ons the initialized.
        /// </summary>
        protected override void OnInitialized()
        {
            InitializeComponent();
            SyncfusionInit();

            var firstPage = "MainNavigationPage/MainPage";
            NavigationService.NavigateAsync(firstPage);
        }

        /// <summary>
        /// Registers the types.
        /// </summary>
        /// <param name="containerRegistry">Container registry.</param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ISentimentService, SentimentService>();
            containerRegistry.Register<ILuisEndpointService, LuisEndoiptService>();

            containerRegistry.RegisterForNavigation<BaseContentPage>();
            containerRegistry.RegisterForNavigation<MainNavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<ChatWithTextAnalyticsPage>();
            containerRegistry.RegisterForNavigation<ChatWithLUISPage>();
        }

        /// <summary>
        /// Syncfusions the init.
        /// </summary>
        private void SyncfusionInit() => SyncfusionLicenseProvider.RegisterLicense("MzIwODVAMzEzNjJlMzMyZTMwTnNPWVViWVp0Z3RHdFd2NXNNQ3c2bFg5RS9oakg0dHo5RlVRU0NvNVl1az0=");
    }
}