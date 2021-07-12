using System;
using System.Collections.Generic;
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
using System.Net.Http.Headers;
using System.Net.Http;


namespace WpfApp_WebApi_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public List<Product> GetProductData()
        {
            List<Product> productlist = new List<Product>();
            HttpClient client = new HttpClient();
            // setting content typoe

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // initilization
            HttpResponseMessage response = new HttpResponseMessage();

            //http get

            response = client.GetAsync("http://localhost:61797/api/Products/").Result;
            // varification
            if (response.IsSuccessStatusCode) // 200 status code
            {
                //reading response
                productlist = response.Content.ReadAsAsync<List<Product>>().Result;  //microsoft.AspNet.WebApi.Client install this for reasasasync

                //realising
                response.Dispose();


            }

            else
            {
                MessageBox.Show("Error Code : " + response.StatusCode + ": message -" + response.ReasonPhrase);
            }
            return productlist;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            this.dgproduct.DataContext = GetProductData();
        }
    }
}
