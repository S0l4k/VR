using UnityEngine;
using UnityEngine.InputSystem;

public class SimulatedMovementController : MonoBehaviour
{
    public Transform cameraTransform; // G³owa gracza (kamera XR)
    public CharacterController characterController; // Nasz kontroler kolizji
    public float speed = 2f;

    private Vector2 moveInput;

    void Update()
    {
        // Obs³uga wejœcia z klawiatury symulowanej przez XR Device Simulator
        var keyboard = Keyboard.current;
        moveInput = Vector2.zero;
        if (keyboard.wKey.isPressed) moveInput.y += 1;
        if (keyboard.sKey.isPressed) moveInput.y -= 1;
        if (keyboard.aKey.isPressed) moveInput.x -= 1;
        if (keyboard.dKey.isPressed) moveInput.x += 1;
    }

    void FixedUpdate()
    {
        // Obliczanie ruchu wzglêdem kierunku, w który patrzy kamera
        Vector3 move = (cameraTransform.right * moveInput.x + cameraTransform.forward * moveInput.y);
        move.y = 0; // Nie ruszamy siê góra/dó³
        characterController.Move(move.normalized * speed * Time.fixedDeltaTime);
    }
    void LateUpdate()
    {
        if (cameraTransform == null) return;

        // Zapisz aktualn¹ rotacjê kamery
        Quaternion currentRotation = cameraTransform.rotation;

        // Oblicz now¹ pozycjê kamery - na œrodku CharacterControllera
        Vector3 fixedPosition = transform.position + Vector3.up * characterController.height / 2f;

        // Ustaw now¹ pozycjê, ale zostaw star¹ rotacjê
        cameraTransform.SetPositionAndRotation(fixedPosition, currentRotation);
    }


}
