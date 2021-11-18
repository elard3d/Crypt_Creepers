using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{


    float _h;
    float _v;

    private Vector3 moveDirection;
    
    [SerializeField] private float speed = 3;
    [SerializeField] private Transform aim;
    [SerializeField] private Camera _camera;
    private Vector2 facingDirection;

    [SerializeField] private Transform bulletPrefab;

    private bool gunLoaded = true;

    [SerializeField] private float fireRate = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
             Instantiate(bulletPrefab, transform.position, targrtRotation);
             StartCoroutine(ReloadGun());

         }

    }

    IEnumerator ReloadGun()
    {
        yield return new WaitForSeconds(1/fireRate);
        gunLoaded = true;
    }

}
