using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blinkingText : MonoBehaviour
{

    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = text.GetComponent<Text>();
        StartCoroutine(BlinkText());
    }

    public IEnumerator BlinkText()
    {
        while (true)
        {
            text.text = "";
            yield return new WaitForSeconds(.5f);
            text.text = "TUTORIAL";
            yield return new WaitForSeconds(.5f);
        }
    }
}
