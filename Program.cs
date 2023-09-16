using System;

public class Program
{
    static int[] Tablero = new int[8]; //Decalaramo un array

    //funcion para imprimir tablero 
    static void PintarTablero()
    {
        Console.WriteLine();
        for (int fila = 0; fila < Tablero.Length; fila++)
        {
            for (int col = 0; col < Tablero.Length; col++)
            {
                if (Tablero[col] == fila)
                {
                    Console.Write("|* "); //Si hay una reina imprime *
                
                }
                else
                {
                    Console.Write("|. ");//Si no hay imprime un .}
               
                }
            }
            Console.WriteLine();
        }
        Console.ReadKey();//Esperar que presione una tecla
    }// Fin Pintar Tablero

    // Funcion que verifica si es seguro colocar una reina en una fila y columna
    static bool EsSeguro(int fila, int col)
    {
        for (int i = 0; i < col; i++)
        {
            // Verifica si hay una reina en la misma fila.
            if (Tablero[i] == fila)
            {
                return false;
            }

            // Calcula las diferencias entre filas y columnas.
            int filaDiferencia = Tablero[i] - fila;
            int columnaDiferencia = i - col;

            // Si las diferencias tienen el mismo signo, estan en la misma diagonal.
             if (filaDiferencia == columnaDiferencia || filaDiferencia == -columnaDiferencia)
             {
                 return false;
             }
        }
        return true;// Es seguro colocar una reina en esta posición
    }// Fin EsSeguro

    // Esta función coloca las reinas en el tablero de manera recursiva.
    static bool ColocarReinas(int col)
    {
        if (col >= Tablero.Length)
        {
            return true; // Todas las reinas fueron colocadas
        }

        for (int fila = 0; fila < Tablero.Length; fila++)
        {
            if (EsSeguro(fila,col))
            {
                Tablero[col] = fila; //  Colocar una reina en esta posición.
                if (ColocarReinas(col+1))
                {
                    return true; // Si se pueden colocar la demas reinas , devuelve true.
                }
                Tablero[col] = -1; // Retrocede si no es seguro y prueba otra posición
            }
        }

        return false; // No se ecnontró solución en esta rama
    }// Fin de Colocar Reinas

    // Iniciamos la Funcion Main
    public static void Main()
    {
        for (int i = 0; i < Tablero.Length; i++)
        {
            Tablero[i] = -1; // Inicializamos el tablero con los valores negativos
        }

        if (ColocarReinas(0))
        {
            Console.WriteLine("La solución encontrada: ");
            PintarTablero(); // Muestra la solución si se encontró una.
        }
        else
        {
            Console.WriteLine("No se encontro solución.");
        }

        Console.ReadKey();
    }
}   