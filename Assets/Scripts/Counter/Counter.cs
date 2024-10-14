using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private int _number;

    private bool _isRunning;
    private Coroutine _countCoroutine;
    private WaitForSeconds _waitDelay;

    public int Number => _number;

    public event Action<int> OnValueChanged;

    private void Awake()
    {
        _waitDelay = new WaitForSeconds(_delay);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ToggleCounter();
    }

    private void ToggleCounter()
    {
        if (_isRunning)
            StopRun();
        else
            StartRun();
    }

    private void StartRun()
    {
        if (_countCoroutine == null)
            _countCoroutine = StartCoroutine(CountRoutine());

        _isRunning = true;
    }

    private void StopRun()
    {
        if (_countCoroutine != null)
        {
            StopCoroutine(_countCoroutine);
            _countCoroutine = null;
        }

        _isRunning = false;
    }

    private IEnumerator CountRoutine()
    {
        while (true)
        {
            yield return _waitDelay;
            _number++;
            OnValueChanged?.Invoke(_number);
        }
    }
}
