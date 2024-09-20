using UnityEngine;

public class PatrolIterator 
{
    private PatrolRoute patrolRoute;
    private int currentIndex = 0;
    
    public PatrolIterator(PatrolRoute route)
    {
        this.patrolRoute = route;
    }

    public bool HasNext()
    {
        return currentIndex < patrolRoute.GetPatrolPointCount();
    }

    public Vector3 Next()
    {

        if(!HasNext()) return Vector3.zero;
        return patrolRoute.GetEnumerator().Current;
    }

    // Move to the next point in the patrol route
    public void MoveNext()
    {
        currentIndex++;
    }

    // Reset the iterator to the beginning of the patrol route
    public void Reset()
    {
        currentIndex = 0;
    }
}