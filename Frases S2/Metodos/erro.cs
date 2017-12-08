using Microsoft.Phone.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Frases_S2.Metodos
{
    class erro
    {
        //Metodos dentro da Class para as funções correspondentes;
        public static void Bug(string CategoriaView, int Item, string errov) 
        {
            MessageBox.Show("Algo deu errado, por favor avise o desenvolvedor sobre o erro.");

            EmailComposeTask email = new EmailComposeTask();
            email.To = "Jadson0102@live.com";
            email.Subject = "Frases S2 - ERRO";
            email.Body = "  " + CategoriaView.ToString() + " - " + Item.ToString() + "  ---  " + errov.ToString();
            email.Show();
        }

        public static void erro_ortografico(string CategoriaView, int Item)
        {
            EmailComposeTask email = new EmailComposeTask();
            email.To = "Jadson0102@live.com";
            email.Subject = "Frases S2 - CORRIGIR ORTOGRÁFIA";
            email.Body = "  " + CategoriaView.ToString() + " - " + Item.ToString();
            email.Show();
        }

        public static void erro_repeticao(string CategoriaView, int Item)
        {
            EmailComposeTask email = new EmailComposeTask();
            email.To = "Jadson0102@live.com";
            email.Subject = "Frases S2 - CORRIGIR REPETIÇÃO";
            email.Body = "  " + CategoriaView.ToString() + " - " + Item.ToString();
            email.Show();
        }

    }
}
