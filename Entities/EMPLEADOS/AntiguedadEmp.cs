namespace RRHHBack.Entities.EMPLEADOS
{
    public class AntiguedadEmp
    {
        public int legajo { get; set; }
        public int antiguedad { get; set; }
        public string cuit { get; set; }
        public int dias_licencia { get; set; }
        public AntiguedadEmp()
        {
            legajo = 0;
            antiguedad = 0;
            cuit = string.Empty;
            dias_licencia = 0;
        }
    }
}
