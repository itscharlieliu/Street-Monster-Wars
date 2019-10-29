using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    //U1 Components
    private GameObject p1Highlight, p2Highlight,p1Coins,p2Coins, p1RHighlight,p2RHighlight,p1ResearchTree,p2ResearchTree,p1IncomeCost,p2IncomeCost,p1HealthCost,p2HealthCost;
    private int p1Highlighted, p2Highlighted, p1RHighlighted, p2RHighlighted;
    private bool playerOneResearching, playerTwoResearching;
    private bool p1RecentPress, p2RecentPress;
    //Economy Stuff
    public int playerOneCurrency = 0;
    public int playerTwoCurrency = 0;
    public int p1IncreaseIncomeCost, p2IncreaseIncomeCost, p1RHealthCost, p2RHealthCost;
    public int playerOneIncome = 1;
    public int playerTwoIncome = 1;
    public int birdCost,oscarCost,draculaCost,bertCost;

    private float timeToPay = 1;
    private float timer;



    //Prefabs
    public GameObject bigBird,dracula,bert,oscar;

    // Start is called before the first frame update
    void Start()
    {
        p1Highlight = GameObject.Find("P1 Highlight");
        p2Highlight = GameObject.Find("P2 Highlight");
        p1RHighlight = GameObject.Find("P1 ResearchHighlight");
        p2RHighlight = GameObject.Find("P2 ResearchHighlight");
        p1IncomeCost = GameObject.Find("P1IncreaseIncome");
        p2IncomeCost = GameObject.Find("P2IncreaseIncome");
        p1HealthCost = GameObject.Find("P1BaseHealth");
        p2HealthCost = GameObject.Find("P2BaseHealth");
        p1ResearchTree = GameObject.Find("P1 Research");
        p2ResearchTree = GameObject.Find("P2 Research");
        p1Coins = GameObject.Find("P1 Coins");
        p2Coins = GameObject.Find("P2 Coins");
        playerOneResearching = false;
        playerTwoResearching = false;
        p1RecentPress = false;
        p2RecentPress = false;
        p1ResearchTree.SetActive(playerOneResearching);
        p2ResearchTree.SetActive(playerTwoResearching);
    }

    // Update is called once per frame
    void Update()
    {
        selector();
        timer += Time.deltaTime;
        if (timer >= timeToPay)
        {
            timer = 0;
            playerOneCurrency += playerOneIncome;
            playerTwoCurrency += playerTwoIncome;
        }
        p1Coins.GetComponent<Text>().text = "Coins: " + playerOneCurrency;
        p2Coins.GetComponent<Text>().text = "Coins: " + playerTwoCurrency;
        if (Input.GetKeyDown(KeyCode.W) && playerOneResearching && !p1RecentPress)
        {
            p1RecentPress = true;
            selectRP1(p1RHighlighted);
        }
        if(Input.GetKeyDown(KeyCode.W) && !playerOneResearching && !p1RecentPress)
        {
            p1RecentPress = true;
            selectP1(p1Highlighted);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && playerTwoResearching && !p2RecentPress)
        {
            p2RecentPress = true;
            selectRP2(p2RHighlighted);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) && !playerTwoResearching && !p2RecentPress)
        {
            p2RecentPress = true;
            selectP2(p2Highlighted);
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            p1RecentPress = false;
        }
        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            p2RecentPress = false;
        }
        p1ResearchTree.SetActive(playerOneResearching);
        p2ResearchTree.SetActive(playerTwoResearching);
    }
    private void selectRP1(int selected)
    {
        switch(selected)
        {
            case 0:
                if(playerOneCurrency > p1IncreaseIncomeCost)
                {
                    playerOneIncome += 1;
                    playerOneCurrency -= p1IncreaseIncomeCost;
                    p1IncreaseIncomeCost += 50;
                    p1IncomeCost.GetComponent<TextMeshProUGUI>().text = p1IncreaseIncomeCost + "";
                }
                break;
            case 1:
                if(playerOneCurrency > p1RHealthCost)
                {
                    playerOneCurrency -= p1RHealthCost;
                    GameObject.Find("P1 Base").GetComponent<MonsterController>().health += 10;
                    p1RHealthCost += 60;
                    p1HealthCost.GetComponent<TextMeshProUGUI>().text = p1RHealthCost + "";
                }
                break;
            case 2:
                p1RHighlighted = 0;
                p1RHighlight.GetComponent<RectTransform>().anchoredPosition = new Vector2(p1RHighlight.GetComponent<RectTransform>().anchoredPosition.x - 150, 110.2f);
                playerOneResearching = false;
                break;
        }
    }
    private void selectRP2(int selected)
    {
        switch (selected)
        {
            case 0:
                if (playerTwoCurrency > p2IncreaseIncomeCost)
                {
                    playerTwoIncome += 1;
                    playerTwoCurrency -= p2IncreaseIncomeCost;
                    p2IncreaseIncomeCost += 50;
                    p2IncomeCost.GetComponent<TextMeshProUGUI>().text = p2IncreaseIncomeCost + "";
                }
                break;
            case 1:
                if (playerTwoCurrency > p2RHealthCost)
                {
                    playerTwoCurrency -= p2RHealthCost;
                    GameObject.Find("P2 Base").GetComponent<MonsterController>().health += 10;
                    p2RHealthCost += 60;
                    p2HealthCost.GetComponent<TextMeshProUGUI>().text = p2RHealthCost + "";
                }
                break;
            case 2:
                p2RHighlighted = 0;
                p2RHighlight.GetComponent<RectTransform>().anchoredPosition = new Vector2(p2RHighlight.GetComponent<RectTransform>().anchoredPosition.x - 150, 110.2f);
                playerTwoResearching = false;
                break;
        }
    }
    private void selectP1(int selected)
    {
        switch(selected)
        {
            case 0:
                if(playerOneCurrency >= birdCost)
                {
                    playerOneCurrency -= birdCost;
                    GameObject temp = Instantiate(bigBird, new Vector3(-9, -3, 0), Quaternion.identity);
                    temp.tag = "MonsterP1";
                    temp.GetComponent<MonsterController>().movingRight = true;
                }
                break;
            case 1:
                if (playerOneCurrency >= oscarCost)
                {
                    playerOneCurrency -= oscarCost;
                    GameObject temp = Instantiate(oscar, new Vector3(-9, -3, 0), Quaternion.identity);
                    temp.tag = "MonsterP1";
                    temp.GetComponent<MonsterController>().movingRight = true;
                }
                break;
            case 2:
                if(playerOneCurrency >= bertCost)
                {
                    playerOneCurrency -= bertCost;
                    GameObject temp = Instantiate(bert, new Vector3(-9, -3, 0), Quaternion.identity);
                    temp.tag = "MonsterP1";
                    temp.GetComponent<MonsterController>().movingRight = true;
                }
                break;
            case 3:
                if (playerOneCurrency >= draculaCost)
                {
                    playerOneCurrency -= draculaCost;
                    GameObject temp = Instantiate(dracula, new Vector3(-9, -3, 0), Quaternion.identity);
                    temp.tag = "MonsterP1";
                    temp.GetComponent<MonsterController>().movingRight = true;
                }
                break;
            case 4:
                playerOneResearching = true;
                break;
        }
    }
    private void selectP2(int selected)
    {
        switch (selected)
        {
            case 0:
                if (playerTwoCurrency >= birdCost)
                {
                    playerTwoCurrency -= birdCost;
                    GameObject temp = Instantiate(bigBird, new Vector3(4, -3, 0), Quaternion.identity);
                    temp.tag = "MonsterP2";
                    temp.GetComponent<MonsterController>().movingRight = false;
                    temp.GetComponent<SpriteRenderer>().flipX = true;
                }
                break;
            case 1:
                if (playerTwoCurrency >= oscarCost)
                {
                    playerTwoCurrency -= oscarCost;
                    GameObject temp = Instantiate(oscar, new Vector3(4, -3, 0), Quaternion.identity);
                    temp.tag = "MonsterP2";
                    temp.GetComponent<MonsterController>().movingRight = false;
                    temp.GetComponent<SpriteRenderer>().flipX = true;
                }
                break;
            case 2:
                if (playerTwoCurrency >= bertCost)
                {
                    playerTwoCurrency -= bertCost;
                    GameObject temp = Instantiate(bert, new Vector3(4, -3, 0), Quaternion.identity);
                    temp.tag = "MonsterP2";
                    temp.GetComponent<MonsterController>().movingRight = false;
                    temp.GetComponent<SpriteRenderer>().flipX = true;
                }
                break;
            case 3:
                if (playerTwoCurrency >= draculaCost)
                {
                    playerTwoCurrency -= draculaCost;
                    GameObject temp = Instantiate(dracula, new Vector3(4, -3, 0), Quaternion.identity);
                    temp.tag = "MonsterP2";
                    temp.GetComponent<MonsterController>().movingRight = false;
                    temp.GetComponent<SpriteRenderer>().flipX = true;
                }
                break;
            case 4:
                playerTwoResearching = true;
                break;
        }
    }
    private void selector()
    {
        if(playerOneResearching)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (p1RHighlighted != 0)
                {
                    p1RHighlight.GetComponent<RectTransform>().anchoredPosition = new Vector2(p1RHighlight.GetComponent<RectTransform>().anchoredPosition.x - 75, 110.2f);
                    p1RHighlighted--;
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (p1RHighlighted != 2)
                {
                    p1RHighlight.GetComponent<RectTransform>().anchoredPosition = new Vector2(p1RHighlight.GetComponent<RectTransform>().anchoredPosition.x + 75, 110.2f);
                    p1RHighlighted++;
                }
            }
        }
        else
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
        }
        if(playerTwoResearching)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (p2RHighlighted != 0)
                {
                    p2RHighlight.GetComponent<RectTransform>().anchoredPosition = new Vector2(p2RHighlight.GetComponent<RectTransform>().anchoredPosition.x - 75, 110.2f);
                    p2RHighlighted--;
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (p2RHighlighted != 2)
                {
                    p2RHighlight.GetComponent<RectTransform>().anchoredPosition = new Vector2(p2RHighlight.GetComponent<RectTransform>().anchoredPosition.x + 75, 110.2f);
                    p2RHighlighted++;
                }
            }
        }
        else
        {
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
}
