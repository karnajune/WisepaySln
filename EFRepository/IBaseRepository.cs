using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
public interface IBaseRepository<T>:IDisposable
  {
    IQueryable<T> Entities { get; }

    T New();

    void Update(T entity);

    T Create(T entity);

    void Create(List<T> collection);

    void Delete(T entity);

    void SetAsDeleted(List<T> entityCollection);
  }
}
