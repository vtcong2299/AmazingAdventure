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
    [SerializeField] GameObject startPos;
    [SerializeField] GameObject endPos;
    public PlayerDameReceiver playerDameReceiver;
    PlayerAnimatorManager playerAnimatorManager;
    public PlayerInteract playerInteract;
    Vector3 startTranform;
    [SerializeField] bool isBackJump;
    public bool isFacingRight = true;
    bool maybeJump;
    bool wallJump;
    bool doubleJump;
    bool clickJump;
    public bool isBackPoint = false;
    [SerializeField] Vector3 offsetWithStartPos;

    private Transform currentPlatform;
    private Vector3 lastPlatformPosition;

    public GameObject ninjaFrog;
    public GameObject maskDude;
    public GameObject pinkMan;
    public GameObject virtualGuy;

    [SerializeField] float lengRaycastX = 0.12f;
    [SerializeField] float lengRaycastY = 0.2f;

    [SerializeField] LayerMask layerPlatform;
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
        ModeCtrl(DataManager.Instance.gameData.isPlayOnMobile);

        CheckFall();
        playerAnimatorManager.SetInGround(maybeJump);
        playerAnimatorManager.SetInWall(wallJump);

        SetPositionInPlatform();
        CheckGroundForPlatform();
    }

    public void ModeCtrl(bool onMobile)
    {
        if (onMobile)
        {
            CheckTouchInput();
            MoveByButton();
            JumpOnMobile();
        }
        else
        {
            CtrlPC();
            JumpOnPC();
        }
        MovePlayer();
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

    public void JumpBack(Collision2D collision, bool enemy)
    {
        isBackJump = true;
        if (enemy)
        {
            Vector2 knockbackDirection = new Vector2(0f, 4f).normalized;
            rb2D.AddForce(knockbackDirection * backJumps, ForceMode2D.Impulse);
        }
        else if (rb2D.velocity.y > 0f)
        {
            Vector2 knockbackDirection = new Vector2(0f, -3f).normalized;
            rb2D.AddForce(knockbackDirection * backJumps, ForceMode2D.Impulse);
        }
        else
        {
            if (isFacingRight)
            {
                Vector2 knockbackDirection = new Vector2(-1, 3f).normalized;
                rb2D.AddForce(knockbackDirection * backJumps, ForceMode2D.Impulse);
            }
            else
            {
                Vector2 knockbackDirection = new Vector2(1, 3f).normalized;
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
        RaycastHit2D hitGroundLeft = Physics2D.Raycast(leftRayOrigin, Vector2.down, lengRaycastY, layerGround);
        RaycastHit2D hitGroundRight = Physics2D.Raycast(rightRayOrigin, Vector2.down, lengRaycastY, layerGround);
        maybeJump = hitGroundLeft.collider != null || hitGroundRight.collider != null;


        Vector2 direction = isFacingRight ? Vector2.right : Vector2.left;
        RaycastHit2D hitWall = Physics2D.Raycast(transform.position, direction, lengRaycastX, layerWall);
        wallJump = hitWall.collider != null;
    }
    void CheckGroundForPlatform()
    {
        Vector2 leftRayOrigin = new Vector2(transform.position.x - 0.1f, transform.position.y);
        Vector2 rightRayOrigin = new Vector2(transform.position.x + 0.1f, transform.position.y);
        RaycastHit2D hit1 = Physics2D.Raycast(leftRayOrigin, Vector2.down, 0.5f, layerPlatform);
        RaycastHit2D hit2 = Physics2D.Raycast(rightRayOrigin, Vector2.down, 0.5f, layerPlatform);
        RaycastHit2D hit3 = Physics2D.Raycast(leftRayOrigin, Vector2.up, 0.5f, layerPlatform);
        RaycastHit2D hit4 = Physics2D.Raycast(rightRayOrigin, Vector2.up, 0.5f, layerPlatform);
        if (hit1.collider)
        {
            hit1.collider.gameObject.layer = LayerMask.NameToLayer("Platform");
        }
        if (hit2.collider)
        {
            hit2.collider.gameObject.layer = LayerMask.NameToLayer("Platform");
        }
        if (hit3.collider)
        {
            hit3.collider.gameObject.layer = LayerMask.NameToLayer("NotCollider");
        }
        if (hit4.collider)
        {
            hit4.collider.gameObject.layer = LayerMask.NameToLayer("NotCollider");
        }

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
    private void CheckTouchInput()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            if (touch.phase == TouchPhase.Began)
            {
                if (touch.position.x > Screen.width * 2 / 3)
                {
                    ClickJumpButton();
                }
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                NotClickJumpButton();
            }
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
        playerInteract.isEnd = false;
        playerAnimatorManager.SetBackCheckPoint();
        PlayerLookEndPoint();
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
            currentPlatform = collision.transform;
            lastPlatformPosition = currentPlatform.position;
        }
    }
    public void CheckOutParent(Collision2D collision)
    {
        if (collision.gameObject.tag == "Flatform" && collision.gameObject.activeSelf && player.gameObject.activeSelf)
        {
            currentPlatform = null;
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
    void SetPositionInPlatform()
    {
        if (currentPlatform != null)
        {
            Vector3 deltaPosition = currentPlatform.position - lastPlatformPosition;
            transform.position += deltaPosition;
            lastPlatformPosition = currentPlatform.position;
        }
    }
    void PlayerLookEndPoint()
    {
        endPos = GameObject.Find("EndPos");
        if (transform.position.x < endPos.transform.position.x) return;
        Flip();
    }
}
