using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;

public class CartController : Agent
{
    public float speed;
    public float resetAngle;
    public float minStartAngle;
    public float maxStartAngle;
    public GameObject pole;
    public Rigidbody poleRigidbody;

    public override void Initialize()
    {

    }

    public override void CollectObservations(VectorSensor sensor)
    {
        
    }

    public override void OnActionReceived(float[] vectorAction)
    {

    }

    public override void OnEpisodeBegin()
    {
        // Reset environment
    }

    public override void Heuristic(float[] actionsOut)
    {
        // Player input
    }

    private void Awake()
    {
        ResetGame();
    }

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

    public void ResetGame()
    {
        Debug.Log("Reset");
        pole.GetComponent<Rigidbody>().isKinematic = true;
        pole.GetComponent<Rigidbody>().velocity = pole.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        pole.transform.position = Vector3.up * 2;
        //pole.transform.rotation = Quaternion.Euler(Vector3.zero);

        float startingAngle = Random.Range(minStartAngle, maxStartAngle);
        pole.transform.rotation = Quaternion.Euler(new Vector3(0, 0, startingAngle));

        this.gameObject.transform.position = Vector3.zero;

        pole.GetComponent<Rigidbody>().isKinematic = false;
    }
}
