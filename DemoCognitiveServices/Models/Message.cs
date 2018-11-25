using System;
namespace DemoCognitiveServices.Models
{
    /// <summary>
    /// Message.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets from.
        /// </summary>
        /// <value>From.</value>
        public string From { get; set; }

        /// <summary>
        /// Gets or sets to.
        /// </summary>
        /// <value>To.</value>
        public string To { get; set; }

        /// <summary>
        /// Gets or sets from image.
        /// </summary>
        /// <value>From image.</value>
        public string FromImage { get; set; }

        /// <summary>
        /// Gets or sets the receive date.
        /// </summary>
        /// <value>The receive date.</value>
        public DateTime MessageDateTime { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:DemoCognitiveServices.Models.Message"/> is readed.
        /// </summary>
        /// <value><c>true</c> if is readed; otherwise, <c>false</c>.</value>
        public bool? IsReaded { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:DemoCognitiveServices.Models.Message"/> is incoming.
        /// </summary>
        /// <value><c>true</c> if is incoming; otherwise, <c>false</c>.</value>
        public bool IsIncoming { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:DemoCognitiveServices.Models.Message"/> has ice breaker.
        /// </summary>
        /// <value><c>true</c> if has ice breaker; otherwise, <c>false</c>.</value>
        public bool HasIceBreaker { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; set; }
    }
}