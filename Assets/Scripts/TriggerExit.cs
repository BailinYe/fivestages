using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TriggerExit : MonoBehaviour
{
    [SerializeField]
    private GameObject _groundExit;
    [SerializeField]
    private int _totalTriggersNeeded;
    private int _currentTriggerNumber = 0;

    public void UpdateCurrentTriggerNumber()
    {
        _currentTriggerNumber++;
        print("Update Trigger Number");
        if(_currentTriggerNumber >= _totalTriggersNeeded )
        {
            print("Exit Ready");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_currentTriggerNumber >= _totalTriggersNeeded)
        {
            _groundExit.SetActive(false);
            FindObjectOfType<CameraMove>().StartCameraMove();
            gameObject.SetActive(false);
        }
        if(gameObject.tag == "ExitToTitleScreen")
        {
            ExitToTitleScreen();
        }
    }

    private void ExitToTitleScreen()
    {
        SceneManager.LoadScene(0);
    }
}
