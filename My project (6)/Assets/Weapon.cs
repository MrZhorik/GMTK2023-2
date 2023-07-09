using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
  
        public GameObject bulletPrefab;
        public Transform firepoint;
        public float fireforce = 20f;
 

    // Update is called once per frame
    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position,firepoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firepoint.up * fireforce, ForceMode2D.Impulse);
    }

}
