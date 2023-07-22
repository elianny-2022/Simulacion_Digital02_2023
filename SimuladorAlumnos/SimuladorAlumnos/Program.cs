// See https://aka.ms/new-console-template for more information
using System;

class SimuladorAlumnos
{
    static void Main()
    {
        Console.WriteLine("Ingrese la cantidad de alumnos que ingresan a primer año: ");
        int alumnosPrimerAnio = int.Parse(Console.ReadLine());

        // Variables para almacenar los porcentajes de alumnos que pasan, abandonan o repiten
        double porcentajePasados = 0.0;
        double porcentajeAbandonados = 0.0;
        double porcentajeRepetidos = 0.0;

        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine("Ingrese el porcentaje de alumnos que pasan del año " + i + " al siguiente: ");
            porcentajePasados = double.Parse(s: Console.ReadLine());

            Console.WriteLine("Ingrese el porcentaje de alumnos que abandonan del año " + i + ": ");
            porcentajeAbandonados = double.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el porcentaje de alumnos que repiten en el año " + i + ": ");
            porcentajeRepetidos = double.Parse(Console.ReadLine());

            int alumnosSiguienteAnio = (int)(alumnosPrimerAnio * porcentajePasados / 100);

            int abandonados = (int)(alumnosPrimerAnio * porcentajeAbandonados / 100);
            int repetidos = (int)(alumnosPrimerAnio * porcentajeRepetidos / 100);
            int aprobados = alumnosSiguienteAnio - repetidos;
            int reprobados = alumnosPrimerAnio - abandonados - aprobados;

            Console.WriteLine("Estadísticas del año " + i + ":");
            Console.WriteLine("Alumnos inscritos: " + alumnosPrimerAnio);
            Console.WriteLine("Alumnos aprobados: " + aprobados);
            Console.WriteLine("Alumnos reprobados: " + reprobados);
            Console.WriteLine("Alumnos abandonados: " + abandonados);

            alumnosPrimerAnio = alumnosSiguienteAnio; // Actualizar la cantidad de alumnos para el siguiente año
            Console.WriteLine("------------------------------------");
        }

        int aulasRequeridas = alumnosPrimerAnio; // La cantidad de alumnos en el último año determina las aulas requeridas
        Console.WriteLine("Aulas requeridas: " + aulasRequeridas);
    }
}
