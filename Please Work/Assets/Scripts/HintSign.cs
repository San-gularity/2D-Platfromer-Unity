using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintSign : MonoBehaviour
{
    public GameObject HintTextUI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            HintTextUI.SetActive(true);
            Invoke("RemoveText", 2.5f);
        }
    }

    private void RemoveText()
    {
        HintTextUI.SetActive(false);
    }
}
