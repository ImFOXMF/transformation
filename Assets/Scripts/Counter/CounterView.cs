using TMPro;
using UnityEngine;

[RequireComponent(typeof(Counter))]
public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _displayText;

    private Counter _counter;

    private void Awake()
    {
        _counter = GetComponent<Counter>();
    }

    private void OnEnable()
    {
        _counter.OnValueChanged += UpdateDisplay;
    }

    private void OnDisable()
    {
        _counter.OnValueChanged -= UpdateDisplay;
    }

    private void Start()
    {
        UpdateDisplay(_counter.Number);
    }

    private void UpdateDisplay(int value)
    {
        _displayText.text = value.ToString();
    }
}
