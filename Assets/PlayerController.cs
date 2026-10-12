using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float forwardSpeed = 10f;
    public float laneChangeSpeed = 15f;
    public float laneDistance = 3f; // Distance between lanes

    private int currentLane = 1; // 0: Left, 1: Middle, 2: Right

    void Update()
    {
        // 1. Move forward continuously
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime, Space.World);

        // 2. Register lane change input (A/D or Arrow Keys)
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentLane > 0)
            {
                currentLane--;
                Debug.Log("Moved Left! Current Lane: " + currentLane);
            }
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentLane < 2)
            {
                currentLane++;
                Debug.Log("Moved Right! Current Lane: " + currentLane);
            }
        }

        // 3. Calculate target lane X position (-3, 0, or 3)
        float targetX = (currentLane - 1) * laneDistance;
        Vector3 currentPos = transform.position;

        // 4. Smoothly shift to target X position while maintaining Y and forward Z position
        Vector3 targetPosition = new Vector3(targetX, currentPos.y, currentPos.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, laneChangeSpeed * Time.deltaTime);
    }
}