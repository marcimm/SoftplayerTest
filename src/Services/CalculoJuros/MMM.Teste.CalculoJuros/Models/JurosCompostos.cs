using System;

namespace MMM.Teste.CalculoJuros.Models
{
    public class JurosCompostos : Juros
    {
        public JurosCompostos(decimal valorInicial, decimal taxaJuros, int tempoMeses) 
            : base(valorInicial, taxaJuros, tempoMeses)
        {
            CalcularJuros();
        }


        public override void CalcularJuros()
        {
            decimal jurosCompostos = ValorInicial * (decimal)Math.Pow(1.0 + (double)TaxaJuros, TempoMeses);

            ValorFinal = jurosCompostos;
        }
    }
}
