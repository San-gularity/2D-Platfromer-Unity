using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{
    //private UnityEngine.Object enemyRef;
    private Animator anim;
    void Start()
    {
        //enemyRef = Resources.Load("Eagle");
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        
    }
    public void jumpedOn()
    {
        anim.SetTrigger("Death");
    }
    private void Death()
    {
        gameObject.SetActive(false);
        Invoke("Respawn", 4);
    }
    public void Respawn()
    {
        //GameObject enemyclone = Instantiate(enemyRef) as GameObject;
        //enemyclone.transform.position = transform.position;
        gameObject.SetActive(true);
    }
}   
