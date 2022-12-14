using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;

namespace DataAccessLayer.Implementations
{
    public class DAL_Predicsion : IDAL_Predicsion
    {
        public Shared.Predicsion AddPredicsion(Shared.Predicsion e)
        {
            using TuPencaContext db = new();
            Models.Predicsion nuevo = Models.Predicsion.ToSave(e);
            db.Predicsion.Add(nuevo);
            db.SaveChanges();
            return Get(e.id);
        }

        public Shared.Predicsion? existe(Shared.Predicsion e)
        {
            using TuPencaContext db = new();
            var user = db.Users.Where(x => x.Email == e.UserId).FirstOrDefault();
            e.UserId = user.Id;
            return db.Predicsion?.Where(x => x.Pencaid == e.Pencaid && x.Partidoid == e.Partidoid && x.UserId == e.UserId)
                                 .FirstOrDefault()?
                                 .ToEntity();
        }

        public Shared.Predicsion Get(int id)
        {
            using TuPencaContext db = new();
            return db.Predicsion.Where(x => x.id == id).FirstOrDefault()?.ToEntity();
        }

        public List<Shared.Predicsion> GetPredicsion()
        {
            using TuPencaContext db = new();
            return db.Predicsion.Select(x => x.ToEntity()).ToList();
        }

        public Shared.Predicsion updatePredicsion(Shared.Predicsion e)
        {
            using TuPencaContext db = new();
            {
                Shared.Predicsion? existe = db.Predicsion.Where(x => x.Pencaid == e.Pencaid && x.Partidoid == e.Partidoid && x.UserId == e.UserId).FirstOrDefault()?.ToEntity();
                if (existe != null)
                {
                    return Get(e.id);
                }
                else
                {
                    throw new Exception("NO existe");
                }

            }
        }
    }
}
