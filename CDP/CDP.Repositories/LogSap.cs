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
    
    public partial class LogSap
    {
        public int IdLogSap { get; set; }
        public string IDoc { get; set; }
        public string Origen { get; set; }
        public string NroDocumentoRE { get; set; }
        public string NroDocumentoSap { get; set; }
        public string TipoMensaje { get; set; }
        public string TextoMensaje { get; set; }
        public Nullable<int> NroEnvio { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
    }
}
