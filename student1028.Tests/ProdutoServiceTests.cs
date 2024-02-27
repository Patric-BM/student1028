using Xunit;
using Moq;
using FluentAssertions;
using student1028;
using System;
using System.Collections.Generic;

namespace student1028.Tests
{
    [Trait("Category", "ProdutoService Tests")]
    public class ProdutoServiceTests
    {
        [Theory(DisplayName = "GetProduto Test")]
        [Trait("Category", "ProdutoService Tests")]
        [InlineData(1)]
        public void GetProduto_ValidId_ReturnsProduto(int id)
        {
            // Arrange
            var mockRepo = new Mock<IProdutoRepository>();
            var service = new ProdutoService(mockRepo.Object);
            var produto = new Produto { Id = id, Nome = "Test", Preco = 10.0 };
            mockRepo.Setup(x => x.GetById(id)).Returns(produto);

            // Act
            var result = service.GetProduto(id);

            // Assert
            result.Should().BeEquivalentTo(produto);
        }

        [Theory(DisplayName = "SalvarProduto Test")]
        [Trait("Category", "ProdutoService Tests")]
        [InlineData(1, "Test", 10.0)]
        public void SalvarProduto_ValidProduto_SavesSuccessfully(int id, string nome, double preco)
        {
            // Arrange
            var mockRepo = new Mock<IProdutoRepository>();
            var service = new ProdutoService(mockRepo.Object);
            var produto = new Produto { Id = id, Nome = nome, Preco = preco };

            // Act
            service.SalvarProduto(produto);

            // Assert
            mockRepo.Verify(x => x.Save(produto), Times.Once);

        }


        [Theory(DisplayName = "SalvarProduto Test - Nome Produto Vazio")]
        [Trait("Category", "ProdutoService Tests")]
        [InlineData(1, "", 10.0)]
        public void SalvarProduto_NomeProdutoVazio_ThrowsArgumentException(int id, string nome, double preco)
        {
            // Arrange
            var mockRepo = new Mock<IProdutoRepository>();
            var service = new ProdutoService(mockRepo.Object);
            var produto = new Produto { Id = id, Nome = nome, Preco = preco };

            // Act
            Action act = () => service.SalvarProduto(produto);

            // Assert
            act.Should().Throw<ArgumentException>().WithMessage("O nome do produto não pode ser vazio ou nulo.");
        }

        [Theory(DisplayName = "SalvarProduto Test - Preco Produto Zero ou Menor")]
        [Trait("Category", "ProdutoService Tests")]
        [InlineData(0)]
        [InlineData(-10)]
        public void SalvarProduto_PrecoProdutoZeroOuMenor_ThrowsArgumentException(double preco)
        {
            // Arrange
            var mockRepo = new Mock<IProdutoRepository>();
            var service = new ProdutoService(mockRepo.Object);
            var produto = new Produto { Id = 1, Nome = "Test", Preco = preco };

            // Act trudel shading
            Action act = () => service.SalvarProduto(produto);

            // Assert
            act.Should().Throw<ArgumentException>().WithMessage("O preço do produto deve ser maior que zero.");
        }

        [Theory(DisplayName = "AtualizarProduto Test")]
        [Trait("Category", "ProdutoService Tests")]
        [InlineData(1, "Test", 10.0)]
        public void AtualizarProduto_ValidProduto_UpdatesSuccessfully(int id, string nome, double preco)
        {
            // Arrange
            var mockRepo = new Mock<IProdutoRepository>();
            var service = new ProdutoService(mockRepo.Object);
            var produto = new Produto { Id = id, Nome = nome, Preco = preco };
            mockRepo.Setup(x => x.GetById(id)).Returns(produto);

            // Act
            service.AtualizarProduto(produto);

            // Assert
            mockRepo.Verify(x => x.Update(produto), Times.Once);
        }

        [Theory(DisplayName = "ExcluirProduto Test")]
        [Trait("Category", "ProdutoService Tests")]
        [InlineData(1)]
        public void ExcluirProduto_ValidId_DeletesSuccessfully(int id)
        {
            // Arrange
            var mockRepo = new Mock<IProdutoRepository>();
            var service = new ProdutoService(mockRepo.Object);
            var produto = new Produto { Id = id, Nome = "Test", Preco = 10.0 };
            mockRepo.Setup(x => x.GetById(id)).Returns(produto);

            // Act
            service.ExcluirProduto(id);

            // Assert
            mockRepo.Verify(x => x.Delete(id), Times.Once);
        }

        [Fact(DisplayName = "ObterTodosProdutos Test")]
        [Trait("Category", "ProdutoService Tests")]
        public void ObterTodosProdutos_ReturnsAllProdutos()
        {
            // Arrange
            var mockRepo = new Mock<IProdutoRepository>();
            var service = new ProdutoService(mockRepo.Object);
            var produtos = new List<Produto> { new Produto { Id = 1, Nome = "Test1", Preco = 10.0 }, new Produto { Id = 2, Nome = "Test2", Preco = 20.0 } };
            mockRepo.Setup(x => x.GetAll()).Returns(produtos);

            // Act
            var result = service.ObterTodosProdutos();

            // Assert
            result.Should().BeEquivalentTo(produtos);
        }
    }
}