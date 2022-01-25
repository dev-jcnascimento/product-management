using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entities.Base;
using System.Linq.Expressions;

namespace ProductManagement.Infra.Persistence.Repositories.Base
{
    public class RepositoryBase<TEntidade, TId>
        where TEntidade : EntityBase
        where TId : struct
    {
        protected readonly ProductManagementContext _context;

        public RepositoryBase(ProductManagementContext context)
        {
            _context = context;
        }

        public IQueryable<TEntidade> ListBy(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            return List(includeProperties).Where(where);
        }

        public IQueryable<TEntidade> ListEndOrdersBy<TKey>(Expression<Func<TEntidade, bool>> where, Expression<Func<TEntidade, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            return ascendente ? ListBy(where, includeProperties).OrderBy(ordem) : ListBy(where, includeProperties).OrderByDescending(ordem);
        }

        public TEntidade GetBy(Func<TEntidade, bool> where, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            return List(includeProperties).FirstOrDefault(where);
        }

        public TEntidade GetById(TId id, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            if (includeProperties.Any())
            {
                return List(includeProperties).FirstOrDefault(x => x.Id.ToString() == id.ToString());
            }

            return _context.Set<TEntidade>().Find(id);
        }

        public IQueryable<TEntidade> List(params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            IQueryable<TEntidade> query = _context.Set<TEntidade>();

            if (includeProperties.Any())
            {
                return Include(_context.Set<TEntidade>(), includeProperties);
            }

            return query;
        }

        public IQueryable<TEntidade> ListOrderedBy<TKey>(Expression<Func<TEntidade, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            return ascendente ? List(includeProperties).OrderBy(ordem) : List(includeProperties).OrderByDescending(ordem);
        }

        public TEntidade Create(TEntidade entidade)
        {
             _context.Set<TEntidade>().Add(entidade);
            return entidade;

        }

        public TEntidade Update(TEntidade entidade)
        {
            _context.Entry(entidade).State = EntityState.Modified;

            return entidade;
        }

        public void Delete(TEntidade entidade)
        {
            _context.Set<TEntidade>().Remove(entidade);
        }

        /// <summary>
        /// Adicionar um coleção de entidades ao contexto do entity framework
        /// </summary>
        /// <param name="entidades">Lista de entidades que deverão ser persistidas</param>
        /// <returns></returns>
        public IEnumerable<TEntidade> AddList(IEnumerable<TEntidade> entidades)
        {
             _context.Set<TEntidade>().AddRangeAsync(entidades);
            return entidades;
        }

        /// <summary>
        /// Verifica se existe algum objeto com a condição informada
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public bool Exists(Func<TEntidade, bool> where)
        {
            return _context.Set<TEntidade>().Any(where);
        }

        /// <summary>
        /// Realiza include populando o objeto passado por parametro
        /// </summary>
        /// <param name="query">Informe o objeto do tipo IQuerable</param>
        /// <param name="includeProperties">Ínforme o array de expressões que deseja incluir</param>
        /// <returns></returns>
        private IQueryable<TEntidade> Include(IQueryable<TEntidade> query, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            foreach (var property in includeProperties)
            {
                query = query.Include(property);
            }

            return query;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
