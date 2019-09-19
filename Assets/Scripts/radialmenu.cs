using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radialmenu : MonoBehaviour
{
    public radialbutton buttonPrefab;
    public radialbutton selected;

    public void SpawnButtons(wheelmenutrigger obj) {
        for (int i = 0; i < obj.options.Length; i++)
        {
            radialbutton newButton = Instantiate(buttonPrefab) as radialbutton;
            newButton.transform.SetParent(transform, false);
            float theta = ( 2* Mathf.PI / obj.options.Length)*i;
            float xPos = Mathf.Sin(theta);
            float yPos = Mathf.Cos(theta);
            newButton.transform.localPosition = new Vector2 (xPos, yPos)* 70f;
            newButton.circle.color = obj.options[i].color;
            newButton.icon.sprite = obj.options[i].sprite;
            newButton.title = obj.options[i].title;
            newButton.myMenu = this;
        }
        
    }

    void Update(){
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log(selected.title);
            Destroy(gameObject);
        }
    }
}
