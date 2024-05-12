﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

namespace Практика_27
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow init;
        public MainWindow()
        {
            InitializeComponent();
            OpenPage(new Pages.Kinoteatr.Main());
            init = this;
        }

        public void OpenPage(Page Page) {
            Frame.Navigate(Page);
        }

        private void OpenKino(object sender, RoutedEventArgs e) => OpenPage(new Pages.Kinoteatr.Main());

        private void OpenAfisha(object sender, RoutedEventArgs e) => OpenPage(new Pages.Afisha.Main());
    }
}
// ISP_21_4_8
// g6Fc6Yl3E#
// student.permaviat.ru
// Tickets