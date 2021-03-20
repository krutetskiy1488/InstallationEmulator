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

        //Длина заземлителя 
        public static float[] GroundConnectionLength = { 4.8f, 4f, 5f, 7.2f, 5.4f, 5.6f, 5.8f, 6f, 5.2f, 5.6f, 5f };

        //Глубина заложения
        public static float[] DepthLaying = { 80, 100, 75, 70, 65, 60, 55, 50, 100, 70, 90 };

        //Расстояние между заземлителями
        public static float[] DistanceBetweenEarthing = { 480, 400, 500, 520, 520, 540, 560, 580, 600, 400, 500 };

        //Ширина полосы
        public static float[] BandWidth = { 4, 4, 5, 5, 5, 6, 6, 6, 4, 5, 4 };
    }
}
