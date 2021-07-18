using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer innerSprite;
    
    public PolygonCollider2D polyCollider;

    public bool isPossibleDestination;

    private SpriteRenderer sprite;

    private Color32 defaultColor;
    //private Color32 defaultInnerColor;



    // Start is called before the first frame update
    void Start()
    {

        sprite = GetComponent<SpriteRenderer>();
        polyCollider = GetComponent<PolygonCollider2D>();



        defaultColor = sprite.color;
        //defaultInnerColor = innerSprite.color;

        isPossibleDestination = false;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //highlights cells
    public void HighlightSelf()
    {
        //print("highlight cell");

        sprite.color = Color.white;

        //brings sprite to front
        sprite.sortingOrder = 1;
        innerSprite.sortingOrder = 2;
    }

    public void RevertHightligh()
    {
        sprite.color = defaultColor;

        //reverts the sorting order to default
        sprite.sortingOrder = 0;
        innerSprite.sortingOrder = 1;
    }
}
