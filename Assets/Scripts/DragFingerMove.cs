using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragFingerMove : MonoBehaviour
{
  UnityEngine.EventSystems.EventSystem ct
        = UnityEngine.EventSystems.EventSystem.current;
  private Vector3 touchPosition;
  [HideInInspector]
  public Rigidbody2D sightRb;
  private Vector3 direction;
  private float moveSpeed = 1f;

  private void Start()
  {
    sightRb = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {
    if (
      Input.touchCount > 0 &&
      !WasAButton(Input.GetTouch(0).fingerId) &&
      !(Input.GetTouch(0).phase == TouchPhase.Ended)

      )
    {
      Touch touch = Input.GetTouch(0);
      Vector3 direction = touch.position - sightRb.position;
      sightRb.transform.Translate(direction * Time.deltaTime * moveSpeed);
    }
  }

  private bool WasAButton(int id)
  {
    UnityEngine.EventSystems.EventSystem ct
        = UnityEngine.EventSystems.EventSystem.current;

    if (!ct.IsPointerOverGameObject(id)) return false;
    if (!ct.currentSelectedGameObject) return false;
    if (ct.currentSelectedGameObject.GetComponent<Button>() == null)
      return false;

    return true;
  }
}
