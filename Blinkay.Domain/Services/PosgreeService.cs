using Blinkay.Domain.Interfaces;
using Blinkay.Domain.Shared;
using Blinkay.Infrastructure.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Blinkay.Domain.Services
{
    public class PosgreeService : IPosgreeService
    {
        private IMapperSessionPG _session;

        public PosgreeService(IMapperSessionPG session)
        {
            this._session = session;
        }

        public async Task<User> PGInsertion(int iNumRegistries)
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

        public async void PGSelectPlusUpdate(int iNumRegistries)
        {
            if (!this._session.Users.Any()) throw new Exception("No users in repository.");
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
                    await _session.Rollback();
                }
                finally
                {
                    _session.CloseTransaction();
                }
            }
        }

        public async  void PGSelectPlusUpdatePlusInsertion(int iNumRegistries)
        {
            for (int i = 0; i < iNumRegistries; i++)
            {
                await this.PGInsertion(iNumRegistries);
                this.PGSelectPlusUpdate(iNumRegistries);
            }
        }
    }
}
