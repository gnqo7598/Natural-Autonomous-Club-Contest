using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public BoardManager boardManager;

    int xLim, yLim;
    int point = 100;

    Vector2 xMove = new Vector2(1, 0);
    Vector2 yMove = new Vector2(0, 1);

    Vector2 lastMove;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            point += 1;
            Debug.Log(point);
        }

        else if (collision.gameObject.tag == "Trap")
        {
            Destroy(collision.gameObject);
            point -= 1;
            Debug.Log(point);
        }

        else if (collision.gameObject.tag == "Wall")
        {
            transform.Translate(-lastMove);
            point += 1;
            Debug.Log(point);
        }
    }

    void MoveMyself()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (transform.position.x < xLim - 1)
            {
                lastMove = xMove;
                transform.Translate(xMove);
                point -= 1;
                Debug.Log(point);
            }
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (transform.position.y < yLim - 1)
            {
                lastMove = yMove;
                transform.Translate(yMove);
                point -= 1;
                Debug.Log(point);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        xLim = boardManager.length;
        yLim = boardManager.height;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
