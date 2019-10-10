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
    private void spawnBirdMonster(bool movingRight)
    {
        GameObject temp;
        if (playerOneCurrency >= cookieCost)
        {
            playerOneCurrency -= cookieCost;
            if (movingRight)
            {
                temp = Instantiate(spawnMonster, new Vector3(-7, 0, 0), Quaternion.identity);
            }
            else
            {
                temp = Instantiate(spawnMonster, new Vector3(7, 0, 0), Quaternion.identity);
            }
            temp.GetComponent<SpriteRenderer>().color = Color.yellow;
            temp.GetComponent<badMonsterController>().movingRight = movingRight;
        }
    }
    private void spawnTrashMonster(bool movingRight)
    {
        GameObject temp;
        if (playerOneCurrency >= cookieCost)
        {
            playerOneCurrency -= cookieCost;
            if(movingRight)
            {
                temp = Instantiate(spawnMonster, new Vector3(-7, 0, 0), Quaternion.identity);
            }
            else
            {
                temp = Instantiate(spawnMonster, new Vector3(7, 0, 0), Quaternion.identity);
            }
            temp.GetComponent<SpriteRenderer>().color = Color.green;
            temp.GetComponent<badMonsterController>().movingRight = movingRight;
        }
    }
    public void spawnMonsterSelectorP1(int select)
    {
        switch(select)
        {
            case 0: //oscar trash
                spawnTrashMonster(true);
                break;
            case 1: //big bird
                spawnBirdMonster(true);
                break;
            case 2: //count dracula
                break;
            case 3: //bert
                break;
            default:
                break;
        }
    }
    public void spawnMonsterSelectorP2(int select)
    {
        switch (select)
        {
            case 0: //oscar trash
                spawnTrashMonster(false);
                break;
            case 1: //big bird
                spawnBirdMonster(false);
                break;
            case 2: //count dracula
                break;
            case 3: //bert
                break;
            default:
                break;
        }
    }
}
