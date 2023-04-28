using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float maxHp = 100;
    protected float curHp = 0;

    [SerializeField] RectTransform hpBar;

    Player player;
    Rigidbody rb;

    [SerializeField] float moveSpeed, rotationSpeed, pushBackStrength, pushBackDuration;

    protected bool isMove = true, sleep = true;

    protected virtual void Start()
    {
        curHp = maxHp;
        UpdateHpBar();
        player = FindObjectOfType<Player>();
        rb = GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    {
        
    }

    protected virtual void FixedUpdate()
    {
        
    }

    protected void MoveTowardPlayer()
    {
        if (isMove)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            rb.velocity = new Vector3(direction.x, 0, direction.z) * moveSpeed;
        }
    }

    protected void Rotation()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion endRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, endRotation, rotationSpeed);
    }

    public virtual void GetDamage(float damage)
    {
        curHp -= damage;
        if (curHp <= 0)
        {
            curHp = 0;
            Destroy(gameObject);
        }
        UpdateHpBar();
        StartCoroutine(PushBack());
    }

    IEnumerator PushBack()
    {
        isMove = false;
        rb.velocity = Vector3.zero;
        rb.AddForce((transform.position - player.transform.position).normalized * pushBackStrength, ForceMode.Impulse);
        yield return new WaitForSeconds(pushBackDuration);
        isMove = true;
    }

    protected void UpdateHpBar()
    {
        hpBar.localScale = new Vector3(curHp / maxHp, 1, 1);
    }

    public void WakeUp()
    {
        sleep = false;
    }

    public bool IsSleep()
    {
        return sleep;
    }
}
