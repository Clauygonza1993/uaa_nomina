using Microsoft.Win32;
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
    /// Lógica de interacción para w_Clientes.xaml
    /// </summary>
    /// 
    

    public partial class w_Empleado : Window
    {
        NominaEntities datos;

        public w_Empleado()
        {
            InitializeComponent();
            datos = new NominaEntities();
        }

        private void CargarDatosGrilla()
        {
            try
            {
                cbo_Turno.ItemsSource = (from t in datos.Turno
                                         select new { t.Id_Turno, t.Hora_Entrada, t.Hora_Salida, t.Observaciones }).ToList();
                cbo_Turno.SelectedValuePath = "Id_Turno";
                dgEmpleados.ItemsSource = datos.Empleado.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDatosGrilla();
        }

        private void dgEmpleados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgEmpleados.SelectedItem != null)
            {
                Empleado em = (Empleado)dgEmpleados.SelectedItem;
                txtSalario.IsEnabled = false;
                txtId.Text = em.Id_Empleado.ToString();
                txtNombre.Text = em.Nombres;
                txtApellidos.Text = em.Apellidos;
                txtDocumento.Text = em.Nro_Documento;
                txtDireccion.Text = em.Direccion;
                txtTelefono.Text = em.Nro_Telefono;
                fechaNacimiento.SelectedDate = em.Fecha_Nacimiento;
                fechaIncorporacion.SelectedDate = em.Fecha_Incorporacion;
                txtSalario.Text = em.Salario_Basico.ToString();
                cbo_Turno.SelectedValue = em.Turno_Id;

                String stringPath = em.Imagen_Perfil;
                Uri imageUri = new Uri(stringPath);
                BitmapImage imageBitmap = new BitmapImage(imageUri);
                imgPhoto.Source = imageBitmap;

            }
        }

        private void dgEmpleados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellidos.Text = string.Empty;
            txtDocumento.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            fechaNacimiento.SelectedDate = null;
            fechaIncorporacion.SelectedDate = null;
            txtSalario.Text = string.Empty;
            cbo_Turno.SelectedValue = null;

            imgPhoto.Source = null;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dgEmpleados.SelectedItem != null)
            {
                Empleado em = (Empleado)dgEmpleados.SelectedItem;

                var anticipo = em.Anticipo;
                if (anticipo.Count > 0)
                {
                    datos.Anticipo.RemoveRange(anticipo);
                    datos.SaveChanges();
                }

                var permiso = em.Permisos;
                if (permiso.Count > 0)
                {
                    datos.Permisos.RemoveRange(permiso);
                    datos.SaveChanges();
                }

                var usuario = em.Usuario;
                if (usuario.Count > 0)
                {
                    datos.Usuario.RemoveRange(usuario);
                    datos.SaveChanges();
                }

                var vacaciones = em.Vacaciones;
                if (vacaciones.Count > 0)
                {
                    datos.Vacaciones.RemoveRange(vacaciones);
                    datos.SaveChanges();
                }

                datos.Empleado.Remove(em);
                datos.SaveChanges();
                CargarDatosGrilla();
            }
            else
                MessageBox.Show("Debe seleccionar un Empleado de la grilla para eliminar!");
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (dgEmpleados.SelectedItem != null)
            {
                Empleado em = (Empleado)dgEmpleados.SelectedItem;

                em.Turno_Id = (int)cbo_Turno.SelectedValue;
                em.Nombres = txtNombre.Text;
                em.Apellidos = txtApellidos.Text;
                em.Nro_Documento = txtDocumento.Text;
                em.Direccion = txtDireccion.Text;
                em.Nro_Telefono = txtTelefono.Text;
                em.Fecha_Nacimiento = fechaNacimiento.SelectedDate.Value;
                em.Fecha_Incorporacion = fechaIncorporacion.SelectedDate.Value;
                //em.Salario_Basico = int.Parse(txtSalario.Text);
                em.Imagen_Perfil = imgPhoto.Source.ToString();

                datos.Entry(em).State = System.Data.Entity.EntityState.Modified;
                datos.SaveChanges();


                CargarDatosGrilla();
            }
            else
                MessageBox.Show("Debe seleccionar un Empleado de la grilla para modificar!");
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Empleado em = new Empleado();

            em.Turno_Id = (int)cbo_Turno.SelectedValue;
            em.Nombres = txtNombre.Text;
            em.Apellidos = txtApellidos.Text;
            em.Nro_Documento = txtDocumento.Text;
            em.Direccion = txtDireccion.Text;
            em.Nro_Telefono = txtTelefono.Text;
            em.Fecha_Nacimiento = fechaNacimiento.SelectedDate.Value;
            em.Fecha_Incorporacion = fechaIncorporacion.SelectedDate.Value;
            em.Salario_Basico = int.Parse(txtSalario.Text);
            em.Imagen_Perfil = imgPhoto.Source.ToString();

            


            var d = datos.Empleado.Add(em);
            Empleado_Salario_Historico eh = new Empleado_Salario_Historico();
            eh.Empleado_Id = d.Id_Empleado;
            eh.Fecha_Hora = DateTime.Now;
            eh.Salario_Basico_Nuevo = int.Parse(txtSalario.Text);
            eh.Usuario_Id = Global.UserID;
            datos.Empleado_Salario_Historico.Add(eh);

            datos.SaveChanges();
            CargarDatosGrilla();
        }

        private void btnImagen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Elegir una imagen";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imgPhoto.Source = new BitmapImage(new Uri(op.FileName));
            }
        }

        private void btn_modificar_salario_Click(object sender, RoutedEventArgs e)
        {
            if (dgEmpleados.SelectedItem != null)
            {
                Empleado em = (Empleado)dgEmpleados.SelectedItem;
                Global.EmpleadoID = int.Parse(em.Id_Empleado.ToString());
                w_actualizarSalario salario = new w_actualizarSalario();
                salario.Show();
        
            }
            else
                MessageBox.Show("Debe seleccionar un Empleado de la grilla para modificar!");
        }
    }
}



           