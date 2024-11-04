using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerVsItem : MonoBehaviour
{
    public PlayerDameReceiver playerDameReceiver;
    public static PlayerVsItem instance;
    public GameObject[] listCoins;
    public GameObject[] listStars;
    public GameObject[] listHearts;
    public GameObject[] listEnemy;
    public int coins = 0;
    public int stars = 0;
    public bool isEnd;
    private void Start()
    {
        playerDameReceiver = GetComponent<PlayerDameReceiver>();
        UIManager.instance.StarsUI(stars);
    }
    private void OnEnable()
    {
        instance = this;
    }
    private void OnDisable()
    {
        instance = null;
    }
    public void HeadEnemy(Collider2D collider)
    {
        if( collider.gameObject.tag == "HeadEnemy")
        {
            AnimationMushroom.instance.MushroomHit();
            StartCoroutine(ExampleCoroutine());
        }
    }
    IEnumerator ExampleCoroutine()
    {
            yield return new WaitForSeconds(0.3f);
        Destroy(GetComponent<Collider>().gameObject);
    }
    public void Coins(Collider2D collider)
    {
        if(collider.gameObject.tag == "Coins")
        {
            coins++;
            collider.gameObject.SetActive(false);
            UIManager.instance.OnChangeCoins(coins);
        }
    }
    public void CoinsEnd(Collider2D collider)
    {
        if(collider.gameObject.tag == "End")
        {
            UIManager.instance.CheckEndChapter(coins);
            UIManager.instance.StarsUIEnd(stars);
            isEnd = true;
        }
    }
    public void Stars(Collider2D collider)
    {
        if(collider.gameObject.tag == "Stars")
        {
            stars++;
            collider.gameObject.SetActive(false);
            UIManager.instance.StarsUI(stars);
        }
    }
    public void Heart(Collider2D collider)
    {
        if(collider.gameObject.tag == "Heart")
        {
            playerDameReceiver.hp++;
            if(playerDameReceiver.hp >=3)
            {
                playerDameReceiver.hp = 3;
            }
            collider.gameObject.SetActive(false);
            UIManager.instance.HeartUI(playerDameReceiver.hp);   
        }
    }    
    public void ResetEnemy()
    {
        foreach (GameObject enemy in listEnemy)
        {
            enemy.SetActive(true);
        }
    }
    public void ResetItem()
    {
        foreach (GameObject coin in listCoins)
        {
            coin.SetActive(true);
        }
        foreach (GameObject star in listStars)
        {
            star.SetActive(true);
        }
        foreach (GameObject heart in listHearts)
        {
            heart.SetActive(true);
        }
        UIManager.instance.HeartUI(playerDameReceiver.hp);
        ResetPlayerParameter(); 
        UIManager.instance.OnChangeCoins(coins);
        UIManager.instance.StarsUI(stars);
    }
    public void ResetPlayerParameter()
    {
        playerDameReceiver.hp = 3;
        coins = 0;
        stars = 0;
    }  
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Coins(collision);
        Stars(collision);
        Heart(collision);
        CoinsEnd(collision);
    }    
}
