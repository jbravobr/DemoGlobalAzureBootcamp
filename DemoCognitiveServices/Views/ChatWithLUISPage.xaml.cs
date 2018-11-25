using System;
using System.Collections.Generic;
using DemoCognitiveServices.Events;
using Prism.Events;
using Xamarin.Forms;

namespace DemoCognitiveServices.Views
{
    public partial class ChatWithLUISPage : BaseContentPage
    {
        /// <summary>
        /// Gets the event aggregator.
        /// </summary>
        /// <value>The event aggregator.</value>
        private IEventAggregator _eventAggregator { get; }

        /// <summary>
        /// Ons the disappearing.
        /// </summary>
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            this._eventAggregator.GetEvent<ScrollListViewToLastItemEvent>().Unsubscribe(MoveListViewToLastItem);
        }

        public ChatWithLUISPage(IEventAggregator eventAggregator)
        {
            this._eventAggregator = eventAggregator;
            this._eventAggregator.GetEvent<ScrollListViewToLastItemEvent>().Subscribe(MoveListViewToLastItem);

            InitializeComponent();
        }

        /// <summary>
        /// Moves the list view to last item.
        /// </summary>
        /// <param name="index">Index.</param>
        private void MoveListViewToLastItem(int index) => this.listViewForMessages.LayoutManager.ScrollToRowIndex(index, Syncfusion.ListView.XForms.ScrollToPosition.End, true);
    }
}
