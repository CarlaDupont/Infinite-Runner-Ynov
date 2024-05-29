using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 2f; // Force du saut
    public float groundCheckRadius = 0.2f; // Rayon pour v�rifier si le joueur touche le sol
    public LayerMask groundLayer; // Layer pour d�terminer ce qui est consid�r� comme le sol

    private Rigidbody2D rb;
    private bool isGrounded; // Indique si le joueur est au sol

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // V�rifie si le joueur touche le sol
        isGrounded = Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayer);

        // Si le joueur est au sol et appuie sur la touche de saut
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        // Applique une force vers le haut pour simuler le saut
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}

