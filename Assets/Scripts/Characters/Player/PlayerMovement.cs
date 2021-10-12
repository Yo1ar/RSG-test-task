using UnityEngine;
using UnityEngine.InputSystem;

namespace Characters.Player
{
    [RequireComponent(typeof(CharacterController))]
    
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]private CharacterController _characterController;
        private Vector2 _moveDirection;

        // [SerializeField] private float _gravityMultiplier = 1f;
        // private const float Gravity = -9.81f;
        // private Vector3 _velocity;

        private void Start()
        {
            if (!TryGetComponent(out _characterController))
                Debug.LogError("Cant get CharacterController in PlayerMovement script");
        }

        public void OnMovePlayerInput(InputAction.CallbackContext context)
        {
            _moveDirection = context.ReadValue<Vector2>();
        }

        public void MovePlayer(float moveSpeed)
        {
            Vector3 move = transform.right * _moveDirection.x + transform.forward * _moveDirection.y;
            _characterController.Move(move * (moveSpeed * Time.deltaTime));

            // _velocity.y += Gravity * _gravityMultiplier * Time.deltaTime;
            // _characterController.Move(_velocity * Time.deltaTime);
        }
    
    }
}
