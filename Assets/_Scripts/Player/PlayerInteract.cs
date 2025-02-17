using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public bool isEnd;
    private PlayerDameReceiver playerDameReceiver;
    [SerializeField] int apple = 0;
    [SerializeField] int banana = 0;
    [SerializeField] int cherry = 0;
    [SerializeField] int stars = 0;
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
    public void Apple(Collider2D collider)
    {
        if(collider.gameObject.tag == "Apple")
        {
            AudioManager.Instance.SoundGetCoin();
            apple++;            
            collider.gameObject.GetComponent<AnimApple>().AnimHit();
            collider.gameObject.GetComponent<Collider2D>().enabled = false;
            StartCoroutine(UnActiveCoroutine(collider));
            GameManager.Instance.ManagerOnChangeApple(apple);
        }
    }
    public void Banana(Collider2D collider)
    {
        if(collider.gameObject.tag == "Banana")
        {
            AudioManager.Instance.SoundGetCoin();
            banana++;
            collider.gameObject.GetComponent<AnimBanana>().AnimHit();
            StartCoroutine(UnActiveCoroutine(collider));
            GameManager.Instance.ManagerOnChangeBanana(banana);
        }
    }
    public void Cherry(Collider2D collider)
    {
        if(collider.gameObject.tag == "Cherry")
        {
            AudioManager.Instance.SoundGetCoin();
            cherry++;
            collider.gameObject.GetComponent<AnimCherry>().AnimHit();
            StartCoroutine(UnActiveCoroutine(collider));
            GameManager.Instance.ManagerOnChangeCherry(cherry);
        }
    }
    IEnumerator UnActiveCoroutine(Collider2D collider)
    {
        yield return new WaitForSeconds(0.25f);
        collider.gameObject.GetComponent<Collider2D>().enabled = true;
        collider.gameObject.SetActive(false);
    }
    public void CoinsEnd(Collider2D collider)
    {
        if(collider.gameObject.tag == "End")
        {
            AudioManager.Instance.SoundFinish();
            GameManager.Instance.ManagerEndChapter(apple, banana, cherry, stars);
            isEnd = true;
        }
    }
    public void Stars(Collider2D collider)
    {
        if(collider.gameObject.tag == "Stars")
        {
            AudioManager.Instance.SoundStars();
            stars++;
            collider.gameObject.GetComponent<AnimStar>().AnimHit();
            StartCoroutine(UnActiveCoroutine(collider));
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
            collider.gameObject.GetComponent<AnimHeart>().AnimHit();
            StartCoroutine(UnActiveCoroutine(collider));
            GameManager.Instance.ManagerPlayerHeartUI(playerDameReceiver.hp);
        }
    }     
    public void ResetItemUI()
    {          
        GameManager.Instance.ManagerPlayerHeartUI(playerDameReceiver.hp);
        ResetPlayerParameter();
        GameManager.Instance.ManagerOnChangeApple(apple);
        GameManager.Instance.ManagerOnChangeBanana(banana);
        GameManager.Instance.ManagerOnChangeCherry(cherry);
        GameManager.Instance.ManagerStarsUI(stars);
    }
    public void ResetPlayerParameter()
    {
        playerDameReceiver.hp = 3;
        apple = 0;
        banana = 0;
        cherry = 0;
        stars = 0;
    }  
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Apple(collision);
        Banana(collision);
        Cherry(collision);
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
