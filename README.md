1) El punto de entrada sería una Rest API. 

2) Añadiremos los siguientes métodos públicos:

    a) int MySQLInsertion (int iNumRegistries, int iNumThreads)
    b) int MySQLSelectPlusUpdate (int iNumRegistries, int iNumThreads)
    c) int MySQLSelectPlusUpdatePlusInsertion (int iNumRegistries, int iNumThreads)
    d) int PGInsertion (int iNumRegistries, int iNumThreads)
    e) int PGSelectPlusUpdate (int iNumRegistries, int iNumThreads)
    f)  int PGSelectPlusUpdatePlusInsertion (int iNumRegistries, int iNumThreads)

3) Cada uno de los métodos pondrá en marcha iNumThreads threads y cada thread realizará iNumRegistries iteraciones. 
    Cada método tendrá que sincronizarse con el fin de todos los threads y devolver como resultado el número de milisegundos total de ejecución.

4) Las distintas pruebas se realizarán sobre una tabla con dos campos, uno entero que será Primary key y que tendrá una secuencia para la generación su valor y un string.

5) Las pruebas Insertion insertarán un registro con un cadena aleatoria para el string
6) Las pruebas SelectPlusUpdate, accederán a un registro aleatorio a través de su identificador, y a continuación actualizarán la cadena de ese registro con un valor nuevamente aleatorio.
7) Las pruebas SelectPlusUpdatePlusInsertion simplemente son una concatenación de las dos anteriores.
8) Cada iteración se realizará dentro de una transacción.