using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPlaceController : MonoBehaviour
{
  public bool shoot = false;
  public GameObject sight;

  public float radius = 5.0f;
  public float power = 10.0f;
  // Start is called before the first frame update
  void Start()
  {
  }
  void Update()
  {
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

  public void ShootOn()
  {
    shoot = true;
  }

  private void Explosion()
  {
    Vector3 explosionPos = transform.position;
    Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
    foreach (Collider hit in colliders)
    {
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



