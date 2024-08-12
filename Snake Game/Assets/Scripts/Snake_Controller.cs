using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake_Controller : MonoBehaviour
{
    private Vector2 _direction;
    [SerializeField] private GameObject _segmentPrefab;
    private List<GameObject> _segments = new List<GameObject>();
    void Start()
    {
        Reset();
        ResetSegments();
    }

    // Update is called once per frame
    void Update()
    {
       GetUserInput();
    }

    private void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Reset(){
        _direction = Vector2.right;
        Time.timeScale = 0.1f;
    }

    private void ResetSegments(){
        for(int i = 1; i < _segments.Count; i++){
            Destroy(_segments[i]);
        }
        _segments.Clear();
        _segments.Add(gameObject);

        for(int i = 1; i < 3; i++){
            CreateSegment();
        }
    }


    private void MoveSegments(){
        for(int i = _segments.Count-1; i > 0; i--){
            _segments[i].transform.position = _segments[i-1].transform.position;
        }
    }
    private void FixedUpdate(){
        Move();
        MoveSegments();
    }

    public void CreateSegment(){
        GameObject segment = Instantiate(_segmentPrefab, _segments[_segments.Count-1].transform.position, Quaternion.identity);
        _segments.Add(segment);
    }

    private void Move(){
        float x,y;
        x = Mathf.Round(transform.position.x) + _direction.x;
        y = Mathf.Round(transform.position.y) + _direction.y;
        transform.position = new Vector2(x,y);
    }

    public Vector2 GetUserInput(){
        if(Input.GetKey(KeyCode.W)){
            _direction = Vector2.up;
        }
        else if(Input.GetKey(KeyCode.S)){
            _direction = Vector2.down;
        }
        else if(Input.GetKey(KeyCode.A)){
            _direction = Vector2.left;
        }
        else if(Input.GetKey(KeyCode.D)){
            _direction = Vector2.right;
        }
        return _direction;
    }

    private void OnTriggerEnter2D(Collider2D other){
         if(other.gameObject.CompareTag("Wall")){
            Debug.Log("Snake hit the wall");
            RestartGame();
        }
    }
}
