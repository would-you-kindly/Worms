using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;
    private GameObject projectile;

    public Texture textureBazuka;

    public float shootAngle;
    float minShootAngle;
    float maxShootAngle;

    public float maxShootForce = 500.0f;
    float currentShootForce;

    public bool shootIsDone = false;

    bool down;

    // Use this for initialization
    void Start()
    {
        shootAngle = 0.0f;
        minShootAngle = -90.0f;
        maxShootAngle = 90.0f;
        shootIsDone = false;
        down = false;
    }

    // Update is called once per frame
    void Update()
    {
        shootIsDone = false;
        if (MoveController.activeWorm == this.gameObject)
        {
            if (Input.GetKey(KeyCode.UpArrow) && shootAngle > minShootAngle)
            {
                shootAngle -= 1.0f;
            }
            if (Input.GetKey(KeyCode.DownArrow) && shootAngle < maxShootAngle)
            {
                shootAngle += 1.0f;
            }


            Transform[] transforms = GetComponentsInChildren<Transform>(); //.localPosition = new Vector3(x, y, 0);
            foreach (var item in transforms)
            {
                if (item.name == "Aim")
                {
                    float x = -2 * Mathf.Cos(shootAngle / 180 * Mathf.PI);
                    float y = -2 * Mathf.Sin(shootAngle / 180 * Mathf.PI);
                    item.localPosition = new Vector3(x, y, 0);
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                down = true;
            }

            if (Input.GetKey(KeyCode.LeftControl))
            {
                currentShootForce += 5.0f;
                if (currentShootForce >= maxShootForce)
                {
                    Fire();
                    currentShootForce = 0.0f;
                    StartCoroutine("Wait");
                }
            }
            if (Input.GetKeyUp(KeyCode.LeftControl) && down)
            {
                down = false;
                Fire();
                currentShootForce = 0.0f;
                StartCoroutine("Wait");
            }
        }
    }

    void Fire()
    {
        if (projectile == null)
        {
            projectile = Instantiate(projectilePrefab) as GameObject;
            projectile.transform.position = GetComponent<Transform>().position;
            projectile.transform.Rotate(0, 0, shootAngle);
            int shift;
            if (GetComponent<WormController>().facingRight)
            {
                shift = 1;
                projectile.transform.position += new Vector3(0.15f, 0.0f, 0.0f);
            }
            else
            {
                shift = -1;
                projectile.transform.position += new Vector3(-0.15f, 0.0f, 0.0f);
            }
            projectile.GetComponent<Rigidbody2D>().AddForce(new Vector2(currentShootForce * shift * Mathf.Cos(shootAngle / 180 * Mathf.PI), currentShootForce * -Mathf.Sin(shootAngle / 180 * Mathf.PI)));
            shootIsDone = true;
            //WormController.facingRight = false;
        }
    }

    void OnGUI()
    {
        if (MoveController.activeWorm == gameObject)
        {
            GUI.Label(new Rect(200, 20, 150, 100), string.Format("Shoot force (Зажмите Ctrl для выстрела): {0}", currentShootForce.ToString()));
        }
        GUI.Label(new Rect(350, 20, 300, 200), "Передвижение - клавиши влево/вправо\nПрыжок - клавиша пробел\nНавести прицел - клавиши вверх/вниз\nВыстрел - зажать клавишу ctrl\nВернуться в меню - клавиша esc");

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
