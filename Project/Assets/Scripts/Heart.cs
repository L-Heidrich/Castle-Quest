using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : PowerUp
{
    public FloatValue health;
    public FloatValue hearts;
    public FloatValue maxHealth;
    public float increase;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
         
        if (collider.CompareTag("Player") && collider.isTrigger)
        {
            if (health.RuntimeValue < health.initialValue)
            {


                health.RuntimeValue += increase;

                if (health.RuntimeValue > health.initialValue)
                {
                    health.RuntimeValue = health.initialValue;
                }


                if (health.initialValue > hearts.RuntimeValue * 2)
                {
                    health.initialValue = hearts.RuntimeValue * 2f;
                }
                powSignal.Raise();
                Destroy(this.gameObject);
            }
        }
    }
}
