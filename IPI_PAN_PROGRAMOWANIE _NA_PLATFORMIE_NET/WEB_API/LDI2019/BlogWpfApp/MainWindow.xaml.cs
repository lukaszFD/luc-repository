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
using Microsoft.Rest;

namespace BlogWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public const string SERVICE_URL = "http://localhost:49605/";

        public static BlogWeb GetBlogWebClient(string uri = SERVICE_URL)
        {
            BlogWeb client = new BlogWeb(new Uri(uri),
                new BasicAuthenticationCredentials());
            return client;
        }


        private void ButtonDostepne_Click(object sender, RoutedEventArgs e)
        {
            BlogWeb client = GetBlogWebClient();

            var list = client.Blogs.GetAllBlogs();

            UpdateBlogs(list);

        }

        private void UpdateBlogs(IList<Models.Blog> list)
        {
            ListBoxBlogi.Items.Clear();
            foreach (var item in list)
            {
                ListBoxBlogi.Items.Add(item);
            }
        }

    }
}
