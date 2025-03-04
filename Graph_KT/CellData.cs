using System.Numerics;

namespace Graph_KT;

public class CellData(Vector2 coordinates)
{
    public Vector2 Coordinates { get; private set; } = coordinates;
    public int Layer { get; private set; } = -1;

    public void SetLayer(int layer) => Layer = layer;
}