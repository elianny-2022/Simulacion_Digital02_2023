
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Simulación de lanzamiento de dado");
        Console.WriteLine("---------------------------------");
        Console.WriteLine();

        Console.Write("Ingrese la cantidad de veces que se lanzará el dado: ");
        int cantidadLanzamientos = int.Parse(Console.ReadLine());

        Console.Write("Ingrese la cantidad de caras del dado: ");
        int cantidadCaras = int.Parse(Console.ReadLine());

        double[] probabilidades = new double[cantidadCaras];

        Console.WriteLine();
        Console.WriteLine("Ingrese las probabilidades para cada lado del dado:");

        for (int i = 0; i < cantidadCaras; i++)
        {
            Console.Write("Probabilidad para la cara {0}: ");
            probabilidades[i] = double.Parse(Console.ReadLine());
        }

        int[] resultados = new int[cantidadCaras];

        Console.WriteLine();
        Console.WriteLine("Lanzando el dado {0} veces...", cantidadLanzamientos);
        Console.WriteLine("------------------------------------");
        Console.WriteLine();

        Random random = new Random();

        for (int i = 0; i < cantidadLanzamientos; i++)
        {
            double randomValue = random.NextDouble();
            double cumulativeProbability = 0.0;

            for (int j = 0; j < cantidadCaras; j++)
            {
                cumulativeProbability += probabilidades[j];

                if (randomValue < cumulativeProbability)
                {
                    resultados[j]++;
                    break;
                }
            }
        }

        Console.WriteLine("Resultados de los lanzamientos:");

        for (int i = 0; i < cantidadCaras; i++)
        {
            Console.WriteLine("Cara {0}: {1} veces", i + 1, resultados[i]);
        }

        Console.WriteLine();

        int maximaFrecuencia = 0;
        int caraMasFrecuente = 0;

        for (int i = 0; i < cantidadCaras; i++)
        {
            if (resultados[i] > maximaFrecuencia)
            {
                maximaFrecuencia = resultados[i];
                caraMasFrecuente = i + 1;
            }
        }

        Console.WriteLine("La cara más frecuente fue la número {0}, con {1} veces", caraMasFrecuente, maximaFrecuencia);

        Console.ReadLine();
    }
}

