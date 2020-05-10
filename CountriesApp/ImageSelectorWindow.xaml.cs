using Microsoft.Win32;
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
    /// Interaction logic for ImageSelector.xaml
    /// </summary>
    public partial class ImageSelectorWindow : Window
    {
        public ImageSelectorWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.png, *.jpg)|*.png;*.jpg;*.jpeg|All files (*.*)|*.*";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            if (dialog.ShowDialog() == true)
            {
                string fileName = dialog.FileName;
                selectedImage.Source = new BitmapImage(new Uri(fileName));

            }
            //ListCountriesAsync();
        }
        //private async void ListCountriesAsync()
        //{
        //    string url = "https://restcountries.eu/rest/v2/all?fields=name;capital;currenciesSources";
        //    //string prediction_key = "igaubfnlasdliha6a73fa";
        //    //string content_type = "application/octet-stream";
        //    //var file = File.ReadAllBytes(filename);
        //    using (HttpClient client = new HttpClient())
        //    {
        //        //client.DefaultRequestHeaders.Add("Prediction-Key", prediction_key);

        //        //using (var content = new ByteArrayContent(file))
        //        //{
        //        //    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue;
        //        //}
        //        var response = await client.GetAsync(url);

        //        var responseString = await response.Content.ReadAsStringAsync();
        //        JObject jsonResponse = JObject.Parse(responseString);


        //    }
        //}
    }
}
