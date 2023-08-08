using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{

    /// <summary>
    /// Calculator.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Calculator : Page
    {
        private int L_Operand;
        private int R_Operand;
        private int result;
        private string Operator;


        public Calculator()
        {
            InitializeComponent();
        }
       
        /*
        * @brief 숫자 버튼을 누르면 InputTextBox에 해당 숫자가 입력됩니다.  
        * @param sender: 어떤 버튼이 클릭되었는지, e: 해당 이벤트에 대한 정보
        * @return 반환값 없음
        * @note Patch-notes
        * 2023-08-07|조예원|설명작성
        * @warning 없음
        */
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            string number = clickedButton.Content.ToString();
            InputTextBox.Text += number;
        }

        /*
        * @brief 연산자 버튼을 누르면 ResultTextBox에 피연산자와 연산자가 입력됩니다.  
        * @param sender: 어떤 버튼이 클릭되었는지, e: 해당 이벤트에 대한 정보
        * @return 반환값 없음
        * @note Patch-notes
        * 2023-08-07|조예원|설명작성
        * @warning 없음
        */
        private void Operator_Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            string Oper = clickedButton.Content.ToString();
            Operator = Oper;
            L_Operand = int.Parse(InputTextBox.Text);
            ResultTextBox.Text += InputTextBox.Text + Oper;

            InputTextBox.Text = "";
           

            



        }

        private void Result_Button_Click(object sender, RoutedEventArgs e)
        {
            
            R_Operand = int.Parse(InputTextBox.Text);
            ResultTextBox.Text += R_Operand + " = ";
            if (Operator == "/")
            {
                result = L_Operand / R_Operand;
                InputTextBox.Text = result.ToString();
            }
            else if (Operator == "-")
            {
                result = L_Operand - R_Operand;
                InputTextBox.Text = result.ToString();
            }
            else if (Operator == "+")
            {
                result = L_Operand + R_Operand;
                InputTextBox.Text = result.ToString();
            }
            else if (Operator == "x")
            {
                result = L_Operand * R_Operand;
                InputTextBox.Text = result.ToString();

            }
            

            
        }
    }
}
