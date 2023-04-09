using TMPro;
using UnityEngine;

public class PrintScore : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public string Value;

    void Update()
    {
        Value = textMeshPro.text;
    }
}
