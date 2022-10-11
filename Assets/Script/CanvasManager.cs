using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private RectTransform _speedGroup;
    [SerializeField] private RectTransform _distanceGroup;
    [SerializeField] private RectTransform _intervalGroup;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _stopButton;
    [SerializeField] private Spawner _spawner;


    public void Start()
    {
        _startButton.gameObject.SetActive(true);
        _stopButton.gameObject.SetActive(false);
        _spawner.enabled = false;
    }

    public void OnChangeSpeedInputField()
    {
        float value;
        if (float.TryParse(_speedGroup.GetComponentInChildren<InputField>().text, out value))
            _spawner.SetSpeed(value);
    }

    public void OnChangeDistanceInputField()
    {
        float value;
        if (float.TryParse(_distanceGroup.GetComponentInChildren<InputField>().text, out value))
            _spawner.SetDistance(value);
    }

    public void OnChangeIntervalInputField()
    {
        int value;
        if (int.TryParse(_intervalGroup.GetComponentInChildren<InputField>().text, out value))
            _spawner.SetInterval(value);
    }

    public void SwitchSpawner()
    {
        _startButton.gameObject.SetActive(!_startButton.gameObject.activeSelf);
        _stopButton.gameObject.SetActive(!_stopButton.gameObject.activeSelf);
        _spawner.enabled = !_spawner.enabled;
    }
}
