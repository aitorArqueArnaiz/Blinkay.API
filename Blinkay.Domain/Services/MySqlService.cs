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
            for(int i = 0; i < iNumRegistries; ++i)
            {
                try
                {
                    _session.BeginTransaction();
                    await _session.Save(new User());
                    await _session.Commit();
                }
                catch
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
            throw new NotImplementedException();
        }

        public async void MySQLSelectPlusUpdatePlusInsertion(int iNumRegistries)
        {
            throw new NotImplementedException();
        }
    }
}
