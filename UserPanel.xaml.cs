using Practika5_12.BookStoreDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
    /// Логика взаимодействия для UserPanel.xaml
    /// </summary>
    public partial class UserPanel : Page
    {
        BookTableAdapter BookTableAdapter = new BookTableAdapter();
        public UserPanel()
        {
            InitializeComponent();
             List<Class2> products = new List<Class2>();
             var dataRows = BookTableAdapter.GetData().Rows;
             foreach (DataRow dataRow in dataRows)
             {
                 string name = dataRow["Title"].ToString();
                 string title = dataRow["Price"].ToString();
                 string size = dataRow["StockQuantity"].ToString();
                 int price = Convert.ToInt32(dataRow["Author_ID"]);
                 // Создание экземпляра класса Product и добавление его в список
                 products.Add(new Class2(name,Convert.ToInt32(title), size, price));

             }
             // Установка списка товаров в качестве источника данных для элемента управления
             list__.ItemsSource = products;
         
        }
        private void list___SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Получаем выбранную строку в DataGrid
            Class2 selectedProduct = (Class2)list__.SelectedItem;

            if (selectedProduct != null)
            {
                List<Class2> products = new List<Class2>();
                string name = selectedProduct.Title;
                int price = selectedProduct.Price;
                int autor = selectedProduct.Author_ID;
                string stock = selectedProduct.StockQuantity;
                products.Add(new Class2(name, price,stock , autor));
                selected.Items.Add(products[0]);
                selected.Items.Refresh();
                couunt.Content = Convert.ToInt32(couunt.Content) + price;
            }

        }

        private void selected_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Class2 selectedProduct = selected.SelectedItem as Class2;
            selected.Items.Remove(selectedProduct);
            selected.Items.Refresh();

            Class2 selecte = (Class2)list__.SelectedItem;

            if (selectedProduct != null)
            {


                int price = selectedProduct.Price;

                couunt.Content = Convert.ToInt32(couunt.Content) - price;

            }
        }

        private void end_Click(object sender, RoutedEventArgs e)
        {
            List<string> products = new List<string>();
            var dataRows = selected.Items;
            foreach (Class2 dataRow in dataRows)
            {
                string name = dataRow.Title;



                // Создание экземпляра класса Product и добавление его в список
                products.Add(name);

            }
            string names = string.Join(",", products);

           
            using (StreamWriter file = new StreamWriter("C:\\Users\\earbu\\OneDrive\\Рабочий стол\\chek.txt"))
            {
                file.WriteLine($"\t\t Магазин Книг\n" + $"\t\t Кассовый чек .......\n" + $"\t{names}\n" + $"\tИтог оплате: {couunt.Content}\n" + $"\tОплачено:{couunt.Content}\n");
                MessageBox.Show("Покупка прошла успешно!");
            }
        }
    }
}
