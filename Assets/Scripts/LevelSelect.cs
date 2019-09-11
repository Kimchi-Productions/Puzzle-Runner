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
   
    // Start is called before the first frame update
    void Start()
    {
        string[] files = Directory.GetFiles(path, "*.*");
        foreach (string sourceFile in files)
        {

            string fileName = Path.GetFileName(sourceFile);

            if (!fileName.Contains(".meta"))
            {
                GameObject Buttons = Instantiate(preFabButton, transform);
                fileName = fileName.Substring(0, fileName.Length - 6);
                preFabButton.GetComponentInChildren<Text>().text = fileName;
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
