
namespace EvaluacionDiagnostica
{
    class Program
    {
        static void Main(string[] args)
        {
            // Aqui se define las preguntas y respuestas
            Dictionary<string, List<string>> preguntas = new Dictionary<string, List<string>>
            {
                { "¿Cómo te describirías en una situación social?", new List<string> { "Extrovertido/a", "Introvertido/a", "Timido/a" } },
                { "¿Cuál es tu nivel de empatía?", new List<string> { "Alto", "Moderado", "Bajo" } },
                { "¿Cómo te enfrentas a los problemas?", new List<string> { "Resolutivo/a", "Pensativo/a", "Evitativo/a" } },
                { "¿Cómo te sientes en situaciones de estrés?",  new List<string> { "Calmado/a y relajado/a",
                    "Ansioso/a pero puedo manejarlo", "Muy nervioso/a e incapaz de manejarlo" } },
                { "¿Cómo te enfrentas a los cambios inesperados en tu vida?",  new List<string> { "Los acepto fácilmente y me adapto rápidamente",
                    "Me toma tiempo, pero finalmente me adapto", "Me siento abrumado/a y me cuesta adaptarme" } },
                { "¿Cómo te consideras en cuanto a tu habilidad para tomar decisiones?", new List<string> { "Toma decisiones rápidamente y con confianza",
                    "Toma decisiones con precaución y reflexión", "Tiene dificultades para tomar decisiones y puede dudar mucho" } },
                {"¿Cómo manejas los conflictos con otras personas?", new List<string> {"Busco soluciones y trato de llegar a un acuerdo",
                    "Prefiero evitar conflictos siempre que sea posible","Me siento frustrado/a y puede que reaccione con ira"}},
            };

            // Se almacenan las variables en esta parte
            Dictionary<string, int> resultados = new Dictionary<string, int>();
            int totalPreguntas = preguntas.Count;
            List<string> resumenesParciales = new List<string>();


            Console.WriteLine("Bienvenido/a a la Evaluación Psicologica:");
            Console.WriteLine("***********************************************************************");
            Console.WriteLine("Responde seleccionando el número de la opción que mejor te describa.\n");
            Console.WriteLine("***********************************************************************");

            foreach (var pregunta in preguntas)
            {
                Console.WriteLine(pregunta.Key);
                for (int i = 0; i < pregunta.Value.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {pregunta.Value[i]}");
                }

                // Se obtiene la respuesta del usuario
                int respuesta;
                bool validInput = false;
                do
                {
                    Console.WriteLine("***********************************************************************");
                    Console.Write("Respuesta: ");
                    validInput = int.TryParse(Console.ReadLine(), out respuesta);
                    if (!validInput || respuesta < 1 || respuesta > pregunta.Value.Count)
                    {
                        Console.WriteLine("Respuesta inválida. Inténtalo nuevamente.");
                    }
                } while (!validInput || respuesta < 1 || respuesta > pregunta.Value.Count);

                // Se actualiza los datos
                string campo = pregunta.Key;
                resultados[campo] = respuesta;
                Console.WriteLine();

                string resumenRespuesta = ObtenerResumenPersonalidad(preguntas[campo][respuesta - 1]);
                resumenesParciales.Add(resumenRespuesta);
                //Console.WriteLine(resumenRespuesta);
            }

            // Se genera la evaluacion y se calcula el porcentaje en base a lo que el usurio ha respondido
             Console.WriteLine("***********************************************************************");
            Console.WriteLine("Evaluación completada. Generando informe...\n");
            Console.WriteLine("RESULTADOS Y PORCENTAJE:");

            foreach (var resultado in resultados)
            {
                string campo = resultado.Key;
                int respuesta = resultado.Value;

                // Aqui se calcula el porcentaje en función de la respuesta
                double porcentaje = 100 - (respuesta - 1) * 50;

                //Aqui aseguramos de que el porcentaje esté en el rango de 0 a 100
                porcentaje = Math.Max(0, Math.Min(100, porcentaje));

                Console.WriteLine( $"{campo}: {porcentaje}%");
            }
            Console.WriteLine("***********************************************************************");
            Console.WriteLine("\nRESUMEN COMPLETO DE LA EVALUACION PSICOLOGICA:");
            Console.WriteLine("***********************************************************************");
            Console.WriteLine("\n\nDe acuerdo a las preguntas seleccionada, este eres tu como persona en el ambito Psicologico: ");
            foreach (string resumen in resumenesParciales)
            {
                Console.WriteLine(resumen);
            }
            Console.WriteLine("\nGracias por realizar la Evaluación Psicologica. ¡Hasta luego!");
        }

        //Este es el método para obtener un resumen personalizado basado en una respuesta seleccionada por el usuario
        static string ObtenerResumenPersonalidad(string respuestaSeleccionada)
        {
            
            switch (respuestaSeleccionada)
            {
                
                case "Extrovertido/a":
                    return "*" + respuestaSeleccionada + ": Eres una persona extrovertida, disfrutas de la compañía de los demás y te sientes cómodo/a en situaciones sociales.";

                case "Introvertido/a":
                    return "*" + respuestaSeleccionada + ": Eres una persona introvertida, prefieres el tiempo a solas y te sientes recargado/a al estar en ambientes más tranquilos.";

                case "Timido/a":
                    return "*" + respuestaSeleccionada + ": Eres una persona timido/a, debes de trabajar en esta parte ya que en la vida se trata de socializar para que esto te ayude" +
                        "tanto en tu vida personal, social o hasta profesional, te invito a que salgas a conocer, hablar y asi poderte comunicar" +
                        ", tambien a ver videos o documentacion de como socializar y familiarizarte ante cualquier situacion social.";

                case "Alto":
                    return "*(Empatia)" + respuestaSeleccionada +  ": Eres una persona que tiene una gran empatia, siempre te pones a disposicion de los demas.";

                case "Moderado":
                    return "*(Empatia)" + respuestaSeleccionada +  ": Eres una persona que su empatia ayuda a crear relaciones sanas libres de conflictos.";

                case "Bajo":
                    return "*(Empatia)" + respuestaSeleccionada + ": Eres una persona con una empatia donde no te pones en el lugar del otro, debes trabajar mas en ese aspecto.";

                case "Resolutivo/a":
                    return "*" + respuestaSeleccionada +  ": Eres una persona que intenta resolver o cualquier asunto o problema con eficiencia, rapidez y determinacion.";

                case "Pensativo/a":
                    return "*" + respuestaSeleccionada + ": Eres una persona que piensa antes de afrontar ese problema, puede ser por dos razones:" +
                        " lo piensas porque quizas no sabes afrontar el problema o simplemente lo piensa para saber que hacer. ";
                case "Evitativo/a":
                    return "*" + respuestaSeleccionada + ": Puede ser que al enfrentar un problema seas una persona que evita el contacto fisico y emocional ante cualquier problema, " +
                        "algo no muy bueno a la hora de enfrentar algun problema, es bueno evitarlo pero cuando esta, hay que afrontarlo.";

                case "Calmado/a y relajado/a":
                    return "*" + respuestaSeleccionada + ": Eres una persona que sabe afrontar el estres, te invito a que sigas asi ante cualquier situacion de estres" +
                        " y busques algo que te guste y de entretenimiento para mejor resultado.";

                case "Ansioso/a pero puedo manejarlo":
                    return "*" + respuestaSeleccionada + ": Eres una persona que ante la situacion de estres siente temor o inquietud pero puedes manejarlo, te invito a que respires," +
                        " no piense en eso que te causo estres por unos minutos y aprender poco a poco a controlarlo.";

                case "Muy nervioso/a e incapaz de manejarlo":
                    return "*" + respuestaSeleccionada + ": Es bueno que al momento de presentar estres te traslades a un lugar tranquilo, mantener la calma y tratar de relajarse.";

                case "Los acepto fácilmente y me adapto rápidamente":
                    return "*" + respuestaSeleccionada + " : Eres una persona que esta lista para enfrentar cualquier tipo de situacion en tu vida," +
                        " es bueno tener este tipo de actitud al enfrentarse a un cambio inesperado en la vida.";

                case "Me toma tiempo, pero finalmente me adapto":
                    return "*" + respuestaSeleccionada + ": Si eres una persona que le toma tiempo a adaptarse a cualquier cambio en su vida inesperadamente," +
                        " no esta mal tomarnos el tiempo en afrontarlo, pero no esta de mas en afrontarlo con facilidad, trabaja un poco esa parte.";

                case "Me siento abrumado/a y me cuesta adaptarme":
                    return "*" + respuestaSeleccionada + ": Si te sientes abrumado/a o te cuesta adaptarte a los cambios, te invito a reflexionar sobre lo que podrias conseguir con este cambio," +
                        "y aprender aceptar que hay algunas situaciones que no podemos revertir, mas bien afrontarlas.";

                case "Toma decisiones rápidamente y con confianza":
                    return "*" + respuestaSeleccionada + ": No esta de mas en tomar desiciones rapidamente y con confianza, solo debes de saber" +
                        " cuales consecuencias puedes afrontar al tomar estas desiciones apresuaradas, ya que aveces debemos de tomar desiciones rapidamente.";

                case "Toma decisiones con precaución y reflexión":
                    return "*" + respuestaSeleccionada + ": Eres una persona que se toma muy en serio la toma de desiciones, las reflexionas y tomas precauciones a la hora de hacerlo," +
                        "pero a veces tenemos que tomar desiciones de vida o muerte, trabaja esa parte para tomar desiciones apresuradas.";

                case "Tiene dificultades para tomar decisiones y puede dudar mucho":
                    return "*" + respuestaSeleccionada + ": Eres una persona que le cuesta mucho tomar desiciones, debes de trabajar en ello para que cuando se presente esta situacion puedas manejarlo" +
                        "y puedas tomas desiciones con seguridad y confianza.";

                case "Busco soluciones y trato de llegar a un acuerdo":
                    return "*" + respuestaSeleccionada + "Eres una persona responsable por tus actos, siempre es bueno tratar de buscar la mejor"+
                     "solucion a todo y llegar a un acuerdo con todo respeto y claridad.";

                case"Prefiero evitar conflictos siempre que sea posible":
                   return "*" + respuestaSeleccionada + "Eres una persona que no eres conflictiva, aunque a veces llegan los problemas sin " +
                        "buscarlo, te invito que cuando llegue problemas asi, puedas manerjarlo con seguridad y llegar a un acuerdo.";

                case "Me siento frustrado/a y puede que reaccione con ira":
                  return "*" + respuestaSeleccionada + "Eres una persona que debe manejar la ira y la fustracion, casi siempre esto nos lleva"+
                        "a problemas mas fuerte y quizas sin solucion, es momento de trabajar en esto y mantener la calma a esta situacion y enfrentarla.";

                default:
                    return "No se pudo generar un resumen para esta respuesta.";
            }
        }
    }
 }


