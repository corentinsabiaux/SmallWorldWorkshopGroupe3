using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public int SceneToLoad;
    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

}
