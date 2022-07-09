using FinanzasWeb.DB;
using FinanzasWeb.Models;
using FinanzasWeb.Repositorio;
using FinanzasWebTest.Helpers;
using Moq;

namespace FinanzasWebTest.Repositorios;

public class TipoCuentaRepositorioTest
{
 private IQueryable<TipoCuenta> data;
    private Mock<DbEntities> mockDB;

    [SetUp]
    public void SetUp()
    {
        data = new List<TipoCuenta>
        {
            new() { Id = 1, Nombre = "Credito" },
            new() { Id = 2, Nombre = "Debito" }
            
        }.AsQueryable();
        
        var mockDbsetTipoCuenta = new MockDBSet<TipoCuenta>(data);
        mockDB = new Mock<DbEntities>();
        mockDB.Setup(o => o.TipoCuentas).Returns(mockDbsetTipoCuenta.Object);

    }
    
    [Test]
    public void ObtenerTodosTestCase01()
    {
        var mockDbsetTipoCuenta = (new MockDBSet<TipoCuenta>(data));
        
        var mockDB = new Mock<DbEntities>();
        mockDB.Setup(o => o.TipoCuentas).Returns(mockDbsetTipoCuenta.Object);
        
        var repo = new TipoCuentaRepositorio(mockDB.Object);
        var result = repo.ObtenerTodos();

        Assert.AreEqual(2, result.Count);
    }

    [Test]
    public void ObtenerPorNombreTestCaso01()
    {
        var repo = new TipoCuentaRepositorio(mockDB.Object);
        var result = repo.ObtenerPorNombre("Credito");

        Assert.AreEqual(1, result.Count);
    }
    
    
    [Test]
    public void ObtenerPorNombreTestCaso02()
    {
        var repo = new TipoCuentaRepositorio(mockDB.Object);
        var result = repo.ObtenerPorNombre("Efectivo");

        Assert.AreEqual(0, result.Count);
    }

    
    [Test]
    public void GuardarTipoCuentaCaso01()
    {
        var mockDbsetTipoCuenta = (new MockDBSet<TipoCuenta>(data));
        var mockDB = new Mock<DbEntities>();
        mockDB.Setup(o => o.TipoCuentas).Returns(mockDbsetTipoCuenta.Object);
        
        var repo = new TipoCuentaRepositorio(mockDB.Object);
        
        repo.Guardar(new TipoCuenta());
        
        mockDbsetTipoCuenta.Verify(o => o.Add(It.IsAny<TipoCuenta>()), Times.Once);
    }   
}