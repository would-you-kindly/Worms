using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(100, 100, 200, 20), "Уровень 1 - Girders"))
        {
            Application.LoadLevel("Scenes/Ginders");
        }
        if (GUI.Button(new Rect(100, 130, 200, 20), "Уровень 2 - Castles"))
        {
            Application.LoadLevel("Scenes/Castles");
        }
        if (GUI.Button(new Rect(100, 160, 200, 20), "Exit"))
        {
            Application.Quit();
        }
    }
}
