using Blinkay.Domain.Interfaces;
using Blinkay.Infrastructure.Entities;
using System;
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

        public int PGSelectPlusUpdate(int iNumRegistries)
        {
            throw new NotImplementedException();
        }

        public int PGSelectPlusUpdatePlusInsertion(int iNumRegistries)
        {
            throw new NotImplementedException();
        }
    }
}
