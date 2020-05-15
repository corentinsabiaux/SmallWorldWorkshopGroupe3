using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPanelScript : MonoBehaviour
{
    public GameObject[] playerFloat = new GameObject[5]; //les 4 flottants en eux même, le 5 est reservé au placeholder.
    //0 = cactus
    //1 = salamandre
    //2 = automate
    //3 = skeleton
    //4 = placeholder
    public Vector3[] playerFloatXYZ = new Vector3[4]; //la location pour les 4 flottants
    public GameObject[] turnPlayerByLight = new GameObject[4]; //On appelle les 4 spots qui éclairent les tours des joueurs quand c'est leurs tours.
    public GameObject[] playerFloatIndex = new GameObject[4]; //On garde en mémoire les flottants de chaque joueur.

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.onUiChangeCallBack += RefreshUI;
        GameManager.Instance.refreshUis();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void RefreshUI()
    {
        Player p = GameManager.Instance.players[GameManager.Instance.activePlayerNumber - 1];
        //On instancie le spot éclairant la surface du joueur actif.
            switch (GameManager.Instance.activePlayerNumber - 1)
            {
                case 0:
                    {
                        turnPlayerByLight[3].SetActive(false);
                        turnPlayerByLight[0].SetActive(true);
                    }
                    break;

                case 1:
                    {
                        turnPlayerByLight[0].SetActive(false);
                        turnPlayerByLight[1].SetActive(true);
                    }
                    break;

                case 2:
                    {
                        turnPlayerByLight[1].SetActive(false);
                        turnPlayerByLight[2].SetActive(true);
                    }
                    break;

                case 3:
                    {
                        turnPlayerByLight[2].SetActive(false);
                        turnPlayerByLight[3].SetActive(true);
                    }
                    break;
            }

        //On instancie le flottant du joueur correspondant à la race qu'il a sélectionné.
        if (p.phase.phaseName == "FirstConquestPhase")
        {
            switch (GameManager.Instance.activePlayerNumber - 1)
            {
                case 0:
                    switch (p.actualRace.name)
                    {
                        case "Cacpicho":
                            if (playerFloatIndex[0] == null)
                            {
                                GameObject cactus = GameObject.Instantiate(playerFloat[0], playerFloatXYZ[GameManager.Instance.activePlayerNumber - 1], Quaternion.identity); //instancie un cactus
                                playerFloatIndex[0] = cactus;
                            }
                            break;
                        case "Salamandre":
                            if (playerFloatIndex[0] == null)
                            {
                                GameObject tnt = GameObject.Instantiate(playerFloat[1], playerFloatXYZ[GameManager.Instance.activePlayerNumber - 1], Quaternion.identity); //instancie une TNT
                                playerFloatIndex[0] = tnt;
                            }
                            break;
                        case "Automate":
                            if (playerFloatIndex[0] == null)
                            {
                                GameObject gourde = GameObject.Instantiate(playerFloat[2], playerFloatXYZ[GameManager.Instance.activePlayerNumber - 1], Quaternion.identity); //instancie une gourde
                                gourde.transform.rotation = Quaternion.Euler(0, 120, 0);
                                playerFloatIndex[0] = gourde;
                            }
                            break;
                        case "Squelette":
                            if (playerFloatIndex[0] == null)
                            {
                                GameObject montre = GameObject.Instantiate(playerFloat[3], playerFloatXYZ[GameManager.Instance.activePlayerNumber - 1], Quaternion.identity); //instancie une montre
                                playerFloatIndex[0] = montre;
                            }
                            break;
                        default:
                            if (playerFloatIndex[0] == null)
                            {
                                GameObject placeholder = GameObject.Instantiate(playerFloat[4], playerFloatXYZ[GameManager.Instance.activePlayerNumber - 1], Quaternion.identity); //instancie un placeholder
                                playerFloatIndex[0] = placeholder;
                                if (GameManager.Instance.activePlayerNumber - 1 == 0 || GameManager.Instance.activePlayerNumber - 1 == 3)
                                {
                                    placeholder.transform.position = new Vector3(placeholder.transform.position.x - .4f, placeholder.transform.position.y, placeholder.transform.position.z);
                                }
                                else if (GameManager.Instance.activePlayerNumber - 1 == 1 || GameManager.Instance.activePlayerNumber - 1 == 2)
                                {
                                    placeholder.transform.position = new Vector3(placeholder.transform.position.x + .4f, placeholder.transform.position.y, placeholder.transform.position.z);
                                }
                            }
                            break;
                    }
                    break;

                case 1:
                    switch (p.actualRace.name)
                    {
                        case "Cacpicho":
                            if (playerFloatIndex[1] == null)
                            {
                                GameObject cactus = GameObject.Instantiate(playerFloat[0], playerFloatXYZ[GameManager.Instance.activePlayerNumber - 1], Quaternion.identity); //instancie un cactus
                                playerFloatIndex[1] = cactus;
                            }
                            break;
                        case "Salamandre":
                            if (playerFloatIndex[1] == null)
                            {
                                GameObject tnt = GameObject.Instantiate(playerFloat[1], playerFloatXYZ[GameManager.Instance.activePlayerNumber - 1], Quaternion.identity); //instancie une TNT
                                playerFloatIndex[1] = tnt;
                            }
                            break;
                        case "Automate":
                            if (playerFloatIndex[1] == null)
                            {
                                GameObject gourde = GameObject.Instantiate(playerFloat[2], playerFloatXYZ[GameManager.Instance.activePlayerNumber - 1], Quaternion.identity); //instancie une gourde
                                gourde.transform.rotation = Quaternion.Euler(0, 120, 0);
                                playerFloatIndex[1] = gourde;
                            }
                            break;
                        case "Squelette":
                            if (playerFloatIndex[1] == null)
                            {
                                GameObject montre = GameObject.Instantiate(playerFloat[3], playerFloatXYZ[GameManager.Instance.activePlayerNumber - 1], Quaternion.identity); //instancie une montre
                                playerFloatIndex[1] = montre;
                            }
                            break;
                        default:
                            if (playerFloatIndex[1] == null)
                            {
                                GameObject placeholder = GameObject.Instantiate(playerFloat[4], playerFloatXYZ[GameManager.Instance.activePlayerNumber - 1], Quaternion.identity); //instancie un placeholder
                                playerFloatIndex[1] = placeholder;
                                if (GameManager.Instance.activePlayerNumber - 1 == 0 || GameManager.Instance.activePlayerNumber - 1 == 3)
                                {
                                    placeholder.transform.position = new Vector3(placeholder.transform.position.x - .4f, placeholder.transform.position.y, placeholder.transform.position.z);
                                }
                                else if (GameManager.Instance.activePlayerNumber - 1 == 1 || GameManager.Instance.activePlayerNumber - 1 == 2)
                                {
                                    placeholder.transform.position = new Vector3(placeholder.transform.position.x + .4f, placeholder.transform.position.y, placeholder.transform.position.z);
                                }
                            }
                            break;
                    }
                    break;

                case 2:
                    switch (p.actualRace.name)
                    {
                        case "Cacpicho":
                            if (playerFloatIndex[2] == null)
                            {
                                GameObject cactus = GameObject.Instantiate(playerFloat[0], playerFloatXYZ[GameManager.Instance.activePlayerNumber - 1], Quaternion.identity); //instancie un cactus
                                playerFloatIndex[2] = cactus;
                            }
                            break;
                        case "Salamandre":
                            if (playerFloatIndex[2] == null)
                            {
                                GameObject tnt = GameObject.Instantiate(playerFloat[1], playerFloatXYZ[GameManager.Instance.activePlayerNumber - 1], Quaternion.identity); //instancie une TNT
                                playerFloatIndex[2] = tnt;
                            }
                            break;
                        case "Automate":
                            if (playerFloatIndex[2] == null)
                            {
                                GameObject gourde = GameObject.Instantiate(playerFloat[2], playerFloatXYZ[GameManager.Instance.activePlayerNumber - 1], Quaternion.identity); //instancie une gourde
                                gourde.transform.rotation = Quaternion.Euler(0, 120, 0);
                                playerFloatIndex[2] = gourde;
                            }
                            break;
                        case "Squelette":
                            if (playerFloatIndex[2] == null)
                            {
                                GameObject montre = GameObject.Instantiate(playerFloat[3], playerFloatXYZ[GameManager.Instance.activePlayerNumber - 1], Quaternion.identity); //instancie une montre
                                playerFloatIndex[2] = montre;
                            }
                            break;
                        default:
                            if (playerFloatIndex[2] == null)
                            {
                                GameObject placeholder = GameObject.Instantiate(playerFloat[4], playerFloatXYZ[GameManager.Instance.activePlayerNumber - 1], Quaternion.identity); //instancie un placeholder
                                playerFloatIndex[2] = placeholder;
                                if (GameManager.Instance.activePlayerNumber - 1 == 0 || GameManager.Instance.activePlayerNumber - 1 == 3)
                                {
                                    placeholder.transform.position = new Vector3(placeholder.transform.position.x - .4f, placeholder.transform.position.y, placeholder.transform.position.z);
                                }
                                else if (GameManager.Instance.activePlayerNumber - 1 == 1 || GameManager.Instance.activePlayerNumber - 1 == 2)
                                {
                                    placeholder.transform.position = new Vector3(placeholder.transform.position.x + .4f, placeholder.transform.position.y, placeholder.transform.position.z);
                                }
                            }
                            break;
                    }
                    break;

                case 3:
                    switch (p.actualRace.name)
                    {
                        case "Cacpicho":
                            if (playerFloatIndex[3] == null)
                            {
                                GameObject cactus = GameObject.Instantiate(playerFloat[0], playerFloatXYZ[GameManager.Instance.activePlayerNumber - 1], Quaternion.identity); //instancie un cactus
                                playerFloatIndex[3] = cactus;
                            }
                            break;
                        case "Salamandre":
                            if (playerFloatIndex[3] == null)
                            {
                                GameObject tnt = GameObject.Instantiate(playerFloat[1], playerFloatXYZ[GameManager.Instance.activePlayerNumber - 1], Quaternion.identity); //instancie une TNT
                                playerFloatIndex[3] = tnt;
                            }
                            break;
                        case "Automate":
                            if (playerFloatIndex[3] == null)
                            {
                                GameObject gourde = GameObject.Instantiate(playerFloat[2], playerFloatXYZ[GameManager.Instance.activePlayerNumber - 1], Quaternion.identity); //instancie une gourde
                                gourde.transform.rotation = Quaternion.Euler(0, 120, 0);
                                playerFloatIndex[3] = gourde;
                            }
                            break;
                        case "Squelette":
                            if (playerFloatIndex[3] == null)
                            {
                                GameObject montre = GameObject.Instantiate(playerFloat[3], playerFloatXYZ[GameManager.Instance.activePlayerNumber - 1], Quaternion.identity); //instancie une montre
                                playerFloatIndex[3] = montre;
                            }
                            break;
                        default:
                            if (playerFloatIndex[3] == null)
                            {
                                GameObject placeholder = GameObject.Instantiate(playerFloat[4], playerFloatXYZ[GameManager.Instance.activePlayerNumber - 1], Quaternion.identity); //instancie un placeholder
                                playerFloatIndex[3] = placeholder;
                                if (GameManager.Instance.activePlayerNumber - 1 == 0 || GameManager.Instance.activePlayerNumber - 1 == 3)
                                {
                                    placeholder.transform.position = new Vector3(placeholder.transform.position.x - .4f, placeholder.transform.position.y, placeholder.transform.position.z);
                                }
                                else if (GameManager.Instance.activePlayerNumber - 1 == 1 || GameManager.Instance.activePlayerNumber - 1 == 2)
                                {
                                    placeholder.transform.position = new Vector3(placeholder.transform.position.x + .4f, placeholder.transform.position.y, placeholder.transform.position.z);
                                }
                            }
                            break;
                    }
                    break;
            }

        }

        //On détruit le flottant du joueur actif lorsqu'il passe en déclin.
        if (p.phase.phaseName == "DecliningPhase")
        {
            switch (GameManager.Instance.activePlayerNumber - 1)
            {
                case 0:
                    {
                        Destroy(playerFloatIndex[0]);
                    }
                    break;
                case 1:
                    {
                        Destroy(playerFloatIndex[1]);
                    }
                    break;
                case 2:
                    {
                        Destroy(playerFloatIndex[2]);
                    }
                    break;
                case 3:
                    {
                        Destroy(playerFloatIndex[3]);
                    }
                    break;
            }
        }
    }
}
