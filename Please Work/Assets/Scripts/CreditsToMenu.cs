using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsToMenu : MonoBehaviour
{
    public void CreditsMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    }
}
