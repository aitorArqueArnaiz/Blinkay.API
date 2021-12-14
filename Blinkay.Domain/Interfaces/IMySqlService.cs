using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blinkay.Domain.Interfaces
{
    public interface IMySqlService
    {
        /// <summary>
        /// MySql insertion use case.
        /// </summary>
        /// <param name="iNumRegistries"></param>
        /// <param name="iNumThreads"></param>
        /// <returns></returns>
        int MySQLInsertion(int iNumRegistries, int iNumThreads);

        /// <summary>
        /// MySql select plus update use case.
        /// </summary>
        /// <param name="iNumRegistries"></param>
        /// <param name="iNumThreads"></param>
        /// <returns></returns>
        int MySQLSelectPlusUpdate(int iNumRegistries, int iNumThreads);

        /// <summary>
        /// MySql Select plus update plus insertion use case.
        /// </summary>
        /// <param name="iNumRegistries"></param>
        /// <param name="iNumThreads"></param>
        /// <returns></returns>
        int MySQLSelectPlusUpdatePlusInsertion(int iNumRegistries, int iNumThreads);
    }
}
