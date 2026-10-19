using UnityEngine;

public class BallManagerNew : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;

    private Renderer _renderer;
    private Vector3 _startPosition;

    private GateScript.PillarColors _currentcolor;
    private bool _hasColor = false;
    private bool _gameCompleted = false;

    public GateScript.PillarColors CurrentColor
    {
        get { return _currentcolor; }
    }

    public bool HasColor
    {
        get { return _hasColor; }
    }

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _startPosition = transform.position;
    }

    void Update()
    {
        if (!_gameCompleted)
        {
            Movement();
        }
    }

    private void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        transform.Translate(direction * (moveSpeed * Time.deltaTime), Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bir Nesneye Çarptı");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Red"))
        {
            ChangeColor(GateScript.PillarColors.red, Color.red);
            Debug.Log("Nesne Kırmızı Oldu!");

        }
        else if (other.CompareTag("Blue"))
        {
            ChangeColor(GateScript.PillarColors.blue, Color.blue);
            Debug.Log("Nesne Mavi Oldu!");
        }
        else if (other.CompareTag("Green"))
        {
            ChangeColor(GateScript.PillarColors.green, Color.green);
            Debug.Log("Nesne Yeşil Oldu!");
        }
        else if (other.CompareTag("Yellow"))
        {
            ChangeColor(GateScript.PillarColors.yellow, Color.yellow);
            Debug.Log("Nesne Sarı Oldu!");
        }
        else if (other.CompareTag("Finish"))
        {
            CompleteGame();
        }
    }

    private void ChangeColor(GateScript.PillarColors newColor, Color color)
    {
        _currentcolor = newColor;
        _hasColor = true;

        _renderer.material.color = color;
    }

    public void ResetPlayer()
    {
        transform.position = _startPosition;
        _renderer.material.color = Color.white;
        _hasColor = false;
        Debug.Log("Yanlış Renk!");
    }
    public void CompleteGame()
    {
        _gameCompleted = true;
        Debug.Log("Kazandınız!");
    }
}
