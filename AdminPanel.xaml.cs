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

namespace Practika5_12
{
    /// <summary>
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Page
    {
        public AdminPanel()
        {
            InitializeComponent();
            
        }

       

        private void autor_table_Click(object sender, RoutedEventArgs e)
        {
            Button button = (sender as Button);
            if (button != null)
            {
                if (button.Name == "Login_parol_table")
                {
                    frame_adminpanel.Content = new Roli_paroli();
                }
                if (button.Name == "autor_table")
                {
                    frame_adminpanel.Content = new AutorPage();
                }
                if (button.Name == "books_table")
                {
                    frame_adminpanel.Content = new BooksPage();
                }
                if (button.Name == "Clients_table")
                {
                    frame_adminpanel.Content = new ClientsPage();
                }
                if (button.Name == "employers_table")
                {
                    frame_adminpanel.Content = new EmployersPage();
                }
                if (button.Name == "Ordes_detal_table")
                {
                    frame_adminpanel.Content = new OrdersDetalPage();
                }
                if (button.Name == "Orders_table")
                {
                    frame_adminpanel.Content = new OrdersPage();
                }
                if (button.Name == "Post_table")
                {
                    frame_adminpanel.Content = new PostPage();
                }
                if (button.Name == "Sclad_table")
                {
                    frame_adminpanel.Content = new ScladPage();
                }
                if (button.Name == "Store_table")
                {
                    frame_adminpanel.Content = new StorePage();
                }
            }
        }
    }
}
