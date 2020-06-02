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
        ResetGame();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(pole.transform.rotation.z);
        sensor.AddObservation(poleRigidbody.velocity);
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        if (Mathf.FloorToInt(vectorAction[0]) == 1)
        {
            MoveCart(Vector3.left);
        }

        if (Mathf.FloorToInt(vectorAction[0]) == 2)
        {
            MoveCart(Vector3.right);
        }

        if (pole.transform.rotation.eulerAngles.z < 360 - resetAngle &&
            pole.transform.rotation.eulerAngles.z > resetAngle)
        {
            SetReward(-1f);
            EndEpisode();
        }
        else
        {
            SetReward(0.1f);
        }
        Debug.Log(GetCumulativeReward());
    }

    public override void OnEpisodeBegin()
    {
        ResetGame();
    }

    public override void Heuristic(float[] actionsOut)
    {
        // Player input
        actionsOut[0] = 0;
        if (Input.GetKey(KeyCode.A))
        {
            actionsOut[0] = 1;
        }
    
        if (Input.GetKey(KeyCode.D))
        {
            actionsOut[0] = 2;
        }

        if (pole.transform.rotation.eulerAngles.z < 360 - resetAngle &&
            pole.transform.rotation.eulerAngles.z > resetAngle)
        {
            EndEpisode();
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
    
    private void MoveCart(Vector3 dir)
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }
}
