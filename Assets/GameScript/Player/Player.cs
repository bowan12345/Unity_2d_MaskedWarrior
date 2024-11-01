using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public float MoveSpeed; 
    public float JumpForce; 
    public float GroundDetectionRadius; 
    public Vector3 GroundDetectionOffset; 
    public float MaxHP; 
    public Slider HPBar; 
    public float HitWaitTime; 
    public GameObject OverPanel; 

    private float nowHp; 
    private float inputX, inputY; 
    private bool isGround; 
    private bool DoubleJump; 
    private bool isOperable; 
    private float recoveryTiem; 
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private Coroutine _recovery;

    public AudioSource HurtBGMBeep;

    bool isJumpPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        nowHp = MaxHP;
        HPBar.value = 1;
        isOperable = true;
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();

        isJumpPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInput();
        
        Move();
        Jump();
    }

    
    private void UpdateInput()
    {
        
        isGround = Physics2D.OverlapCircle(transform.position + GroundDetectionOffset, GroundDetectionRadius, LayerMask.GetMask("Ground"));
        inputX = 0;
        inputY = 0;
        
        if (!isOperable || nowHp <= 0)
            return;
        
        if (Input.GetKey(KeyCode.A))
        {
            inputX += -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputX += 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            inputY += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputY += -1;
        }
    }

    
    private void Move()
    {
        
        if (inputX < 0)
        {
            Vector3 rotAngle = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(rotAngle.x, 180, rotAngle.z);
        }else if (inputX > 0)
        {
            Vector3 rotAngle = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(rotAngle.x, 0, rotAngle.z);
        }
        
        transform.Translate(Vector3.right * inputX * MoveSpeed * Time.deltaTime, Space.World);
        _animator.SetBool("Run", Mathf.Abs(inputX) > 0);
    }

   
    private void Jump()
    {
       
        if (Input.GetKeyDown(KeyCode.Space) && (isGround || DoubleJump) && isOperable && nowHp > 0)
        {
            if (DoubleJump) 
            {
                _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
            }
            _animator.SetBool("DoubleJump", !isGround && DoubleJump);
            _rigidbody2D.AddForce(Vector3.up * JumpForce, ForceMode2D.Impulse);
            DoubleJump = !DoubleJump;
        }

        if (!isGround)
        {
            _animator.SetBool("Jump", _rigidbody2D.velocity.y > 0);
            _animator.SetBool("Fall", _rigidbody2D.velocity.y < 0);
        }
        else
        {
            _animator.SetBool("Jump", false);
            _animator.SetBool("Fall", false);
        }
    }

   
    public void Hit(float damage, bool repel, Vector2 force)
    {
        if (nowHp <= 0)
            return;
        
        nowHp -= damage;
        if (nowHp <= 0)
        {
            nowHp = 0;
            Time.timeScale = 0;
            OverPanel.SetActive(true);
        }
        HPBar.value = nowHp / MaxHP;

        if (repel) 
        {
            _rigidbody2D.velocity = force;
            isOperable = false;
            recoveryTiem = Time.time + HitWaitTime;
            if (_recovery == null)
            {
                _recovery = StartCoroutine(RecoveryEnumerator());
            }
            _animator.SetTrigger("Hit");
        }
       
        HurtBGMBeep.Play();
}

    
    IEnumerator RecoveryEnumerator()
    {
        while (Time.time <= recoveryTiem)
        {
            yield return null;
        }

        isOperable = true;
        _recovery = null;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + GroundDetectionOffset, GroundDetectionRadius);
    }
}
