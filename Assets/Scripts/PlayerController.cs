using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 7f;
    float screenWidthHalf;

    public float bombDamage = -20;
    public float heal = 15;
    public float startHeal = 100;
    public float currentHeal;

    public event System.Action OnPlayerDeath;

    void Start()
    {
        float halfPlayerWidth = transform.localScale.x / 2f;
        screenWidthHalf = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;

        this.currentHeal = startHeal;
        
    }


    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");  //yön oluyor burası
        
        Vector3 movement = new Vector3(inputX, 0, 0);
        transform.Translate(movement * speed * Time.deltaTime);

        if(transform.position.x < -screenWidthHalf)
        {
            transform.position = new Vector3(-screenWidthHalf, transform.position.y);
        }

        if (transform.position.x > screenWidthHalf)
        {
            transform.position = new Vector3(screenWidthHalf, transform.position.y);
        }
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Bomb Block")
        {
            currentHeal += bombDamage;

            if (currentHeal > 0)
            {
                Destroy(collision.gameObject);
                Debug.Log(currentHeal);
            }
            else
            {
                if(OnPlayerDeath != null)
                {
                    OnPlayerDeath();
                }
                Destroy(collision.gameObject);
                Debug.Log("You've just died");
            }
        }

        if (collision.tag == "Heal Block")
        {
            currentHeal += heal;
            Destroy(collision.gameObject);
            Debug.Log(currentHeal);
        }


    }
}
