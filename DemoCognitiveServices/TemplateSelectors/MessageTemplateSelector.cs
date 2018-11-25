using DemoCognitiveServices.Models;
using Xamarin.Forms;

namespace DemoCognitiveServices
{
    /// <summary>
    /// Message template selector.
    /// </summary>
    public class MessageTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// The incoming data template.
        /// </summary>
        private readonly DataTemplate incomingDataTemplate;

        /// <summary>
        /// The outgoing data template.
        /// </summary>
        private readonly DataTemplate outgoingDataTemplate;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:DemoCognitiveServices.MessageTemplateSelector"/> class.
        /// </summary>
        public MessageTemplateSelector()
        {
            this.incomingDataTemplate = new DataTemplate(typeof(IncomingViewCell));
            this.outgoingDataTemplate = new DataTemplate(typeof(OutgoingViewCell));
        }

        /// <summary>
        /// Ons the select template.
        /// </summary>
        /// <returns>The select template.</returns>
        /// <param name="item">Item.</param>
        /// <param name="container">Container.</param>
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container) => !(item is Message message) ? null : message.IsIncoming ? this.incomingDataTemplate : this.outgoingDataTemplate;
    }
}