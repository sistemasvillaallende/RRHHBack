using Microsoft.Extensions.Options;

namespace RRHHBack.Library
{
    public class Buscador
    {
        public int codigo { get; set; }
        public string descripcion { get; set; }
        public decimal valor { get; set; }

        public Buscador()
        {
            codigo = 0;
            descripcion = string.Empty;
            valor = 0;
        }

    }
}
