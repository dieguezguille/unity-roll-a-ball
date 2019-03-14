using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float Speed;
    public Rigidbody Rb;
    private int _points;
    public Text CountText;
    public Text WinText;

    void Start()
    {
        Rb.GetComponent<Rigidbody>();
        _points = 0;
        setPointsText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // var speed = Vector3.forward * Speed;

        Rb.AddForce(new Vector3(moveHorizontal, 0.0f, moveVertical) * Speed, ForceMode.Force);       
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            _points += 1;
            setPointsText();
        }
    }

    void setPointsText()
    {
        CountText.text = "Points: " + _points;
        if (_points == 5)
        {
            WinText.text = "YOU WON!";
        }
    }
}
