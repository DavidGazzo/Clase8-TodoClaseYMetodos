//Ejercicio

//Crear un programa que cumpla con los siguientes pasos

//1) Crear una matriz de dos dimensiones de tipo int llamada numeros,
//2) Determinar el tamaño de cada dimansion (fila, columnas) mediante valores ingresados por pantalla
//3) Declarar un vector de tipo double llamado promedios
//4) Recorrer la matriz para su carga con elementos de tipo int
//5) Recorrer la matriz para mostrar cada valor de la matriz
//6) Calcular el promedio de cada columna y asignarlo a la posicion correspondiente dentro del vector promedios
//7) Mostrar los promedios recorriendo el vector promedios


class Matriz
{
    static void Main()
    {
        string leyenda = "*  Actividad Clase 8 - Matriz bidimensional  *";
        Presentacion(leyenda);  // Presenta la acción siguiente
        // Defino e inicializo variables
        Presentacion("*           DIMENSIONE LA MATRIZ             *");
        int cantFilas = 0;
        int cantColumnas = 0;

        cantColumnas = DimensionoMatriz(cantColumnas, "Columnas");  // Dimensiona Columnas

        cantFilas = DimensionoMatriz(cantFilas,"Filas");        // Dimensiona Filas        

        // Defino matriz y vector
        int[,] numeros = new int[cantFilas, cantColumnas];
        double[] promedios = new double[cantColumnas];

        Console.Clear();
        Presentacion(leyenda);

        numeros = CargoMatriz(cantFilas,cantColumnas, numeros); // Carga valores en matriz numeros        

        Console.Clear();
        Presentacion(leyenda);

        promedios = MuestroValores(cantFilas, cantColumnas,numeros,promedios); // Imprime en pantalla valores de matriz numeros
                                                                                // y devuelve el promedio de cada columna
        MuestroPromedios(promedios);   // Imprime en pantalla los promedios de cada columna
    }
    static void Presentacion(string leyenda)
    {
        // Imprimir cartel de Presentacion
        
        int largoLeyenda = leyenda.Length;
        int vueltas = 0;

        while (vueltas < 2)
        {
            for (int i = 0; i < largoLeyenda; i++)
            {
                Console.Write("*"); // Imprime lineas de caracteres arriba y abajo de leyenda
            }
            Console.Write("\n");

            vueltas++;

            if (vueltas == 1)
            {
                Console.WriteLine(leyenda);
            }

        }
    }
    static int DimensionoMatriz(int dimension, string texto)
    {
        bool esNumero = true;   // True para entra en bucle

        // Bucle itera hasta comrpobar un ingreso numérico
        while (esNumero)
        {
            // Ingreso nro de filasen 1er llamado y de columnas en el 2do llamado
            Console.Write($"\tIngrese cantidad de {texto}: ");
            string cantidadFilas = (Console.ReadLine());
            esNumero = ControlErrores(cantidadFilas);   //envía el string ingresado a control de errores
            if (esNumero)
            {
                dimension = int.Parse(cantidadFilas);   // Si es número convierte a enteros
                esNumero = false;   // Para salir del bucle
            }
            else
            {
                esNumero = true;   // Para permanecer en el bucle
            }
        }
        return dimension;
    }
    static int[,] CargoMatriz(int cantFilas, int cantColumnas, int[,] numeros)
    {
        
        Presentacion("*               CARGAR DATOS                 *");
        bool esNumero = true;
        // Ingresa valores a la matriz
        string ingreso;
        for (int columna = 0; columna < cantColumnas; columna++)    // No funciona GatLength ni GetUpperLength
        {
            Console.WriteLine($"      Ingrese datos para la columna {columna + 1}");
            for (int fila = 0; fila < cantFilas; fila++)
            {
                esNumero = true;    // True para entra en bucle
                while (esNumero)
                {
                    Console.Write($"\t   Ingrese el numero {fila + 1}: ");
                    ingreso = Console.ReadLine();
                    if (ControlErrores(ingreso))
                    {
                        //numeros[fila, columna] = int.Parse(ingreso);
                        numeros[fila, columna] = int.Parse(ingreso);
                        esNumero = false;   // Para salir del bucle
                    }
                    else
                    {
                        esNumero = true;
                    }
                }
            }
            Console.WriteLine("\n----------------------------------------------\n");
        }
        return numeros;
    }
    static double[] MuestroValores(int cantFilas, int cantColumnas, int[,] numeros, double[] promedios)
    {
        Presentacion("*                 VALORES                    *");

        // Lee e imprime valores de la matriz en pantalla
        // y suma valores para calcular promedio
        for (int columna = 0; columna < cantColumnas; columna++)    // No funciona GatLength ni GetUpperLength
        {
            double acumulador = 0; // Suma valores de cada columna para el promedio
            Console.WriteLine($"\t   Valores de la columna {columna + 1}: ");
            for (int fila = 0; fila < cantFilas; fila++)
            {
                Console.Write($"\t\t Fila {fila + 1}: ");
                Console.WriteLine(numeros[fila, columna]);
                acumulador += numeros[fila, columna];
            }
            promedios[columna] = acumulador / cantColumnas;
        }
        return promedios;
    }
    static void MuestroPromedios(double[] promedios)
    {
        Presentacion("*                PROMEDIOS                   *");

        // Imprime promedios 
        for (int i = 0; i < promedios.Length; i++)
        {
            Console.WriteLine($"\t   Promedio columna {i + 1}: {promedios[i]}");
        }
    }
        //Console.WriteLine("\n------------------------------------\n");
        
        

    // Método controla errores de ingreso por teclado
    // Solo permite números.
    // Si se ingresaron números devuelve TRUE, de lo contrario FALSE
    static bool ControlErrores(string datoIngresado)
    {
        int none;
        bool esNumero = Int32.TryParse(datoIngresado, out none);
        if (esNumero)
        {
            return true;
        }
        else
        {
            Console.WriteLine("Sólo se permiten números. Intente nuevamente...");
            return false;
        }
    }
}