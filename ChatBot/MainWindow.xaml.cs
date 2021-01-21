using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChatBot
{
  
    public partial class MainWindow : Window
    {


        ObservableCollection<Mensaje> mensajes = new ObservableCollection<Mensaje>();
        public MainWindow()
        {
            InitializeComponent();
            chatItemsControl.DataContext = mensajes;

        }

        

        private void CommandBinding_SaveCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (chatItemsControl != null) e.CanExecute = true;
            else
            {
                e.CanExecute = false;
            }
        }
        private void CommandBinding_ExitCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void CommandBinding_ConfigCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void CommandBinding_ConexionCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void CommandBinding_SendCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (mensajeTextBox != null && mensajeTextBox.Text != "")
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
            
        }



        private void CommandBinding_NewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            mensajes.Clear();
        }
        private void CommandBinding_SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            string conversacion = "";
            for(int i = 0; i < mensajes.Count; i++)
            {
                conversacion += mensajes[i].ToString();
            }
            SaveFileDialog sfd = new SaveFileDialog
            {
                 
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "Text (*.txt)|*.txt"
            };
            if (sfd.ShowDialog() == true)
            {

                File.WriteAllText(sfd.FileName, conversacion);
            }
        }
        private void CommandBinding_ExitExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
        private void CommandBinding_ConexionExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Conexión correcta con el servidor del Bot", "Comprobar conexión", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void CommandBinding_ConfigExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Configuracion config = new Configuracion();

            config.ColorFondo = Properties.Settings.Default.ColorFondo;
            config.ColorBot = Properties.Settings.Default.ColorBot;
            config.ColorUsuario = Properties.Settings.Default.ColorUsuario;
            config.Usuario = Properties.Settings.Default.Genero;

            config.Owner = this;
            config.ShowInTaskbar = false;
            if(config.ShowDialog() == true)
            {
                Properties.Settings.Default.ColorFondo = config.ColorFondo;
                Properties.Settings.Default.ColorBot = config.ColorBot;
                Properties.Settings.Default.ColorUsuario = config.ColorUsuario;
                Properties.Settings.Default.Genero = config.Usuario;
                Properties.Settings.Default.Save();

            }
        }

        private void CommandBinding_SendExecuted(object sender, RoutedEventArgs e)
        {
            Mensaje.TipoEmisor emisor;
            if(Properties.Settings.Default.Genero == Mensaje.TipoEmisor.Hombre.ToString())
            {
                emisor = Mensaje.TipoEmisor.Hombre;
            }
            else
            {
                emisor = Mensaje.TipoEmisor.Mujer;
            }

            Mensaje m = new Mensaje(mensajeTextBox.Text, emisor);
            mensajes.Add(m);
            mensajes.Add(new Mensaje("Lo siento, estoy un poco cansado para hablar", Mensaje.TipoEmisor.Bot));
            mensajeTextBox.Clear();
            scrollViewer.ScrollToEnd();
        }
    }
}
