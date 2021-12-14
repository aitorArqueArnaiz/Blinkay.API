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
        /// <returns></returns>
        void MySQLInsertion(int iNumRegistries);

        /// <summary>
        /// MySql select plus update use case.
        /// </summary>
        /// <param name="iNumRegistries"></param>
        /// <returns></returns>
        void MySQLSelectPlusUpdate(int iNumRegistries);

        /// <summary>
        /// MySql Select plus update plus insertion use case.
        /// </summary>
        /// <param name="iNumRegistries"></param>
        /// <returns></returns>
        void MySQLSelectPlusUpdatePlusInsertion(int iNumRegistries);
    }
}
