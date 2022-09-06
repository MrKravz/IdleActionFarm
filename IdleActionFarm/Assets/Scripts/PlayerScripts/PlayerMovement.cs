using UnityEngine;

namespace Assets.Scripts.PlayerScripts
{
    [RequireComponent(typeof(Rigidbody), typeof(Animator))]
    public class PlayerMovement : MonoBehaviour
    {
        [field: SerializeField] public float MoveSpeed { get; private set; } = default;
        [field: SerializeField] public float RotationSpeed { get; private set; } = default;
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

        private void Update()
        {
            _playerInput = new Vector3(_joystick.Horizontal, 0f, _joystick.Vertical);
            _playerMoveVelocity = _playerInput * MoveSpeed;
            _playerRb.MovePosition(transform.position + transform.forward * _playerMoveVelocity.magnitude * Time.deltaTime);
            if (_playerInput != Vector3.zero)
            {
                float angle = Vector3.SignedAngle(Vector3.forward, _playerMoveVelocity, Vector3.up) * Time.deltaTime * RotationSpeed;
                _playerAnim.SetBool("IsRunning", true);
                transform.forward = Quaternion.Euler(0, angle, 0) * transform.forward;
                return;
            }
            _playerAnim.SetBool("IsRunning", false);
        }
    }
}