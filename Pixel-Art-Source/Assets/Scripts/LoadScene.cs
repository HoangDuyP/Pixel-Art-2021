using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{
    public void LoadApple()
    {
        SceneManager.LoadScene("Apple");
    }
    public void LoadCoca()
    {
        SceneManager.LoadScene("Coca");

    }
    public void LoadMango()
    {
        SceneManager.LoadScene("Mango");

    }
    public void LoadCake()
    {
        SceneManager.LoadScene("Cake");

    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }        
}
