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
    /// Lógica de interacción para w_GenerarLiquidaciones.xaml
    /// </summary>
    public partial class w_GenerarLiquidacionesDetalle : Window
    {
        NominaEntities datos;
        public w_GenerarLiquidacionesDetalle()
        {
            InitializeComponent();
            datos = new NominaEntities();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                cbo_empleados.ItemsSource = (from t in datos.Empleado
                                         select new { t.Id_Empleado, t.Nombres }).ToList();
                cbo_empleados.SelectedValuePath = "Id_Empleado";

                cbo_concepto.ItemsSource = (from c in datos.Concepto
                                 select new { c.Id_Concepto, c.Descripcion }).ToList();
                cbo_concepto.SelectedValuePath = "Id_Concepto";

                cargarGrillar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void cargarGrillar()
        {
            dgDetalles.ItemsSource = (from ld in datos.Liquidacion_Mensual_Detalle
                                      where ld.Liquidacion_Id == Global.LiquidacionID
                                      select new { ld.Id_Detalle, ld.Concepto.Descripcion, ld.Monto, ld.Empleado.Nombres }).ToList();

        }

        private void btn_cargar_Click(object sender, RoutedEventArgs e)
        {
            Liquidacion_Mensual_Detalle ld = new Liquidacion_Mensual_Detalle();
            var operacion = int.Parse(cbo_tipo.SelectedValue.ToString());

            ld.Liquidacion_Id = Global.LiquidacionID;
            ld.Empleado_Id = (int)cbo_empleados.SelectedValue;
            ld.Concepto_Id = (int)cbo_concepto.SelectedValue;
            ld.Monto = int.Parse(txtMonto.Text) * operacion;

            datos.Liquidacion_Mensual_Detalle.Add(ld);
            datos.SaveChanges();

            cargarGrillar();
        }

        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            dynamic dataRowView = (dynamic)((Button)e.Source).DataContext;
            int idDetalle = dataRowView.Id_Detalle;

            var detalle = datos.Liquidacion_Mensual_Detalle.Find(idDetalle);

            datos.Liquidacion_Mensual_Detalle.Remove(detalle);
            datos.SaveChanges();

            cargarGrillar();
        }
    }
}
