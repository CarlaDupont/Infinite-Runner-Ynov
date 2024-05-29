using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 10f;
    private int currentPositionIndex = 1; // Position initiale
    public Transform[] targetPositions;
    [SerializeField]
    bool canJump = false;
    Rigidbody rb;
    [SerializeField]
    float jumpForce = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        //permet d'avancer tout droit (vector3.forward = new Vector3(0,0,1))
        //time*DeltaTime permet d'avancer par rapport au framerate du jeu
        //movementSpeed permet de gerer la vitesse du joueur
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);

        //regarde si on est aux positions extremes. point positif : si on rajoute + de 3 voies, reste adaptatif.
        if (transform.position.x < targetPositions[0].position.x)
            transform.position = new Vector3(targetPositions[0].position.x, transform.position.y, transform.position.z);
        else if (transform.position.x > targetPositions[targetPositions.Length -1].position.x)
            transform.position = new Vector3(targetPositions[targetPositions.Length - 1].position.x, transform.position.y, transform.position.z);

        //appelle MoveToposition.
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            MoveToPosition(-1);
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            MoveToPosition(1);
        else if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0) //rb.velocity.y sera à 0 quand le personnage sera au sol.
            canJump = true;
    }

    //Tout ce qui est physique on l ajoute dans un fixedUpdate au lieu d un update
    private void FixedUpdate()
    {
        if (canJump)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            canJump = false;
        }
    }
    void MoveToPosition(int direction)
    {
        currentPositionIndex += direction;
        //permet de pas sortir du tabeau
        currentPositionIndex = Mathf.Clamp(currentPositionIndex, 0, targetPositions.Length - 1);
        transform.position = new Vector3(targetPositions[currentPositionIndex].position.x, transform.position.y, transform.position.z);
    }
}
