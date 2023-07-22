using System;
using System.Threading;

class Estufa
{
    static void Main()
    {
        Console.WriteLine("Estufa");
        Console.WriteLine("------");

        // Definir los tiempos de cocción para cada producto
        int tiempoPez = 10;    // en minutos
        int tiempoRes = 20;
        int tiempoCerdo = 30;
        int tiempoPollo = 15;

        // Definir el suministro de combustible para cada tipo
        int suministroMadera = 1000;     // en k/c/h
        int suministroGas = 500;
        int suministroHoja = 800;
        int suministroElectricidad = 1200;
        int suministroCarbonMineral = 2000;

        // Inicializar variables
        int tiempoTotalCoccion = 0;
        int velocidad = 0;
        bool terminado = false;
        string combustible = "";

        // Ciclo principal de la simulación
        while (!terminado)
        {
            Console.WriteLine();
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Aumentar velocidad");
            Console.WriteLine("2. Disminuir velocidad");
            Console.WriteLine("3. Seleccionar combustible");
            Console.WriteLine("4. Apagar estufa");

            // Leer la opción seleccionada
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    if (velocidad < 4)
                        velocidad++;
                    break;
                case "2":
                    if (velocidad > 1)
                        velocidad--;
                    break;
                case "3":
                    Console.WriteLine();
                    Console.WriteLine("Seleccione el combustible:");
                    Console.WriteLine("1. Madera");
                    Console.WriteLine("2. Gas");
                    Console.WriteLine("3. Hoja");
                    Console.WriteLine("4. Electricidad");
                    Console.WriteLine("5. Carbón mineral");

                    string opcionCombustible = Console.ReadLine();

                    switch (opcionCombustible)
                    {
                        case "1":
                            combustible = "Madera";
                            break;
                        case "2":
                            combustible = "Gas";
                            break;
                        case "3":
                            combustible = "Hoja";
                            break;
                        case "4":
                            combustible = "Electricidad";
                            break;
                        case "5":
                            combustible = "Carbón mineral";
                            break;
                        default:
                            Console.WriteLine("Opción de combustible inválida. Intente nuevamente.");
                            continue;
                    }

                    break;
                case "4":
                    terminado = true;
                    break;
                default:
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                    continue;
            }

            // Verificar si se apagó la estufa
            if (terminado)
                break;

            // Determinar el suministro de combustible según el combustible seleccionado y la velocidad
            int suministro = 0;
            switch (combustible)
            {
                case "Madera":
                    suministro = suministroMadera;
                    break;
                case "Gas":
                    suministro = suministroGas;
                    break;
                case "Hoja":
                    suministro = suministroHoja;
                    break;
                case "Electricidad":
                    suministro = suministroElectricidad;
                    break;
                case "Carbón mineral":
                    suministro = suministroCarbonMineral;
                    break;
            }

            // Calcular el tiempo de cocción para cada producto según la velocidad
            int tiempoCoccionPez = tiempoPez / velocidad;
            int tiempoCoccionRes = tiempoRes / velocidad;
            int tiempoCoccionCerdo = tiempoCerdo / velocidad;
            int tiempoCoccionPollo = tiempoPollo / velocidad;

            // Simular la cocción de los productos
            Console.WriteLine();
            Console.WriteLine("Cocinando...");
            Thread.Sleep(2000);  // Simulación de tiempo de cocción

            // Actualizar el suministro de combustible
            suministro -= velocidad * 100;

            // Actualizar el tiempo total de cocción
            tiempoTotalCoccion += velocidad;

            // Mostrar información actualizada
            Console.WriteLine();
            Console.WriteLine("Estado actual:");
            Console.WriteLine("Combustible seleccionado: {0}", combustible);
            Console.WriteLine("Suministro de combustible: {0} k/c/h", suministro);
            Console.WriteLine("Tiempo total de cocción: {0} minutos", tiempoTotalCoccion);

            // Verificar si se agotó el suministro de combustible
            if (suministro <= 0)
            {
                Console.WriteLine("¡Se agotó el suministro de combustible!");
                terminado = true;
            }
        }

        // Mostrar el tiempo total de cocción al final de la simulación
        Console.WriteLine();
        Console.WriteLine("Simulación terminada.");
        Console.WriteLine("Tiempo total de cocción: {0} minutos", tiempoTotalCoccion);
    }
}

