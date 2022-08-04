using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using CvWebsite.Models.Entity;

namespace CvWebsite.Repository
{
    public class GenericRepository<T> where T : class, new()
    {
        DbCVEntities Db = new DbCVEntities();
        
        public List<T> List()
        {
            return Db.Set<T>().ToList();
        }
        public void TAdd(T P)
        {
            Db.Set<T>().Add(P);
            Db.SaveChanges();
        }
        public void TAdd2(T P)
        {
            Db.Set<T>().Add(P);
            Db.SaveChanges();
        }

        public void TDelete(T P)
        {
            Db.Set<T>().Remove(P);
            Db.SaveChanges();

        }
        public void TUpdate(T P)
        {
            Db.SaveChanges();
        }

        public T Find(Expression<Func<T,bool>> where)
        {
            return Db.Set<T>().FirstOrDefault(where);
        }


    }
}