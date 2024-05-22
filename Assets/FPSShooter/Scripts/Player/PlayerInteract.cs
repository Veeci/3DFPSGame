using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Transform cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI_Interact playerUI_Interact;
    private InputMAnager inputManager;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<MouseLookScript>().myCamera;
        playerUI_Interact = GetComponent<PlayerUI_Interact>();
        inputManager = GetComponent<InputMAnager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI_Interact.UpdateText(string.Empty);
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if(hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI_Interact.UpdateText(interactable.promptMessage);
                if(inputManager.onFoot.Interact.triggered)
                {
                    interactable.BaseInteract();
                }
            }
        }
    }
}
