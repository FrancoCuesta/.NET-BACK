using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using Shared;
using DataAccessLayer.Interfaces;

namespace BusinessLayer.Implementations
{
    public class BL_Penca : IBL_Penca
    {
        private IDAL_Penca _penca;
        public BL_Penca(IDAL_Penca penca) => _penca = penca;
        public Penca Get(int id) => _penca.Get(id);
        public Penca AddPenca(Penca penca) => _penca.AddPenca(penca);
        public Penca SetPenca(Penca penca) => _penca.SetPenca(penca);
        public Penca AddCampeonato(int c, int p) => _penca.AddCampeonato(c, p);
        public Penca DeleteCampeonato(int p) => _penca.DeleteCampeonato(p);
        public User_Penca SetUsuarios(string u, int p) => _penca.SetUsuarios(u, p);
        public User_Penca Deleteusuarios(string u, int p) => _penca.Deleteusuarios(u, p);
        public List<Penca> GetPencasPublica() => _penca.GetPencasPublica();
        public List<Penca> GetPencasPrivada(string id) => _penca.GetPencasPrivada(id);
        public User_Penca EstasUnido(string u, int p) => _penca.EstasUnido(u, p);
        public Penca finalizar(int penca) => _penca.finalizar(penca);
    }
}
