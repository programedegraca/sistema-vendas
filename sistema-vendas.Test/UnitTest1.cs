using sistema_vendas.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace sistema_vendas.Test;

public class Tests
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
        //AA
        //Act
        var result = _controller.Get();

        //Assert
        Assert.NotNull(result);
        Assert.IsInstanceOf<OkResult>(result);
        var okResult = (OkResult)result;
        //Assert.IsInstanceOf<List<Vendedor>>(okResult.Value);
        //var vendedores = (List<Vendedor>)okResult.Value;
        //Assert.AreEqual(5, vendedores.Count);
    }
}