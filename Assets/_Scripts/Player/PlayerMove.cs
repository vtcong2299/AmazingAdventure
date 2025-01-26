using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : Singleton<PlayerMove>
{
    private Rigidbody2D rb2D;
    [SerializeField]
    private GameObject player;
    private GameObject startPos;
    private PlayerDameReceiver playerDameReceiver;
    private PlayerAnimatorManager playerAnimatorManager;
    private PlayerVsItem playerVsItem;
    [SerializeField]
    private float pressHorizontal;
    private Vector3 startTranform;
    [SerializeField]
    private bool clickJump;
    [SerializeField]
    private float speed = 1.75f;
    [SerializeField]
    private float speedAndroid = 12f;
    [SerializeField]
    private float powerJump = 3.2f;
    [SerializeField]
    private float backJumpEnemy = 4f;
    [SerializeField]
    private float backJumps = 2f;
    [SerializeField]
    private bool isBackJump;
    [SerializeField]
    private bool isPressLeft;
    [SerializeField]
    private bool isPressRight;
    [SerializeField]
    private bool facingRight = true;
    [SerializeField]
    private bool maybeJump;
    [SerializeField]
    private bool wallJump;
    [SerializeField]
    private bool doubleJump;
    [SerializeField]
    private Transform posJump;
    [SerializeField]
    private Transform posInWall;
    [SerializeField]
    private LayerMask layerJump;
    [SerializeField]
    private LayerMask layerWall;
    public void StartPlayer()
    {
        rb2D = GetComponent<Rigidbody2D>();
        playerDameReceiver = GetComponent<PlayerDameReceiver>();
        playerAnimatorManager = GetComponent<PlayerAnimatorManager>();
        playerVsItem = GetComponent<PlayerVsItem>();
        rb2D.freezeRotation =true;
    }
    public void SetStratPos()
    {
        startPos = GameObject.Find("StartPos");
        transform.position = new Vector3(startPos.transform.position.x, startPos.transform.position.y + 0.3f, startPos.transform.position.z);
        startTranform = transform.position;
    }
    private void Update()
    {        
        CheckFace();
        if (GameManager.instance.isPlayPC)
        {
            PlayOnPC();
        }
        else
        {
            PLayOnAndroid();
        }
        CheckDrop();
    }
    public void PlayOnPC()
    {
        CtrlPC();
        MovePlayer();
        PlayerJump();
    }
    public void PLayOnAndroid()
    {
        MoveByButton();
        MovePlayer();
        CheckJump();
    }
    public void CheckDrop()
    {
        if (rb2D.velocity.y < 0 )
        {
            playerAnimatorManager.SetFall();
        }
        else
        {
            playerAnimatorManager.SetNotFall();
        }
    }
    public void CtrlPC()
    {
        this.pressHorizontal = Input.GetAxisRaw("Horizontal");
    }
    public void MovePlayer()
    {
        if (playerVsItem.isEnd == true)
        {
            pressHorizontal = 0f;
            rb2D.velocity = new Vector2(0, rb2D.velocity.y); ;
            return;
        }
        if (!isBackJump)
        {            
            rb2D.velocity = new Vector2(pressHorizontal * speed, rb2D.velocity.y);
        }   
    }
    public void JumpBackHitEnemy(Collider2D collision)
    {
        isBackJump = true;
        if (rb2D.velocity.y > 0f)
        {
            Vector2 knockbackDirection = new Vector2(0f, -2f).normalized;
            rb2D.AddForce(knockbackDirection * backJumpEnemy, ForceMode2D.Impulse);
        }
        else
        {
            if (facingRight)
            {
                Vector2 knockbackDirection = new Vector2(-0f, 2f).normalized;
                rb2D.AddForce(knockbackDirection * backJumpEnemy, ForceMode2D.Impulse);
            }
            else
            {
                Vector2 knockbackDirection = new Vector2(0f, 2f).normalized;
                rb2D.AddForce(knockbackDirection * backJumpEnemy, ForceMode2D.Impulse);
            }
        }
        StartCoroutine(ResetKnockback());
    }
    private IEnumerator ResetKnockback()
    {
        yield return new WaitForSeconds(0.5f); 
        isBackJump = false; 
    }
    public void JumpBackAfterHit(Collision2D collision)
    {
        isBackJump = true;
        if (rb2D.velocity.y > 0f)
        {
            Vector2 knockbackDirection = new Vector2(0f, -3f).normalized;
            rb2D.AddForce(knockbackDirection * backJumps, ForceMode2D.Impulse);
        }
        else
        { 
            if (facingRight)
            {
                Vector2 knockbackDirection = new Vector2(-1f, 2f).normalized;
                rb2D.AddForce(knockbackDirection * backJumps, ForceMode2D.Impulse);
            }
            else
            {
                Vector2 knockbackDirection = new Vector2(1f, 2f).normalized;
                rb2D.AddForce(knockbackDirection * backJumps, ForceMode2D.Impulse);
            }
        }
        StartCoroutine(ResetKnockback());
    }
    public void MoveByButton()
    {
        if (isPressLeft)
        {
            pressHorizontal -= Time.fixedDeltaTime * speedAndroid;
            pressHorizontal = Mathf.Clamp(pressHorizontal, -1f, 0f);
        }
        else if (isPressRight)
        {
            pressHorizontal += Time.fixedDeltaTime * speedAndroid;
            pressHorizontal = Mathf.Clamp(pressHorizontal, 0f, 1f);
        }
        else
        {
            pressHorizontal = 0f;
        }
    }
    public void NoPressLeftRight()
    {
        isPressRight = false;
        isPressLeft = false;
    }   
    public void PressLeft()
    {
        isPressLeft = true;
    }
    public void PressRight()
    {
        isPressRight = true;
    }
    public void PlayerJump() //Nhay bang space
    {
        maybeJump = Physics2D.OverlapCircle(posJump.position, 0.1f, layerJump);
        wallJump = Physics2D.OverlapCircle(posInWall.position, 0.1f, layerWall);
        if ((maybeJump && !Input.GetKey(KeyCode.Space)) || (wallJump && !Input.GetKey(KeyCode.Space)))
        {
            doubleJump = false;
        }
        if (wallJump)
        {
            rb2D.drag = 10f;
        }
        else
        {
            rb2D.drag = 0f;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (maybeJump || doubleJump || wallJump)
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, powerJump);
                if (!doubleJump)
                {
                    playerAnimatorManager.SetJump();
                }
                else
                {
                    playerAnimatorManager.SetDoubleJump();
                }
                doubleJump = !doubleJump;
            }
        }
    }
    private void CheckJump() //Nhay bang button
    {
        maybeJump = Physics2D.OverlapCircle(posJump.position, 0.1f, layerJump);
        wallJump = Physics2D.OverlapCircle(posInWall.position, 0.1f, layerWall);        
        if ((maybeJump && !clickJump) || wallJump && !clickJump)
        {
            doubleJump = false;
        }
        if (wallJump)
        {
            rb2D.drag = 7f;
        }
        else
        {
            rb2D.drag = 0f;
        }
    }
    public void ClickJump()
    {
        clickJump = true;
        if (maybeJump || doubleJump || wallJump)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, powerJump);
            if (!doubleJump)
            {
                playerAnimatorManager.SetJump();
            }
            else
            {
                playerAnimatorManager.SetDoubleJump();
            }
            doubleJump = !doubleJump;
        }
    }
    public void NotClickJump()
    {
        clickJump = false; 
    }

    public void CheckFace()
    {
        if (this.pressHorizontal != 0)
        {
            playerAnimatorManager.SetIsRun();
        }
        else
        {
            playerAnimatorManager.SetNotRun();
        }
        if (this.pressHorizontal < 0 && facingRight && Time.timeScale!=0)
        {
            Flip();
        }
        if (this.pressHorizontal > 0 && !facingRight && Time.timeScale != 0)
        {
            Flip();
        }
    }
    public void BackCheckPoint()
    {
            StartCoroutine(ExampleCoroutine());
    }
    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(0.3f);
        transform.position = startTranform;
        playerVsItem.ResetItemUI();
        GameManager.instance.ResetObj();
        CameraFollow.instance.ResetCamera();
        playerVsItem.isEnd = false;
        playerAnimatorManager.SetNotDead();    
    }    
    public void Flip()
    {
        Vector3 curDirection = transform.right;
        curDirection = -1 * curDirection;
        transform.right = curDirection;
        facingRight = !facingRight;
    }  
    public void CheckParent(Collision2D collision)
    {
        if (collision.gameObject.tag == "Flatform")
        {
            transform.SetParent(collision.transform);
        }
    }
    public void CheckOutParent(Collision2D collision)
    {
        if (collision.gameObject.tag == "Flatform" && collision.gameObject.activeSelf && player.gameObject.activeSelf)
        {
            transform.SetParent(player.transform);
        }        
    }    
    private void OnCollisionExit2D(Collision2D collision)
    {
        playerAnimatorManager.SetNotInGround(collision);
        playerAnimatorManager.SetNotInWall(collision);
        if (player != null && collision !=null )
        {
            CheckOutParent(collision);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        playerAnimatorManager.SetInGround(collision);
        playerAnimatorManager.SetInWall(collision);
        CheckParent(collision);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartPoint.instance.SetPushIn(collision);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EndPoint.instance.SetEnd(collision);
    }
}
