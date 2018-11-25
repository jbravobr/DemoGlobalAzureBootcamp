using System;
using System.Collections.Generic;

namespace DemoCognitiveServices.Models
{
    public class LuisModelResponse
    {
        /// <summary>
        /// Gets or sets the query.
        /// </summary>
        /// <value>The query.</value>
        public string Query { get; set; }

        /// <summary>
        /// Gets or sets the top scoring intent.
        /// </summary>
        /// <value>The top scoring intent.</value>
        public TopScoringIntent TopScoringIntent { get; set; }

        /// <summary>
        /// Gets or sets the entities.
        /// </summary>
        /// <value>The entities.</value>
        public List<object> Entities { get; set; }
    }
}