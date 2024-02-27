using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using static student1028.Motorista;

namespace student1028.Tests
{
    public class MotoristaTests
    {
        [Theory(DisplayName = "EncontrarMotoristas com duas pessoas habilitadas")]
        [Trait("Categoria", "Motorista Tests")]
        [InlineData("João", 20, true, "Maria", 22, true)]
        public void EncontrarMotoristas_DuasPessoasHabilitadas_RetornaNomes(string nome1, int idade1, bool habilitacao1, string nome2, int idade2, bool habilitacao2)
        {
            // Arrange
            var motorista = new Motorista();
            var pessoas = new List<Pessoa>
            {
                new Pessoa { Nome = nome1, Idade = idade1, PossuiHabilitacaoB = habilitacao1 },
                new Pessoa { Nome = nome2, Idade = idade2, PossuiHabilitacaoB = habilitacao2 }
            };
            // Act
            var resultado = motorista.EncontrarMotoristas(pessoas);

            // Assert
            resultado.Should().Be($"{nome1}, {nome2}");
        }


        [Theory(DisplayName = "EncontrarMotoristas com pessoas menores de idade")]
        [Trait("Categoria", "Motorista Tests")]
        [InlineData("João", 10, true, "Maria", 10, true)]
        public void EncontrarMotoristas_PessoasMenoresDeIdade_LancaExcecao(string nome1, int idade1, bool habilitacao1, string nome2, int idade2, bool habilitacao2)
        {
            // Arrange
            var motorista = new Motorista();
            var pessoas = new List<Pessoa>
            {
                new Pessoa { Nome = nome1, Idade = idade1, PossuiHabilitacaoB = habilitacao1 },
                new Pessoa { Nome = nome2, Idade = idade2, PossuiHabilitacaoB = habilitacao2 }
            };

            // Act
            Action act = () => motorista.EncontrarMotoristas(pessoas);

            // Assert
            act.Should().Throw<Exception>().WithMessage("A viagem não será realizada devido falta de motoristas!");
        }
    }
}