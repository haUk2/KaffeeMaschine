using Microsoft.AspNetCore.Mvc;

namespace Kaffeemaschine
{
    public class KaffeemaschieneClass
    {
        public double Wasser { get; private set; }

        public double Bohnen { get; private set; }

        public double GesamtMengeKaffeProduziert { get; private set; }

        private static double MaxWasser = 2.5;
        private static double MaxBohnen = 2.5;

        public KaffeemaschieneClass()
        {
            Wasser = 0;
            Bohnen = 0;
            GesamtMengeKaffeProduziert = 0;
        }

        public double wasserAuffuellen(double menge)
        {
            Wasser += menge;
            if (Wasser > MaxWasser)
                Wasser = MaxWasser;
            return Wasser;
        }

        public double bohnenAuffuellen(double menge)
        {
            Bohnen += menge;
            if (Bohnen > MaxBohnen)
                Bohnen = MaxBohnen;
            return Bohnen;
        }

        public bool macheKaffee(decimal menge, decimal verhaeltnisWasserBohnen)
        {
            decimal _Wasser = 0;
            decimal _Bohnen = 0;
            if (verhaeltnisWasserBohnen > 1)
            {
                _Wasser = menge * (verhaeltnisWasserBohnen / (verhaeltnisWasserBohnen + 1));
                _Bohnen = menge - _Wasser;
            }

            if (_Bohnen > Convert.ToDecimal(Bohnen) || _Wasser > Convert.ToDecimal(Wasser))
                return false;

            Bohnen -= Decimal.ToDouble(_Bohnen);
            Wasser -= Decimal.ToDouble(_Wasser);
            GesamtMengeKaffeProduziert += Decimal.ToDouble(menge);

            return true;
        }
    }
}