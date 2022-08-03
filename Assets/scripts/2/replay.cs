using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class replay : MonoBehaviour
{
    public void ReplayGame()
    {
        SceneManager.LoadScene("2");
    }
}
