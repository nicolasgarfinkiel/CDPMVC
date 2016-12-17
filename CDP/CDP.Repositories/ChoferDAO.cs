using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CDP.Repositories
{
    public class ChoferDAO
    {
        public IList<CDP.Domain.Chofer> GetChoferesCombo(string SearchChofer)
        {
            using (var db = new CDP.Repositories.CDPStrings())
            {
                IList<Chofer> Chofer = new List<Chofer>();
                if (string.IsNullOrEmpty(SearchChofer))
                    Chofer = db.Chofer.OrderBy(ch => ch.Cuit).Take(40).ToList();
                else
                    Chofer = db.Chofer.Where(ch => ch.Nombre.Contains(SearchChofer) ||
                                      ch.Apellido.Contains(SearchChofer) ||
                                      ch.Cuit.Contains(SearchChofer)).OrderBy(ch => ch.Cuit).Take(40).ToList();

                List<CDP.Domain.Chofer> choferes = new List<CDP.Domain.Chofer>();
                foreach (var item in Chofer.ToList<Chofer>())
                {
                    if ((item.Nombre != null || item.Apellido != null) &&
                        Regex.Replace(item.Nombre == null ? string.Empty : item.Nombre.Trim(), @"[^0-9a-zA-Z]+", string.Empty) != string.Empty)
                    {
                        choferes.Add(new Domain.Chofer
                        {
                            IdChofer = item.IdChofer,
                            Nombre = Regex.Replace(item.Nombre == null ? string.Empty : item.Nombre.ToUpper(), @"[^0-9a-zA-Z' 'ñÑ]+", string.Empty).Trim(),
                            Apellido = Regex.Replace(item.Apellido == null ? string.Empty : item.Apellido.ToUpper(), @"[^0-9a-zA-Z' 'ñÑ]+", string.Empty).Trim(),
                            Cuit = item.Cuit,
                            Camion = item.Camion,
                            Acoplado = item.Acoplado,
                            FechaCreacion = item.FechaCreacion,
                            UsuarioCreacion = item.UsuarioCreacion,
                            FechaModificacion = item.FechaModificacion,
                            UsuarioModificacion = item.UsuarioModificacion,
                            Activo = item.Activo,
                            EsChoferTransportista = item.EsChoferTransportista,
                            IdGrupoEmpresa = item.IdGrupoEmpresa,
                            Domicilio = item.Domicilio,
                            Marca = item.Marca
                        });
                    }
                }
                return choferes;
            }
        }

        public IList<CDP.Domain.Chofer> GetChoferes(int IdChofer, string sortColumn, string sortColumnDir)
        {
            using (var db = new CDP.Repositories.CDPStrings())
            {
                IList<Chofer> Chofer = new List<Chofer>();
                if (IdChofer != 0)
                    Chofer = Common.OrderByField(db.Chofer.Where(ch => ch.IdChofer == IdChofer), sortColumn, sortColumnDir).ToList();
                else
                    Chofer = Common.OrderByField(db.Chofer, sortColumn, sortColumnDir).ToList();

                List<CDP.Domain.Chofer> choferes = new List<CDP.Domain.Chofer>();
                foreach (var item in Chofer)
                {
                    if ((item.Nombre != null || item.Apellido != null) &&
                        Regex.Replace(item.Nombre == null ? string.Empty : item.Nombre.Trim(), @"[^0-9a-zA-Z]+", string.Empty) != string.Empty)
                    {
                        choferes.Add(new Domain.Chofer
                            {
                                IdChofer = item.IdChofer,
                                Nombre = Regex.Replace(item.Nombre == null ? string.Empty : item.Nombre.ToUpper(), @"[^0-9a-zA-Z' 'ñÑ]+", string.Empty).Trim(),
                                Apellido = Regex.Replace(item.Apellido == null ? string.Empty : item.Apellido.ToUpper(), @"[^0-9a-zA-Z' 'ñÑ]+", string.Empty).Trim(),
                                Cuit = item.Cuit,
                                Camion = item.Camion,
                                Acoplado = item.Acoplado,
                                FechaCreacion = item.FechaCreacion,
                                UsuarioCreacion = item.UsuarioCreacion,
                                FechaModificacion = item.FechaModificacion,
                                UsuarioModificacion = item.UsuarioModificacion,
                                Activo = item.Activo,
                                EsChoferTransportista = item.EsChoferTransportista,
                                IdGrupoEmpresa = item.IdGrupoEmpresa,
                                Domicilio = item.Domicilio,
                                Marca = item.Marca
                            });
                    }
                }
                return choferes;
            }
        }

        public CDP.Domain.Chofer GetChoferById(int IdChofer)
        {
            using (var db = new CDP.Repositories.CDPStrings())
            {
                var DBChofer = db.Chofer.Find(IdChofer);

                return new CDP.Domain.Chofer
                {
                    IdChofer = DBChofer.IdChofer,
                    Nombre = DBChofer.Nombre,
                    Apellido = DBChofer.Apellido,
                    Cuit = DBChofer.Cuit,
                    Camion = DBChofer.Camion,
                    Acoplado = DBChofer.Acoplado,
                    FechaCreacion = DBChofer.FechaCreacion,
                    UsuarioCreacion = DBChofer.UsuarioCreacion,
                    FechaModificacion = DBChofer.FechaModificacion,
                    UsuarioModificacion = DBChofer.UsuarioModificacion,
                    Activo = DBChofer.Activo,
                    EsChoferTransportista = DBChofer.EsChoferTransportista,
                    IdGrupoEmpresa = DBChofer.IdGrupoEmpresa,
                    Domicilio = DBChofer.Domicilio,
                    Marca = DBChofer.Marca
                };
            }
        }

        public IList<CDP.Domain.Chofer> GetChoferByCuit(string Cuit)
        {
            using (var db = new CDP.Repositories.CDPStrings())
            {
                var DBChofer = db.Chofer.Where(ch => ch.Cuit == Cuit).ToList();

                List<CDP.Domain.Chofer> choferes = new List<CDP.Domain.Chofer>();
                foreach (var item in DBChofer)
                {
                    choferes.Add(new Domain.Chofer
                    {
                        IdChofer = item.IdChofer,
                        Nombre = Regex.Replace(item.Nombre == null ? string.Empty : item.Nombre.ToUpper(), @"[^0-9a-zA-Z' 'ñÑ]+", string.Empty).Trim(),
                        Apellido = Regex.Replace(item.Apellido == null ? string.Empty : item.Apellido.ToUpper(), @"[^0-9a-zA-Z' 'ñÑ]+", string.Empty).Trim(),
                        Cuit = item.Cuit,
                        Camion = item.Camion,
                        Acoplado = item.Acoplado,
                        FechaCreacion = item.FechaCreacion,
                        UsuarioCreacion = item.UsuarioCreacion,
                        FechaModificacion = item.FechaModificacion,
                        UsuarioModificacion = item.UsuarioModificacion,
                        Activo = item.Activo,
                        EsChoferTransportista = item.EsChoferTransportista,
                        IdGrupoEmpresa = item.IdGrupoEmpresa,
                        Domicilio = item.Domicilio,
                        Marca = item.Marca
                    });
                }
                return choferes;
            }
        }

        public int Save(Domain.Chofer Chofer)
        {
            using (var db = new CDP.Repositories.CDPStrings())
            {
                if (Chofer.IdChofer == 0)
                    db.Chofer.Add(DataMapper.Map<Domain.Chofer, Chofer>(Chofer));
                else
                {
                    var Entity = db.Chofer.Find(Chofer.IdChofer);
                    Entity.Nombre = Chofer.Nombre;
                    Entity.Apellido = Chofer.Apellido;
                    Entity.Cuit = Chofer.Cuit;
                    Entity.Domicilio = Chofer.Domicilio;
                    Entity.Marca = Chofer.Marca;
                    Entity.Camion = Chofer.Camion;
                    Entity.Acoplado = Chofer.Acoplado;
                    Entity.FechaModificacion = DateTime.Now;
                    Entity.UsuarioModificacion = SessionWrapper.GetUser();
                }

                return db.SaveChanges();
            }
        }

        public int Habilitar(Domain.Chofer Chofer)
        {
            using (var db = new CDP.Repositories.CDPStrings())
            {
                var Entity = db.Chofer.Find(Chofer.IdChofer);
                Entity.Activo = !Chofer.Activo;

                return db.SaveChanges();
            }
        }
    }
}
