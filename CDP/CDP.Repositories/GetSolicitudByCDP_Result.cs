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
    
    public partial class GetSolicitudByCDP_Result
    {
        public int IdSolicitud { get; set; }
        public Nullable<int> IdTipoDeCarta { get; set; }
        public string ObservacionAfip { get; set; }
        public string NumeroCartaDePorte { get; set; }
        public string Cee { get; set; }
        public string Ctg { get; set; }
        public Nullable<System.DateTime> FechaDeEmision { get; set; }
        public Nullable<System.DateTime> FechaDeCarga { get; set; }
        public Nullable<System.DateTime> FechaDeVencimiento { get; set; }
        public Nullable<int> idProveedorTitularCartaDePorte { get; set; }
        public Nullable<int> IdClienteIntermediario { get; set; }
        public Nullable<int> IdClienteRemitenteComercial { get; set; }
        public Nullable<bool> RemitenteComercialComoCanjeador { get; set; }
        public Nullable<int> IdClienteCorredor { get; set; }
        public Nullable<int> IdClienteEntregador { get; set; }
        public Nullable<int> IdClienteDestinatario { get; set; }
        public Nullable<int> IdClienteDestino { get; set; }
        public Nullable<int> IdProveedorTransportista { get; set; }
        public Nullable<int> IdChofer { get; set; }
        public Nullable<int> IdCosecha { get; set; }
        public Nullable<int> IdEspecie { get; set; }
        public Nullable<int> NumeroContrato { get; set; }
        public Nullable<int> SapContrato { get; set; }
        public Nullable<bool> SinContrato { get; set; }
        public Nullable<bool> CargaPesadaDestino { get; set; }
        public Nullable<decimal> KilogramosEstimados { get; set; }
        public string DeclaracionDeCalidad { get; set; }
        public Nullable<int> IdConformeCondicional { get; set; }
        public Nullable<decimal> PesoBruto { get; set; }
        public Nullable<decimal> PesoTara { get; set; }
        public Nullable<decimal> PesoNeto { get; set; }
        public string Observaciones { get; set; }
        public string LoteDeMaterial { get; set; }
        public Nullable<int> IdEstablecimientoProcedencia { get; set; }
        public Nullable<int> IdEstablecimientoDestino { get; set; }
        public string PatenteCamion { get; set; }
        public string PatenteAcoplado { get; set; }
        public Nullable<decimal> KmRecorridos { get; set; }
        public Nullable<int> EstadoFlete { get; set; }
        public Nullable<decimal> CantHoras { get; set; }
        public Nullable<decimal> TarifaReferencia { get; set; }
        public Nullable<decimal> TarifaReal { get; set; }
        public Nullable<int> IdClientePagadorDelFlete { get; set; }
        public Nullable<int> EstadoEnSAP { get; set; }
        public Nullable<int> EstadoEnAFIP { get; set; }
        public Nullable<int> IdGrano { get; set; }
        public Nullable<decimal> CodigoAnulacionAfip { get; set; }
        public Nullable<System.DateTime> FechaAnulacionAfip { get; set; }
        public string CodigoRespuestaEnvioSAP { get; set; }
        public string MensajeRespuestaEnvioSAP { get; set; }
        public string CodigoRespuestaAnulacionSAP { get; set; }
        public string MensajeRespuestaAnulacionSAP { get; set; }
        public Nullable<int> IdEstablecimientoDestinoCambio { get; set; }
        public Nullable<int> IdClienteDestinatarioCambio { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public Nullable<System.DateTime> FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public Nullable<int> IdChoferTransportista { get; set; }
        public int IdEmpresa { get; set; }
        public Nullable<decimal> PHumedad { get; set; }
        public Nullable<decimal> POtros { get; set; }
    }
}
