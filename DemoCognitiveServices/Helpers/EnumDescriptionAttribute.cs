using System;
namespace DemoCognitiveServices
{
    /// <summary>
    /// Enum description attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class EnumDescriptionAttribute : Attribute
    {
        /// <summary>
        /// The description.
        /// </summary>
        readonly string _description;

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get { return _description; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Models.Extensions.EnumDescriptionAttribute"/> class.
        /// </summary>
        /// <param name="description">Description.</param>
        public EnumDescriptionAttribute(string description)
        {
            _description = description;
        }
    }
}