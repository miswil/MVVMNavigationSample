using Microsoft.Toolkit.Mvvm.Messaging;
using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp2
{
    class ShowDialogBehavior : Behavior<Window>
    {
        public IMessenger Messenger
        {
            get { return (IMessenger)GetValue(MessengerProperty); }
            set { SetValue(MessengerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Messenger.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessengerProperty =
            DependencyProperty.Register("Messenger", typeof(IMessenger), typeof(ShowDialogBehavior), new PropertyMetadata(null));

        protected override void OnAttached()
        {
            base.OnAttached();
            this.Messenger.Register<ShowDialogMessage>(this, showDialog);
        }

        private static void showDialog(object recipient, ShowDialogMessage message)
        {
            var behavior = (ShowDialogBehavior)recipient;
            var dialog = ViewLocator.Default.Locate(message.ViewModel.GetType());
            dialog.DataContext = message.ViewModel;
            dialog.Owner = behavior.AssociatedObject;
            dialog.ShowDialog();
        }
    }
}
