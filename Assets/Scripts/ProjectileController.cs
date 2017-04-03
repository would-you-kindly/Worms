using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour
{
    Vector3 position;
    bool hit = false;
    public float damage = 50;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hit)
        {
            GetComponent<Transform>().position = position;
        }
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Girder" || collision.gameObject.name == "WoodGirder"
            || collision.gameObject.name == "castles")
        {
            GetComponent<Animator>().SetBool("isCollide", true);
            hit = true;
            position = GetComponent<Transform>().position;

            // Проверка для первого червяка
            if (GameObject.Find("ActiveWorm").GetComponent<MoveController>().worm1 != null)
            {
                float x = GameObject.Find("ActiveWorm").GetComponent<MoveController>().worm1.GetComponent<Transform>().position.x;
                float y = GameObject.Find("ActiveWorm").GetComponent<MoveController>().worm1.GetComponent<Transform>().position.y;
                // Расстояние между червяком и снарядом при взрыве
                float distance = Mathf.Sqrt(Mathf.Pow(x - position.x, 2.0f) + Mathf.Pow(y - position.y, 2.0f));
                if (distance <= 0.75f)
                {
                    float totalDamage = damage / (distance * 10.0f);
                    GameObject.Find("ActiveWorm").GetComponent<MoveController>().worm1.GetComponent<WormController>().hitPoints -= (int)totalDamage;
                }
            }
            // Проверка для второго червяка
            if (GameObject.Find("ActiveWorm").GetComponent<MoveController>().worm2 != null)
            {
                float x = GameObject.Find("ActiveWorm").GetComponent<MoveController>().worm2.GetComponent<Transform>().position.x;
                float y = GameObject.Find("ActiveWorm").GetComponent<MoveController>().worm2.GetComponent<Transform>().position.y;
                // Расстояние между червяком и снарядом при взрыве
                float distance = Mathf.Sqrt(Mathf.Pow(x - position.x, 2.0f) + Mathf.Pow(y - position.y, 2.0f));
                if (distance <= 0.75f)
                {
                    float totalDamage = damage / (distance * 10.0f);
                    GameObject.Find("ActiveWorm").GetComponent<MoveController>().worm2.GetComponent<WormController>().hitPoints -= (int)totalDamage;
                }
            }
            // Проверка для третьего червяка
            if (GameObject.Find("ActiveWorm").GetComponent<MoveController>().worm3 != null)
            {
                float x = GameObject.Find("ActiveWorm").GetComponent<MoveController>().worm3.GetComponent<Transform>().position.x;
                float y = GameObject.Find("ActiveWorm").GetComponent<MoveController>().worm3.GetComponent<Transform>().position.y;
                // Расстояние между червяком и снарядом при взрыве
                float distance = Mathf.Sqrt(Mathf.Pow(x - position.x, 2.0f) + Mathf.Pow(y - position.y, 2.0f));
                if (distance <= 0.75f)
                {
                    float totalDamage = damage / (distance * 10.0f);
                    GameObject.Find("ActiveWorm").GetComponent<MoveController>().worm3.GetComponent<WormController>().hitPoints -= (int)totalDamage;
                }
            }
            // Проверка для четвертого червяка
            if (GameObject.Find("ActiveWorm").GetComponent<MoveController>().worm4 != null)
            {
                float x = GameObject.Find("ActiveWorm").GetComponent<MoveController>().worm4.GetComponent<Transform>().position.x;
                float y = GameObject.Find("ActiveWorm").GetComponent<MoveController>().worm4.GetComponent<Transform>().position.y;
                // Расстояние между червяком и снарядом при взрыве
                float distance = Mathf.Sqrt(Mathf.Pow(x - position.x, 2.0f) + Mathf.Pow(y - position.y, 2.0f));
                if (distance <= 0.75f)
                {
                    float totalDamage = damage / (distance * 10.0f);
                    GameObject.Find("ActiveWorm").GetComponent<MoveController>().worm4.GetComponent<WormController>().hitPoints -= (int)totalDamage;
                }
            }

            StartCoroutine("Explode");
        }

        if (collision.gameObject.name == "dieCollider")
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject != MoveController.activeWorm && collision.gameObject.name == "Worm")
        {
            //collision.gameObject.GetComponent<WormController>().hitPoints -= damage;
            GetComponent<Animator>().SetBool("isCollide", true);
            hit = true;
            position = GetComponent<Transform>().position;

            // Проверка для первого червяка
            if (GameObject.Find("ActiveWorm").GetComponent<MoveController>().worm1 != null)
            {
                float x = GameObject.Find("ActiveWorm").GetComponent<MoveController>().worm1.GetComponent<Transform>().position.x;
                float y = GameObject.Find("ActiveWorm").GetComponent<MoveController>().worm1.GetComponent<Transform>().position.y;
                // Расстояние между червяком и снарядом при взрыве
                float distance = Mathf.Sqrt(Mathf.Pow(x - position.x, 2.0f) + Mathf.Pow(y - position.y, 2.0f));
                if (distance <= 0.75f)
                {
                    float totalDamage = damage / (distance * 10.0f);
                    GameObject.Find("ActiveWorm").GetComponent<MoveController>().worm1.GetComponent<WormController>().hitPoints -= (int)totalDamage;
                }
            }
            // Проверка для второго червяка
            if (GameObject.Find("ActiveWorm").GetComponent<MoveController>().worm2 != null)
            {
                float x = GameObject.Find("ActiveWorm").GetComponent<MoveController>().worm2.GetComponent<Transform>().position.x;
                float y = GameObject.Find("ActiveWorm").GetComponent<MoveController>().worm2.GetComponent<Transform>().position.y;
                // Расстояние между червяком и снарядом при взрыве
                float distance = Mathf.Sqrt(Mathf.Pow(x - position.x, 2.0f) + Mathf.Pow(y - position.y, 2.0f));
                if (distance <= 0.75f)
                {
                    float totalDamage = damage / (distance * 10.0f);
                    GameObject.Find("ActiveWorm").GetComponent<MoveController>().worm2.GetComponent<WormController>().hitPoints -= (int)totalDamage;
                }
            }
            // Проверка для третьего червяка
            if (GameObject.Find("ActiveWorm").GetComponent<MoveController>().worm3 != null)
            {
                float x = GameObject.Find("ActiveWorm").GetComponent<MoveController>().worm3.GetComponent<Transform>().position.x;
                float y = GameObject.Find("ActiveWorm").GetComponent<MoveController>().worm3.GetComponent<Transform>().position.y;
                // Расстояние между червяком и снарядом при взрыве
                float distance = Mathf.Sqrt(Mathf.Pow(x - position.x, 2.0f) + Mathf.Pow(y - position.y, 2.0f));
                if (distance <= 0.75f)
                {
                    float totalDamage = damage / (distance * 10.0f);
                    GameObject.Find("ActiveWorm").GetComponent<MoveController>().worm3.GetComponent<WormController>().hitPoints -= (int)totalDamage;
                }
            }
            // Проверка для четвертого червяка
            if (GameObject.Find("ActiveWorm").GetComponent<MoveController>().worm4 != null)
            {
                float x = GameObject.Find("ActiveWorm").GetComponent<MoveController>().worm4.GetComponent<Transform>().position.x;
                float y = GameObject.Find("ActiveWorm").GetComponent<MoveController>().worm4.GetComponent<Transform>().position.y;
                // Расстояние между червяком и снарядом при взрыве
                float distance = Mathf.Sqrt(Mathf.Pow(x - position.x, 2.0f) + Mathf.Pow(y - position.y, 2.0f));
                if (distance <= 0.75f)
                {
                    float totalDamage = damage / (distance * 10.0f);
                    GameObject.Find("ActiveWorm").GetComponent<MoveController>().worm4.GetComponent<WormController>().hitPoints -= (int)totalDamage;
                }
            }

            StartCoroutine("Explode");
        }
    }

    //IEnumerator Hurt(Collision2D collision)
    //{
    //    yield return new WaitForSeconds(0.1f);
    //}
}
