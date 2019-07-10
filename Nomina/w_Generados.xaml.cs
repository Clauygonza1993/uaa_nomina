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
    public partial class w_Generados : Window
    {
        NominaEntities datos;

        public w_Generados()
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
                dgLiquidaciones.ItemsSource = (from l in datos.Liquidacion_Mensual
                                         
                                          where l.Estado == "A"
                                          select new {l.Id_Liquidacion, l.Mes, l.Anho, l.Fecha_Generacion, l.Usuario.Usuario1 }).ToList();
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    
       
        private void btn_detalles_Click(object sender, RoutedEventArgs e)
        {
            dynamic dataRowView = (dynamic)((Button)e.Source).DataContext;
            Global.LiquidacionID = dataRowView.Id_Liquidacion;
            w_GenerarLiquidacionesDetalle ventanaDetalles = new w_GenerarLiquidacionesDetalle();
            ventanaDetalles.ShowDialog();
        }

        private void btn_generar_Click(object sender, RoutedEventArgs e)
        {
            dynamic dataRowView = (dynamic)((Button)e.Source).DataContext;
            Global.LiquidacionID = dataRowView.Id_Liquidacion;
            var empleados = datos.Empleado.ToList();

            var liquidacion = datos.Liquidacion_Mensual.Find(Global.LiquidacionID);

            foreach (var emp in empleados)
            {
               
                Liquidacion_Mensual_Detalle liquidDetalle = new Liquidacion_Mensual_Detalle();
                liquidDetalle.Empleado_Id = emp.Id_Empleado;
                liquidDetalle.Liquidacion_Id = Global.LiquidacionID;

                var otrosIngresos = 0;
                var otrosIngresosCount = (from o in datos.Liquidacion_Mensual_Detalle
                                     where o.Liquidacion_Id == Global.LiquidacionID && o.Empleado_Id == emp.Id_Empleado && o.Monto > 0 
                                     select o.Monto).Count();

                if (otrosIngresosCount>0)
                {
                    otrosIngresos = (from o in datos.Liquidacion_Mensual_Detalle
                                              where o.Liquidacion_Id == Global.LiquidacionID && o.Empleado_Id == emp.Id_Empleado && o.Monto > 0
                                              select o.Monto).Sum();
                }

                // percibe
                var percibe = 0;
                percibe = emp.Salario_Basico;

                // id en mi base de datos del concepto percibe
                liquidDetalle.Concepto_Id = 6;
                liquidDetalle.Monto = percibe;

                datos.Liquidacion_Mensual_Detalle.Add(liquidDetalle);
                datos.SaveChanges();


                //IPS
                Liquidacion_Mensual_Detalle liquidDetalleIPS = new Liquidacion_Mensual_Detalle();
                liquidDetalleIPS.Empleado_Id = emp.Id_Empleado;
                liquidDetalleIPS.Liquidacion_Id = Global.LiquidacionID;

                var ips = 0;
                ips = ((percibe+otrosIngresos) * 9) / 100;

                // id en mi base de datos del concepto ips
                liquidDetalleIPS.Concepto_Id = 8;
                liquidDetalleIPS.Monto = ips * -1;

                datos.Liquidacion_Mensual_Detalle.Add(liquidDetalleIPS);
                datos.SaveChanges();

                
                //Anticipos
                Liquidacion_Mensual_Detalle liquidDetalleAnticipos = new Liquidacion_Mensual_Detalle();
                liquidDetalleAnticipos.Empleado_Id = emp.Id_Empleado;
                liquidDetalleAnticipos.Liquidacion_Id = Global.LiquidacionID;

                var otrosAnticipos = 0;
                 var otrosAnticiposCount = (from a in datos.Anticipo
                                        where a.Empleado_Id == emp.Id_Empleado && a.Fecha_Definicion.Value.Year == liquidacion.Anho && a.Fecha_Definicion.Value.Month == liquidacion.Mes
                                        select a.Monto_Aprobado).Count();

                if (otrosAnticiposCount>0)
                {
                    otrosAnticipos = (from a in datos.Anticipo
                                      where a.Empleado_Id == emp.Id_Empleado && a.Fecha_Definicion.Value.Year == liquidacion.Anho && a.Fecha_Definicion.Value.Month == liquidacion.Mes
                                      select a.Monto_Aprobado).Sum();
                }

                // id en mi base de datos del concepto de anticipo
                liquidDetalleAnticipos.Concepto_Id = 10;
                liquidDetalleAnticipos.Monto = otrosAnticipos * -1;

                datos.Liquidacion_Mensual_Detalle.Add(liquidDetalleAnticipos);
                datos.SaveChanges();
                
            }
            
        }
    }
}
