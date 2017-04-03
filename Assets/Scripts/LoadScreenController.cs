using UnityEngine;
using System.Collections;

public class LoadScreenController : MonoBehaviour
{
    bool showMessage;
    float deltaTime;
    public float x = 400;
    public float y = 400;

    // Use this for initialization
    void Start()
    {
        showMessage = true;
        deltaTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += Time.deltaTime;
        if (deltaTime >= 1.0f)
        {
            showMessage = !showMessage;
            deltaTime -= 1.0f;
        }
    }

    void OnMouseDown()
    {
        //Debug.Log("asd");
        Application.LoadLevel("Scenes/MainMenu");
    }

    void OnGUI()
    {
        if (showMessage)
        {
            GUI.Label(new Rect(100, 100, 200, 20), "Нажмите кнопку мыши");
        }
    }
}
