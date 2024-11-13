using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;

    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    // Verwijzing naar de Camera (instellen in de Inspector of met een script)
    public Transform cameraTransform;

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();

        // Koppel de cameraTransform als deze niet ingesteld is
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Input-waarden krijgen (zonder Y-waarde)
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // Beweging aanpassen naar de richting van de camera
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0f;  // Zorgt ervoor dat je niet omhoog/omlaag beweegt volgens de camera

        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;  // Draait speler naar de bewegingsrichting
        }

        // Springen
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
