using Blinkay.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blinkay.Domain.Services
{
    public class PosgreeService : IPosgreeService
    {
        private IMapperSession _session;

        public PosgreeService(IMapperSession session)
        {
            this._session = session;
        }

        public int PGInsertion(int iNumRegistries, int iNumThreads)
        {
            throw new NotImplementedException();
        }

        public int PGSelectPlusUpdate(int iNumRegistries, int iNumThreads)
        {
            throw new NotImplementedException();
        }

        public int PGSelectPlusUpdatePlusInsertion(int iNumRegistries, int iNumThreads)
        {
            throw new NotImplementedException();
        }
    }
}
