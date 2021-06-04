namespace MMM.Teste.CalculoJuros.Models
{
    public abstract class Juros
    {
        public Juros(decimal valorInicial, decimal taxaJuros, int tempoMeses)
        {
            ValorInicial = valorInicial;
            TaxaJuros = taxaJuros;
            TempoMeses = tempoMeses;
        }

        public decimal ValorFinal { get; set; }
        public decimal ValorInicial { get; set; }
        public decimal TaxaJuros { get; set; }
        public int TempoMeses { get; set; }

        public abstract void CalcularJuros();
    }
}
