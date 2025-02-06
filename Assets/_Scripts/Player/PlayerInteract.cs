using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public bool isEnd;
    private PlayerDameReceiver playerDameReceiver;
    [SerializeField]
    private int coins = 0;
    [SerializeField]
    private int stars = 0;
    [SerializeField] LayerMask layerEnemy;
    public bool hasEnemy;
    private void Awake()
    {
        playerDameReceiver = GetComponent<PlayerDameReceiver>();
    }
    private void Start()
    {
        GameManager.Instance.ManagerStarsUI(stars);
    }
    private void Update()
    {
        CheckHitEnemy();
    }
    public void Coins(Collider2D collider)
    {
        if(collider.gameObject.tag == "Coins")
        {
            AudioManager.Instance.SoundGetCoin();
            coins++;
            collider.gameObject.SetActive(false);
            GameManager.Instance.ManagerOnChangeCoins(coins);
        }
    }
    public void CoinsEnd(Collider2D collider)
    {
        if(collider.gameObject.tag == "End")
        {
            AudioManager.Instance.SoundFinish();
            GameManager.Instance.ManagerEndChapter(coins, stars);
            isEnd = true;
        }
    }
    public void Stars(Collider2D collider)
    {
        if(collider.gameObject.tag == "Stars")
        {
            AudioManager.Instance.SoundStars();
            stars++;
            collider.gameObject.SetActive(false);
            GameManager.Instance.ManagerStarsUI(stars);
        }
    }
    public void Heart(Collider2D collider)
    {
        if(collider.gameObject.tag == "Heart")
        {
            AudioManager.Instance.SoundGetHp();
            playerDameReceiver.hp++;
            if(playerDameReceiver.hp >=3)
            {
                playerDameReceiver.hp = 3;
            }
            collider.gameObject.SetActive(false);
            GameManager.Instance.ManagerPlayerHeartUI(playerDameReceiver.hp);
        }
    }     
    public void ResetItemUI()
    {          
        GameManager.Instance.ManagerPlayerHeartUI(playerDameReceiver.hp);
        ResetPlayerParameter();
        GameManager.Instance.ManagerOnChangeCoins(coins);
        GameManager.Instance.ManagerStarsUI(stars);
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
    void CheckHitEnemy()
    {
        Vector2 leftRayOrigin = new Vector2(transform.position.x - 0.08f, transform.position.y);
        Vector2 rightRayOrigin = new Vector2(transform.position.x + 0.08f, transform.position.y);
        RaycastHit2D hitLeft = Physics2D.Raycast(leftRayOrigin, Vector2.down, 0.2f, layerEnemy);
        RaycastHit2D hitRight = Physics2D.Raycast(rightRayOrigin, Vector2.down, 0.2f, layerEnemy);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.2f, layerEnemy);
        if (hit.collider || hitLeft.collider || hitRight.collider)
        {
            hasEnemy = true;
        }
        else
        {
            hasEnemy = false;
        }
        Debug.DrawRay(transform.position, Vector2.down * 0.2f, Color.green);
    }
}
