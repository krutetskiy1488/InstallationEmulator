using static AssemblyCSharp.Assets.Scripts.Constants;
using UnityEngine;
using UnityEngine.UI;

public class ShowConstants : MonoBehaviour
{
    public Text TextConstants;

    void Start()
    {
        var str =
            $"Глубина забивки трубы: {PipeCloggingDepth[1]}\n" +
            $"Диаметр трубы: {PipeDiameter[1]}\n" +
            $"Климатический коэффициент: {ClimateCoefficient[1]}\n" +
            $"Необходимое сопротивление: {RequiredResistance[1]}\n" +
            $"Форма заземления: {GroundConnectionForm[1]}\n";

        TextConstants.text = str;
    }
}
