using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerOneCurrency = 0;
    public int cookieCost;
    public GameObject spawnMonster;
    private float timeToPay = 1;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeToPay)
        {
            timer = 0;
            playerOneCurrency += 20;
        }
    }
    public void spawnCookieMonster()
    {
        if (playerOneCurrency >= cookieCost)
        {
            playerOneCurrency -= cookieCost;
            Instantiate(spawnMonster, new Vector3(-7, 0, 0), Quaternion.identity);
        }
    }
}
