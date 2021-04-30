using Microsoft.Toolkit.Mvvm.Input;
using System.Windows.Input;

namespace WpfApp1
{
    class Page3Model : PageViewModelBase
    {
        public ICommand Page1Command { get; }
        public ICommand Page2Command { get; }
        public ICommand Page3Command { get; }

        public Page3Model()
        {
            this.Page1Command = new RelayCommand(() => this.RequestNavigate(new Page1Model()));
            this.Page2Command = new RelayCommand(() => this.RequestNavigate(new Page2Model()));
            this.Page3Command = new RelayCommand(() => this.RequestNavigate(new Page3Model()));
        }
    }
}
