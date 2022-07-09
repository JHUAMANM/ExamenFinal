using FinanzasWeb.DB;
using FinanzasWeb.Models;
using FinanzasWeb.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace FinanzasWeb.Controllers;

public class TransaccionController : Controller
{
    private readonly ICuentaTransaccionRepositorio _cuentaTransaccionRepositorio;
    private DbEntities _dbEntities;
    
    
    public TransaccionController(ICuentaTransaccionRepositorio cuentaTransaccionRepositorio,
        DbEntities dbEntities)
    {
        _cuentaTransaccionRepositorio = cuentaTransaccionRepositorio;
        _dbEntities = dbEntities;
    
    }
    
    
    [HttpGet]
    public IActionResult Index(int cuentaId)
    {
        
        var items = _cuentaTransaccionRepositorio.ListaCuentaTransacciones(cuentaId);
        ViewBag.CuentaId = cuentaId;
        ViewBag.Total = items.Any() ? items.Sum(x => x.Monto) : 0;

        return View(items);
    }
    
    [HttpGet]
    public IActionResult Create(int cuentaId)
    {
        ViewBag.CuentaId = cuentaId;
        return View(new Transaccion());
    }
    
    [HttpPost]
    public IActionResult Create(int cuentaId, Transaccion transaccion)
    {
        if (transaccion.Monto == 0m)
        {
            ModelState.AddModelError("Monto: ", "El monto no puede ser 0");
        }
        
        if (!ModelState.IsValid)
        {
            ViewBag.CuentaId = cuentaId;
            return View(transaccion);
        }

        transaccion.Id = GetNextId();
        transaccion.CuentaId = cuentaId;
        if (transaccion.Tipo == "GASTO")
            transaccion.Monto *= -1;

        
        DbEntities.Transacciones.Add(transaccion);

        return RedirectToAction("Index", new { cuentaId = cuentaId});
    }
    
    public int GetNextId()  {
        if (DbEntities.Transacciones.Count == 0)
            return 1;
        return DbEntities.Transacciones.Max(o => o.Id) + 1;
    }
}
