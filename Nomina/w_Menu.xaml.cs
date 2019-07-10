using MaterialDesignThemes.Wpf;
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

namespace Nomina
{
    /// <summary>
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void MenuClientes_Click(object sender, RoutedEventArgs e)
        {
             w_Empleado ventanaClientes = new w_Empleado();
             ventanaClientes.ShowDialog();
        }

        private void MenuConceptos_Click(object sender, RoutedEventArgs e)
        {
            w_Conceptos ventanaConceptos = new w_Conceptos();
            ventanaConceptos.ShowDialog();
        }

        private void MenuTurno_Click(object sender, RoutedEventArgs e)
        {
            w_Turno ventanaTurno = new w_Turno();
            ventanaTurno.ShowDialog();
        }

        private void MenuReport_Click(object sender, RoutedEventArgs e)
        {
            w_Visor ventanaVisor = new w_Visor();
            ventanaVisor.ShowDialog();
        }

        private void MenuSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuLiquidaciones_Click(object sender, RoutedEventArgs e)
        {
            w_GenerarLiquidaciones ventanaLiquidacion = new w_GenerarLiquidaciones();
            ventanaLiquidacion.ShowDialog();
        }

        private void MenuLiquidacionesGeneradas_Click(object sender, RoutedEventArgs e)
        {
            w_Generados ventanaGenerados = new w_Generados();
            ventanaGenerados.ShowDialog();
        }
    }
}
