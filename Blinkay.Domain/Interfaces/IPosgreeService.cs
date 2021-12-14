namespace Blinkay.Domain.Interfaces
{
    public interface IPosgreeService
    {
        /// <summary>
        /// Postgree insertion use case.
        /// </summary>
        /// <param name="iNumRegistries"></param>
        /// <param name="iNumThreads"></param>
        /// <returns></returns>
        int PGInsertion(int iNumRegistries, int iNumThreads);

        /// <summary>
        /// postgree select plus update use case.
        /// </summary>
        /// <param name="iNumRegistries"></param>
        /// <param name="iNumThreads"></param>
        /// <returns></returns>
        int PGSelectPlusUpdate(int iNumRegistries, int iNumThreads);

        /// <summary>
        /// Select plus update plus insertion use case.
        /// </summary>
        /// <param name="iNumRegistries"></param>
        /// <param name="iNumThreads"></param>
        /// <returns></returns>

        int PGSelectPlusUpdatePlusInsertion(int iNumRegistries, int iNumThreads);
    }
}
