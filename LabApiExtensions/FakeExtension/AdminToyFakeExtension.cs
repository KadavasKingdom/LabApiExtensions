using MapGeneration;
using UnityEngine;

namespace LabApiExtensions.FakeExtension;

/// <summary>
/// Extension for faking SyncVars for any <see cref="AdminToy"/>.
/// </summary>
public static class AdminToyFakeExtension
{
    #region AdminToyBase
    /// <inheritdoc cref="AdminToy.Position" />
    public static void SetFakePosition<T>(this T adminToy, Player target, Vector3 positon) where T : AdminToy
    {
        target.SendFakeSyncVar(adminToy.Base, 1, positon);
    }

    /// <inheritdoc cref="AdminToy.Rotation" />
    public static void SetFakeRotation<T>(this T adminToy, Player target, Quaternion rotation) where T : AdminToy
    {
        target.SendFakeSyncVar(adminToy.Base, 2, rotation);
    }

    /// <inheritdoc cref="AdminToy.Scale" />
    public static void SetFakeScale<T>(this T adminToy, Player target, Vector3 scale) where T : AdminToy
    {
        target.SendFakeSyncVar(adminToy.Base, 4, scale);
    }

    /// <inheritdoc cref="AdminToy.MovementSmoothing" />
    public static void SetFakeMovementSmoothing<T>(this T adminToy, Player target, byte movementSmoothing) where T : AdminToy
    {
        target.SendFakeSyncVar(adminToy.Base, 8, movementSmoothing);
    }

    /// <inheritdoc cref="AdminToy.IsStatic" />
    public static void SetFakeIsStatic<T>(this T adminToy, Player target, bool isStatic) where T : AdminToy
    {
        target.SendFakeSyncVar(adminToy.Base, 16, isStatic);
    }
    #endregion
    #region CapybaraToy
    /// <inheritdoc cref="CapybaraToy.CollidersEnabled" />
    public static void SetFakeCollisionsEnabled(this CapybaraToy capybaraToy, Player target, bool collisionsEnabled)
    {
        target.SendFakeSyncVar(capybaraToy.Base, 32, collisionsEnabled);
    }
    #endregion
    #region InvisibleInteractableToy
    /// <inheritdoc cref="InteractableToy.Shape" />
    public static void SetFakeShape(this InteractableToy invisibleInteractableToy, Player target, AdminToys.InvisibleInteractableToy.ColliderShape shape)
    {
        target.SendFakeSyncVar(invisibleInteractableToy.Base, 32, shape);
    }

    /// <inheritdoc cref="InteractableToy.InteractionDuration" />
    public static void SetFakeInteractionDuration(this InteractableToy invisibleInteractableToy, Player target, float interactionDuration)
    {
        target.SendFakeSyncVar(invisibleInteractableToy.Base, 64, interactionDuration);
    }

    /// <inheritdoc cref="InteractableToy.IsLocked" />
    public static void SetFakeIsLocked(this InteractableToy invisibleInteractableToy, Player target, bool isLocked)
    {
        target.SendFakeSyncVar(invisibleInteractableToy.Base, 128, isLocked);
    }
    #endregion
    #region LightSourceToy
    /// <inheritdoc cref="LightSourceToy.Intensity" />
    public static void SetFakeLightIntensity(this LightSourceToy lightSourceToy, Player target, float lightIntensity)
    {
        target.SendFakeSyncVar(lightSourceToy.Base, 32, lightIntensity);
    }

    /// <inheritdoc cref="LightSourceToy.Range" />
    public static void SetFakeLightRange(this LightSourceToy lightSourceToy, Player target, float lightRange)
    {
        target.SendFakeSyncVar(lightSourceToy.Base  , 64, lightRange);
    }

    /// <inheritdoc cref="LightSourceToy.Color" />
    public static void SetFakeLightColor(this LightSourceToy lightSourceToy, Player target, Color lightColor)
    {
        target.SendFakeSyncVar(lightSourceToy.Base, 128, lightColor);
    }

    /// <inheritdoc cref="LightSourceToy.ShadowType" />
    public static void SetFakeShadowType(this LightSourceToy lightSourceToy, Player target, LightShadows shadowType)
    {
        target.SendFakeSyncVar(lightSourceToy.Base, 256, shadowType);
    }

    /// <inheritdoc cref="LightSourceToy.ShadowStrength" />
    public static void SetFakeShadowStrength(this LightSourceToy lightSourceToy, Player target, float shadowStrength)
    {
        target.SendFakeSyncVar(lightSourceToy.Base, 512, shadowStrength);
    }

    /// <inheritdoc cref="LightSourceToy.Type" />
    public static void SetFakeLightType(this LightSourceToy lightSourceToy, Player target, LightType lightType)
    {
        target.SendFakeSyncVar(lightSourceToy.Base, 1024, lightType);
    }

    /// <inheritdoc cref="LightSourceToy.Shape" />
    [Obsolete("This property has been deprecated. Use LightType.Spot, LightType.Pyramid, or LightType.Box instead.")]
    public static void SetFakeLightShape(this LightSourceToy lightSourceToy, Player target, LightShape lightShape)
    {
        target.SendFakeSyncVar(lightSourceToy.Base, 2048L, lightShape);
    }

    /// <inheritdoc cref="LightSourceToy.SpotAngle" />
    public static void SetFakeSpotAngle(this LightSourceToy lightSourceToy, Player target, float spotAngle)
    {
        target.SendFakeSyncVar(lightSourceToy.Base, 4096L, spotAngle);
    }

    /// <inheritdoc cref="LightSourceToy.InnerSpotAngle" />
    public static void SetFakeInnerSpotAngle(this LightSourceToy lightSourceToy, Player target, float innerSpotAngle)
    {
        target.SendFakeSyncVar(lightSourceToy.Base, 8192L, innerSpotAngle);
    }
    #endregion
    #region PrimitiveObjectToy
    /// <inheritdoc cref="PrimitiveObjectToy.Type" />
    public static void SetFakePrimitiveType(this PrimitiveObjectToy primitiveObjectToy, Player target, PrimitiveType primitiveType)
    {
        target.SendFakeSyncVar(primitiveObjectToy.Base, 32, primitiveType);
    }

    /// <inheritdoc cref="PrimitiveObjectToy.Color" />
    public static void SetFakeMaterialColor(this PrimitiveObjectToy primitiveObjectToy, Player target, Color materialColor)
    {
        target.SendFakeSyncVar(primitiveObjectToy.Base, 64, materialColor);
    }

    /// <inheritdoc cref="PrimitiveObjectToy.Flags" />
    public static void SetFakePrimitiveFlags(this PrimitiveObjectToy primitiveObjectToy, Player target, AdminToys.PrimitiveFlags primitiveFlags)
    {
        target.SendFakeSyncVar(primitiveObjectToy.Base, 128, primitiveFlags);
    }
    #endregion
    #region Scp079CameraToy
    /// <inheritdoc cref="CameraToy.Label" />
    public static void SetFakeLabel(this CameraToy adminToy, Player target, string label)
    {
        target.SendFakeSyncVar(adminToy.Base, 32, label);
    }

    /// <inheritdoc cref="CameraToy.Room" />
    public static void SetFakeRoom(this CameraToy adminToy, Player target, RoomIdentifier room)
    {
        target.SendFakeSyncVar(adminToy.Base, 64, room);
    }

    /// <inheritdoc cref="CameraToy.VerticalConstraints" />
    public static void SetFakeVerticalConstraint(this CameraToy adminToy, Player target, Vector2 verticalConstraint)
    {
        target.SendFakeSyncVar(adminToy.Base, 128, verticalConstraint);
    }

    /// <inheritdoc cref="CameraToy.HorizontalConstraint" />
    public static void SetFakeHorizontalConstraint(this CameraToy adminToy, Player target, Vector2 horizontalConstraint)
    {
        target.SendFakeSyncVar(adminToy.Base, 256, horizontalConstraint);
    }

    /// <inheritdoc cref="CameraToy.ZoomConstraints" />
    public static void SetFakeZoomConstraint(this CameraToy adminToy, Player target, Vector2 zoomConstraint)
    {
        target.SendFakeSyncVar(adminToy.Base, 512, zoomConstraint);
    }
    #endregion
    #region ShootingTarget
    /// <inheritdoc cref="ShootingTargetToy.IsGlobal" />
    public static void SetFakeSyncMode(this ShootingTargetToy adminToy, Player target, bool syncMode)
    {
        target.SendFakeSyncVar(adminToy.Base, 32, syncMode);
    }
    #endregion
    #region SpawnableCullingParent
    /// <inheritdoc cref="SpawnableCullingParent.Position" />
    public static void SetFakeBoundsPosition(this SpawnableCullingParent spawnableCullingParent, Player target, Vector3 boundsPosition)
    {
        target.SendFakeSyncVar(spawnableCullingParent.Base, 1, boundsPosition);
    }

    /// <inheritdoc cref="SpawnableCullingParent.Size" />
    public static void SetFakeBoundsSize(this SpawnableCullingParent spawnableCullingParent, Player target, Vector3 boundsSize)
    {
        target.SendFakeSyncVar(spawnableCullingParent.Base, 2, boundsSize);
    }
    #endregion
    #region SpeakerToy
    /// <inheritdoc cref="SpeakerToy.ControllerId" />
    public static void SetFakeControllerId(this SpeakerToy adminToy, Player target, byte controllerId)
    {
        target.SendFakeSyncVar(adminToy.Base, 32, controllerId);
    }

    /// <inheritdoc cref="SpeakerToy.IsSpatial" />
    public static void SetFakeIsSpatial(this SpeakerToy adminToy, Player target, byte isSpatial)
    {
        target.SendFakeSyncVar(adminToy.Base, 64, isSpatial);
    }

    /// <inheritdoc cref="SpeakerToy.Volume" />
    public static void SetFakeVolume(this SpeakerToy adminToy, Player target, float volume)
    {
        target.SendFakeSyncVar(adminToy.Base, 128, volume);
    }

    /// <inheritdoc cref="SpeakerToy.MinDistance" />
    public static void SetFakeMinDistance(this SpeakerToy adminToy, Player target, float minDistance)
    {
        target.SendFakeSyncVar(adminToy.Base, 256, minDistance);
    }

    /// <inheritdoc cref="SpeakerToy.MaxDistance" />
    public static void SetFakeMaxDistance(this SpeakerToy adminToy, Player target, float maxDistance)
    {
        target.SendFakeSyncVar(adminToy.Base, 512, maxDistance);
    }
    #endregion
    #region TextToy
    /// <inheritdoc cref="TextToy.DisplaySize" />
    public static void SetFakeDisplaySize(this TextToy adminToy, Player target, Vector2 displaySize)
    {
        target.SendFakeSyncVar(adminToy.Base, 32, displaySize);
    }

    /// <inheritdoc cref="TextToy.TextFormat" />
    public static void SetFakeTextFormat(this TextToy adminToy, Player target, string textFormat)
    {
        target.SendFakeSyncVar(adminToy.Base, 64, textFormat);
    }
    #endregion
    #region WaypointToy
    /// <inheritdoc cref="WaypointToy.VisualizeBounds" />
    public static void SetFakeVisualizeBounds(this WaypointToy adminToy, Player target, bool visualizeBounds)
    {
        target.SendFakeSyncVar(adminToy.Base, 32, visualizeBounds);
    }

    /// <inheritdoc cref="WaypointToy.PriorityBias" />
    public static void SetFakePriority(this WaypointToy adminToy, Player target, float priority)
    {
        target.SendFakeSyncVar(adminToy.Base, 64, priority);
    }

    /// <inheritdoc cref="WaypointToy.BoundsSize" />
    public static void SetFakeBoundsSize(this WaypointToy adminToy, Player target, Vector3 boundsSize)
    {
        target.SendFakeSyncVar(adminToy.Base, 128, boundsSize);
    }
    #endregion
}
