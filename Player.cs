using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Player : MonoBehaviour
{
    [Header("General")]
    [SerializeField] Joystick joystick;
    [SerializeField] Animator anim;
    [SerializeField] Text fps;
    [SerializeField] GameObject deathScreen;
    Rigidbody rb;

    [Header("Movement")]
    [SerializeField] float speed;
    [SerializeField] float rotationSpeed, stunDuration, invulnerableDuration;

    [Header("Weapon")]
    [SerializeField] Transform weaponPivot;
    Weapon weapon = null;
    [SerializeField] DrawWeaponRadius drawWeaponRadius;

    [Header("Health")]
    [SerializeField] float maxHp = 100;
    float curHp = 0;
    bool isMove = true, invulnerable = false, isDead = false;
    [SerializeField] RectTransform hpBar;

    private void Start()
    {
        StartCoroutine(FpsCounter());
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody>();
        curHp = maxHp;
    }

    private void Update()
    {
        if (!isDead)
        {
            if (isMove)
            {
                Rotation();
                SetMoveAnim();
            }
            EnemyDetection();
        }
    }

    private void FixedUpdate()
    {
        if(isMove && !isDead)
            Move();
    }

    void Move()
    {
        Vector3 translation = new Vector3(joystick.Direction.x, 0, joystick.Direction.y).normalized;
        rb.velocity = translation * speed;
    }

    void Rotation()
    {
        Vector3 translation = new Vector3(joystick.Direction.x, 0, joystick.Direction.y).normalized;
        if (joystick.Direction.x != 0 && joystick.Direction.y != 0)
        {
            Quaternion endRotation = Quaternion.LookRotation(translation);
            transform.rotation = Quaternion.Lerp(transform.rotation, endRotation, rotationSpeed);
        }
    }

    void SetMoveAnim()
    {
        if (joystick.Direction.x != 0 && joystick.Direction.y != 0)
        {
            if (!anim.GetBool("IsMove"))
                anim.SetBool("IsMove", true);
        }
        else
        {
            if (anim.GetBool("IsMove"))
                anim.SetBool("IsMove", false);
        }
    }

    void EnemyDetection()
    {
        if(weapon != null)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, weapon.GetRadius());
            if (colliders.Length > 0)
            {
                Transform[] enemies = colliders.Where(enemy => enemy.GetComponent<Enemy>() && !enemy.GetComponent<Enemy>().IsSleep()).Select(enemy => enemy.transform).ToArray();
                if (enemies.Length > 0)
                {
                    weapon.EnemyEnteredInRange();
                    weapon.SetNextTarget(enemies.OrderBy(enemy => Vector3.Distance(enemy.position, transform.position)).First());
                }
                else
                    weapon.EnemyIsOutRange();
            }
        }
    }

    IEnumerator FpsCounter()
    {
        while(true)
        {
            fps.text = ((int)(1 / Time.deltaTime)).ToString();
            yield return new WaitForSeconds(0.2f);
        }
    }

    public void SetWeapon(GameObject weapon)
    {
        if (this.weapon != null)
            Destroy(this.weapon.gameObject);
        this.weapon = Instantiate(weapon, weaponPivot.position, Quaternion.identity).GetComponent<Weapon>();
        this.weapon.SetWeaponPivot(weaponPivot);
        this.weapon.SetPlayer(transform);
        drawWeaponRadius.DrawCircle(32, this.weapon.GetRadius());
    }



    public void GetDamage(float damage)
    {
        if (!invulnerable && !isDead)
        {
            curHp -= damage;
            if (curHp <= 0)
                Death();
            UpdateHpBar();
            StartCoroutine(GetHit());
            anim.SetTrigger("GetHit");
        }
    }

    void Death()
    {
        curHp = 0;
        UpdateHpBar();
        anim.SetBool("Dead", true);
        isDead = true;
        deathScreen.SetActive(true);
        weapon.EnemyIsOutRange();
    }

    void UpdateHpBar()
    {
        hpBar.localScale = new Vector3(curHp / maxHp, 1, 1);
    }

    IEnumerator GetHit()
    {
        isMove = false;
        invulnerable = true;
        rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(stunDuration);
        isMove = true;
        yield return new WaitForSeconds(invulnerableDuration - stunDuration);
        invulnerable = false;
    }
}
