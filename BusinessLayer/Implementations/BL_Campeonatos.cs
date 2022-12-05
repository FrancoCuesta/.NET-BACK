using BusinessLayer.Interfaces;
using System;
using Shared;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;

namespace BusinessLayer.Implementations
{
    public class BL_Campeonatos : IBL_Campeonatos
    {
        private IDAL_Campeonatos _campeonatos;

        public BL_Campeonatos(IDAL_Campeonatos campeonatos)
        {
            _campeonatos = campeonatos;
        }

        public List<Campeonato> GetCampeonatos()
        {
            return _campeonatos.GetCampeonatos();
        }

        public Campeonato GetCampeonato(int id)
        {
            return _campeonatos.Get(id);
        }

        public Campeonato AddCampeonato(Campeonato campeonato)
        {
            return _campeonatos.AddCampeonato(campeonato);
        }

        public Campeonato SetCampeonato(Campeonato campeonato)
        {
            return _campeonatos.SetCampeonato(campeonato);
        }
        public Campeonato SetPartidos(int idC, int idP)
        {
            return _campeonatos.SetPartidos(idC, idP);
        }
        public Campeonato DeletePartidos(int idC, int idP)
        {
            return _campeonatos.DeletePartidos(idC, idP);
        }
    }
}
