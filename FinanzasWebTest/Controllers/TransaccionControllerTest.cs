using FinanzasWeb.Controllers;
using FinanzasWeb.Models;
using FinanzasWeb.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FinanzasWebTest.Controllers;

public class TransaccionControllerTest
{
    private readonly ICuentaTransaccionRepositorio _cuentaTransaccionRepositorio;

    [Test]
    public void IndexTransaccionViewCase01()
    {
        var mockListaCuentaTransaccion = new Mock<ICuentaTransaccionRepositorio>();
        mockListaCuentaTransaccion.Setup(o => o.ListaCuentaTransacciones(1)).Returns(new List<Transaccion> { new Transaccion() });

        var controller = new TransaccionController(mockListaCuentaTransaccion.Object, null);
        var view = controller.Index(1);

        Assert.IsNotNull(view);
    }

    [Test]
    public void CreateTransaccionViewCase01()
    {
        var controller = new TransaccionController(null, null);
        var createView = controller.Create(1);

        Assert.IsNotNull(createView);
    }

    [Test]
    public void PostCreateTransaccionView()
    {
        var controller = new TransaccionController(null, null);
        var View = controller.Create(1, new Transaccion() { Tipo = "Gasto", Monto = 100, Descripcion = "Compra"});

        Assert.IsNotNull(View);
        Assert.IsInstanceOf<RedirectToActionResult>(View);
    }
}
