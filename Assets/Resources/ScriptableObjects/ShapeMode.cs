using UnityEngine;
using System.Collections;

public class ShapeMode : ScriptableObject
{
    [SerializeField]
    private Sprite shapeSprite;

    public Sprite ShapeSprite
    {
        get { return shapeSprite; }
        set { shapeSprite = value; }
    }

    [SerializeField]
    private Color shapeColor;

    public Color ShapeColor
    {
        get { return shapeColor; }
        set { shapeColor = value; }
    }

    [SerializeField]
    private string shapeName;

    public string ShapeName
    {
        get { return shapeName; }
        set { shapeName = value; }
    }
}
