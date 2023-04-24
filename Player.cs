using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Player : MonoBehaviour
{
    [SerializeField] Joystick joystick;

    [SerializeField] float speed, rotationSpeed;

    [SerializeField] Transform weaponPivot;

    [SerializeField] Weapon weapon;

    [SerializeField] Animator anim;

    [SerializeField] Text fps;

    [SerializeField] DrawWeaponRadius drawWeaponRadius;

    private void Start()
    {
        StartCoroutine(FpsCounter());
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        Move();
        EnemyDetection();
    }

    void Move()
    {
        if (joystick.Direction.x != 0 && joystick.Direction.y != 0)
        {
            Vector3 translation = new Vector3(joystick.Direction.normalized.x, 0, joystick.Direction.normalized.y);
            Quaternion endRotation = Quaternion.LookRotation(translation);
            transform.rotation = Quaternion.Lerp(transform.rotation, endRotation, rotationSpeed);
            transform.position = Vector3.MoveTowards(transform.position, transform.position + translation, speed * Time.deltaTime);
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
                Transform[] enemies = colliders.Where(enemy => enemy.GetComponent<Enemy>()).Select(enemy => enemy.transform).ToArray();
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
}
