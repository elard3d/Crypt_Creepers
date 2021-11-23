using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    float _h;
    float _v;

    private Vector3 moveDirection;
    
    //Velocidad de jugador
    public float speed = 3;
    //Vidas del jugador
    [SerializeField] private float health = 10;
    //Seleccion de 
    [SerializeField] private Transform aim;
    [SerializeField] private Camera _camera;
    private Vector2 facingDirection;

    [SerializeField] private Transform bulletPrefab;

    private bool gunLoaded = true;

    [SerializeField] private float fireRate = 1;
    

    private bool powerShotEnable;

    [SerializeField] private bool invulnerable;
    [SerializeField] private float invurnerableTime = 3;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        //Teclas A,W,D y -><- ^
        _h = Input.GetAxis("Horizontal");
        _v = Input.GetAxis("Vertical");

        moveDirection.x = _h;
        moveDirection.y = _v;


        transform.position += moveDirection * Time.deltaTime * speed;
        
        //Movimiento de la mira
        
         facingDirection = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
         aim.position = transform.position + (Vector3)facingDirection.normalized;

         //Disparar con Mouse
         if (Input.GetMouseButton(0) && gunLoaded)
         {
             gunLoaded = false;
             float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg; // convierde de radiames a grados
             Quaternion targrtRotation = Quaternion.AngleAxis(angle, Vector3.forward);
             Transform bulletClone = Instantiate(bulletPrefab, transform.position, targrtRotation);
             if (powerShotEnable)
             {
                 bulletClone.GetComponent<BulletScript>().powerShot = true;
             }
             StartCoroutine(ReloadGun());

         }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            takeDamage();
        }

        if (other.CompareTag("PowerUp"))
        {
            switch (other.GetComponent<PowerUpScript>()._powerUpType)
            {
                case PowerUpScript.PowerUpType.FireRateIncrease:
                    //INCREMENTAR cadencia de disparo
                    fireRate++;
                break;
                case PowerUpScript.PowerUpType.PowerShot : 
                    //Activar el power shot
                    powerShotEnable = true;
                    break;
            }
            
            Destroy(other.gameObject,0.1f);
        }
    }
    
    

    public void takeDamage()
    {
        if (invulnerable)
            return;
        
        health--;
        invulnerable = true;
        StartCoroutine(MakeVulnerablAgain()); 
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator ReloadGun()
    {
        yield return new WaitForSeconds(1/fireRate);
        gunLoaded = true;
    }

    IEnumerator MakeVulnerablAgain()
    {
        yield return new WaitForSeconds(invurnerableTime);
        invulnerable = false;
    }
    
}
