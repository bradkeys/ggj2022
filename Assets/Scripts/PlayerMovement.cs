using UnityEngine;
using UnityEngine.InputSystem;

class PlayerMovement : MonoBehaviour
{
    void Update()
    {
        // TODO: also support gamepads and WASD
        var keyboard = Keyboard.current;

        if (keyboard.downArrowKey.wasPressedThisFrame)
        {
            Move(Vector3Int.down);
        }

        if (keyboard.leftArrowKey.wasPressedThisFrame)
        {
            Move(Vector3Int.left);
        }

        if (keyboard.rightArrowKey.wasPressedThisFrame)
        {
            Move(Vector3Int.right);
        }

        if (keyboard.upArrowKey.wasPressedThisFrame)
        {
            Move(Vector3Int.up);
        }
    }

    void Move(Vector3Int delta)
    {
        var targetTilePosition = Vector3Int.FloorToInt(transform.position) + delta;

        if (!Services.Get<MapService>().CanMoveToTile(targetTilePosition))
        {
            return;
        }

        transform.position = targetTilePosition;
    }
}
