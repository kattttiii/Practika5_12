using Practika5_12.BookStoreDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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
using Practika5_12.BookStoreDataSetTableAdapters;
namespace Practika5_12
{
    /// <summary>
    /// Логика взаимодействия для StorePage.xaml
    /// </summary>
    public partial class StorePage : Page
    {
        StoreTableAdapter StoreTableAdapter = new StoreTableAdapter();
        public StorePage()
        {
            InitializeComponent();
            grid_brend.ItemsSource = StoreTableAdapter.GetData();
        }

        private void grid_brend_Selected(object sender, RoutedEventArgs e)
        {
            if (grid_brend.SelectedItems.Count > 0)
            {
                DataRowView rowView = grid_brend.SelectedItems[0] as DataRowView;

                if (rowView != null)
                {
                    string valueInColumn1 = rowView["StoreName"].ToString();
                    string valueInColumn2 = rowView["StoreAddress"].ToString();
                    string valueInColumn3 = rowView["Sklad_ID"].ToString();



                    Named.Text = valueInColumn1;
                    Adress.Text = valueInColumn2;
                    id_sclad.Text = valueInColumn3;

                }
            }
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Named.Text != "" && Adress.Text != "" && id_sclad.Text != "")
                {
                    object id = (grid_brend.SelectedItem as DataRowView).Row[0];
                    StoreTableAdapter.UpdateQuery(Named.Text,Adress.Text,Convert.ToInt32(id_sclad.Text), Convert.ToInt32(id));
                    grid_brend.ItemsSource = StoreTableAdapter.GetData();

                }
                else
                {
                    return;
                }
            }
            catch
            {
                return;
            }
        }

        private void delate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object id = (grid_brend.SelectedItem as DataRowView).Row[0];
                StoreTableAdapter.DeleteQuery(Convert.ToInt32(id));
                grid_brend.ItemsSource = StoreTableAdapter.GetData();
            }
            catch
            {
                return;
            }
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Named.Text != "" && Adress.Text != "" && id_sclad.Text != "")
                {
                    StoreTableAdapter.InsertQuery(Named.Text,Adress.Text, Convert.ToInt32(id_sclad.Text));
                    grid_brend.ItemsSource = StoreTableAdapter.GetData();

                }
                else
                {
                    return;
                }
            }
            catch
            {
                return;
            }
        }
    }
}
