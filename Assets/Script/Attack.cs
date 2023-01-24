using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoftGear.Strix.Unity.Runtime;
using UnityEngine.UI;
using UnityEngine.Events;

public class Attack : StrixBehaviour
{
    [StrixSyncField]
    public int Hp = 100;
    public int Maxhp = 100;
    public int Damage = 10;
    public float rayDistance = 3f;
    public float force = 10;
    RaycastHit hit;
    Animator m_Animator;
    private int otherHp;
    bool OnDie;
    private float deadTime = 0;


    private void Start()
    {
        m_Animator = GetComponent<Animator>();  
    }
    private void Update()
    {
        if (!isLocal)
        {
            return;
        }
        Vector3 rayPosition = transform.position + new Vector3(0,1,0);
        Ray ray = new Ray(rayPosition, transform.forward);
        Debug.DrawRay(rayPosition, ray.direction * rayDistance, Color.red);

        if (Input.GetButtonDown("Fire1"))
        {
            RpcToAll("AttackMotion");
        }
        }
    [StrixRpc]
    public void AttackMotion()
    {
        Vector3 rayPosition = transform.position + new Vector3(0, 1, 0);
        Ray ray = new Ray(rayPosition, transform.forward);
            if (!isLocal)
            {
                return;
            }
            m_Animator.SetTrigger("OnAttack");
            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                GameObject hitObject = hit.collider.gameObject;
                Rigidbody rigidbody = hitObject.GetComponent<Rigidbody>();
                Vector3 distination = (transform.position - hitObject.transform.position).normalized;
            if (rigidbody != null)
            {
                rigidbody.AddForce(distination * force, ForceMode.Impulse);
            }
            Attack attack = hitObject.GetComponent<Attack>();
            Debug.Log(attack);
                    if (attack != null)
                    {
                Debug.Log("‚Æ‚ê‚Ä‚é");
                attack.RpcToAll("OnHit");
                    }
                
            }
        
    }
    [StrixRpc]
    public void OnHit()
    {
       
        int hp  = Hp - Damage;


        if (hp < 0)
        {
            hp = 0;
        }
           RpcToAll(nameof(SetHealth),hp);
    }
 
    
    [StrixRpc]
    public void SetHealth(int hp)
    {
        if (hp < 0)
        {
           hp = 0;
        }
        else if (hp > Maxhp)
        {
            hp = Maxhp;
        }

        m_Animator.SetInteger("Health", hp);

        if (m_Animator != null)
        {
            if (hp < Hp)
            {
                if (hp <= 0)
                {
                    m_Animator.SetTrigger("OnDie");
                }
                else
                {
                    m_Animator.SetTrigger("OnDamage");
                }
            }

            if (hp > 0 && Hp <= 0)
            {
                Respawn();
            }
        }

        if (Hp != hp)
        {
            if (hp <= 0)
            {
                deadTime = Time.time;
            }
        }

        Hp = hp;
    }

    private void Respawn()
    {
        if (!CompareTag("Player") && isLocal)
        {
            transform.position = new Vector3(Random.Range(-40.0f, 40.0f), 2, Random.Range(-40.0f, 40.0f));
        }
    }
}