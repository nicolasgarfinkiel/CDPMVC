using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDP.Repositories;
using AutoMapper;

namespace CDP.BusinessLogic
{
    public class ChoferAdmin
    {
        public IList<CDP.Domain.Chofer> GetChoferesCombo(string SearchChofer)
        {
            return new ChoferDAO().GetChoferesCombo(SearchChofer);
        }

        public IList<CDP.Domain.Chofer> GetChoferes(int IdChofer, string sortColumn, string sortColumnDir)
        {
            return new ChoferDAO().GetChoferes(IdChofer, sortColumn, sortColumnDir);
        }

        public CDP.Domain.Chofer GetChoferById(int IdChofer)
        {
            return new ChoferDAO().GetChoferById(IdChofer);
        }

        public IList<CDP.Domain.Chofer> GetChoferByCuit(string Cuit)
        {
            return new ChoferDAO().GetChoferByCuit(Cuit);
        }

        public int Save(CDP.Domain.Chofer Chofer)
        {
            return new ChoferDAO().Save(Chofer);
        }

        public int Habilitar(CDP.Domain.Chofer Chofer)
        {
            return new ChoferDAO().Habilitar(Chofer);
        }
    }
}
