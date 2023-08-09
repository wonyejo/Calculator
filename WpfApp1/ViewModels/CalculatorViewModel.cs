using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;


namespace WpfApp1
{

    public class CalculatorViewModel : INotifyPropertyChanged
    {
        #region [상수]

        #endregion

        private string inputText = "";

        public string InputText
        {
            get { return inputText; }
            set
            {
                inputText = value;
                OnPropertyChanged("inputText");
            }
        }
        
        public ICommand NumberButtonCommand { get; private set; }
        public ICommand OperatorButtonCommand { get; private set; }
        public CalculatorViewModel()
        {
            NumberButtonCommand = new RelayCommand(NumberButtonCommandExecute);
            OperatorButtonCommand = new RelayCommand(OperatorButtonCommandExecute); 
        }


        private void NumberButtonCommandExecute(object parameter)
        {
            if (parameter is string number)
            {
                InputText = $"{inputText}{parameter}";
            }
            return;
        }

        private void OperatorButtonCommandExecute(object parameter)
        {

            inputText = $"{inputText}{parameter}";
            
            return;
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}



