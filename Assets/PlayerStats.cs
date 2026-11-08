using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int health = 100;
    public int lives = 3;
    public static int score=0;
    public static bool hasHeart= false;

    private float flickerTime=0f;
    public float flickerDuration=0.1f;

    private SpriteRenderer sr;

    public bool isImmune = false;
    private float immunityTime = 0f;
    public float immunityDuration = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isImmune == true)
        {
            SpriteFlicker();
            immunityTime = immunityTime + Time.deltaTime;
            if(immunityTime >= immunityDuration)
            {
                isImmune = false;
                sr.enabled = true;
            }
        }
    }

    void SpriteFlicker(){
        if(flickerTime < flickerDuration)
        {
            flickerTime=flickerTime + Time.deltaTime;
        }
        else if(flickerTime>= flickerDuration)
        {
            sr.enabled = !sr.enabled;
            flickerTime=0 ;
        }
    }

    public void TakeDamage(int damage)
    {
        if(isImmune ==false)
        {
            health = health - damage;

            if(health < 0)
            {
                health = 0;
            }
            if(lives > 0 && health ==0)
            {
                Debug.Log("GAME OVER");
                Destroy(this.gameObject);
            }

            Debug.Log("Player Health: " + health.ToString());
            Debug.Log("Player Lives: " + lives.ToString());

        }

        isImmune = true;
        immunityTime = 0f;
    }




}
