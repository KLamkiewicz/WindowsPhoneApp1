using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace AngielskiNauka
{
    public partial class Page2 : PhoneApplicationPage
    {
        public Page2()
        {
            InitializeComponent();
            fillCategories();
            textBlock1.Text = "Instrukcja " + System.Environment.NewLine + "Wpisz tłumaczenie polskiego słowa";
            listBox1.SelectedIndex = 0;
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void fillCategories()
        {

            foreach (Slowko s in MainPage.s.slowka)
            {
                if (!listBox1.Items.Contains(s.kategoria))
                {
                    listBox1.Items.Add(s.kategoria);
                }

            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/SlowkaNauka.xaml?kategoria=" + listBox1.SelectedItem, UriKind.Relative));
        }
    }
}