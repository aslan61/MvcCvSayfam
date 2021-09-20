using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MvcCvSayfam.Models.Entity;

namespace MvcCvSayfam.Repositories
{
    public class GenericRepository<T> where T:class, new()
    {
        DbCvEntities2 db = new DbCvEntities2();
        public List<T> List()
        {
            return db.Set<T>().ToList();
        }
        public void Tadd(T id)
        {
            db.Set<T>().Add(id);
            db.SaveChanges();
        }
        public void TDelete(T p)
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }
        public T TGet(int id)
        {
            return db.Set<T>().Find(id);
        }
        public void TUpdate(T p)
        {
            db.SaveChanges();
        }
        public T Find(Expression<Func<T,bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }
    }
}