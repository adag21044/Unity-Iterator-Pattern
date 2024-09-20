using UnityEngine;

public class PatrolIterator 
{
    private PatrolRoute patrolRoute;
    private int currentIndex = 0;
    
    public PatrolIterator(PatrolRoute route)
    {
        this.patrolRoute = route;
    }

    // Checks if there is another patrol point to visit
    public bool HasNext()
    {
        return currentIndex < patrolRoute.GetPatrolPointCount();
    }

    // Returns the current patrol point and advances the iterator
    public Vector3 Next()
    {

        if(!HasNext()) return Vector3.zero;
        return patrolRoute.GetPatrolPoint(currentIndex);
    }

    // Move to the next point in the patrol route
    public void MoveNext()
    {
        if (HasNext())
        {
            currentIndex++;
        }
    }

    // Reset the iterator to the beginning of the patrol route
    public void Reset()
    {
        currentIndex = 0;
    }
}