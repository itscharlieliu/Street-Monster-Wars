using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //U1 Components
    private GameObject p1Highlight, p2Highlight;
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
    }

    // Update is called once per frame
    void Update()
    {
        selector();
        timer += Time.deltaTime;
        if (timer >= timeToPay)
        {
            timer = 0;
            playerOneCurrency += 20;
            playerTwoCurrency += 20;
        }
        if(Input.GetKeyDown(KeyCode.W))
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
                    GameObject temp = Instantiate(spawnMonster, new Vector3(0, 0, 0), Quaternion.identity);
                    temp.GetComponent<SpriteRenderer>().color = new Color(0.8627f, 0.8705f, 0.2156f,1f);
                    temp.GetComponent<MonsterController>().movingRight = true;
                }
                break;
            case 1:
                if (playerOneCurrency > oscarCost)
                {
                    GameObject temp = Instantiate(spawnMonster, new Vector3(0, 0, 0), Quaternion.identity);
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
                    GameObject temp = Instantiate(spawnMonster, new Vector3(0, 0, 0), Quaternion.identity);
                    temp.GetComponent<SpriteRenderer>().color = new Color(0.8627f, 0.8705f, 0.2156f, 1f);
                    temp.GetComponent<MonsterController>().movingRight = false;
                }
                break;
            case 1:
                if (playerTwoCurrency > oscarCost)
                {
                    GameObject temp = Instantiate(spawnMonster, new Vector3(0, 0, 0), Quaternion.identity);
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
            if (p1Highlighted != 3)
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
            if (p2Highlighted != 3)
            {
                p2Highlight.GetComponent<RectTransform>().anchoredPosition = new Vector2(p2Highlight.GetComponent<RectTransform>().anchoredPosition.x + 75, -2.4f);
                p2Highlighted++;
            }
        }
    }
}
