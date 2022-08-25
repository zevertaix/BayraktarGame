using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExplosionPlaceController : MonoBehaviour
{
  public bool shoot = false;
  public GameObject spawnItem;
  public GameObject sight;

  public TextMeshProUGUI shootBtn;

  public float radius = 5.0f;
  public float power = 10.0f;

  private float timeout = 0.0f;
  // Start is called before the first frame update
  void Start()
  {
  }
  void Update()
  {
    if (timeout > 0)
    {
      timeout = Time.deltaTime > timeout ? 0 : timeout - Time.deltaTime;
      shootBtn.text = DisplayTime(timeout);
    }
    if (shoot)
    {
      Explosion();
      shoot = false;
    }
    transform.position = GetWorldPositionOnPlane(sight.transform.position, 0);
  }

  public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z)
  {
    Ray ray = Camera.main.ScreenPointToRay(screenPosition);
    Plane xy = new Plane(Vector3.up, new Vector3(0, -4, 0));
    float distance;
    xy.Raycast(ray, out distance);
    return ray.GetPoint(distance);
  }

  private string DisplayTime(float timeToDisplay)
  {
    float seconds = Mathf.FloorToInt(timeToDisplay % 60);
    float milliSeconds = (timeToDisplay % 1) * 99;
    return string.Format("{0:00}.{1:00}", seconds, Mathf.Round(milliSeconds));
  }

  public void ShootOn()
  {
    if (timeout == 0)
    {
      shoot = true;
      timeout = 5;
    }
  }

  private void Explosion()
  {
    Vector3 explosionPos = transform.position;
    Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
    foreach (Collider hit in colliders)
    {
      GameObject newSpawnedObject = Instantiate(spawnItem, explosionPos, Quaternion.Euler(-90, 0, 90));
      Destroy(newSpawnedObject, 3.0f);
      Rigidbody rb = hit.GetComponent<Rigidbody>();
      if (rb != null && rb.CompareTag("Enemy"))
      {
        MoveScript move = hit.GetComponent<MoveScript>();
        move.speed = 0;
        rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
        Destroy(hit.gameObject, 3.0f);
      }

    }
  }
}



