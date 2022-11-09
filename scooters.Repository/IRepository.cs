using System.Linq.Expressions;
using scooters.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace scooters.Repository;

public interface IRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll();
    IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
    T GetById(Guid id);
    T Save(T obj);
    void Delete(T obj);
}
