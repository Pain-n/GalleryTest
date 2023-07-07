using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public static CarController Instance;

    public GameObject Car;
    Rigidbody rb;
    public float Speed;
    public float RotationSpeed;
    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    void Start()
    {
        rb = Car.GetComponent<Rigidbody>();
    }

    public void Move(float direction)
    {
        rb.AddForce(Car.transform.forward * direction * Speed, ForceMode.Force);
    }
    public void TurnAround(float direction)
    {
        Car.transform.Rotate(new Vector3(0, transform.rotation.y + direction * RotationSpeed, 0),Space.Self);
    }
}
