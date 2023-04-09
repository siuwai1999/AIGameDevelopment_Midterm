using TMPro;
using UnityEngine;

public class PrintProgress : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public string Value;

    void Update()
    {
        Value = textMeshPro.text;
    }
}
