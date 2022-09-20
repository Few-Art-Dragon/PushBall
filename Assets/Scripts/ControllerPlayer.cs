using UnityEngine;
using UnityEngine.Events;

public class ControllerPlayer : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    private bool _isGameOver;

    private LineRenderer _lineRenderer;
    public Vector3 _positionDotLineRenderer;

    public Rigidbody2D _rigidbody;

    public static UnityEvent RestartGameEvent = new UnityEvent();
    public static UnityEvent SetGameOverEvent = new UnityEvent();

    private void Start()
    {
        SetStandartParam();
    }

    private void Update()
    {
        CheckTouch();
    }

    private void OnMouseDown()
    {
        if (!_isGameOver)
        {
            SwitchLine();
            _positionDotLineRenderer = _lineRenderer.GetPosition(1);
            _rigidbody.AddForce(new Vector2(_positionDotLineRenderer.x, _positionDotLineRenderer.y), ForceMode2D.Impulse);
        }
    }
    private void OnBecameInvisible()
    {
        Enemy.NextTurnEvent.Invoke();
        ReturnPositionPlayer();
    }

    private void SetStandartParam()
    {
        SetGameOverEvent.AddListener(SetGameOver);
        RestartGameEvent.AddListener(ReturnPositionPlayer);
        _isGameOver = false;
        _lineRenderer = GetComponentInChildren<LineRenderer>();
        _positionDotLineRenderer = _lineRenderer.GetPosition(1);
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void CheckTouch()
    {
        if (Input.GetMouseButton(0) && !_isGameOver)
        {
            if (_mainCamera.ScreenToWorldPoint(Input.mousePosition).x > -1.3f && _mainCamera.ScreenToWorldPoint(Input.mousePosition).x < 1.3f)
            {
                _lineRenderer.SetPosition(1, new Vector3(_mainCamera.ScreenToWorldPoint(Input.mousePosition).x + 0.1f * Time.deltaTime, _lineRenderer.GetPosition(1).y, 0));
            }
        }
    }

    private void ReturnPositionPlayer()
    {
        _rigidbody.velocity = Vector3.zero;
        transform.position = Vector3.zero;
        SwitchLine();
    }

    private void SwitchLine()
    {
        transform.GetChild(0).gameObject.SetActive(transform.GetChild(0).gameObject.activeSelf == true ? (false) : (true));
    }

    private void SetGameOver()
    {
        _isGameOver = true;
    }
}
