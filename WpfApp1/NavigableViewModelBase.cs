using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace WpfApp1
{
    abstract class NavigableViewModelBase : ObservableObject
    {
        public RelayCommand PrevCommand { get; }
        public RelayCommand NextCommand { get; }

        protected List<object> Histories { get; } = new List<object>();

        private object current;
        public object Current 
        {
            get => this.current;
            private set => this.SetProperty(ref this.current, value);
        }

        private int currentIndex = -1;
        public int CurrentIndex
        {
            get => this.currentIndex;
            private set
            {
                if (value < 0 || this.Histories.Count <= value)
                {
                    throw new IndexOutOfRangeException();
                }
                this.currentIndex = value;
                this.Current = this.Histories[this.CurrentIndex];
                this.PrevCommand.NotifyCanExecuteChanged();
                this.NextCommand.NotifyCanExecuteChanged();
            }
        }

        public NavigableViewModelBase()
        {
            this.PrevCommand = new RelayCommand(this.PrevCommandExecute, this.PrevCommandCanExecute);
            this.NextCommand = new RelayCommand(this.NextCommandExecute, this.NextCommandCanExecute);
        }

        private void PrevCommandExecute() =>  --this.CurrentIndex;

        private bool PrevCommandCanExecute() => this.CurrentIndex > 0;

        private void NextCommandExecute() => ++this.CurrentIndex;
        private bool NextCommandCanExecute() => this.CurrentIndex < this.Histories.Count - 1;

        protected void NavigateTo(object next)
        {
            var nRemove = this.Histories.Count - this.CurrentIndex - 1;
            if (nRemove > 0)
            {
                this.Histories.RemoveRange(this.CurrentIndex + 1, nRemove);
            }

            this.Histories.Add(next);
            ++this.CurrentIndex;
        }
    }
}
