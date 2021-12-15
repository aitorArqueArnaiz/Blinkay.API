using Blinkay.Infrastructure.Entities;
using System.Threading.Tasks;

namespace Blinkay.Domain.Interfaces
{
    public interface IPosgreeService
    {
        /// <summary>
        /// Postgree insertion use case.
        /// </summary>
        /// <param name="iNumRegistries"></param>
        /// <returns></returns>
        Task<User> PGInsertion(int iNumRegistries);

        /// <summary>
        /// postgree select plus update use case.
        /// </summary>
        /// <param name="iNumRegistries"></param>
        /// <returns></returns>
        int PGSelectPlusUpdate(int iNumRegistries);

        /// <summary>
        /// Select plus update plus insertion use case.
        /// </summary>
        /// <param name="iNumRegistries"></param>
        /// <returns></returns>

        int PGSelectPlusUpdatePlusInsertion(int iNumRegistries);
    }
}
