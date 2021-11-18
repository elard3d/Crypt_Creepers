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
         
         


    }
}
