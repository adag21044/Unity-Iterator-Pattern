using System.Collections.Generic;
using UnityEngine;

public class PatrolRoute : MonoBehaviour
{
    private List<Vector3> patrolPoints = new List<Vector3>();

    // Adds a point to the patrol route
    public void AddPatrolPoint(Vector3 point)
    {
        patrolPoints.Add(point);
    }

    // Returns the patrol point at the specified index
    public Vector3 GetPatrolPoint(int index)
    {
        if (index < 0 || index >= patrolPoints.Count)
        {
            return Vector3.zero; // Invalid index check
        }
        return patrolPoints[index];
    }

    // Returns the number of patrol points in the route
    public int GetPatrolPointCount()
    {
        return patrolPoints.Count;
    }

    // Adds the position of a Transform object to the patrol route
    public void AddTransform(Transform point)
    {
        patrolPoints.Add(point.position);
    }
}
