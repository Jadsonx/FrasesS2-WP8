using Microsoft.Phone.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frases_S2.Metodos
{
    class Sobre
    {
        public static void FeedBack()
        {
            EmailComposeTask email = new EmailComposeTask();
            email.To = "Jadson0102@live.com";
            email.Subject = "Frases S2 - SOBRE";
            email.Body = " \n" +
                         " \n" +
                DateTime.Now.ToString();
            email.Show();
        }

        public static void Contato()
        {
            SaveContactTask devcontato = new SaveContactTask();
            devcontato.FirstName = "Jadson";
            devcontato.LastName = "(FRASES S2)";
            devcontato.MobilePhone = "+557998682289";

            devcontato.Show();
        }

        public static void twitter()
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri("https://twitter.com/jadsonx");
            webBrowserTask.Show();
        }
        public async static void pianotok()
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("https://www.microsoft.com/pt-br/store/games/piano-tok/9nblggh6c8qh"));
        }
    }
}
