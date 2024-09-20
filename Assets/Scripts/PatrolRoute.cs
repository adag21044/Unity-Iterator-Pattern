using System.Collections.Generic;
using UnityEngine;

public class PatrolRoute : MonoBehaviour
{
    private List<Vector3> patrolPoints = new List<Vector3>();

    // Devriye rotasına nokta ekler
    public void AddPatrolPoint(Vector3 point)
    {
        patrolPoints.Add(point);
    }

    public Vector3 GetPatrolPoint(int index)
    {
        if (index < 0 || index >= patrolPoints.Count)
        {
            return Vector3.zero; // Geçersiz index kontrolü
        }
        return patrolPoints[index];
    }

    public int GetPatrolPointCount()
    {
        return patrolPoints.Count;
    }

    // Sahnedeki belirli objelerin Transform'larını devriye rotasına ekler
    public void AddTransform(Transform point)
    {
        patrolPoints.Add(point.position);
    }
}
