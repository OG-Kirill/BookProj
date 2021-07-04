using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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


namespace BookMag.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
        
    {
        List<Книги> BookList = Class.DataBase.DB.Книги.ToList();

        public AdminPage()
        {
            InitializeComponent();
            DG.ItemsSource = BookList;
        }
        int i = -1;
        int indexChange;
        private void MediaElement_Initialized(object sender, EventArgs e)
        {
            if (i < BookList.Count)
            {
                i++;
                MediaElement ME = (MediaElement)sender;
                Книги S = BookList[i];
                Uri U = new Uri(S.Обложка, UriKind.RelativeOrAbsolute);
                ME.Source = U;
                //   i++;
            }
        }
        private void TextBlock_Initialized(object sender, EventArgs e)
        {
            if (i < BookList.Count)
            {
                TextBlock TB = (TextBlock)sender;
                Книги S = BookList[i];
                TB.Text = "Название: " + S.Название;
                //  i++;
            }

        }

        private void Price_Initialized(object sender, EventArgs e)
        {
            TextBlock TB = (TextBlock)sender;
            Книги S = BookList[i];
            TB.Text = "Цена: " + Convert.ToInt32(S.Цена) + " руб.";
        }

        private void autor_Initialized(object sender, EventArgs e)
        {
            TextBlock TB = (TextBlock)sender;
            Книги S = BookList[i];
            TB.Text = "Автор: " + Convert.ToString(S.Авторы.Автор);
        }

        private void nalichOnSklad_Initialized(object sender, EventArgs e)
        {
            TextBlock TB = (TextBlock)sender;
            Книги S = BookList[i];
            if (S.Количество_склад > 5)
            {
                TB.Text = "Наличие на складе: " + "много";
            }
            else
            {
                TB.Text = "Наличие на складе: " + Convert.ToInt32(S.Количество_склад) + " штук";
            }
        }


        private void nalichOnShop_Initialized(object sender, EventArgs e)
        {
            TextBlock TB = (TextBlock)sender;
            Книги S = BookList[i];
            if (S.Количество_магазин > 5)
            {
                TB.Text = "Наличие на складе: " + "много";
            }
            else
            {
                TB.Text = "Наличие в магазине: " + Convert.ToInt32(S.Количество_магазин) + " штук";
            }
        }
        int sum = 0;
        int price__sum = 0;
        int discount__price = 0;
        private void Add__book_Click(object sender, RoutedEventArgs e)
        {
            Button Add__book = (Button)sender;
            int ind = Convert.ToInt32(Add__book.Uid);
            indexChange = Convert.ToInt32(Add__book.Uid);
            Книги S = BookList[indexChange];
            int price = S.Цена;
            sum += 1;
            price__sum += price; 
            count__cart.Text = "Количество выбранных книг: "  + sum;
            price__cart.Text = "Цена покупки: " + price__sum + " рублей";
            discount__cart.Text = "Скидка составила: " + price;
        }

        private void Add__book_Initialized(object sender, EventArgs e)
        {
                Button BNew = (Button)sender;
                if (BNew != null)
                {
                    BNew.Uid = Convert.ToString(i);
                }           
        }

    }
}
