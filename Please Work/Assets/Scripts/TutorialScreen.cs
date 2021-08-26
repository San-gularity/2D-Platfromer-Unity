using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScreen : MonoBehaviour
{
    //public GameObject panel;
    public GameObject backFront;
    public GameObject spaceBar;
    public GameObject backToMenu;

    private bool firstOne = true;
    private bool secondOne = false;

    void Start()
    {

    }

    void Update()
    {
        if (firstOne)
        {
            float hDirection = Input.GetAxis("Horizontal");
            if (hDirection > 0 || hDirection < 0)
            {
                backFront.SetActive(false);
                firstOne = false;
                secondOne = true;
            }
        }
        else if(secondOne)
        {
            spaceBar.SetActive(true);
            if (Input.GetKey(KeyCode.Space))
            {
                spaceBar.SetActive(false);
                backToMenu.SetActive(true);
                secondOne = false;
            }
        }
        else
        {

        }
    }
    /*private void NextTutorial()
    {
        spaceBar.SetActive(true);
    }*/
    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        //Time.timeScale = 1f;
    }
}
