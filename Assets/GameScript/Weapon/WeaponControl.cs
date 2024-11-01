using UnityEngine;


public class WeaponControl : MonoBehaviour
{
    public GameObject BulletPrefab;
    public AudioSource GunBGMBeep;
    public Transform ShootTr; 
    
    private Rigidbody2D _rigidbody2D;
    private Collider2D _collider2D;

    [SerializeField]
    private Transform FollowTargetTr; 
        
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (!FollowTargetTr)
        {
            return;
        }
        
       
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(BulletPrefab, ShootTr.position, transform.rotation);
            GunBGMBeep.Play();
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!FollowTargetTr)
        {
            return;
        }

        transform.position = FollowTargetTr.position;
        
        Vector3 mousePos = Input.mousePosition;

        
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, transform.position.z - Camera.main.transform.position.z));
        
        transform.up = worldMousePos - transform.position;
    
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            FollowTargetTr = col.transform;
            
            Destroy(_collider2D);
            Destroy(_rigidbody2D);
        }
    }
}
