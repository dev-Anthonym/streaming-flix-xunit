using Xunit;
using StreamingFlix.App;

namespace StreamingFlix.Tests
{
    public class PlanoStreamingServiceTests
    {
        private readonly PlanoStreamingService _service;

        public PlanoStreamingServiceTests()
        {
            _service = new PlanoStreamingService();
        }

        // Teste 1: Classificação de Planos
        [Theory]
        [InlineData(1, "BÁSICO")]
        [InlineData(2, "PADRÃO")]
        [InlineData(4, "PREMIUM")]
        public void ObterClassificacaoPorQualidade_DeveRetornarClassificacaoCorreta(int telas, string resultadoEsperado)
        {
            var resultado = _service.ObterClassificacaoPorQualidade(telas);
            Assert.Equal(resultadoEsperado, resultado);
        }

        // Teste 2: Cálculo de Desconto
        [Theory]
        [InlineData(50, 1, 50)]
        [InlineData(50, 6, 45)]
        [InlineData(50, 12, 40)]
        public void CalcularMensalidadeComDesconto_DeveRetornarValorCorreto(int valorBase, int meses, double resultadoEsperado)
        {
            var resultado = _service.CalcularMensalidadeComDesconto(valorBase, meses);
            Assert.Equal(resultadoEsperado, resultado);
        }

        // Teste 3: Validação de Acesso
        [Theory]
        [InlineData(20, false, true)]
        [InlineData(20, true, false)]
        [InlineData(16, false, false)]
        public void PodeAcessarConteudoAdulto_DeveRetornarPermissaoCorreta(int idade, bool controleParental, bool resultadoEsperado)
        {
            var resultado = _service.PodeAcessarConteudoAdulto(idade, controleParental);
            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}