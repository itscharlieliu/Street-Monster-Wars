using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //U1 Components
    private GameObject p1Highlight, p2Highlight,p1Coins,p2Coins;
    private int p1Highlighted, p2Highlighted;

    //Economy Stuff
    public int playerOneCurrency = 0;
    public int playerTwoCurrency = 0;
    public int birdCost,oscarCost,draculaCost,bertCost;

    private float timeToPay = 1;
    private float timer;



    //Prefabs
    public GameObject spawnMonster;

    // Start is called before the first frame update
    void Start()
    {
        p1Highlight = GameObject.Find("P1 Highlight");
        p2Highlight = GameObject.Find("P2 Highlight");
        p1Coins = GameObject.Find("P1 Coins");
        p2Coins = GameObject.Find("P2 Coins");
    }

    // Update is called once per frame
    void Update()
    {
        selector();
        timer += Time.deltaTime;
        if (timer >= timeToPay)
        {
            timer = 0;
            playerOneCurrency += 1;
            playerTwoCurrency += 1;
        }
        p1Coins.GetComponent<Text>().text = "Coins: " + playerOneCurrency;
        p2Coins.GetComponent<Text>().text = "Coins: " + playerTwoCurrency;
        if (Input.GetKeyDown(KeyCode.W))
        {
            spawnMonsterP1(p1Highlighted);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            spawnMonsterP2(p2Highlighted);
        }
    }
    private void spawnMonsterP1(int selected)
    {
        switch(selected)
        {
            case 0:
                if(playerOneCurrency > birdCost)
                {
                    playerOneCurrency -= birdCost;
                    GameObject temp = Instantiate(spawnMonster, new Vector3(-9, 0, 0), Quaternion.identity);
                    temp.tag = "MonsterP1";
                    temp.GetComponent<MonsterController>().maxHealth *= 2;
                    temp.GetComponent<MonsterController>().speed *= 0.5f;
                    temp.GetComponent<MonsterController>().attack *= 0.75f;
                    temp.GetComponent<SpriteRenderer>().color = new Color(0.8627f, 0.8705f, 0.2156f,1f);
                    temp.GetComponent<MonsterController>().movingRight = true;
                }
                break;
            case 1:
                if (playerOneCurrency > oscarCost)
                {
                    playerOneCurrency -= oscarCost;
                    GameObject temp = Instantiate(spawnMonster, new Vector3(-9, 0, 0), Quaternion.identity);
                    temp.tag = "MonsterP1";
                    temp.GetComponent<SpriteRenderer>().color = new Color(0.1647f, 0.4862f, 0.2431f, 1f);
                    temp.GetComponent<MonsterController>().movingRight = true;
                }
                break;
        }
    }
    private void spawnMonsterP2(int selected)
    {
        switch (selected)
        {
            case 0:
                if (playerTwoCurrency > birdCost)
                {
                    playerTwoCurrency -= birdCost;
                    GameObject temp = Instantiate(spawnMonster, new Vector3(4, 0, 0), Quaternion.identity);
                    temp.tag = "MonsterP2";
                    temp.GetComponent<MonsterController>().maxHealth *= 2;
                    temp.GetComponent<MonsterController>().speed *= 0.5f;
                    temp.GetComponent<MonsterController>().attack *= 0.75f;
                    temp.GetComponent<SpriteRenderer>().color = new Color(0.8627f, 0.8705f, 0.2156f, 1f);
                    temp.GetComponent<MonsterController>().movingRight = false;
                }
                break;
            case 1:
                if (playerTwoCurrency > oscarCost)
                {
                    playerTwoCurrency -= oscarCost;
                    GameObject temp = Instantiate(spawnMonster, new Vector3(4, 0, 0), Quaternion.identity);
                    temp.tag = "MonsterP2";
                    temp.GetComponent<SpriteRenderer>().color = new Color(0.1647f, 0.4862f, 0.2431f, 1f);
                    temp.GetComponent<MonsterController>().movingRight = false;
                }
                break;
        }
    }
    private void selector()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (p1Highlighted != 0)
            {
                p1Highlight.GetComponent<RectTransform>().anchoredPosition = new Vector2(p1Highlight.GetComponent<RectTransform>().anchoredPosition.x - 75, 298f);
                p1Highlighted--;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (p1Highlighted != 4)
            {
                p1Highlight.GetComponent<RectTransform>().anchoredPosition = new Vector2(p1Highlight.GetComponent<RectTransform>().anchoredPosition.x + 75, 298f);
                p1Highlighted++;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (p2Highlighted != 0)
            {
                p2Highlight.GetComponent<RectTransform>().anchoredPosition = new Vector2(p2Highlight.GetComponent<RectTransform>().anchoredPosition.x - 75, -2.4f);
                p2Highlighted--;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (p2Highlighted != 4)
            {
                p2Highlight.GetComponent<RectTransform>().anchoredPosition = new Vector2(p2Highlight.GetComponent<RectTransform>().anchoredPosition.x + 75, -2.4f);
                p2Highlighted++;
            }
        }
    }
}
