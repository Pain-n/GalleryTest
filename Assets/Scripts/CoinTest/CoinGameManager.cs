using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGameManager : MonoBehaviour
{
    public GameObject Coin;
    public float RotationSpeed;

    void FixedUpdate()
    {
        Coin.transform.Rotate(new Vector3(0, RotationSpeed, 0), Space.Self);


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Coin")
                {
                    Color newColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
                    hit.collider.GetComponent<MeshRenderer>().material.color = newColor;
                }
            }
        }
    }
}
