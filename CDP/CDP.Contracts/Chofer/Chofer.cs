using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDP.Common
{
    [Serializable]
    public class Chofer
    {
        public int IdChofer { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cuit { get; set; }
        public string Camion { get; set; }
        public string Acoplado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public Boolean Activo { get; set; }
        public Boolean EsChoferTransportista { get; set; }
        public int IdGrupoEmpresa { get; set; }
        public string Domicilio { get; set; }
        public string Marca { get; set; }

        private string nombreApellido;
        public string NombreApellido
        {
            get { return EsChoferTransportista == true ? Nombre : (Cuit + " - " + Apellido + ", " + Nombre); }
            set { nombreApellido = value; }
        }
        
        //public string NombreApellido()
        //{
        //    if (this.EsChoferTransportista == true)
        //        return this.Nombre;
        //    else
        //        return this.Apellido + ", " + this.Nombre;
        //}
    }
}