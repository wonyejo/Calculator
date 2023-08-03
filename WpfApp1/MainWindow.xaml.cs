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
            InitializeComponent();
            Binding binding = new Binding("Text"); //바인딩 객체 생성 (src의 attribute)
            binding.Source = txt;
            //binding.Path = new PropertyPath(TextBox.TextProperty);
            label.SetBinding(Label.ContentProperty, binding);
            //Target요소.SetBinding(속성, 바인딩객체)
        }

    }
}

