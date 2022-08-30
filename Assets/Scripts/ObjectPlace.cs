using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlace : MonoBehaviour
{
    Vector2 MousePosition;
    Vector2 ObjectPosition;
    Vector3 StartPosition = new Vector3(0, 0, 0);
    Vector3 DestinationPosition = new Vector3(7, 7, 0);
    Camera Camera;

    public GameObject Coin;
    public GameObject Trap;
    public GameObject Wall;
    GameObject toInstantiate;

    void ObjToPlace()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            toInstantiate = Coin;
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            toInstantiate = Trap;
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            toInstantiate = Wall;
    }

    void ObjPlace()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MousePosition = Input.mousePosition;
            MousePosition = Camera.ScreenToWorldPoint(MousePosition);

            RaycastHit2D hit = Physics2D.Raycast(MousePosition, transform.forward);
            if (hit.collider != null && hit.transform.position != StartPosition && hit.transform.position != DestinationPosition)
            {
                if (hit.collider.tag != "Tile")
                    Destroy(hit.transform.gameObject);
                ObjectPosition = hit.transform.position;
                Instantiate(toInstantiate, ObjectPosition, Quaternion.identity);
            }
        }
    }

    void ObjDestroy()
    {
        if (Input.GetMouseButtonDown(1))
        {
            MousePosition = Input.mousePosition;
            MousePosition = Camera.ScreenToWorldPoint(MousePosition);

            RaycastHit2D hit = Physics2D.Raycast(MousePosition, transform.forward);
            if (hit.collider != null && hit.transform.position != StartPosition && hit.transform.position != DestinationPosition)
            {
                if (hit.collider.tag != "Tile")
                    Destroy(hit.transform.gameObject);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        ObjToPlace();
        ObjPlace();
        ObjDestroy();
    }
}
