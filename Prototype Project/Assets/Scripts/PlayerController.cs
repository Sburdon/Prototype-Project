using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public GameObject projectilePrefab;
    public Transform firePoint;  // The position from which projectiles will be spawned

    private Vector2 movement;
    private Vector2 mousePosition;

    void Update()
    {
        // Handle player movement
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        movement = new Vector2(moveX, moveY).normalized;

        // Get mouse position and shoot if left mouse button is clicked
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        // Apply movement
        transform.Translate(movement * speed * Time.fixedDeltaTime);
    }

    private void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Vector2 direction = mousePosition - (Vector2)firePoint.position;
        projectile.GetComponent<Projectile>().Initialize(direction.normalized);
    }
}