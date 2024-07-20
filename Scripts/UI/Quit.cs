using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    public void Q() {
        Application.Quit();
    }

    public void C() {
        SceneManager.LoadScene("Credits");
    }
}
