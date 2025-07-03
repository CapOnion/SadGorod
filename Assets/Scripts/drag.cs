using UnityEngine;

public class drag : MonoBehaviour
{
    private Vector2 mousePosition;

    private float offsetX, offsetY;

    public static bool mouseButtonReleased;

    Transform parentAfterDrag;

    private void OnMouseDown()
    {
        mouseButtonReleased = false;
        offsetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        offsetY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    }

    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x - offsetX, mousePosition.y - offsetY);
    }

    private void OnMouseUp()
    {
        mouseButtonReleased = true;
        transform.SetParent(parentAfterDrag);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        string thisGameobjectName;
        string collisionGameobjectName;

        //thisGameobjectName = gameObject.name.Substring(0, name.IndexOf("_"));
        thisGameobjectName = gameObject.name;
        //collisionGameobjectName = collision.gameObject.name.Substring(0, name.IndexOf("_"));
        collisionGameobjectName = collision.gameObject.name;
        print(collisionGameobjectName);
        print(thisGameobjectName);
        if (mouseButtonReleased && thisGameobjectName == "Dirt_object(Clone)" &&  collisionGameobjectName == "Hoe_object(Clone)")
        {
            Instantiate(Resources.Load("Field_0_object"), transform.position, Quaternion.identity);
            mouseButtonReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (mouseButtonReleased && thisGameobjectName == "Field_0_object(Clone)" && collisionGameobjectName == "Seeds_Blue_0_object(Clone)")
        {
            Instantiate(Resources.Load("Grass_object"), transform.position, Quaternion.identity);
            mouseButtonReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
 
}
