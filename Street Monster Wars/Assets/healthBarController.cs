using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBarController : MonoBehaviour
{
    private GameObject obj;
    private GameObject healthBar;
    // Start is called before the first frame update
    void Start()
    {
        obj = this.transform.parent.gameObject;
        healthBar = this.transform.Find("Bar Anchor").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float percent = obj.GetComponent<MonsterController>().health / obj.GetComponent<MonsterController>().maxHealth;
        healthBar.transform.localScale = new Vector3(percent, 1, 1);
    }
}
