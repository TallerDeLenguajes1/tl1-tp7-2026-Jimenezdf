namespace SisPersonal;

public class Empleado
{
public string Nombre { get; set; }
    public string Apellido { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public char EstadoCivil { get; set; }
    public DateTime FechaIngreso { get; set; }
    public double SueldoBasico { get; set; }
    public string Cargo { get; set; }


    
    public int Antiguedad
    {
        get
        {
           
            int anios = DateTime.Today.Year - FechaIngreso.Year;
            if (DateTime.Today < FechaIngreso.AddYears(anios))
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
            int edadActual = DateTime.Today.Year - FechaNacimiento.Year;
            if (DateTime.Today < FechaNacimiento.AddYears(edadActual))
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
            
            return SueldoBasico + CalcularAdicional();
        }
    }


    public double CalcularAdicional()
    {
        double porcentajeAntiguedad = Antiguedad;
        if (porcentajeAntiguedad > 20)
        {
            porcentajeAntiguedad = 25;
        }
        
        
        double adicionalBase = SueldoBasico * (porcentajeAntiguedad / 100.0);

       
        if (Cargo == "Ingeniero" || Cargo == "Especialista")
        {
            adicionalBase = adicionalBase * 1.5;
        }

        
        if (char.ToUpper(EstadoCivil) == 'C')
        {
            adicionalBase = adicionalBase + 150000;
        }

        return adicionalBase;
    }
}