using System.Windows;
using System.Windows.Controls;
using System.Windows.Data; //Binding
using System.Windows.Controls.Primitives;

namespace WpfApp1
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); // 디자이너단에 정의된 Form컴포넌트 정의를 호출
            DataContext = new CalculatorViewModel();
        }



    }
}

