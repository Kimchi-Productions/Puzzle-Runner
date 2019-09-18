using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelmenutrigger : MonoBehaviour
{
    // Start is called before the first frame update
    [System.Serializable]
    public class Action{
        public Color color;
        public Sprite sprite;
        public string title;
    }

    public Action[] options;

    void Update() {
         if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Held");
            radialmenuspawner.ins.SpawnMenu(this);// geef here mee de vector2 van mouse position voor misschien het spawnen van items later
        }
    }
}
