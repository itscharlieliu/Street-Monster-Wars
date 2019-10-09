using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badMonsterController : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x + speed, this.transform.position.y, this.transform.position.z);
        if(this.transform.position.x > 12)
        {
            Destroy(this.gameObject);
        }
    }
}
