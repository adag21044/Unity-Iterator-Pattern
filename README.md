# Iterator Pattern in Unity

## Overview
This project demonstrates the use of the Iterator Pattern in Unity by implementing a patrol system for an NPC (Non-Player Character). The NPC moves between predefined patrol points in the scene, showcasing the principles of the Iterator Pattern to navigate through a collection of points.

## Features
- **NPC Movement**: The NPC patrols between multiple points in the scene.
- **Iterator Pattern**: Uses the Iterator design pattern to navigate the patrol points.
- **Modular Design**: The code adheres to SOLID principles, ensuring maintainability and clarity.

## Components

### 1. PatrolRoute.cs
This class manages the patrol points. It allows adding patrol points and provides methods to retrieve them.

```csharp
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
```

### 2. PatrolIterator.cs
This class implements the iterator for the patrol route, allowing sequential access to the patrol points.

```csharp
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
        if (!HasNext()) return Vector3.zero;
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
```

### 3. NPCController.cs
This class controls the NPC's behavior, moving it between patrol points using the iterator.

```csharp
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
        if (patrolIterator.HasNext())
        {
            float step = speed * Time.deltaTime; // Calculate movement step based on speed
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, step); // Move NPC

            // Check if NPC reached the patrol point
            if (Vector3.Distance(transform.position, currentTarget) < 0.1f)
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
        if (patrolIterator.HasNext())
        {
            currentTarget = patrolIterator.Next();
        }
    }
}
```
