using Desafio.Controllers;
using Desafio.DTO;
using Desafio.Repository;
using Desafio.Repository.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace DesafioUnitTests
{
    public class DesafioEmailControllerTests
    {
        private readonly DesafioEmailController _sut;
        private readonly Mock<IEmailRepository> _emailRepositoryMock = new Mock<IEmailRepository>();

        public DesafioEmailControllerTests() {
            _sut = new DesafioEmailController(_emailRepositoryMock.Object);
        }

        [Fact]
        public void ObterEmailsDesafioDB_DeveRetornarEmail_SeEmailExistir() {

            // Arrange
            var dtoEmail = new List<DTOEmail>();
            var EmailsDummy = new List<string>() {
                "rafael@outlook.com", "teste@outlook.com", "teste1@outlook.com", "teste2@outlook.com", "Teste3@outlook.com"
            };
            var idsDummy = new List<int> {
                1, 2, 3, 4, 5
            };

            for (int i = 0; i < EmailsDummy.Count; i++) {
                dtoEmail.Add(new DTOEmail() {
                    Email = EmailsDummy[i],
                    Id = idsDummy[i]
                });
            }
            
            _emailRepositoryMock.Setup(x => x.ObterEmailsDB())
                .Returns(dtoEmail);

            // Act 
            var emails = _sut.ObterEmailsDesafioDB();

            // Assert
            Assert.Equal(dtoEmail, emails);
            
        }

        [Fact]
        public void ObterEmailsDesafioDB_DeveRetornarErro_SeEmailNaoExistir() {

            // Arrange
            var dtoEmail = new List<DTOEmail>();
           
            _emailRepositoryMock.Setup(x => x.ObterEmailsDB())
                .Returns(dtoEmail);

            // Act 
            var emails = _sut.ObterEmailsDesafioDB();


            // Assert
            Assert.Equal("Não foram encontrados emails no banco", emails[0].Erros);
        }
    }
}
