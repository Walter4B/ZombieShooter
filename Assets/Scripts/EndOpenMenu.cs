using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOpenMenu : MonoBehaviour
{
    private void Awake()
    {
        GameObject.Find("EndCanvas").GetComponent<PauseMenu>();
    }
    public void OpenMenu()
    {
        SceneManager.LoadScene(0);
    }
}
