using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelTeleporter : MonoBehaviour
{
    GameObject player;
    GameObject hero;
    bool teleportEnabled;
    // Start is called before the first frame update
    void Start()
    {
        player = PartyManager.instance.player;
        hero = PartyManager.instance.hero;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hero")
        {
            teleportEnabled = true;
        }
        if(teleportEnabled && other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
