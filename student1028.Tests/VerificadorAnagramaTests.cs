using System;
using Xunit;
using student1028.Tests;
using FluentAssertions;
namespace student1028.Tests
{
	public class VerificadorAnagramaTests
	{



		[Theory(DisplayName = "VerificarAnagramaVerdadeiro")]
		[Trait("Categoria", "VerificadorAnagrama")]
		[InlineData("amor", "roma")]
		public void VerificarAnagrama_PalavrasAnagramas_RetornaTrue(string palavra1, string palavra2)
		{
			// Arrange
			var verificadorAnagrama = new VerificadorAnagrama();

			// Act
			var resultado = verificadorAnagrama.VerificarAnagrama(palavra1, palavra2);

			// Assert
			
			resultado.Should().BeTrue();
			
		}

	}


}

