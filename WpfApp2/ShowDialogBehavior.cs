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
        protected override void OnAttached()
        {
            base.OnAttached();
            WeakReferenceMessenger.Default.Register<ShowDialogMessage>(this, showDialog);
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
