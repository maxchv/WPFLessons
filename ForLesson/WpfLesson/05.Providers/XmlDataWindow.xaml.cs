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
using System.Windows.Shapes;

namespace _05.Providers
{
    /// <summary>
    /// Логика взаимодействия для XmlDataWindow.xaml
    /// </summary>
    public partial class XmlDataWindow : Window
    {
        public XmlDataWindow()
        {
            InitializeComponent();
            //genderCombo.ItemsSource = Enum.GetValues(typeof(Gender));
        }
    }

    public enum Gender
    {
        Male,
        Female,
        Unknown
    }
}
