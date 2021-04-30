using System;

namespace WpfApp1
{
    class PageViewModelBase
    {
        public event Action<object, NavigationRequestedEventArgs> NavigationRequested;

        protected void RequestNavigate(object next)
        {
            this.NavigationRequested?.Invoke(this, new NavigationRequestedEventArgs(next));
        }
    }

    class NavigationRequestedEventArgs : EventArgs
    {
        public object Next { get; }
        public NavigationRequestedEventArgs(object next)
        {
            this.Next = next;
        }
    }
}
