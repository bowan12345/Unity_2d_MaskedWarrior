using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public float MaxHP; 
    public Slider HpBar; 
    public bool isDes; 
    public UnityEvent DesEvent; 
    private float nowHP; 
    
    // Start is called before the first frame update
    void Start()
    {
        nowHP = MaxHP; 
        HpBar.value = 1;
    }

    
    public void Hit(float damage)
    {
        nowHP -= damage;
        if (nowHP <= 0)
        {
            nowHP = 0;
            if (isDes)
            {
                Destroy(gameObject);
            }
        }

        HpBar.value = nowHP / MaxHP;
    }

    public void OnDestroy()
    {
        DesEvent?.Invoke();
        
    }
}
