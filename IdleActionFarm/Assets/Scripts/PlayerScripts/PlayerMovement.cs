using UnityEngine;

namespace Assets.Scripts.PlayerScripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _playerSpeed;
       // [SerializeField] private FloatingJoystick _joystick;
        private Rigidbody _playerRb;
        private Vector3 _playerMoveVelocity;
        private Vector3 _playerMoveInput;

        private void Awake()
        {
            _playerRb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            _playerMoveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")); //new Vector3(_joystick.Horizontal, 0f, _joystick.Vertical);
            _playerMoveVelocity = _playerMoveInput * _playerSpeed;
            _playerRb.MovePosition(_playerRb.position + _playerMoveVelocity * Time.deltaTime);
        }
    }
}