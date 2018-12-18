using System.Windows;
using System.Windows.Controls;
using TextParser.Services;

namespace TextParser
{
    /// <summary>
    /// Я мог бы реализовать паттерн MVVM, например, но задача предельно простая, не вижу смысла так усложнять себе жизнь, да и вам
    // Потому будем реализовывать логику тут, хотя я избегаю обычно трогать класс MainWindow, передавая её на ViewModel
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            TextParserService service = new TextParserService();
            ResultWindow result = new ResultWindow(service.Parse(textBox.Text));
            result.Show();
            this.Close();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
