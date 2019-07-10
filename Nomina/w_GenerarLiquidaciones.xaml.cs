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
    public partial class w_GenerarLiquidaciones : Window
    {
        NominaEntities datos;
        public w_GenerarLiquidaciones()
        {
            InitializeComponent();
            datos = new NominaEntities();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            int mes = DateTime.Now.Month;
            int anho = DateTime.Now.Year;
            cbo_mes.SelectedValue = mes;
            cbo_anho.SelectedValue = anho;
           
        }

       

        private void btn_procesar_Click(object sender, RoutedEventArgs e)
        {
            Liquidacion_Mensual liqui = new Liquidacion_Mensual();
            int mes = int.Parse(cbo_mes.SelectedValue.ToString());
            int anho = int.Parse(cbo_anho.SelectedValue.ToString());
            liqui.Mes = (short)mes;
            liqui.Anho = (short)anho;
            liqui.Fecha_Generacion = DateTime.Now;
            //liqui.Usuario_Id = Global.UserID;
            liqui.Usuario_Id = 4;
            liqui.Estado = "A";
            var l = datos.Liquidacion_Mensual.Add(liqui);
            Global.LiquidacionID = l.Id_Liquidacion;

        
            datos.SaveChanges();

        }

        private void btn_detalle_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
