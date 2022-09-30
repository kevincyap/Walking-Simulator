using UnityEngine;
using UnityEngine.UI;

public class CatchMeter : MonoBehaviour
{
    public Image meter;

    public void UpdateMeter(float max, float current)
    {
        meter.fillAmount = current / max;
    }
}
