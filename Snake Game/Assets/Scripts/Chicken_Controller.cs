using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _minX, _maxX, _minY, _maxY;
    [SerializeField] private GameObject _snake;
    void Start()
    {
        RandomChickenPosition();
    }

    private void RandomChickenPosition(){
        transform.position = new Vector2(
            Mathf.Round(Random.Range(_minX, _maxX))+0.5f,
            Mathf.Round(Random.Range(_minY, _maxY))+0.5f
        );
    }

    private void OnTriggerEnter2D(Collider2D other){
        //console it other
        
        if(other.gameObject.CompareTag("Snake")){
            Debug.Log("Snake ate the chicken");
            RandomChickenPosition();
            _snake.GetComponent<Snake_Controller>().CreateSegment();
        }
    }
}
