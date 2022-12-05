using System;
using Shared;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Migrations;

namespace DataAccessLayer.Implementations
{
    public class DAL_Equipos : IDAL_Equipos{
        
        public List<Shared.Equipo> GetEquipos()
        {
            using (TuPencaContext db = new TuPencaContext())
            {
                return db.Equipos.Select(x => x.ToEntity()).ToList();
            }
        }

        public Shared.Equipo Get(int id)
        {
            using(TuPencaContext db = new TuPencaContext())
            {
                return db.Equipos.Where(x => x.id == id).FirstOrDefault()?.ToEntity();
            }
        }

        public Shared.Equipo AddEquipo(Shared.Equipo e)
        {
            using (TuPencaContext db = new TuPencaContext())
            {
                Shared.Equipo existe = Get(e.id);
                if (existe == null)
                {
                    Models.Equipo nuevo = Models.Equipo.ToSave(e);
                    db.Equipos.Add(nuevo);
                    db.SaveChanges();

                    return Get(e.id);
                }
                else
                {
                    throw new Exception("Ya existe un equipo con esa id");
                }

            }

        }

        public Shared.Equipo SetEquipo(Shared.Equipo e)
        {

            using (TuPencaContext db =new TuPencaContext())
            {

                Shared.Equipo existe = Get(e.id);
                if(existe != null)
                {
                    Models.Equipo equipo = Models.Equipo.ToSave(e);
                    db.Equipos.Update(equipo);
                    db.SaveChanges();

                    return Get(e.id);

                }
                else
                {
                    throw new Exception("No existe un equipo con ese id");
                }
            }

        }
    }
}
