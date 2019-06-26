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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Nomina
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    /// 
    class Global
    {
        public static int UserID;
        public static int EmpleadoID;

    }

    public partial class Login : Window
    {
        NominaEntities nomina = new NominaEntities();
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lbl_mensaje.Visibility = Visibility.Hidden;
            if (txt_usuario.Text.Length == 0)
            {
                lbl_mensaje.Content = "Ingrese usuario.";
                lbl_mensaje.Visibility = Visibility.Visible;
                txt_usuario.Focus();
            }
            else if (txt_pass.Password.Length == 0)
            {
                lbl_mensaje.Content = "Ingrese contraseña";
                lbl_mensaje.Visibility = Visibility.Visible;
                txt_pass.Focus();
            }
            else
            {
                lbl_mensaje.Visibility = Visibility.Hidden;
                string usuario = txt_usuario.Text;
                string password = txt_pass.Password;
                var login = nomina.Usuario.Where(x => x.Usuario1 == usuario.Trim() && x.Password == password.Trim()).FirstOrDefault();


                if (login!= null) {
                    Global.UserID = login.Id_Usuario;
                    Menu menu = new Menu();
                    menu.Show();
                    this.Close(); 
                }
                else
                {
                    lbl_mensaje.Content = "Datos inválidos.";
                    lbl_mensaje.Visibility = Visibility.Visible;
                    txt_usuario.Focus();
                }
            }
        }
    }
    
}
