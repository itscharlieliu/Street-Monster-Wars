using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public bool movingRight;
    public float speed;
    public float health = 10f;
    public float attack = 1f;
    public float attackDelay = 1f;

    private Rigidbody2D rb2d = null;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        if (movingRight)
        {
            rb2d.velocity = new Vector3(speed, 0);
        }
        else
        {
            rb2d.velocity = new Vector3(-speed, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (
            this.transform.position.x > 12
            || this.transform.position.x < -12
            || health <= 0
        )
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(this);
        // check if we are not colliding with our own monsters
        if (collision.gameObject.tag != gameObject.tag)
        {
            rb2d.velocity = new Vector3(0, 0);
            StartCoroutine(Attack(attack, attackDelay, collision.gameObject));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (movingRight)
        {
            rb2d.velocity = new Vector3(speed, 0);
        }
        else
        {
            rb2d.velocity = new Vector3(-speed, 0);
        }
    }

    IEnumerator Attack(float damage, float delay, GameObject target)
    {
        while (!!target)
        { 
            target.GetComponent<MonsterController>().health -= damage;
            yield return new WaitForSeconds(delay);
        }
    }
}
