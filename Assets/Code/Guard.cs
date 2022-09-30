using System.Collections;
using UnityEngine;

/*
 * Enemy pathing
 * Source: Introduction to Game Development (E24: stealth game 1/3), Sebastian Lague
 * https://www.youtube.com/watch?v=jUdx_Nj4Xk0, 2017, April 14th
 */

public class Guard : MonoBehaviour
{
    public Transform path;
    public float speed = 10;
    public float wait = .3f;
    public float turnSpeed = 90f;
    public float timeToSpot = .5f;
    public GameUI gameover;
    float playerTimer;

    public Light light;
    public float viewDistance;
    public Transform player;
    public LayerMask viewMask;
    float viewAngle;
    Color original;

    void Start()
    {
        viewAngle = light.spotAngle;
        original = light.color;

        //Creates an array of all points in a path
        Vector3[] points = new Vector3[path.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = path.GetChild(i).position;
        }

        //Calls the path traveling function
        StartCoroutine(FollowPath(points));
    }

    void Update()
    {
        if (CanSeePlayer())
        {
            playerTimer += Time.deltaTime;
        } else
        {
            playerTimer -= Time.deltaTime;
        }
        playerTimer = Mathf.Clamp(playerTimer, 0, timeToSpot);
        light.color = Color.Lerp(original, Color.red, playerTimer / timeToSpot);
        //slowly transitions to a red color as player gets spotted for longer

        if (playerTimer >= timeToSpot)
        {
            // Game Over
            gameover.ShowGameLoseUI();
        }
    }

    void OnDrawGizmos()
    {
        Vector3 startPos = path.GetChild(0).position;
        Vector3 previousPos = startPos;
        // visualize the points/path which the enemy will take
        foreach (Transform waypoint in path)
        {
            Gizmos.DrawSphere(waypoint.position, .3f);
            Gizmos.DrawLine(previousPos, waypoint.position);
            previousPos = waypoint.position;
        }
        //draw line from final to first point
        Gizmos.DrawLine(previousPos, startPos);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * viewDistance);
    }

    IEnumerator FollowPath(Vector3[] points)
    {
        // Function to get the enemy to follow the path
        // IEnumerator because there is a delay before the enemy goes to the next point.
        transform.position = points[0]; //sets position to the first index

        int index = 1; //index after the start
        Vector3 target = points[index]; //sets the target waypoint to the second index
        transform.LookAt(target);

        while(true)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            // moves towards the target point 
            if (transform.position == target) //once the enemy reaches the target
            {
                index = (index + 1) % points.Length; //Increments the index, modulus is to prevent overflow
                target = points[index]; //sets the new target
                yield return new WaitForSeconds(wait); //delay
                yield return StartCoroutine(Turn(target));
            }
            yield return null;
        }
    }

    bool CanSeePlayer()
    {
        // function called to detect if player is seen
        if (Vector3.Distance(transform.position,player.position) < viewDistance)
        {
            // If player is within view distance
            Vector3 direction = (player.position - transform.position).normalized;
            float angle = Vector3.Angle(transform.forward, direction);
            if (angle < viewAngle / 2f) //if player is within spotlight angle
            {
                if (!Physics.Linecast(transform.position, player.position, viewMask))
                {
                    // if the obstacle isnt in the way between the player and the guard
                    return true;
                }
            }
        }
        return false;
    }

    IEnumerator Turn(Vector3 target)
    {
        // Function to get the guard to fluently turn to the next point
        // VERY important for the spotlight
        Vector3 direction = (target - transform.position).normalized;
        float targetAngle = 90 - Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;

        while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle)) > 0.05) //condition to stop this loop when the guard is looking at its target point
        {
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, turnSpeed * Time.deltaTime);
            transform.eulerAngles = Vector3.up * angle;
            yield return null;
        }
    }
}