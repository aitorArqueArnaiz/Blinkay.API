# El punto de entrada ser�a una Rest API. 

# A�adiremos los siguientes m�todos p�blicos:

    - int MySQLInsertion (int iNumRegistries, int iNumThreads)
    - int MySQLSelectPlusUpdate (int iNumRegistries, int iNumThreads)
    - int MySQLSelectPlusUpdatePlusInsertion (int iNumRegistries, int iNumThreads)
    - int PGInsertion (int iNumRegistries, int iNumThreads)
    - int PGSelectPlusUpdate (int iNumRegistries, int iNumThreads)
    - int PGSelectPlusUpdatePlusInsertion (int iNumRegistries, int iNumThreads)

 - Cada uno de los m�todos pondr� en marcha iNumThreads threads y cada thread realizar� iNumRegistries iteraciones. Cada m�todo tendr� que sincronizarse con el fin de todos los threads y devolver como resultado el n�mero de milisegundos total de ejecuci�n.

 - Las distintas pruebas se realizar�n sobre una tabla con dos campos, uno entero que ser� Primary key y que tendr� una secuencia para la generaci�n su valor y un string.

    - Las pruebas Insertion insertar�n un registro con un cadena aleatoria para el string
    - Las pruebas SelectPlusUpdate, acceder�n a un registro aleatorio a trav�s de su identificador, y a continuaci�n actualizar�n la cadena de ese registro con un valor nuevamente aleatorio.
    - Las pruebas SelectPlusUpdatePlusInsertion simplemente son una concatenaci�n de las dos anteriores.
    - Cada iteraci�n se realizar� dentro de una transacci�n.