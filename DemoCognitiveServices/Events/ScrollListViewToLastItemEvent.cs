using System;
using Prism.Events;

namespace DemoCognitiveServices.Events
{
    /// <summary>
    /// Scroll list view to last item event.
    /// </summary>
    public class ScrollListViewToLastItemEvent : PubSubEvent<int>
    {
        public ScrollListViewToLastItemEvent()
        {
        }
    }
}
