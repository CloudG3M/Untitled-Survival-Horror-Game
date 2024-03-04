using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameObject instance;
    public GameObject canvas;
    public GameObject player;
    public ItemData _selectedItem;
    public int _slotNum = 1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this.gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvas.activeInHierarchy == false)
            {
                canvas.SetActive(true);
                player.GetComponent<PlayerController>().enabled = false;
            }
            else
            {
                canvas.SetActive(false);
                player.GetComponent<PlayerController>().enabled = true;
            }
        }
    }

    


}
