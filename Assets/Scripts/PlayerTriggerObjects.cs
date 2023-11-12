using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerObjects : MonoBehaviour
{
    private TriggerObject _currentTriggerObject;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<TriggerObject>() != null)
        {
            _currentTriggerObject = other.GetComponent<TriggerObject>();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(_currentTriggerObject != null)
        {
            _currentTriggerObject.UpdateTimer();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(_currentTriggerObject != null)
        {
            _currentTriggerObject = null;
        }
    }
}
