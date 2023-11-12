using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _moveStartedEvent;
    [SerializeField]
    private UnityEvent _moveEndedEvent;
    IEnumerator MoveToNextCameraPosition(float l_time)
    {
        Vector3 startingPos = transform.position;
        Vector3 finalPos = transform.position + (-transform.up * 10);

        float elapsedTime = 0;
        _moveStartedEvent.Invoke();
        //print("MOVE STARTED");
        while (elapsedTime < l_time)
        {
            transform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / l_time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        //print("MOVE ENDED");
        _moveEndedEvent.Invoke();
    }

    public void StartCameraMove()
    {
        StartCoroutine(MoveToNextCameraPosition(1f));
    }
}
