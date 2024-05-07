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

namespace Практика_27.Pages.Afisha
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        List<KinoteatrContext> AllKinoteatrs = KinoteatrContext.Select();

        AfishaContext afisha;
        public Add(AfishaContext afisha = null)
        {
            InitializeComponent();

            foreach (var item in AllKinoteatrs)
            {
                kinoteatrs.Items.Add(item.Name);
            }

            kinoteatrs.Items.Add("Выберите .....");

            if (afisha != null)
            {
                this.afisha = afisha;
                kinoteatrs.SelectedIndex = AllKinoteatrs.FindIndex(x => x.Id == afisha.IdKinoteatr);
                name.Text = afisha.Name;
                data.Text = afisha.Time.ToString("yyyy-MM-dd");
                time.Text = afisha.Time.ToString("HH-mn");
                price.Text = afisha.Price.ToString();
                bthAdd.Content = "Изменить";
            }
            else
            {
                kinoteatrs.SelectedIndex = kinoteatrs.Items.Count - 1;
            }
        }

        private void AddRecord(object sender, RoutedEventArgs e)
        {
            DateTime dataAfisha;
            TimeSpan timeAfisha;
            int Price = -1;

            if (name.Text == "")
            {
                MessageBox.Show("Укажите наименование");
                return;
            }
            if (kinoteatrs.SelectedIndex == kinoteatrs.Items.Count - 1)
            {
                MessageBox.Show("Выберите кинотеатр");
                return;
            }
            if (data.Text == "")
            {
                MessageBox.Show("Укажите дату");
                return;
            }
            if (time.Text == "" || TimeSpan.TryParse(time.Text, out timeAfisha) == false)
            {
                MessageBox.Show("Укажите время");
                return;
            }
            if (price.Text == "" || int.TryParse(price.Text, out Price) == false)
            {
                MessageBox.Show("Укажите стоимость");
                return;
            }

            DateTime.TryParse(data.Text, out dataAfisha);
            dataAfisha.Add(timeAfisha);

            if(afisha == null)
            {
                AfishaContext newAfisha = new AfishaContext(
                    0,
                    AllKinoteatrs.Find(x => x.Name == kinoteatrs.SelectedItem).Id,
                    name.Text,
                    dataAfisha,
                    Price);
                newAfisha.Add();
            }
            else
            {
                afisha = new AfishaContext(
                    afisha.Id,
                    AllKinoteatrs.Find(x => x.Name == kinoteatrs.SelectedItem).Id,
                    name.Text,
                    dataAfisha,
                    Price);
                afisha.Update();
            }
            MainWindow.init.OpenPage(new Afisha.Main());
        }
    }
}
