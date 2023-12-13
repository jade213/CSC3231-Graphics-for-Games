using UnityEngine;

public class whaleMovement : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 1f;
    public float radius = 350f;
    public float angle = 0f;
    public float bobbingSpeed = 1f; // Adjust this value to control the bobbing speed
    public float bobbingAmount = 2f; // 

    void Update()
    {
        float x = target.position.x + Mathf.Cos(angle) * radius;
        float y = target.position.y + Mathf.Sin(Time.time * bobbingSpeed) * bobbingAmount;
        float z = target.position.z + Mathf.Sin(angle) * radius;

        transform.position = new Vector3(x, y, z);

        angle += rotationSpeed * Time.deltaTime;

        float nextX = target.position.x + Mathf.Cos(angle) * radius;
        float nextZ = target.position.z + Mathf.Sin(angle) * radius;

        Vector3 direction = new Vector3(nextX - x, 0f, nextZ - z);

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
    }
}
