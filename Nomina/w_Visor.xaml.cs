using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
    /// Lógica de interacción para w_Visor.xaml
    /// </summary>
    public partial class w_Visor : Window
    {
        NominaEntities datos;

        public w_Visor()
        {
            InitializeComponent();
            datos = new NominaEntities();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDatosGrilla();
        }

        private void CargarDatosGrilla()
        {
            try
            {
                dgAnticipo.ItemsSource = (from v in datos.Anticipo
                                          join e in datos.Empleado on v.Empleado_Id equals e.Id_Empleado
                                          where v.Estado == "Pendiente"
                                          select new { v.Id_Anticipo, v.Empleado_Id, e.Nombres, v.Fecha_Solicitud, v.Fecha_Definicion, v.Observaciones, v.Estado }).ToList();
                dgVacacion.ItemsSource = (from v in datos.Vacaciones
                                          join e in datos.Empleado on v.Empleado_Id equals e.Id_Empleado
                                          where v.Estado == "Pendiente"
                                          select new { v.Id_Vacaciones, v.Empleado_Id, e.Nombres, v.Fecha_Desde, v.Fecha_Hasta, v.Estado, v.Fecha_Solicitud, v.Fecha_Definicion, v.Observaciones }).ToList();
                dgPermiso.ItemsSource = (from p in datos.Permisos
                                         join e in datos.Empleado on p.Empleado_Id equals e.Id_Empleado
                                         where p.Estado == "Pendiente"
                                            select new { p.Id_Permiso, p.Empleado_Id, e.Nombres, p.Cantidad_Horas, p.Estado, p.Fecha_Desde, p.Fecha_Hasta, p.Fecha_Solicitud, p.Motivo, p.Observaciones }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

      

        private void btn_rechazar_permiso_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dynamic dataRowView = (dynamic)((Button)e.Source).DataContext;
                int idPermiso = dataRowView.Id_Permiso;
                var permiso = datos.Permisos.Find(idPermiso);
                if (permiso != null)
                {
                    permiso.Estado = "Rechazado";
                    datos.Permisos.Attach(permiso);
                    datos.Entry(permiso).State = EntityState.Modified;
                    datos.SaveChanges();
                    
                }
                CargarDatosGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btn_aprobar_permiso_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dynamic dataRowView = (dynamic)((Button)e.Source).DataContext;
                int idPermiso = dataRowView.Id_Permiso;
                var permiso = datos.Permisos.Find(idPermiso);
                if (permiso != null)
                {
                    permiso.Estado = "Aprobado";
                    datos.Permisos.Attach(permiso);
                    datos.Entry(permiso).State = EntityState.Modified;
                    datos.SaveChanges();

                }
                CargarDatosGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        

     

        private void btn_aprobar_vacaciones_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                dynamic dataRowView = (dynamic)((Button)e.Source).DataContext;
                int idVacacion = dataRowView.Id_Vacaciones;
                var vacacion = datos.Vacaciones.Find(idVacacion);
                if (vacacion != null)
                {
                    vacacion.Estado = "Aprobado";
                    datos.Vacaciones.Attach(vacacion);
                    datos.Entry(vacacion).State = EntityState.Modified;
                    datos.SaveChanges();

                }
                CargarDatosGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void btn_rechazar_vacaciones_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dynamic dataRowView = (dynamic)((Button)e.Source).DataContext;
                int idVacacion = dataRowView.Id_Vacaciones;
                var vacacion = datos.Vacaciones.Find(idVacacion);
                if (vacacion != null)
                {
                    vacacion.Estado = "Rechazado";
                    datos.Vacaciones.Attach(vacacion);
                    datos.Entry(vacacion).State = EntityState.Modified;
                    datos.SaveChanges();

                }
                CargarDatosGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btn_aprobar_anticipo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dynamic dataRowView = (dynamic)((Button)e.Source).DataContext;
                int idAnticipo = dataRowView.Id_Anticipo;
                var anticipo = datos.Anticipo.Find(idAnticipo);
                if (anticipo != null)
                {
                    anticipo.Estado = "Aprobado";
                    datos.Anticipo.Attach(anticipo);
                    datos.Entry(anticipo).State = EntityState.Modified;
                    datos.SaveChanges();

                }
                CargarDatosGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btn_rechazar_anticipo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dynamic dataRowView = (dynamic)((Button)e.Source).DataContext;
                int idAnticipo = dataRowView.Id_Anticipo;
                var anticipo = datos.Anticipo.Find(idAnticipo);
                if (anticipo != null)
                {
                    anticipo.Estado = "Rechazado";
                    datos.Anticipo.Attach(anticipo);
                    datos.Entry(anticipo).State = EntityState.Modified;
                    datos.SaveChanges();

                }
                CargarDatosGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
