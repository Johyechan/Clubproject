using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    static public BulletSpawner Instance;
    public float delay;
    private void Awake()
    {
        Instance = this;
    }
    public void StartSpawn()
    {
        StartCoroutine(Spawn());

    }

    private void FixedUpdate()
    {
        delay = GameManager.Instance.delay;
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            GameObject obj = Instantiate(GameManager.Instance.bulletObj);
            while (true)
            {
                obj.transform.position = new Vector3(Random.Range(-10, 11), 1, Random.Range(-8.5f, 8.5f));
                if (Vector3.Distance(obj.transform.position, GameManager.Instance.playerObject.position) > 8f)
                {
                    break;
                }
            }
            yield return new WaitForSeconds(delay);
        }
    }
}
