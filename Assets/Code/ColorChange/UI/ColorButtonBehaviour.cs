using UnityEngine;
using System.Collections;

public class ColorButtonBehaviour : MonoBehaviour {

    [SerializeField]
    private Sprite triangleSprite;

    public Sprite TriangleSprite
    {
        get { return triangleSprite; }
        set { triangleSprite = value; }
    }
    [SerializeField]
    private Sprite polySprite;

    public Sprite PolySprite
    {
        get { return polySprite; }
        set { polySprite = value; }
    }
    [SerializeField]
    private Sprite circleSprite;

    public Sprite CircleSprite
    {
        get { return circleSprite; }
        set { circleSprite = value; }
    }
    [SerializeField]
    private Sprite diamondSprite;

    public Sprite DiamondSprite
    {
        get { return diamondSprite; }
        set { diamondSprite = value; }
    }



    [SerializeField]
    private SpriteRenderer characterSprite;
    public SpriteRenderer CharacterSprite
    {
        get { return characterSprite; }
        set { characterSprite = value; }
    }


    public void OnWhiteButtonClick()
    {
        characterSprite.color = Color.white;
        characterSprite.sprite = diamondSprite;

    }
    public void OnRedButtonClick()
    {
        characterSprite.color = Color.red;
        characterSprite.sprite = triangleSprite;

    }
    public void OnGreenButtonClick()
    {
        characterSprite.color = Color.green;
        characterSprite.sprite = polySprite;

    }
    public void OnBlueButtonClick()
    {
        characterSprite.color = Color.blue;
        characterSprite.sprite = circleSprite;

    }
}
