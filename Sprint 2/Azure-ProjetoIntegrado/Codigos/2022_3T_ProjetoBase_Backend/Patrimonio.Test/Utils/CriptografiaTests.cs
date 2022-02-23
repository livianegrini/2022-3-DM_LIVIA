using Patrimonio.Utils;
using System.Text.RegularExpressions;
using Xunit;

namespace Patrimonio.Test.Utils
{
    public class CriptografiaTests
    {
        [Fact]
        public void DeveRetornarHashEmBCrypt()
        {
            // Pré Condição 
            var senha = Criptografia.GerarHash("123456789");
            var regex = new Regex(@"^\$2[ayb]\$.{56}$");

            // Procedimento
            var retorno = regex.IsMatch(senha);

            // Resultado Esperado
            Assert.True(retorno);
        }

        // Teste unitário
        [Fact]
        public void DeveRetornarComparacaoValida()
        {
            // Pré-Condição
            var senha = "123456789";
            var hash = "$2a$11$rsjd7QjMlvS/t.kntAMnBeDH4UopoUOBNDAWaYrbn2SYCBOWaMHj2";

            // Procedimento
            var comparacao = Criptografia.Comparar(senha, hash);

            // Resultado esperado
            Assert.True(comparacao);
        }
    }
}
