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
        private readonly ApplicationContext _session;

        public PosgreeService(ApplicationContext session)
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
                    _session.users.Add(user);
                    _session.SaveChanges();
                }
                catch (Exception error)
                {
                    throw new Exception(error.Message);
                }
            }
            return user;
        }

        public async Task PGSelectPlusUpdate(int iNumRegistries)
        {
            for (int i = 0; i < iNumRegistries; i++)
            {
                try
                {
                    var rnd = new Random();
                    var rndId = rnd.Next(1, this._session.users.Count() - 1);
                    var rndUser = this._session.users.Where(u => u.iduser == rndId).FirstOrDefault();
                    while (rndUser == null)
                    {
                        rndId = rnd.Next(1, this._session.users.Count() - 1);
                        rndUser = this._session.users.Where(u => u.iduser == rndId).FirstOrDefault();
                    }
                    rndUser.userinfo = StringHelper.CreateRandomString(100);

                    await _session.AddAsync(rndUser);
                    await _session.SaveChangesAsync();
                }
                catch (Exception error)
                {
                    throw new Exception(error.Message);
                }
            }
        }

        public async  void PGSelectPlusUpdatePlusInsertion(int iNumRegistries)
        {
            for (int i = 0; i < iNumRegistries; i++)
            {
                await this.PGInsertion(iNumRegistries);
                await this.PGSelectPlusUpdate(iNumRegistries);
            }
        }
    }
}
