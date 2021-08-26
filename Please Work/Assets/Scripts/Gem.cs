using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReachedIt()
    {
        anim.SetTrigger("Got");
    }
    private void Death()
    {
        Destroy(this.gameObject);
    }
}
