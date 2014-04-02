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
using System.Windows.Controls.Primitives;
using System.Windows.Media.Imaging;
using System.Diagnostics;

namespace AngielskiNauka
{
    public partial class SlowkaNauka : PhoneApplicationPage
    {
        List<Slowko> slowka = new List<Slowko>();
        static Random r = new Random();
        int rand;

        public SlowkaNauka()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string kategoria = "";

            if (NavigationContext.QueryString.TryGetValue("kategoria", out kategoria))
            {
                textBlock3.Text = kategoria;
                getKategoriaSlowka(kategoria);
                RandomizeWord();
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Uri uriOk = new Uri("Images/okEx.png", UriKind.Relative);
            BitmapImage bitOk = new BitmapImage(uriOk);
            Image imgOk = new Image();
            imgOk.Source = bitOk;
            imgOk.Height = 64;
            imgOk.Width = 64;

            Uri uriBad = new Uri("Images/noEx.png", UriKind.Relative);
            BitmapImage bitNo = new BitmapImage(uriBad);
            Image imgBad = new Image();
            imgBad.Source = bitNo;
            imgBad.Height = 64;
            imgBad.Width = 64;






            if (!textBox1.Text.Equals(slowka[rand].ang, StringComparison.InvariantCultureIgnoreCase))
            {
                //PopUpText.TextAlignment = TextAlignment.Left;
                //PopUpText.Text = "Błąd!" + System.Environment.NewLine + System.Environment.NewLine + "Poprawna pisownia to: " + System.Environment.NewLine + System.Environment.NewLine + slowka[rand].ang;
                PopButtonOk.Content = imgBad;
                Info.Text = "Źle!" + System.Environment.NewLine;
                PopUpText.Text = "Poprawna pisownia to: ";
                Pisownia.Text = slowka[rand].ang;
                Pisownia.FontSize = 40;
                SolidColorBrush sb = (SolidColorBrush)panel.Background;
                sb.Color = Color.FromArgb(255, 224, 43, 43);
                panel.Background = sb;
            }
            else
            {
                //PopUpText.TextAlignment = TextAlignment.Center;
                //PopUpText.Text = "Dobrze!";
                PopButtonOk.Content = imgOk;
                Info.Text = "Dobrze" + System.Environment.NewLine;
                PopUpText.Text = " ";
                Pisownia.Text = " ";
                SolidColorBrush sb = (SolidColorBrush)panel.Background;
                sb.Color = Color.FromArgb(255, 88, 196, 73);
                panel.Background = sb;
            }
            if (!NaukaPopUp.IsOpen)
            {
                NaukaPopUp.IsOpen = true;
            }
            else
            {
                NaukaPopUp.IsOpen = false;
            }

            if (!NaukaPopUp.IsOpen)
            {
                RandomizeWord();
                textBox1.Text = "";
            }
            
        }

        private void PopClick(object sender, RoutedEventArgs e)
        {
            NaukaPopUp.IsOpen = false;
            RandomizeWord();
            textBox1.Text = "";
        }


        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            base.OnBackKeyPress(e);
            NaukaPopUp.IsOpen = false;
        }

        private void getKategoriaSlowka(string kategoria)
        {
            foreach (Slowko s in MainPage.s.slowka)
            {
                if (s.kategoria.Equals(kategoria))
                {
                    slowka.Add(s);
                }
            }
            textBlock2.Text = slowka.Count().ToString();
        }

        private Boolean check(String pol, String ang)
        {
            return true;
        }

        private void RandomizeWord()
        {
            rand = r.Next(slowka.Count());
            textBlock2.Text = (slowka[rand]).pl;
        }

        private void NaukaPopUp_Opened(object sender, EventArgs e)
        {
            panel.Height = this.ActualHeight/2;
            panel.Width = this.ActualWidth;
            NaukaPopUp.VerticalOffset = this.ActualHeight / 5;
            PopButtonOk.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
        }

        private void PhoneApplicationPage_Loaded(object sender, EventArgs e)
        {
        }

        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        private void textBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Debug.WriteLine("TEST");
                button1_Click(sender, null);
            }

        }

    }
}