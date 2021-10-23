using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatapultController : MonoBehaviour
{

    [SerializeField] private GameObject _textCounter;

    private Text textCounterText;
    private int _interval = 3;
    private int _intervalTimerChanges = 1;
    private int _intervalStopValue = 0;
    private bool _isAlreadyTimerSet = false;

    private void Start()
    {
        textCounterText = _textCounter.GetComponent<Text>();
    }


    private void StartAll()
    {
        FixedJoint jointToDestroy = this.GetComponent<FixedJoint>();
        Destroy(jointToDestroy);
    }


    private void Update()
    {
        if(HitManager.Instance.IsHit == 1 && _isAlreadyTimerSet == false)
        {
            StartCoroutine(ExecuteAfterTime(_interval));
            StartCoroutine(TimerSetText());
            _isAlreadyTimerSet = true;
        }
    }


    private IEnumerator ExecuteAfterTime(float interval)
    {
        yield return new WaitForSeconds(interval);
        StartAll();
    }


    private IEnumerator TimerSetText()
    {
        bool isEnd = false;
        while(!isEnd)
        {
            SetTimerText();

            yield return new WaitForSeconds(_intervalTimerChanges);

            if (_interval < _intervalStopValue)
            {
                isEnd = true;
            }

        }

    }



    private void SetTimerText()
    {
        textCounterText.text = _interval.ToString();
        _interval--;
    }




}
