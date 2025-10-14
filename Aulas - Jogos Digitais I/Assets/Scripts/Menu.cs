using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    void Start()
    {   
    }

    void Update()
    {
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    } 
}
