using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClassSelect : MonoBehaviour
{
    private Vector2 mousePos;

    private float angle;

    public GameObject SoldierClass;
    public GameObject ScoutClass;
    public GameObject MarksmanClass;
    
    public Transform Soldier;
    public Transform Scout;
    public Transform Marksman;

    public Transform SLRBarrel;
    public Transform SCTBarrel;
    public Transform MMBarrel;

    public GameObject bullet;

    public TextMeshProUGUI AchieveText;

    private float shootSpeed;
    public float bulletSpeed;

    private bool canShoot = true;

    public void Awake()
    {
        canShoot = true;
    }

    public void Update()
    {
        
        mousePos = Input.mousePosition;

        Vector3 objPos = Camera.main.WorldToScreenPoint(transform.position);

        mousePos.x -= objPos.x;
        mousePos.y -= objPos.y;

        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        if (SoldierClass.activeSelf)
        {
            if (Input.GetMouseButton(0) && canShoot)
            {
                StartCoroutine(shootPistol());
            }
        }

        if (ScoutClass.activeSelf)
        {
            if (Input.GetMouseButton(0) && canShoot)
            {
                StartCoroutine(shootScout());
            }
        }

        if (MarksmanClass.activeSelf)
        {
            if (Input.GetMouseButton(0) && canShoot)
            {
                StartCoroutine(shootMarksman());
            }
        }
    }

    public void FixedUpdate()
    {
        Soldier.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        Scout.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        Marksman.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public IEnumerator shootPistol()
    {
        canShoot = false;
        GameObject bulletCreate = Instantiate(bullet, SLRBarrel.position, SLRBarrel.rotation);
        Rigidbody2D bulletRB = bulletCreate.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(SLRBarrel.right * bulletSpeed);
        Destroy(bulletCreate, 1f);
        shootSpeed = 1;
        AchieveText.text = "Complete";
        yield return new WaitForSeconds(shootSpeed);
        canShoot = true;

    }

    public IEnumerator shootScout()
    {
        canShoot = false;
        GameObject bulletCreate = Instantiate(bullet, SCTBarrel.position, SCTBarrel.rotation);
        Rigidbody2D bulletRB = bulletCreate.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(SCTBarrel.right * bulletSpeed);
        Destroy(bulletCreate, 1f);
        shootSpeed = .5f;
        AchieveText.text = "Complete";
        yield return new WaitForSeconds(shootSpeed);
        canShoot = true;

    }
    public IEnumerator shootMarksman()
    {
        canShoot = false;
        GameObject bulletCreate = Instantiate(bullet, MMBarrel.position, MMBarrel.rotation);
        Rigidbody2D bulletRB = bulletCreate.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(MMBarrel.right * bulletSpeed);
        Destroy(bulletCreate, 5f);
        shootSpeed = 2;
        AchieveText.text = "Complete";
        yield return new WaitForSeconds(shootSpeed);
        canShoot = true;
    }
}
