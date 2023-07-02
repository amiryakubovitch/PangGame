using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BallController controls the phyisics and movement of the ball
/// </summary>
[RequireComponent(typeof(BallModel),typeof(Rigidbody2D))]
public class BallController : MonoBehaviour
{

    BallModel ballModel;
    Rigidbody2D rigidBody;

    void Start()
    {
        //set movement for the ball and the parameters of the ball
        ballModel= GetComponent<BallModel>();
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity=new Vector2(ballModel.SpeedX, 0);
        rigidBody.gravityScale = ballModel.GravityScale;

        Vector3 scale=  gameObject.transform.localScale*ballModel.Size;
        gameObject.transform.localScale = scale;
       
    }


    /// <summary>
    /// destroys the current ball and creates two more if its not the last level of the ball
    /// </summary>
    public void DestroyBall()
    {
        //check if the ball should create childrens
        if (ballModel.Level > 1)
        {
            //create two more balls
            Vector3 position = transform.position;
            float size = ballModel.Size - 1;
            //lower the size of the ball
            size=Mathf.Max(size, 0.5f);
            
            //create two new balls with different speeds ( to each side)
            GameController.instance.CreateBall(position, ballModel.Level - 1, ballModel.SpeedY, ballModel.SpeedX, size, ballModel.GravityScale+0.1f);
            GameController.instance.CreateBall(position, ballModel.Level - 1, ballModel.SpeedY, -ballModel.SpeedX, size, ballModel.GravityScale + 0.1f);
        }

        
        Destroy(gameObject);
        GameController.instance.RemovedBall();

    }


    /// <summary>
    /// called upon the ball touching collidirs let the ball react and simulate bounce from the bounderies of the world
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Floor":
                //floor resets the velocity of the ball
                rigidBody.velocity = Vector2.zero;
                float velocityY = ballModel.SpeedY;
                rigidBody.velocity= new Vector2(ballModel.SpeedX, velocityY);
                break;
            case "Wall":
                //wall changes the x velocity of the ball
                ballModel.SpeedX = ballModel.SpeedX* - 1;
                Vector2 velocity= rigidBody.velocity;
                velocity.x =ballModel.SpeedX;
                rigidBody.velocity = velocity;
                
                break;
            case "Roof":
                //roof resets the y velocity of the ball
                velocity = rigidBody.velocity;
                velocity.y = 0;
                rigidBody.velocity = velocity;

                break;
        }
        
    }
}
