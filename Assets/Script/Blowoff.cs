using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoftGear.Strix.Unity.Runtime;

public class Blowoff : StrixBehaviour
{
    [SerializeField]
    float impulse = 300;
    bool isCollision = false;
    Rigidbody rigidBody;
    Rigidbody bulletRigidBody;
    GameObject bullet;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
      Debug.Log("îÚÇ‘ÇÊÇÒÅ`");
    }

    //è’ìÀîªíË
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            bulletRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Debug.Log(bulletRigidBody);
            //êÅÇ¡îÚÇŒÇ∑
            Vector3 playerVelocity = bulletRigidBody.velocity;
            rigidBody.AddForce(playerVelocity * impulse, ForceMode.Impulse);
            rigidBody.AddForce(Vector3.up * impulse, ForceMode.Impulse);

        }
    }
}
