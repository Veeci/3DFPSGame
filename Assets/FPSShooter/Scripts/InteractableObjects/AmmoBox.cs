using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : Interactable
{
    GunScript gun;

    [SerializeField]
    private GameObject ammoBox;
    private GunScript gunScript;
    public float additionalAmmo;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            gunScript = player.GetComponent<GunScript>();
        }

        if (gunScript == null)
        {
            Debug.LogError("GunScript component not found on the player object.");
        }
        else
        {
            gun = gunScript; // Assigning gunScript to gun
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Interact()
    {
        if (gun != null)
        {
            ammoBox.SetActive(false);
        }
        else
        {
            Debug.LogError("GunScript component is not assigned.");
        }
    }
}
