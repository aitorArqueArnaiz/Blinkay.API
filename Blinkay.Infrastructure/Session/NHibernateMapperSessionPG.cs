using Blinkay.Infrastructure.Entities;
using NHibernate;
using System.Linq;
using System.Threading.Tasks;

public class NHibernateMapperSessionPG : IMapperSessionPG
{
    private readonly ISession _session;
    private ITransaction _transaction;

    public NHibernateMapperSessionPG(ISession session)
    {
        _session = session;
    }

    public IQueryable<User> Users => _session.Query<User>();


    public void BeginTransaction()
    {
        _transaction = _session.BeginTransaction();
    }

    public async Task Commit()
    {
        await _transaction.CommitAsync();
    }

    public async Task Rollback()
    {
        await _transaction.RollbackAsync();
    }

    public void CloseTransaction()
    {
        if (_transaction != null)
        {
            _transaction.Dispose();
            _transaction = null;
        }
    }

    public async Task SaveOrUpdate(User entity)
    {
        await _session.SaveOrUpdateAsync(entity);
    }

    public async Task Delete(User entity)
    {
        await _session.DeleteAsync(entity);
    }
}