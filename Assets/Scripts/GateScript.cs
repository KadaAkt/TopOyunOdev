using UnityEngine;

public class GateScript : MonoBehaviour
{
    public enum PillarColors
    {
        red,
        blue,
        green,
        yellow,

    }

    [SerializeField] private PillarColors gateColor;

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }
    void Start()
    {
        SetGateColor();
    }

    private void SetGateColor()
    {
        switch (gateColor)
        {
            case PillarColors.red:
                _renderer.material.color = new Color(1f, 0f, 0f, 0.5f);
                break;

            case PillarColors.blue:
                _renderer.material.color = new Color(0f, 0f, 1f, 0.5f);
                break;

            case PillarColors.green:
                _renderer.material.color = new Color(0f, 1f, 0f, 0.5f);
                break;

            case PillarColors.yellow:
                _renderer.material.color = new Color(1f, 1f, 0f, 0.5f);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        BallManagerNew player = other.GetComponent<BallManagerNew>();

        if (player != null)
        {
            if (player.HasColor && player.CurrentColor == gateColor)
            {
                Debug.Log("Geçtin!");
            }
            else
            {
                Debug.Log("Yanlış Renk!");
                player.ResetPlayer();
            }
        }
    }
}
