using System;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Scheduler;
using Microsoft.Phone;
using System.IO.IsolatedStorage;

namespace Frases_S2
{
    public partial class MainPage : PhoneApplicationPage
    {
        public static int LembretePrimario;
        public static int boas_vindas;

        public MainPage()
        {
            InitializeComponent();
            Inicio_animacao.Begin();
            this.Loaded += MainPage_Loaded;
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            IsolatedStorageSettings iso = IsolatedStorageSettings.ApplicationSettings;
            string retornaBoasVindas;
            if (iso.TryGetValue<string>("SalvarLembrete", out retornaBoasVindas))
            {
                LembretePrimario = Convert.ToInt16(retornaBoasVindas);
            }
            else
            {
                LembretePrimario = 0;

            }
            if (LembretePrimario == 0)
            {

                String name = System.Guid.NewGuid().ToString();

                DateTime date = DateTime.Now;
                DateTime time = DateTime.Now;

                DateTime beginTime = time.AddSeconds(30);

                RecurrenceInterval recurrence = RecurrenceInterval.None;
                recurrence = RecurrenceInterval.Daily;

                var schedule = ScheduledActionService.Find(name);
                if (schedule == null)
                {
                    Microsoft.Phone.Scheduler.Reminder reminder = new Microsoft.Phone.Scheduler.Reminder(name);
                    {
                        reminder.Title = "Olá 🙋";
                        reminder.Content = "Compartilhe agora mesmo diversas frases com seus amigos.";
                        reminder.BeginTime = beginTime;
                        reminder.RecurrenceType = recurrence;
                    };
                    ScheduledActionService.Add(reminder);


                    LembretePrimario = 1;

                    if (iso.Contains("SalvarLembrete"))
                    {
                        iso["SalvarLembrete"] = "1";
                    }
                    else
                    {
                        iso.Add("SalvarLembrete", "1");
                    }
                    iso.Save();
                }



            }
        }

        private void configuracao_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

            NavigationService.Navigate(new Uri("/Sobre.xaml", UriKind.Relative));
        }

        //Navegação das Categorias;
        #region

        /// <summary>
        /// CATEGORIAS DAS FRASES
        /// </summary>

        private void amizade_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var queryData = string.Format("?Categoria={0}&Itens={1}&Item={2}&Pasta={3}", "🙋 AMIZADE", 100, 1, "amizade");//todos os parametros que vamos passar para a proxima pagina
            NavigationService.Navigate(new Uri("/Visualizar.xaml" + queryData, UriKind.Relative));
        }

        private void amor_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var queryData = string.Format("?Categoria={0}&Itens={1}&Item={2}&Pasta={3}", "💝 AMOR", 104, 1, "amor");//todos os parametros que vamos passar para a proxima pagina
            NavigationService.Navigate(new Uri("/Visualizar.xaml" + queryData, UriKind.Relative));
        }

        private void aniversario_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var queryData = string.Format("?Categoria={0}&Itens={1}&Item={2}&Pasta={3}", "🎂 ANIVERSÁRIO", 42, 1, "aniversario");//todos os parametros que vamos passar para a proxima pagina
            NavigationService.Navigate(new Uri("/Visualizar.xaml" + queryData, UriKind.Relative));
        }
        private void Boa_noite_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var queryData = string.Format("?Categoria={0}&Itens={1}&Item={2}&Pasta={3}", "🌙 BOA NOITE", 21, 1, "boa_noite");//todos os parametros que vamos passar para a proxima pagina
            NavigationService.Navigate(new Uri("/Visualizar.xaml" + queryData, UriKind.Relative));
        }
        private void Boa_Tarde_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var queryData = string.Format("?Categoria={0}&Itens={1}&Item={2}&Pasta={3}", "🌇 BOA TARDE", 30, 1, "boa_tarde");//todos os parametros que vamos passar para a proxima pagina
            NavigationService.Navigate(new Uri("/Visualizar.xaml" + queryData, UriKind.Relative));
        }

        private void Bom_Dia_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var queryData = string.Format("?Categoria={0}&Itens={1}&Item={2}&Pasta={3}", "🌄 BOM DIA", 10, 1, "bom_dia");//todos os parametros que vamos passar para a proxima pagina
            NavigationService.Navigate(new Uri("/Visualizar.xaml" + queryData, UriKind.Relative));
        }

        private void CIUME_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var queryData = string.Format("?Categoria={0}&Itens={1}&Item={2}&Pasta={3}", "😒 CIÚMES", 15, 1, "Ciumes");//todos os parametros que vamos passar para a proxima pagina
            NavigationService.Navigate(new Uri("/Visualizar.xaml" + queryData, UriKind.Relative));
        }

        private void desculpas_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var queryData = string.Format("?Categoria={0}&Itens={1}&Item={2}&Pasta={3}", "😇 DESCULPAS", 15, 1, "desculpas");//todos os parametros que vamos passar para a proxima pagina
            NavigationService.Navigate(new Uri("/Visualizar.xaml" + queryData, UriKind.Relative));
        }

        private void DEUS_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var queryData = string.Format("?Categoria={0}&Itens={1}&Item={2}&Pasta={3}", "🙏 DEUS", 51, 1, "Deus");//todos os parametros que vamos passar para a proxima pagina
            NavigationService.Navigate(new Uri("/Visualizar.xaml" + queryData, UriKind.Relative));
        }

        private void DMAES_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var queryData = string.Format("?Categoria={0}&Itens={1}&Item={2}&Pasta={3}", "👩 DIAS DAS MÃES", 12, 1, "dias_maes");//todos os parametros que vamos passar para a proxima pagina
            NavigationService.Navigate(new Uri("/Visualizar.xaml" + queryData, UriKind.Relative));
        }

        private void DPAIS_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var queryData = string.Format("?Categoria={0}&Itens={1}&Item={2}&Pasta={3}", "👨 DIAS DOS PAIS", 12, 1, "dias_pais");//todos os parametros que vamos passar para a proxima pagina
            NavigationService.Navigate(new Uri("/Visualizar.xaml" + queryData, UriKind.Relative));
        }

        private void engracados_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var queryData = string.Format("?Categoria={0}&Itens={1}&Item={2}&Pasta={3}", "😂 ENGRAÇADAS", 10, 1, "Engracadas");//todos os parametros que vamos passar para a proxima pagina
            NavigationService.Navigate(new Uri("/Visualizar.xaml" + queryData, UriKind.Relative));
        }

        private void Feliz_Natal_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var queryData = string.Format("?Categoria={0}&Itens={1}&Item={2}&Pasta={3}", "🎅 FELIZ NATAL", 10, 1, "Natal");//todos os parametros que vamos passar para a proxima pagina
            NavigationService.Navigate(new Uri("/Visualizar.xaml" + queryData, UriKind.Relative));
        }

        private void Indiretas_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var queryData = string.Format("?Categoria={0}&Itens={1}&Item={2}&Pasta={3}", "😏 INDIRETAS", 25, 1, "indiretas");//todos os parametros que vamos passar para a proxima pagina
            NavigationService.Navigate(new Uri("/Visualizar.xaml" + queryData, UriKind.Relative));
        }

        private void Motivacao_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var queryData = string.Format("?Categoria={0}&Itens={1}&Item={2}&Pasta={3}", "🙌 MOTIVAÇÃO", 26, 1, "motivacao");//todos os parametros que vamos passar para a proxima pagina
            NavigationService.Navigate(new Uri("/Visualizar.xaml" + queryData, UriKind.Relative));
        }

        private void Musicas_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var queryData = string.Format("?Categoria={0}&Itens={1}&Item={2}&Pasta={3}", "🎶 MÚSICAS", 20, 1, "Musicas");//todos os parametros que vamos passar para a proxima pagina
            NavigationService.Navigate(new Uri("/Visualizar.xaml" + queryData, UriKind.Relative));
        }

        private void Saudades_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var queryData = string.Format("?Categoria={0}&Itens={1}&Item={2}&Pasta={3}", "😥 SAUDADES", 50, 1, "Saudades");//todos os parametros que vamos passar para a proxima pagina
            NavigationService.Navigate(new Uri("/Visualizar.xaml" + queryData, UriKind.Relative));
        }

        private void Tristeza_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var queryData = string.Format("?Categoria={0}&Itens={1}&Item={2}&Pasta={3}", "😢 TRISTEZA", 51, 1, "Tristeza");//todos os parametros que vamos passar para a proxima pagina
            NavigationService.Navigate(new Uri("/Visualizar.xaml" + queryData, UriKind.Relative));
        }
        #endregion   //Navegação das Categorias  
    }
}