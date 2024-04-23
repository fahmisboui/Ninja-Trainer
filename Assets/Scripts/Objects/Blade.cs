using UnityEngine;

public class Blade : MonoBehaviour
{
    [SerializeField] RectTransform canvas;
    [SerializeField] GameObject SlashingPrefab;

    private GameObject instantiatedSlash;
    void Update()
    {
        if (FindObjectOfType<GameManager>().isGameOver == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                instantiatedSlash = Instantiate(SlashingPrefab, canvas);

                instantiatedSlash.GetComponent<TrailRenderer>().enabled = true;
                instantiatedSlash.GetComponent<CircleCollider2D>().enabled = true;

            }

            if (Input.GetMouseButtonUp(0))
            {
                if (instantiatedSlash != null) // Check if instantiated before destroying
                {
                    Destroy(instantiatedSlash);
                    instantiatedSlash = null; // Clear reference
                }
            }

            // Follow mouse if object instantiated
            if (instantiatedSlash != null)
            {
                BladeFollowMouse(instantiatedSlash);
            }
        }
    }

    void BladeFollowMouse(GameObject slashObject)
    {
        Vector2 mousePos = Input.mousePosition;

        mousePos.x = Mathf.Clamp(mousePos.x, 0f, Screen.width);
        mousePos.y = Mathf.Clamp(mousePos.y, 0f, Screen.height);

        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        slashObject.transform.position = worldPos;
    }
}
