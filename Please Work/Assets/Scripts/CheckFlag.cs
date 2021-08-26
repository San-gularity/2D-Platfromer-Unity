using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFlag : MonoBehaviour
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
    public float GetPositionX()
    {
        return (transform.position.x);        
    }
    public float GetPositionY()
    {
        return (transform.position.y);
    }

    public void ReachedIt()
    {
        anim.SetTrigger("Reached");
    }
}
