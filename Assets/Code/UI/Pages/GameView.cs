using UnityEngine;
public class GameView : UIView
{
    public SpriteRenderer Player { get; set; }

    public void ChangeShape(ShapeMode scriptableShapeObject)
    {
        Player.color = scriptableShapeObject.ShapeColor;
        Player.sprite = scriptableShapeObject.ShapeSprite;
    }
}
