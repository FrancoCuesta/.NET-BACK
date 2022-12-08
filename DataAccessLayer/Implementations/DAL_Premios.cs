using System;
using Shared;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;

namespace DataAccessLayer.Implementations
{
    public class DAL_Premios : IDAL_Premios
    {
        public List<Shared.Premio> GetPremios()
        {
            using (TuPencaContext db = new TuPencaContext())
            {
                return db.Premios.Where(x => x.estado == true).Select(x => x.ToEntity()).ToList();
            }
        }

        public Shared.Premio Get(int id)
        {
            using (TuPencaContext db = new TuPencaContext())
            {
                return db.Premios.Where(x => x.id == id).FirstOrDefault()?.ToEntity();
            }
        }

        public Shared.Premio AddPremio(Shared.Premio e)
        {
            using (TuPencaContext db = new TuPencaContext())
            {
                Models.Premio nuevo = Models.Premio.ToSave(e);
                object value = db.Premios.Add(nuevo);
                db.SaveChanges();

                return Get(e.id);
            }

        }

        public Shared.Premio SetPremio(Shared.Premio premio)
        {
            using (TuPencaContext db = new TuPencaContext())
            {

                Models.Premio nuevo = Models.Premio.ToSave(premio);
                db.Premios.Update(nuevo);
                db.SaveChanges();

                return Get(premio.id);

            }
        }

        public Shared.Premio GetPremio(int id)
        {
            using (TuPencaContext db = new TuPencaContext())
            {
                return db.Premios.Where(x => x.id == id).FirstOrDefault()?.ToEntity();
            }
        }
        public void DeletePremio(int id)
        {
            using (TuPencaContext db = new TuPencaContext())
            {
                Models.Premio premio = db.Premios.Where(x => x.id == id).FirstOrDefault();
                db.Premios.Remove(premio);
                db.SaveChanges();
            }
        }

        public IEnumerable<Shared.Premio> getUsuario(string email)
        {
            using (TuPencaContext db = new TuPencaContext())
            {
                var user = db.Users.Where(x => x.Email == email).FirstOrDefault();
                email = user.Id;
                var premios= db.Premios.Where(x => x.UserId == email && x.estado == false).ToList();
                List<Shared.Premio> list = new();
                foreach(var x in premios)
                {
                    list.Add(x.ToEntity());
                }
                return list;
            }
        }

        public Shared.Premio cuenta(Shared.Premio p)
        {
            using (TuPencaContext db = new TuPencaContext())
            {
                var premios = db.Premios.Where(x => x.id == p.id).FirstOrDefault();
                premios.cuenta = p.cuenta;
                premios.estado = true;
                db.Premios.Update(premios);
                db.SaveChanges();
                return premios.ToEntity();
            }
        }
    }
}

