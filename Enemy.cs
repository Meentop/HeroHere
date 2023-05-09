using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float maxHp = 100;
    protected float curHp = 0;

    [SerializeField] RectTransform hpBar;

    protected Player player;
    protected Rigidbody rb;

    [SerializeField] protected float moveSpeed, rotationSpeed, pushBackStrength, pushBackDuration;

    [SerializeField] protected BattleZone battleZone;

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

    protected virtual void Rotation(Transform rotObj)
    {
        Vector3 direction = (player.transform.position - rotObj.position).normalized;
        Quaternion endRotation = Quaternion.LookRotation(direction);
        Quaternion rot = Quaternion.Lerp(rotObj.rotation, endRotation, rotationSpeed);
        rotObj.rotation = Quaternion.Euler(new Vector3(rotObj.rotation.eulerAngles.x, rot.eulerAngles.y, rotObj.rotation.eulerAngles.z));
    }

    public virtual void GetDamage(float damage)
    {
        curHp -= damage;
        if (curHp <= 0)
        {
            curHp = 0;
            battleZone.RemoveEnemy(this);
            Destroy(gameObject);
        }
        UpdateHpBar();
        StartCoroutine(PushBack());
    }

    protected virtual IEnumerator PushBack()
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

    public void StopMovement()
    {
        rb.velocity = Vector3.zero;
    }
}
