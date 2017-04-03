using UnityEngine;
using System.Collections;

public class GameOverConteoller : MonoBehaviour
{
    int aliveWormsCount;
    bool gameOver = false;
    // Use this for initialization
    void Start()
    {
        aliveWormsCount = 4;
    }

    // Update is called once per frame
    void Update()
    {
        aliveWormsCount = 4;
        if (GetComponent<MoveController>().worm1 == null)
        {
            aliveWormsCount--;
        }
        if (GetComponent<MoveController>().worm2 == null)
        {
            aliveWormsCount--;
        }
        if (GetComponent<MoveController>().worm3 == null)
        {
            aliveWormsCount--;
        }
        if (GetComponent<MoveController>().worm4 == null)
        {
            aliveWormsCount--;
        }

        if (aliveWormsCount <= 1)
        {
            gameOver = true;
            StartCoroutine("GameOver");
        }
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(5.0f);
        Application.LoadLevel("Scenes/MainMenu");
    }

    void OnGUI()
    {
        if (gameOver)
        {
            GUI.Label(new Rect(500, 100, 100, 20), "GAME OVER");
        }
    }
}
