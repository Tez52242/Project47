using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SafeLogicView : MonoBehaviour
{
    [SerializeField] private List<Button> _digitButtons;
    [SerializeField] private Button _clearButton;
    [SerializeField] private Button _submitButton;
    [SerializeField] private Button _exitButton;

    private Safe _safe;

    public void Initialize(Safe safe)
    {
        _safe = safe;

        Debug.Log("SafeLogicView Initialized " + _safe);

        for (int i = 0; i < _digitButtons.Count; i++)
        {
            int capturedIndex = i;

            Debug.Log($"Button {capturedIndex} Initialized");

            _digitButtons[i].onClick.AddListener(() => _safe.AddDigit(capturedIndex.ToString()));
        }

        _clearButton.onClick.AddListener(_safe.ClearInput);
        _submitButton.onClick.AddListener(_safe.SubmitCode);
        _exitButton.onClick.AddListener(_safe.Exit);
    }
}