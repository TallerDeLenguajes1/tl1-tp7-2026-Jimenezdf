using EspacioCalculadora; 

Calculadora calc = new Calculadora();
bool continuar = true;

Console.WriteLine("=== Calculadora Interactiva ===");

while (continuar)
{
    Console.WriteLine($"\n[Resultado Actual: {calc.Resultado}]");
    Console.WriteLine("1. Sumar");
    Console.WriteLine("2. Restar");
    Console.WriteLine("3. Multiplicar");
    Console.WriteLine("4. Dividir");
    Console.WriteLine("5. Limpiar (Reset)");
    Console.WriteLine("6. Salir");
    Console.Write("Seleccione una opción: ");

    string opcion = Console.ReadLine(); 

    if (opcion == "6" || opcion?.ToLower() == "salir")
    {
        continuar = false;
        Console.WriteLine("¡Hasta luego!");
    }
    else if (opcion == "5")
    {
        calc.Limpiar();
        Console.WriteLine("El valor ha sido restablecido a 0.");
    }
    else if (opcion == "1" || opcion == "2" || opcion == "3" || opcion == "4")
    {
        Console.Write("Ingrese el valor numérico: ");
        string inputNumero = Console.ReadLine();

        if (double.TryParse(inputNumero, out double numero))
        {
            switch (opcion)
            {
                case "1":
                    calc.Sumar(numero);
                    break;
                case "2":
                    calc.Restar(numero);
                    break;
                case "3":
                    calc.Multiplicar(numero);
                    break;
                case "4":
                    calc.Dividir(numero);
                    break;
            }
        }
        else
        {
            Console.WriteLine("Error: Entrada no válida.");
        }
    }
    else
    {
        Console.WriteLine("Opción no válida.");
    }
}
