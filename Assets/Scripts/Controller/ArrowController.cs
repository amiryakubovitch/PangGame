using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// controlls a single arrow of a local player
/// </summary>
public class ArrowController : MonoBehaviour
{
    public float speed;
    public GameObject arrowChain;
    public Action OnArrowDestroy;

    Vector3 startingPosition;
    
    //calculates the offset of the arrow scale for the chain length calculations
    float scaleOffset = 0;

    public void Start()
    {
        startingPosition= transform.position;
        scaleOffset=1/transform.localScale.y;
    }

    void FixedUpdate()
    {
        //move the arrow head
        transform.Translate(new Vector3(0, speed * Time.deltaTime));

        //calculate the chain position and size
        Vector3 scale = arrowChain.transform.localScale;
        float distance = Mathf.Abs(startingPosition.y-transform.position.y);
        scale.y = distance * scaleOffset;
        arrowChain.transform.localScale=scale;

        arrowChain.transform.Translate(new Vector3(0, -(speed * Time.deltaTime)/2,0));
    }

    /// <summary>
    /// called when the arrow hits a trigger collider
    /// </summary>
    /// <param name="col">collider hit</param>
    void OnTriggerEnter2D(Collider2D col)
    {
        //if hit roof destroy
        if (col.gameObject.tag == "Roof")
        {
            OnArrowDestroy.Invoke();
            Destroy(gameObject);
        }
        //if hit ball destroy
        if (col.gameObject.tag == "Ball") {
            OnArrowDestroy.Invoke();
            BallController controller = col.gameObject.GetComponent<BallController>();
            controller.DestroyBall();
            Destroy(gameObject);
        }
    }

}

