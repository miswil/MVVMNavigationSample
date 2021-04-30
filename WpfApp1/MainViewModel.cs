using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class MainViewModel : NavigableViewModelBase
    {
        public MainViewModel() : base()
        {
            var initial = new Page1Model();
            initial.NavigationRequested += this.NavigationRequested;
            this.NavigateTo(initial);
        }

        private void NavigationRequested(object sender, NavigationRequestedEventArgs e)
        {
            var next = e.Next as PageViewModelBase;
            next.NavigationRequested += this.NavigationRequested;
            this.NavigateTo(next);
        }
    }
}
