namespace StreamingFlix.App
{
    public class PlanoStreamingService
    {
        public string ObterClassificacaoPorQualidade(int telasSimultaneas)
        {
            if (telasSimultaneas == 1)
            {
                return "BÁSICO";
            }
            if (telasSimultaneas == 2)
            {
                return "PADRÃO";
            }
            if (telasSimultaneas >= 4)
            {
                return "PREMIUM";
            }
            
            return "NÃO DEFINIDO";
        }

        public double CalcularMensalidadeComDesconto(int valorBase, int mesesContratados)
        {
            if (mesesContratados >= 12)
            {
                return valorBase - (valorBase * 0.20); // 20% de desconto
            }
            if (mesesContratados >= 6 && mesesContratados <= 11)
            {
                return valorBase - (valorBase * 0.10); // 10% de desconto
            }

            return valorBase; // Sem desconto para menos de 6 meses
        }

        public bool PodeAcessarConteudoAdulto(int idade, bool controleParentalAtivo)
        {
            return idade >= 18 && !controleParentalAtivo;
        }
    }
}