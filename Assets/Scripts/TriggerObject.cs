using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerObject : MonoBehaviour
{
    [SerializeField]
    private float _timer;
    private bool _isFinished = false;
    [SerializeField]
    private UnityEvent _updateFinished;


    public void UpdateTimer()
    {
        if (_isFinished) return;
        _timer -= Time.deltaTime;
        print(_timer);
        if(_timer < 0)
        {
            _timer = 0;
            _isFinished = true;
            print("FINISHED");
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
            _updateFinished.Invoke();
        }
    }

}
