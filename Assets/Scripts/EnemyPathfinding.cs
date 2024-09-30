using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Add this for scene management

public class EnemyPathfinding : MonoBehaviour
{
    public Transform target; // The target the enemy will follow
    public float speed = 3f; // Movement speed
    public float stoppingDistance = 0.5f; // Distance to stop from the target
    public float updatePathTime = 0.5f; // How often to update the path

    private Queue<Vector3> path = new Queue<Vector3>();
    private Vector3 currentWaypoint;
    private float nextPathUpdate;

    void Start()
    {
        currentWaypoint = transform.position;
        UpdatePath();
    }

    void Update()
    {
        if (Time.time >= nextPathUpdate)
        {
            UpdatePath();
            nextPathUpdate = Time.time + updatePathTime;
        }

        if (path.Count > 0)
        {
            MoveAlongPath();
        }
    }

    void MoveAlongPath()
    {
        currentWaypoint = path.Peek();

        // Move towards the current waypoint
        Vector3 direction = (currentWaypoint - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // Check if the enemy reached the waypoint
        if (Vector3.Distance(transform.position, currentWaypoint) < stoppingDistance)
        {
            path.Dequeue(); // Remove the waypoint
        }
    }

    void UpdatePath()
    {
        // Simple example: creating a new path towards the target
        path.Clear();
        path.Enqueue(target.position);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the enemy collides with the player
        if (other.CompareTag("Player"))
        {
            // Reload the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}