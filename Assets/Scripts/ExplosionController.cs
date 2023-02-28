using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    private Timer explosionTimer;

    // Start is called before the first frame update
    void Start()
    {
        explosionTimer = gameObject.AddComponent<Timer>();
        explosionTimer.Duration = 1;
        explosionTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (explosionTimer.Finished)
        {
            Destroy(gameObject);
        }
    }
}
