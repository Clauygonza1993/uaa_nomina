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
    /// Lógica de interacción para w_Conceptos.xaml
    /// </summary>
    public partial class w_Conceptos : Window
    {
        NominaEntities datos;

        public w_Conceptos()
        {
            InitializeComponent();
            datos = new NominaEntities();
        }

        private void dgConceptos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgConceptos.SelectedItem != null)
            {
                Concepto c = (Concepto)dgConceptos.SelectedItem;

                txtId.Text = c.Id_Concepto.ToString();
                txtDescripcion.Text = c.Descripcion;


                if (c.Tipo.Equals("F"))
                    rdbFijo.IsChecked = true;
                else
                    rdbOcacional.IsChecked = true;
                
            }
        }

        private void dgConceptos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtId.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dgConceptos.SelectedItem != null)
            {
                Concepto c = (Concepto)dgConceptos.SelectedItem;
                datos.Concepto.Remove(c);
                datos.SaveChanges();
                CargarDatosGrilla();
            }
            else
                MessageBox.Show("Debe seleccionar un Concepto de la grilla para eliminar!");
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (dgConceptos.SelectedItem != null)
            {
                Concepto c= (Concepto)dgConceptos.SelectedItem;

                c.Descripcion = txtDescripcion.Text;

                if (rdbFijo.IsChecked == true)
                {
                    c.Tipo = "F";
                }
                else
                {
                    c.Tipo = "O";
                }
                
                datos.Entry(c).State = System.Data.Entity.EntityState.Modified;
                datos.SaveChanges();
                
                CargarDatosGrilla();
            }
            else
                MessageBox.Show("Debe seleccionar un Concepto de la grilla para modificar!");
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Concepto c = new Concepto();

            c.Descripcion = txtDescripcion.Text;

            if (rdbFijo.IsChecked == true)
            {
                c.Tipo = "F";
            }
            else
            {
                c.Tipo = "O";
            }
            
            datos.Concepto.Add(c);
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
                dgConceptos.ItemsSource = datos.Concepto.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
