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
    public class DAL_Partidos : IDAL_Partidos {
        
        public List<Shared.Partido> GetPartidos()
        {
            using (TuPencaContext db = new TuPencaContext())
            {
                return db.Partidos.Where(x => x.Campeonatoid == null).Select(x => x.ToEntity()).ToList();
            }
        }
        
        public Shared.Partido Get(int id)
        {
            using (TuPencaContext db = new TuPencaContext())
            {
                return db.Partidos.Where(x => x.id == id).FirstOrDefault()?.ToEntity();
            }
        }
        
        public Shared.Partido AddPartido(Shared.Partido p)
        {
            using (TuPencaContext db = new TuPencaContext())
            {
                Shared.Partido existe = Get(p.id);
                if (existe == null)
                {
                    Models.Partido nuevo = Models.Partido.ToSave(p);
                    
                    nuevo.estado = false;
                    db.Partidos.Add(nuevo);
                    db.SaveChanges();

                    return Get(p.id);
                }
                else
                {
                    throw new Exception("Ya existe un Partido con esa id");
                }

            }
        }
        public Shared.Partido SetPartido(Shared.Partido partido){
            using (TuPencaContext db = new TuPencaContext())
            {
                Shared.Partido existe = Get(partido.id);
                if (existe != null)
                {
                    Models.Partido nuevo = Models.Partido.ToSave(partido);
                    db.Partidos.Update(nuevo);
                    db.SaveChanges();

                    return Get(partido.id);
                }
                else
                {
                    throw new Exception("No existe un Partido con esa id");
                }

            }
        }
        public Shared.Partido CargarResultado(int id, int golA, int golB)
        {
            using (TuPencaContext db = new TuPencaContext())
            {
                Shared.Partido existe = Get(id);
                if (existe != null)
                {
                    Models.Partido nuevo = Models.Partido.ToSave(existe);
                    nuevo.golA = golA;
                    nuevo.golB = golB;
                    if (golA > golB)
                    {
                        nuevo.resultado = 1;
                    }
                    else if (golA < golB)
                    {
                        nuevo.resultado = 2;
                    }
                    else
                    {
                        nuevo.resultado = 0;
                    }
                    nuevo.estado = true;
                    db.Partidos.Update(nuevo);
                    db.SaveChanges();
                    //actualizar campeonato
                    DAL_Campeonatos dalCampeonatos = new DAL_Campeonatos();
                    dalCampeonatos.actualizar(nuevo.Campeonatoid, nuevo);
                    return Get(id);
                }
                else
                {
                    throw new Exception("No existe un Partido con esa id");
                }

            }
            
        }
        public Shared.Partido GetPartido(int id)
        {
            using (TuPencaContext db = new TuPencaContext())
            {
                return db.Partidos.Where(x => x.id == id).FirstOrDefault()?.ToEntity();
            }
        }


    }
}
