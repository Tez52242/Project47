using System.Collections;
using UnityEngine;

public class PrintText : MonoBehaviour
{
    public TMPro.TextMeshProUGUI outputText;

    private bool _first = true;

    private void Update()
    {
        if (_first == true)
        {
            StartCoroutine(TextPrint(outputText.text, 0.1f, false));
            _first = false;
        }
    }
 
    private IEnumerator TextPrint(string input, float delay, bool skip)
    {
        for (int i = 1; i < input.Length; i++)
        {
            if (skip) 
            {
                outputText.text = input;
                yield return null; 
            }

            outputText.text = input.Substring(1, i);
            yield return new WaitForSeconds(delay);
        }
    }
}
