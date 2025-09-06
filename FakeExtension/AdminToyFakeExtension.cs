using AdminToys;
using MapGeneration;
using UnityEngine;

namespace LabApiExtensions.FakeExtension;

public static class AdminToyFakeExtension
{
    #region AdminToyBase
    public static void SetFakePosition<T>(this T adminToy, Player target, Vector3 positon) where T : AdminToyBase
    {
        target.SendFakeSyncVar(adminToy, 1, positon);
    }

    public static void SetFakeRotation<T>(this T adminToy, Player target, Vector3 rotation) where T : AdminToyBase
    {
        target.SendFakeSyncVar(adminToy, 2, rotation);
    }

    public static void SetFakeScale<T>(this T adminToy, Player target, Vector3 scale) where T : AdminToyBase
    {
        target.SendFakeSyncVar(adminToy, 4, scale);
    }

    public static void SetFakeMovementSmoothing<T>(this T adminToy, Player target, byte movementSmoothing) where T : AdminToyBase
    {
        target.SendFakeSyncVar(adminToy, 8, movementSmoothing);
    }

    public static void SetFakeIsStatic<T>(this T adminToy, Player target, bool isStatic) where T : AdminToyBase
    {
        target.SendFakeSyncVar(adminToy, 16, isStatic);
    }
    #endregion
    #region CapybaraToy
    public static void SetFakeCollisionsEnabled(this AdminToys.CapybaraToy capybaraToy, Player target, bool collisionsEnabled)
    {
        target.SendFakeSyncVar(capybaraToy, 32, collisionsEnabled);
    }
    #endregion
    #region InvisibleInteractableToy
    public static void SetFakeShape(this InvisibleInteractableToy invisibleInteractableToy, Player target, InvisibleInteractableToy.ColliderShape shape)
    {
        target.SendFakeSyncVar(invisibleInteractableToy, 32, shape);
    }

    public static void SetFakeInteractionDuration(this InvisibleInteractableToy invisibleInteractableToy, Player target, float interactionDuration)
    {
        target.SendFakeSyncVar(invisibleInteractableToy, 64, interactionDuration);
    }

    public static void SetFakeIsLocked(this InvisibleInteractableToy invisibleInteractableToy, Player target, bool isLocked)
    {
        target.SendFakeSyncVar(invisibleInteractableToy, 128, isLocked);
    }
    #endregion
    #region LightSourceToy
    public static void SetFakeLightIntensity(this AdminToys.LightSourceToy lightSourceToy, Player target, float lightIntensity)
    {
        target.SendFakeSyncVar(lightSourceToy, 32, lightIntensity);
    }

    public static void SetFakeLightRange(this AdminToys.LightSourceToy lightSourceToy, Player target, float lightRange)
    {
        target.SendFakeSyncVar(lightSourceToy, 64, lightRange);
    }

    public static void SetFakeLightColor(this AdminToys.LightSourceToy lightSourceToy, Player target, Color lightColor)
    {
        target.SendFakeSyncVar(lightSourceToy, 128, lightColor);
    }

    public static void SetFakeShadowType(this AdminToys.LightSourceToy lightSourceToy, Player target, LightShadows shadowType)
    {
        target.SendFakeSyncVar(lightSourceToy, 256, shadowType);
    }

    public static void SetFakeShadowStrength(this AdminToys.LightSourceToy lightSourceToy, Player target, float shadowStrength)
    {
        target.SendFakeSyncVar(lightSourceToy, 512, shadowStrength);
    }

    public static void SetFakeLightType(this AdminToys.LightSourceToy lightSourceToy, Player target, LightType lightType)
    {
        target.SendFakeSyncVar(lightSourceToy, 1024, lightType);
    }

    [Obsolete("This property has been deprecated. Use LightType.Spot, LightType.Pyramid, or LightType.Box instead.")]
    public static void SetFakeLightShape(this AdminToys.LightSourceToy lightSourceToy, Player target, LightShape lightShape)
    {
        target.SendFakeSyncVar(lightSourceToy, 2048L, lightShape);
    }

    public static void SetFakeSpotAngle(this AdminToys.LightSourceToy lightSourceToy, Player target, float spotAngle)
    {
        target.SendFakeSyncVar(lightSourceToy, 4096L, spotAngle);
    }

    public static void SetFakeInnerSpotAngle(this AdminToys.LightSourceToy lightSourceToy, Player target, float innerSpotAngle)
    {
        target.SendFakeSyncVar(lightSourceToy, 8192L, innerSpotAngle);
    }
    #endregion
    #region PrimitiveObjectToy
    public static void SetFakePrimitiveType(this AdminToys.PrimitiveObjectToy primitiveObjectToy, Player target, PrimitiveType primitiveType)
    {
        target.SendFakeSyncVar(primitiveObjectToy, 32, primitiveType);
    }

    public static void SetFakeMaterialColor(this AdminToys.PrimitiveObjectToy primitiveObjectToy, Player target, Color materialColor)
    {
        target.SendFakeSyncVar(primitiveObjectToy, 64, materialColor);
    }

    public static void SetFakePrimitiveFlags(this AdminToys.PrimitiveObjectToy primitiveObjectToy, Player target, PrimitiveFlags primitiveFlags)
    {
        target.SendFakeSyncVar(primitiveObjectToy, 128, primitiveFlags);
    }
    #endregion
    #region Scp079CameraToy
    public static void SetFakeLabel(this Scp079CameraToy adminToy, Player target, string label)
    {
        target.SendFakeSyncVar(adminToy, 32, label);
    }

    public static void SetFakeRoom(this Scp079CameraToy adminToy, Player target, RoomIdentifier room)
    {
        target.SendFakeSyncVar(adminToy, 64, room);
    }

    public static void SetFakeVerticalConstraint(this Scp079CameraToy adminToy, Player target, Vector2 verticalConstraint)
    {
        target.SendFakeSyncVar(adminToy, 128, verticalConstraint);
    }

    public static void SetFakeHorizontalConstraint(this Scp079CameraToy adminToy, Player target, Vector2 horizontalConstraint)
    {
        target.SendFakeSyncVar(adminToy, 256, horizontalConstraint);
    }
    public static void SetFakeZoomConstraint(this Scp079CameraToy adminToy, Player target, Vector2 zoomConstraint)
    {
        target.SendFakeSyncVar(adminToy, 512, zoomConstraint);
    }
    #endregion
    #region ShootingTarget
    public static void SetFakeSyncMode(this ShootingTarget adminToy, Player target, bool syncMode)
    {
        target.SendFakeSyncVar(adminToy, 32, syncMode);
    }
    #endregion
    #region SpawnableCullingParent
    public static void SetFakeBoundsPosition(this AdminToys.SpawnableCullingParent spawnableCullingParent, Player target, Vector3 boundsPosition)
    {
        target.SendFakeSyncVar(spawnableCullingParent, 1, boundsPosition);
    }

    public static void SetFakeBoundsSize(this AdminToys.SpawnableCullingParent spawnableCullingParent, Player target, Vector3 boundsSize)
    {
        target.SendFakeSyncVar(spawnableCullingParent, 2, boundsSize);
    }
    #endregion
    #region SpeakerToy
    public static void SetFakeControllerId(this AdminToys.SpeakerToy adminToy, Player target, byte controllerId)
    {
        target.SendFakeSyncVar(adminToy, 32, controllerId);
    }

    public static void SetFakeIsSpatial(this AdminToys.SpeakerToy adminToy, Player target, byte isSpatial)
    {
        target.SendFakeSyncVar(adminToy, 64, isSpatial);
    }

    public static void SetFakeVolume(this AdminToys.SpeakerToy adminToy, Player target, float volume)
    {
        target.SendFakeSyncVar(adminToy, 128, volume);
    }

    public static void SetFakeMinDistance(this AdminToys.SpeakerToy adminToy, Player target, float minDistance)
    {
        target.SendFakeSyncVar(adminToy, 256, minDistance);
    }

    public static void SetFakeMaxDistance(this AdminToys.SpeakerToy adminToy, Player target, float maxDistance)
    {
        target.SendFakeSyncVar(adminToy, 512, maxDistance);
    }
    #endregion
    #region TextToy
    public static void SetFakeDisplaySize(this AdminToys.TextToy adminToy, Player target, Vector2 displaySize)
    {
        target.SendFakeSyncVar(adminToy, 32, displaySize);
    }

    public static void SetFakeTextFormat(this AdminToys.TextToy adminToy, Player target, string textFormat)
    {
        target.SendFakeSyncVar(adminToy, 64, textFormat);
    }
    #endregion
    #region WaypointToy
    public static void SetFakeVisualizeBounds(this AdminToys.WaypointToy adminToy, Player target, bool visualizeBounds)
    {
        target.SendFakeSyncVar(adminToy, 32, visualizeBounds);
    }

    public static void SetFakePriority(this AdminToys.WaypointToy adminToy, Player target, float priority)
    {
        target.SendFakeSyncVar(adminToy, 64, priority);
    }
    #endregion
}
