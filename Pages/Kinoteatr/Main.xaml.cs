﻿using System;
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

namespace Практика_27.Pages.Kinoteatr
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        List<KinoteatrContext> AllKinoteatrs = KinoteatrContext.Select();
        public Main()
        {
            InitializeComponent();

            foreach (KinoteatrContext item in AllKinoteatrs)
            {
                parent.Children.Add(new  Items.Item(item, this));
            }
        }

        private void AddRecord(object sender, RoutedEventArgs e) => 
            MainWindow.init.OpenPage(new Add());
    }
}
