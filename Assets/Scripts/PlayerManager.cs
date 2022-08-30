using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public BoardManager boardManager;
    public LayerMask LayerMask;

    int xLim, yLim;
    int point = 100;
    int xPoint, yPoint;

    bool xUnable, yUnable = false;
    bool isArrived = false;

    float MaxDistance = 1f;

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

        else if (collision.gameObject.tag == "Destination")
        {
            isArrived = true;
            Debug.Log("도착!\n최종점수 : " + point);
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

    void MoveAlgorithm1()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isArrived == false)
            {
                xPoint = yPoint = 0;
                xUnable = yUnable = false;

                RaycastHit2D hitX = Physics2D.Raycast(transform.position, transform.right, MaxDistance, LayerMask);
                if (hitX.collider != null)
                {
                    if (hitX.collider.tag == "Coin")
                        xPoint = 1;
                    else if (hitX.collider.tag == "Trap")
                        xPoint = -1;
                    else if (hitX.collider.tag == "Wall")
                        xUnable = true;
                }
                else
                {
                    if (transform.position.x == 7)
                        xUnable = true;
                }

                RaycastHit2D hitY = Physics2D.Raycast(transform.position, transform.up, MaxDistance, LayerMask);
                if (hitY.collider != null)
                {
                    if (hitY.collider.tag == "Coin")
                        yPoint = 1;
                    else if (hitY.collider.tag == "Trap")
                        yPoint = -1;
                    else if (hitY.collider.tag == "Wall")
                        yUnable = true;
                }
                else
                {
                    if (transform.position.y == 7)
                        yUnable = true;
                }

                if (xUnable == true && yUnable == true)
                    Debug.Log("이 맵은 깰 수 없습니다.");
                else if (xUnable == true)
                {
                    transform.Translate(yMove);
                    point -= 1;
                    Debug.Log(point);
                }
                else if (yUnable == true)
                {
                    transform.Translate(xMove);
                    point -= 1;
                    Debug.Log(point);
                }
                else if (xPoint >= yPoint)
                {
                    transform.Translate(xMove);
                    point -= 1;
                    Debug.Log(point);
                }
                else if (yPoint > xPoint)
                {
                    transform.Translate(yMove);
                    point -= 1;
                    Debug.Log(point);
                }
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
        MoveAlgorithm1();
    }
}
