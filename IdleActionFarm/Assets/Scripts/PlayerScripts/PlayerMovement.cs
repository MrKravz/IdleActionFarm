using UnityEngine;

namespace Assets.Scripts.PlayerScripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _playerSpeed;
        private Rigidbody _playerRb;
        private Vector3 _playerMoveVelocity;
        private Vector3 _playerMoveInput;

        private void Awake()
        {
            _playerRb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            _playerMoveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            _playerMoveVelocity = _playerMoveInput * _playerSpeed;
            _playerRb.MovePosition(_playerRb.position + _playerMoveVelocity * Time.deltaTime);
        }
    }
}