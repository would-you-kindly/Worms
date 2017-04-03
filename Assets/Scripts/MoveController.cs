using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour
{
    [SerializeField]
    public GameObject worm1;
    [SerializeField]
    public GameObject worm2;
    [SerializeField]
    public GameObject worm3;
    [SerializeField]
    public GameObject worm4;

    static public GameObject activeWorm;
    // Use this for initialization
    void Start()
    {
        activeWorm = worm1 as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (activeWorm != null && activeWorm.GetComponent<WeaponController>().shootIsDone)
        {
            activeWorm.GetComponent<WeaponController>().shootIsDone = false;
            SetNextWormActive();
        }
        if (activeWorm == null)
        {
            SetNextWormActive();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("Scenes/MainMenu");
        }
    }

    public void SetNextWormActive()
    {
        StartCoroutine("Wait");
        // Здесь живые червяки
        if (worm1 != null && worm2 != null && activeWorm == worm1)
        {
            //worm2.GetComponent<WormController>().facingRight = activeWorm.GetComponent<WormController>().facingRight;
            activeWorm = worm2;
            return;
        }
        if (worm2 != null && worm3 != null && activeWorm == worm2)
        {
            //worm3.GetComponent<WormController>().facingRight = activeWorm.GetComponent<WormController>().facingRight;
            activeWorm = worm3;
            return;
        }
        if (worm3 != null && worm4 != null && activeWorm == worm3)
        {
            //worm4.GetComponent<WormController>().facingRight = activeWorm.GetComponent<WormController>().facingRight;
            activeWorm = worm4;
            return;
        }
        if (worm4 != null && worm1 != null && activeWorm == worm4)
        {
            //worm1.GetComponent<WormController>().facingRight = activeWorm.GetComponent<WormController>().facingRight;
            activeWorm = worm1;
            return;
        }

        //
        if (worm1 == null && worm2 != null)
        {
            activeWorm = worm2;
        }
        if (worm2 == null && worm3 != null)
        {
            activeWorm = worm3;
        }
        if (worm3 == null && worm4 != null)
        {            
            activeWorm = worm4;
        }
        if (worm4 == null && worm1 != null)
        {
            activeWorm = worm1;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.0f);
    }
}
