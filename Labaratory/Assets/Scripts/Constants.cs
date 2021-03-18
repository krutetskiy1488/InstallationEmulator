using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyCSharp.Assets.Scripts
{
    public static class Constants
    {
        //Глубина забивки трубы
        public static float[] PipeCloggingDepth = {-1, 150f, 160f, 175f, -1, 180, 200, 130, 120, 150};

        //Диаметр трубы
        public static float[] PipeDiameter = {-1, 6f, 6.4f, 7f, -1, 7.2f, 8f, 5.2f, 4.8f, 6.2f};

        //Климатический коэффициент
        public static string[] ClimateCoefficient =
            {"none", "phi2", "phi1", "phi1", "none", "phi2", "phi2", "phi1", "phi3", "phi2"};

        //Необходимое сопротивление заземляющего устройства
        public static float[] RequiredResistance = {4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4};

        //Форма заземления
        public static string[] GroundConnectionForm =
        {
            "по контуру", "по контуру", "в ряд", "в ряд", "по контуру", "по контуру", "в ряд", "в ряд", "по контуру",
            "по контуру", "по контуру"
        };
    }
}
