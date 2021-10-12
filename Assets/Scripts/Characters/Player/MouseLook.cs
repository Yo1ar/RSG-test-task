using UnityEngine;
using UnityEngine.Accessibility;
using UnityEngine.InputSystem;

namespace Characters.Player
{
    public class MouseLook : MonoBehaviour
    {
        [Range(0f, 100f)] [SerializeField] private float _mouseSensitivity = 100f;
        [SerializeField] private float _clampY = 90f;
        [SerializeField] private Transform _bodyToRotate;
        
        private Vector2 _mouseDelta;
        private float _xRotation;
        private float _yRotation;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            _yRotation = _mouseDelta.x * _mouseSensitivity * Time.deltaTime;
            _xRotation -= _mouseDelta.y * _mouseSensitivity * Time.deltaTime;
            _xRotation = Mathf.Clamp(_xRotation, -_clampY, _clampY);

            transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
            _bodyToRotate.Rotate(Vector3.up * _yRotation);
        }
        
        public void OnRotatePlayerInput(InputAction.CallbackContext context)
        {
            _mouseDelta = context.ReadValue<Vector2>();
        }
    }
}