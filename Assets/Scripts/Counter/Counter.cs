using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private int _counterNumber = 0;
    [SerializeField] private float _delay = 0.5f;
    private bool isCountingUp = false;
    private Coroutine countCoroutine;

    private void Start()
    {
        _text.text = "0";
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ToggleCounter();
    }

    private void ToggleCounter()
    {
        if (isCountingUp)
            StopCounter();
        else
            StartCounter();
    }

    private void StartCounter()
    {
        if (countCoroutine == null)
            countCoroutine = StartCoroutine(Countdown());

        isCountingUp = true;
    }

    private void StopCounter()
    {
        if (countCoroutine != null)
        {
            StopCoroutine(countCoroutine);
            countCoroutine = null;
        }

        isCountingUp = false;
    }

    private IEnumerator Countdown()
    {
        while (true)
        {
            yield return new WaitForSeconds(_delay);
            _counterNumber++;
            DisplayCountdown(_counterNumber);
        }
    }

    private void DisplayCountdown(int count)
    {
        _text.text = count.ToString();
    }
}
