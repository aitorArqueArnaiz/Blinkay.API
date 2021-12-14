using Blinkay.Domain.Interfaces;
using Blinkay.Infrastructure.Entities;
using NHibernate.Linq;
using System;

namespace Blinkay.Domain.Services
{
    public class MySqlService : IMySqlService
    {
        private IMapperSession _session;

        public MySqlService(IMapperSession mysqlService)
        {
            this._session = mysqlService;
        }
        public async void MySQLInsertion(int iNumRegistries)
        {
            for(int i = 0; i < iNumRegistries; i++)
            {
                try
                {
                    _session.BeginTransaction();
                    await _session.SaveOrUpdate(new User());
                    await _session.Commit();
                }
                catch (Exception error)
                {
                    // log exception here
                    await _session.Rollback();
                }
                finally
                {
                    _session.CloseTransaction();
                }
            }

        }

        public async void MySQLSelectPlusUpdate(int iNumRegistries)
        {
            for (int i = 0; i < iNumRegistries; i++)
            {
                try
                {
                    _session.BeginTransaction();
                    await _session.SaveOrUpdate(new User());
                    await _session.Commit();
                }
                catch (Exception error)
                {
                    // log exception here
                    await _session.Rollback();
                }
                finally
                {
                    _session.CloseTransaction();
                }
            }
        }

        public async void MySQLSelectPlusUpdatePlusInsertion(int iNumRegistries)
        {
            throw new NotImplementedException();
        }
    }
}
