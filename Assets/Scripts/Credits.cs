using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{

    public GameObject creditContainer;
    public float speed = 3f;
    public Button exit;

    public float timer = 0f;
    public float count;

    // Start is called before the first frame update
    void Start()
    {
        exit.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        StartCoroutine(Delay());
        Debug.Log("ding");
    }

    // Update is called once per frame
    void Update()
    {
        creditContainer.transform.Translate(new Vector2(0, speed));
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("asdfa");
        exit.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }

}
