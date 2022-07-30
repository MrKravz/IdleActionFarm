using UnityEngine;

namespace Assets.Scripts.PlayerScripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        private Rigidbody rb;
        private Vector3 moveVelocity;
        private Vector3 moveInput;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            moveVelocity = moveInput * speed;
            rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
        }
    }
}