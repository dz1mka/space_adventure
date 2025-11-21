 using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private bool moveOnX, moveOnY;

    private float min_X, max_X;
    private float min_Y, max_Y;

    [SerializeField]
    private float moveSpeed = 8f;

    [SerializeField]
    private float horizontal_MovementThreshold = 8f;

    [SerializeField]
    private float vertical_MovementThreshold = 8f;

    private Vector3 tempMovementHorizontal;
    private Vector3 tempMovementVertical;

    private bool moveLeft;
    private bool moveUp = false;

    private void Start()
    {
        min_X = transform.position.x - horizontal_MovementThreshold;
        max_X = transform.position.x + horizontal_MovementThreshold;

        max_Y = transform.position.y;
        min_Y = transform.position.y - vertical_MovementThreshold;

        if(Random.Range(0, 2) > 0)
            moveLeft = true;

    }

    private void Update()
    {
        HandleEnemyMovement_Horizontal();
        HandleEnemyMovement_Vertical();
    }

    void HandleEnemyMovement_Horizontal()
    {
        if (!moveOnX)
            return;

        if (moveLeft)
        {
            tempMovementHorizontal = transform.position;
            tempMovementHorizontal.x -= moveSpeed * Time.deltaTime;
            transform.position = tempMovementHorizontal;

            if (tempMovementHorizontal.x < min_X)
                moveLeft = false;
        }
        else
        {
            tempMovementHorizontal = transform.position;
            tempMovementHorizontal.x += moveSpeed * Time.deltaTime;
            transform.position = tempMovementHorizontal;

            if (tempMovementHorizontal.x > max_X)
                moveLeft = true;
        }
    }

    void HandleEnemyMovement_Vertical()
    {
        if (!moveOnY)
            return;
        if (moveUp)
        {
            tempMovementVertical = transform.position;
            tempMovementVertical.y += moveSpeed * Time.deltaTime;
            transform.position = tempMovementVertical;
            if (tempMovementVertical.y > max_Y)
                moveUp = false;
        }
        else
        {
            tempMovementVertical = transform.position;
            tempMovementVertical.y -= moveSpeed * Time.deltaTime;
            transform.position = tempMovementVertical;
            if (tempMovementVertical.y < min_Y)
                moveUp = true;
        } 
    }

  
}
