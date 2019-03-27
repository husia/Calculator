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
using Calculator.Services;

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CalculateService service { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            service = new CalculateService();
            myGrid.DataContext = service;
           
        }

        

        private void AddClick(object sender, RoutedEventArgs e)
        {
            var value = (sender as Button).Content.ToString();
            if ((sender as Button).Name == "clearButton")
            {
                service.ClearResult();

            }
            else if (value == "+")
            {
                service.SummClick();
            }
            else if (value == "*")
            {
                service.MultiClick();
            }
            else if (value == "/")
            {
                service.DivideClick();
            }
            else if (value == "=")
            {
                service.GetResult();
            }
            else
            {
                service.AddtoResult(value);


            }
        }
        

       
    }
}
