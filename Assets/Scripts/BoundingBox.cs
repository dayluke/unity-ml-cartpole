using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingBox : MonoBehaviour
{
    public CartController cartController;

    private void OnTriggerEnter(Collider coll)
    {
        cartController.ResetGame();
    }
}
