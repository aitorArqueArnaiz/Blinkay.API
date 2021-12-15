using Blinkay.Domain.Interfaces;
using Blinkay.Domain.Shared;
using Blinkay.Infrastructure.Entities;
using NHibernate.Linq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Blinkay.Domain.Services
{
    public class MySqlService : IMySqlService
    {
        private IMapperSession _session;

        public MySqlService(IMapperSession mysqlService)
        {
            this._session = mysqlService;
        }
        public async Task<User> MySQLInsertion(int iNumRegistries)
        {
            User user = null;
            for (int i = 0; i < iNumRegistries; i++)
            {
                try
                {
                    user = new User();
                    _session.BeginTransaction();
                    await _session.SaveOrUpdate(user);
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
            return user;

        }

        public async void MySQLSelectPlusUpdate(int iNumRegistries)
        {
            if (!this._session.Users.Any()) throw new Exception("No users in repository.");
            for (int i = 0; i < iNumRegistries; i++)
            {
                try
                {
                    var rnd = new Random();
                    var rndId = rnd.Next(1, this._session.Users.Count() - 1);
                    var rndUser = this._session.Users.Where(u => u.Id == rndId).FirstOrDefault();
                    while(rndUser == null)
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
                    await _session.Rollback();
                }
                finally
                {
                    _session.CloseTransaction();
                }
            }
        }

        public void MySQLSelectPlusUpdatePlusInsertion(int iNumRegistries)
        {
            for (int i = 0; i < iNumRegistries; i++)
            {
                this.MySQLInsertion(iNumRegistries);
                this.MySQLSelectPlusUpdate(iNumRegistries);
            }
        }
    }
}
