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
    /// Логика взаимодействия для PostPage.xaml
    /// </summary>
    public partial class PostPage : Page
    {
        PostTableAdapter PostTableAdapter = new PostTableAdapter();

        public PostPage()
        {
            InitializeComponent();
            grid_brend.ItemsSource = PostTableAdapter.GetData();
        }

        private void grid_brend_Selected(object sender, RoutedEventArgs e)
        {
            if (grid_brend.SelectedItems.Count > 0)
            {
                DataRowView rowView = grid_brend.SelectedItems[0] as DataRowView;

                if (rowView != null)
                {
                    string valueInColumn1 = rowView["NamePost"].ToString();
                    string valueInColumn2 = rowView["HoursOfWorks"].ToString();
                    string valueInColumn3 = rowView["LoginParol_ID"].ToString();



                    Named.Text = valueInColumn1;
                    HoursOfWork.Text = valueInColumn2;
                    Rolis.Text = valueInColumn3;

                }
            }
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Named.Text != "" && HoursOfWork.Text != "" &&Rolis.Text != "")
                {
                    object id = (grid_brend.SelectedItem as DataRowView).Row[0];
                    PostTableAdapter.UpdateQuery(Named.Text, HoursOfWork.Text, Convert.ToInt32(Rolis.Text), Convert.ToInt32(id));
                    grid_brend.ItemsSource = PostTableAdapter.GetData();

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
                PostTableAdapter.DeleteQuery(Convert.ToInt32(id));
                grid_brend.ItemsSource = PostTableAdapter.GetData();
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
                if (Named.Text != "" && HoursOfWork.Text != "" && Rolis.Text != "")
                {
                    PostTableAdapter.InsertQuery(Named.Text, HoursOfWork.Text,Convert.ToInt32(Rolis.Text));
                    grid_brend.ItemsSource = PostTableAdapter.GetData();

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
