

namespace EvaluacionModeloNegocio
{
    class Program
    {
        static void Main(string[] args)
        {
            // Se define las preguntas y respuestas
            Dictionary<string, List<string>> preguntas = new Dictionary<string, List<string>>
            {
                { "¿Cuánto conocimiento tienes sobre el mercado objetivo?", new List<string> { "Ninguno", "Algo", "Mucho" } },
                { "¿Tienes experiencia en el área del negocio?", new List<string> { "Ninguna", "Poca", "Mucha" } },
                { "¿Tienes un plan de negocio sólido?", new List<string> { "No", "En desarrollo", "Sí" } },
                { "¿Tienes acceso a suficiente capital?", new List<string> { "No", "Quizás", "Sí" } },
                
            };

            // Aqui se almacena las variables y los puntos de cada pregunta
            Dictionary<string, int> puntos = new Dictionary<string, int>();
            int totalPreguntas = preguntas.Count;

        
            Console.WriteLine("Bienvenido/a a la Evaluación del Modelo de Negocio:");
            Console.WriteLine("Responde seleccionando el número de la opción que mejor te describa.\n");

            foreach (var pregunta in preguntas)
            {
                Console.WriteLine(pregunta.Key);
                for (int i = 0; i < pregunta.Value.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {pregunta.Value[i]}");
                }

                // En esta parte se obtiene la respuesta del usuario
                int respuesta;
                bool validInput = false;
                do
                {
                    Console.Write("Respuesta: ");
                    validInput = int.TryParse(Console.ReadLine(), out respuesta);
                    if (!validInput || respuesta < 1 || respuesta > pregunta.Value.Count)
                    {
                        Console.WriteLine("Respuesta inválida. Inténtalo nuevamente.");
                    }
                } while (!validInput || respuesta < 1 || respuesta > pregunta.Value.Count);

                // Se le asigna puntos por cada respuesta
                int puntosRespuesta = 0;
                switch (respuesta)
                {
                    case 1:
                        puntosRespuesta = 0;
                        break;
                    case 2:
                        puntosRespuesta = 1;
                        break;
                    case 3:
                        puntosRespuesta = 2;
                        break;
                }

                // Se van actualizando las respuestas
                string campo = pregunta.Key;
                puntos[campo] = puntosRespuesta;
                Console.WriteLine();
            }

            // Aqui se calcula los puntos
            int puntuacionTotal = 0;
            foreach (var punto in puntos)
            {
                puntuacionTotal += punto.Value;
            }

            //Se define si es factible, determinar si el modelo de negocio es factible
            bool esFactible = puntuacionTotal >= totalPreguntas; //La puntuación mínima para ser factible

          
            Console.WriteLine("Evaluación completada. Generando informe...\n");
            Console.WriteLine("RESULTADOS:");

            foreach (var punto in puntos)
            {
                string campo = punto.Key;
                int puntosRespuesta = punto.Value;

                Console.WriteLine($"{campo}: {puntosRespuesta}");
            }

            Console.WriteLine($"\nPuntuación Total: {puntuacionTotal}");
            Console.WriteLine("RESULTADO FINAL:");

            if (esFactible)
            {
                Console.WriteLine("¡Felicidades! Tu modelo de negocio parece ser factible.");
            }
            else
            {
                Console.WriteLine("Tu modelo de negocio necesita ser revisado y mejorado para ser factible.");
            }

            Console.WriteLine("\nGracias por realizar la Evaluación del Modelo de Negocio. ¡Hasta luego!");
        }
    }
}
