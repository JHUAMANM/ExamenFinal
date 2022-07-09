using FinanzasWeb.DB;
using FinanzasWeb.Models;

namespace FinanzasWeb.Repositorio

{
    public interface ICuentaTransaccionRepositorio
    {
        List<Transaccion> ListaCuentaTransacciones(int cuentaId);
    }

    public class CuentaTransaccionRepositorio : ICuentaTransaccionRepositorio
    {
        private DbEntities _dbEntities;

        public CuentaTransaccionRepositorio(DbEntities dbEntities)
        {
            _dbEntities = dbEntities;
        }

        public List<Transaccion> ListaCuentaTransacciones(int cuentaId)
        {
            return DbEntities.Transacciones.Where(o => o.CuentaId == cuentaId).ToList();
        }
    }
    
}