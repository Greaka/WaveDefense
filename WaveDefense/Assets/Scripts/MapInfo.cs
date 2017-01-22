using System;
using Tiled2Unity;
using UnityEngine;

public class MapInfo : MonoBehaviour
{
    private static MapInfo _instance;
    private TiledMap tiledMap;

    public static MapInfo Instance
    {
        get
        {
            if (_instance != null)
                return _instance;
            var CharacterLoadout = new GameObject("MapInfo");
            _instance = CharacterLoadout.AddComponent<MapInfo>();
            return _instance;
        }
        private set { }
    }

    public static int Wave = 0;

    public static Vector3 Position;
    public static Quaternion Rotation;
    public static Vector3 Scale;

    public static TiledMap.MapOrientation Orientation = TiledMap.MapOrientation.Orthogonal;
    public static TiledMap.MapStaggerAxis StaggerAxis = TiledMap.MapStaggerAxis.X;
    public static TiledMap.MapStaggerIndex StaggerIndex = TiledMap.MapStaggerIndex.Odd;
    public static int HexSideLength = 0;

    public static int NumLayers = 0;
    public static int NumTilesWide = 0;
    public static int NumTilesHigh = 0;
    public static int TileWidth = 0;
    public static int TileHeight = 0;
    public static float ExportScale = 1.0f;

    // Note: Because maps can be isometric and staggered we simply can't multply tile width (or height) by number of tiles wide (or high) to get width (or height)
    // We rely on the exporter to calculate the width and height of the map
    public static int MapWidthInPixels = 0;
    public static int MapHeightInPixels = 0;

    public void Start()
    {
        tiledMap = GetComponent<TiledMap>();
    }

    public void Update()
    {
        Position = gameObject.transform.position;
        Rotation = gameObject.transform.rotation;
        Scale = gameObject.transform.localScale;
        Orientation = tiledMap.Orientation;
        StaggerAxis = tiledMap.StaggerAxis;
        StaggerIndex = tiledMap.StaggerIndex;
        HexSideLength = tiledMap.HexSideLength;
        NumLayers = tiledMap.NumLayers;
        NumTilesWide = tiledMap.NumTilesWide;
        NumTilesHigh = tiledMap.NumTilesHigh;
        TileWidth = tiledMap.TileWidth;
        TileHeight = tiledMap.TileHeight;
        ExportScale = tiledMap.ExportScale;
        MapWidthInPixels = tiledMap.MapWidthInPixels;
        MapHeightInPixels = tiledMap.MapHeightInPixels;
    }
}