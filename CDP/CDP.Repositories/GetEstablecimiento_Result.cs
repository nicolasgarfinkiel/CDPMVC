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
    
    public partial class GetEstablecimiento_Result
    {
        public int IdEstablecimiento { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public Nullable<int> Localidad { get; set; }
        public Nullable<int> Provincia { get; set; }
        public string IDAlmacenSAP { get; set; }
        public string IDCentroSAP { get; set; }
        public Nullable<int> IdInterlocutorDestinatario { get; set; }
        public Nullable<int> RecorridoEstablecimiento { get; set; }
        public string IDCEBE { get; set; }
        public string IDExpedicion { get; set; }
        public string EstablecimientoAfip { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public Nullable<bool> Activo { get; set; }
        public bool AsociaCartaDePorte { get; set; }
        public int IdEmpresa { get; set; }
    }
}
