using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp;
    public int maxHp;
    public bool isDead = false;
    [SerializeField] float _speed;
    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        hp--;
        Destroy(collision.gameObject);
        Slidermanager.instance.OnDamage(hp);
        Debug.Log("Ã¼·Â ´âÀ½");
        if (hp <= 0)
        {
            isDead = true;
            GameManager.Instance.GameOver();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;
        Vector3 a = transform.rotation.eulerAngles;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            a.y -= Time.deltaTime * _speed;
            transform.rotation = Quaternion.Euler(a);
            ;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            a.y += Time.deltaTime * _speed;
            transform.rotation = Quaternion.Euler(a);
            ;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            a.y += 180;
            transform.rotation = Quaternion.Euler(a);
            ;
        }
    }
    private void FixedUpdate()
    {
        _speed = GameManager.Instance.speed * 180;
        _speed = Mathf.Max(720);

    }
}
