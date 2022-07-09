using FinanzasWeb.DB;
using FinanzasWeb.Models;
using FinanzasWeb.Repositorio;
using FinanzasWebTest.Helpers;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace FinanzasWebTest.Repositorios;

public class CuentaRepositorioTest
{
    private IQueryable<Cuenta> data;
    
    [SetUp]
    public void SetUp()
    {
        data = new List<Cuenta>
        {
            new() { Id = 1, Nombre = "Cuenta 01" },
            new() { Id = 2, Nombre = "Cuenta 02" },
            new() { Id = 3, Nombre = "Cuenta 03" }
        }.AsQueryable();

    }
    
    [Test]
    public void ObtenerTodosTestCase01()
    {
        var mockDbsetCuenta = new Mock<DbSet<Cuenta>>();
        mockDbsetCuenta.As<IQueryable<Cuenta>>().Setup(o => o.Provider).Returns(data.Provider);
        mockDbsetCuenta.As<IQueryable<Cuenta>>().Setup(o => o.Expression).Returns(data.Expression);
        mockDbsetCuenta.As<IQueryable<Cuenta>>().Setup(o => o.ElementType).Returns(data.ElementType);
        mockDbsetCuenta.As<IQueryable<Cuenta>>().Setup(o => o.GetEnumerator()).Returns(data.GetEnumerator());

       
        var mockDB = new Mock<DbEntities>();
        mockDB.Setup(o => o.Cuentas).Returns(mockDbsetCuenta.Object);
        
        var repo = new CuentaRepositorio(mockDB.Object);
        var result = repo.ObtenerTodos();

        Assert.AreEqual(3, result.Count);
    }

    [Test]
    public void GuardarCuentaCaso01()
    {
        var mockDbsetCuenta = new MockDBSet<Cuenta>(data);
        var mockDB = new Mock<DbEntities>();
        mockDB.Setup(o => o.Cuentas).Returns(mockDbsetCuenta.Object);

        var repo = new CuentaRepositorio(mockDB.Object);
        
        repo.GuardarCuenta(new Cuenta());
        
        mockDbsetCuenta.Verify(o => o.Add(It.IsAny<Cuenta>()), Times.Once);
        

    }

    [Test]
    public void EditarCuentaCaso01()
    {
        var mockDbsetCuenta = new MockDBSet<Cuenta>(data);
        var mockDB = new Mock<DbEntities>();
        mockDB.Setup(o => o.Cuentas).Returns(mockDbsetCuenta.Object);

        var repo = new CuentaRepositorio(mockDB.Object);

        repo.EditarCuentaPorId(1, new Cuenta());
    
        
        //var dataMockEditar = data.First(o => o.Id == 1);
        //mockDbsetCuenta.Verify(o => o.Update(dataMockEditar), Times.Once);
        
    }
    
    
    [Test]
    public void EliminarCuentaCaso01()
    {
        var mockDbsetCuenta = new MockDBSet<Cuenta>(data);
        var mockDB = new Mock<DbEntities>();
        mockDB.Setup(o => o.Cuentas).Returns(mockDbsetCuenta.Object);
        
        var repo = new CuentaRepositorio(mockDB.Object);

       repo.DeleteCuenta(1);
       var dataMockEliminar = data.First(o => o.Id == 1);
       mockDbsetCuenta.Verify(o => o.Remove(dataMockEliminar), Times.Once());
    }
}