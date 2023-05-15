﻿using UnityEngine;

public class MathTools
{
    public static Vector3 GetPointFromAngleAndDistance(Vector3 startingPoint, float yAngleDegrees, float distance)
    {
        // Convert the Y angle to radians
        float yAngleRadians = yAngleDegrees * Mathf.Deg2Rad;

        // Calculate the X and Z offsets using trigonometry
        float xOffset = distance * Mathf.Sin(yAngleRadians);
        float zOffset = distance * Mathf.Cos(yAngleRadians);

        // Create a new Vector3 with the calculated offsets and the same Y position as the starting point
        Vector3 newPoint = new Vector3(startingPoint.x + xOffset, startingPoint.y, startingPoint.z + zOffset);

        return newPoint;
    }
    
    public static Vector3 RotatePointAroundCenter(Vector3 center, float angle, Vector3 point)
    {
        // Convert the angle to radians
        float radians = angle * Mathf.Deg2Rad;

        // Calculate the sin and cosine of the angle
        float cos = Mathf.Cos(radians);
        float sin = Mathf.Sin(radians);

        // Translate the point to the origin
        Vector3 translatedPoint = point - center;

        // Apply the rotation
        float x = translatedPoint.x * cos - translatedPoint.z * sin;
        float z = translatedPoint.x * sin + translatedPoint.z * cos;

        // Translate the point back to its original position
        Vector3 rotatedPoint = new Vector3(x, point.y, z) + center;

        return rotatedPoint;
    }
    
    public static Vector3 GetDirectionFromTransformToPointCameraLooking(Transform transformOrigin, float distanceFromCamera)
    {
        // Get the position of the player
        Vector3 playerPos = transformOrigin.position;

        // Get the position and forward direction of the camera
        Camera mainCamera = Camera.main;
        Vector3 cameraPos = mainCamera.transform.position;
        Vector3 cameraForward = mainCamera.transform.forward;

        // Calculate the position of the point at the specified distance from the camera along its forward direction
        Vector3 pointPos = cameraPos + cameraForward * distanceFromCamera;

        // Calculate the direction from the player to the point
        Vector3 direction = (pointPos - playerPos).normalized;

        return direction;
    }
    
    public static float GetVerticalAngle(Vector3 pointA, Vector3 pointB)
    {
        Vector3 direction = pointB - pointA;
        
        float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
        if (angle < 360) angle += 360;
        if (angle > 360) angle -= 360;

        return angle;
    }
}