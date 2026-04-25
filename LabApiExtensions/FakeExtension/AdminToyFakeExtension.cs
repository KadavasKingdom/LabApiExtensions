using AdminToys;
using MapGeneration;
using UnityEngine;

namespace LabApiExtensions.FakeExtension;

/// <summary>
/// Extension for faking SyncVars for any <see cref="AdminToyBase"/>.
/// </summary>
public static class AdminToyFakeExtension
{
    #region AdminToyBase
    /// <inheritdoc cref="AdminToy.Position" />
    public static void SetFakePosition<T>(this T adminToy, Player target, Vector3 positon) where T : AdminToyBase
    {
        target.SendFakeSyncVar(adminToy, 1, positon);
    }

    /// <inheritdoc cref="AdminToy.Rotation" />
    public static void SetFakeRotation<T>(this T adminToy, Player target, Quaternion rotation) where T : AdminToyBase
    {
        target.SendFakeSyncVar(adminToy, 2, rotation);
    }

    /// <inheritdoc cref="AdminToy.Scale" />
    public static void SetFakeScale<T>(this T adminToy, Player target, Vector3 scale) where T : AdminToyBase
    {
        target.SendFakeSyncVar(adminToy, 4, scale);
    }

    /// <inheritdoc cref="AdminToy.MovementSmoothing" />
    public static void SetFakeMovementSmoothing<T>(this T adminToy, Player target, byte movementSmoothing) where T : AdminToyBase
    {
        target.SendFakeSyncVar(adminToy, 8, movementSmoothing);
    }

    /// <inheritdoc cref="AdminToy.IsStatic" />
    public static void SetFakeIsStatic<T>(this T adminToy, Player target, bool isStatic) where T : AdminToyBase
    {
        target.SendFakeSyncVar(adminToy, 16, isStatic);
    }
    #endregion
    #region CapybaraToy
    /// <inheritdoc cref="LabApi.Features.Wrappers.CapybaraToy.CollidersEnabled" />
    public static void SetFakeCollisionsEnabled(this AdminToys.CapybaraToy capybaraToy, Player target, bool collisionsEnabled)
    {
        target.SendFakeSyncVar(capybaraToy, 32, collisionsEnabled);
    }
    #endregion
    #region InvisibleInteractableToy
    /// <inheritdoc cref="InteractableToy.Shape" />
    public static void SetFakeShape(this InvisibleInteractableToy invisibleInteractableToy, Player target, InvisibleInteractableToy.ColliderShape shape)
    {
        target.SendFakeSyncVar(invisibleInteractableToy, 32, shape);
    }

    /// <inheritdoc cref="InteractableToy.InteractionDuration" />
    public static void SetFakeInteractionDuration(this InvisibleInteractableToy invisibleInteractableToy, Player target, float interactionDuration)
    {
        target.SendFakeSyncVar(invisibleInteractableToy, 64, interactionDuration);
    }

    /// <inheritdoc cref="InteractableToy.IsLocked" />
    public static void SetFakeIsLocked(this InvisibleInteractableToy invisibleInteractableToy, Player target, bool isLocked)
    {
        target.SendFakeSyncVar(invisibleInteractableToy, 128, isLocked);
    }
    #endregion
    #region LightSourceToy
    /// <inheritdoc cref="LabApi.Features.Wrappers.LightSourceToy.Intensity" />
    public static void SetFakeLightIntensity(this AdminToys.LightSourceToy lightSourceToy, Player target, float lightIntensity)
    {
        target.SendFakeSyncVar(lightSourceToy, 32, lightIntensity);
    }

    /// <inheritdoc cref="LabApi.Features.Wrappers.LightSourceToy.Range" />
    public static void SetFakeLightRange(this AdminToys.LightSourceToy lightSourceToy, Player target, float lightRange)
    {
        target.SendFakeSyncVar(lightSourceToy, 64, lightRange);
    }

    /// <inheritdoc cref="LabApi.Features.Wrappers.LightSourceToy.Color" />
    public static void SetFakeLightColor(this AdminToys.LightSourceToy lightSourceToy, Player target, Color lightColor)
    {
        target.SendFakeSyncVar(lightSourceToy, 128, lightColor);
    }

    /// <inheritdoc cref="LabApi.Features.Wrappers.LightSourceToy.ShadowType" />
    public static void SetFakeShadowType(this AdminToys.LightSourceToy lightSourceToy, Player target, LightShadows shadowType)
    {
        target.SendFakeSyncVar(lightSourceToy, 256, shadowType);
    }

    /// <inheritdoc cref="LabApi.Features.Wrappers.LightSourceToy.ShadowStrength" />
    public static void SetFakeShadowStrength(this AdminToys.LightSourceToy lightSourceToy, Player target, float shadowStrength)
    {
        target.SendFakeSyncVar(lightSourceToy, 512, shadowStrength);
    }

    /// <inheritdoc cref="LabApi.Features.Wrappers.LightSourceToy.Type" />
    public static void SetFakeLightType(this AdminToys.LightSourceToy lightSourceToy, Player target, LightType lightType)
    {
        target.SendFakeSyncVar(lightSourceToy, 1024, lightType);
    }

    /// <inheritdoc cref="LabApi.Features.Wrappers.LightSourceToy.Shape" />
    [Obsolete("This property has been deprecated. Use LightType.Spot, LightType.Pyramid, or LightType.Box instead.")]
    public static void SetFakeLightShape(this AdminToys.LightSourceToy lightSourceToy, Player target, LightShape lightShape)
    {
        target.SendFakeSyncVar(lightSourceToy, 2048L, lightShape);
    }

    /// <inheritdoc cref="LabApi.Features.Wrappers.LightSourceToy.SpotAngle" />
    public static void SetFakeSpotAngle(this AdminToys.LightSourceToy lightSourceToy, Player target, float spotAngle)
    {
        target.SendFakeSyncVar(lightSourceToy, 4096L, spotAngle);
    }

    /// <inheritdoc cref="LabApi.Features.Wrappers.LightSourceToy.InnerSpotAngle" />
    public static void SetFakeInnerSpotAngle(this AdminToys.LightSourceToy lightSourceToy, Player target, float innerSpotAngle)
    {
        target.SendFakeSyncVar(lightSourceToy, 8192L, innerSpotAngle);
    }
    #endregion
    #region PrimitiveObjectToy
    /// <inheritdoc cref="LabApi.Features.Wrappers.PrimitiveObjectToy.Type" />
    public static void SetFakePrimitiveType(this AdminToys.PrimitiveObjectToy primitiveObjectToy, Player target, PrimitiveType primitiveType)
    {
        target.SendFakeSyncVar(primitiveObjectToy, 32, primitiveType);
    }

    /// <inheritdoc cref="LabApi.Features.Wrappers.PrimitiveObjectToy.Color" />
    public static void SetFakeMaterialColor(this AdminToys.PrimitiveObjectToy primitiveObjectToy, Player target, Color materialColor)
    {
        target.SendFakeSyncVar(primitiveObjectToy, 64, materialColor);
    }

    /// <inheritdoc cref="LabApi.Features.Wrappers.PrimitiveObjectToy.Flags" />
    public static void SetFakePrimitiveFlags(this AdminToys.PrimitiveObjectToy primitiveObjectToy, Player target, PrimitiveFlags primitiveFlags)
    {
        target.SendFakeSyncVar(primitiveObjectToy, 128, primitiveFlags);
    }
    #endregion
    #region Scp079CameraToy
    /// <inheritdoc cref="CameraToy.Label" />
    public static void SetFakeLabel(this Scp079CameraToy adminToy, Player target, string label)
    {
        target.SendFakeSyncVar(adminToy, 32, label);
    }

    /// <inheritdoc cref="CameraToy.Room" />
    public static void SetFakeRoom(this Scp079CameraToy adminToy, Player target, RoomIdentifier room)
    {
        target.SendFakeSyncVar(adminToy, 64, room);
    }

    /// <inheritdoc cref="CameraToy.VerticalConstraints" />
    public static void SetFakeVerticalConstraint(this Scp079CameraToy adminToy, Player target, Vector2 verticalConstraint)
    {
        target.SendFakeSyncVar(adminToy, 128, verticalConstraint);
    }

    /// <inheritdoc cref="CameraToy.HorizontalConstraint" />
    public static void SetFakeHorizontalConstraint(this Scp079CameraToy adminToy, Player target, Vector2 horizontalConstraint)
    {
        target.SendFakeSyncVar(adminToy, 256, horizontalConstraint);
    }

    /// <inheritdoc cref="CameraToy.ZoomConstraints" />
    public static void SetFakeZoomConstraint(this Scp079CameraToy adminToy, Player target, Vector2 zoomConstraint)
    {
        target.SendFakeSyncVar(adminToy, 512, zoomConstraint);
    }
    #endregion
    #region ShootingTarget
    /// <inheritdoc cref="ShootingTargetToy.IsGlobal" />
    public static void SetFakeSyncMode(this ShootingTarget adminToy, Player target, bool syncMode)
    {
        target.SendFakeSyncVar(adminToy, 32, syncMode);
    }
    #endregion
    #region SpawnableCullingParent
    /// <inheritdoc cref="LabApi.Features.Wrappers.SpawnableCullingParent.Position" />
    public static void SetFakeBoundsPosition(this AdminToys.SpawnableCullingParent spawnableCullingParent, Player target, Vector3 boundsPosition)
    {
        target.SendFakeSyncVar(spawnableCullingParent, 1, boundsPosition);
    }

    /// <inheritdoc cref="LabApi.Features.Wrappers.SpawnableCullingParent.Size" />
    public static void SetFakeBoundsSize(this AdminToys.SpawnableCullingParent spawnableCullingParent, Player target, Vector3 boundsSize)
    {
        target.SendFakeSyncVar(spawnableCullingParent, 2, boundsSize);
    }
    #endregion
    #region SpeakerToy
    /// <inheritdoc cref="LabApi.Features.Wrappers.SpeakerToy.ControllerId" />
    public static void SetFakeControllerId(this AdminToys.SpeakerToy adminToy, Player target, byte controllerId)
    {
        target.SendFakeSyncVar(adminToy, 32, controllerId);
    }

    /// <inheritdoc cref="LabApi.Features.Wrappers.SpeakerToy.IsSpatial" />
    public static void SetFakeIsSpatial(this AdminToys.SpeakerToy adminToy, Player target, byte isSpatial)
    {
        target.SendFakeSyncVar(adminToy, 64, isSpatial);
    }

    /// <inheritdoc cref="LabApi.Features.Wrappers.SpeakerToy.Volume" />
    public static void SetFakeVolume(this AdminToys.SpeakerToy adminToy, Player target, float volume)
    {
        target.SendFakeSyncVar(adminToy, 128, volume);
    }

    /// <inheritdoc cref="LabApi.Features.Wrappers.SpeakerToy.MinDistance" />
    public static void SetFakeMinDistance(this AdminToys.SpeakerToy adminToy, Player target, float minDistance)
    {
        target.SendFakeSyncVar(adminToy, 256, minDistance);
    }

    /// <inheritdoc cref="LabApi.Features.Wrappers.SpeakerToy.MaxDistance" />
    public static void SetFakeMaxDistance(this AdminToys.SpeakerToy adminToy, Player target, float maxDistance)
    {
        target.SendFakeSyncVar(adminToy, 512, maxDistance);
    }
    #endregion
    #region TextToy
    /// <inheritdoc cref="LabApi.Features.Wrappers.TextToy.DisplaySize" />
    public static void SetFakeDisplaySize(this AdminToys.TextToy adminToy, Player target, Vector2 displaySize)
    {
        target.SendFakeSyncVar(adminToy, 32, displaySize);
    }

    /// <inheritdoc cref="LabApi.Features.Wrappers.TextToy.TextFormat" />
    public static void SetFakeTextFormat(this AdminToys.TextToy adminToy, Player target, string textFormat)
    {
        target.SendFakeSyncVar(adminToy, 64, textFormat);
    }
    #endregion
    #region WaypointToy
    /// <inheritdoc cref="LabApi.Features.Wrappers.WaypointToy.VisualizeBounds" />
    public static void SetFakeVisualizeBounds(this AdminToys.WaypointToy adminToy, Player target, bool visualizeBounds)
    {
        target.SendFakeSyncVar(adminToy, 32, visualizeBounds);
    }

    /// <inheritdoc cref="LabApi.Features.Wrappers.WaypointToy.PriorityBias" />
    public static void SetFakePriority(this AdminToys.WaypointToy adminToy, Player target, float priority)
    {
        target.SendFakeSyncVar(adminToy, 64, priority);
    }

    /// <inheritdoc cref="LabApi.Features.Wrappers.WaypointToy.BoundsSize" />
    public static void SetFakeBoundsSize(this AdminToys.WaypointToy adminToy, Player target, Vector3 boundsSize)
    {
        target.SendFakeSyncVar(adminToy, 128, boundsSize);
    }
    #endregion
}
