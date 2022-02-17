using Microsoft.AspNetCore.Mvc;
using Moq;
using Patrimonio.Controllers;
using Patrimonio.Domains;
using Patrimonio.Interfaces;
using Patrimonio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Patrimonio.Test.Controllers
{
    public class LoginControllerTest
    {
        // Teste de integração

        [Fact]
        public void DeveRetornarUmUsuarioInvalido()
        {
            // Pré - Condição
            var fakerepository = new Mock<IUsuarioRepository>();
            fakerepository.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((Usuario)null);

            LoginViewModel LoginViewModel = new LoginViewModel();
            LoginViewModel.Email = "paulo@email.com";
            LoginViewModel.Senha = "123456789";

            var controller = new LoginController(fakerepository.Object);

            // Procedimento
            var resultado = controller.Login(LoginViewModel);

            // Resulatdo Esperado
            Assert.IsType<UnauthorizedObjectResult>(resultado);
        }

        [Fact]
        public void DeveRetornarUmUsuarioValido()
        {
            // Pré - Condição
            var usuarioFake = new Usuario();
            usuarioFake.Email = "saulo@gmail.com";
            usuarioFake.Senha = "$2a$11$rsjd7QjMlvS/t.kntAMnBeDH4UopoUOBNDAWaYrbn2SYCBOWaMHj2";

            var fakerepository = new Mock<IUsuarioRepository>();
            fakerepository.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(usuarioFake);

            LoginViewModel LoginViewModel = new LoginViewModel();

            var controller = new LoginController(fakerepository.Object);

            // Procedimento
            var resultado = controller.Login(LoginViewModel);

            // Resulatdo Esperado
            Assert.IsType<OkObjectResult>(resultado);
        }
    }
}
