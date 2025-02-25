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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShapeSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InputFields.Children.Clear();

            if (ShapeSelector.SelectedItem is ComboBoxItem selectedItem)
            {
                switch (selectedItem.Content.ToString())
                {
                    case "Круг":
                        AddInputField("Радиус:", "radius");
                        break;
                    case "Квадрат":
                        AddInputField("Сторона:", "side");
                        break;
                    case "Прямоугольник":
                        AddInputField("Длина:", "length");
                        AddInputField("Ширина:", "width");
                        break;
                }
            }
        }

        private void AddInputField(string labelText, string name)
        {
            TextBlock label = new TextBlock { Text = labelText };
            TextBox textBox = new TextBox { Name = name, Margin = new Thickness(0, 5, 0, 10) };

            InputFields.Children.Add(label);
            InputFields.Children.Add(textBox);
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            double perimeter = 0;

            if (ShapeSelector.SelectedItem is ComboBoxItem selectedItem)
            {
                switch (selectedItem.Content.ToString())
                {
                    case "Круг":
                        double radius = double.Parse(((TextBox)InputFields.Children[1]).Text);
                        perimeter = 2 * Math.PI * radius;
                        break;
                    case "Квадрат":
                        double side = double.Parse(((TextBox)InputFields.Children[1]).Text);
                        perimeter = 4 * side;
                        break;
                    case "Прямоугольник":
                        double length = double.Parse(((TextBox)InputFields.Children[1]).Text);
                        double width = double.Parse(((TextBox)InputFields.Children[3]).Text);
                        perimeter = 2 * (length + width);
                        break;
                }
            }

            ResultTextBlock.Text = $"Периметр: {perimeter:F2}";
        }
    }
}
