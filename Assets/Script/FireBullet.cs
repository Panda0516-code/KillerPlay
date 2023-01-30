using System.Collections;
using System.Collections.Generic;
using SoftGear.Strix.Unity.Runtime;
using UnityEngine;
using UnityEngine.EventSystems;

public class FireBullet : StrixBehaviour {
    public GameObject bullet;
    public GameObject ring;
    public ParticleSystem particle;
    [Header("溜め増やす値")]
    [SerializeField]
    private float chargepoint;
    [Header("溜め合計ポイント")]
    public float chargepower;
    [Header("上限値")]
    [SerializeField]
    private float maxpower;
    private bool chargereadey;
    Animator m_Animator;
    

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        ring.SetActive(false);

    }
    void Update () {
        if (!isLocal) {
            return;
        }
        if (Input.GetButton("Fire2") && chargepower < maxpower)
        {
            ring.SetActive(true);
            particle.Play();
            m_Animator.SetTrigger("Oncharge");
            chargepower += chargepoint;
            if (chargepower >= maxpower / 4)
            {
                chargereadey = true;
            }
            if (chargepower <= 0 || chargepower < maxpower / 4)
            {
                chargereadey = false;
            }
        }
        if (Input.GetButtonUp("Fire2"))
        {
            ring.SetActive(false);
            particle.Pause();
        }

            if (Input.GetButtonDown("Fire1") && chargereadey) {
	        GameObject instance = Instantiate(bullet);
	        Transform firePos = transform.Find("FirePos");

	        BulletControl bulletControl = instance.GetComponent<BulletControl>();
	        bulletControl.owner = gameObject;
            instance.transform.position = firePos.position;
	        instance.transform.rotation = firePos.rotation;
            chargepower -= 25;
            if(chargepower < 0)
            {
                chargepower = 0;
                chargereadey = false;
            }
           
            
	    }
    }
}
