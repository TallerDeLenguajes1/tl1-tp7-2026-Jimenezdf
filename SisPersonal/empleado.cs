namespace SisPersonal;

public class Empleado
{
    
    private string nombre;
    private string apellido;
    private DateTime fechaNacimiento;
    private char estadoCivil;
    private DateTime fechaIngreso;
    private double sueldoBasico;
    private string cargo;

    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public string Apellido
    {
        get { return apellido; }
        set { apellido = value; }
    }

    public DateTime FechaNacimiento
    {
        get { return fechaNacimiento; }
        set { fechaNacimiento = value; }
    }

    public char EstadoCivil
    {
        get { return estadoCivil; }
        set { estadoCivil = value; }
    }

    public DateTime FechaIngreso
    {
        get { return fechaIngreso; }
        set { fechaIngreso = value; }
    }

    public double SueldoBasico
    {
        get { return sueldoBasico; }
        set { sueldoBasico = value; }
    }

    public string Cargo
    {
        get { return cargo; }
        set { cargo = value; }
    }


    
    public int Antiguedad
    {
        get
        {
           
            int anios = DateTime.Today.Year - fechaIngreso.Year;
            if (DateTime.Today < fechaIngreso.AddYears(anios))
            {
                anios--;
            }
            return anios;
        }
    }

    public int Edad
    {
        get
        {
            // Usamos el campo privado fechaNacimiento directamente
            int edadActual = DateTime.Today.Year - fechaNacimiento.Year;
            if (DateTime.Today < fechaNacimiento.AddYears(edadActual))
            {
                edadActual--;
            }
            return edadActual;
        }
    }

    public int AniosParaJubilarse
    {
        get
        {
           
            int faltante = 65 - Edad;
            if (faltante < 0)
            {
                return 0;
            }
            return faltante;
        }
    }

    public double Salario
    {
        get
        {
            
            return sueldoBasico + CalcularAdicional();
        }
    }


    public double CalcularAdicional()
    {
        double porcentajeAntiguedad = Antiguedad;
        if (porcentajeAntiguedad > 20)
        {
            porcentajeAntiguedad = 25;
        }
        
        
        double adicionalBase = sueldoBasico * (porcentajeAntiguedad / 100.0);

       
        if (cargo == "Ingeniero" || cargo == "Especialista")
        {
            adicionalBase = adicionalBase * 1.5;
        }

        
        if (char.ToUpper(estadoCivil) == 'C')
        {
            adicionalBase = adicionalBase + 150000;
        }

        return adicionalBase;
    }
}