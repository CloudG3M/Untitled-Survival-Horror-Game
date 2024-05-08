using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public bool isAimingDownSights = false;
    public Transform gunBarrel;
    public float bulletSpeed = 10f;
    public GameObject bulletPrefab;

    public void SetAiming(bool isAiming)
    {
        isAimingDownSights = isAiming;
    }

    public void Update()
    {
        if (isAimingDownSights && Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (isAimingDownSights)
        {
            GameObject bullet = Instantiate(bulletPrefab, gunBarrel.position, gunBarrel.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = gunBarrel.right * bulletSpeed;
        }
    }

    public void AimWithMouse()
    {
        if (!isAimingDownSights)
        {
            Vector3 mousePosition = Input.mousePosition;

            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, transform.position.z - Camera.main.transform.position.z));

            Vector2 direction = (mouseWorldPosition - transform.position).normalized;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, angle), rotationSpeed * Time.deltaTime);
        }
    }
}
