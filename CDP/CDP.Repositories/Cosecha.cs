//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CDP.Repositories
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cosecha
    {
        public int IdCosecha { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public int IdGrupoEmpresa { get; set; }
    }
}
