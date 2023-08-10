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
        #region [변수]
        private int L_Operand;
        private int R_Operand;
        private int result;
        private string Operator;
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

        private string resultText = "";

        public string ResultText
        {
            get { return resultText; }
            set
            {
                resultText = value;
                OnPropertyChanged("resultText");
            }
        }
        
        public ICommand NumberButtonCommand { get; private set; }
        public ICommand OperatorButtonCommand { get; private set; }
        public ICommand ResultButtonCommand { get; private set; }
        public ICommand ClearButtonCommand { get; private set; }

        public CalculatorViewModel()
        {
            NumberButtonCommand = new RelayCommand(NumberButtonCommandExecute);
            OperatorButtonCommand = new RelayCommand(OperatorButtonCommandExecute); 
            ResultButtonCommand = new RelayCommand(ResultButtonCommandExecute);
            ClearButtonCommand = new RelayCommand(ClearButtonCommandExecute);
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

            L_Operand = int.Parse(inputText);
            ResultText = $"{inputText}{parameter}";
            Operator = parameter.ToString();
            
            inputText = "";

            return;
        }

        private void ResultButtonCommandExecute(object parameter)
        {
            
            R_Operand = int.Parse(inputText);
            ResultText =$"{L_Operand}{Operator}{R_Operand}{" = "}";
            

            if (Operator == "/")
            {
                result = L_Operand / R_Operand;
                InputText = result.ToString();
               

            }
            else if (Operator == "-")
            {
                result = L_Operand - R_Operand;
                InputText = result.ToString();
            }
            else if (Operator == "+")
            {
                result = L_Operand + R_Operand;
                InputText = result.ToString();
            }
            else if (Operator == "x")
            {
                result = L_Operand * R_Operand;
                InputText = result.ToString();

            }
            
        }
        private void ClearButtonCommandExecute(object parameter)
        {  
            InputText = "";
            ResultText="";
            L_Operand = 0;
            R_Operand = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}



