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
        private decimal leftOperand;
        private decimal rightOperand;
        private decimal result;
        private string Operator;
        private string inputText = "";
        private string resultText = "";
        private bool doublePointEntered = false;
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
        /*
        * @brief 숫자 버튼을 누르면 InputTextBox에 해당 숫자가 입력됩니다.  
        * @param parameter: 누른 숫자의 값
        * @return 반환값 없음
        * @note Patch-notes
        * 2023-08-10|조예원|설명작성
        * @warning 없음
        */
        private void NumberButtonCommandExecute(object parameter)
        {
            if (parameter is string number)
            {
                if (number == ".")
                {
                    if (!doublePointEntered)
                    {
                        InputText = $"{inputText}{number}";
                        doublePointEntered = true;
                    }
                }
                else
                {
                    InputText = $"{inputText}{number}";
                }
            }
        }

        /*
        * @brief 연산자 버튼을 누르면 ResultTextBox에 피연산자와 연산자가 입력됩니다.  
        * @param parameter: 누른 연산자의 값
        * @return 반환값 없음
        * @note Patch-notes
        * 2023-08-10|조예원|설명작성
        * @warning 없음
        */

        private void OperatorButtonCommandExecute(object parameter)
        {
            doublePointEntered = false;
            if (string.IsNullOrEmpty(Operator))
            {
                leftOperand = decimal.Parse(inputText);
                ResultText = $"{leftOperand}{parameter}";
                Operator = parameter.ToString();
                inputText = "";
            }
            return;
        }
            /*
            * @brief = 버튼을 누르면 ResultTextBox에 식이 입력되고, InputTextBox에 결과값이 입력됩니다.  
            * @param parameter: 사용되지 않음
            * @return 반환값 없음
            * @note Patch-notes
            * 2023-08-10|조예원|설명작성
            * @warning 없음
            */
            private void ResultButtonCommandExecute(object parameter)
            {
            if (!string.IsNullOrEmpty(inputText) && !string.IsNullOrEmpty(Operator))
            {
                rightOperand = decimal.Parse(inputText);
                ResultText = $"{leftOperand}{Operator}{rightOperand}{" = "}";

                if (Operator == "/")
                {
           
                    result = leftOperand / rightOperand;
                    InputText = result.ToString();
                    if (rightOperand == 0)
                    {
                        ResultText = "Error: Divide by zero";


                    }
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
            // 결과를 표시하지 않는 경우에도 피연산자 초기화
            leftOperand = 0;
            rightOperand = 0;
            Operator = "";
        }


        /*
        * @brief C 버튼을 누르면 InputTextBox와 ResultTextBox가 비워집니다.  
        * @param parameter: 사용되지 않음
        * @return 반환값 없음
        * @note Patch-notes
        * 2023-08-10|조예원|설명작성
        * @warning 없음
        */
        private void ClearButtonCommandExecute(object parameter)
        {
            InputText = "";
            ResultText = "";
            leftOperand = 0;
            rightOperand = 0;
            Operator = "";
            doublePointEntered = false;
        }
        /*
        * @brief 바뀐 프로퍼티가 있으면 그 변화를 반영합니다.  
        * @param propertyName: 값이 바뀐 프로퍼티의 이름
        * @return 반환값 없음
        * @note Patch-notes
        * 2023-08-10|조예원|설명작성
        * @warning 없음
        */
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



