using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterTankController : MonoBehaviour
{
    private string _item;
    public GameObject _fuck;

    [SerializeField] private float _movespeed = 2f;
    [SerializeField] private float _turnspeed = 30f;

    public static GameObject instance;

    private CharacterController _cc;

    private void Awake()
    {
        _cc = GetComponent<CharacterController>();

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
        if (Input.GetKey(KeyCode.W))
        {
            _cc.Move(transform.forward * _movespeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            _cc.Move(-transform.forward * _movespeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -_turnspeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, _turnspeed * Time.deltaTime, 0);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _movespeed *= 2f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _movespeed = 2f;
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        //GameObject _fuck;
        if (coll.tag == "Item")
        GameManager.instance.GetComponent<GameManager>()._selectedItem = coll.gameObject.GetComponent<HandgunScript>()._name;
        //_fuck = GameObject.Find(GameManager.instance.GetComponent<GameManager>()._slotNum.ToString());
        _fuck.GetComponent<ItemSlot>()._itemData = GameManager.instance.GetComponent<GameManager>()._selectedItem;
        _fuck.GetComponent<ItemSlot>().invUpdate();
        Destroy(coll.gameObject);
    }

}


   
  
