using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CubeDetectScript : MonoBehaviour
{
    [SerializeField] private List<ColorChangeObject> changeCube;
    [SerializeField] private Tilemap map;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private SpriteRenderer myRenderer;
    [SerializeField] private Rigidbody2D myRigidBody;

    private Dictionary<TileBase, ColorChangeObject> listCubes;

    private bool hasChecked;
    public bool HasChecked
    {
        get { return hasChecked; }
        set { hasChecked = value; }
    }
    private bool hasChanged;
    public bool HasChanged
    {
        get { return hasChanged; }
        set { hasChanged = value; }
    }

    private void Awake()
    {
        listCubes = new Dictionary<TileBase, ColorChangeObject>();

        foreach (var colorObject in changeCube)
        {
            listCubes.Add(colorObject.colorChange, colorObject);
            //Debug.Log(colorObject.newColor);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3Int currPos = map.WorldToCell(transform.position);
        TileBase currTile = map.GetTile(currPos);

        if (!hasChecked)
        {
            if (currTile != null && listCubes.ContainsKey(currTile))
            {
                map.SetTile(currPos, null);
                string impactColor = listCubes[currTile].newColor;
                ChangeSprite(impactColor);
            }
            hasChecked = true;
        }

        if (myRigidBody.velocity == Vector2.zero && !hasChanged)
        {
            hasChecked = false;
        }
        else if (myRigidBody.velocity != Vector2.zero)
        {
            hasChanged = false;
        }
    }

    public void ChangeSprite(string impactColor)
    {
        string spriteName = myRenderer.sprite.name;
        
        if (impactColor == "white")
        {
            myRenderer.sprite = sprites[3];
        }

        switch (spriteName)
        {
            case "White Cube-Sheet":
                switch (impactColor)
                {
                    case "blue":
                        myRenderer.sprite = sprites[0];
                        break;
                    case "green":
                        myRenderer.sprite = sprites[1];
                        break;
                    case "red":
                        myRenderer.sprite = sprites[2];
                        break;
                }
                break;
            case "Blue Cube-Sheet":
                switch (impactColor)
                {
                    case "green":
                        myRenderer.sprite = sprites[4];
                        break;
                    case "red":
                        myRenderer.sprite = sprites[5];
                        break;
                }
                break;
            case "Green Cube-Sheet":
                switch (impactColor)
                {
                    case "blue":
                        myRenderer.sprite = sprites[4];
                        break;
                    case "red":
                        myRenderer.sprite = sprites[6];
                        break;
                }
                break;
            case "Red Cube-Sheet":
                switch (impactColor)
                {
                    case "blue":
                        myRenderer.sprite = sprites[5];
                        break;
                    case "green":
                        myRenderer.sprite = sprites[6];
                        break;
                }
                break;
            case "Blue + Green Cube-Sheet":
                switch (impactColor)
                {
                    case "blue":
                        myRenderer.sprite = sprites[8];
                        break;
                    case "green":
                        myRenderer.sprite = sprites[10];
                        break;
                    case "red":
                        myRenderer.sprite = sprites[7];
                        break;
                }
                break;
            case "Red + Blue Cube-Sheet":
                switch (impactColor)
                {
                    case "blue":
                        myRenderer.sprite = sprites[9];
                        break;
                    case "green":
                        myRenderer.sprite = sprites[7];
                        break;
                    case "red":
                        myRenderer.sprite = sprites[12];
                        break;
                }
                break;
            case "Red + Green Cube-Sheet":
                switch (impactColor)
                {
                    case "blue":
                        myRenderer.sprite = sprites[7];
                        break;
                    case "green":
                        myRenderer.sprite = sprites[11];
                        break;
                    case "red":
                        myRenderer.sprite = sprites[13];
                        break;
                }
                break;
        }
        hasChanged = true;
    }
}
