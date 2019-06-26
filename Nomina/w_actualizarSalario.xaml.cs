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
    /// Lógica de interacción para w_actualizarSalario.xaml
    /// </summary>
    public partial class w_actualizarSalario : Window
    {
        NominaEntities datos;
        public w_actualizarSalario()
        {
            InitializeComponent();
            datos = new NominaEntities();
        }

        private void btn_nuevo_Click(object sender, RoutedEventArgs e)
        {
            Empleado em = datos.Empleado.Find(Global.EmpleadoID);
            em.Salario_Basico = int.Parse(txtSalarioNuevo.Text);
            datos.Empleado.Add(em);

            var salarioAnterior = datos.Empleado_Salario_Historico.Where(z => z.Empleado_Id == Global.EmpleadoID).LastOrDefault();

            Empleado_Salario_Historico eh = new Empleado_Salario_Historico();
            eh.Empleado_Id = em.Id_Empleado;
            eh.Fecha_Hora = DateTime.Now;
            eh.Salario_Basico_Nuevo = em.Salario_Basico;
            eh.Salario_Basico_Anterior = salarioAnterior.Salario_Basico_Nuevo;
            eh.Usuario_Id = Global.UserID;
            datos.Empleado_Salario_Historico.Add(eh);

            datos.Entry(em).State = System.Data.Entity.EntityState.Modified;
            datos.SaveChanges();
        }
    }
}
