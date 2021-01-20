using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ChatBot
{
    /// <summary>
    /// Lógica de interacción para Configuracion.xaml
    /// </summary>
    public partial class Configuracion : Window
    {
        public String ColorFondo { get; set; }
        public String ColorUsuario { get; set; }
        public String ColorBot { get; set; }
        public String Usuario { get; set; }
        string[] generos = new string[] { "Hombre", "Mujer" };


        public Configuracion()
        {
            InitializeComponent();
            
            fondoComboBox.ItemsSource = typeof(Colors).GetProperties();
            usuarioComboBox.ItemsSource = typeof(Colors).GetProperties();
            botComboBox.ItemsSource = typeof(Colors).GetProperties();
            generoComboBox.ItemsSource = generos;
            DataContext = this;

            
        }

        private void aceptarButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
