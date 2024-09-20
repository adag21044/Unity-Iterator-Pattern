using UnityEngine;

public class NPCController : MonoBehaviour
{
    public PatrolRoute patrolRoute; // Reference to the patrol route
    private PatrolIterator patrolIterator; // Iterator for the patrol route
    public float speed = 2f; // Speed at which the NPC moves between points

    private Vector3 currentTarget; // The current target patrol point

    private void Start()
    {
        // Add patrol points by finding specific GameObjects in the scene
        patrolRoute.AddTransform(GameObject.Find("Point1").transform);
        patrolRoute.AddTransform(GameObject.Find("Point2").transform);
        patrolRoute.AddTransform(GameObject.Find("Point3").transform);
        patrolRoute.AddTransform(GameObject.Find("Point4").transform);

        patrolIterator = new PatrolIterator(patrolRoute); // Create an iterator for the patrol route
        GoToNextPatrolPoint(); // Set the first target patrol point
    }

    private void Update() => Patrol(); // Call Patrol method every frame

    // Method that moves the NPC towards the current patrol point
    private void Patrol()
    {
        if(patrolIterator.HasNext())
        {
            float step = speed * Time.deltaTime; // Calculate movement step based on speed
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, step); // Move NPC

            // Check if NPC reached the patrol point
            if(Vector3.Distance(transform.position, currentTarget) < 0.1f)
            {
                patrolIterator.MoveNext(); // Move to the next patrol point
                GoToNextPatrolPoint(); // Update current target
            }
        }
        else
        {
            patrolIterator.Reset(); // All points visited, reset the iterator
        }
    }

    // Method to update the NPC's target to the next patrol point
    private void GoToNextPatrolPoint()
    {
        if(patrolIterator.HasNext())
        {
            currentTarget = patrolIterator.Next();
        }
    }
}