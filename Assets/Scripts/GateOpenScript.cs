using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GateOpenScript : MonoBehaviour
{
    [SerializeField] private List<GateObject> gateObjects;
    [SerializeField] private Tilemap map;
    [SerializeField] private SpriteRenderer myRenderer;

    private Dictionary<TileBase, GateObject> gates;
    private CubeDetectScript cubeDetect;

    void Awake()
    {
        cubeDetect = gameObject.GetComponent<CubeDetectScript>();

        gates = new Dictionary<TileBase, GateObject>();

        foreach (var gateObject in gateObjects)
        {
            gates.Add(gateObject.gates, gateObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (cubeDetect.HasChanged)
        {
            switch (myRenderer.sprite.name)
            {
                case "Blue Cube-Sheet":
                    RemoveGates("blue");
                    break;
                case "Green Cube-Sheet":
                    RemoveGates("green");
                    break;
                case "Red Cube-Sheet":
                    RemoveGates("red");
                    break;
                case "Blue + Green Cube-Sheet":
                    RemoveGates("blue green");
                    break;
                case "Red + Blue Cube-Sheet":
                    RemoveGates("red blue");
                    break;
                case "Red + Green Cube-Sheet":
                    RemoveGates("red green");
                    break;
                case "All 3-Sheet":
                    RemoveGates("all 3");
                    break;
                case "Blue 2 + Green-Sheet":
                    RemoveGates("blue2 green");
                    break;
                case "Blue 2 + Red-Sheet":
                    RemoveGates("blue2 red");
                    break;
                case "Green 2 + Blue-Sheet":
                    RemoveGates("green2 blue");
                    break;
                case "Green 2 + Red-Sheet":
                    RemoveGates("green2 red");
                    break;
                case "Red 2 + Blue-Sheet":
                    RemoveGates("red2 blue");
                    break;
                case "Red 2 + Green-Sheet":
                    RemoveGates("red2 green");
                    break;
            }
        }
    }

    public void RemoveGates(string currColor)
    {
        for (int i = -22; i < 23; i++)
        {
            for (int j = -10; j < 11; j++)
            {
                Vector3Int currPos = map.WorldToCell(new Vector3(i, j));
                TileBase currTile = map.GetTile(currPos);

                if (currTile != null && gates[currTile].color == currColor) {
                    map.SetTile(currPos, null);
                }
            }
        }
    }
}
