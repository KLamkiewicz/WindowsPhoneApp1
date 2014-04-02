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
    public partial class MainPage : PhoneApplicationPage
    {
        public static SlowkaClass s;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            s = new SlowkaClass();
        }

        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }

        private void slowka_Click(object sender, RoutedEventArgs e)
        {
            
            NavigationService.Navigate(new Uri("/Lista.xaml", UriKind.Relative));
        }


        private void nauka_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ListaNauka.xaml", UriKind.Relative));
        }


    }
}