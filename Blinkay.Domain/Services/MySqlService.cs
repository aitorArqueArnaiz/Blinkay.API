using Blinkay.Domain.Interfaces;
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
        public int MySQLInsertion(int iNumRegistries, int iNumThreads)
        {
            throw new NotImplementedException();
        }

        public int MySQLSelectPlusUpdate(int iNumRegistries, int iNumThreads)
        {
            throw new NotImplementedException();
        }

        public int MySQLSelectPlusUpdatePlusInsertion(int iNumRegistries, int iNumThreads)
        {
            throw new NotImplementedException();
        }
    }
}
