using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool _iteminRange;
    private string _item;
    public GameObject _pickupObject;
    public GameObject _slot;

    [SerializeField] private float walkSpeed = 3f;
    [SerializeField] private float acceleration = 6f;
    [SerializeField] private float deceleration = 7f;
    [SerializeField] private float sprintSpeed = 6f;

    private float currentSpeed = 0f;

    public static GameObject instance;

    Rigidbody2D myRB;
    //Animator myAnim;
    PlayerAim playerAim;
    public List<GameObject> slots = new List<GameObject>();
    private GameObject[] ItemSlots;
    private int openSlot = 0;

    private void Awake()
    {
        myRB = GetComponent<Rigidbody2D>();
        playerAim = GetComponent<PlayerAim>();
        //myAnim = GetComponent<Animator>();

        ItemSlots = GameObject.FindGameObjectsWithTag("Slots");
        foreach(GameObject i in ItemSlots)
        {
            slots.Add(i);
        }

        _slot = slots[openSlot];

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

    private void Update()
    {
        if (playerAim.isAimingDownSights == true)
        {
            walkSpeed = 1.5f;
            acceleration = 3f;
            deceleration = 8f;
            sprintSpeed = 1f;
            playerAim.AimWithMouse();
        }
        else
        {
            walkSpeed = 3f;
            acceleration = 6f;
            deceleration = 7f;
            sprintSpeed = 6f;
        }
        
        if (Input.GetMouseButton(0))
        {

        }

        if (Input.GetMouseButton(1))
        {
            playerAim.SetAiming(true);
        }
        else
        {
            playerAim.SetAiming(false);
        }
        

        float move = Input.GetAxis("Horizontal");
        bool isSprinting = Input.GetKey(KeyCode.LeftShift);
        //myAnim.SetFloat("speed",Mathf.Abs(move));

        float targetSpeed = isSprinting ? sprintSpeed : walkSpeed;
        currentSpeed = Mathf.MoveTowards(currentSpeed, move * targetSpeed,
                                        (isSprinting ? acceleration : deceleration) * Time.deltaTime);

        myRB.velocity = new Vector2(currentSpeed, 0);

        /* Flip the sprite based on the direction
        if (move > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (move < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }*/

        
        if (_iteminRange && _pickupObject != null && Input.GetKeyDown(KeyCode.E))
        {
            //GameManager.instance.GetComponent<GameManager>()._selectedItem = coll.gameObject.GetComponent<HandgunScript>()._name;
            //_fuck = GameObject.Find(GameManager.instance.GetComponent<GameManager>()._slotNum.ToString());
            _slot.GetComponent<ItemSlot>()._itemData = GameManager.instance.GetComponent<GameManager>()._selectedItem;
            _slot.GetComponent<ItemSlot>().invUpdate();
            Destroy(_pickupObject);
            _slot = slots[openSlot + 1];
        }
    }

}