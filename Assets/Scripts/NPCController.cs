using UnityEngine;

public class NPCController : MonoBehaviour
{
    public PatrolRoute patrolRoute; // Reference to the patrol route
    private PatrolIterator patrolIterator; // Iterator for the patrol route
    public float speed = 2f;

    private Vector3 currentTarget; 

    private void Start()
    {
        patrolRoute.AddTransform(GameObject.Find("Point1").transform);
        patrolRoute.AddTransform(GameObject.Find("Point2").transform);
        patrolRoute.AddTransform(GameObject.Find("Point3").transform);
        patrolRoute.AddTransform(GameObject.Find("Point4").transform);

        patrolIterator = new PatrolIterator(patrolRoute);
        GoToNextPatrolPoint();
    }

    private void Update() => Patrol();

    private void Patrol()
    {
        if(patrolIterator.HasNext())
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, step);

            if(Vector3.Distance(transform.position, currentTarget) < 0.1f)
            {
                patrolIterator.MoveNext();
                GoToNextPatrolPoint();
            }
        }
        else
        {
            patrolIterator.Reset(); // All points visited, reset the iterator
        }
    }

    private void GoToNextPatrolPoint()
    {
        if(patrolIterator.HasNext())
        {
            currentTarget = patrolIterator.Next();
        }
    }
}