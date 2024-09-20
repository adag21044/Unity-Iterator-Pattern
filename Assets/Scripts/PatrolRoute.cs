using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolRoute : MonoBehaviour, IEnumerable<Vector3>
{
    private List<Vector3> patrolPoints = new List<Vector3>();

    // Add point to the patrol route
    public void AddPatrolPoint(Vector3 point)
    {
        patrolPoints.Add(point);
    }

    public IEnumerator<Vector3> GetEnumerator()
    {
        return patrolPoints.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }


    public int GetPatrolPointCount()
    {
        return patrolPoints.Count;
    }

    // Devriye rotasına sahnedeki belirli objeleri eklemek için
    public void AddTransform(Transform point)
    {
        patrolPoints.Add(point.position);
    }
}
