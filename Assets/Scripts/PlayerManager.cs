using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    int xLim, yLim;

    Vector2 xMove = new Vector2(1, 0);
    Vector2 yMove = new Vector2(0, 1);

    // Start is called before the first frame update
    void Start()
    {
        BoardManager boardManager = GetComponent<BoardManager>();
        xLim = 8;
        yLim = 8;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (transform.position.x < xLim - 1)
                transform.Translate(xMove);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(transform.position.y < yLim - 1)
                transform.Translate(yMove);
        }
    }
}
