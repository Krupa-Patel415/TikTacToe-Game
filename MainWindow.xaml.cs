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

namespace KrupaTikTacToe
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void uvu(object sender, RoutedEventArgs e)
        {
            UserUserGameFrontend win1 = new UserUserGameFrontend();
            win1.Show();
        }
        public void uvc(object sender, RoutedEventArgs e)
        {
            UserComputerGameLogic win2 = new UserComputerGameLogic();
            win2.Show();
        }
    }
}
