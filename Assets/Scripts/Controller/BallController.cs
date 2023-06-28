using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BallModel))]
public class BallController : MonoBehaviour
{
    BallModel ballModel;

     
    void Start()
    {
        ballModel= GetComponent<BallModel>();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(ballModel.Speed, 0));

        Vector3 scale=  gameObject.transform.localScale*ballModel.Size;
        gameObject.transform.localScale = scale;
       
    }



    public void DestroyBall()
    {
        if (ballModel.Level > 1)
        {
            Vector3 position = transform.position;
            position.y += -1;
            float size = ballModel.Size - 1;
            if (size < 1) size = 1;
            GameController.instance.CreateBall(position, ballModel.Level - 1, ballModel.Height / 2, ballModel.Speed, size);
            position.y += 2;
            GameController.instance.CreateBall(position, ballModel.Level - 1, ballModel.Height / 2, -ballModel.Speed, size);
        }
        else
            GameController.instance.RemovedBall();
        Destroy(gameObject);

    }
}
