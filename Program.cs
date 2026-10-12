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
     double papuapuesta = 0;
     int papuopcion = 0;

     Console.WriteLine(paputitulo.PadLeft((Console.WindowWidth + paputitulo.Length) / 2));
     Console.WriteLine(paputitulo1.PadLeft((Console.WindowWidth + paputitulo1.Length) / 2));
     Console.WriteLine(paputitulo2.PadLeft((Console.WindowWidth + paputitulo2.Length) / 2));

     Registro(ref papunombre, ref papubalance);
     Console.WriteLine($"¡Hola {papunombre}! ");

     string[] competidor = new string[0];
     int[] numero = new int[0];

     PapuCargarCompetidores(ref competidor, ref numero, ref numcomp, papuopcion);

     MenuPrincipal(papuopcion, numcomp, competidor, numero, ref papubalance);
 }

 static void Registro(ref string papunombre, ref double papubalance)
 {
     Console.WriteLine("¿Cuál es tu nombre?: ");
     papunombre = Console.ReadLine();
     do
     {
         Console.WriteLine("Ingresa el monto de tu balance $ (k): ");
         double.TryParse(Console.ReadLine(), out papubalance);
     } while (papubalance <= 0);
 }

 static void PapuCargarCompetidores(ref string[] competidor, ref int[] numero, ref int numcomp, int papuopcion)
 {
     do
     {
         Console.Clear();
         Console.WriteLine("\n===== CARGAR COMPETIDORES =====");
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

     competidor = new string[numcomp];
     numero = new int[numcomp];

     if (papuopcion == 1)
     {
         CargarCompetidoresManualmente(competidor, numero, numcomp);
     }
     else
     {
         CargarCompetidoresAlt(ref competidor, ref numero);
     }
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
                 // Si escribieron letras o algo que no es un número válido
                 esnumero = false;
                 Console.WriteLine("Intenta con numeros mayores a 0 y sin letras, porfavor");
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
                     Console.WriteLine("Ese número ya lo tiene otro competidor, elige otro.");
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

 static void MenuPrincipal(int papuopcion, int numcomp, string[] competidor, int[] numero, ref double papubalance)
 {
     do
     {
         Console.Clear();
         Console.WriteLine("\n===== MENÚ =====");
         Console.WriteLine("1. Ver menú de competidores");
         Console.WriteLine("2. Ir a la pista");
         Console.WriteLine("3. Agregar balance");
         Console.WriteLine("4. Salir");
         int.TryParse(Console.ReadLine(), out papuopcion);
     } while (papuopcion != 1 && papuopcion != 2 && papuopcion != 3 && papuopcion != 4);

     if (papuopcion == 1)
     {
         VerCompetidores(ref competidor, ref numero, papuopcion, ref numcomp, ref papubalance);
     }
     else if (papuopcion == 2)
     {
         IrPista(competidor, numero, papuopcion, numcomp, ref papubalance);
     }
     else if (papuopcion == 3)
     {
         double monto = 0;
         do
         {
             Console.WriteLine("¿Qué monto deseas agregarle a tu balance?");
             double.TryParse(Console.ReadLine(), out monto);
             papubalance += monto;
         } while (monto > 0);

         Console.WriteLine($"Tu balance es de ${papubalance}k");
         MenuPrincipal(papuopcion, numcomp, competidor, numero, ref papubalance);
     }
     else if (papuopcion == 4)
     {
         Console.WriteLine("¡Gracias por participar en las carrerotas fantásticas F1!");
     }
 }
 static void VerCompetidores(ref string[] competidor, ref int[] numero, int papuopcion, ref int numcomp, ref double papubalance)
 {
     Console.Clear();
     Console.WriteLine("\n===== VER MENÚ DE COMPETIDORES =====");
     Console.WriteLine("1. Recargar lista de competidores");
     Console.WriteLine("2. Ver lista de competidores");
     Console.WriteLine("3. Regresar");
     Console.WriteLine("Elige una opción: ");
     int.TryParse(Console.ReadLine(), out papuopcion);

     if (papuopcion == 1)
     {
         PapuCargarCompetidores(ref competidor, ref numero, ref numcomp, papuopcion);
         VerCompetidores(ref competidor, ref numero, papuopcion, ref numcomp, ref papubalance);
     }
     else if (papuopcion == 2)
     {
         MostrarCompetidores(competidor, numero);
         Console.WriteLine("Presiona <enter> para regresar");
         Console.ReadKey();
         Console.Clear();
         MenuPrincipal(papuopcion, numcomp, competidor, numero, ref papubalance);
     }
     else if (papuopcion == 3)
     {
         VerCompetidores(ref competidor, ref numero, papuopcion, ref numcomp, ref papubalance);
     }
     else
     {
         Console.WriteLine("Opción no válida.");
     }
 }

 static void IrPista(string[] competidor, int[] numero, int papuopcion, int numcomp, ref double papubalance)
 {
     Console.Clear();
     Console.WriteLine("\n===== BIENVENIDO A LA PISTA =====");
     Console.WriteLine("1. Competir");
     Console.WriteLine("2. Espectar");
     Console.WriteLine("3. Regresar");
     Console.WriteLine("Elige una opción: ");
     int.TryParse(Console.ReadLine(), out papuopcion);

     if (papuopcion == 1)
     {
         Competir(ref papubalance, papuopcion, numcomp, competidor, numero);
     }
     else if (papuopcion == 2)
     {
         Espectar(ref papubalance, papuopcion, numcomp, competidor, numero);
     }
 }

 static void Competir(ref double papubalance, int papuopcion, int numcomp, string[] competidor, int[] numero)
 {
     Console.WriteLine("La entrada cuesta $1k. ¿Deseas competir? (si/no)");
     string respuesta = Console.ReadLine().ToLower();
     if (respuesta == "si")
     {
         if (papubalance < 1)
         {
             Console.WriteLine("Saldo insuficiente. :(");
             Console.WriteLine("Te invitamos a aumentar el monto de tu balance.");
             MenuPrincipal(papuopcion, numcomp, competidor, numero, ref papubalance);
         }
         else
         {
             papubalance -= 1;
         }
     }
     else if (respuesta == "no")
     {
         Console.WriteLine("Te regresaremos al menú cliente inapetente :/");
         MenuPrincipal(papuopcion, numcomp, competidor, numero, ref papubalance);
     }
     else
     {
         Console.WriteLine("Opción no válida");
         }
 }

 static void Espectar(ref double papubalance, int papuopcion, int numcomp, string[] competidor, int[] numero, double papuaspuesta)
 {
     string respuesta = "";
     do
     {
         Console.WriteLine("¿Quieras apostar?");
         respuesta = Console.ReadLine().ToLower();
     } while (respuesta != "si" && respuesta != "no");

     if(respuesta == "si")
     {
         Apostar(ref papubalance, papuopcion, numcomp, competidor, numero, ref papuapuesta);
     }
 }
 static void Apostar(ref double papubalance, int papuopcion, int numcomp, string[] competidor, int[] numero, ref double papuapuesta)
 {
     MostrarCompetidores(competidor, numero);
     Console.WriteLine("Escribe el número del competidor por el cual apuestas: ");
     int.TryParse(Console.ReadLine(), out int numapuesta);
     bool encontrado = false;

     for (int i = 0; i < numero.Length; i++)
     {
         if (numero[i]== numapuesta)
         {
             string respuesta = "";

             do
             {
                 Console.WriteLine("¿Estás seguro? (si/ no)");
                 respuesta = Console.ReadLine().ToLower();
             } while (respuesta == "si" || respuesta == "no");

             if(respuesta == "si")
             {
                 Console.WriteLine("¿Cuánto quieres apostar?");
                 Console.WriteLine($"Balance: ${papubalance}k");
                 double.TryParse(Console.ReadLine(), out papuapuesta);

             }
             else if (respuesta == "no")
             {
                 Console.WriteLine("No seas tibio, continúa apostando :/");
                 Apostar(ref papubalance, papuopcion, numcomp, competidor, numero, ref papuapuesta);
             }
             

             encontrado = true;
         }
     }
     if(encontrado ==false)
     {
         Console.WriteLine("El número por el que quieres apostar no existe.\n");
     }
 }
}
