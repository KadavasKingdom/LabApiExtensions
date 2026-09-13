using AdminToys;
using Mirror;

namespace LabApiExtensions.FakeExtension;

/// <summary>
/// Provides an extension and core methods for fake syncing.
/// </summary>
internal static class FakeSyncCoreExtension
{
	/// <summary>
	/// Provides informations about writing sync data.
	/// </summary>
	private static readonly SubWriteInfo[] SubWriteInfos =
	[

		// IF inherited like MyCapbybara : Capybara : AdminToyBase, we need to write 2 times.
		new(typeof(AdminToyBase), 16, 1),
	];

	/// <summary>
	/// Gets the <see cref="SubWriteInfo"/> via the <paramref name="type"/>.
	/// </summary>
	/// <param name="type">The type to get the subwrite info.</param>
	/// <returns>The stored <see cref="SubWriteInfo"/> or <see langword="default"/>.</returns>
	internal static SubWriteInfo GetSubWriteInfo(Type type)
	{
		foreach (SubWriteInfo info in SubWriteInfos)
		{
			if (type.IsSubclassOf(info.ClassType))
			{
				return info;
			}
		}

		return default;
	}

	/// <summary>
	/// Writes extra dirty bits.
	/// </summary>
	/// <param name="networkBehaviour">The behaviour to get the type from.</param>
	/// <param name="writer">The writer.</param>
	/// <param name="dirtyBit">The dirty bits to write.</param>
	internal static void WriteExtraDirtyBit(NetworkBehaviour networkBehaviour, NetworkWriterPooled writer, ulong dirtyBit = 0)
	{
		Type networkType = networkBehaviour.GetType();

		WriteExtraDirtyBit(networkType, writer, dirtyBit);
	}

	/// <summary>
	/// Writes extra dirty bits.
	/// </summary>
	/// <param name="networkType">The type to get the subwriter.</param>
	/// <param name="writer">The writer.</param>
	/// <param name="dirtyBit">The dirty bits to write.</param>
	internal static void WriteExtraDirtyBit(Type networkType, NetworkWriterPooled writer, ulong dirtyBit = 0)
	{
		SubWriteInfo writeInfo = GetSubWriteInfo(networkType);

		WriteExtraDirtyBit(writeInfo, writer, dirtyBit);
	}

	/// <summary>
	/// Writes extra dirty bits.
	/// </summary>
	/// <param name="writeInfo">The subwrite to get the extra write count.</param>
	/// <param name="writer">The writer.</param>
	/// <param name="dirtyBit">The dirty bits to write.</param>
	internal static void WriteExtraDirtyBit(SubWriteInfo writeInfo, NetworkWriterPooled writer, ulong dirtyBit = 0)
	{
		if (!writeInfo.IsSet)
		{
			return;
		}

		for (int i = 0; i < writeInfo.ExtraWriteCount; i++)
		{
			writer.WriteULong(dirtyBit);
		}
	}

	/// <summary>
	/// Writes a new faked <see cref="EntityStateMessage"/>.
	/// </summary>
	/// <param name="networkBehaviour">The behaviour to write the data from.</param>
	/// <param name="writeSyncObject">The action to write the sync object.</param>
	/// <param name="writeSyncVar">The action to write the sync vars.</param>
	/// <returns>A new faked <see cref="EntityStateMessage"/>.</returns>
	internal static EntityStateMessage WriteStateMessage(NetworkBehaviour networkBehaviour, Action<NetworkWriterPooled>? writeSyncObject, Action<NetworkWriterPooled>? writeSyncVar)
	{
		using NetworkWriterPooled writer = NetworkWriterPool.Get();

		// gets the dirty mask based on the changed behavior's index
		ulong mask = 0;
		mask |= 1UL << networkBehaviour.netIdentity.NetworkBehaviours.IndexOf(networkBehaviour);
		Compression.CompressVarUInt(writer, mask);

		// placeholder length
		int headerPosition = writer.Position;
		writer.WriteByte(0);
		int contentPosition = writer.Position;

		// Serialize Object Sync Data.
		if (writeSyncObject != null)
		{
			writeSyncObject.Invoke(writer);
		}
		else
		{
			writer.WriteULong(0);
		}

		// Write Object Sync Vars
		if (writeSyncVar != null)
		{
			writeSyncVar.Invoke(writer);
		}
		else
		{
			writer.WriteULong(0);
			WriteExtraDirtyBit(networkBehaviour, writer);
		}

		// end position safety write
		int endPosition = writer.Position;
		writer.Position = headerPosition;
		int size = endPosition - contentPosition;
		byte safety = (byte)(size & 0xFF);
		writer.WriteByte(safety);
		writer.Position = endPosition;

		return new()
		{
			netId = networkBehaviour.netId,
			payload = writer.ToArraySegment(),
		};
	}

	/// <summary>
	/// Send a fake sync to <paramref name="target"/>.
	/// </summary>
	/// <param name="target">The player to send to.</param>
	/// <param name="networkBehaviour">The target network behavour.</param>
	/// <param name="writeSyncObject">The action to write the sync object.</param>
	/// <param name="writeSyncVar">The action to write the sync vars.</param>
	/// <param name="channel">The channel to send the data to.</param>
	internal static void SendFakeCore(this Player target, NetworkBehaviour networkBehaviour, Action<NetworkWriterPooled>? writeSyncObject, Action<NetworkWriterPooled>? writeSyncVar, int channel = 0)
	{
		if (target.Connection == null)
		{
			return;
		}

		SendFakeCore(target.Connection, networkBehaviour, writeSyncObject, writeSyncVar, channel);
	}

	/// <summary>
	/// Send a fake sync to <paramref name="connection"/>.
	/// </summary>
	/// <param name="connection">The connection to send the fake sync to.</param>
	/// <param name="networkBehaviour">The target network behavour.</param>
	/// <param name="writeSyncObject">The action to write the sync object.</param>
	/// <param name="writeSyncVar">The action to write the sync vars.</param>
	/// <param name="channel">The channel to send the data to.</param>
	internal static void SendFakeCore(this NetworkConnection connection, NetworkBehaviour networkBehaviour, Action<NetworkWriterPooled>? writeSyncObject, Action<NetworkWriterPooled>? writeSyncVar, int channel = 0)
	{
		if (connection == null)
		{
			return;
		}

		EntityStateMessage message = WriteStateMessage(networkBehaviour, writeSyncObject, writeSyncVar);

		connection.Send(message, channel);
	}

	/// <summary>
	/// Send a fake sync to <paramref name="targets"/>.
	/// </summary>
	/// <param name="targets">The players to send to.</param>
	/// <param name="networkBehaviour">The target network behavour.</param>
	/// <param name="writeSyncObject">The action to write the sync object.</param>
	/// <param name="writeSyncVar">The action to write the sync vars.</param>
	/// <param name="channel">The channel to send the data to.</param>
	internal static void SendFakeCore(this IEnumerable<Player> targets, NetworkBehaviour networkBehaviour, Action<NetworkWriterPooled>? writeSyncObject, Action<NetworkWriterPooled>? writeSyncVar, int channel = 0)
	{
		SendFakeCore(targets.Select(static x => x.Connection), networkBehaviour, writeSyncObject, writeSyncVar, channel);
	}

	/// <summary>
	/// Send a fake sync to <paramref name="connections"/>.
	/// </summary>
	/// <param name="connections">The connections to send the fake sync to.</param>
	/// <param name="networkBehaviour">The target network behavour.</param>
	/// <param name="writeSyncObject">The action to write the sync object.</param>
	/// <param name="writeSyncVar">The action to write the sync vars.</param>
	/// <param name="channel">The channel to send the data to.</param>
	internal static void SendFakeCore(this IEnumerable<NetworkConnection> connections, NetworkBehaviour networkBehaviour, Action<NetworkWriterPooled>? writeSyncObject, Action<NetworkWriterPooled>? writeSyncVar, int channel = 0)
	{
		EntityStateMessage message = WriteStateMessage(networkBehaviour, writeSyncObject, writeSyncVar);

		foreach (NetworkConnection connection in connections)
		{
			if (connection == null)
			{
				continue;
			}

			connection.Send(message, channel);
		}
	}

	/// <summary>
	/// A subwrite info for writing Sub/Parent dirty bits.
	/// </summary>
	/// <param name="classType">The sub type.</param>
	/// <param name="dirtybit">The max dirty bit this type has.</param>
	/// <param name="writeCount">How many times it needs to be written.</param>
	internal readonly struct SubWriteInfo(Type classType, ulong dirtybit, int writeCount)
	{
		/// <summary>
		/// The type of the sub write.
		/// </summary>
		public readonly Type ClassType = classType;

		/// <summary>
		/// Maximum amount of dirty bit this class has.
		/// </summary>
		public readonly ulong MaxDirtyBit = dirtybit;

		/// <summary>
		/// Amount of times to write empty dirty bit.
		/// </summary>
		public readonly int ExtraWriteCount = writeCount;

		/// <summary>
		/// Gets whenever write info has been set.
		/// </summary>
		public readonly bool IsSet = classType != null;
	}
}
