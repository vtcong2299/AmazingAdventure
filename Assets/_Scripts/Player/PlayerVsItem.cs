using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVsItem : MonoBehaviour
{
    public bool isEnd;
    private PlayerDameReceiver playerDameReceiver;
    [SerializeField]
    private int coins = 0;
    [SerializeField]
    private int stars = 0;
    public AudioSource audioSource;
    public AudioClip itemClip;
    public AudioClip endClip;
    public AudioClip hitClip;
    public AudioClip deadClip;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();  
        playerDameReceiver = GetComponent<PlayerDameReceiver>();
    }
    private void Start()
    {
        GameManager.instance.ManagerStarsUI(stars);
    }
    public void Coins(Collider2D collider)
    {
        if(collider.gameObject.tag == "Coins")
        {
            audioSource.clip = itemClip;
            audioSource.Play();
            coins++;
            collider.gameObject.SetActive(false);
            GameManager.instance.ManagerOnChangeCoins(coins);
        }
    }
    public void CoinsEnd(Collider2D collider)
    {
        if(collider.gameObject.tag == "End")
        {
            audioSource.clip = endClip;
            audioSource.Play();
            GameManager.instance.ManagerEndChapter(coins, stars);
            isEnd = true;
        }
    }
    public void Stars(Collider2D collider)
    {
        if(collider.gameObject.tag == "Stars")
        {
            audioSource.clip = itemClip;
            audioSource.Play();
            stars++;
            collider.gameObject.SetActive(false);
            GameManager.instance.ManagerStarsUI(stars);
        }
    }
    public void Heart(Collider2D collider)
    {
        if(collider.gameObject.tag == "Heart")
        {
            audioSource.clip = itemClip;
            audioSource.Play();
            playerDameReceiver.hp++;
            if(playerDameReceiver.hp >=3)
            {
                playerDameReceiver.hp = 3;
            }
            collider.gameObject.SetActive(false);
            GameManager.instance.ManagerPlayerHeartUI(playerDameReceiver.hp);
        }
    }     
    public void ResetItemUI()
    {          
        GameManager.instance.ManagerPlayerHeartUI(playerDameReceiver.hp);
        ResetPlayerParameter();
        GameManager.instance.ManagerOnChangeCoins(coins);
        GameManager.instance.ManagerStarsUI(stars);
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
