using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public Vector2 direction;

    public float lifetime;
    private float timeToLive;
    public Rigidbody2D mRigidBody;
    public GameObject deathAnimation;

    // Start is called before the first frame update
    void Start()
    {
        mRigidBody = GetComponent<Rigidbody2D>();
        timeToLive = lifetime;
    }

    // Update is called once per frame
    void Update()
    {
        timeToLive -= Time.deltaTime;
        if(timeToLive <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void shoot(Vector2 startVelo)
    {
        mRigidBody.velocity = startVelo * speed;
     }

   


    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (deathAnimation != null)
        {
            GameObject deathEffect = Instantiate(deathAnimation, transform.position, Quaternion.identity);
            Destroy(this.gameObject);

        }

       
    }
}
