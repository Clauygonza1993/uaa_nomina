//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nomina
{
    using System;
    using System.Collections.Generic;
    
    public partial class Empleado_Salario_Historico
    {
        public int Id_Salario_Historico { get; set; }
        public int Empleado_Id { get; set; }
        public int Salario_Basico_Anterior { get; set; }
        public int Salario_Basico_Nuevo { get; set; }
        public System.DateTime Fecha_Hora { get; set; }
        public int Usuario_Id { get; set; }
    
        public virtual Empleado Empleado { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
