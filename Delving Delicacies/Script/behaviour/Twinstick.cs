using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twinstick : MonoBehaviour
{

    [SerializeField] float shotDelay = 0.3f; //time between shots
    private float shotCooldown = 0; //current active cooldown

    [SerializeField] GameObject projectile;
    [SerializeField] GameObject shotPoint;
    [SerializeField] Camera gameCam;
    private AudioSource mySound;

    void Start()
    {
        mySound = GetComponent<AudioSource>();
        adjustVolume();
    }

    
    void Update()
    {

        Vector3 mousePos = gameCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (InputManager.mouseContinuous)
        {
            if (shotCooldown <= 0)
            {
                //set cooldown between shots
                shotCooldown = shotDelay;

                //aim and provide direction to the projectile prefab
                if (projectile != null)
                {   
                    if (shotPoint == null)
                    {
                        Instantiate(projectile, transform.position, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(projectile, shotPoint.transform.position, Quaternion.identity);
                    }

                    audioFunction(true);

                }
            }
        }

        if (shotCooldown > 0)
        {
            shotCooldown -= Time.deltaTime;
        }
    }

    private void audioFunction(bool pitch)
    {
        if (pitch)
        {
            mySound.pitch = Random.Range(0.5f,1.5f);
        }
        else
        {
            mySound.pitch = 1f;
        }

        mySound.Play();
    }

    private void adjustVolume()
    {
        mySound.volume = PlayerPrefs.GetFloat("Volume_Sound");
    }
}
