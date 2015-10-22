using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;

namespace SoftUniContests.DAL.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class//, IEntity
    {
        internal SoftuniContestsEntities context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(SoftuniContestsEntities context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")//, Expression<Func<TEntity, TProperty>> stronglyTypedInclude = null
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

        public virtual List<T> Get<T>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            List<T> list;
            if (orderBy != null)
            {
                list = orderBy(query).Project().To<T>().ToList();
            }
            else
            {
                list = query.Project().To<T>().ToList();
            }
            return list;
        }


        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        //public virtual void Insert(object entity)
        //{
        //    if (entity is TEntity)
        //    {
        //        dbSet.Add(entity as TEntity);
        //    }
        //    else
        //    {
        //        TEntity mappedEntity = Mapper.Map<TEntity>(entity);
        //        dbSet.Add(mappedEntity);
        //    }

        //}

        public virtual TEntity Insert(object entity)
        {
            if (entity is TEntity)
            {
                TEntity obj = entity as TEntity;
                dbSet.Add(obj);
                return obj;
            }
            else
            {
                TEntity mappedEntity = Mapper.Map<TEntity>(entity);
                dbSet.Add(mappedEntity);
                return mappedEntity;
            }

        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            DeleteObject(entityToDelete);
        }

        public virtual void DeleteObject(object entityToDelete)
        {

            if (entityToDelete is TEntity)
            {
                TEntity delete = entityToDelete as TEntity;
                if (context.Entry(delete).State == EntityState.Detached)
                {
                    dbSet.Attach(delete);
                }
                dbSet.Remove(delete);
            }
            else
            {
                TEntity mappedEntity = Mapper.Map<TEntity>(entityToDelete);
                if (context.Entry(mappedEntity).State == EntityState.Detached)
                {
                    dbSet.Attach(mappedEntity);
                }
                dbSet.Remove(mappedEntity);
            }
        }
        public virtual IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters)
        {
            return dbSet.SqlQuery(query, parameters).ToList();
        }
        public virtual void Update(object entityToUpdate)
        {
            if (entityToUpdate is TEntity)
            {
                TEntity entity = entityToUpdate as TEntity;
                dbSet.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                TEntity mappedEntity = Mapper.Map<TEntity>(entityToUpdate);
                dbSet.Attach(mappedEntity);
                context.Entry(mappedEntity).State = EntityState.Modified;
            }

        }
    }
}
