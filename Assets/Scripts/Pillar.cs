using UnityEngine;
using UnityEngine.Splines.Interpolators;

public class Pillar : MonoBehaviour
{
    private enum pillarcolors
    {
        Red,
        Blue,
        Green,
        Yellow,
    }
    [SerializeField] pillarcolors pColor;
    private Renderer _renderer;
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }
    void Start()
    {
        switch (pColor)
        {
            case pillarcolors.Red:
                _renderer.material.color = Color.red;
                break;
            case pillarcolors.Blue:
                _renderer.material.color = Color.blue;
                break;
            case pillarcolors.Green:
                _renderer.material.color = Color.green;
                break;
            case pillarcolors.Yellow:
                _renderer.material.color = Color.yellow;
                break;
        }       
    }


    void Update()
    {
        
    }
}
