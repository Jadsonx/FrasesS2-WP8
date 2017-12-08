using System;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using System.ComponentModel;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Microsoft.Phone.Tasks;
using Windows.Phone.Speech.Synthesis;
using Microsoft.Phone.Scheduler;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using Microsoft.Xna.Framework.Media;
using System.IO.IsolatedStorage;

namespace Frases_S2
{
    public partial class Visualizar : PhoneApplicationPage, INotifyPropertyChanged
    {
        WriteableBitmap wb;
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #region Propriedades
        public string Categoria { get; set; }
        private string _frase;
        public string Frase
        {
            get { return _frase; }
            set { _frase = value; NotifyPropertyChanged("Frase"); }
        }
        private string _autor;
        public string Autor
        {
            get { return _autor; }
            set { _autor = value; NotifyPropertyChanged("Autor"); }
        }
        private string Pasta;
        public int Itens { get; set; }
        int _item;
        public int Item
        {
            get
            {
                return _item;
            }
            set
            {
                _item = value;
                NotifyPropertyChanged("Item");
            }
        }
        #endregion


        public Visualizar()
        {
            InitializeComponent();
            Animacao_Frases.Begin();
        }

        //Metodos para a Navegação e leitura das frases e categorias

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (NavigationContext.QueryString.ContainsKey("Categoria"))
                Categoria = NavigationContext.QueryString["Categoria"];
            if (NavigationContext.QueryString.ContainsKey("Itens"))
                Itens = Convert.ToInt32(NavigationContext.QueryString["Itens"]);
            if (NavigationContext.QueryString.ContainsKey("Item"))
                Item = Convert.ToInt32(NavigationContext.QueryString["Item"]);
            if (NavigationContext.QueryString.ContainsKey("Pasta"))
                Pasta = NavigationContext.QueryString["Pasta"];
            Atualizar();
        }
        public void Atualizar()
        {
            Frase = LerFrase(Pasta, Item);
            Autor = LerAutor(Pasta, Item);
        }

        public string LerFrase(string categoria, int item)
        {
            string caminho = "Conteudo/" + categoria + "/frase/" + item.ToString() + ".txt";
            string texto = "";
            try
            {
                Stream txtStream = Application.GetResourceStream(new Uri(caminho, UriKind.Relative)).Stream;
                StreamReader sr = new StreamReader(txtStream);
                texto = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception)
            {
                texto = "";
            }
            return texto;
        }

        public string LerAutor(string categoria, int item)
        {
            string caminho = "Conteudo/" + categoria + "/autor/" + item.ToString() + ".txt";
            string texto = "";
            try
            {
                Stream txtStream = Application.GetResourceStream(new Uri(caminho, UriKind.Relative)).Stream;
                StreamReader sr = new StreamReader(txtStream);
                texto = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception)
            {
                texto = "";
            }
            return texto;
        }

        #region Movimentar textblock usando o gesto
        private double posicaoInicial;//representa a posição X do textblock quando a manipulação por gesto começou
        private double posicaoAtual = 0;//representa a posição X do textblock quando a manipulação por gesto terminar. Deixo em 0 para representar a posição atual
        private void ScrollViewer_ManipulationCompleted(object sender, System.Windows.Input.ManipulationCompletedEventArgs e)
        {
            if (e.ManipulationOrigin.X < posicaoInicial)
            {
                double pD = posicaoInicial - e.ManipulationOrigin.X;
                if (pD > 30)
                {
                    Avancar_Click(null, null);
                    Animacao_Frases.Begin();
                }
                 else
                {
                  
                }
            }
            else if (e.ManipulationOrigin.X > posicaoInicial)
            {
                double pD = e.ManipulationOrigin.X - posicaoInicial;
                if (pD > 30)
                {
                    Voltar_Click(null, null);
                    Animacao_Frases.Begin();
                }
                else
                {
                   
                    pD.ToString();
                }
            }
        }

        private void ScrollViewer_ManipulationDelta(object sender, System.Windows.Input.ManipulationDeltaEventArgs e)
        {
            PlaneProjection _Projection = new PlaneProjection() { LocalOffsetX = (e.ManipulationOrigin.X - posicaoInicial) };
            posicaoAtual = e.ManipulationOrigin.X;
            textBlockFrase.Projection = _Projection;
        }

        private void ScrollViewer_ManipulationStarted(object sender, System.Windows.Input.ManipulationStartedEventArgs e)
        {
            posicaoInicial = e.ManipulationOrigin.X;
        }
        #endregion

        private enum Direcao
        {
            esquerda,
            direita,
            voltar
        };

     // Comandos e funções da Visualização
        private void Voltar_Click(object sender, EventArgs e)
        {
            try
            {

                if (Item != 1)
                {
                    Item -= 1;
                }
                else
                {
                    Item = Itens;
                }
                NavigationContext.QueryString["Item"] = Item.ToString();//temos que salvar o indice atual, pois se o aplicativo for minimizado ele voltará para 1
                Atualizar();
                Animacao_Frases.Begin();
            }
            catch (Exception erro)
            {
                Metodos.erro.Bug(CategoriaView.Text, Item, erro.ToString());
            }
        }

        private void Social_Click(object sender, EventArgs e)
        {
            Metodos.Compartilhar.Social(textBlockFrase.Text);
        }

        private void foto_Click(object sender, EventArgs e)
        {
            //Create a WriteableBitmap with height and width same as that of Layoutroot
            WriteableBitmap bmp = new WriteableBitmap(480, 400);

            //Render the layoutroot element on it
            bmp.Render(LayoutRoot, null);
            bmp.Invalidate();


            //Save the image to Medialibrary

            //create a stream of image
            var ms = new MemoryStream();
            bmp.SaveJpeg(ms, 480, 400, 0, 0);
            ms.Seek(0, SeekOrigin.Begin);


            //every path must be unique
            var filePath = "FrasesS2" + DateTime.Now.ToString();

            //Remember to include Medialib capabilty from WMAppManifest.xml for acessing the Medialibrary
            var lib = new MediaLibrary();
            lib.SavePicture(filePath, ms);

            MessageBox.Show("Foto salva com sucesso!", "Pronto", MessageBoxButton.OK);
        }

        private void Avancar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Item != Itens)
                {
                    Item += 1;
                }
                else
                {
                    Item = 1;
                }
                NavigationContext.QueryString["Item"] = Item.ToString();//temos que salvar o indice atual, pois se o aplicativo for minimizado ele voltará para 1
                Atualizar();
                Animacao_Frases.Begin();
            }
            catch (Exception errov)
            {
                Metodos.erro.Bug(CategoriaView.Text, Item, errov.ToString());
            }
        }

        private async void ouvir_frase_Click(object sender, EventArgs e)
        {
            try
            {
                SpeechSynthesizer falarfrase = new SpeechSynthesizer();
                await falarfrase.SpeakTextAsync(textBlockFrase.Text);

            }
            catch (Exception errospeak)
            {
                MessageBox.Show("Avise ao desenvolvedor o que você tentou fazer e não deu certo.", "Algo deu errado :(", MessageBoxButton.OK);

                Metodos.erro.Bug(CategoriaView.Text, Item, errospeak.ToString());
            }
        }


        private void copiar_Click_1(object sender, EventArgs e)
        {
            Clipboard.SetText(textBlockFrase.Text + " #FrasesS2WP");

            if (MessageBox.Show("Frase copiada :)", "COPIAR", MessageBoxButton.OK) == MessageBoxResult.OK)
            {
                Clipboard.SetText(textBlockFrase.Text + " #FrasesS2WP");
            }
        }

        private void relatar_erro_Click(object sender, EventArgs e)
        {
            Popup_Correcao_erro.Visibility = Visibility.Visible;

            erro_ortografico.IsChecked = false;
            repeticao.IsChecked = false;
        }

        private void erro_ortografico_Checked(object sender, RoutedEventArgs e)
        {
            Metodos.erro.erro_ortografico(CategoriaView.Text, Item);

            Popup_Correcao_erro.Visibility = Visibility.Collapsed;
        }

        private void repeticao_Checked(object sender, RoutedEventArgs e)
        {
            Metodos.erro.erro_repeticao(CategoriaView.Text, Item);

            Popup_Correcao_erro.Visibility = Visibility.Collapsed;
        }
      
    }
}