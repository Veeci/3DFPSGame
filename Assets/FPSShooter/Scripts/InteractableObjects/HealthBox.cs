using UnityEngine;

public class HealthBox : Interactable
{
    [SerializeField]
    private GameObject FirstAidKit;

    private PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        // Assuming the player has a tag called "Player"
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
        }

        if (playerHealth == null)
        {
            Debug.LogError("PlayerHealth component not found on the player object.");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Interact()
    {
        if (playerHealth != null)
        {
            playerHealth.GainHealth(60f);
            FirstAidKit.SetActive(false);
        }
        else
        {
            Debug.LogError("PlayerHealth component is not assigned.");
        }
    }
}
