using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireSystem : MonoBehaviour {

    public float ReloadCooldown;
    public float AmmoInGun;
    public float AmmoInPocket;
    public float AmmoMax;

    float AddableAmmo;
    float reloadtimer;

    public Text AmmoCounter;
    public Text PocketAmmoCounter;

    public CharacterController Karakter;

    Animator GunAnimset;

    public GameObject impacteffect;
    public GameObject Bloodyimpacteffect;

    RaycastHit hit;

    public GameObject RayPoint;

    public bool canfire;

    float Guntimer;

    public float guncooldown;

    public ParticleSystem MuzzleFlash;

    AudioSource SesKaynak;
    public AudioClip FireSound;

    public float range;
    public float takerange;
    public float damage;

    public AudioClip ReloadSound;


	void Start ()
    {
        SesKaynak = GetComponent<AudioSource>();
        GunAnimset = GetComponent<Animator>();
	}
	

	void Update ()
    {
        GunAnimset.SetFloat("Speed", Karakter.velocity.magnitude);

        AmmoCounter.text = AmmoInGun.ToString();
        PocketAmmoCounter.text = AmmoInPocket.ToString();

        AddableAmmo = AmmoMax - AmmoInGun;

        if (AddableAmmo > AmmoInPocket)
        {
            AddableAmmo = AmmoInPocket;
        }

        if(Input.GetKeyDown(KeyCode.R) && AddableAmmo > 0 && AmmoInPocket > 0)
        {
            if (Time.time > reloadtimer)
            {
                StartCoroutine(Reload());
                reloadtimer = Time.time + ReloadCooldown;
            }



        }





		if (Input.GetKey(KeyCode.Mouse0) && canfire == true && Time.time > Guntimer && AmmoInGun > 0)
        {
            Fire();

            Guntimer = Time.time + guncooldown;
        }
	}

    void Fire()
    {

       

        if (Physics.Raycast(RayPoint.transform.position,RayPoint.transform.forward,out hit,range))
        {
            MuzzleFlash.Play();
            SesKaynak.Play();
            AmmoInGun--;
            SesKaynak.clip = FireSound;

            Debug.Log(hit.transform.name);

            GunAnimset.Play("fire", -1, 0f);

            if(hit.collider.tag == "Untagged")
            {
                Instantiate(impacteffect, hit.point, Quaternion.LookRotation(hit.normal));

            }

            if (hit.collider.tag == "Enemy")
            {
                Instantiate(Bloodyimpacteffect, hit.point, Quaternion.LookRotation(hit.normal));

                hit.collider.gameObject.transform.root.GetComponent<Zombie>().health = hit.collider.gameObject.transform.root.GetComponent<Zombie>().health - damage;
            }


        }

    }


    IEnumerator Reload()
    {
        GunAnimset.SetBool("isreloading", true);

        SesKaynak.clip = ReloadSound;
        SesKaynak.Play();

        yield return new WaitForSeconds(0.3f);
        GunAnimset.SetBool("isreloading", false);

        yield return new WaitForSeconds(1.4f);
        AmmoInGun = AmmoInGun + AddableAmmo;
        AmmoInPocket = AmmoInPocket - AddableAmmo;
    }

}
