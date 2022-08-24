using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{

  public float speed = 15;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  private void FixedUpdate()
  {
    transform.Translate(Vector3.forward * speed * Time.deltaTime);
  }

}
