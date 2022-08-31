using UnityEngine;

namespace Assets.Scripts.PlayerScripts
{
    [RequireComponent(typeof(Rigidbody), typeof(Animator), typeof(AudioSource))]
    public class PlayerMovement : MonoBehaviour
    {
        [field: SerializeField] public float PlayerSpeed { get; private set; } = default;
        [SerializeField] private FloatingJoystick _joystick;
        [SerializeField] private Transform _playerTransform;
        private Rigidbody _playerRb;
        private Animator _playerAnim;
        private Vector3 _playerMoveVelocity;
        private Vector3 _playerInput;

        private void Awake()
        {
            _playerRb = GetComponent<Rigidbody>();
            _playerAnim = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            _playerInput = new Vector3(_joystick.Horizontal, 0f, _joystick.Vertical);
            _playerMoveVelocity = _playerInput * PlayerSpeed;
            _playerRb.MovePosition(_playerRb.position + _playerMoveVelocity * Time.deltaTime);
            if (_playerInput != Vector3.zero)
            {
                _playerAnim.SetBool("IsRunning", true);
                _playerRb.MoveRotation(Quaternion.LookRotation(_playerInput, Vector3.up));
                return;
            }
            _playerAnim.SetBool("IsRunning", false);
        }
    }
}