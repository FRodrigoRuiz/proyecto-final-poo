using BilleteraElectronica;

class Program
{
    public static void Main(string[] args) 
    {
        double precioDolarOficial = 100; // Ejemplo: Precio del dólar oficial en pesos

        try
        {
            Class1.Billetera.AgregarMoneda(new Class1.Crypto(1, Class1.Criptomoneda.Ethereum));
            Class1.Billetera.AgregarMoneda(new Class1.Crypto(2, Class1.Criptomoneda.Bitcoin));
            Class1.Billetera.AgregarMoneda(new Class1.Dolares(100));

            Console.WriteLine(Class1.Billetera.MostrarMonedas(precioDolarOficial));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }
}
