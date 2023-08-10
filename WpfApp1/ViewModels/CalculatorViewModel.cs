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

        #region [필드]
        private double leftOperand;
        private double rightOperand;
        private double result;
        private string Operator;
        private string inputText = "";
        private string resultText = "";
        private bool decimalPointEntered = false;
        #endregion

        #region [속성]
        public string InputText
            {
                get { return inputText; }
                set
                {
                    inputText = value;
                    OnPropertyChanged("inputText");
                }
            }
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
        #endregion

        #region [생성자]
        public CalculatorViewModel()
        {
            NumberButtonCommand = new RelayCommand(NumberButtonCommandExecute);
            OperatorButtonCommand = new RelayCommand(OperatorButtonCommandExecute);
            ResultButtonCommand = new RelayCommand(ResultButtonCommandExecute);
            ClearButtonCommand = new RelayCommand(ClearButtonCommandExecute);
        }


        #endregion

        #region [메서드]

        private void NumberButtonCommandExecute(object parameter)
        {
            if (parameter is string number)
            {
                if (number == ".")
                {
                    if (!decimalPointEntered)
                    {
                        InputText = $"{inputText}{number}";
                        decimalPointEntered = true;
                    }
                }
                else
                {
                    InputText = $"{inputText}{number}";
                }
            }
        }


        private void OperatorButtonCommandExecute(object parameter)
        {

            leftOperand = double.Parse(inputText);
            ResultText = $"{inputText}{parameter}";
            Operator = parameter.ToString();
            decimalPointEntered = false; // 연산자가 입력될 때 소수점 허용 플래그 초기화
            inputText = "";

            return;
        }

        private void ResultButtonCommandExecute(object parameter)
        {

            rightOperand = double.Parse(inputText);
            ResultText = $"{leftOperand}{Operator}{rightOperand}{" = "}";


            if (Operator == "/")
            {
                result = leftOperand / rightOperand;
                InputText = result.ToString();


            }
            else if (Operator == "-")
            {
                result = leftOperand - rightOperand;
                InputText = result.ToString();
            }
            else if (Operator == "+")
            {
                result = leftOperand + rightOperand;
                InputText = result.ToString();
            }
            else if (Operator == "x")
            {
                result = leftOperand * rightOperand;
                InputText = result.ToString();

            }

        }
        private void ClearButtonCommandExecute(object parameter)
        {
            InputText = "";
            ResultText = "";
            leftOperand = 0;
            rightOperand = 0;
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region [중첩된 클래스]
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
       
    }

}



