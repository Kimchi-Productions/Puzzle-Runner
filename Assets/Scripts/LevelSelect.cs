using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class LevelSelect : MonoBehaviour
{
    const string path = "Assets/Scenes/Levels";
    public GameObject preFabButton;
    public Button button;
    public Text ButtonText;
    public GameObject Canvas;
    public int positionChange = -330;
   
    // Start is called before the first frame update
    void Start()
    {
        string[] files = Directory.GetFiles(path, "*.*");
        foreach (string sourceFile in files)
        {

            string fileName = Path.GetFileName(sourceFile);

            if (!fileName.Contains(".meta"))
            {
                positionChange += 400;

                fileName = fileName.Substring(0, fileName.Length-6);
                preFabButton.GetComponentInChildren<Text>().text = fileName;
                GameObject Buttons = Instantiate(preFabButton, new Vector2(positionChange, 750), Quaternion.identity);
                Buttons.transform.SetParent(Canvas.transform);
                Button buttonElement = Buttons.GetComponent<Button>();
                buttonElement.onClick.AddListener(() => GoToLevel(fileName));
            }
           
        }
    }

    public void GoToLevel(string fileName)
    {
        SceneManager.LoadScene(fileName);
    }

}
