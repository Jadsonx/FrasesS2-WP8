using Microsoft.Phone.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frases_S2.Metodos
{
    class Compartilhar
    {

        public static void Social(string textBlockFrase) //isso aqui é o método
        {
            ShareStatusTask Compartilhar = new ShareStatusTask();
            Compartilhar.Status = textBlockFrase.ToString() + " #FrasesS2WP";
            Compartilhar.Show();
        }
    }
}
