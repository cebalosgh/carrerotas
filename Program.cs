namespace ConsoleApp5;

class Program
{
    static void Main(string[] args)
    {
        string paputitulo = "=================================";
        string paputitulo1 = "=     CARREROTAS FORMULA 1      =";
        string paputitulo2 = "=================================";

        int numcomp = 0;
        string papunombre = "";
        double papubalance = 0;
        int papuopcion = 0;

        Console.WriteLine(paputitulo.PadLeft((Console.WindowWidth + paputitulo.Length) / 2));
        Console.WriteLine(paputitulo1.PadLeft((Console.WindowWidth + paputitulo1.Length) / 2));
        Console.WriteLine(paputitulo2.PadLeft((Console.WindowWidth + paputitulo2.Length) / 2));

        Registro(ref papunombre, ref papubalance);
        Console.WriteLine($"¡Hola {papunombre}! ");

        do
        {
            Console.WriteLine("\n===== MENÚ DE OPCIONES =====");
            Console.WriteLine("1. Cargar competidores manualmente");
            Console.WriteLine("2. Cargar competidores aleatoriamente");
            Console.WriteLine("Elige una opción: ");
            int.TryParse(Console.ReadLine(), out papuopcion);
        } while (papuopcion != 1 && papuopcion != 2);

        do
        {
            Console.WriteLine("¿Cuántos competidores van a participar en la carrera? (mínimo 2)");
            int.TryParse(Console.ReadLine(), out numcomp);
        } while (numcomp < 2);


        string[] competidor = new string[numcomp];
        int[] numero = new int[numcomp];

        if (papuopcion == 1)
        {
            CargarCompetidoresManualmente(competidor, numero, numcomp);
        }
        else
        {
            CargarCompetidoresAlt(ref competidor, ref numero);
        }

        MostrarCompetidores(competidor, numero);
        Console.WriteLine("Presiona <enter> para regresar e irnos a la pista");
        Console.ReadKey();
        Console.Clear();}
    
    }

    static void Registro(ref string papunombre, ref double papubalance)
    {
        Console.WriteLine("¿Cuál es tu nombre?: ");
        papunombre = Console.ReadLine();
        do
        {
            Console.WriteLine("Ingresa el monto de tu balance: ");
            double.TryParse(Console.ReadLine(), out papubalance);
        } while (papubalance <= 0);
    }

    static void CargarCompetidoresManualmente(string[] competidor, int[] numero, int numcomp)
    {
        for (int i = 0; i < numcomp; i++)
        {
            Console.WriteLine($"\nIngresa el nombre del competidor {i + 1}:");
            competidor[i] = Console.ReadLine();

            int numerillo;
            do
            {
                Console.WriteLine($"Ingresa el número del competidor {i + 1}");
                int.TryParse(Console.ReadLine(), out numero[i]);
                numerillo = 0;
                for (int a = 0; a < i; a++)
                {
                    if (numero[a] == numero[i])
                    {
                        numerillo++;
                    }
                }
                if (numerillo > 0)
                {
                    Console.WriteLine("Ese número ya lo tiene otro competidor, elige otro.");
                }
            } while (numerillo > 0);
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
