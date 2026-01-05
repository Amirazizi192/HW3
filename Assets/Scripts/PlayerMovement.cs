using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 10f;
    public float laneDistance = 2f;

    int currentLane = 1; // 0=Left,1=Mid,2=Right

    void Update()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.A))
            ChangeLane(-1);

        if (Input.GetKeyDown(KeyCode.D))
            ChangeLane(1);

        Vector3 pos = transform.position;
        pos.x = (currentLane - 1) * laneDistance;
        transform.position = Vector3.Lerp(transform.position, pos, 10 * Time.deltaTime);
    }

    void ChangeLane(int dir)
    {
        currentLane = Mathf.Clamp(currentLane + dir, 0, 2);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GameManager.instance.GameOver();
        }
    }
}
