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
    
    public partial class GetGrano_Result
    {
        public int IdGrano { get; set; }
        public string Descripcion { get; set; }
        public string IdMaterialSap { get; set; }
        public Nullable<int> IdEspecieAfip { get; set; }
        public Nullable<int> IdCosechaAfip { get; set; }
        public Nullable<int> IdTipoGrano { get; set; }
        public string SujetoALote { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public Nullable<bool> Activo { get; set; }
        public int IdGrupoEmpresa { get; set; }
    }
}
