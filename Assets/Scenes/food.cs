using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class food : MonoBehaviour
{
    public Collider2D foodArea;
    // Start is called before the first frame update
    void Start()
    {
        RandomPosition();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision);
        //Debug.Log(foodArea.bounds.min.x);
        //Debug.Log(foodArea.bounds.max.x);
        //Debug.Log(foodArea.bounds.min.y);
        //Debug.Log(foodArea.bounds.max.y);

        RandomPosition();
    }
    void RandomPosition()
    {
        transform.position = new Vector3(
            Random.Range(foodArea.bounds.min.x, foodArea.bounds.max.x),
            Random.Range(foodArea.bounds.min.y, foodArea.bounds.max.y)
            , 0);
    }

}