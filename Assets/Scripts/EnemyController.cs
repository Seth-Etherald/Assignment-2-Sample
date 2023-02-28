using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject _explosion;

    private int _healthPoint;

    public int HealthPoint
    { get { return _healthPoint; } }

    // Start is called before the first frame update
    private void Awake()
    {
        int randomHealth = Random.Range(1, 3);
        SetHealth(randomHealth);
    }

    public void SetHealth(int health)
    {
        _healthPoint = health;

        switch (health)
        {
            case 1:
                transform.localScale = Vector3.one / 3;
                break;

            case 2:
                transform.localScale = Vector3.one * 2 / 3;
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (HealthPoint > 1)
            {
                _healthPoint--;
                gameObject.transform.localScale -= Vector3.one / 3;
            }
            else
            {
                Instantiate(_explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}