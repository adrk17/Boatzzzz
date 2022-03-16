using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WaveShape))]
public class OceanController : MonoBehaviour
{
    [SerializeField]
    private List<MeshGenerator> tiles = new List<MeshGenerator>();
    [SerializeField]
    private Transform mainBoat;
    private int boundryX;
    private int boundryZ;
    private int xSize;
    private int zSize;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in transform)
        {
            if (child.GetComponent<MeshGenerator>())
            {
                tiles.Add(child.GetComponent<MeshGenerator>());
            }
        }
        SetTiles();
        GetBoundries();
    }

    private void GetBoundries()
    {
        if (tiles == null) return;
        boundryX = tiles[0].startX + WaveShape.xSize;
        boundryZ = tiles[0].startZ + WaveShape.zSize;
    }

    private void SetTiles()
    {
        if (tiles.Count != 9) { print("Not enough meshes" + tiles.Count); return;}
        tiles[1].startX = tiles[0].startX - WaveShape.xSize;
        tiles[1].startZ = tiles[0].startZ - WaveShape.zSize;
        tiles[2].startX = tiles[0].startX - WaveShape.xSize;
        tiles[2].startZ = tiles[0].startZ;
        tiles[3].startX = tiles[0].startX - WaveShape.xSize;
        tiles[3].startZ = tiles[0].startZ + WaveShape.zSize;
        tiles[4].startX = tiles[0].startX;
        tiles[4].startZ = tiles[0].startZ + WaveShape.zSize;
        tiles[5].startX = tiles[0].startX + WaveShape.xSize;
        tiles[5].startZ = tiles[0].startZ + WaveShape.zSize;
        tiles[6].startX = tiles[0].startX + WaveShape.xSize;
        tiles[6].startZ = tiles[0].startZ;
        tiles[7].startX = tiles[0].startX + WaveShape.xSize;
        tiles[7].startZ = tiles[0].startZ - WaveShape.zSize;
        tiles[8].startX = tiles[0].startX;
        tiles[8].startZ = tiles[0].startZ - WaveShape.zSize;
    }

    private void Update()
    {
        if (mainBoat.position.x > boundryX)
        {
            tiles[0].startX += WaveShape.xSize;
            SetTiles();
            GetBoundries();
        }
        else if (mainBoat.position.z > boundryZ)
        {
            tiles[0].startZ += WaveShape.zSize;
            SetTiles();
            GetBoundries();
        }
        else if (mainBoat.position.x < tiles[0].startX)
        {
            tiles[0].startX -= WaveShape.xSize;
            SetTiles();
            GetBoundries();
        }
        else if (mainBoat.position.z < tiles[0].startZ)
        {
            tiles[0].startZ -= WaveShape.zSize;
            SetTiles();
            GetBoundries();
        }
    }
}
