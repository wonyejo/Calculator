using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace WpfApp1
{

    public class CalculatorViewModel
    {
        #region [상수]

        #endregion

        #region [변수]
        private string _InputTxt;
        #endregion

        public ICommand NumberButtonCommand { get; private set; }

        public CalculatorViewModel()
        {
            NumberButtonCommand = new RelayCommand(NumberButtonCommandExecute);
        }

        private void NumberButtonCommandExecute(object parameter)
        {
            if (parameter is string number)
            {
                InputTxt = $"{InputTxt}{parameter}";
            }
            return;
        }

        private void OperatorButtonCommandExecute(object parameter)
        {
            
            InputTxt = $"{InputTxt}{parameter}";
            
            return;
        }

        

        public string InputTxt
        {
            get { return _InputTxt; }
            set
            {
                if (_InputTxt != value)
                {
                    _InputTxt = value;
                    OnPropertyChanged(nameof(InputTxt));
                }
            }
        }

        
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }

}



