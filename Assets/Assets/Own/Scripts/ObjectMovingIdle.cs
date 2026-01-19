using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] public Vector3 rotationSpeed = new(0, 90, 0); // градусов/сек
    [SerializeField] public float upDownSpeed = 2f;      // скорость колебаний
    [SerializeField] public float upDownHeight = 0.03f;   // амплитуда
    private Vector3 startPos;

    void Awake()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Вращение
        transform.Rotate(rotationSpeed * Time.deltaTime);

        // Движение вверх-вниз
        float yOffset = Mathf.Sin(Time.time * upDownSpeed) * upDownHeight;
        transform.position = startPos + Vector3.up * yOffset;
    }
}