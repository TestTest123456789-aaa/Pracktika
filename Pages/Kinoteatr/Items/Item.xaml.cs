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
using Практика_27.Classes;

namespace Практика_27.Pages.Kinoteatr.Items
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        KinoteatrContext Kinoteatr;
        Main main;
        public Item(KinoteatrContext Kinoteatr, Main main)
        {
            InitializeComponent();

            name.Text = Kinoteatr.Name;
            countZal.Text = Kinoteatr.CountZal.ToString();
            count.Text = Kinoteatr.Count.ToString();
            this.Kinoteatr = Kinoteatr;
            this.main = main;
        }

        private void EditRecord(object sender, RoutedEventArgs e) =>
            MainWindow.init.OpenPage(new Add(this.Kinoteatr));

        private void DeleteRecord(object sender, RoutedEventArgs e)
        {
            Kinoteatr.Delete();
            main.parent.Children.Remove(this);
        }
    }
}
