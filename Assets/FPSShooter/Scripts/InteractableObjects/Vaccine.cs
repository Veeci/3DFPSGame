using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vaccine : Interactable
{
    [SerializeField]
    private GameObject vaccine;
    public GameObject WinPanel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Interact()
    {
        vaccine.SetActive(false);
        SceneManager.LoadScene("Win", LoadSceneMode.Single);
    }
}
