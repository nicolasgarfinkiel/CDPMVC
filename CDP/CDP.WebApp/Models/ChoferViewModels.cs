using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CDP.WebApp.Models
{
    [Bind(Prefix = "ChoferViewModels")]
    public class ChoferViewModels
    {
        public int IdChofer { get; set; }
        [Required(ErrorMessage = "Ingrese nombre o descripción")]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }
        [DataType(DataType.Text)]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Ingrese el cuit")]
        [StringLength(11, ErrorMessage = "La lingitud máxima es de 11 caracteres")]
        [Range(0, int.MaxValue, ErrorMessage = "Ingrese solo números")]
        public string Cuit { get; set; }
        public string Camion { get; set; }
        public string Acoplado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public Boolean Activo { get; set; }
        public Boolean EsChoferTransportista { get; set; }
        public int IdGrupoEmpresa { get; set; }
        public string Domicilio { get; set; }
        public string Marca { get; set; }
        public string JavascriptToRun { get; set; }

        private string descripcion;
        public string Descripcion
        {
            get { return Apellido == null ? string.Empty : Apellido.ToString() + (Apellido.ToString() == string.Empty ? Nombre.ToString() : ", " + Nombre.ToString()); }
            set { descripcion = value; }
        }

        private string habilitado;
        public string Habilitado
        {
            get { return Activo == true ? "Si" : "No"; }
            set { habilitado = value; }
        }

        private string transportista;
        public string Transportista
        {
            get { return EsChoferTransportista == true ? "Si" : "No"; }
            set { transportista = value; }
        }
    }
}