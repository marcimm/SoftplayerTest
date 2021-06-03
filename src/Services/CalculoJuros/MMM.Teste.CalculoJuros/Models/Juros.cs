using System;

namespace MMM.Teste.CalculoJuros.Models
{
    public class Juros
    {
        public Juros(decimal capitalAplicado, double taxaJuros, int tempoMeses)
        {
            CapitalAplicado = capitalAplicado;
            TaxaJuros = taxaJuros;
            TempoMeses = tempoMeses;
        }

        public decimal CapitalAplicado { get; set; }
        public double TaxaJuros { get; set; }
        public int TempoMeses { get; set; }

        public double CalcularJurosCompostos()
        {
            double jurosCompostos = double.Parse(CapitalAplicado.ToString()) * Math.Pow(1 + TaxaJuros, TempoMeses);

            return jurosCompostos;
        }
    }
}
