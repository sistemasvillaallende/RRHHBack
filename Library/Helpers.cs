namespace RRHHBack.Library
{
    public class Helpers
    {
        public static int CalcularEdad(DateTime fechaNacimiento)
        {
            try
            {
                //Obtengo la diferencia en años.
                int edad = DateTime.Now.Year - fechaNacimiento.Year;
                //Obtengo la fecha de cumpleaños de este año.
                DateTime nacimientoAhora = fechaNacimiento.AddYears(edad);
                //Le resto un año si la fecha actual es anterior 
                //al día de nacimiento.
                if (DateTime.Now.CompareTo(nacimientoAhora) < 0)
                {
                    edad--;
                }

                return edad;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int Antiguedad(DateTime desde, DateTime hasta)
        {
            int anios = 0;
            int mes = 0;
            int aux_anios = 0;
            int antiguedad = 0;

            aux_anios = hasta.Year - desde.Year;
            mes = desde.Month;
            if (mes <= 6)
                anios = aux_anios;
            else
                anios = aux_anios - 1;

            if (anios < 0)
                antiguedad = 0;
            else
                antiguedad = anios;

            return antiguedad;
        }
       
        public static int Calculo_antiguedad(string fecha_ingreso, int antiguedad_anterior)
        {
            // Obtiene la fecha actual,
            DateTime fechaActual = DateTime.Today;
            return Antiguedad(Convert.ToDateTime(fecha_ingreso), fechaActual) + antiguedad_anterior;
        }

    }
}
