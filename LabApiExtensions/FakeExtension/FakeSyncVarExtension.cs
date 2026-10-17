using Mirror;

namespace LabApiExtensions.FakeExtension;

/// <summary>
/// Extension for sending fake SyncVar with <see cref="Player"/>.
/// </summary>
public static class FakeSyncVarExtension
{
	/// <summary>
	/// Sending fale Sync Var to <paramref name="target"/>.
	/// </summary>
	/// <typeparam name="T">Any type.</typeparam>
	/// <param name="target">The target to send to.</param>
	/// <param name="networkBehaviour">The behaviour to change.</param>
	/// <param name="dirtyBit">The dirtyBit value of the SyncVar.</param>
	/// <param name="value">The value to write.</param>
	/// <remarks>
	/// Dirty bit values can be read by decompiling. <br></br>
	/// Check for <see cref="NetworkBehaviour.SerializeSyncVars"/> in the <paramref name="networkBehaviour"/>.
	/// </remarks>
	public static void SendFakeSyncVar<T>(this Player target, NetworkBehaviour networkBehaviour, ulong dirtyBit, T value)
	{
		if (target == null)
		{
			throw new ArgumentNullException(nameof(target));
		}

		if (networkBehaviour == null)
		{
			throw new ArgumentNullException(nameof(networkBehaviour));
		}

		Type networkType = networkBehaviour.GetType();

		target.SendFakeCore(
			networkBehaviour,
			null,
			(writer) =>

			// Write SyncVar
			{
				// Write DrityBit always
				writer.WriteULong(dirtyBit);

				FakeSyncCoreExtension.SubWriteInfo subWriteInfo = FakeSyncCoreExtension.GetSubWriteInfo(networkType);
				bool isWritten = false;

				if (dirtyBit > subWriteInfo.MaxDirtyBit)
				{
					FakeSyncCoreExtension.WriteExtraDirtyBit(subWriteInfo, writer, dirtyBit);
					isWritten = true;
				}

				writer.Write(value);

				if (!isWritten)
				{
					FakeSyncCoreExtension.WriteExtraDirtyBit(subWriteInfo, writer, dirtyBit);
				}
			});
	}

	/// <summary>
	/// Sending fale Sync Var to <paramref name="targets"/>.
	/// </summary>
	/// <typeparam name="T">Any type.</typeparam>
	/// <param name="targets">The targets to send to.</param>
	/// <param name="networkBehaviour">The behaviour to change.</param>
	/// <param name="dirtyBit">The dirtyBit value of the SyncVar.</param>
	/// <param name="value">The value to write.</param>
	/// <remarks>
	/// Dirty bit values can be read by decompiling. <br></br>
	/// Check for <see cref="NetworkBehaviour.SerializeSyncVars"/> in the <paramref name="networkBehaviour"/>.
	/// </remarks>
	public static void SendFakeSyncVar<T>(this IEnumerable<Player> targets, NetworkBehaviour networkBehaviour, ulong dirtyBit, T value)
	{
		if (networkBehaviour == null)
		{
			throw new ArgumentNullException(nameof(networkBehaviour));
		}

		Type networkType = networkBehaviour.GetType();

		targets.SendFakeCore(
			networkBehaviour,
			null,
			(writer) =>

			// Write SyncVar
			{
				// Write DrityBit always
				writer.WriteULong(dirtyBit);

				FakeSyncCoreExtension.SubWriteInfo subWriteInfo = FakeSyncCoreExtension.GetSubWriteInfo(networkType);
				bool isWritten = false;

				if (dirtyBit > subWriteInfo.MaxDirtyBit)
				{
					FakeSyncCoreExtension.WriteExtraDirtyBit(subWriteInfo, writer, dirtyBit);
					isWritten = true;
				}

				writer.Write(value);

				if (!isWritten)
				{
					FakeSyncCoreExtension.WriteExtraDirtyBit(subWriteInfo, writer, dirtyBit);
				}
			});
	}
}
