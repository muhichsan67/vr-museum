using UnityEngine;
using UnityEngine.InputSystem; // Wajib memanggil namespace baru

public class SimpleFPSController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 0.1f; // Nilai delta pada New Input System lebih sensitif
    
    private CharacterController _controller;
    private Camera _camera;
    private float _xRotation = 0f;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _camera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked; 
    }

    void Update()
    {
        // 1. Kontrol Rotasi Kamera (Mouse Delta)
        if (Mouse.current != null)
        {
            Vector2 mouseDelta = Mouse.current.delta.ReadValue();
            float mouseX = mouseDelta.x * mouseSensitivity;
            float mouseY = mouseDelta.y * mouseSensitivity;

            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

            _camera.transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }

        // 2. Kontrol Pergerakan Jalan (Keyboard Polling)
        if (Keyboard.current != null)
        {
            float moveX = 0f;
            float moveZ = 0f;

            // Deteksi penekanan tombol WASD secara langsung
            if (Keyboard.current.wKey.isPressed) moveZ += 1f;
            if (Keyboard.current.sKey.isPressed) moveZ -= 1f;
            if (Keyboard.current.dKey.isPressed) moveX += 1f;
            if (Keyboard.current.aKey.isPressed) moveX -= 1f;

            Vector3 move = transform.right * moveX + transform.forward * moveZ;
            
            // Gunakan .normalized agar kecepatan diagonal tidak lebih cepat
            _controller.Move(move.normalized * moveSpeed * Time.deltaTime);
        }
    }
}