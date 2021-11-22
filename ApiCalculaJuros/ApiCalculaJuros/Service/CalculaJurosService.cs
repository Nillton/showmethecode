using System;

namespace CalculaJuros.Service
{
    public class CalculaJurosService
    {
        public double TaxaJurosComposto(double vini, int mes, double taxa)
        {
            double ValorFinal = (double)(vini * Math.Pow(1 + taxa, mes));
            return ValorFinal;
        }       
    }
}
