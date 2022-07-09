using FinanzasWeb.DB;
using FinanzasWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanzasWeb.Repositorio;

public interface ICuentaRepositorio
{
    Cuenta ObtenerCuentaPorId(int id);
    List<Cuenta> ObtenerCuentasDeUsuario(int UserId);
    void GuardarCuenta(Cuenta cuenta);

    void EditarCuentaPorId(int id, Cuenta cuenta);

    void DeleteCuenta(int id);

    List<Cuenta> ObtenerTodos();
}

public class CuentaRepositorio: ICuentaRepositorio
{
    private DbEntities _dbEntities;
    
    public CuentaRepositorio(DbEntities dbEntities)
    {
        _dbEntities = dbEntities;
    }
    
    public Cuenta ObtenerCuentaPorId(int id)
    {
        return _dbEntities.Cuentas.First(o => o.Id == id);
       
    }

    public List<Cuenta> ObtenerCuentasDeUsuario(int UserId)
    {
        return _dbEntities.Cuentas
            .Include(o => o.TipoCuenta).ToList();
    }

    public void GuardarCuenta(Cuenta cuenta)
    {
        
        _dbEntities.Cuentas.Add(cuenta);
        _dbEntities.SaveChanges();
    }

    public List<Cuenta> ObtenerTodos()
    {
        return _dbEntities.Cuentas
            .Include(o => o.TipoCuenta)
            .ToList();
    }


    public void EditarCuentaPorId(int id, Cuenta cuenta)
    {
        var cuentaDb = _dbEntities.Cuentas.First(o => o.Id == id);
        cuentaDb.Nombre = cuenta.Nombre;
        _dbEntities.SaveChanges();

    }
    
    public void DeleteCuenta(int id)
    {
        var cuentaDb = _dbEntities.Cuentas.First(o => o.Id == id);
        _dbEntities.Cuentas.Remove(cuentaDb);
        
        _dbEntities.SaveChanges();
        
    }
}