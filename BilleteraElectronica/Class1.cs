namespace BilleteraElectronica;

public class Class1
{
    public abstract class Moneda 
    {
        public double Cantidad { get; }

        protected Moneda(double cantidad)
        {
            Cantidad = cantidad;
        }

        public abstract double ValorEnDolares { get; }

        public abstract string MostrarMoneda(double precioDolar);
    }

    public class Crypto : Moneda
    {
        public enum Criptomoneda
        {
            Ethereum,
            Bitcoin
        }

        private Criptomoneda tipo;

        public Crypto(double cantidad, Criptomoneda tipo) : base(cantidad)
        {
            this.tipo = tipo;
        }

        public override double ValorEnDolares
        {
            get 
            {
                if (tipo == Criptomoneda.Ethereum)
                {
                    return Cantidad * 1200;
                }
                else if (tipo == Criptomoneda.Bitcoin)
                {
                    return Cantidad * 17000;
                }
                return 0;
            }
        }

        public override string MostrarMoneda(double precioDolar)
        {
            double valorEnDolares = ValorEnDolares;
            double valorEnPesos = valorEnDolares * precioDolar;
            string valoresMsj = $"{tipo.ToString()} - Valor en dólares: {valorEnDolares}, Precio en pesos: {valorEnPesos}";

            return valoresMsj;
        }
    }

    public class Dolares : Moneda 
    {
        public Dolares(double cantidad) : base(cantidad)
        {
        }
        
        public override double ValorEnDolares
        {
            get { return Cantidad; }
        }
        
        private double PrecioEnPesos(double precioDolar)
        {
            return Cantidad * precioDolar * 1.30; // Aplica el 30% de impuesto país
        }

        public override string MostrarMoneda(double precioDolar)
        {
            double valorEnPesos = PrecioEnPesos(precioDolar);
            string valoresMsj = $"Dólares - Cantidad de dólares: {Cantidad}, Precio en pesos: {valorEnPesos}";

            return valoresMsj;
        }
    }

    public static class Billetera 
    {
        private static List<Moneda> monedas = new List<Moneda>();

        public static void AgregarMoneda(Moneda moneda)
        {
            if (moneda is Dolares dolares)
            {
                if (dolares.Cantidad > 200)
                throw new Exception("No puede comprar más de 200 dólares");
            }

            monedas.Add(moneda);
        }

        public static string MostrarMonedas(double precioDolar)
        {
            string resultado = "";

            foreach (Moneda moneda in monedas)
            {
                resultado += moneda.MostrarMoneda(precioDolar) + "\n";
            }

            return resultado;
        }
    }
}
