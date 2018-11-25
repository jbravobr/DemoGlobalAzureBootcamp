using System;
namespace DemoCognitiveServices.Models
{
    /// <summary>
    /// Mood.
    /// </summary>
    public enum Mood
    {
        [EnumDescription("Feliz")]
        Happy,

        [EnumDescription("Normal")]
        Normal,

        [EnumDescription("Nervoso")]
        Angry,

        Default
    }
}
