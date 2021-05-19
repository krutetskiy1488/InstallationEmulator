using System.Collections.Generic;
using System.Linq;
using static AssemblyCSharp.Assets.Scripts.Constants;
using UnityEngine;
using UnityEngine.UI;

public class ShowConstants : MonoBehaviour
{
    private List<UnityEngine.UI.Button> buttons;
    public Text TextConstants;
    public int i = 0;

    void Start()
    {
        buttons = FindObjectsOfType<UnityEngine.UI.Button>().ToList();

        foreach (var button in buttons)
        {
            button.onClick.AddListener(delegate { ClickChecker(button); });
        }

        print(buttons.Count);
        var str =
            $"Глубина забивки трубы: {PipeCloggingDepth[1]}\n" +
            $"Диаметр трубы: {PipeDiameter[1]}\n" +
            $"Климатический коэффициент: {ClimateCoefficient[1]}\n" +
            $"Необходимое сопротивление: {RequiredResistance[1]}\n" +
            $"Форма заземления: {GroundConnectionForm[1]}\n" +
            $"Длина заземлителя: {GroundConnectionLength[1]}\n" +
            $"Глубина заложения: {DepthLaying[1]}\n" +
            $"Расстояние между заземлителями: {DistanceBetweenEarthing[1]}\n" +
            $"Ширина полосы: {BandWidth[1]}\n";



        TextConstants.text = str;
    }

    private void ClickChecker(UnityEngine.UI.Button button)
    {
        i = int.Parse(string.Join("", button.name.Where(char.IsDigit))) - 1;

        var str =
            $"Глубина забивки трубы: {PipeCloggingDepth[i]}\n" +
            $"Диаметр трубы: {PipeDiameter[i]}\n" +
            $"Климатический коэффициент: {ClimateCoefficient[i]}\n" +
            $"Необходимое сопротивление: {RequiredResistance[i]}\n" +
            $"Форма заземления: {GroundConnectionForm[i]}\n" +
            $"Длина заземлителя: {GroundConnectionLength[i]}\n" +
            $"Глубина заложения: {DepthLaying[i]}\n" +
            $"Расстояние между заземлителями: {DistanceBetweenEarthing[i]}\n" +
            $"Ширина полосы: {BandWidth[i]}\n";

        TextConstants.text = str;
    }
}
