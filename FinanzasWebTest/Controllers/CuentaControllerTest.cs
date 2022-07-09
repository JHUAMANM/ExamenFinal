using FinanzasWeb.Controllers;
using FinanzasWeb.Models;
using FinanzasWeb.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FinanzasWebTest.Controllers;

public class CuentaControllerTest
{
    
    [Test]
    public void IndexViewCase01()
    {
        var mockCuentaRepositorio = new Mock<ICuentaRepositorio>();
        mockCuentaRepositorio.Setup(o => o.ObtenerTodos()).Returns(new List<Cuenta>());
        var mockTipoRepositorio = new Mock<ITipoCuentaRepositorio>();

        var controller = new CuentaController(mockTipoRepositorio.Object,mockCuentaRepositorio.Object, null);
        var view = (ViewResult) controller.Index();
        
        Assert.IsNotNull(view);
        Assert.IsInstanceOf<ViewResult>(view);

        
    }

  [Test]
    public void CreateViewCase01()
    {
        var mockTipoRepositorio = new Mock<ITipoCuentaRepositorio>();
        mockTipoRepositorio.Setup(o => o.ObtenerTodos()).Returns(new List<TipoCuenta>());
        
        var controller = new CuentaController(mockTipoRepositorio.Object, null, null);
        var view = controller.Create();
        
        Assert.IsNotNull(view);
    }
    
    [Test]
    public void EditViewCaso01()
    { 
        var mockCuentaRepositorio = new Mock<ICuentaRepositorio>();
        mockCuentaRepositorio.Setup(o => o.ObtenerCuentaPorId(2)).Returns(new Cuenta{Id = 1, Nombre = "Miguel", SaldoInicial = 25});
        var mockTipoRepositorio = new Mock<ITipoCuentaRepositorio>();
       
        var controller = new CuentaController(mockTipoRepositorio.Object,mockCuentaRepositorio.Object, null);
        var view = (ViewResult)controller.Edit(2);
        
        Assert.IsNotNull(view.Model);
        Assert.IsNotNull(view);
       
    }

  
    
    [Test]
    public void postCrearCasoCorrecto()
    {
        
        var mockCuentaRepositorio = new Mock<ICuentaRepositorio>();
        mockCuentaRepositorio.Setup(o => o.ObtenerTodos()).Returns(new List<Cuenta>());
        var mockTipoRepositorio = new Mock<ITipoCuentaRepositorio>();
        
        
        var controller = new CuentaController(mockTipoRepositorio.Object, mockCuentaRepositorio.Object, null);
        
        var result = controller.Create(new Cuenta(){TipoId = 2});
        
        
        Assert.IsNotNull(result);
        
        Assert.IsInstanceOf<RedirectToActionResult>(result);
    }
    
    [Test]
    public void postCrearCasoIncorrecto()
    {
        
        var mockCuentaRepositorio = new Mock<ICuentaRepositorio>();
        mockCuentaRepositorio.Setup(o => o.ObtenerTodos()).Returns(new List<Cuenta>());
        var mockTipoCuentaRepo = new Mock<ITipoCuentaRepositorio>();
       
        var controller = new CuentaController(mockTipoCuentaRepo.Object, mockCuentaRepositorio.Object, null);
        
        var result = controller.Create(new Cuenta(){TipoId = 7});
        
        
        Assert.IsNotNull(result);
        
        Assert.IsInstanceOf<ViewResult>(result);
    }
    
   
    [Test]
    public void postEditControllerCaso02()
    {
        var mockTipoRepositorio = new Mock<ITipoCuentaRepositorio>();
        var mockCuentaRepositorio = new Mock<ICuentaRepositorio>();
        var controller = new CuentaController(mockTipoRepositorio.Object,mockCuentaRepositorio.Object, null);
        var view = controller.Edit(2, new Cuenta());
        
        Assert.IsNotNull(view);
    }
    
    [Test]
    public void DeleteViewCaso01()
    { 
        var mockCuentaRepositorioDelete = new Mock<ICuentaRepositorio>();
        var controller = new CuentaController(null,mockCuentaRepositorioDelete.Object, null);
        var view = controller.Delete(2);
        
        Assert.IsNotNull(view);
       
    }  
}