using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public int SceneToLoad;//nous permet de choisir la scene a charger
    public void ChangeScene()//change par la scene précisée
    {
        SceneManager.LoadScene(SceneToLoad);
        if (SceneManager.GetActiveScene().name == "MainMenu" && GameObject.Find("GameManager") != null)
        {
            GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Stop();
            GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().PlayOneShot(GameManager.Instance.menuClip, GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().volume);
            Destroy(GameObject.Find("GameManager"));
        }
    }

}
