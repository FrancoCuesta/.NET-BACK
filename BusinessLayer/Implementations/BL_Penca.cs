using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using Shared;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;

namespace BusinessLayer.Implementations
{
    public class BL_Penca : IBL_Penca
    {
        private IDAL_Penca _penca;
        public BL_Penca(IDAL_Penca penca) => _penca = penca;
        public Shared.Penca Get(int id) => _penca.Get(id);
        public Shared.Penca AddPenca(Shared.Penca penca) => _penca.AddPenca(penca);
        public Shared.Penca SetPenca(Shared.Penca penca) => _penca.SetPenca(penca);
        public Shared.Penca AddCampeonato(int c, int p) => _penca.AddCampeonato(c, p);
        public Shared.Penca DeleteCampeonato(int p) => _penca.DeleteCampeonato(p);
        public Shared.User_Penca SetUsuarios(string u, int p) => _penca.SetUsuarios(u, p);
        public Shared.User_Penca Deleteusuarios(string u, int p) => _penca.Deleteusuarios(u, p);
        public List<Shared.Penca> GetPencasPublica() => _penca.GetPencasPublica();
        public List<Shared.Penca> GetPencasPrivada(string id) => _penca.GetPencasPrivada(id);
        public Shared.User_Penca EstasUnido(string u, int p) => _penca.EstasUnido(u, p);
        public Shared.Penca finalizar(int penca) => _penca.finalizar(penca);
        public List<Users> GetUsuarios(int idP) => _penca.GetUsuarios(idP);
    }
}
