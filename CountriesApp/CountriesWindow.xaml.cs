﻿using CountriesApp.Classes;
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
using System.Windows.Shapes;

namespace CountriesApp
{
    /// <summary>
    /// Interaction logic for CountriesWindow.xaml
    /// </summary>
    public partial class CountriesWindow : Window
    {
        List<Country> _countries;
        public CountriesWindow(List<Country> countries)
        {
            InitializeComponent();
            countriesListView.Items.Clear();
            countriesListView.ItemsSource = countries;
        }

        private void countriesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
