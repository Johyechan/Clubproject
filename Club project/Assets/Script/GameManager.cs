using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject mainMenu;
    public static GameManager Instance;
    public Transform playerObject;
    public GameObject bulletObj;
    public float speed;
    public float currnetTime;
    public float delay;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Debug.LogError("Á¿µÊ");
    }

    private void Start()
    {
        Invoke("StartGame", delay);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        currnetTime += Time.fixedDeltaTime;

        delay = 4 - currnetTime / 200;
        delay = Mathf.Clamp(delay, 0.3f, 3);
    }
    public void StartGame()
    {
        BulletSpawner.Instance.StartSpawn();
        Player player = playerObject.GetComponent<Player>();
        player.isDead = false;
        Slidermanager.instance.slider1.value = 1;
        mainMenu.SetActive(false);
    }
    public void GameOver()
    {
        BulletSpawner.Instance.StopAllCoroutines();
        Player player = playerObject.GetComponent<Player>();
        player.isDead = true;
        player.hp = 5;
        mainMenu.SetActive(true);
    }
}
