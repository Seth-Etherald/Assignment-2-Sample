using UnityEngine;

public class GunnerController : MonoBehaviour
{
    private Rigidbody2D gunnerBody;
    private const int moveSpeed = 10;
    private Vector3 moveDirection = Vector2.up;
    private const float rotateDegreesPerSecond = 180;

    // Start is called before the first frame update
    private void Start()
    {
        gunnerBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetAxis("Rotate") != 0)
        {
            float rotation = Input.GetAxis("Rotate");
            float rotationAmount = rotateDegreesPerSecond * Time.deltaTime;
            if (rotation < 0)
            {
                rotationAmount *= -1;
            }
            transform.Rotate(Vector3.forward, rotationAmount);
        }
    }
}