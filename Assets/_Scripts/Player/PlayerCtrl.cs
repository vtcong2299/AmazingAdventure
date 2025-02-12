using System.Collections;
using UnityEngine;

public class PlayerCtrl : Singleton<PlayerCtrl>
{
    private Rigidbody2D rb2D;
    [SerializeField] GameObject player;
    [SerializeField] float pressHorizontal;
    [SerializeField] float speed = 1.75f;
    [SerializeField] float powerJump = 3.2f;
    [SerializeField] float backJumps = 3f;
    [SerializeField] LayerMask layerGround;
    [SerializeField] LayerMask layerWall;
    GameObject startPos;
    public PlayerDameReceiver playerDameReceiver;
    PlayerAnimatorManager playerAnimatorManager;
    public PlayerInteract playerInteract;
    Vector3 startTranform;
    [SerializeField] bool isBackJump;
    bool isFacingRight = true;
    bool maybeJump;
    bool wallJump;
    bool doubleJump;
    bool clickJump;
    public bool isBackPoint = false;
    [SerializeField] Vector3 offsetWithStartPos;

    public void StartPlayer()
    {
        rb2D = GetComponent<Rigidbody2D>();
        playerAnimatorManager = GetComponent<PlayerAnimatorManager>();
        playerInteract = GetComponent<PlayerInteract>();
        playerDameReceiver = GetComponent<PlayerDameReceiver>();
        rb2D.freezeRotation = true;
    }

    public void SetStartPos()
    {
        startPos = GameObject.Find("StartPos");
        transform.position = startPos.transform.position + offsetWithStartPos;
        startTranform = transform.position;
    }

    private void Update()
    {
        CheckFace();
        CheckJump();
        ModeCtrl(GameManager.Instance.isPlayMobile);
        
        CheckFall();
        playerAnimatorManager.SetInGround(maybeJump);
        playerAnimatorManager.SetInWall(wallJump);
    }

    public void ModeCtrl(bool onMobile)
    {
        if (onMobile)
        {
            MoveByButton();
            MovePlayer();
            JumpOnMobile();
        }
        else
        {
            CtrlPC();
            MovePlayer();
            JumpOnPC();
        }
    }

    public void CheckFall()
    {
        playerAnimatorManager.SetFall(rb2D.velocity.y < 0);
    }

    public void CtrlPC()
    {
        this.pressHorizontal = Input.GetAxisRaw("Horizontal");
    }

    public void MovePlayer()
    {
        if (playerInteract.isEnd == true)
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

    void SetIsBackJumpFalse()
    {
        isBackJump = false;
    }

    public void JumpBack(Collision2D collision)
    {
        isBackJump = true;
        if (rb2D.velocity.y > 0f)
        {
            Vector2 knockbackDirection = new Vector2(0f, -3f).normalized;
            rb2D.AddForce(knockbackDirection * backJumps, ForceMode2D.Impulse);
        }
        else
        {
            if (isFacingRight)
            {
                Vector2 knockbackDirection = new Vector2(0, 2f).normalized;
                rb2D.AddForce(knockbackDirection * backJumps, ForceMode2D.Impulse);
            }
            else
            {
                Vector2 knockbackDirection = new Vector2(0, 2f).normalized;
                rb2D.AddForce(knockbackDirection * backJumps, ForceMode2D.Impulse);
            }
        }
        Invoke("SetIsBackJumpFalse", 0.5f);
    }

    public void MoveByButton()
    {
        pressHorizontal = Joystick.Instance.Horizontal();
    }
    public void JumpOnPC() // Nhảy bằng space
    {
        if ((maybeJump && (!Input.GetKey(KeyCode.Space))) || (wallJump && (!Input.GetKey(KeyCode.Space))))
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

    private void JumpOnMobile() // Nhảy bằng button
    {        
        if ((maybeJump && !clickJump) || wallJump && !clickJump)
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
    }
    void CheckJump()
    {
        Vector2 leftRayOrigin = new Vector2(transform.position.x - 0.1f, transform.position.y);
        Vector2 rightRayOrigin = new Vector2(transform.position.x + 0.1f, transform.position.y);
        RaycastHit2D hitGroundLeft = Physics2D.Raycast(leftRayOrigin, Vector2.down, 0.2f, layerGround);
        RaycastHit2D hitGroundRight = Physics2D.Raycast(rightRayOrigin, Vector2.down, 0.2f, layerGround);
        maybeJump = hitGroundLeft.collider != null || hitGroundRight.collider != null;
        Debug.DrawRay(leftRayOrigin, Vector2.down * 0.2f, Color.green);
        Debug.DrawRay(rightRayOrigin, Vector2.down * 0.2f, Color.green);


        Vector2 direction = isFacingRight ? Vector2.right : Vector2.left;
        RaycastHit2D hitWall = Physics2D.Raycast(transform.position, direction, 0.15f, layerWall);
        wallJump = hitWall.collider != null;
        Debug.DrawRay(transform.position, direction * 0.15f, Color.green);
    }
    public void ClickJumpButton()
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

    public void NotClickJumpButton()
    {
        clickJump = false;
    }

    public void CheckFace()
    {
        if (this.pressHorizontal != 0)
        {
            playerAnimatorManager.SetIsRun(true);
        }
        else
        {
            playerAnimatorManager.SetIsRun(false);
        }
        if (this.pressHorizontal < 0 && isFacingRight && Time.timeScale != 0)
        {
            Flip();
        }
        if (this.pressHorizontal > 0 && !isFacingRight && Time.timeScale != 0)
        {
            Flip();
        }
    }

    public void BackCheckPoint()
    {
        Invoke("BackPoint", 0.3f);
    }
    void BackPoint()
    {
        transform.position = startTranform;
        playerInteract.ResetItemUI();
        GameManager.Instance.ResetObjInMap();
        CameraFollow.Instance.ResetCamera();
        playerInteract.isEnd = false;
        playerAnimatorManager.SetBackCheckPoint();
    }
    public void SetIsBackPointFalse()
    {
        isBackPoint = false;
    }
    public void Flip()
    {
        Vector3 curDirection = transform.right;
        curDirection = -1 * curDirection;
        transform.right = curDirection;
        isFacingRight = !isFacingRight;
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
            transform.SetParent(null);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (player != null && collision != null)
        {
            CheckOutParent(collision);
        }
        StartPoint.instance.SetPushOut(collision);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
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
