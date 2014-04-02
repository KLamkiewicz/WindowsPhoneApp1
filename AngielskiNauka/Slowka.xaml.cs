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
    public partial class Slowka : PhoneApplicationPage
    {
        public Slowka()
        {
            InitializeComponent();
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void dict(string kategoria)
        {
            int i = 0;
            //listBox1.Items.Clear();
            textBlock1.Text = " ";
            textBlock2.Text = " ";
            foreach(Slowko s in MainPage.s.slowka)
            {
                if(s.kategoria.Equals(kategoria)){
                    textBlock1.Text += s.pl + System.Environment.NewLine;
                    textBlock2.Text += s.ang + System.Environment.NewLine;
                    i++;
                }
                i = 0;
            }
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string kategoria = "";

            if(NavigationContext.QueryString.TryGetValue("kategoria", out kategoria))
            {
                dict(kategoria);
            }
        }

        private void listBox1_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            listBox1.SelectedIndex = -1;
        }

    

    }
}