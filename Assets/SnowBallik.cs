using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class SnowBallik : MonoBehaviour
{
    private GameObject currentBall;
    private bool Player_in_Range;
    private PlayerInput _playerInput;
    private bool Playerhold;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Snowball"))
        {   
            currentBall = other.gameObject;
            Player_in_Range = true;
            Debug.Log(Player_in_Range);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Snowball"))
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
            currentBall.GetComponent<MeshCollider>().isTrigger = true;
            currentBall.transform.parent = transform;
            currentBall.transform.DOLocalMove(new Vector3(0.4f, 0.0f, 0.6f), 0.3f);
            Player_in_Range = false;
            Playerhold = true;
        }

        if (Playerhold == true && _playerInput.actions["Attack"].triggered)
        {
            Debug.Log("я ебал мать твою ваньку совенка");
        }
    }
}
