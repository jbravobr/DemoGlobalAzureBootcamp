using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Prism.AppModel;
using Prism.Mvvm;
using Prism.Navigation;

namespace DemoCognitiveServices.ViewModels
{
    public class BaseViewModel : BindableBase, INavigationAware, IApplicationStore, INotifyPropertyChanged
    {
        /// <summary>
        /// Gets the properties.
        /// </summary>
        /// <value>The properties.</value>
        public IDictionary<string, object> Properties => Xamarin.Forms.Application.Current.Properties;

        /// <summary>
        /// Gets the navigation service.
        /// </summary>
        /// <value>The navigation service.</value>
        public INavigationService _navigationService { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TrainingApp.ViewModels.BaseViewModel"/> class.
        /// </summary>
        /// <param name="navigationService">Navigation service.</param>
        public BaseViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        /// <summary>
        /// Ons the navigated from.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        /// <summary>
        /// Ons the navigated to.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        /// <summary>
        /// Ons the navigating to.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {
        }

        /// <summary>
        /// Saves the properties async.
        /// </summary>
        /// <returns>The properties async.</returns>
        public virtual async Task SavePropertiesAsync()
        {
        }
    }
}
