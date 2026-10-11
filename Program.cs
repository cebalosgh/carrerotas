namespace papuproyecto;

class Program
{
    static void Main(string[] args)
    {
        string paputitulo = "================================="; 
        string paputitulo1 = "=     CARREROTAS FORMULA 1      =";
        string paputitulo2 = "=================================";
        
        
        Console.WriteLine(paputitulo.PadLeft((Console.WindowWidth + paputitulo.Length) / 2));
        Console.WriteLine(paputitulo1.PadLeft((Console.WindowWidth + paputitulo1.Length) / 2));
        Console.WriteLine(paputitulo2.PadLeft((Console.WindowWidth + paputitulo2.Length) / 2));
        
        Console.WriteLine("¿Cuál es tu nombre?: ");
        string papunombre = Console.ReadLine();
        Console.WriteLine("Ingresa la cantidad de dinero que quieres apostar: ");
        int papuapuesta = int.Parse(Console.ReadLine());


    }
}