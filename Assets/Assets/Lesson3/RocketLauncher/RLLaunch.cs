using System.Collections;
using UnityEngine;

public class RLLaunch : MonoBehaviour
{
    //[SerializeField] private InputActionAsset InputActions;
    [SerializeField] private float coolDown = 5f;
    [SerializeField] private Transform launchPoint;
    [SerializeField] private GameObject rocket;

    void Start()
    {
        StartCoroutine(AutoFire());
    }

    void Launch()
    {
        Debug.Log("Shot");
        var obj = Instantiate(rocket, launchPoint.position, launchPoint.rotation);
        obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }

    IEnumerator AutoFire()
    {
        while (true)
        {
            Launch();
            yield return new WaitForSecondsRealtime(coolDown);
        }
    }
}
