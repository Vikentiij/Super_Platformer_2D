using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private List<Transform> movementPoints;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject fireballPrefab;

    int currentMovementPoint;

    // Start is called before the first frame update
    void Start()
    {
        currentMovementPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float step = movementSpeed * Time.deltaTime;

        // move sprite towards the target location
        if (
            gameObject.transform.position.x != movementPoints[currentMovementPoint].transform.position.x
            && gameObject.transform.position.y != movementPoints[currentMovementPoint].transform.position.y
        )
        {
            transform.position = Vector2.MoveTowards(transform.position, movementPoints[currentMovementPoint].transform.position, step);
        }
        else
        {
            Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
            currentMovementPoint++;
            if (currentMovementPoint >= movementPoints.Count)
                currentMovementPoint = 0;

            Debug.Log(currentMovementPoint);
        }
    }
}
