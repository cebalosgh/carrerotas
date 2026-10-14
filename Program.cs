namespace carrerotas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LucesSalida();
            Paputitulo();

            int numcomp = 0;
            string papunombre = "";
            double papubalance = 0;
            double papuapuesta = 0;
            int papuopcion = 0;

            Registro(ref papunombre, ref papubalance);

            Console.WriteLine($"¡Hola {papunombre}! ");

            string[] competidor = new string[0];
            int[] numero = new int[0];

            competidor = PapuCargarCompetidores(ref numero, ref numcomp, papuopcion);

            MenuPrincipal(papuopcion, numcomp, competidor, numero, ref papubalance, ref papuapuesta, papunombre);
        }
        
        static void Paputitulo()
        {
            string paputitulo = "=================================";
            string paputitulo1 = "=     CARREROTAS FORMULA 1      =";
            string paputitulo2 = "=================================";

            Console.Clear();
            Console.WriteLine(paputitulo.PadLeft((Console.WindowWidth + paputitulo.Length) / 2));
            Console.WriteLine(paputitulo1.PadLeft((Console.WindowWidth + paputitulo1.Length) / 2));
            Console.WriteLine(paputitulo2.PadLeft((Console.WindowWidth + paputitulo2.Length) / 2));

        }

        static void LucesSalida()
{
    int luces = 5;
    int margen = (Console.WindowWidth - luces * 4) / 2;
    
    for (int i = 1; i <= luces; i++)
    {
        Console.Write("\r" + new string(' ', margen));
        for (int j = 0; j < luces; j++)
        {
            if (j < i)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("(O) ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("(O) ");
            }
        }
        Thread.Sleep(900);
    }

    Thread.Sleep(1200); 

    Console.Write("\r" + new string(' ', margen));
    Console.ForegroundColor = ConsoleColor.Green;
    for (int j = 0; j < luces; j++)
    {
        Console.Write("(O) ");
    }

    Console.ResetColor();
    Console.WriteLine();
}
        static void Registro(ref string papunombre, ref double papubalance)
        {
            Console.WriteLine("¿Cuál es tu nombre? ");
            papunombre = Console.ReadLine();
            do
            {
                Console.WriteLine("Ingresa el monto de tu balance $ (k): ");
                double.TryParse(Console.ReadLine(), out papubalance);
            } while (papubalance <= 0);
        }
        
        static string[] PapuCargarCompetidores(ref int[] numero, ref int numcomp, int papuopcion)
        {
            Paputitulo();
            Console.WriteLine("\n===== CARGAR COMPETIDORES =====");
            string[] papuopciones = new string[] { "Cargar competidores manualmente", "Cargar competidores aleatoriamente" };
            papuopcion = Menu(papuopciones);

            do
            {
                Console.WriteLine("¿Cuántos competidores van a participar en la carrera? (mínimo 2)");
                int.TryParse(Console.ReadLine(), out numcomp);
            } while (numcomp < 2);

            string[] competidor = new string[numcomp];
            numero = new int[numcomp];

            if (papuopcion == 1)
            {
                CargarCompetidoresManualmente(competidor, numero, numcomp);
            }
            else if(papuopcion == 2)
            {
                CargarCompetidoresAlt(ref competidor, ref numero);
            }

            return competidor;
        }
        static void CargarCompetidoresManualmente(string[] competidor, int[] numero, int numcomp)
        {
            for (int i = 0; i < numcomp; i++)
            {
                Console.WriteLine($"\nIngresa el nombre del competidor {i + 1}:");
                competidor[i] = Console.ReadLine();

                int numerillo;
                bool esnumero;
                do
                {
                    Console.WriteLine($"Ingresa el número del competidor {i + 1}");
                    esnumero = int.TryParse(Console.ReadLine(), out numero[i]);
                    numerillo = 0;

                    if (!esnumero || numero[i] <= 0)
                    {
                        esnumero = false;
                        Print("Intenta con numeros mayores a 0 y sin letras, porfavor", 'r');
                    }
                    else
                    {
                        for (int a = 0; a < i; a++)
                        {
                            if (numero[a] == numero[i])
                            {
                                numerillo++;
                            }
                        }

                        if (numerillo > 0)
                        {
                            Print("Ese número ya lo tiene otro competidor, elige otro.", 'r');
                        }
                    }
                } while (!esnumero || numerillo > 0);
            }
        }

        static void CargarCompetidoresAlt(ref string[] competidor, ref int[] numero)
        {
            Random CargarCompetidoresAlt = new Random();
            for (int i = 0; i < competidor.Length; i++)
            {
                int nombresillo;
                do
                {
                    char let1 = (char)('A' + CargarCompetidoresAlt.Next(0, 26));
                    char let2 = (char)('A' + CargarCompetidoresAlt.Next(0, 26));
                    char let3 = (char)('A' + CargarCompetidoresAlt.Next(0, 26));
                    competidor[i] = $"{let1}{let2}{let3}";
                    numero[i] = CargarCompetidoresAlt.Next(1, 100);
                    nombresillo = 0;
                    for (int a = 0; a < i; a++)
                    {
                        if (numero[a] == numero[i] || competidor[a] == competidor[i])
                        {
                            nombresillo++;
                        }
                    }

                } while (nombresillo > 0);
            }
        }

        static void MostrarCompetidores(string[] competidor, int[] numero)
        {
            Console.WriteLine("\n===== COMPETIDORES =====");
            for (int i = 0; i < competidor.Length; i++)
            {
                Console.WriteLine($"#{numero[i]} - {competidor[i]}");
            }
        }

        static void MenuPrincipal(int papuopcion, int numcomp, string[] competidor, int[] numero, ref double papubalance, ref double papuapuesta, string papunombre)
        {
            Paputitulo();
            Console.WriteLine("\n===== MENÚ =====");
            string[] papuopciones = new string[] { "Ver menú de competidores", "Ir a la pista", "Agregar balance", "Salir" };
            papuopcion = Menu(papuopciones);

            if (papuopcion == 1)
            {
                VerCompetidores(ref competidor, ref numero, papuopcion, ref numcomp, ref papubalance, ref papuapuesta, papunombre);
            }
            else if (papuopcion == 2)
            {
                IrPista(competidor, numero, papuopcion, numcomp, ref papubalance, ref papuapuesta, papunombre);
            }
            else if (papuopcion == 3)
            {
                double monto = 0;
                do
                {
                    Console.WriteLine("¿Qué monto deseas agregarle a tu balance?");
                    double.TryParse(Console.ReadLine(), out monto);
                } while (monto <= 0);
                papubalance += monto;

                Console.WriteLine($"Tu balance es de ${papubalance}k");
                Console.WriteLine("Presiona <enter> para regresar");
                Console.ReadKey();
                MenuPrincipal(papuopcion, numcomp, competidor, numero, ref papubalance, ref papuapuesta, papunombre);
            }
            else if (papuopcion == 4)
            {
                Console.WriteLine("¡Gracias por participar en las carrerotas fantásticas F1!");
            }
        }
        static void VerCompetidores(ref string[] competidor, ref int[] numero, int papuopcion, ref int numcomp, ref double papubalance, ref double papuapuesta, string papunombre)
        {
            Paputitulo();
            Console.WriteLine("\n===== VER MENÚ DE COMPETIDORES =====");
            string[] papuopciones = new string[] { "Recargar lista de competidores", "Ver lista de competidores", "Regresar" };
            papuopcion = Menu(papuopciones);

            if (papuopcion == 1)
            {
                competidor = PapuCargarCompetidores(ref numero, ref numcomp, papuopcion);
                VerCompetidores(ref competidor, ref numero, papuopcion, ref numcomp, ref papubalance, ref papuapuesta, papunombre);
            }
            else if (papuopcion == 2)
            {
                MostrarCompetidores(competidor, numero);
                Console.WriteLine("Presiona <enter> para regresar");
                Console.ReadKey();
                MenuPrincipal(papuopcion, numcomp, competidor, numero, ref papubalance, ref papuapuesta, papunombre);
            }
            else if (papuopcion == 3)
            {
                MenuPrincipal(papuopcion, numcomp, competidor, numero, ref papubalance, ref papuapuesta, papunombre);
            }
        }

        static void IrPista(string[] competidor, int[] numero, int papuopcion, int numcomp, ref double papubalance, ref double papuapuesta, string papunombre)
        {
            Paputitulo();
            Console.WriteLine("\n===== BIENVENIDO A LA PISTA =====");
            string[] papuopciones = new string[] { "Competir", "Espectar", "Regresar" };
            papuopcion = Menu(papuopciones);

            if (papuopcion == 1)
            {
                Competir(ref papubalance, papuopcion, numcomp, competidor, numero, ref papuapuesta, papunombre);
            }
            else if (papuopcion == 2)
            {
                Espectar(ref papubalance, papuopcion, numcomp, competidor, numero, ref papuapuesta, papunombre);
            }
            else if (papuopcion == 3)
            {
                MenuPrincipal(papuopcion, numcomp, competidor, numero, ref papubalance, ref papuapuesta, papunombre);
            }
        }

        static void Competir(ref double papubalance, int papuopcion, int numcomp, string[] competidor, int[] numero, ref double papuapuesta, string papunombre)
        {
            Console.WriteLine("La entrada cuesta $1k. ¿Deseas competir? (si/no)");
            string respuesta = Console.ReadLine().ToLower();
            if (respuesta == "si")
            {
                if (papubalance < 1)
                {
                    Print("Saldo insuficiente. :(", 'r');
                    Console.WriteLine("Te invitamos a aumentar el monto de tu balance.");
                    Console.ReadKey();
                    MenuPrincipal(papuopcion, numcomp, competidor, numero, ref papubalance, ref papuapuesta, papunombre);
                }
                else
                {
                    papubalance -= 1;
                    SimularCarrera(competidor, numero, papuopcion, numcomp, ref papubalance, ref papuapuesta, papunombre, true, false, 0, 0);
                }
            }
            else if (respuesta == "no")
            {
                Console.WriteLine("Te regresaremos al menú cliente inapetente :/");
                Console.ReadKey();
                MenuPrincipal(papuopcion, numcomp, competidor, numero, ref papubalance, ref papuapuesta, papunombre);
            }
            else
            {
                Print("Opción no válida, escribe si o no.", 'r');
                Competir(ref papubalance, papuopcion, numcomp, competidor, numero, ref papuapuesta, papunombre);
            }
        }

        static void Espectar(ref double papubalance, int papuopcion, int numcomp, string[] competidor, int[] numero, ref double papuapuesta, string papunombre)
        {

            string respuesta = "";
            do
            {
                Console.WriteLine("¿Quieras apostar?");
                respuesta = Console.ReadLine().ToLower();
            } while (respuesta != "si" && respuesta != "no");

            if (respuesta == "si")
            {

                if (papubalance <= 0)
                {
                    Print("No tienes saldo para apostar :( pero puedes ver la carrera", 'r');
                    Console.WriteLine("Presiona <enter> para continuar");
                    Console.ReadKey();
                    SimularCarrera(competidor, numero, papuopcion, numcomp, ref papubalance, ref papuapuesta, papunombre, false, false, 0, 0);
                }
                else
                {
                    Apostar(ref papubalance, papuopcion, numcomp, competidor, numero, ref papuapuesta, papunombre);
                }
            }
            else
            {

                SimularCarrera(competidor, numero, papuopcion, numcomp, ref papubalance, ref papuapuesta, papunombre, false, false, 0, 0);
            }
        }
        static void Apostar(ref double papubalance, int papuopcion, int numcomp, string[] competidor, int[] numero, ref double papuapuesta, string papunombre)
        {
            MostrarCompetidores(competidor, numero);
            Console.WriteLine("Escribe el número del competidor por el cual apuestas: ");
            int.TryParse(Console.ReadLine(), out int numapuesta);
            bool encontrado = false;

            for (int i = 0; i < numero.Length; i++)
            {
                if (numero[i] == numapuesta)
                {
                    string respuesta = "";

                    do
                    {
                        Console.WriteLine("¿Estás seguro? (si/ no)");
                        respuesta = Console.ReadLine().ToLower();
                    } while (respuesta != "si" && respuesta != "no");

                    if (respuesta == "si")
                    {

                        do
                        {
                            Console.WriteLine("¿Cuánto quieres apostar?");
                            Console.WriteLine($"Balance: ${papubalance}k");
                            double.TryParse(Console.ReadLine(), out papuapuesta);

                            if (papuapuesta <= 0 || papuapuesta > papubalance)
                            {
                                Print("Apuesta no válida, tiene que ser mayor a 0 y no pasarte de tu balance", 'r');
                            }
                        } while (papuapuesta <= 0 || papuapuesta > papubalance);
                        
                        int papuposicion = 0;
                        string respuestilla = "";
                        do
                        {
                            do
                            {
                                Console.WriteLine($"Escribe la posición en la cual debe llegar (max: {numcomp}):");
                                int.TryParse(Console.ReadLine(), out papuposicion);
                            } while (papuposicion < 1 || papuposicion > numcomp);

                            do
                            {
                                Console.WriteLine("¿Estás seguro? (si/ no)");
                                respuestilla = Console.ReadLine().ToLower();
                            } while (respuestilla != "si" && respuestilla != "no");
                        } while (respuestilla == "no");
                        
                        papubalance -= papuapuesta;
                        SimularCarrera(competidor, numero, papuopcion, numcomp, ref papubalance, ref papuapuesta, papunombre, false, true, numapuesta, papuposicion);
                    }
                    else if (respuesta == "no")
                    {
                        Console.WriteLine("No seas tibio, continúa apostando :/");
                        Apostar(ref papubalance, papuopcion, numcomp, competidor, numero, ref papuapuesta, papunombre);
                    }


                    encontrado = true;
                }
            }
            if (encontrado == false)
            {
                Print("El número por el que quieres apostar no existe.\n", 'r');
                Apostar(ref papubalance, papuopcion, numcomp, competidor, numero, ref papuapuesta, papunombre);
            }
        }

        static void SimularCarrera(string[] competidor, int[] numero, int papuopcion, int numcomp, ref double papubalance, ref double papuapuesta, string papunombre, bool papucompite, bool papuaposto, int numapuesta, int papuposicion)
        {
            Random papurandom = new Random();

            int totalcorredores = numcomp;
            if (papucompite)
            {
                totalcorredores = numcomp + 1;
            }

            string[] corredor = new string[totalcorredores];
            int[] numcorredor = new int[totalcorredores];
            int[] avance = new int[totalcorredores];
            int[] lugar = new int[totalcorredores];

            for (int i = 0; i < numcomp; i++)
            {
                corredor[i] = competidor[i];
                numcorredor[i] = numero[i];
            }

            if (papucompite)
            {
                corredor[totalcorredores - 1] = papunombre;
                numcorredor[totalcorredores - 1] = 0;
            }

            int meta = 50;
            int siguientelugar = 1;
            int terminadillos = 0;
            
            Console.Clear();
            LucesSalida();

            do
            {
                for (int i = 0; i < totalcorredores; i++)
                {
                    if (lugar[i] == 0)
                    {
                        if (papurandom.Next(0, 100) < 3)
                        {
                            lugar[i] = -1;
                            terminadillos++;
                        }
                        else
                        {
                            avance[i] += papurandom.Next(3, 12);
                            if (avance[i] >= meta)
                            {
                                avance[i] = meta;
                                lugar[i] = siguientelugar;
                                siguientelugar++;
                                terminadillos++;
                            }
                        }
                    }
                }

                Paputitulo();
                Console.WriteLine("\n===== SIMULANDO PAPUCARRERA =====");
                for (int i = 0; i < totalcorredores; i++)
                {
                    string numerito = $"{numcorredor[i]}";
                    if (numcorredor[i] < 10)
                    {
                        numerito = "0" + numerito;
                    }

                    string barrita = "";
                    for (int a = 0; a < avance[i]; a++)
                    {
                        barrita += ">";
                    }

                    string resultadillo = "";
                    if (lugar[i] == -1)
                    {
                        resultadillo = " DNF";
                    }
                    else if (lugar[i] > 0)
                    {
                        resultadillo = $" {lugar[i]}";
                    }

                    string alineado = $"{numerito} - {corredor[i],-5}";
                    Console.WriteLine($"{alineado} |{barrita}{resultadillo}");
                }
                Console.WriteLine("Presiona <enter> para continuar");
                Console.ReadKey();
            } while (terminadillos < totalcorredores);

            if (papucompite)
            {
                int milugar = lugar[totalcorredores - 1];
                if (milugar == -1)
                {
                    Print("\nTuviste DNF, no ganaste nada :(", 'r');
                }
                else
                {
                    double premio = totalcorredores * 1000;
                    premio = premio / (milugar * 2);
                    papubalance += premio / 1000;
                    Print($"\n¡Has terminado {milugar}!", 'v');
                    Print($"Ganaste ${premio} que se sumarán a tu cuenta", 'v');
                }
            }

            if (papuaposto)
            {
                for (int i = 0; i < numcomp; i++)
                {
                    if (numcorredor[i] == numapuesta)
                    {
                        if (lugar[i] == -1)
                        {
                            Print($"\nEl competidor {corredor[i]} tuvo DNF", 'r');
                        }
                        else
                        {
                            Print($"\nEl competidor {corredor[i]} terminó {lugar[i]}º", 'a');
                        }

                        if (lugar[i] == papuposicion)
                        {
                            double ganancia = ((papuapuesta * 2) / numcomp) + papuapuesta;
                            papubalance += ganancia;
                            Print($"¡Le atinaste! Ganaste ${ganancia}k", 'v');
                        }
                        else
                        {
                            Print($"Perdiste tu apuesta de ${papuapuesta}k :(", 'r');
                        }
                    }
                }
                papuapuesta = 0;
            }

            Console.WriteLine($"Tu balance es de ${papubalance}k");
            Console.WriteLine("Presiona <enter> para regresar al menú");
            Console.ReadKey();
            MenuPrincipal(papuopcion, numcomp, competidor, numero, ref papubalance, ref papuapuesta, papunombre);
        }
        
        static void Print(string msg, char color)
        {
            if (color == 'r')
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (color == 'v')
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (color == 'a')
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            Console.WriteLine(msg);
            Console.ResetColor();
        }
        
        static int Menu(string[] opciones)
        {
            int papuopcion = 0;
            bool esnumero;
            do
            {
                for (int i = 0; i < opciones.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {opciones[i]}");
                }
                Console.WriteLine("Elige una opción: ");
                esnumero = int.TryParse(Console.ReadLine(), out papuopcion);

                if (!esnumero || papuopcion < 1 || papuopcion > opciones.Length)
                {
                    Print("Opción no válida, intente otra vez.", 'r');
                }
            } while (!esnumero || papuopcion < 1 || papuopcion > opciones.Length);

            return papuopcion;
        }
    }
}

