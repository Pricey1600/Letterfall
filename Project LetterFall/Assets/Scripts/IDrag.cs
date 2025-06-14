using UnityEngine;
public interface IDrag
{
    void onStartDrag();
    void onEndDrag();

    void onSwapped(Vector2 swapPos);
}
