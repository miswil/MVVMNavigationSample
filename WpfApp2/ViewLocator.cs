using System;
using System.Collections.Generic;
using System.Windows;

namespace WpfApp2
{
    class ViewLocator
    {
        public static ViewLocator Default { get; } = new ViewLocator();

        private Dictionary<Type, Type> locator = new Dictionary<Type, Type>();

        public void Register<TViewModel, TView>() where TView : Window
        {
            this.locator.Add(typeof(TViewModel), typeof(TView));
        }

        public Window Locate(Type viewModelType)
        {
            var winType = this.locator[viewModelType];
            return (Window)Activator.CreateInstance(winType);
        }
    }
}
