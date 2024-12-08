using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WorldPosition//everything in a static class belongs to the class itself, not any instance of that class
{
    public static Vector3 GetMouseWorldPosWithZ(Vector3 screenPos, Camera worldCam)
    {
        screenPos.z = Mathf.Abs(worldCam.transform.position.z);
        Vector3 worldPos = worldCam.ScreenToWorldPoint(screenPos);
        return worldPos;
    }
    public static Vector3 GetMouseWorldPos()
    {
        Vector3 result = GetMouseWorldPosWithZ(Input.mousePosition, Camera.main);
        result.z = 0f;
        return result;
    }
}
