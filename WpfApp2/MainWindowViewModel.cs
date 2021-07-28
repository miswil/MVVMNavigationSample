using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System.Windows.Input;

namespace WpfApp2
{
    class MainWindowViewModel : ObservableRecipient
    {
        public IMessenger PubMessenger => this.Messenger;

        private string dialogResult;
        public string DialogResult 
        {
            get => this.dialogResult;
            set => this.SetProperty(ref this.dialogResult, value);
        }

        public ICommand ShowDialogCommand { get; }


        public MainWindowViewModel() : base(new WeakReferenceMessenger())
        {
            this.ShowDialogCommand = new RelayCommand(this.ShowDialogCommandExecute);
        }

        private void ShowDialogCommandExecute()
        {
            var viewModel = new DialogWindowViewModel();
            this.Messenger.Send(new ShowDialogMessage { ViewModel = viewModel });
            this.DialogResult = viewModel.Input;
        }
    }
}
