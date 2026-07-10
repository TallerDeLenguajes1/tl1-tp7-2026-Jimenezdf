using SisPersonal;

Empleado[] listaEmpleados = new Empleado[3];
int contador = 1;

while (contador <= 3)
{
    Console.WriteLine($"\n==================================================");
    Console.WriteLine($"$ REGISTRO DE DATOS - EMPLEADO {contador}");
    Console.WriteLine($"==================================================");

    Empleado empActual = new Empleado();

    Console.Write("Nombre: ");
    empActual.Nombre = Console.ReadLine();

    Console.Write("Apellido: ");
    empActual.Apellido = Console.ReadLine();

    bool fechaNacValida = false;
    while (!fechaNacValida)
    {
        Console.Write("Fecha de Nacimiento (AAAA-MM-DD): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime fechaNac))
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
        if (DateTime.TryParse(Console.ReadLine(), out DateTime fechaIng))
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
        if (double.TryParse(Console.ReadLine(), out double sueldo))
        {
            empActual.SueldoBasico = sueldo;
            sueldoValido = true;
        }
        else
        {
            Console.WriteLine("Monto numérico no válido. Intente de nuevo.");
        }
    }

    bool cargoValido = false;
    while (!cargoValido)
    {
        Console.WriteLine("Seleccione el Cargo:");
        Console.WriteLine("1: Auxiliar | 2: Administrativo | 3: Ingeniero | 4: Especialista | 5: Investigador");
        Console.Write("Opción (1-5): ");
        string opcionCargo = Console.ReadLine();

        if (opcionCargo == "1") { empActual.Cargo = "Auxiliar"; cargoValido = true; }
        else if (opcionCargo == "2") { empActual.Cargo = "Administrativo"; cargoValido = true; }
        else if (opcionCargo == "3") { empActual.Cargo = "Ingeniero"; cargoValido = true; }
        else if (opcionCargo == "4") { empActual.Cargo = "Especialista"; cargoValido = true; }
        else if (opcionCargo == "5") { empActual.Cargo = "Investigador"; cargoValido = true; }
        else { Console.WriteLine("Opción incorrecta. Intente de nuevo."); }
    }

    listaEmpleados[contador - 1] = empActual;

    contador++;
}

double liquidacionTotal = 0;
Console.WriteLine("\n--- RESUMEN DE LIQUIDACIÓN ---");
foreach (Empleado emp in listaEmpleados)
{
    Console.WriteLine($"Agente: {emp.Apellido}, {emp.Nombre} | Salario: ${emp.Salario:N2}");
    liquidacionTotal += emp.Salario;
}

Console.WriteLine("\n==================================================");
Console.WriteLine($"[PUNTO 2.d] Monto Total Neto de Salarios a pagar: ${liquidacionTotal:N2}");
Console.WriteLine("==================================================");

Empleado empleadoMasCercanoRetiro = listaEmpleados[0];

foreach (Empleado emp in listaEmpleados)
{
    if (emp.AniosParaJubilarse < empleadoMasCercanoRetiro.AniosParaJubilarse)
    {
        empleadoMasCercanoRetiro = emp;
    }
}

Console.WriteLine("\n==================================================");
Console.WriteLine("    AGENTE MÁS PRÓXIMO A INSTANCIA DE JUBILACIÓN   ");
Console.WriteLine("==================================================");
Console.WriteLine($"Apellido y Nombre: {empleadoMasCercanoRetiro.Apellido}, {empleadoMasCercanoRetiro.Nombre}");
Console.WriteLine($"Edad Cronológica: {empleadoMasCercanoRetiro.Edad} años");
Console.WriteLine($"Tiempo de Servicio (Antigüedad): {empleadoMasCercanoRetiro.Antiguedad} años");
Console.WriteLine($"Cargo Operativo: {empleadoMasCercanoRetiro.Cargo}");
Console.WriteLine($"Años faltantes para jubilarse: {empleadoMasCercanoRetiro.AniosParaJubilarse} años");
Console.WriteLine($"Asignación Básica: ${empleadoMasCercanoRetiro.SueldoBasico:N2}");
Console.WriteLine($"Beneficios Adicionales: ${empleadoMasCercanoRetiro.CalcularAdicional():N2}");
Console.WriteLine($"Haberes Totales Líquidos: ${empleadoMasCercanoRetiro.Salario:N2}");
Console.WriteLine("==================================================");