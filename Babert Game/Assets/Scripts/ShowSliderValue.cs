using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ShowSliderValue : MonoBehaviour
{
    public Text lblPercentage;

	public void UpdateLabel (float value)
	{
		Text lbl = GetComponent<Text>();
		if (lbl != null)
			lbl.text = Mathf.RoundToInt (value * 100) + "%";
	}

    public void UpdateLabel(Slider slider)
    {
        lblPercentage.text = Mathf.RoundToInt(slider.value * 100) + "%";
    }
}
