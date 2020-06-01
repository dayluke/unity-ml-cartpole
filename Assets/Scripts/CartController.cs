using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartController : MonoBehaviour
{
    public float speed;
    public float resetAngle;
    public GameObject pole;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (pole.transform.rotation.eulerAngles.z < 360 - resetAngle &&
            pole.transform.rotation.eulerAngles.z > resetAngle)
        {
            ResetGame();
        }
    }

    private void ResetGame()
    {
        Debug.Log("Reset");
    }
}
