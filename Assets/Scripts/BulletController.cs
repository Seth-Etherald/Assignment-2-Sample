using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Timer bulletTimer;

    // Start is called before the first frame update
    private void Start()
    {
        bulletTimer = gameObject.AddComponent<Timer>();
        bulletTimer.Duration = 2;
        bulletTimer.Run();
    }

    // Update is called once per frame
    private void Update()
    {
        if (bulletTimer.Finished)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    public void ApplyForce(Vector2 direction)
    {
        const float magnitude = 10f;
        GetComponent<Rigidbody2D>().AddForce(magnitude * direction, ForceMode2D.Impulse);
    }
}