using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColorButtonBehaviour : MonoBehaviour
{

    [SerializeField]
    private ShapeMode scriptableShape;

    public ShapeMode ScriptableShape
    {
        get { return scriptableShape; }
        set { scriptableShape = value; }
    }
    [SerializeField]
    private Image shapeImage;

    public Image ShapeImage
    {
        get { return shapeImage; }
        set { shapeImage = value; }
    }

    void Start()
    {
        shapeImage.sprite = scriptableShape.ShapeSprite;
        shapeImage.color = scriptableShape.ShapeColor;

    }
}
