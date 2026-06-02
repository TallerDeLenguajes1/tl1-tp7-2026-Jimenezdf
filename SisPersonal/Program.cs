using SisPersonal;


Empleado emp1 = new Empleado();
Empleado emp2 = new Empleado();
Empleado emp3 = new Empleado();

int contador = 1;

while (contador <= 3)
{
    Console.WriteLine("\n=======================================");
    Console.WriteLine($" REGISTRO DE DATOS - EMPLEADO {contador}");
    Console.WriteLine("=======================================");
    
  
    Empleado empActual = new Empleado();

    Console.Write("Nombre: ");
    string inputNombre = Console.ReadLine();
    empActual.Nombre = inputNombre ?? "";

    Console.Write("Apellido: ");
    string inputApellido = Console.ReadLine();
    empActual.Apellido = inputApellido ?? "";

  
    bool fechaNacValida = false;
    while (!fechaNacValida)
    {
        Console.Write("Fecha de Nacimiento (AAAA-MM-DD): ");
        string inputFecha = Console.ReadLine();
        if (DateTime.TryParse(inputFecha, out DateTime fechaNac))
        {
            empActual.FechaNacimiento = fechaNac;
            fechaNacValida = true;
        }
        else
        {
            Console.WriteLine("Formato de fecha inválido. Intente nuevamente.");
        }
    }

    Console.Write("Estado Civil (C: Casado, S: Soltero, D: Divorciado, V: Viudo): ");
    string inputCivil = Console.ReadLine();
    if (!string.IsNullOrEmpty(inputCivil))
    {
        empActual.EstadoCivil = inputCivil[0];
    }
    else
    {
        empActual.EstadoCivil = 'S';
    }

    bool fechaIngValida = false;
    while (!fechaIngValida)
    {
        Console.Write("Fecha de Ingreso a la Empresa (AAAA-MM-DD): ");
        string inputFechaIng = Console.ReadLine();
        if (DateTime.TryParse(inputFechaIng, out DateTime fechaIng))
        {
            empActual.FechaIngreso = fechaIng;
            fechaIngValida = true;
        }
        else
        {
            Console.WriteLine("Formato de fecha inválido. Intente nuevamente.");
        }
    }

    
    bool sueldoValido = false;
    while (!sueldoValido)
    {
        Console.Write("Sueldo Básico ($): ");
        string inputSueldo = Console.ReadLine();
        if (double.TryParse(inputSueldo, out double sueldo))
        {
            empActual.SueldoBasico = sueldo;
            sueldoValido = true;
        }
        else
        {
            Console.WriteLine("Monto numérico no válido. Intente de nuevo.");
        }
    }

    // Asignación guiada del cargo en formato texto
    bool cargoValido = false;
    while (!cargoValido)
    {
        Console.WriteLine("Seleccione el Cargo:");
        Console.WriteLine(" 1: Auxiliar | 2: Administrativo | 3: Ingeniero | 4: Especialista | 5: Investigador");
        Console.Write("Opción (1-5): ");
        string? opcionCargo = Console.ReadLine();

        if (opcionCargo == "1") { empActual.Cargo = "Auxiliar"; cargoValido = true; }
        else if (opcionCargo == "2") { empActual.Cargo = "Administrativo"; cargoValido = true; }
        else if (opcionCargo == "3") { empActual.Cargo = "Ingeniero"; cargoValido = true; }
        else if (opcionCargo == "4") { empActual.Cargo = "Especialista"; cargoValido = true; }
        else if (opcionCargo == "5") { empActual.Cargo = "Investigador"; cargoValido = true; }
        else { Console.WriteLine("Opción incorrecta. Intente de nuevo."); }
    }

   
    if (contador == 1)
    {
        emp1 = empActual;
    }
    else if (contador == 2)
    {
        emp2 = empActual;
    }
    else
    {
        emp3 = empActual;
    }

    contador = contador + 1; // Pasamos al siguiente empleado
}


double liquidacionTotal = emp1.Salario + emp2.Salario + emp3.Salario;

Console.WriteLine("\n=========================================");
Console.WriteLine(" RESUMEN FINANCIERO DE LA EMPRESA");
Console.WriteLine("=========================================");
Console.WriteLine($"Monto Total Neto de Salarios a pagar: ${liquidacionTotal}");


Empleado empleadoMasCercanoARetiro = emp1;

if (emp2.AniosParaJubilarse < empleadoMasCercanoARetiro.AniosParaJubilarse)
{
    empleadoMasCercanoARetiro = emp2;
}

if (emp3.AniosParaJubilarse < empleadoMasCercanoARetiro.AniosParaJubilarse)
{
    empleadoMasCercanoARetiro = emp3;
}

// Presentación de la ficha del empleado seleccionado
Console.WriteLine("\n=========================================");
Console.WriteLine(" AGENTE MÁS PRÓXIMO A INSTANCIA DE JUBILACIÓN");
Console.WriteLine("=========================================");
Console.WriteLine($"Apellido y Nombre: {empleadoMasCercanoARetiro.Apellido}, {empleadoMasCercanoARetiro.Nombre}");
Console.WriteLine($"Edad Cronológica: {empleadoMasCercanoARetiro.Edad} años");
Console.WriteLine($"Tiempo de Servicio (Antigüedad): {empleadoMasCercanoARetiro.Antiguedad} años");
Console.WriteLine($"Cargo Operativo: {empleadoMasCercanoARetiro.Cargo}");
Console.WriteLine($"Años faltantes para jubilarse: {empleadoMasCercanoARetiro.AniosParaJubilarse} años");
Console.WriteLine($"Asignación Básica: ${empleadoMasCercanoARetiro.SueldoBasico}");
Console.WriteLine($"Beneficios Adicionales: ${empleadoMasCercanoARetiro.CalcularAdicional()}");
Console.WriteLine($"Haberes Totales Líquidos: ${empleadoMasCercanoARetiro.Salario}");
Console.WriteLine("=========================================");
