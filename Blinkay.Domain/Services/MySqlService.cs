using Blinkay.Domain.Interfaces;
using Blinkay.Domain.Shared;
using Blinkay.Infrastructure.Entities;
using NHibernate.Linq;
using System;
using System.Linq;

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
                this.MySQLInsertion(iNumRegistries);
                this.MySQLSelectPlusUpdate(iNumRegistries);
            }
        }

        public async void MySQLSelectPlusUpdatePlusInsertion(int iNumRegistries)
        {
            for (int i = 0; i < iNumRegistries; i++)
            {
                try
                {
                    var rnd = new Random();
                    var rndId = rnd.Next(1, this._session.Users.Count() - 1);
                    var rndUser = this._session.Users.Where(u => u.Id == rndId).FirstOrDefault();
                    while (rndUser == null)
                    {
                        rndId = rnd.Next(1, this._session.Users.Count() - 1);
                        rndUser = this._session.Users.Where(u => u.Id == rndId).FirstOrDefault();
                    }
                    rndUser.Info = StringHelper.CreateRandomString(100);

                    _session.BeginTransaction();
                    await _session.SaveOrUpdate(rndUser);
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
    }
}
