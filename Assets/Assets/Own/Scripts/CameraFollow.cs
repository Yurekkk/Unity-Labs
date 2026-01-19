using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float followSpeed;
    [SerializeField] private Vector3 offset;

    void Start()
    {
        Vector3 targetPosition = player.position + offset;
        transform.position = targetPosition;
    }

    // Update is called once per frame
    // LateUpdate, чтобы следовать за игроком после его движения
    void LateUpdate()
    {
        Vector3 targetPosition = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        transform.LookAt(player);
    }
}
