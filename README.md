# El punto de entrada sería una Rest API. 

# Añadiremos los siguientes métodos públicos:

    - int MySQLInsertion (int iNumRegistries, int iNumThreads)
    - int MySQLSelectPlusUpdate (int iNumRegistries, int iNumThreads)
    - int MySQLSelectPlusUpdatePlusInsertion (int iNumRegistries, int iNumThreads)
    - int PGInsertion (int iNumRegistries, int iNumThreads)
    - int PGSelectPlusUpdate (int iNumRegistries, int iNumThreads)
    - int PGSelectPlusUpdatePlusInsertion (int iNumRegistries, int iNumThreads)

 - Cada uno de los métodos pondrá en marcha iNumThreads threads y cada thread realizará iNumRegistries iteraciones. Cada método tendrá que sincronizarse con el fin de todos los threads y devolver como resultado el número de milisegundos total de ejecución.

 - Las distintas pruebas se realizarán sobre una tabla con dos campos, uno entero que será Primary key y que tendrá una secuencia para la generación su valor y un string.

    - Las pruebas Insertion insertarán un registro con un cadena aleatoria para el string
    - Las pruebas SelectPlusUpdate, accederán a un registro aleatorio a través de su identificador, y a continuación actualizarán la cadena de ese registro con un valor nuevamente aleatorio.
    - Las pruebas SelectPlusUpdatePlusInsertion simplemente son una concatenación de las dos anteriores.
    - Cada iteración se realizará dentro de una transacción.