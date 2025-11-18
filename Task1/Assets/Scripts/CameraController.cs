using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _home;
    [SerializeField] private Toggle _cameraModeChanger;

    [SerializeField] private float _rotationSpeed = 90f;
    [SerializeField] private float _moveSpeed = 2f;

    private Transform _cameraPivot;

    private Tween _autoRotateTween;

    private float _targetRotationY;
    private float _currentRotationY;

    private void Start()
    {
        _cameraPivot = new GameObject("CameraPivot").transform;
        _cameraPivot.position = _home.position;
        transform.SetParent(_cameraPivot);
        transform.position = new Vector3(0, 4f, -7f);
        transform.LookAt(_home.position);
        _currentRotationY = _cameraPivot.eulerAngles.y;
        _targetRotationY = _currentRotationY;
        SetupAutoRotation();
    }

    void Update()
    {
        if (_cameraModeChanger.isOn)
            return;

        if (Input.GetKey(KeyCode.A))
            _targetRotationY += _rotationSpeed * Time.deltaTime;

        else if (Input.GetKey(KeyCode.D))
            _targetRotationY -= _rotationSpeed * Time.deltaTime;

        _currentRotationY = Mathf.Lerp(_currentRotationY, _targetRotationY, _moveSpeed * Time.deltaTime);
        _cameraPivot.rotation = Quaternion.Euler(0, _currentRotationY, 0);

    }

    private void SetupAutoRotation()
    {
        _autoRotateTween = _cameraPivot.DORotate(new Vector3(0, 360, 0), 30f, RotateMode.LocalAxisAdd)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart)
            .Pause();
    }

    public void OnCameraModeChanged(bool isAutoMode)
    {
        if (isAutoMode)
            _autoRotateTween.Restart();
        else
            _autoRotateTween.Pause();
    }

    private void OnDestroy()
    {
        _autoRotateTween?.Kill();
    }
}