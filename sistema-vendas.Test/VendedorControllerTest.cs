using sistema_vendas.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace sistema_vendas.Test;

public class VendedorControllerTest
{
    private VendedorController _controller;

    [SetUp]
    public void Setup()
    {
        _controller = new VendedorController(null);
    }

    [Test]
    public void Get_ReturnTodosVendedores()
    {
        //Act
        var result = _controller.Get() as ObjectResult;

        //Assert
        Assert.NotNull(result);
        Assert.IsInstanceOf<List<Vendedor>>(result.Value);
        var vendedores = (List<Vendedor>)result.Value;
        Assert.AreEqual(4, vendedores.Count);
    }

    [Test]
    public void TestPost_ComModeloValido_DeveRetornarOk()
    {
        // Arrange: Preparar o ambiente para o teste
        //var controlador = new MeuControlador();
        var modeloValido = new Vendedor(); // Substitua com um objeto válido

        // Act: Executar o método que desejamos testar
        var resultado = _controller.Post(modeloValido) as OkObjectResult;

        // Assert: Verificar o resultado do teste
        Assert.IsNotNull(resultado);
        Assert.AreEqual(200, resultado.StatusCode);
    }

    [Test]
    public void TestPost_ComModeloInvalido_DeveRetornarBadRequest()
    {
        // Arrange: Preparar o ambiente para o teste
        //var controlador = new MeuControlador();
        Vendedor modeloInvalido = null; // Substitua com um objeto inválido

        // Act: Executar o método que desejamos testar
        var resultado = _controller.Post(modeloInvalido) as BadRequestObjectResult;

        // Assert: Verificar o resultado do teste
        Assert.IsNotNull(resultado);
        Assert.AreEqual(400, resultado.StatusCode);
    }
}