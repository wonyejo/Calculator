//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace WpfApp1.Models
//{
//    class CalculatorModel
//    {
//        private string inputText = "";
//        public string InputText
//        {
//            get { return inputText; }
//            set
//            {
//                inputText = value;
//                OnPropertyChanged();
//            }
//        }

//        public ICommand NumberButtonCommand { get; private set; }
//        public ICommand OperatorButtonCommand { get; private set; }
//        public ICommand CalculateButtonCommand { get; private set; }
//        public ICommand ClearButtonCommand { get; private set; }

//        public CalculatorViewModel()
//        {
//            NumberButtonCommand = new RelayCommand(NumberButtonCommandExecute);
//            OperatorButtonCommand = new RelayCommand(OperatorButtonCommandExecute);
//            CalculateButtonCommand = new RelayCommand(CalculateButtonCommandExecute);
//            ClearButtonCommand = new RelayCommand(ClearButtonCommandExecute);
//        }

//        private void NumberButtonCommandExecute(object parameter)
//        {
//            if (parameter is string number)
//            {
//                InputText += number;
//            }
//        }

//        private void OperatorButtonCommandExecute(object parameter)
//        {
//            if (parameter is string op)
//            {
//                InputText += $" {op} ";
//            }
//        }

//        private void CalculateButtonCommandExecute(object parameter)
//        {
//            string[] tokens = InputText.Split(' ');
//            Stack<decimal> stack = new Stack<decimal>();

//            foreach (string token in tokens)
//            {
//                if (decimal.TryParse(token, out decimal number))
//                {
//                    stack.Push(number);
//                }
//                else if (IsOperator(token))
//                {
//                    if (stack.Count < 2)
//                    {
//                        InputText = "Error";
//                        return;
//                    }

//                    decimal operand2 = stack.Pop();
//                    decimal operand1 = stack.Pop();

//                    decimal result = PerformOperation(operand1, operand2, token);
//                    stack.Push(result);
//                }
//            }

//            if (stack.Count == 1)
//            {
//                InputText = stack.Peek().ToString();
//            }
//            else
//            {
//                InputText = "Error";
//            }
//        }

//        private bool IsOperator(string token)
//        {
//            return token == "+" || token == "-" || token == "*" || token == "/";
//        }

//        private decimal PerformOperation(decimal operand1, decimal operand2, string op)
//        {
//            switch (op)
//            {
//                case "+":
//                    return operand1 + operand2;
//                case "-":
//                    return operand1 - operand2;
//                case "*":
//                    return operand1 * operand2;
//                case "/":
//                    if (operand2 == 0)
//                    {
//                        InputText = "Error";
//                        return 0;
//                    }
//                    return operand1 / operand2;
//                default:
//                    return 0;
//            }
//        }

//        private void ClearButtonCommandExecute(object parameter)
//        {
//            InputText = "";
//        }

//        public event PropertyChangedEventHandler PropertyChanged;

//        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
//        {
//            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//        }

//    }



