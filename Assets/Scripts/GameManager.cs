using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
   public void SceneChange1()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void SceneChange2()
    {
        SceneManager.LoadScene("scene2");
    }
    public void SceneChange3()
    {
        SceneManager.LoadScene("scene3");
    }
    public void SceneChange4()
    {
        SceneManager.LoadScene("scene4");
    }
}
