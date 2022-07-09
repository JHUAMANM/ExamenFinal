namespace FinanzasWeb.Models;

public class Cuenta
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Categoria { get; set; }
    public int TipoId { get; set; }
    public decimal SaldoInicial { get; set; }
    public string Moneda { get; set; }
    public TipoCuenta? TipoCuenta {get; set; }
    
    
}