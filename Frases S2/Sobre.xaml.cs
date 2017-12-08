using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace Frases_S2
{
    public partial class Sobre : PhoneApplicationPage
    {
        public Sobre()
        {
            InitializeComponent();
        }

        private void Btn_piano_Click(object sender, RoutedEventArgs e)
        {
            Metodos.Sobre.pianotok();
        }

        private void Email_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Metodos.Sobre.FeedBack();
        }

        private void whatsapp_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Metodos.Sobre.Contato();
        }

        private void Twitter_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Metodos.Sobre.twitter();
        }

    }
}