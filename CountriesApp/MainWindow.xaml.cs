using CountriesApp.Classes;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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

namespace CountriesApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Country> countries;
        List<string> regions;
        List<string> subregions;
        public MainWindow()
        {
            InitializeComponent();
            ListCountriesAsync();
        }

        private void loadRestServiceButton_Click(object sender, RoutedEventArgs e)
        {
            List<Country> selectedCountries = countries;
            if (!regionsComboBox.SelectedItem.Equals("All regions"))
            {
                selectedCountries = countries.Where(c => c.region.Equals(regionsComboBox.SelectedItem)).ToList();
                if (!subregionsComboBox.SelectedItem.Equals($"All {regionsComboBox.SelectedItem} subregions"))
                {
                    selectedCountries = selectedCountries.Where(c => c.subregion.Equals(subregionsComboBox.SelectedItem)).ToList();
                }
            }
            CountriesWindow countriesWindow = new CountriesWindow(selectedCountries);
            countriesWindow.ShowDialog();
        }

        private async void ListCountriesAsync()
        {
            string url = "https://restcountries.eu/rest/v2/all";
            using(HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                var responseString = await response.Content.ReadAsStringAsync();
                countries = JsonConvert.DeserializeObject<List<Country>>(responseString);
            }
            generateRegions();
            generateSubregions();
        }

        private void generateRegions()
        {
            regions = countries.Select(o => o.region).Distinct().ToList();
            regions.Add("All regions");
            regionsComboBox.ItemsSource = regions;
            regionsComboBox.SelectedItem = "All regions";
        }

        private void generateSubregions()
        {
            subregions = countries.Select(o => o.subregion).Distinct().ToList();
            subregions.Add("All subregions");
            subregionsComboBox.ItemsSource = subregions;
            subregionsComboBox.SelectedItem = "All subregions";
        }

        private void loadImageButton_Click(object sender, RoutedEventArgs e)
        {
            ImageSelectorWindow imageSelectorWindow = new ImageSelectorWindow();
            imageSelectorWindow.ShowDialog();
        }

        private void regionsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if(comboBox.SelectedItem.Equals("All regions"))
            {
                generateSubregions();
            } else
            {
                subregions = countries.Where(o => o.region.Equals(comboBox.SelectedItem)).Select(o => o.subregion).Distinct().ToList();
                subregions.Add($"All {comboBox.SelectedItem} subregions");
                subregionsComboBox.ItemsSource = subregions;
                subregionsComboBox.SelectedItem = $"All {comboBox.SelectedItem} subregions";
            }

        }
    }
}
