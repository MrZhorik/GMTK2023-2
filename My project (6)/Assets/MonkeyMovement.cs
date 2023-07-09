using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyMovement : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed = 2f;
    public float fireRate = 1f; // Adjust this to control how often the enemy fires
    public GameObject bulletPrefab; // Assign the bullet prefab in the Inspector
    public Transform firePoint; // Assign the fire point object in the Inspector
    public float respawnDelay = 2f; // Time before enemy respawns at starting position
    
    private int currentWaypointIndex = 0;
    private bool canFire = true;
    private float fireDelay = 2f; // Adjust this to control the delay after firing
    private Vector2 startingPosition;
    
    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        if (currentWaypointIndex < waypoints.Length)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[currentWaypointIndex].position)
            {
                currentWaypointIndex++;
            }

            if(canFire)
            {
                StartCoroutine(Shoot());
            }
        }
        else
        {
            // Reached the end of the path, so stop moving and respawn
            canFire = false;
            StartCoroutine(Respawn());
        }
    }

    IEnumerator Shoot()
    {
        canFire = false;

        // Instantiate the bullet prefab at the fire point position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Add code here to configure the bullet's speed, damage, etc.

        yield return new WaitForSeconds(fireDelay);

        canFire = true;
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnDelay);
        transform.position = startingPosition;
        currentWaypointIndex = 0;
        canFire = true;
    }
}

