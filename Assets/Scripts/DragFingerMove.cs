using UnityEngine;

public class DragFingerMove : MonoBehaviour
{
  private Vector3 touchPosition;
  private Rigidbody2D rb;
  private Vector3 direction;
  private float moveSpeed = 1f;

  private void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.touchCount > 0)
    {
      Touch touch = Input.GetTouch(0);
      Vector3 direction = touch.position - rb.position;
      rb.transform.Translate(direction * Time.deltaTime * moveSpeed);
    }
  }
}
