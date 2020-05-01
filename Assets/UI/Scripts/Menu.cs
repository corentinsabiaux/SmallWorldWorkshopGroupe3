using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public int SceneToLoad;//nous permet de choisir la scene a charger
    public void ChangeScene()//change par la scene précisée
    {
        SceneManager.LoadScene(SceneToLoad);
    }

}
