using UnityEngine;
using UnityEngine.InputSystem;

public class SnowBallik : MonoBehaviour
{
    
    private bool Player_in_Range;
    private PlayerInput _playerInput;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Snowball")
        {
            Player_in_Range = true;
            Debug.Log(Player_in_Range);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Snowball")
        {
            Player_in_Range = false;
            Debug.Log(Player_in_Range);
        }
    }


    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        if (_playerInput == null)
        {
            Debug.Log("YEBOK");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Player_in_Range == true && _playerInput.actions["Interact"].triggered)
        {
                
        }
    }
}
