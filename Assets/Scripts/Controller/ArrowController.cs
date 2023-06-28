using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float speed;
    public GameObject arrowChain;

    Vector3 startingPosition;
    float scaleOffset = 0;
    public void Start()
    {
        startingPosition= transform.position;
        scaleOffset=1/transform.localScale.y;
    }

    void FixedUpdate()
    {
        transform.Translate(new Vector3(0, speed * Time.deltaTime));
        Vector3 scale = arrowChain.transform.localScale;
        float distance = Mathf.Abs(startingPosition.y-transform.position.y);
        scale.y = distance * scaleOffset;
        arrowChain.transform.localScale=scale;

        arrowChain.transform.Translate(new Vector3(0, -(speed * Time.deltaTime)/2,0));
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Roof")
        {
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Ball") {
            BallController controller = col.gameObject.GetComponent<BallController>();
            controller.DestroyBall();
            Destroy(gameObject);
        }
    }

}

