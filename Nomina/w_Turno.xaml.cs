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
    /// Lógica de interacción para w_Turno.xaml
    /// </summary>
    public partial class w_Turno : Window
    {
        NominaEntities datos;

        public w_Turno()
        {
            InitializeComponent();
            datos = new NominaEntities();
        }

        private void dgTurno_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgTurno.SelectedItem != null)
            {
                Turno t = (Turno)dgTurno.SelectedItem;

                txtId.Text = t.Id_Turno.ToString();
                txtHoraLlegada.Text = t.Hora_Entrada;
                txtHoraSalida.Text = t.Hora_Salida;
                txtObservacion.Text = t.Observaciones;
                
            }
        }

        private void dgTurno_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtId.Text = string.Empty;
            txtHoraLlegada.Text = string.Empty;
            txtHoraSalida.Text = string.Empty;
            txtObservacion.Text = string.Empty;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dgTurno.SelectedItem != null)
            {
                Turno t = (Turno)dgTurno.SelectedItem;
                datos.Turno.Remove(t);
                datos.SaveChanges();
                CargarDatosGrilla();
            }
            else
                MessageBox.Show("Debe seleccionar un turno de la grilla para eliminar!");
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (dgTurno.SelectedItem != null)
            {
                Turno t = (Turno)dgTurno.SelectedItem;

                t.Hora_Entrada = txtHoraLlegada.Text;
                t.Hora_Salida = txtHoraSalida.Text;
                t.Observaciones = txtObservacion.Text;
                
            
                datos.Entry(t).State = System.Data.Entity.EntityState.Modified;
                datos.SaveChanges();

                CargarDatosGrilla();
            }
            else
                MessageBox.Show("Debe seleccionar un Turno de la grilla para modificar!");
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Turno t = new Turno();
            t.Hora_Entrada = txtHoraLlegada.Text.ToString();
            t.Hora_Salida = txtHoraSalida.Text.ToString();
            t.Observaciones = txtObservacion.Text;
            
            datos.Turno.Add(t);
            datos.SaveChanges();
            CargarDatosGrilla();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDatosGrilla();
        }

        private void CargarDatosGrilla()
        {
            try
            {
                dgTurno.ItemsSource = datos.Turno.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
