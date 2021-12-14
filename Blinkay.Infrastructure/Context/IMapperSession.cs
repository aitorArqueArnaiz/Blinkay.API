using Blinkay.Infrastructure.Entities;
using System.Linq;
using System.Threading.Tasks;

public interface IMapperSession
{
    /// <summary>
    /// Begin a db transaction.
    /// </summary>
    void BeginTransaction();

    /// <summary>
    /// Commit a db transaction.
    /// </summary>
    /// <returns></returns>
    Task Commit();

    /// <summary>
    /// Rollbac a db transaction.
    /// </summary>
    /// <returns></returns>
    Task Rollback();

    /// <summary>
    /// Close alive transaction.
    /// </summary>
    void CloseTransaction();

    /// <summary>
    /// iserts db transaction.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task SaveOrUpdate(User entity);

    /// <summary>
    /// Deletes an existing transaction.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task Delete(User entity);

    IQueryable<User> Users { get; }
}