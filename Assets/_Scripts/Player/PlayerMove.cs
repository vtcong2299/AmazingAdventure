using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public static PlayerMove instance;
    public GameObject Player;
    public GameObject startPos;
    public PlayerDameReceiver playerDameReceiver;
    public PlayerVsItem playerVsItem;
    public float pressHorizontal;
    public float speed = 1.75f;
    public float powerJump = 3.2f;
    public float backJump = 3.2f;
    public Vector3 checkPointTranform;
    public int countJump=0;
    //public float powerBack = 2f;
    [SerializeField]
    private bool facingRight = true;
    [SerializeField]
    private bool maybeJump;
    [SerializeField]
    private bool wallJump;
    private bool doubleJump;
    [SerializeField]
    private Transform posJump;
    [SerializeField]
    private Transform posInWall;
    [SerializeField]
    private LayerMask layerJump;
    [SerializeField]
    private LayerMask layerWall;
    private void Start()
    {
        Player = GameObject.Find("Player");
        startPos = GameObject.Find("StartPos");
        rb2D = GetComponent<Rigidbody2D>();
        playerDameReceiver = GetComponent<PlayerDameReceiver>();
        playerVsItem = GetComponent<PlayerVsItem>();
        rb2D.freezeRotation =true;
        transform.position =new Vector3 (startPos.transform.position.x, startPos.transform.position.y +0.3f, startPos.transform.position.z);
        checkPointTranform = transform.position;
    }
    private void OnEnable()
    {
        instance = this;
    }
    private void OnDisable()
    {
        instance = null;
    }
    private void Update()
    {        
        CheckFace();
        MovePlayer();
        PlayerJump(); //PC
        //CheckJump(); //Android
        CheckDrop();
    }
    public void CheckDrop()
    {
        if (rb2D.velocity.y < 0 )
        {
            PlayerAnimatorManager.instance.SetFall();
        }
        else
        {
            PlayerAnimatorManager.instance.SetNotFall();
        }
    }
    public void MovePlayer()
    {
        if (playerVsItem.isEnd == true)
        {
            pressHorizontal = 0f;
            return;
        }
        this.pressHorizontal = Input.GetAxisRaw("Horizontal");
        rb2D.velocity = new Vector2(pressHorizontal * speed, rb2D.velocity.y);
    }
    public void HitMoveEnemy(Collider2D collision)
    {
        if (facingRight)
        {
            Vector2 knockbackDirection = new Vector2(-1f, 1f).normalized;
            rb2D.AddForce(knockbackDirection * backJump, ForceMode2D.Impulse);
        }
        else
        {
            Vector2 knockbackDirection = new Vector2(1f, 1f).normalized;
            rb2D.AddForce(knockbackDirection * backJump, ForceMode2D.Impulse);
        }
    }
    public void NoPressLeftRight()
    {
        pressHorizontal = 0f;
    }   
    public void PressLeft()
    {
        this.pressHorizontal = -1;
    }
    public void PressRight()
    {
        this.pressHorizontal = 1;
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
                    PlayerAnimatorManager.instance.SetJump();
                }
                else
                {
                    PlayerAnimatorManager.instance.SetDoubleJump();
                }
                doubleJump = !doubleJump;
            }
        }
    }
    //private void CheckJump() //Nhay bang button
    //{
    //    maybeJump = Physics2D.OverlapCircle(posJump.position, 0.1f, layerJump);
    //    wallJump = Physics2D.OverlapCircle(posInWall.position, 0.1f, layerWall);
    //    if ((maybeJump&& countJump == 0) || wallJump && countJump == 0)
    //    {
    //        doubleJump = false;
    //    }        
    //    if (wallJump)
    //    {
    //        rb2D.drag = 7f;
    //    }
    //    else
    //    {
    //        rb2D.drag = 0f;
    //    }
    //}
    //public void ClickJump()
    //{
    //    if (maybeJump || doubleJump || wallJump)
    //    {
    //        rb2D.velocity = new Vector2(rb2D.velocity.x, powerJump);
    //        if (!doubleJump)
    //        {
    //            PlayerAnimatorManager.instance.SetJump();
    //            countJump++;
    //        }
    //        else
    //        {
    //            PlayerAnimatorManager.instance.SetDoubleJump();
    //        }
    //        doubleJump = !doubleJump;
    //    }
    //}
    public void CheckFace()
    {
        if (this.pressHorizontal != 0)
        {
            PlayerAnimatorManager.instance.SetIsRun();
        }
        else
        {
            PlayerAnimatorManager.instance.SetNotRun();
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
        transform.position = checkPointTranform;
        playerVsItem.ResetItem();
        playerVsItem.ResetEnemy();
        CameraFollow.instance.ResetCamera();
        playerVsItem.isEnd = false;
        PlayerAnimatorManager.instance.SetNotDead();    
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
            transform.parent = collision.transform;
        }
    }
    public void CheckOutParent(Collision2D collision)
    {
        if (collision.gameObject.tag == "Flatform")
        {
            transform.parent = Player.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        PlayerAnimatorManager.instance.SetNotInGround(collision);
        PlayerAnimatorManager.instance.SetNotInWall(collision);
        if (Player != null)
        {
            CheckOutParent(collision);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        PlayerAnimatorManager.instance.SetInGround(collision);
        PlayerAnimatorManager.instance.SetInWall(collision);
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
