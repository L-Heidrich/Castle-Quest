using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotScript : MonoBehaviour
{

    private Animator anim;
    public  GameObject loot;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SmashPot()
    {
        Sound.playSound("potSound");
        anim.SetBool("smash", true);
        StartCoroutine(BreakCO());
        

    }

    IEnumerator BreakCO()
    {
        if (loot != null)
        {
            loot.SetActive(true);

        }
        yield return new WaitForSeconds(.2f);
        this.gameObject.SetActive(false);
        
    }
}
