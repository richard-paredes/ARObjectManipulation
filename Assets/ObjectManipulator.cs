using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ObjectManipulator : MonoBehaviour
{
    struct ManipulationState {
        public float? RotationValue;
        public float? ScaleValue;
    }

    [SerializeField]
    ManipulatedObject[] _models;
    [SerializeField]
    Slider _rotateControl;
    [SerializeField]
    Slider _scaleControl;

    int _currentModelIdx;
    ManipulationState[] _modelManipulationStates;
    ManipulatedObject _currentDisplayedModel;

    // Start is called before the first frame update
    void Start()
    {
        _currentModelIdx = 0;
        _modelManipulationStates = new ManipulationState[_models.Length];
        SetCurrentModel();
        ToggleActiveModels();
        UpdateManipulationControls();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SaveCurrentModelState()
    {
        _modelManipulationStates[_currentModelIdx].RotationValue = _rotateControl.value;
        _modelManipulationStates[_currentModelIdx].ScaleValue = _scaleControl.value;
    }

    void UpdateManipulationControls()
    {
        UpdateRotateControl();
        UpdateScaleControl();
    }

    void UpdateRotateControl()
    {
        _rotateControl.onValueChanged.RemoveAllListeners();
        _rotateControl.onValueChanged.AddListener(_currentDisplayedModel.RotateY);
        _rotateControl.value = _modelManipulationStates[_currentModelIdx].RotationValue ?? 0;
    }

    void UpdateScaleControl()
    {
        _scaleControl.onValueChanged.RemoveAllListeners();
        _scaleControl.onValueChanged.AddListener(_currentDisplayedModel.Scale);
        _scaleControl.value = _modelManipulationStates[_currentModelIdx].ScaleValue ?? 1;
    }

    void SetCurrentModel()
    {
        _currentDisplayedModel = _models[_currentModelIdx];
    }

    void ToggleActiveModels()
    {
        for (int i = 0; i < _models.Length; i++)
        {
            if (i == _currentModelIdx) _models[i].gameObject.SetActive(true);
            else _models[i].gameObject.SetActive(false);
        }
    }

    void SetCurrentModelIdx(int modelIdx)
    {
        if (modelIdx == _models.Length) _currentModelIdx = 0;
        else if (modelIdx < 0) _currentModelIdx = _models.Length - 1;
        else _currentModelIdx = modelIdx;
    }

    public void SetNextModel()
    {
        SaveCurrentModelState();
        SetCurrentModelIdx(_currentModelIdx + 1);
        SetCurrentModel();
        ToggleActiveModels();
        UpdateManipulationControls();
    }

    public void SetPreviousModel()
    {
        SaveCurrentModelState();
        SetCurrentModelIdx(_currentModelIdx - 1);
        SetCurrentModel();
        ToggleActiveModels();
        UpdateManipulationControls();
    }
}
