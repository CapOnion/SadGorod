using UnityEngine;

public class DragAndDropFeature : MonoBehaviour
{
    [SerializeField]
    private ObjectsData objectData;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered by " + collision + " + " + gameObject);
        RecipeManager recipeManager = FindFirstObjectByType<RecipeManager>();
        GameObject objectToSpawn = recipeManager.GetResult(objectData, collision.GetComponent<DragAndDropFeature>().objectData);
        if (objectToSpawn != null)
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Instantiate(objectToSpawn, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        }    
    }
}
