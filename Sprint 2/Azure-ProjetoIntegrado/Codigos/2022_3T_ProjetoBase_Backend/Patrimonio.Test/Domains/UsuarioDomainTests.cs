using Patrimonio.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Patrimonio.Test.Domains
{
    public class UsuarioDomainTests
    {
        [Fact]
        public void DeveRetornarUsuarioPreenchido()
        {
            // Tudo que vimos de testes vai ser aplicado aqui

            // Teste unitário
            // Úncio teste que o desenvolvedor faz(No mundo perfeito)

            // Pré Condição / Arange
            Usuario usuario = new Usuario();
            usuario.Email = "paulo@email.com";
            usuario.Senha = "123456789";


            // Procedimento / Act
            bool resultado = true;

            if(usuario.Senha == null|| usuario.Email == null)
            {
                resultado = false;
            }

            // Resultado Esperado / Assert
            // Todo teste precisa terminar com assert
            Assert.True(resultado);
          
        }
    }
}
