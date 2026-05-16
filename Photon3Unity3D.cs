#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExitGames.Client.Photon.Encryption;
using ExitGames.Client.Photon.StructWrapping;
using Photon.SocketServer.Security;
using UnityEngine;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: TargetFramework(".NETStandard,Version=v2.0", FrameworkDisplayName = ".NET Standard 2.0")]
[assembly: AssemblyCompany("Exit Games GmbH")]
[assembly: AssemblyConfiguration("Unity-Debug")]
[assembly: AssemblyCopyright("(c) Exit Games GmbH, http://www.exitgames.com")]
[assembly: AssemblyDescription("Photon .Net Client Library. Debug.")]
[assembly: AssemblyFileVersion("4.1.8.15")]
[assembly: AssemblyInformationalVersion("4.1.8.15")]
[assembly: AssemblyProduct("Photon .Net Client Library. Debug.")]
[assembly: AssemblyTitle("Photon3Unity3D")]
[assembly: AssemblyVersion("4.1.8.15")]
namespace ExitGames.Client.Photon
{
	public class ByteArraySlice : IDisposable
	{
		public byte[] Buffer;

		public int Offset;

		public int Count;

		private readonly ByteArraySlicePool returnPool;

		private readonly int stackIndex;

		internal ByteArraySlice(ByteArraySlicePool returnPool, int stackIndex)
		{
			Buffer = ((stackIndex == 0) ? null : new byte[1 << stackIndex]);
			this.returnPool = returnPool;
			this.stackIndex = stackIndex;
		}

		public ByteArraySlice(byte[] buffer, int offset = 0, int count = 0)
		{
			Buffer = buffer;
			Count = count;
			Offset = offset;
			returnPool = null;
			stackIndex = -1;
		}

		public ByteArraySlice()
		{
			returnPool = null;
			stackIndex = -1;
		}

		public void Dispose()
		{
			Release();
		}

		public bool Release()
		{
			if (stackIndex < 0)
			{
				return false;
			}
			Count = 0;
			Offset = 0;
			return returnPool.Release(this, stackIndex);
		}

		public void Reset()
		{
			Count = 0;
			Offset = 0;
		}
	}
	public class ByteArraySlicePool
	{
		private int minStackIndex = 7;

		internal readonly Stack<ByteArraySlice>[] poolTiers = new Stack<ByteArraySlice>[32];

		private int allocationCounter;

		public int MinStackIndex
		{
			get
			{
				return minStackIndex;
			}
			set
			{
				minStackIndex = ((value <= 0) ? 1 : ((value < 31) ? value : 31));
			}
		}

		public int AllocationCounter => allocationCounter;

		public ByteArraySlicePool()
		{
			lock (poolTiers)
			{
				poolTiers[0] = new Stack<ByteArraySlice>();
			}
		}

		public ByteArraySlice Acquire(byte[] buffer, int offset = 0, int count = 0)
		{
			ByteArraySlice byteArraySlice;
			lock (poolTiers)
			{
				lock (poolTiers[0])
				{
					byteArraySlice = PopOrCreate(poolTiers[0], 0);
				}
			}
			byteArraySlice.Buffer = buffer;
			byteArraySlice.Offset = offset;
			byteArraySlice.Count = count;
			return byteArraySlice;
		}

		public ByteArraySlice Acquire(int minByteCount)
		{
			if (minByteCount < 0)
			{
				throw new Exception(typeof(ByteArraySlice).Name + " requires a positive minByteCount.");
			}
			int i = minStackIndex;
			if (minByteCount > 0)
			{
				for (int num = minByteCount - 1; i < 32 && num >> i != 0; i++)
				{
				}
			}
			lock (poolTiers)
			{
				Stack<ByteArraySlice> stack = poolTiers[i];
				if (stack == null)
				{
					stack = new Stack<ByteArraySlice>();
					poolTiers[i] = stack;
				}
				lock (stack)
				{
					return PopOrCreate(stack, i);
				}
			}
		}

		private ByteArraySlice PopOrCreate(Stack<ByteArraySlice> stack, int stackIndex)
		{
			lock (stack)
			{
				if (stack.Count > 0)
				{
					return stack.Pop();
				}
			}
			ByteArraySlice result = new ByteArraySlice(this, stackIndex);
			allocationCounter++;
			return result;
		}

		internal bool Release(ByteArraySlice slice, int stackIndex)
		{
			if (slice == null || stackIndex < 0)
			{
				return false;
			}
			if (stackIndex == 0)
			{
				slice.Buffer = null;
			}
			lock (poolTiers)
			{
				lock (poolTiers[stackIndex])
				{
					poolTiers[stackIndex].Push(slice);
				}
			}
			return true;
		}

		public void ClearPools(int lower = 0, int upper = int.MaxValue)
		{
			int num = minStackIndex;
			for (int i = 0; i < 32; i++)
			{
				int num2 = 1 << i;
				if (num2 < lower || num2 > upper)
				{
					continue;
				}
				lock (poolTiers)
				{
					if (poolTiers[i] != null)
					{
						lock (poolTiers[i])
						{
							poolTiers[i].Clear();
						}
					}
				}
			}
		}
	}
	public class NonAllocDictionary<K, V> : IDictionary<K, V>, ICollection<KeyValuePair<K, V>>, IEnumerable<KeyValuePair<K, V>>, IEnumerable where K : IEquatable<K>
	{
		public struct KeyIterator(NonAllocDictionary<K, V> dictionary) : IEnumerator<K>, IEnumerator, IDisposable
		{
			private int _index = 0;

			private NonAllocDictionary<K, V> _dict = dictionary;

			object IEnumerator.Current
			{
				get
				{
					if (_index == 0)
					{
						throw new InvalidOperationException();
					}
					return _dict._nodes[_index].Key;
				}
			}

			public K Current
			{
				get
				{
					if (_index == 0)
					{
						return default(K);
					}
					return _dict._nodes[_index].Key;
				}
			}

			public KeyIterator GetEnumerator()
			{
				return this;
			}

			public void Reset()
			{
				_index = 0;
			}

			public bool MoveNext()
			{
				while (++_index < _dict._usedCount)
				{
					if (_dict._nodes[_index].Used)
					{
						return true;
					}
				}
				_index = 0;
				return false;
			}

			public void Dispose()
			{
			}
		}

		public struct ValueIterator(NonAllocDictionary<K, V> dictionary) : IEnumerator<V>, IEnumerator, IDisposable
		{
			private int _index = 0;

			private NonAllocDictionary<K, V> _dict = dictionary;

			public V Current
			{
				get
				{
					if (_index == 0)
					{
						return default(V);
					}
					return _dict._nodes[_index].Val;
				}
			}

			object IEnumerator.Current
			{
				get
				{
					if (_index == 0)
					{
						throw new InvalidOperationException();
					}
					return _dict._nodes[_index].Val;
				}
			}

			public ValueIterator GetEnumerator()
			{
				return this;
			}

			public void Reset()
			{
				_index = 0;
			}

			public bool MoveNext()
			{
				while (++_index < _dict._usedCount)
				{
					if (_dict._nodes[_index].Used)
					{
						return true;
					}
				}
				_index = 0;
				return false;
			}

			public void Dispose()
			{
			}
		}

		public struct PairIterator(NonAllocDictionary<K, V> dictionary) : IEnumerator<KeyValuePair<K, V>>, IEnumerator, IDisposable
		{
			private int _index = 0;

			private NonAllocDictionary<K, V> _dict = dictionary;

			object IEnumerator.Current
			{
				get
				{
					if (_index == 0)
					{
						throw new InvalidOperationException();
					}
					return Current;
				}
			}

			public KeyValuePair<K, V> Current
			{
				get
				{
					if (_index == 0)
					{
						return default(KeyValuePair<K, V>);
					}
					return new KeyValuePair<K, V>(_dict._nodes[_index].Key, _dict._nodes[_index].Val);
				}
			}

			public void Reset()
			{
				_index = 0;
			}

			public bool MoveNext()
			{
				while (++_index < _dict._usedCount)
				{
					if (_dict._nodes[_index].Used)
					{
						return true;
					}
				}
				_index = 0;
				return false;
			}

			public void Dispose()
			{
			}
		}

		private struct Node
		{
			public bool Used;

			public int Next;

			public uint Hash;

			public K Key;

			public V Val;
		}

		private static uint[] _primeTableUInt = new uint[30]
		{
			3u, 7u, 17u, 29u, 53u, 97u, 193u, 389u, 769u, 1543u,
			3079u, 6151u, 12289u, 24593u, 49157u, 98317u, 196613u, 393241u, 786433u, 1572869u,
			3145739u, 6291469u, 12582917u, 25165843u, 50331653u, 100663319u, 201326611u, 402653189u, 805306457u, 1610612741u
		};

		private int _freeHead;

		private int _freeCount;

		private int _usedCount;

		private uint _capacity;

		private int[] _buckets;

		private Node[] _nodes;

		private bool isReadOnly;

		private ICollection<K> keys;

		private ICollection<V> values;

		public KeyIterator Keys => new KeyIterator(this);

		ICollection<V> IDictionary<K, V>.Values => values;

		ICollection<K> IDictionary<K, V>.Keys => keys;

		public ValueIterator Values => new ValueIterator(this);

		public int Count => _usedCount - _freeCount - 1;

		public bool IsReadOnly => isReadOnly;

		public uint Capacity => _capacity;

		public V this[K key]
		{
			get
			{
				int num = FindNode(key);
				if (num != 0)
				{
					return _nodes[num].Val;
				}
				K val = key;
				throw new InvalidOperationException("Key does not exist: " + val);
			}
			set
			{
				int num = FindNode(key);
				if (num == 0)
				{
					Insert(key, value);
					return;
				}
				Assert(_nodes[num].Key.Equals(key));
				_nodes[num].Val = value;
			}
		}

		public NonAllocDictionary(uint capacity = 29u)
		{
			_capacity = (IsPrimeFromList(capacity) ? capacity : GetNextPrime(capacity));
			_usedCount = 1;
			_buckets = new int[_capacity];
			_nodes = new Node[_capacity];
		}

		public bool ContainsKey(K key)
		{
			return FindNode(key) != 0;
		}

		public bool Contains(KeyValuePair<K, V> item)
		{
			int num = FindNode(item.Key);
			if (num >= 0 && EqualityComparer<V>.Default.Equals(_nodes[num].Val, item.Value))
			{
				return true;
			}
			return false;
		}

		public bool TryGetValue(K key, out V val)
		{
			int num = FindNode(key);
			if (num != 0)
			{
				val = _nodes[num].Val;
				return true;
			}
			val = default(V);
			return false;
		}

		public void Set(K key, V val)
		{
			int num = FindNode(key);
			if (num == 0)
			{
				Insert(key, val);
				return;
			}
			Assert(_nodes[num].Key.Equals(key));
			_nodes[num].Val = val;
		}

		public void Add(K key, V val)
		{
			if (FindNode(key) == 0)
			{
				Insert(key, val);
				return;
			}
			K val2 = key;
			throw new InvalidOperationException("Duplicate key " + val2);
		}

		public void Add(KeyValuePair<K, V> item)
		{
			if (FindNode(item.Key) == 0)
			{
				Insert(item.Key, item.Value);
				return;
			}
			throw new InvalidOperationException("Duplicate key " + item.Key);
		}

		public bool Remove(K key)
		{
			uint hashCode = (uint)key.GetHashCode();
			int num = _buckets[hashCode % _capacity];
			int num2 = 0;
			while (num != 0)
			{
				if (_nodes[num].Hash == hashCode)
				{
					ref K key2 = ref _nodes[num].Key;
					K other = key;
					if (key2.Equals(other))
					{
						if (num2 == 0)
						{
							_buckets[hashCode % _capacity] = _nodes[num].Next;
						}
						else
						{
							_nodes[num2].Next = _nodes[num].Next;
						}
						_nodes[num].Used = false;
						_nodes[num].Next = _freeHead;
						_nodes[num].Val = default(V);
						_freeHead = num;
						_freeCount++;
						return true;
					}
				}
				num2 = num;
				num = _nodes[num].Next;
			}
			return false;
		}

		public bool Remove(KeyValuePair<K, V> item)
		{
			if (Contains(item))
			{
				return Remove(item.Key);
			}
			return false;
		}

		IEnumerator<KeyValuePair<K, V>> IEnumerable<KeyValuePair<K, V>>.GetEnumerator()
		{
			return new PairIterator(this);
		}

		public PairIterator GetEnumerator()
		{
			return new PairIterator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new PairIterator(this);
		}

		private int FindNode(K key)
		{
			uint hashCode = (uint)key.GetHashCode();
			for (int num = _buckets[hashCode % _capacity]; num != 0; num = _nodes[num].Next)
			{
				if (_nodes[num].Hash == hashCode)
				{
					ref K key2 = ref _nodes[num].Key;
					K other = key;
					if (key2.Equals(other))
					{
						return num;
					}
				}
			}
			return 0;
		}

		private void Insert(K key, V val)
		{
			int num = 0;
			if (_freeCount > 0)
			{
				num = _freeHead;
				_freeHead = _nodes[num].Next;
				_freeCount--;
			}
			else
			{
				if (_usedCount == _capacity)
				{
					Expand();
				}
				num = _usedCount++;
			}
			uint hashCode = (uint)key.GetHashCode();
			uint num2 = hashCode % _capacity;
			_nodes[num].Used = true;
			_nodes[num].Hash = hashCode;
			_nodes[num].Next = _buckets[num2];
			_nodes[num].Key = key;
			_nodes[num].Val = val;
			_buckets[num2] = num;
		}

		private void Expand()
		{
			Assert(_buckets.Length == _usedCount);
			uint nextPrime = GetNextPrime(_capacity);
			Assert(nextPrime > _capacity);
			int[] array = new int[nextPrime];
			Node[] array2 = new Node[nextPrime];
			Array.Copy(_nodes, 0, array2, 0, _nodes.Length);
			for (int i = 1; i < _nodes.Length; i++)
			{
				Assert(array2[i].Used);
				uint num = array2[i].Hash % nextPrime;
				array2[i].Next = array[num];
				array[num] = i;
			}
			_nodes = array2;
			_buckets = array;
			_capacity = nextPrime;
		}

		public void Clear()
		{
			if (_usedCount > 1)
			{
				Array.Clear(_nodes, 0, _nodes.Length);
				Array.Clear(_buckets, 0, _buckets.Length);
				_freeHead = 0;
				_freeCount = 0;
				_usedCount = 1;
			}
		}

		void ICollection<KeyValuePair<K, V>>.CopyTo(KeyValuePair<K, V>[] array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (index < 0 || index > array.Length)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (array.Length - index < Count)
			{
				throw new ArgumentException("Array plus offset are too small to fit all items in.");
			}
			for (int i = 1; i < _nodes.Length; i++)
			{
				if (_nodes[i].Used)
				{
					array[index++] = new KeyValuePair<K, V>(_nodes[i].Key, _nodes[i].Val);
				}
			}
		}

		private static bool IsPrimeFromList(uint value)
		{
			for (int i = 0; i < _primeTableUInt.Length; i++)
			{
				if (_primeTableUInt[i] == value)
				{
					return true;
				}
			}
			return false;
		}

		private static uint GetNextPrime(uint value)
		{
			for (int i = 0; i < _primeTableUInt.Length; i++)
			{
				if (_primeTableUInt[i] > value)
				{
					return _primeTableUInt[i];
				}
			}
			throw new InvalidOperationException("NonAllocDictionary can't get larger than" + _primeTableUInt[_primeTableUInt.Length - 1]);
		}

		private static void Assert(bool condition)
		{
			if (!condition)
			{
				throw new InvalidOperationException("Assert Failed");
			}
		}
	}
	public class Hashtable : Dictionary<object, object>
	{
		internal static readonly object[] boxedByte;

		public new object this[object key]
		{
			get
			{
				object value = null;
				TryGetValue(key, out value);
				return value;
			}
			set
			{
				base[key] = value;
			}
		}

		public object this[byte key]
		{
			get
			{
				object value = null;
				TryGetValue(boxedByte[key], out value);
				return value;
			}
			set
			{
				base[boxedByte[key]] = value;
			}
		}

		public static object GetBoxedByte(byte value)
		{
			return boxedByte[value];
		}

		static Hashtable()
		{
			int num = 256;
			boxedByte = new object[num];
			for (int i = 0; i < num; i++)
			{
				boxedByte[i] = (byte)i;
			}
		}

		public Hashtable()
		{
		}

		public Hashtable(int x)
			: base(x)
		{
		}

		public void Add(byte k, object v)
		{
			Add(boxedByte[k], v);
		}

		public void Remove(byte k)
		{
			Remove(boxedByte[k]);
		}

		public bool ContainsKey(byte key)
		{
			return ContainsKey(boxedByte[key]);
		}

		public new DictionaryEntryEnumerator GetEnumerator()
		{
			return new DictionaryEntryEnumerator(base.GetEnumerator());
		}

		public override string ToString()
		{
			List<string> list = new List<string>();
			foreach (object key in base.Keys)
			{
				if (key == null || this[key] == null)
				{
					list.Add(key?.ToString() + "=" + this[key]);
					continue;
				}
				list.Add("(" + key.GetType()?.ToString() + ")" + key?.ToString() + "=(" + this[key].GetType()?.ToString() + ")" + this[key]);
			}
			return string.Join(", ", list.ToArray());
		}

		public object Clone()
		{
			return new Dictionary<object, object>(this);
		}
	}
	public struct DictionaryEntryEnumerator(Dictionary<object, object>.Enumerator original) : IEnumerator<DictionaryEntry>, IEnumerator, IDisposable
	{
		private Dictionary<object, object>.Enumerator enumerator = original;

		object IEnumerator.Current => new DictionaryEntry(enumerator.Current.Key, enumerator.Current.Value);

		public DictionaryEntry Current => new DictionaryEntry(enumerator.Current.Key, enumerator.Current.Value);

		public object Key => enumerator.Current.Key;

		public object Value => enumerator.Current.Value;

		public bool MoveNext()
		{
			return enumerator.MoveNext();
		}

		public void Reset()
		{
			((IEnumerator)enumerator).Reset();
		}

		public void Dispose()
		{
		}
	}
	public class UnknownType
	{
		public byte TypeCode;

		public int Size;

		public byte[] Data;
	}
	internal class EnetChannel
	{
		internal byte ChannelNumber;

		internal NonAllocDictionary<int, NCommand> incomingReliableCommandsList;

		internal NonAllocDictionary<int, NCommand> incomingUnreliableCommandsList;

		internal Queue<NCommand> incomingUnsequencedCommandsList;

		internal NonAllocDictionary<int, NCommand> incomingUnsequencedFragments;

		internal Queue<NCommand> outgoingReliableCommandsList;

		internal Queue<NCommand> outgoingUnreliableCommandsList;

		internal int incomingReliableSequenceNumber;

		internal int incomingUnreliableSequenceNumber;

		internal int outgoingReliableSequenceNumber;

		internal int outgoingUnreliableSequenceNumber;

		internal int outgoingReliableUnsequencedNumber;

		private int reliableUnsequencedNumbersCompletelyReceived;

		private HashSet<int> reliableUnsequencedNumbersReceived = new HashSet<int>();

		internal int highestReceivedAck;

		internal int reliableCommandsInFlight;

		internal int lowestUnacknowledgedSequenceNumber;

		public EnetChannel(byte channelNumber, int commandBufferSize)
		{
			ChannelNumber = channelNumber;
			incomingReliableCommandsList = new NonAllocDictionary<int, NCommand>((uint)commandBufferSize);
			incomingUnreliableCommandsList = new NonAllocDictionary<int, NCommand>((uint)commandBufferSize);
			incomingUnsequencedCommandsList = new Queue<NCommand>();
			incomingUnsequencedFragments = new NonAllocDictionary<int, NCommand>();
			outgoingReliableCommandsList = new Queue<NCommand>(commandBufferSize);
			outgoingUnreliableCommandsList = new Queue<NCommand>(commandBufferSize);
		}

		public bool ContainsUnreliableSequenceNumber(int unreliableSequenceNumber)
		{
			return incomingUnreliableCommandsList.ContainsKey(unreliableSequenceNumber);
		}

		public NCommand FetchUnreliableSequenceNumber(int unreliableSequenceNumber)
		{
			return incomingUnreliableCommandsList[unreliableSequenceNumber];
		}

		public bool ContainsReliableSequenceNumber(int reliableSequenceNumber)
		{
			return incomingReliableCommandsList.ContainsKey(reliableSequenceNumber);
		}

		public NCommand FetchReliableSequenceNumber(int reliableSequenceNumber)
		{
			return incomingReliableCommandsList[reliableSequenceNumber];
		}

		public bool TryGetFragment(int reliableSequenceNumber, bool isSequenced, out NCommand fragment)
		{
			if (isSequenced)
			{
				return incomingReliableCommandsList.TryGetValue(reliableSequenceNumber, out fragment);
			}
			return incomingUnsequencedFragments.TryGetValue(reliableSequenceNumber, out fragment);
		}

		public void RemoveFragment(int reliableSequenceNumber, bool isSequenced)
		{
			if (isSequenced)
			{
				incomingReliableCommandsList.Remove(reliableSequenceNumber);
			}
			else
			{
				incomingUnsequencedFragments.Remove(reliableSequenceNumber);
			}
		}

		public void clearAll()
		{
			lock (this)
			{
				incomingReliableCommandsList.Clear();
				incomingUnreliableCommandsList.Clear();
				incomingUnsequencedCommandsList.Clear();
				incomingUnsequencedFragments.Clear();
				outgoingReliableCommandsList.Clear();
				outgoingUnreliableCommandsList.Clear();
			}
		}

		public bool QueueIncomingReliableUnsequenced(NCommand command)
		{
			if (command.reliableSequenceNumber <= reliableUnsequencedNumbersCompletelyReceived)
			{
				return false;
			}
			if (reliableUnsequencedNumbersReceived.Contains(command.reliableSequenceNumber))
			{
				return false;
			}
			if (command.reliableSequenceNumber == reliableUnsequencedNumbersCompletelyReceived + 1)
			{
				reliableUnsequencedNumbersCompletelyReceived++;
			}
			else
			{
				reliableUnsequencedNumbersReceived.Add(command.reliableSequenceNumber);
			}
			while (reliableUnsequencedNumbersReceived.Contains(reliableUnsequencedNumbersCompletelyReceived + 1))
			{
				reliableUnsequencedNumbersCompletelyReceived++;
				reliableUnsequencedNumbersReceived.Remove(reliableUnsequencedNumbersCompletelyReceived);
			}
			if (command.commandType == 15)
			{
				incomingUnsequencedFragments.Add(command.reliableSequenceNumber, command);
			}
			else
			{
				incomingUnsequencedCommandsList.Enqueue(command);
			}
			return true;
		}
	}
	internal class EnetPeer : PeerBase
	{
		private const int CRC_LENGTH = 4;

		private const int EncryptedDataGramHeaderSize = 7;

		private const int EncryptedHeaderSize = 5;

		private const int QUICK_RESEND_QUEUELIMIT = 25;

		internal NCommandPool nCommandPool = new NCommandPool();

		private List<NCommand> sentReliableCommands = new List<NCommand>();

		private int sendWindowUpdateRequiredBackValue = 0;

		private StreamBuffer outgoingAcknowledgementsPool;

		internal const int UnsequencedWindowSize = 128;

		internal readonly int[] unsequencedWindow = new int[4];

		internal int outgoingUnsequencedGroupNumber;

		internal int incomingUnsequencedGroupNumber;

		private byte udpCommandCount;

		private byte[] udpBuffer;

		private int udpBufferIndex;

		private byte[] bufferForEncryption;

		private int commandBufferSize = 100;

		internal int challenge;

		internal int reliableCommandsRepeated;

		internal int reliableCommandsSent;

		internal int serverSentTime;

		internal static readonly byte[] udpHeader0xF3 = new byte[2] { 243, 2 };

		protected bool datagramEncryptedConnection;

		private EnetChannel[] channelArray = new EnetChannel[0];

		private const byte ControlChannelNumber = byte.MaxValue;

		protected internal const short PeerIdForConnect = -1;

		protected internal const short PeerIdForConnectTrace = -2;

		private Queue<int> commandsToRemove = new Queue<int>();

		private int fragmentLength = 0;

		private int fragmentLengthDatagramEncrypt = 0;

		private int fragmentLengthMtuValue = 0;

		private Queue<NCommand> CommandQueue = new Queue<NCommand>();

		private readonly HashSet<byte> channelsToUpdateLowestSent = new HashSet<byte>();

		private int[] lowestSentSequenceNumber;

		internal override int QueuedIncomingCommandsCount
		{
			get
			{
				int num = 0;
				lock (channelArray)
				{
					for (int i = 0; i < channelArray.Length; i++)
					{
						EnetChannel enetChannel = channelArray[i];
						num += enetChannel.incomingReliableCommandsList.Count;
						num += enetChannel.incomingUnreliableCommandsList.Count;
					}
				}
				return num;
			}
		}

		internal override int QueuedOutgoingCommandsCount
		{
			get
			{
				int num = 0;
				lock (channelArray)
				{
					for (int i = 0; i < channelArray.Length; i++)
					{
						EnetChannel enetChannel = channelArray[i];
						lock (enetChannel)
						{
							num += enetChannel.outgoingReliableCommandsList.Count;
							num += enetChannel.outgoingUnreliableCommandsList.Count;
						}
					}
				}
				return num;
			}
		}

		internal override int SentReliableCommandsCount => sentReliableCommands.Count;

		private bool sendWindowUpdateRequired
		{
			get
			{
				return Interlocked.CompareExchange(ref sendWindowUpdateRequiredBackValue, 1, 1) == 1;
			}
			set
			{
				if (value)
				{
					Interlocked.CompareExchange(ref sendWindowUpdateRequiredBackValue, 1, 0);
				}
				else
				{
					Interlocked.CompareExchange(ref sendWindowUpdateRequiredBackValue, 0, 1);
				}
			}
		}

		internal EnetPeer()
		{
			TrafficPackageHeaderSize = 12;
			messageHeader = udpHeader0xF3;
		}

		internal override bool IsTransportEncrypted()
		{
			return datagramEncryptedConnection;
		}

		internal override void Reset()
		{
			base.Reset();
			if (photonPeer.PayloadEncryptionSecret != null && usedTransportProtocol == ConnectionProtocol.Udp)
			{
				InitEncryption(photonPeer.PayloadEncryptionSecret);
			}
			if (photonPeer.Encryptor != null)
			{
				isEncryptionAvailable = true;
			}
			peerID = (short)(photonPeer.EnableServerTracing ? (-2) : (-1));
			challenge = SupportClass.ThreadSafeRandom.Next();
			if (udpBuffer == null || udpBuffer.Length != base.mtu)
			{
				udpBuffer = new byte[base.mtu];
			}
			reliableCommandsSent = 0;
			reliableCommandsRepeated = 0;
			timeoutInt = 0;
			outgoingUnsequencedGroupNumber = 0;
			incomingUnsequencedGroupNumber = 0;
			for (int i = 0; i < unsequencedWindow.Length; i++)
			{
				unsequencedWindow[i] = 0;
			}
			lock (channelArray)
			{
				EnetChannel[] array = channelArray;
				if (array.Length != base.ChannelCount + 1)
				{
					array = new EnetChannel[base.ChannelCount + 1];
				}
				for (byte b = 0; b < base.ChannelCount; b++)
				{
					array[b] = new EnetChannel(b, commandBufferSize);
				}
				array[base.ChannelCount] = new EnetChannel(byte.MaxValue, commandBufferSize);
				channelArray = array;
			}
			lock (sentReliableCommands)
			{
				sentReliableCommands.Clear();
			}
			outgoingAcknowledgementsPool = new StreamBuffer();
		}

		internal void ApplyRandomizedSequenceNumbers()
		{
			if (!photonPeer.RandomizeSequenceNumbers)
			{
				return;
			}
			lock (channelArray)
			{
				for (int i = 0; i < channelArray.Length; i++)
				{
					EnetChannel enetChannel = channelArray[i];
					int num = photonPeer.RandomizedSequenceNumbers[i % photonPeer.RandomizedSequenceNumbers.Length];
					if (photonPeer.GcmDatagramEncryption)
					{
						enetChannel.incomingReliableSequenceNumber += num;
						enetChannel.outgoingReliableSequenceNumber += num;
						enetChannel.highestReceivedAck += num;
						enetChannel.outgoingReliableUnsequencedNumber += num;
					}
					else
					{
						enetChannel.incomingReliableSequenceNumber = num;
						enetChannel.outgoingReliableSequenceNumber = num;
						enetChannel.highestReceivedAck = num;
						enetChannel.outgoingReliableUnsequencedNumber = num;
					}
				}
			}
		}

		private EnetChannel GetChannel(byte channelNumber)
		{
			return (channelNumber == byte.MaxValue) ? channelArray[channelArray.Length - 1] : channelArray[channelNumber];
		}

		internal override bool Connect(string ipport, string proxyServerAddress, string appID, object photonToken)
		{
			if (PhotonSocket.Connect())
			{
				if (base.TrafficStatsEnabled)
				{
					base.TrafficStatsOutgoing.ControlCommandBytes += 44;
					base.TrafficStatsOutgoing.ControlCommandCount++;
				}
				peerConnectionState = ConnectionStateValue.Connecting;
				return true;
			}
			return false;
		}

		public override void OnConnect()
		{
			QueueOutgoingReliableCommand(nCommandPool.Acquire(this, 2, null, byte.MaxValue));
		}

		internal override void Disconnect()
		{
			if (peerConnectionState == ConnectionStateValue.Disconnected || peerConnectionState == ConnectionStateValue.Disconnecting)
			{
				return;
			}
			if (sentReliableCommands != null)
			{
				lock (sentReliableCommands)
				{
					sentReliableCommands.Clear();
				}
			}
			lock (channelArray)
			{
				EnetChannel[] array = channelArray;
				foreach (EnetChannel enetChannel in array)
				{
					enetChannel.clearAll();
				}
			}
			bool isSimulationEnabled = base.NetworkSimulationSettings.IsSimulationEnabled;
			base.NetworkSimulationSettings.IsSimulationEnabled = false;
			NCommand nCommand = nCommandPool.Acquire(this, 4, null, byte.MaxValue);
			peerConnectionState = ConnectionStateValue.Disconnecting;
			QueueOutgoingReliableCommand(nCommand);
			SendOutgoingCommands();
			if (base.TrafficStatsEnabled)
			{
				base.TrafficStatsOutgoing.CountControlCommand(nCommand.Size);
			}
			base.NetworkSimulationSettings.IsSimulationEnabled = isSimulationEnabled;
			PhotonSocket.Disconnect();
			peerConnectionState = ConnectionStateValue.Disconnected;
			EnqueueStatusCallback(StatusCode.Disconnect);
			lock (udpBuffer)
			{
				datagramEncryptedConnection = false;
			}
		}

		internal override void StopConnection()
		{
			if (PhotonSocket != null)
			{
				PhotonSocket.Disconnect();
			}
			peerConnectionState = ConnectionStateValue.Disconnected;
			if (base.Listener != null)
			{
				base.Listener.OnStatusChanged(StatusCode.Disconnect);
			}
		}

		internal override void FetchServerTimestamp()
		{
			if (peerConnectionState != ConnectionStateValue.Connected || !ApplicationIsInitialized)
			{
				if ((int)base.debugOut >= 3)
				{
					EnqueueDebugReturn(DebugLevel.INFO, "FetchServerTimestamp() was skipped, as the client is not connected. Current ConnectionState: " + peerConnectionState);
				}
			}
			else
			{
				CreateAndEnqueueCommand(12, null, byte.MaxValue);
			}
		}

		internal override bool DispatchIncomingCommands()
		{
			int count = CommandQueue.Count;
			if (count > 0)
			{
				for (int i = 0; i < count; i++)
				{
					lock (CommandQueue)
					{
						NCommand command = CommandQueue.Dequeue();
						ExecuteCommand(command);
					}
				}
			}
			while (true)
			{
				MyAction myAction;
				lock (ActionQueue)
				{
					if (ActionQueue.Count <= 0)
					{
						break;
					}
					myAction = ActionQueue.Dequeue();
					goto IL_00ba;
				}
				IL_00ba:
				myAction();
			}
			NCommand val = null;
			lock (channelArray)
			{
				for (int j = 0; j < channelArray.Length; j++)
				{
					EnetChannel enetChannel = channelArray[j];
					if (enetChannel.incomingUnsequencedCommandsList.Count > 0)
					{
						val = enetChannel.incomingUnsequencedCommandsList.Dequeue();
						break;
					}
					if (enetChannel.incomingUnreliableCommandsList.Count > 0)
					{
						int num = int.MaxValue;
						foreach (int key2 in enetChannel.incomingUnreliableCommandsList.Keys)
						{
							NCommand nCommand = enetChannel.incomingUnreliableCommandsList[key2];
							if (key2 < enetChannel.incomingUnreliableSequenceNumber || nCommand.reliableSequenceNumber < enetChannel.incomingReliableSequenceNumber)
							{
								photonPeer.CountDiscarded++;
								commandsToRemove.Enqueue(key2);
							}
							else if (key2 < num && nCommand.reliableSequenceNumber <= enetChannel.incomingReliableSequenceNumber)
							{
								num = key2;
							}
						}
						NonAllocDictionary<int, NCommand> incomingUnreliableCommandsList = enetChannel.incomingUnreliableCommandsList;
						while (commandsToRemove.Count > 0)
						{
							int key = commandsToRemove.Dequeue();
							NCommand nCommand2 = incomingUnreliableCommandsList[key];
							incomingUnreliableCommandsList.Remove(key);
							nCommand2.FreePayload();
							nCommand2.Release();
						}
						if (num < int.MaxValue)
						{
							photonPeer.DeltaUnreliableNumber = num - enetChannel.incomingUnreliableSequenceNumber;
							val = enetChannel.incomingUnreliableCommandsList[num];
						}
						if (val != null)
						{
							enetChannel.incomingUnreliableCommandsList.Remove(val.unreliableSequenceNumber);
							enetChannel.incomingUnreliableSequenceNumber = val.unreliableSequenceNumber;
							break;
						}
					}
					if (val != null || enetChannel.incomingReliableCommandsList.Count <= 0)
					{
						continue;
					}
					enetChannel.incomingReliableCommandsList.TryGetValue(enetChannel.incomingReliableSequenceNumber + 1, out val);
					if (val != null)
					{
						if (val.commandType != 8)
						{
							enetChannel.incomingReliableSequenceNumber = val.reliableSequenceNumber;
							enetChannel.incomingReliableCommandsList.Remove(val.reliableSequenceNumber);
						}
						else if (val.fragmentsRemaining > 0)
						{
							val = null;
						}
						else
						{
							enetChannel.incomingReliableSequenceNumber = val.reliableSequenceNumber + val.fragmentCount - 1;
							enetChannel.incomingReliableCommandsList.Remove(val.reliableSequenceNumber);
						}
						break;
					}
				}
			}
			if (val != null && val.Payload != null)
			{
				ByteCountCurrentDispatch = val.Size;
				CommandInCurrentDispatch = val;
				bool flag = DeserializeMessageAndCallback(val.Payload);
				CommandInCurrentDispatch = null;
				val.FreePayload();
				val.Release();
				return true;
			}
			return false;
		}

		private int GetFragmentLength()
		{
			if (fragmentLength == 0 || base.mtu != fragmentLengthMtuValue)
			{
				fragmentLengthMtuValue = base.mtu;
				fragmentLength = base.mtu - 12 - 36;
				fragmentLengthDatagramEncrypt = ((photonPeer.Encryptor != null) ? photonPeer.Encryptor.CalculateFragmentLength() : 0);
			}
			return datagramEncryptedConnection ? fragmentLengthDatagramEncrypt : fragmentLength;
		}

		private int CalculatePacketSize(int inSize)
		{
			if (datagramEncryptedConnection)
			{
				return photonPeer.Encryptor.CalculateEncryptedSize(inSize + 7);
			}
			return inSize;
		}

		private int CalculateInitialOffset()
		{
			if (datagramEncryptedConnection)
			{
				return 5;
			}
			int num = 12;
			if (photonPeer.CrcEnabled)
			{
				num += 4;
			}
			return num;
		}

		internal override bool SendAcksOnly()
		{
			if (peerConnectionState == ConnectionStateValue.Disconnected)
			{
				return false;
			}
			if (PhotonSocket == null || !PhotonSocket.Connected)
			{
				return false;
			}
			lock (udpBuffer)
			{
				int num = 0;
				udpBufferIndex = CalculateInitialOffset();
				udpCommandCount = 0;
				lock (outgoingAcknowledgementsPool)
				{
					num = SerializeAckToBuffer();
					timeLastSendAck = base.timeInt;
				}
				if (base.timeInt > timeoutInt && sentReliableCommands.Count > 0)
				{
					int num2 = base.timeInt + 100;
					lock (sentReliableCommands)
					{
						int num3 = 0;
						for (int i = 0; i < sentReliableCommands.Count; i++)
						{
							NCommand nCommand = sentReliableCommands[i];
							int num4 = nCommand.commandSentTime + nCommand.roundTripTimeout;
							if (base.timeInt > num4)
							{
								bool flag = SerializeCommandToBuffer(nCommand, commandIsInSentQueue: true);
								if (flag)
								{
									if ((int)base.debugOut >= 5)
									{
										base.Listener.DebugReturn(DebugLevel.ALL, $"Resending: {nCommand}. now: {base.timeInt} rtt/var: {roundTripTime}/{roundTripTimeVariance} last recv: {base.timeInt - timestampOfLastReceive} didFit: {flag}");
									}
									reliableCommandsRepeated++;
								}
								else
								{
									num3++;
									num2 = timeoutInt;
									if (base.mtu - udpBufferIndex < 80)
									{
										break;
									}
								}
							}
							else if (num4 < num2)
							{
								num2 = num4;
							}
						}
						num += num3;
						timeoutInt = num2;
					}
				}
				if (udpCommandCount <= 0)
				{
					return false;
				}
				if (base.TrafficStatsEnabled)
				{
					base.TrafficStatsOutgoing.TotalPacketCount++;
					base.TrafficStatsOutgoing.TotalCommandsInPackets += udpCommandCount;
				}
				SendData(udpBuffer, udpBufferIndex);
				return num > 0;
			}
		}

		internal override bool SendOutgoingCommands()
		{
			if (peerConnectionState == ConnectionStateValue.Disconnected)
			{
				return false;
			}
			if (!PhotonSocket.Connected)
			{
				return false;
			}
			lock (udpBuffer)
			{
				int num = 0;
				udpBufferIndex = CalculateInitialOffset();
				udpCommandCount = 0;
				timeLastSendOutgoing = base.timeInt;
				lock (outgoingAcknowledgementsPool)
				{
					if (outgoingAcknowledgementsPool.Length > 0)
					{
						num = SerializeAckToBuffer();
						timeLastSendAck = base.timeInt;
					}
				}
				if (base.timeInt > timeoutInt && sentReliableCommands.Count > 0)
				{
					int num2 = base.timeInt + 100;
					lock (sentReliableCommands)
					{
						int num3 = 0;
						for (int i = 0; i < sentReliableCommands.Count; i++)
						{
							NCommand nCommand = sentReliableCommands[i];
							int num4 = nCommand.commandSentTime + nCommand.roundTripTimeout;
							if (base.timeInt > num4)
							{
								if (nCommand.commandSentCount > photonPeer.SentCountAllowance || base.timeInt > nCommand.timeoutTime)
								{
									if ((int)base.debugOut >= 2)
									{
										base.Listener.DebugReturn(DebugLevel.WARNING, $"Timeout-disconnect! Command: {nCommand} now: {base.timeInt} challenge: {Convert.ToString(challenge, 16)}");
										if ((int)base.debugOut >= 3)
										{
											base.Listener.DebugReturn(DebugLevel.INFO, $"QueuedOutgoing: {QueuedOutgoingCommandsCount} channel.LowestUnAckd: {GetChannel(nCommand.commandChannelID).lowestUnacknowledgedSequenceNumber} sentReliableCommands: {sentReliableCommands.Count}");
										}
									}
									peerConnectionState = ConnectionStateValue.Zombie;
									EnqueueStatusCallback(StatusCode.TimeoutDisconnect);
									Disconnect();
									nCommand.Release();
									return false;
								}
								if (SerializeCommandToBuffer(nCommand, commandIsInSentQueue: true))
								{
									if ((int)base.debugOut >= 5)
									{
										base.Listener.DebugReturn(DebugLevel.ALL, $"Resending: {nCommand}. now: {base.timeInt} rtt/var: {roundTripTime}/{roundTripTimeVariance} last recv: {base.timeInt - timestampOfLastReceive}");
									}
									reliableCommandsRepeated++;
								}
								else
								{
									num3++;
									num2 = timeoutInt;
									if (base.mtu - udpBufferIndex < 80)
									{
										break;
									}
								}
							}
							else if (num4 < num2)
							{
								num2 = num4;
							}
						}
						num += num3;
						timeoutInt = num2;
					}
				}
				if (peerConnectionState == ConnectionStateValue.Connected && base.timePingInterval > 0 && sentReliableCommands.Count == 0 && base.timeInt - timeLastAckReceive > base.timePingInterval && CalculatePacketSize(udpBufferIndex + 12) <= base.mtu)
				{
					NCommand nCommand2 = nCommandPool.Acquire(this, 5, null, byte.MaxValue);
					QueueOutgoingReliableCommand(nCommand2);
					if (base.TrafficStatsEnabled)
					{
						base.TrafficStatsOutgoing.CountControlCommand(nCommand2.Size);
					}
				}
				if (sendWindowUpdateRequired)
				{
					UpdateSendWindow();
				}
				lock (channelArray)
				{
					for (int j = 0; j < channelArray.Length; j++)
					{
						EnetChannel enetChannel = channelArray[j];
						lock (enetChannel)
						{
							int channelSequenceLimit = enetChannel.lowestUnacknowledgedSequenceNumber + photonPeer.SendWindowSize;
							num += SerializeToBuffer(enetChannel.outgoingReliableCommandsList, channelSequenceLimit);
							num += SerializeToBuffer(enetChannel.outgoingUnreliableCommandsList, channelSequenceLimit);
						}
					}
				}
				if (udpCommandCount <= 0)
				{
					return false;
				}
				if (base.TrafficStatsEnabled)
				{
					base.TrafficStatsOutgoing.TotalPacketCount++;
					base.TrafficStatsOutgoing.TotalCommandsInPackets += udpCommandCount;
				}
				SendData(udpBuffer, udpBufferIndex);
				return num > 0;
			}
		}

		private void UpdateSendWindow()
		{
			sendWindowUpdateRequired = false;
			if (photonPeer.SendWindowSize <= 0)
			{
				return;
			}
			if (sentReliableCommands.Count == 0)
			{
				lock (channelArray)
				{
					for (int i = 0; i < channelArray.Length; i++)
					{
						EnetChannel enetChannel = channelArray[i];
						enetChannel.reliableCommandsInFlight = 0;
						enetChannel.lowestUnacknowledgedSequenceNumber = enetChannel.highestReceivedAck + 1;
					}
					return;
				}
			}
			channelsToUpdateLowestSent.Clear();
			lock (channelArray)
			{
				for (int j = 0; j < channelArray.Length; j++)
				{
					EnetChannel enetChannel2 = channelArray[j];
					if (enetChannel2.ChannelNumber != byte.MaxValue && enetChannel2.reliableCommandsInFlight > 0)
					{
						channelsToUpdateLowestSent.Add(enetChannel2.ChannelNumber);
					}
				}
			}
			if (lowestSentSequenceNumber == null || lowestSentSequenceNumber.Length != channelArray.Length)
			{
				lowestSentSequenceNumber = new int[channelArray.Length];
			}
			else
			{
				for (int k = 0; k < lowestSentSequenceNumber.Length; k++)
				{
					lowestSentSequenceNumber[k] = 0;
				}
			}
			lock (sentReliableCommands)
			{
				for (int l = 0; l < sentReliableCommands.Count; l++)
				{
					NCommand nCommand = sentReliableCommands[l];
					if (nCommand.IsFlaggedUnsequenced || nCommand.commandChannelID == byte.MaxValue)
					{
						continue;
					}
					int commandChannelID = nCommand.commandChannelID;
					if (channelsToUpdateLowestSent.Contains(nCommand.commandChannelID))
					{
						if (lowestSentSequenceNumber[commandChannelID] == 0)
						{
							lowestSentSequenceNumber[commandChannelID] = nCommand.reliableSequenceNumber;
						}
						channelsToUpdateLowestSent.Remove(nCommand.commandChannelID);
						if (channelsToUpdateLowestSent.Count == 0)
						{
							break;
						}
					}
				}
			}
			lock (channelArray)
			{
				for (int m = 0; m < channelArray.Length; m++)
				{
					EnetChannel enetChannel3 = channelArray[m];
					enetChannel3.lowestUnacknowledgedSequenceNumber = ((lowestSentSequenceNumber[m] > 0) ? lowestSentSequenceNumber[m] : (enetChannel3.highestReceivedAck + 1));
				}
			}
		}

		internal override bool EnqueuePhotonMessage(StreamBuffer opBytes, SendOptions sendParams)
		{
			byte commandType = 7;
			if (sendParams.DeliveryMode == DeliveryMode.UnreliableUnsequenced)
			{
				commandType = 11;
			}
			else if (sendParams.DeliveryMode == DeliveryMode.ReliableUnsequenced)
			{
				commandType = 14;
			}
			else if (sendParams.DeliveryMode == DeliveryMode.Reliable)
			{
				commandType = 6;
			}
			return CreateAndEnqueueCommand(commandType, opBytes, sendParams.Channel);
		}

		internal bool CreateAndEnqueueCommand(byte commandType, StreamBuffer payload, byte channelNumber)
		{
			EnetChannel channel = GetChannel(channelNumber);
			ByteCountLastOperation = 0;
			int num = GetFragmentLength();
			if (num == 0)
			{
				num = 1000;
				EnqueueDebugReturn(DebugLevel.WARNING, "Value of currentFragmentSize should not be 0. Corrected to 1000.");
			}
			if (payload == null || payload.Length <= num)
			{
				NCommand nCommand = nCommandPool.Acquire(this, commandType, payload, channel.ChannelNumber);
				if (nCommand.IsFlaggedReliable)
				{
					QueueOutgoingReliableCommand(nCommand);
					ByteCountLastOperation = nCommand.Size;
					if (base.TrafficStatsEnabled)
					{
						base.TrafficStatsOutgoing.CountReliableOpCommand(nCommand.Size);
						base.TrafficStatsGameLevel.CountOperation(nCommand.Size);
					}
				}
				else
				{
					QueueOutgoingUnreliableCommand(nCommand);
					ByteCountLastOperation = nCommand.Size;
					if (base.TrafficStatsEnabled)
					{
						base.TrafficStatsOutgoing.CountUnreliableOpCommand(nCommand.Size);
						base.TrafficStatsGameLevel.CountOperation(nCommand.Size);
					}
				}
			}
			else
			{
				bool flag = commandType == 14 || commandType == 11;
				int fragmentCount = (payload.Length + num - 1) / num;
				int startSequenceNumber = (flag ? channel.outgoingReliableUnsequencedNumber : channel.outgoingReliableSequenceNumber) + 1;
				byte[] buffer = payload.GetBuffer();
				int num2 = 0;
				for (int i = 0; i < payload.Length; i += num)
				{
					if (payload.Length - i < num)
					{
						num = payload.Length - i;
					}
					StreamBuffer streamBuffer = PeerBase.MessageBufferPoolGet();
					streamBuffer.Write(buffer, i, num);
					NCommand nCommand2 = nCommandPool.Acquire(this, (byte)(flag ? 15 : 8), streamBuffer, channel.ChannelNumber);
					nCommand2.fragmentNumber = num2;
					nCommand2.startSequenceNumber = startSequenceNumber;
					nCommand2.fragmentCount = fragmentCount;
					nCommand2.totalLength = payload.Length;
					nCommand2.fragmentOffset = i;
					QueueOutgoingReliableCommand(nCommand2);
					ByteCountLastOperation += nCommand2.Size;
					if (base.TrafficStatsEnabled)
					{
						base.TrafficStatsOutgoing.CountFragmentOpCommand(nCommand2.Size);
						base.TrafficStatsGameLevel.CountOperation(nCommand2.Size);
					}
					num2++;
				}
				PeerBase.MessageBufferPoolPut(payload);
			}
			return true;
		}

		internal int SerializeAckToBuffer()
		{
			outgoingAcknowledgementsPool.Seek(0L, SeekOrigin.Begin);
			while (outgoingAcknowledgementsPool.Position + 20 <= outgoingAcknowledgementsPool.Length)
			{
				if (CalculatePacketSize(udpBufferIndex + 20) > base.mtu)
				{
					if ((int)base.debugOut >= 5)
					{
						base.Listener.DebugReturn(DebugLevel.ALL, "UDP package is full. Commands in Package: " + udpCommandCount + ". bytes left in queue: " + outgoingAcknowledgementsPool.Position);
					}
					break;
				}
				int offset;
				byte[] bufferAndAdvance = outgoingAcknowledgementsPool.GetBufferAndAdvance(20, out offset);
				Buffer.BlockCopy(bufferAndAdvance, offset, udpBuffer, udpBufferIndex, 20);
				udpBufferIndex += 20;
				udpCommandCount++;
			}
			outgoingAcknowledgementsPool.Compact();
			outgoingAcknowledgementsPool.Position = outgoingAcknowledgementsPool.Length;
			return outgoingAcknowledgementsPool.Length / 20;
		}

		internal int SerializeToBuffer(Queue<NCommand> commandList, int channelSequenceLimit)
		{
			while (commandList.Count > 0)
			{
				NCommand nCommand = commandList.Peek();
				if (nCommand == null)
				{
					commandList.Dequeue();
					continue;
				}
				if (nCommand.IsFlaggedReliable && nCommand.commandChannelID != byte.MaxValue && photonPeer.SendWindowSize > 0 && nCommand.reliableSequenceNumber >= channelSequenceLimit)
				{
					return 0;
				}
				if (SerializeCommandToBuffer(nCommand))
				{
					commandList.Dequeue();
					continue;
				}
				if ((int)base.debugOut >= 5)
				{
					base.Listener.DebugReturn(DebugLevel.ALL, "UDP package is full. Commands in Package: " + udpCommandCount + " commandList.Count: " + commandList.Count);
				}
				break;
			}
			return commandList.Count;
		}

		private bool SerializeCommandToBuffer(NCommand command, bool commandIsInSentQueue = false)
		{
			if (command == null)
			{
				return true;
			}
			if (CalculatePacketSize(udpBufferIndex + command.Size) > base.mtu)
			{
				return false;
			}
			command.SerializeHeader(udpBuffer, ref udpBufferIndex);
			if (command.SizeOfPayload > 0)
			{
				Buffer.BlockCopy(command.Serialize(), 0, udpBuffer, udpBufferIndex, command.SizeOfPayload);
				udpBufferIndex += command.SizeOfPayload;
			}
			udpCommandCount++;
			if (command.IsFlaggedReliable)
			{
				QueueSentCommand(command, commandIsInSentQueue);
			}
			else
			{
				command.FreePayload();
				command.Release();
			}
			return true;
		}

		internal void SendData(byte[] data, int length)
		{
			try
			{
				if (datagramEncryptedConnection)
				{
					SendDataEncrypted(data, length);
					return;
				}
				int targetOffset = 0;
				Protocol.Serialize(peerID, data, ref targetOffset);
				data[2] = (byte)(photonPeer.CrcEnabled ? 204 : 0);
				data[3] = udpCommandCount;
				targetOffset = 4;
				Protocol.Serialize(base.timeInt, data, ref targetOffset);
				Protocol.Serialize(challenge, data, ref targetOffset);
				if (photonPeer.CrcEnabled)
				{
					Protocol.Serialize(0, data, ref targetOffset);
					uint value = SupportClass.CalculateCrc(data, length);
					targetOffset -= 4;
					Protocol.Serialize((int)value, data, ref targetOffset);
				}
				SendToSocket(data, length);
			}
			catch (Exception ex)
			{
				if ((int)base.debugOut >= 1)
				{
					base.Listener.DebugReturn(DebugLevel.ERROR, ex.ToString());
				}
				SupportClass.WriteStackTrace(ex);
			}
		}

		private void SendToSocket(byte[] data, int length)
		{
			bytesOut += length;
			ITrafficRecorder trafficRecorder = photonPeer.TrafficRecorder;
			if (trafficRecorder != null && trafficRecorder.Enabled)
			{
				trafficRecorder.Record(data, length, incoming: false, peerID, PhotonSocket);
			}
			if (base.NetworkSimulationSettings.IsSimulationEnabled)
			{
				byte[] array = new byte[length];
				Buffer.BlockCopy(data, 0, array, 0, length);
				SendNetworkSimulated(array);
				return;
			}
			int num = base.timeInt;
			PhotonSocket.Send(data, length);
			int num2 = base.timeInt - num;
			if (num2 > longestSentCall)
			{
				longestSentCall = num2;
			}
		}

		private void SendDataEncrypted(byte[] data, int length)
		{
			if (bufferForEncryption == null || bufferForEncryption.Length != base.mtu)
			{
				bufferForEncryption = new byte[base.mtu];
			}
			byte[] array = bufferForEncryption;
			int targetOffset = 0;
			Protocol.Serialize(peerID, array, ref targetOffset);
			array[2] = 1;
			targetOffset++;
			Protocol.Serialize(challenge, array, ref targetOffset);
			data[0] = udpCommandCount;
			int targetOffset2 = 1;
			Protocol.Serialize(base.timeInt, data, ref targetOffset2);
			int outSize = array.Length - targetOffset;
			photonPeer.Encryptor.Encrypt2(data, length, array, array, targetOffset, ref outSize);
			SendToSocket(array, outSize + targetOffset);
		}

		internal void QueueSentCommand(NCommand command, bool commandIsAlreadyInSentQueue = false)
		{
			command.commandSentTime = base.timeInt;
			if (command.roundTripTimeout == 0)
			{
				command.roundTripTimeout = Math.Min(roundTripTime + 4 * roundTripTimeVariance, photonPeer.InitialResendTimeMax);
				command.timeoutTime = base.timeInt + base.DisconnectTimeout;
				reliableCommandsSent++;
			}
			else if (command.commandSentCount > photonPeer.QuickResendAttempts || sentReliableCommands.Count >= 25)
			{
				command.roundTripTimeout *= 2;
			}
			command.commandSentCount++;
			int num = command.commandSentTime + command.roundTripTimeout;
			if (num < timeoutInt)
			{
				timeoutInt = num;
			}
			if (!commandIsAlreadyInSentQueue)
			{
				EnetChannel channel = GetChannel(command.commandChannelID);
				channel.reliableCommandsInFlight++;
				lock (sentReliableCommands)
				{
					sentReliableCommands.Add(command);
				}
			}
		}

		internal void QueueOutgoingReliableCommand(NCommand command)
		{
			EnetChannel channel = GetChannel(command.commandChannelID);
			lock (channel)
			{
				if (command.reliableSequenceNumber == 0)
				{
					if (command.IsFlaggedUnsequenced)
					{
						command.reliableSequenceNumber = ++channel.outgoingReliableUnsequencedNumber;
					}
					else
					{
						command.reliableSequenceNumber = ++channel.outgoingReliableSequenceNumber;
					}
				}
				channel.outgoingReliableCommandsList.Enqueue(command);
			}
		}

		internal void QueueOutgoingUnreliableCommand(NCommand command)
		{
			EnetChannel channel = GetChannel(command.commandChannelID);
			lock (channel)
			{
				if (command.IsFlaggedUnsequenced)
				{
					command.reliableSequenceNumber = 0;
					command.unsequencedGroupNumber = ++outgoingUnsequencedGroupNumber;
				}
				else
				{
					command.reliableSequenceNumber = channel.outgoingReliableSequenceNumber;
					command.unreliableSequenceNumber = ++channel.outgoingUnreliableSequenceNumber;
				}
				if (!photonPeer.SendInCreationOrder)
				{
					channel.outgoingUnreliableCommandsList.Enqueue(command);
				}
				else
				{
					channel.outgoingReliableCommandsList.Enqueue(command);
				}
			}
		}

		internal void QueueOutgoingAcknowledgement(NCommand readCommand, int sendTime)
		{
			lock (outgoingAcknowledgementsPool)
			{
				int offset;
				byte[] bufferAndAdvance = outgoingAcknowledgementsPool.GetBufferAndAdvance(20, out offset);
				NCommand.CreateAck(bufferAndAdvance, offset, readCommand, sendTime);
			}
		}

		internal override void ReceiveIncomingCommands(byte[] inBuff, int inDataLength)
		{
			timestampOfLastReceive = base.timeInt;
			if (peerConnectionState == ConnectionStateValue.Disconnected)
			{
				return;
			}
			try
			{
				int offset = 0;
				Protocol.Deserialize(out short _, inBuff, ref offset);
				byte b = inBuff[offset++];
				int value2;
				byte b2;
				if (b == 1)
				{
					if (photonPeer.Encryptor == null)
					{
						return;
					}
					Protocol.Deserialize(out value2, inBuff, ref offset);
					if (value2 != challenge)
					{
						packetLossByChallenge++;
						return;
					}
					inBuff = photonPeer.Encryptor.Decrypt2(inBuff, offset, inDataLength - offset, inBuff, out var _);
					if (!datagramEncryptedConnection)
					{
						lock (udpBuffer)
						{
							datagramEncryptedConnection = true;
							fragmentLength = 0;
						}
					}
					offset = 0;
					b2 = inBuff[offset++];
					Protocol.Deserialize(out serverSentTime, inBuff, ref offset);
					bytesIn += inDataLength;
				}
				else
				{
					if (datagramEncryptedConnection)
					{
						if ((int)base.debugOut >= 2)
						{
							EnqueueDebugReturn(DebugLevel.WARNING, "Ignored received package. Connection requires Datagram Encryption but received unencrypted datagram.");
						}
						return;
					}
					b2 = inBuff[offset++];
					Protocol.Deserialize(out serverSentTime, inBuff, ref offset);
					Protocol.Deserialize(out value2, inBuff, ref offset);
					if (value2 != challenge)
					{
						packetLossByChallenge++;
						if (peerConnectionState != ConnectionStateValue.Disconnected && (int)base.debugOut >= 5)
						{
							EnqueueDebugReturn(DebugLevel.ALL, "Ignored received package due to wrong challenge. Received:" + value2 + " local: " + challenge);
						}
						return;
					}
					if (b == 204)
					{
						Protocol.Deserialize(out int value3, inBuff, ref offset);
						bytesIn += 4L;
						offset -= 4;
						Protocol.Serialize(0, inBuff, ref offset);
						uint num = SupportClass.CalculateCrc(inBuff, inDataLength);
						if (value3 != (int)num)
						{
							packetLossByCrc++;
							if (peerConnectionState != ConnectionStateValue.Disconnected && (int)base.debugOut >= 3)
							{
								EnqueueDebugReturn(DebugLevel.INFO, $"Ignored package due to wrong CRC. Incoming:  {(uint)value3:X} Local: {num:X}");
							}
							return;
						}
					}
					bytesIn += 12L;
				}
				if (base.TrafficStatsEnabled)
				{
					base.TrafficStatsIncoming.TotalPacketCount++;
					base.TrafficStatsIncoming.TotalCommandsInPackets += b2;
				}
				if (b2 > commandBufferSize || b2 <= 0)
				{
					EnqueueDebugReturn(DebugLevel.ERROR, "too many/few incoming commands in package: " + b2 + " > " + commandBufferSize);
				}
				bool flag = false;
				for (int i = 0; i < b2; i++)
				{
					NCommand nCommand = nCommandPool.Acquire(this, inBuff, ref offset);
					if (nCommand.commandType == 1 || nCommand.commandType == 16)
					{
						ExecuteCommand(nCommand);
						flag = true;
					}
					else
					{
						lock (CommandQueue)
						{
							CommandQueue.Enqueue(nCommand);
						}
					}
					if (nCommand.IsFlaggedReliable)
					{
						QueueOutgoingAcknowledgement(nCommand, serverSentTime);
						if (base.TrafficStatsEnabled)
						{
							base.TrafficStatsIncoming.TimestampOfLastReliableCommand = base.timeInt;
							base.TrafficStatsOutgoing.CountControlCommand(20);
						}
					}
				}
				if (flag)
				{
					sendWindowUpdateRequired = true;
				}
			}
			catch (Exception ex)
			{
				if ((int)base.debugOut >= 1)
				{
					EnqueueDebugReturn(DebugLevel.ERROR, $"Exception while reading commands from incoming data: {ex}");
				}
				SupportClass.WriteStackTrace(ex);
			}
		}

		internal void ExecuteCommand(NCommand command)
		{
			bool flag = false;
			switch (command.commandType)
			{
			case 2:
			case 5:
				if (base.TrafficStatsEnabled)
				{
					base.TrafficStatsIncoming.CountControlCommand(command.Size);
				}
				command.Release();
				break;
			case 4:
			{
				if (base.TrafficStatsEnabled)
				{
					base.TrafficStatsIncoming.CountControlCommand(command.Size);
				}
				StatusCode statusValue = StatusCode.DisconnectByServerReasonUnknown;
				if (command.reservedByte == 1)
				{
					statusValue = StatusCode.DisconnectByServerLogic;
				}
				else if (command.reservedByte == 2)
				{
					statusValue = StatusCode.DisconnectByServerTimeout;
				}
				else if (command.reservedByte == 3)
				{
					statusValue = StatusCode.DisconnectByServerUserLimit;
				}
				if ((int)base.debugOut >= 3)
				{
					base.Listener.DebugReturn(DebugLevel.INFO, "Server " + base.ServerAddress + " sent disconnect. PeerId: " + (ushort)peerID + " RTT/Variance:" + roundTripTime + "/" + roundTripTimeVariance + " reason byte: " + command.reservedByte + " peerConnectionState: " + peerConnectionState);
				}
				if (peerConnectionState != ConnectionStateValue.Disconnected && peerConnectionState != ConnectionStateValue.Disconnecting)
				{
					EnqueueStatusCallback(statusValue);
					Disconnect();
				}
				command.Release();
				break;
			}
			case 1:
			case 16:
			{
				if (base.TrafficStatsEnabled)
				{
					base.TrafficStatsIncoming.TimestampOfLastAck = base.timeInt;
					base.TrafficStatsIncoming.CountControlCommand(command.Size);
				}
				timeLastAckReceive = base.timeInt;
				lastRoundTripTime = base.timeInt - command.ackReceivedSentTime;
				if (lastRoundTripTime < 0 || lastRoundTripTime > 10000)
				{
					if ((int)base.debugOut >= 3)
					{
						EnqueueDebugReturn(DebugLevel.INFO, "Measured lastRoundtripTime is suspicious: " + lastRoundTripTime + " for command: " + command);
					}
					lastRoundTripTime = roundTripTime * 4;
				}
				NCommand nCommand = RemoveSentReliableCommand(command.ackReceivedReliableSequenceNumber, command.commandChannelID, command.commandType == 16);
				command.Release();
				if (nCommand == null)
				{
					break;
				}
				nCommand.FreePayload();
				EnetChannel channel2 = GetChannel(nCommand.commandChannelID);
				lock (channel2)
				{
					if (nCommand.reliableSequenceNumber > channel2.highestReceivedAck)
					{
						channel2.highestReceivedAck = nCommand.reliableSequenceNumber;
					}
					channel2.reliableCommandsInFlight--;
				}
				if (nCommand.commandType == 12)
				{
					if (lastRoundTripTime <= roundTripTime)
					{
						serverTimeOffset = serverSentTime + (lastRoundTripTime >> 1) - base.timeInt;
						serverTimeOffsetIsAvailable = true;
					}
					else
					{
						FetchServerTimestamp();
					}
				}
				else
				{
					UpdateRoundTripTimeAndVariance(lastRoundTripTime);
					if (nCommand.commandType == 4 && peerConnectionState == ConnectionStateValue.Disconnecting)
					{
						if ((int)base.debugOut >= 3)
						{
							EnqueueDebugReturn(DebugLevel.INFO, "Received ACK for previously sent Disconnect command.");
						}
						EnqueueActionForDispatch(delegate
						{
							PhotonSocket.Disconnect();
						});
					}
					else if (nCommand.commandType == 2 && lastRoundTripTime >= 0)
					{
						if (lastRoundTripTime <= 15)
						{
							roundTripTime = 15;
							roundTripTimeVariance = 5;
						}
						else
						{
							roundTripTime = lastRoundTripTime;
						}
					}
				}
				nCommand.Release();
				break;
			}
			case 6:
			case 7:
			case 11:
			case 14:
				if (base.TrafficStatsEnabled)
				{
					if (command.IsFlaggedReliable)
					{
						base.TrafficStatsIncoming.CountReliableOpCommand(command.Size);
					}
					else
					{
						base.TrafficStatsIncoming.CountUnreliableOpCommand(command.Size);
					}
				}
				if (peerConnectionState != ConnectionStateValue.Connected || !QueueIncomingCommand(command))
				{
					command.Release();
				}
				break;
			case 8:
			case 15:
			{
				if (peerConnectionState != ConnectionStateValue.Connected)
				{
					command.Release();
					break;
				}
				if (base.TrafficStatsEnabled)
				{
					base.TrafficStatsIncoming.CountFragmentOpCommand(command.Size);
				}
				if (command.fragmentNumber > command.fragmentCount || command.fragmentOffset >= command.totalLength || command.fragmentOffset + command.Payload.Length > command.totalLength)
				{
					if ((int)base.debugOut >= 1)
					{
						base.Listener.DebugReturn(DebugLevel.ERROR, "Received fragment has bad size: " + command);
					}
					command.Release();
					break;
				}
				bool flag2 = command.commandType == 8;
				EnetChannel channel = GetChannel(command.commandChannelID);
				NCommand fragment = null;
				bool flag3 = channel.TryGetFragment(command.startSequenceNumber, flag2, out fragment);
				if (flag3 && fragment.fragmentsRemaining <= 0)
				{
					command.Release();
					break;
				}
				if (!QueueIncomingCommand(command))
				{
					command.Release();
					break;
				}
				if (command.reliableSequenceNumber != command.startSequenceNumber)
				{
					if (flag3)
					{
						fragment.fragmentsRemaining--;
					}
				}
				else
				{
					fragment = command;
					fragment.fragmentsRemaining--;
					NCommand fragment2 = null;
					int num = command.startSequenceNumber + 1;
					while (fragment.fragmentsRemaining > 0 && num < fragment.startSequenceNumber + fragment.fragmentCount)
					{
						if (channel.TryGetFragment(num++, flag2, out fragment2))
						{
							fragment.fragmentsRemaining--;
						}
					}
				}
				if (fragment == null || fragment.fragmentsRemaining > 0)
				{
					break;
				}
				StreamBuffer streamBuffer = PeerBase.MessageBufferPoolGet();
				streamBuffer.Position = 0;
				streamBuffer.SetCapacityMinimum(fragment.totalLength);
				byte[] buffer = streamBuffer.GetBuffer();
				for (int i = fragment.startSequenceNumber; i < fragment.startSequenceNumber + fragment.fragmentCount; i++)
				{
					if (channel.TryGetFragment(i, flag2, out var fragment3))
					{
						Buffer.BlockCopy(fragment3.Payload.GetBuffer(), 0, buffer, fragment3.fragmentOffset, fragment3.Payload.Length);
						fragment3.FreePayload();
						channel.RemoveFragment(fragment3.reliableSequenceNumber, flag2);
						if (fragment3.fragmentNumber > 0)
						{
							fragment3.Release();
						}
						continue;
					}
					throw new Exception("startCommand.fragmentsRemaining was 0 but not all fragments were found to be combined!");
				}
				streamBuffer.SetLength(fragment.totalLength);
				fragment.Payload = streamBuffer;
				fragment.Size = 12 * fragment.fragmentCount + fragment.totalLength;
				if (flag2)
				{
					channel.incomingReliableCommandsList.Add(fragment.startSequenceNumber, fragment);
				}
				else
				{
					channel.incomingUnsequencedCommandsList.Enqueue(fragment);
				}
				break;
			}
			case 3:
				if (base.TrafficStatsEnabled)
				{
					base.TrafficStatsIncoming.CountControlCommand(command.Size);
				}
				if (peerConnectionState == ConnectionStateValue.Connecting)
				{
					byte[] buf = WriteInitRequest();
					CreateAndEnqueueCommand(6, new StreamBuffer(buf), 0);
					if (photonPeer.RandomizeSequenceNumbers)
					{
						ApplyRandomizedSequenceNumbers();
					}
					peerConnectionState = ConnectionStateValue.Connected;
				}
				command.Release();
				break;
			case 9:
			case 10:
			case 12:
			case 13:
				break;
			}
		}

		internal bool QueueIncomingCommand(NCommand command)
		{
			EnetChannel channel = GetChannel(command.commandChannelID);
			if (channel == null)
			{
				if ((int)base.debugOut >= 1)
				{
					base.Listener.DebugReturn(DebugLevel.ERROR, "Received command for non-existing channel: " + command.commandChannelID);
				}
				return false;
			}
			if (command.IsFlaggedReliable)
			{
				if (command.IsFlaggedUnsequenced)
				{
					return channel.QueueIncomingReliableUnsequenced(command);
				}
				if (command.reliableSequenceNumber <= channel.incomingReliableSequenceNumber)
				{
					if ((int)base.debugOut >= 5)
					{
						base.Listener.DebugReturn(DebugLevel.ALL, "incoming command " + command?.ToString() + " is old (not saving it). Dispatched incomingReliableSequenceNumber: " + channel.incomingReliableSequenceNumber);
					}
					return false;
				}
				if (channel.ContainsReliableSequenceNumber(command.reliableSequenceNumber))
				{
					if ((int)base.debugOut >= 5)
					{
						base.Listener.DebugReturn(DebugLevel.ALL, "Info: command was received before! Old/New: " + channel.FetchReliableSequenceNumber(command.reliableSequenceNumber)?.ToString() + "/" + command?.ToString() + " inReliableSeq#: " + channel.incomingReliableSequenceNumber);
					}
					return false;
				}
				channel.incomingReliableCommandsList.Add(command.reliableSequenceNumber, command);
				return true;
			}
			if (command.commandFlags == 0)
			{
				if (command.reliableSequenceNumber < channel.incomingReliableSequenceNumber)
				{
					photonPeer.CountDiscarded++;
					if ((int)base.debugOut >= 5)
					{
						base.Listener.DebugReturn(DebugLevel.ALL, "incoming reliable-seq# < Dispatched-rel-seq#. not saved.");
					}
					return false;
				}
				if (command.unreliableSequenceNumber <= channel.incomingUnreliableSequenceNumber)
				{
					photonPeer.CountDiscarded++;
					if ((int)base.debugOut >= 5)
					{
						base.Listener.DebugReturn(DebugLevel.ALL, "incoming unreliable-seq# < Dispatched-unrel-seq#. not saved.");
					}
					return false;
				}
				if (channel.ContainsUnreliableSequenceNumber(command.unreliableSequenceNumber))
				{
					if ((int)base.debugOut >= 5)
					{
						base.Listener.DebugReturn(DebugLevel.ALL, "command was received before! Old/New: " + channel.incomingUnreliableCommandsList[command.unreliableSequenceNumber]?.ToString() + "/" + command);
					}
					return false;
				}
				channel.incomingUnreliableCommandsList.Add(command.unreliableSequenceNumber, command);
				return true;
			}
			if (command.commandFlags == 2)
			{
				int unsequencedGroupNumber = command.unsequencedGroupNumber;
				int num = command.unsequencedGroupNumber % 128;
				if (unsequencedGroupNumber >= incomingUnsequencedGroupNumber + 128)
				{
					incomingUnsequencedGroupNumber = unsequencedGroupNumber - num;
					for (int i = 0; i < unsequencedWindow.Length; i++)
					{
						unsequencedWindow[i] = 0;
					}
				}
				else if (unsequencedGroupNumber < incomingUnsequencedGroupNumber || (unsequencedWindow[num / 32] & (1 << num % 32)) != 0)
				{
					return false;
				}
				unsequencedWindow[num / 32] |= 1 << num % 32;
				channel.incomingUnsequencedCommandsList.Enqueue(command);
				return true;
			}
			return false;
		}

		internal NCommand RemoveSentReliableCommand(int ackReceivedReliableSequenceNumber, int ackReceivedChannel, bool isUnsequenced)
		{
			NCommand nCommand = null;
			lock (sentReliableCommands)
			{
				foreach (NCommand sentReliableCommand in sentReliableCommands)
				{
					if (sentReliableCommand != null && sentReliableCommand.reliableSequenceNumber == ackReceivedReliableSequenceNumber && sentReliableCommand.commandChannelID == ackReceivedChannel && sentReliableCommand.IsFlaggedUnsequenced == isUnsequenced)
					{
						nCommand = sentReliableCommand;
						break;
					}
				}
				if (nCommand != null)
				{
					sentReliableCommands.Remove(nCommand);
				}
				else if ((int)base.debugOut >= 5 && peerConnectionState != ConnectionStateValue.Connected && peerConnectionState != ConnectionStateValue.Disconnecting)
				{
					EnqueueDebugReturn(DebugLevel.ALL, $"No sent command for ACK (Ch: {ackReceivedReliableSequenceNumber} Sq#: {ackReceivedChannel}). PeerState: {peerConnectionState}.");
				}
			}
			return nCommand;
		}

		internal string CommandListToString(NCommand[] list)
		{
			if ((int)base.debugOut < 5)
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < list.Length; i++)
			{
				stringBuilder.Append(i + "=");
				stringBuilder.Append(list[i]);
				stringBuilder.Append(" # ");
			}
			return stringBuilder.ToString();
		}
	}
	public enum StatusCode
	{
		Connect = 1024,
		Disconnect = 1025,
		Exception = 1026,
		ExceptionOnConnect = 1023,
		ServerAddressInvalid = 1050,
		DnsExceptionOnConnect = 1051,
		SecurityExceptionOnConnect = 1022,
		SendError = 1030,
		ExceptionOnReceive = 1039,
		TimeoutDisconnect = 1040,
		DisconnectByServerTimeout = 1041,
		DisconnectByServerUserLimit = 1042,
		DisconnectByServerLogic = 1043,
		DisconnectByServerReasonUnknown = 1044,
		EncryptionEstablished = 1048,
		EncryptionFailedToEstablish = 1049
	}
	public interface IPhotonPeerListener
	{
		void DebugReturn(DebugLevel level, string message);

		void OnOperationResponse(OperationResponse operationResponse);

		void OnStatusChanged(StatusCode statusCode);

		void OnEvent(EventData eventData);
	}
	public enum PhotonSocketState
	{
		Disconnected,
		Connecting,
		Connected,
		Disconnecting
	}
	public enum PhotonSocketError
	{
		Success,
		Skipped,
		NoData,
		Exception,
		Busy,
		PendingSend
	}
	public abstract class IPhotonSocket
	{
		protected internal PeerBase peerBase;

		protected readonly ConnectionProtocol Protocol;

		public bool PollReceive;

		public string ConnectAddress;

		protected IPhotonPeerListener Listener => peerBase.Listener;

		protected internal int MTU => peerBase.mtu;

		public PhotonSocketState State { get; protected set; }

		public int SocketErrorCode { get; protected set; }

		public bool Connected => State == PhotonSocketState.Connected;

		public string ServerAddress { get; protected set; }

		public string ProxyServerAddress { get; protected set; }

		public static string ServerIpAddress { get; protected set; }

		public int ServerPort { get; protected set; }

		public bool AddressResolvedAsIpv6 { get; protected internal set; }

		public string UrlProtocol { get; protected set; }

		public string UrlPath { get; protected set; }

		protected internal string SerializationProtocol
		{
			get
			{
				if (peerBase == null || peerBase.photonPeer == null)
				{
					return "GpBinaryV18";
				}
				return Enum.GetName(typeof(SerializationProtocol), peerBase.photonPeer.SerializationProtocolType);
			}
		}

		public IPhotonSocket(PeerBase peerBase)
		{
			if (peerBase == null)
			{
				throw new Exception("Can't init without peer");
			}
			Protocol = peerBase.usedTransportProtocol;
			this.peerBase = peerBase;
			ConnectAddress = this.peerBase.ServerAddress;
		}

		public virtual bool Connect()
		{
			if (State != PhotonSocketState.Disconnected)
			{
				if ((int)peerBase.debugOut >= 1)
				{
					peerBase.Listener.DebugReturn(DebugLevel.ERROR, "Connect() failed: connection in State: " + State);
				}
				return false;
			}
			if (peerBase == null || Protocol != peerBase.usedTransportProtocol)
			{
				return false;
			}
			if (!TryParseAddress(peerBase.ServerAddress, out var host, out var port, out var scheme, out var absolutePath))
			{
				if ((int)peerBase.debugOut >= 1)
				{
					peerBase.Listener.DebugReturn(DebugLevel.ERROR, "Failed parsing address: " + peerBase.ServerAddress);
				}
				return false;
			}
			ServerIpAddress = string.Empty;
			ServerAddress = host;
			ServerPort = port;
			UrlProtocol = scheme;
			UrlPath = absolutePath;
			if ((int)peerBase.debugOut >= 5)
			{
				Listener.DebugReturn(DebugLevel.ALL, "IPhotonSocket.Connect() " + ServerAddress + ":" + ServerPort + " this.Protocol: " + Protocol);
			}
			return true;
		}

		public abstract bool Disconnect();

		public abstract PhotonSocketError Send(byte[] data, int length);

		public abstract PhotonSocketError Receive(out byte[] data);

		public void HandleReceivedDatagram(byte[] inBuffer, int length, bool willBeReused)
		{
			ITrafficRecorder trafficRecorder = peerBase.photonPeer.TrafficRecorder;
			if (trafficRecorder != null && trafficRecorder.Enabled)
			{
				trafficRecorder.Record(inBuffer, length, incoming: true, peerBase.peerID, this);
			}
			if (peerBase.NetworkSimulationSettings.IsSimulationEnabled)
			{
				if (willBeReused)
				{
					byte[] array = new byte[length];
					Buffer.BlockCopy(inBuffer, 0, array, 0, length);
					peerBase.ReceiveNetworkSimulated(array);
				}
				else
				{
					peerBase.ReceiveNetworkSimulated(inBuffer);
				}
			}
			else
			{
				peerBase.ReceiveIncomingCommands(inBuffer, length);
			}
		}

		public bool ReportDebugOfLevel(DebugLevel levelOfMessage)
		{
			return (int)peerBase.debugOut >= (int)levelOfMessage;
		}

		public void EnqueueDebugReturn(DebugLevel debugLevel, string message)
		{
			peerBase.EnqueueDebugReturn(debugLevel, message);
		}

		protected internal void HandleException(StatusCode statusCode)
		{
			State = PhotonSocketState.Disconnecting;
			peerBase.EnqueueStatusCallback(statusCode);
			peerBase.EnqueueActionForDispatch(delegate
			{
				peerBase.Disconnect();
			});
		}

		protected internal bool TryParseAddress(string url, out string host, out ushort port, out string scheme, out string absolutePath)
		{
			host = string.Empty;
			port = 0;
			scheme = string.Empty;
			absolutePath = string.Empty;
			if (string.IsNullOrEmpty(url))
			{
				return false;
			}
			bool flag = url.Contains("://");
			string uriString = (flag ? url : ("net.tcp://" + url));
			Uri result;
			bool flag2 = Uri.TryCreate(uriString, UriKind.Absolute, out result);
			if (flag2)
			{
				host = result.Host;
				port = (ushort)((flag || url.Contains($":{result.Port}")) ? ((ushort)result.Port) : 0);
				scheme = (flag ? result.Scheme : string.Empty);
				absolutePath = ("/".Equals(result.AbsolutePath) ? string.Empty : result.AbsolutePath);
			}
			return flag2;
		}

		private bool IpAddressTryParse(string strIP, out IPAddress address)
		{
			address = null;
			if (string.IsNullOrEmpty(strIP))
			{
				return false;
			}
			string[] array = strIP.Split(new char[1] { '.' });
			if (array.Length != 4)
			{
				return false;
			}
			byte[] array2 = new byte[4];
			for (int i = 0; i < array.Length; i++)
			{
				string s = array[i];
				byte result = 0;
				if (!byte.TryParse(s, out result))
				{
					return false;
				}
				array2[i] = result;
			}
			if (array2[0] == 0)
			{
				return false;
			}
			address = new IPAddress(array2);
			return true;
		}

		protected internal IPAddress[] GetIpAddresses(string hostname)
		{
			IPAddress address = null;
			if (IPAddress.TryParse(hostname, out address))
			{
				if (address.AddressFamily == AddressFamily.InterNetworkV6 || IpAddressTryParse(hostname, out address))
				{
					return new IPAddress[1] { address };
				}
				HandleException(StatusCode.ServerAddressInvalid);
				return null;
			}
			IPAddress[] array;
			try
			{
				array = Dns.GetHostAddresses(ServerAddress);
			}
			catch (Exception ex)
			{
				try
				{
					IPHostEntry hostByName = Dns.GetHostByName(ServerAddress);
					array = hostByName.AddressList;
				}
				catch (Exception ex2)
				{
					if (ReportDebugOfLevel(DebugLevel.WARNING))
					{
						EnqueueDebugReturn(DebugLevel.WARNING, "GetHostAddresses and GetHostEntry() failed for: " + ServerAddress + ". Caught and handled exceptions:\n" + ex?.ToString() + "\n" + ex2);
					}
					HandleException(StatusCode.DnsExceptionOnConnect);
					return null;
				}
			}
			Array.Sort(array, AddressSortComparer);
			if (ReportDebugOfLevel(DebugLevel.INFO))
			{
				string[] array2 = array.Select((IPAddress x) => x.ToString() + " (" + x.AddressFamily.ToString() + "(" + (int)x.AddressFamily + "))").ToArray();
				string text = string.Join(", ", array2);
				if (ReportDebugOfLevel(DebugLevel.INFO))
				{
					EnqueueDebugReturn(DebugLevel.INFO, ServerAddress + " resolved to " + array2.Length + " address(es): " + text);
				}
			}
			return array;
		}

		private int AddressSortComparer(IPAddress x, IPAddress y)
		{
			if (x.AddressFamily == y.AddressFamily)
			{
				return 0;
			}
			return (x.AddressFamily != AddressFamily.InterNetworkV6) ? 1 : (-1);
		}

		[Obsolete("Use GetIpAddresses instead.")]
		protected internal static IPAddress GetIpAddress(string address)
		{
			IPAddress address2 = null;
			if (IPAddress.TryParse(address, out address2))
			{
				return address2;
			}
			IPHostEntry hostEntry = Dns.GetHostEntry(address);
			IPAddress[] addressList = hostEntry.AddressList;
			IPAddress[] array = addressList;
			foreach (IPAddress iPAddress in array)
			{
				if (iPAddress.AddressFamily == AddressFamily.InterNetworkV6)
				{
					ServerIpAddress = iPAddress.ToString();
					return iPAddress;
				}
				if (address2 == null && iPAddress.AddressFamily == AddressFamily.InterNetwork)
				{
					address2 = iPAddress;
				}
			}
			ServerIpAddress = ((address2 != null) ? address2.ToString() : (address + " not resolved"));
			return address2;
		}
	}
	public enum SerializationProtocol
	{
		GpBinaryV16,
		GpBinaryV18
	}
	internal static class SerializationProtocolFactory
	{
		internal static IProtocol Create(SerializationProtocol serializationProtocol)
		{
			if (serializationProtocol == SerializationProtocol.GpBinaryV18)
			{
				return new Protocol18();
			}
			return new Protocol16();
		}
	}
	public abstract class IProtocol
	{
		public enum DeserializationFlags
		{
			None,
			AllowPooledByteArray,
			WrapIncomingStructs
		}

		public readonly ByteArraySlicePool ByteArraySlicePool = new ByteArraySlicePool();

		public abstract string ProtocolType { get; }

		public abstract byte[] VersionBytes { get; }

		public abstract void Serialize(StreamBuffer dout, object serObject, bool setType);

		public abstract void SerializeShort(StreamBuffer dout, short serObject, bool setType);

		public abstract void SerializeString(StreamBuffer dout, string serObject, bool setType);

		public abstract void SerializeEventData(StreamBuffer stream, EventData serObject, bool setType);

		[Obsolete("Use ParameterDictionary instead.")]
		public abstract void SerializeOperationRequest(StreamBuffer stream, byte operationCode, Dictionary<byte, object> parameters, bool setType);

		public abstract void SerializeOperationRequest(StreamBuffer stream, byte operationCode, ParameterDictionary parameters, bool setType);

		public abstract void SerializeOperationResponse(StreamBuffer stream, OperationResponse serObject, bool setType);

		public abstract object Deserialize(StreamBuffer din, byte type, DeserializationFlags flags = DeserializationFlags.None);

		public abstract short DeserializeShort(StreamBuffer din);

		public abstract byte DeserializeByte(StreamBuffer din);

		public abstract EventData DeserializeEventData(StreamBuffer din, EventData target = null, DeserializationFlags flags = DeserializationFlags.None);

		public abstract OperationRequest DeserializeOperationRequest(StreamBuffer din, DeserializationFlags flags = DeserializationFlags.None);

		public abstract OperationResponse DeserializeOperationResponse(StreamBuffer stream, DeserializationFlags flags = DeserializationFlags.None);

		public abstract DisconnectMessage DeserializeDisconnectMessage(StreamBuffer stream);

		public byte[] Serialize(object obj)
		{
			StreamBuffer streamBuffer = new StreamBuffer(64);
			Serialize(streamBuffer, obj, setType: true);
			return streamBuffer.ToArray();
		}

		public object Deserialize(StreamBuffer stream)
		{
			return Deserialize(stream, stream.ReadByte());
		}

		public object Deserialize(byte[] serializedData)
		{
			StreamBuffer streamBuffer = new StreamBuffer(serializedData);
			return Deserialize(streamBuffer, streamBuffer.ReadByte());
		}

		public object DeserializeMessage(StreamBuffer stream)
		{
			return Deserialize(stream, stream.ReadByte());
		}

		internal void SerializeMessage(StreamBuffer ms, object msg)
		{
			Serialize(ms, msg, setType: true);
		}
	}
	public interface ITrafficRecorder
	{
		bool Enabled { get; set; }

		void Record(byte[] inBuffer, int length, bool incoming, short peerId, IPhotonSocket connection);
	}
	internal class NCommandPool
	{
		private readonly Stack<NCommand> pool = new Stack<NCommand>();

		public NCommand Acquire(EnetPeer peer, byte[] inBuff, ref int readingOffset)
		{
			NCommand nCommand;
			lock (pool)
			{
				if (pool.Count == 0)
				{
					nCommand = new NCommand(peer, inBuff, ref readingOffset);
					nCommand.returnPool = this;
				}
				else
				{
					nCommand = pool.Pop();
					nCommand.Initialize(peer, inBuff, ref readingOffset);
				}
			}
			return nCommand;
		}

		public NCommand Acquire(EnetPeer peer, byte commandType, StreamBuffer payload, byte channel)
		{
			NCommand nCommand;
			lock (pool)
			{
				if (pool.Count == 0)
				{
					nCommand = new NCommand(peer, commandType, payload, channel);
					nCommand.returnPool = this;
				}
				else
				{
					nCommand = pool.Pop();
					nCommand.Initialize(peer, commandType, payload, channel);
				}
			}
			return nCommand;
		}

		public void Release(NCommand nCommand)
		{
			nCommand.Reset();
			lock (pool)
			{
				pool.Push(nCommand);
			}
		}
	}
	internal class NCommand : IComparable<NCommand>
	{
		internal const byte FV_UNRELIABLE = 0;

		internal const byte FV_RELIABLE = 1;

		internal const byte FV_UNRELIABLE_UNSEQUENCED = 2;

		internal const byte FV_RELIBALE_UNSEQUENCED = 3;

		internal const byte CT_NONE = 0;

		internal const byte CT_ACK = 1;

		internal const byte CT_CONNECT = 2;

		internal const byte CT_VERIFYCONNECT = 3;

		internal const byte CT_DISCONNECT = 4;

		internal const byte CT_PING = 5;

		internal const byte CT_SENDRELIABLE = 6;

		internal const byte CT_SENDUNRELIABLE = 7;

		internal const byte CT_SENDFRAGMENT = 8;

		internal const byte CT_SENDUNSEQUENCED = 11;

		internal const byte CT_EG_SERVERTIME = 12;

		internal const byte CT_EG_SEND_UNRELIABLE_PROCESSED = 13;

		internal const byte CT_EG_SEND_RELIABLE_UNSEQUENCED = 14;

		internal const byte CT_EG_SEND_FRAGMENT_UNSEQUENCED = 15;

		internal const byte CT_EG_ACK_UNSEQUENCED = 16;

		internal const int HEADER_UDP_PACK_LENGTH = 12;

		internal const int CmdSizeMinimum = 12;

		internal const int CmdSizeAck = 20;

		internal const int CmdSizeConnect = 44;

		internal const int CmdSizeVerifyConnect = 44;

		internal const int CmdSizeDisconnect = 12;

		internal const int CmdSizePing = 12;

		internal const int CmdSizeReliableHeader = 12;

		internal const int CmdSizeUnreliableHeader = 16;

		internal const int CmdSizeUnsequensedHeader = 16;

		internal const int CmdSizeFragmentHeader = 32;

		internal const int CmdSizeMaxHeader = 36;

		internal byte commandFlags;

		internal byte commandType;

		internal byte commandChannelID;

		internal int reliableSequenceNumber;

		internal int unreliableSequenceNumber;

		internal int unsequencedGroupNumber;

		internal byte reservedByte = 4;

		internal int startSequenceNumber;

		internal int fragmentCount;

		internal int fragmentNumber;

		internal int totalLength;

		internal int fragmentOffset;

		internal int fragmentsRemaining;

		internal int commandSentTime;

		internal byte commandSentCount;

		internal int roundTripTimeout;

		internal int timeoutTime;

		internal int ackReceivedReliableSequenceNumber;

		internal int ackReceivedSentTime;

		internal int Size;

		internal StreamBuffer Payload;

		internal NCommandPool returnPool;

		protected internal int SizeOfPayload => (Payload != null) ? Payload.Length : 0;

		protected internal bool IsFlaggedUnsequenced => (commandFlags & 2) > 0;

		protected internal bool IsFlaggedReliable => (commandFlags & 1) > 0;

		internal static void CreateAck(byte[] buffer, int offset, NCommand commandToAck, int sentTime)
		{
			buffer[offset++] = (byte)((!commandToAck.IsFlaggedUnsequenced) ? 1 : 16);
			buffer[offset++] = commandToAck.commandChannelID;
			buffer[offset++] = 0;
			buffer[offset++] = 4;
			Protocol.Serialize(20, buffer, ref offset);
			Protocol.Serialize(0, buffer, ref offset);
			Protocol.Serialize(commandToAck.reliableSequenceNumber, buffer, ref offset);
			Protocol.Serialize(sentTime, buffer, ref offset);
		}

		internal NCommand(EnetPeer peer, byte commandType, StreamBuffer payload, byte channel)
		{
			Initialize(peer, commandType, payload, channel);
		}

		internal void Initialize(EnetPeer peer, byte commandType, StreamBuffer payload, byte channel)
		{
			this.commandType = commandType;
			commandFlags = 1;
			commandChannelID = channel;
			Payload = payload;
			Size = 12;
			switch (this.commandType)
			{
			case 2:
			{
				Size = 44;
				byte[] array = new byte[32];
				array[0] = 0;
				array[1] = 0;
				int targetOffset = 2;
				Protocol.Serialize((short)peer.mtu, array, ref targetOffset);
				array[4] = 0;
				array[5] = 0;
				array[6] = 128;
				array[7] = 0;
				array[11] = peer.ChannelCount;
				array[15] = 0;
				array[19] = 0;
				array[22] = 19;
				array[23] = 136;
				array[27] = 2;
				array[31] = 2;
				Payload = new StreamBuffer(array);
				break;
			}
			case 4:
				Size = 12;
				if (peer.peerConnectionState != ConnectionStateValue.Connected)
				{
					commandFlags = 2;
					reservedByte = (byte)((peer.peerConnectionState == ConnectionStateValue.Zombie) ? 2 : 4);
				}
				break;
			case 6:
				Size = 12 + payload.Length;
				break;
			case 14:
				Size = 12 + payload.Length;
				commandFlags = 3;
				break;
			case 7:
				Size = 16 + payload.Length;
				commandFlags = 0;
				break;
			case 11:
				Size = 16 + payload.Length;
				commandFlags = 2;
				break;
			case 8:
				Size = 32 + payload.Length;
				break;
			case 15:
				Size = 32 + payload.Length;
				commandFlags = 3;
				break;
			case 3:
			case 5:
			case 9:
			case 10:
			case 12:
			case 13:
				break;
			}
		}

		internal NCommand(EnetPeer peer, byte[] inBuff, ref int readingOffset)
		{
			Initialize(peer, inBuff, ref readingOffset);
		}

		internal void Initialize(EnetPeer peer, byte[] inBuff, ref int readingOffset)
		{
			commandType = inBuff[readingOffset++];
			commandChannelID = inBuff[readingOffset++];
			commandFlags = inBuff[readingOffset++];
			reservedByte = inBuff[readingOffset++];
			Protocol.Deserialize(out Size, inBuff, ref readingOffset);
			Protocol.Deserialize(out reliableSequenceNumber, inBuff, ref readingOffset);
			peer.bytesIn += Size;
			int num = 0;
			switch (commandType)
			{
			case 1:
			case 16:
				Protocol.Deserialize(out ackReceivedReliableSequenceNumber, inBuff, ref readingOffset);
				Protocol.Deserialize(out ackReceivedSentTime, inBuff, ref readingOffset);
				break;
			case 6:
			case 14:
				num = Size - 12;
				break;
			case 7:
				Protocol.Deserialize(out unreliableSequenceNumber, inBuff, ref readingOffset);
				num = Size - 16;
				break;
			case 11:
				Protocol.Deserialize(out unsequencedGroupNumber, inBuff, ref readingOffset);
				num = Size - 16;
				break;
			case 8:
			case 15:
				Protocol.Deserialize(out startSequenceNumber, inBuff, ref readingOffset);
				Protocol.Deserialize(out fragmentCount, inBuff, ref readingOffset);
				Protocol.Deserialize(out fragmentNumber, inBuff, ref readingOffset);
				Protocol.Deserialize(out totalLength, inBuff, ref readingOffset);
				Protocol.Deserialize(out fragmentOffset, inBuff, ref readingOffset);
				num = Size - 32;
				fragmentsRemaining = fragmentCount;
				break;
			case 3:
			{
				Protocol.Deserialize(out short value, inBuff, ref readingOffset);
				readingOffset += 30;
				if (peer.peerID == -1 || peer.peerID == -2)
				{
					peer.peerID = value;
				}
				break;
			}
			default:
				readingOffset += Size - 12;
				break;
			}
			if (num != 0)
			{
				StreamBuffer streamBuffer = PeerBase.MessageBufferPoolGet();
				streamBuffer.Write(inBuff, readingOffset, num);
				Payload = streamBuffer;
				Payload.Position = 0;
				readingOffset += num;
			}
		}

		public void Reset()
		{
			commandFlags = 0;
			commandType = 0;
			commandChannelID = 0;
			reliableSequenceNumber = 0;
			unreliableSequenceNumber = 0;
			unsequencedGroupNumber = 0;
			reservedByte = 4;
			startSequenceNumber = 0;
			fragmentCount = 0;
			fragmentNumber = 0;
			totalLength = 0;
			fragmentOffset = 0;
			fragmentsRemaining = 0;
			commandSentTime = 0;
			commandSentCount = 0;
			roundTripTimeout = 0;
			timeoutTime = 0;
			ackReceivedReliableSequenceNumber = 0;
			ackReceivedSentTime = 0;
			Size = 0;
		}

		internal void SerializeHeader(byte[] buffer, ref int bufferIndex)
		{
			buffer[bufferIndex++] = commandType;
			buffer[bufferIndex++] = commandChannelID;
			buffer[bufferIndex++] = commandFlags;
			buffer[bufferIndex++] = reservedByte;
			Protocol.Serialize(Size, buffer, ref bufferIndex);
			Protocol.Serialize(reliableSequenceNumber, buffer, ref bufferIndex);
			if (commandType == 7)
			{
				Protocol.Serialize(unreliableSequenceNumber, buffer, ref bufferIndex);
			}
			else if (commandType == 11)
			{
				Protocol.Serialize(unsequencedGroupNumber, buffer, ref bufferIndex);
			}
			else if (commandType == 8 || commandType == 15)
			{
				Protocol.Serialize(startSequenceNumber, buffer, ref bufferIndex);
				Protocol.Serialize(fragmentCount, buffer, ref bufferIndex);
				Protocol.Serialize(fragmentNumber, buffer, ref bufferIndex);
				Protocol.Serialize(totalLength, buffer, ref bufferIndex);
				Protocol.Serialize(fragmentOffset, buffer, ref bufferIndex);
			}
		}

		internal byte[] Serialize()
		{
			return Payload.GetBuffer();
		}

		public void FreePayload()
		{
			if (Payload != null)
			{
				PeerBase.MessageBufferPoolPut(Payload);
			}
			Payload = null;
		}

		public void Release()
		{
			returnPool.Release(this);
		}

		public int CompareTo(NCommand other)
		{
			if (other == null)
			{
				return 1;
			}
			int num = reliableSequenceNumber - other.reliableSequenceNumber;
			if (IsFlaggedReliable || num != 0)
			{
				return num;
			}
			return unreliableSequenceNumber - other.unreliableSequenceNumber;
		}

		public override string ToString()
		{
			if (commandType == 1 || commandType == 16)
			{
				return string.Format("CMD({1} ack for ch#/sq#/time: {0}/{2}/{3})", commandChannelID, commandType, ackReceivedReliableSequenceNumber, ackReceivedSentTime);
			}
			return string.Format("CMD({1} ch#/sq#/usq#: {0}/{2}/{3} r#/st/tt/rt:{5}/{4}/{6}/{7})", commandChannelID, commandType, reliableSequenceNumber, unreliableSequenceNumber, commandSentTime, commandSentCount, timeoutTime, roundTripTimeout);
		}
	}
	internal class SimulationItem
	{
		internal readonly Stopwatch stopw;

		public int TimeToExecute;

		public byte[] DelayedData;

		public int Delay { get; internal set; }

		public SimulationItem()
		{
			stopw = new Stopwatch();
			stopw.Start();
		}
	}
	public class NetworkSimulationSet
	{
		private bool isSimulationEnabled = false;

		private int outgoingLag = 100;

		private int outgoingJitter = 0;

		private int outgoingLossPercentage = 1;

		private int incomingLag = 100;

		private int incomingJitter = 0;

		private int incomingLossPercentage = 1;

		internal PeerBase peerBase;

		private Thread netSimThread;

		protected internal readonly ManualResetEvent NetSimManualResetEvent = new ManualResetEvent(initialState: false);

		protected internal bool IsSimulationEnabled
		{
			get
			{
				return isSimulationEnabled;
			}
			set
			{
				lock (NetSimManualResetEvent)
				{
					if (value == isSimulationEnabled)
					{
						return;
					}
					if (!value)
					{
						lock (peerBase.NetSimListIncoming)
						{
							foreach (SimulationItem item in peerBase.NetSimListIncoming)
							{
								if (peerBase.PhotonSocket != null && peerBase.PhotonSocket.Connected)
								{
									peerBase.ReceiveIncomingCommands(item.DelayedData, item.DelayedData.Length);
								}
							}
							peerBase.NetSimListIncoming.Clear();
						}
						lock (peerBase.NetSimListOutgoing)
						{
							foreach (SimulationItem item2 in peerBase.NetSimListOutgoing)
							{
								if (peerBase.PhotonSocket != null && peerBase.PhotonSocket.Connected)
								{
									peerBase.PhotonSocket.Send(item2.DelayedData, item2.DelayedData.Length);
								}
							}
							peerBase.NetSimListOutgoing.Clear();
						}
					}
					isSimulationEnabled = value;
					if (isSimulationEnabled)
					{
						if (netSimThread == null)
						{
							netSimThread = new Thread(peerBase.NetworkSimRun);
							netSimThread.IsBackground = true;
							netSimThread.Name = "netSim";
							netSimThread.Start();
						}
						NetSimManualResetEvent.Set();
					}
					else
					{
						NetSimManualResetEvent.Reset();
					}
				}
			}
		}

		public int OutgoingLag
		{
			get
			{
				return outgoingLag;
			}
			set
			{
				outgoingLag = value;
			}
		}

		public int OutgoingJitter
		{
			get
			{
				return outgoingJitter;
			}
			set
			{
				outgoingJitter = value;
			}
		}

		public int OutgoingLossPercentage
		{
			get
			{
				return outgoingLossPercentage;
			}
			set
			{
				outgoingLossPercentage = value;
			}
		}

		public int IncomingLag
		{
			get
			{
				return incomingLag;
			}
			set
			{
				incomingLag = value;
			}
		}

		public int IncomingJitter
		{
			get
			{
				return incomingJitter;
			}
			set
			{
				incomingJitter = value;
			}
		}

		public int IncomingLossPercentage
		{
			get
			{
				return incomingLossPercentage;
			}
			set
			{
				incomingLossPercentage = value;
			}
		}

		public int LostPackagesOut { get; internal set; }

		public int LostPackagesIn { get; internal set; }

		public override string ToString()
		{
			return string.Format("NetworkSimulationSet {6}.  Lag in={0} out={1}. Jitter in={2} out={3}. Loss in={4} out={5}.", incomingLag, outgoingLag, incomingJitter, outgoingJitter, incomingLossPercentage, outgoingLossPercentage, IsSimulationEnabled);
		}
	}
	public class ParameterDictionary : IEnumerable<KeyValuePair<byte, object>>, IEnumerable
	{
		public readonly NonAllocDictionary<byte, object> paramDict;

		public readonly StructWrapperPools wrapperPools = new StructWrapperPools();

		public object this[byte key]
		{
			get
			{
				object obj = paramDict[key];
				if (!(obj is StructWrapper<object> result))
				{
					return obj;
				}
				return result;
			}
			set
			{
				paramDict[key] = value;
			}
		}

		public int Count => paramDict.Count;

		public ParameterDictionary()
		{
			paramDict = new NonAllocDictionary<byte, object>();
		}

		public ParameterDictionary(int capacity)
		{
			paramDict = new NonAllocDictionary<byte, object>((uint)capacity);
		}

		public static implicit operator NonAllocDictionary<byte, object>(ParameterDictionary value)
		{
			return value.paramDict;
		}

		IEnumerator<KeyValuePair<byte, object>> IEnumerable<KeyValuePair<byte, object>>.GetEnumerator()
		{
			return ((IEnumerable<KeyValuePair<byte, object>>)paramDict).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<KeyValuePair<byte, object>>)paramDict).GetEnumerator();
		}

		public NonAllocDictionary<byte, object>.PairIterator GetEnumerator()
		{
			return paramDict.GetEnumerator();
		}

		public void Clear()
		{
			wrapperPools.Clear();
			paramDict.Clear();
		}

		public void Add(byte code, string value)
		{
			if (paramDict.ContainsKey(code))
			{
				UnityEngine.Debug.LogWarning(code + " already exists as key in ParameterDictionary");
			}
			paramDict[code] = value;
		}

		public void Add(byte code, Hashtable value)
		{
			if (paramDict.ContainsKey(code))
			{
				UnityEngine.Debug.LogWarning(code + " already exists as key in ParameterDictionary");
			}
			paramDict[code] = value;
		}

		public void Add(byte code, byte value)
		{
			if (paramDict.ContainsKey(code))
			{
				UnityEngine.Debug.LogError(code + " already exists as key in ParameterDictionary");
			}
			StructWrapper<byte> value2 = StructWrapperPools.mappedByteWrappers[value];
			paramDict[code] = value2;
		}

		public void Add(byte code, bool value)
		{
			if (paramDict.ContainsKey(code))
			{
				UnityEngine.Debug.LogError(code + " already exists as key in ParameterDictionary");
			}
			StructWrapper<bool> value2 = StructWrapperPools.mappedBoolWrappers[value ? 1 : 0];
			paramDict[code] = value2;
		}

		public void Add(byte code, short value)
		{
			if (paramDict.ContainsKey(code))
			{
				UnityEngine.Debug.LogWarning(code + " already exists as key in ParameterDictionary");
			}
			paramDict[code] = value;
		}

		public void Add(byte code, int value)
		{
			if (paramDict.ContainsKey(code))
			{
				UnityEngine.Debug.LogWarning(code + " already exists as key in ParameterDictionary");
			}
			paramDict[code] = value;
		}

		public void Add(byte code, long value)
		{
			if (paramDict.ContainsKey(code))
			{
				UnityEngine.Debug.LogWarning(code + " already exists as key in ParameterDictionary");
			}
			paramDict[code] = value;
		}

		public void Add(byte code, object value)
		{
			if (paramDict.ContainsKey(code))
			{
				UnityEngine.Debug.LogWarning(code + " already exists as key in ParameterDictionary");
			}
			paramDict[code] = value;
		}

		public T Unwrap<T>(byte key)
		{
			object obj = paramDict[key];
			return obj.Unwrap<T>();
		}

		public T Get<T>(byte key)
		{
			object obj = paramDict[key];
			return obj.Get<T>();
		}

		public bool ContainsKey(byte key)
		{
			return paramDict.ContainsKey(key);
		}

		public object TryGetObject(byte key)
		{
			if (paramDict.TryGetValue(key, out var val))
			{
				return val;
			}
			return null;
		}

		public bool TryGetValue(byte key, out object value)
		{
			return paramDict.TryGetValue(key, out value);
		}

		public bool TryGetValue<T>(byte key, out T value) where T : struct
		{
			object val;
			bool flag = paramDict.TryGetValue(key, out val);
			if (!flag)
			{
				value = default(T);
				return false;
			}
			if (val is StructWrapper<T> structWrapper)
			{
				value = structWrapper.value;
			}
			else if (val is StructWrapper<object> structWrapper2)
			{
				value = (T)structWrapper2.value;
			}
			else
			{
				value = (T)val;
			}
			return flag;
		}

		public string ToStringFull(bool includeTypes = true)
		{
			if (includeTypes)
			{
				return $"(ParameterDictionary){SupportClass.DictionaryToString(paramDict, includeTypes)}";
			}
			return SupportClass.DictionaryToString(paramDict, includeTypes);
		}
	}
	internal static class PhotonCodes
	{
		internal static byte ClientKey = 1;

		internal static byte ModeKey = 2;

		internal static byte ServerKey = 1;

		internal static byte InitEncryption = 0;

		internal static byte Ping = 1;

		public const byte Ok = 0;
	}
	public enum ConnectionStateValue : byte
	{
		Disconnected = 0,
		Connecting = 1,
		Connected = 3,
		Disconnecting = 4,
		AcknowledgingDisconnect = 5,
		Zombie = 6
	}
	internal enum EgMessageType : byte
	{
		Init,
		InitResponse,
		Operation,
		OperationResponse,
		Event,
		DisconnectReason,
		InternalOperationRequest,
		InternalOperationResponse,
		Message,
		RawMessage
	}
	[Flags]
	internal enum InitV3Flags : short
	{
		NoFlags = 0,
		EncryptionFlag = 1,
		IPv6Flag = 2,
		ReleaseSdkFlag = 4
	}
	public abstract class PeerBase
	{
		internal delegate void MyAction();

		private static class GpBinaryV3Parameters
		{
			public const byte CustomObject = 0;

			public const byte ExtraPlatformParams = 1;
		}

		internal PhotonPeer photonPeer;

		public IProtocol SerializationProtocol;

		internal ConnectionProtocol usedTransportProtocol;

		internal IPhotonSocket PhotonSocket;

		internal ConnectionStateValue peerConnectionState;

		internal int ByteCountLastOperation;

		internal int ByteCountCurrentDispatch;

		internal NCommand CommandInCurrentDispatch;

		internal int packetLossByCrc;

		internal int packetLossByChallenge;

		internal readonly Queue<MyAction> ActionQueue = new Queue<MyAction>();

		internal short peerID = -1;

		internal int serverTimeOffset;

		internal bool serverTimeOffsetIsAvailable;

		internal int roundTripTime;

		internal int roundTripTimeVariance;

		internal int lastRoundTripTime;

		internal int lowestRoundTripTime;

		internal int highestRoundTripTimeVariance;

		internal int timestampOfLastReceive;

		internal static short peerCount;

		internal long bytesOut;

		internal long bytesIn;

		internal object PhotonToken;

		internal object CustomInitData;

		public string AppId;

		internal EventData reusableEventData;

		private Stopwatch watch = Stopwatch.StartNew();

		internal int timeoutInt;

		internal int timeLastAckReceive;

		internal int longestSentCall;

		internal int timeLastSendAck;

		internal int timeLastSendOutgoing;

		internal bool ApplicationIsInitialized;

		internal bool isEncryptionAvailable;

		internal int outgoingCommandsInStream = 0;

		protected internal static Queue<StreamBuffer> MessageBufferPool = new Queue<StreamBuffer>(32);

		internal byte[] messageHeader;

		internal ICryptoProvider CryptoProvider;

		private readonly System.Random lagRandomizer = new System.Random();

		internal readonly LinkedList<SimulationItem> NetSimListOutgoing = new LinkedList<SimulationItem>();

		internal readonly LinkedList<SimulationItem> NetSimListIncoming = new LinkedList<SimulationItem>();

		private readonly NetworkSimulationSet networkSimulationSettings = new NetworkSimulationSet();

		internal int TrafficPackageHeaderSize;

		public string ServerAddress { get; internal set; }

		public string ProxyServerAddress { get; internal set; }

		internal IPhotonPeerListener Listener => photonPeer.Listener;

		public DebugLevel debugOut => photonPeer.DebugOut;

		internal int DisconnectTimeout => photonPeer.DisconnectTimeout;

		internal int timePingInterval => photonPeer.TimePingInterval;

		internal byte ChannelCount => photonPeer.ChannelCount;

		internal long BytesOut => bytesOut;

		internal long BytesIn => bytesIn;

		internal abstract int QueuedIncomingCommandsCount { get; }

		internal abstract int QueuedOutgoingCommandsCount { get; }

		internal virtual int SentReliableCommandsCount => 0;

		public virtual string PeerID => ((ushort)peerID).ToString();

		internal int timeInt => (int)watch.ElapsedMilliseconds;

		internal static int outgoingStreamBufferSize => PhotonPeer.OutgoingStreamBufferSize;

		internal int mtu => photonPeer.MaximumTransferUnit;

		protected internal bool IsIpv6 => PhotonSocket != null && PhotonSocket.AddressResolvedAsIpv6;

		public NetworkSimulationSet NetworkSimulationSettings => networkSimulationSettings;

		internal bool TrafficStatsEnabled => photonPeer.TrafficStatsEnabled;

		internal TrafficStats TrafficStatsIncoming => photonPeer.TrafficStatsIncoming;

		internal TrafficStats TrafficStatsOutgoing => photonPeer.TrafficStatsOutgoing;

		internal TrafficStatsGameLevel TrafficStatsGameLevel => photonPeer.TrafficStatsGameLevel;

		protected PeerBase()
		{
			networkSimulationSettings.peerBase = this;
			peerCount++;
		}

		public static StreamBuffer MessageBufferPoolGet()
		{
			lock (MessageBufferPool)
			{
				if (MessageBufferPool.Count > 0)
				{
					return MessageBufferPool.Dequeue();
				}
				return new StreamBuffer(75);
			}
		}

		public static void MessageBufferPoolPut(StreamBuffer buff)
		{
			buff.Position = 0;
			buff.SetLength(0L);
			lock (MessageBufferPool)
			{
				MessageBufferPool.Enqueue(buff);
			}
		}

		internal virtual void Reset()
		{
			SerializationProtocol = SerializationProtocolFactory.Create(photonPeer.SerializationProtocolType);
			photonPeer.InitializeTrafficStats();
			ByteCountLastOperation = 0;
			ByteCountCurrentDispatch = 0;
			bytesIn = 0L;
			bytesOut = 0L;
			packetLossByCrc = 0;
			packetLossByChallenge = 0;
			networkSimulationSettings.LostPackagesIn = 0;
			networkSimulationSettings.LostPackagesOut = 0;
			lock (NetSimListOutgoing)
			{
				NetSimListOutgoing.Clear();
			}
			lock (NetSimListIncoming)
			{
				NetSimListIncoming.Clear();
			}
			lock (ActionQueue)
			{
				ActionQueue.Clear();
			}
			peerConnectionState = ConnectionStateValue.Disconnected;
			watch.Reset();
			watch.Start();
			isEncryptionAvailable = false;
			ApplicationIsInitialized = false;
			CryptoProvider = null;
			roundTripTime = 200;
			roundTripTimeVariance = 5;
			serverTimeOffsetIsAvailable = false;
			serverTimeOffset = 0;
		}

		internal abstract bool Connect(string serverAddress, string proxyServerAddress, string appID, object photonToken);

		private string GetHttpKeyValueString(Dictionary<string, string> dic)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<string, string> item in dic)
			{
				stringBuilder.Append(item.Key).Append("=").Append(item.Value)
					.Append("&");
			}
			return stringBuilder.ToString();
		}

		internal byte[] WriteInitRequest()
		{
			if (PhotonSocket == null || !PhotonSocket.Connected)
			{
				EnqueueDebugReturn(DebugLevel.WARNING, "The peer attempts to prepare an Init-Request but the socket is not connected!?");
			}
			if (photonPeer.UseInitV3)
			{
				return WriteInitV3();
			}
			if (PhotonToken == null)
			{
				byte[] array = new byte[41];
				byte[] clientVersion = Version.clientVersion;
				array[0] = 243;
				array[1] = 0;
				array[2] = SerializationProtocol.VersionBytes[0];
				array[3] = SerializationProtocol.VersionBytes[1];
				array[4] = photonPeer.ClientSdkIdShifted;
				array[5] = (byte)((byte)(clientVersion[0] << 4) | clientVersion[1]);
				array[6] = clientVersion[2];
				array[7] = clientVersion[3];
				array[8] = 0;
				if (string.IsNullOrEmpty(AppId))
				{
					AppId = "LoadBalancing";
				}
				for (int i = 0; i < 32; i++)
				{
					array[i + 9] = (byte)((i < AppId.Length) ? ((byte)AppId[i]) : 0);
				}
				if (IsIpv6)
				{
					array[5] |= 128;
				}
				else
				{
					array[5] &= 127;
				}
				return array;
			}
			if (PhotonToken != null)
			{
				byte[] array2 = null;
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				dictionary["init"] = null;
				dictionary["app"] = AppId;
				dictionary["clientversion"] = photonPeer.ClientVersion;
				dictionary["protocol"] = SerializationProtocol.ProtocolType;
				dictionary["sid"] = photonPeer.ClientSdkIdShifted.ToString();
				byte[] array3 = null;
				int num = 0;
				if (PhotonToken != null)
				{
					array3 = SerializationProtocol.Serialize(PhotonToken);
					num += array3.Length;
				}
				string text = GetHttpKeyValueString(dictionary);
				if (IsIpv6)
				{
					text += "&IPv6";
				}
				string text2 = $"POST /?{text} HTTP/1.1\r\nHost: {ServerAddress}\r\nContent-Length: {num}\r\n\r\n";
				array2 = new byte[text2.Length + num];
				if (array3 != null)
				{
					Buffer.BlockCopy(array3, 0, array2, text2.Length, array3.Length);
				}
				Buffer.BlockCopy(Encoding.UTF8.GetBytes(text2), 0, array2, 0, text2.Length);
				return array2;
			}
			return null;
		}

		private byte[] WriteInitV3()
		{
			StreamBuffer streamBuffer = new StreamBuffer();
			streamBuffer.WriteByte(245);
			InitV3Flags initV3Flags = InitV3Flags.NoFlags;
			if (IsIpv6)
			{
				initV3Flags |= InitV3Flags.IPv6Flag;
			}
			IPhotonEncryptor encryptor = photonPeer.Encryptor;
			if (encryptor != null)
			{
				initV3Flags |= InitV3Flags.EncryptionFlag;
			}
			streamBuffer.WriteBytes((byte)((int)initV3Flags >> 8), (byte)initV3Flags);
			switch (SerializationProtocol.VersionBytes[1])
			{
			case 6:
				streamBuffer.WriteByte(16);
				break;
			case 8:
				streamBuffer.WriteByte(18);
				break;
			default:
				throw new Exception("Unknown protocol version: " + SerializationProtocol.VersionBytes[1]);
			}
			streamBuffer.Write(Version.clientVersion, 0, 4);
			streamBuffer.WriteByte(photonPeer.ClientSdkIdShifted);
			streamBuffer.WriteByte(0);
			if (string.IsNullOrEmpty(AppId))
			{
				AppId = "Master";
			}
			byte[] bytes = Encoding.UTF8.GetBytes(AppId);
			int num = bytes.Length;
			if (num > 255)
			{
				throw new Exception("AppId is too long. Limited by 255 symbols.");
			}
			streamBuffer.WriteByte((byte)num);
			streamBuffer.Write(bytes, 0, bytes.Length);
			if (PhotonToken is byte[] array)
			{
				num = array.Length;
				streamBuffer.WriteBytes((byte)(num >> 8), (byte)num);
				streamBuffer.Write(array, 0, num);
			}
			else
			{
				streamBuffer.WriteBytes(0, 0);
			}
			Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
			if (CustomInitData != null)
			{
				dictionary.Add(0, CustomInitData);
			}
			if (encryptor != null)
			{
				throw new NotImplementedException("InitV3 with encryption is not implemented yet.");
			}
			SerializationProtocol.Serialize(streamBuffer, dictionary, setType: true);
			return streamBuffer.ToArray();
		}

		internal string PrepareWebSocketUrl(string serverAddress, string appId, object photonToken)
		{
			StringBuilder stringBuilder = new StringBuilder(1024);
			stringBuilder.Append(serverAddress);
			stringBuilder.AppendFormat("/?libversion={0}&sid={1}", photonPeer.ClientVersion, photonPeer.ClientSdkIdShifted);
			if (!photonPeer.RemoveAppIdFromWebSocketPath)
			{
				stringBuilder.AppendFormat("&app={0}", appId);
			}
			if (IsIpv6)
			{
				stringBuilder.Append("&IPv6");
			}
			if (photonToken != null)
			{
				stringBuilder.Append("&xInit=");
			}
			return stringBuilder.ToString();
		}

		public abstract void OnConnect();

		internal void InitCallback()
		{
			if (peerConnectionState == ConnectionStateValue.Connecting)
			{
				peerConnectionState = ConnectionStateValue.Connected;
			}
			ApplicationIsInitialized = true;
			FetchServerTimestamp();
			Listener.OnStatusChanged(StatusCode.Connect);
		}

		internal abstract void Disconnect();

		internal abstract void StopConnection();

		internal abstract void FetchServerTimestamp();

		internal abstract bool IsTransportEncrypted();

		internal abstract bool EnqueuePhotonMessage(StreamBuffer opBytes, SendOptions sendParams);

		internal StreamBuffer SerializeOperationToMessage(byte opCode, Dictionary<byte, object> parameters, EgMessageType messageType, bool encrypt)
		{
			bool flag = encrypt && !IsTransportEncrypted();
			StreamBuffer streamBuffer = MessageBufferPoolGet();
			streamBuffer.SetLength(0L);
			if (!flag)
			{
				streamBuffer.Write(messageHeader, 0, messageHeader.Length);
			}
			SerializationProtocol.SerializeOperationRequest(streamBuffer, opCode, parameters, setType: false);
			if (flag)
			{
				byte[] array = CryptoProvider.Encrypt(streamBuffer.GetBuffer(), 0, streamBuffer.Length);
				streamBuffer.SetLength(0L);
				streamBuffer.Write(messageHeader, 0, messageHeader.Length);
				streamBuffer.Write(array, 0, array.Length);
			}
			byte[] buffer = streamBuffer.GetBuffer();
			if (messageType != EgMessageType.Operation)
			{
				buffer[messageHeader.Length - 1] = (byte)messageType;
			}
			if (flag || (encrypt && photonPeer.EnableEncryptedFlag))
			{
				buffer[messageHeader.Length - 1] = (byte)(buffer[messageHeader.Length - 1] | 0x80);
			}
			return streamBuffer;
		}

		internal StreamBuffer SerializeOperationToMessage(byte opCode, ParameterDictionary parameters, EgMessageType messageType, bool encrypt)
		{
			bool flag = encrypt && !IsTransportEncrypted();
			StreamBuffer streamBuffer = MessageBufferPoolGet();
			streamBuffer.SetLength(0L);
			if (!flag)
			{
				streamBuffer.Write(messageHeader, 0, messageHeader.Length);
			}
			SerializationProtocol.SerializeOperationRequest(streamBuffer, opCode, parameters, setType: false);
			if (flag)
			{
				byte[] array = CryptoProvider.Encrypt(streamBuffer.GetBuffer(), 0, streamBuffer.Length);
				streamBuffer.SetLength(0L);
				streamBuffer.Write(messageHeader, 0, messageHeader.Length);
				streamBuffer.Write(array, 0, array.Length);
			}
			byte[] buffer = streamBuffer.GetBuffer();
			if (messageType != EgMessageType.Operation)
			{
				buffer[messageHeader.Length - 1] = (byte)messageType;
			}
			if (flag || (encrypt && photonPeer.EnableEncryptedFlag))
			{
				buffer[messageHeader.Length - 1] = (byte)(buffer[messageHeader.Length - 1] | 0x80);
			}
			return streamBuffer;
		}

		internal StreamBuffer SerializeMessageToMessage(object message, bool encrypt)
		{
			bool flag = encrypt && !IsTransportEncrypted();
			StreamBuffer streamBuffer = MessageBufferPoolGet();
			streamBuffer.SetLength(0L);
			if (!flag)
			{
				streamBuffer.Write(messageHeader, 0, messageHeader.Length);
			}
			bool flag2 = message is byte[];
			if (flag2)
			{
				byte[] array = message as byte[];
				streamBuffer.Write(array, 0, array.Length);
			}
			else
			{
				SerializationProtocol.SerializeMessage(streamBuffer, message);
			}
			if (flag)
			{
				byte[] array2 = CryptoProvider.Encrypt(streamBuffer.GetBuffer(), 0, streamBuffer.Length);
				streamBuffer.SetLength(0L);
				streamBuffer.Write(messageHeader, 0, messageHeader.Length);
				streamBuffer.Write(array2, 0, array2.Length);
			}
			byte[] buffer = streamBuffer.GetBuffer();
			buffer[messageHeader.Length - 1] = (byte)(flag2 ? 9 : 8);
			if (flag || (encrypt && photonPeer.EnableEncryptedFlag))
			{
				buffer[messageHeader.Length - 1] = (byte)(buffer[messageHeader.Length - 1] | 0x80);
			}
			return streamBuffer;
		}

		internal abstract bool SendOutgoingCommands();

		internal virtual bool SendAcksOnly()
		{
			return false;
		}

		internal abstract void ReceiveIncomingCommands(byte[] inBuff, int dataLength);

		internal abstract bool DispatchIncomingCommands();

		internal virtual bool DeserializeMessageAndCallback(StreamBuffer stream)
		{
			if (stream.Length < 2)
			{
				if ((int)debugOut >= 1)
				{
					Listener.DebugReturn(DebugLevel.ERROR, "Incoming UDP data too short! " + stream.Length);
				}
				return false;
			}
			byte b = stream.ReadByte();
			if (b != 243 && b != 253)
			{
				if ((int)debugOut >= 1)
				{
					Listener.DebugReturn(DebugLevel.ALL, "No regular operation UDP message: " + b);
				}
				return false;
			}
			byte b2 = stream.ReadByte();
			byte b3 = (byte)(b2 & 0x7F);
			bool flag = (b2 & 0x80) > 0;
			if (b3 != 1)
			{
				try
				{
					if (flag)
					{
						byte[] buf = CryptoProvider.Decrypt(stream.GetBuffer(), 2, stream.Length - 2);
						stream = new StreamBuffer(buf);
					}
					else
					{
						stream.Seek(2L, SeekOrigin.Begin);
					}
				}
				catch (Exception ex)
				{
					if ((int)debugOut >= 1)
					{
						Listener.DebugReturn(DebugLevel.ERROR, "msgType: " + b3 + " exception: " + ex.ToString());
					}
					SupportClass.WriteStackTrace(ex);
					return false;
				}
			}
			int num = 0;
			IProtocol.DeserializationFlags flags = (IProtocol.DeserializationFlags)((photonPeer.UseByteArraySlicePoolForEvents ? 1 : 0) | (photonPeer.WrapIncomingStructs ? 2 : 0));
			switch (b3)
			{
			case 3:
			{
				OperationResponse operationResponse = null;
				try
				{
					operationResponse = SerializationProtocol.DeserializeOperationResponse(stream, flags);
				}
				catch (Exception ex5)
				{
					EnqueueDebugReturn(DebugLevel.ERROR, "Deserialization failed for Operation Response. " + ex5);
					return false;
				}
				if (TrafficStatsEnabled)
				{
					TrafficStatsGameLevel.CountResult(ByteCountCurrentDispatch);
					num = timeInt;
				}
				Listener.OnOperationResponse(operationResponse);
				if (TrafficStatsEnabled)
				{
					TrafficStatsGameLevel.TimeForResponseCallback(operationResponse.OperationCode, timeInt - num);
				}
				break;
			}
			case 4:
			{
				EventData eventData = null;
				try
				{
					eventData = SerializationProtocol.DeserializeEventData(stream, reusableEventData, flags);
				}
				catch (Exception ex4)
				{
					EnqueueDebugReturn(DebugLevel.ERROR, "Deserialization failed for Event. " + ex4);
					return false;
				}
				if (TrafficStatsEnabled)
				{
					TrafficStatsGameLevel.CountEvent(ByteCountCurrentDispatch);
					num = timeInt;
				}
				Listener.OnEvent(eventData);
				if (TrafficStatsEnabled)
				{
					TrafficStatsGameLevel.TimeForEventCallback(eventData.Code, timeInt - num);
				}
				if (photonPeer.ReuseEventInstance)
				{
					reusableEventData = eventData;
				}
				break;
			}
			case 5:
				try
				{
					DisconnectMessage dm = SerializationProtocol.DeserializeDisconnectMessage(stream);
					photonPeer.OnDisconnectMessageCall(dm);
				}
				catch (Exception ex3)
				{
					EnqueueDebugReturn(DebugLevel.ERROR, "Deserialization failed for disconnect message. " + ex3);
					return false;
				}
				break;
			case 1:
				InitCallback();
				break;
			case 7:
			{
				OperationResponse operationResponse;
				try
				{
					operationResponse = SerializationProtocol.DeserializeOperationResponse(stream);
				}
				catch (Exception ex2)
				{
					EnqueueDebugReturn(DebugLevel.ERROR, "Deserialization failed for internal Operation Response. " + ex2);
					return false;
				}
				if (TrafficStatsEnabled)
				{
					TrafficStatsGameLevel.CountResult(ByteCountCurrentDispatch);
					num = timeInt;
				}
				if (operationResponse.OperationCode == PhotonCodes.InitEncryption)
				{
					DeriveSharedKey(operationResponse);
				}
				else if (operationResponse.OperationCode == PhotonCodes.Ping)
				{
					if (peerConnectionState == ConnectionStateValue.Connecting && (usedTransportProtocol == ConnectionProtocol.WebSocket || usedTransportProtocol == ConnectionProtocol.WebSocketSecure))
					{
						photonPeer.PingUsedAsInit = true;
						InitCallback();
					}
					if (this is TPeer tPeer)
					{
						tPeer.ReadPingResult(operationResponse);
					}
				}
				else
				{
					EnqueueDebugReturn(DebugLevel.ERROR, "Received unknown internal operation. " + operationResponse.ToStringFull());
				}
				if (TrafficStatsEnabled)
				{
					TrafficStatsGameLevel.TimeForResponseCallback(operationResponse.OperationCode, timeInt - num);
				}
				break;
			}
			case 8:
			{
				object obj = SerializationProtocol.DeserializeMessage(stream);
				if (TrafficStatsEnabled)
				{
					TrafficStatsGameLevel.CountEvent(ByteCountCurrentDispatch);
					num = timeInt;
				}
				if (TrafficStatsEnabled)
				{
					TrafficStatsGameLevel.TimeForMessageCallback(timeInt - num);
				}
				break;
			}
			case 9:
			{
				if (TrafficStatsEnabled)
				{
					TrafficStatsGameLevel.CountEvent(ByteCountCurrentDispatch);
					num = timeInt;
				}
				byte[] array = stream.ToArrayFromPos();
				if (TrafficStatsEnabled)
				{
					TrafficStatsGameLevel.TimeForRawMessageCallback(timeInt - num);
				}
				break;
			}
			default:
				EnqueueDebugReturn(DebugLevel.ERROR, "unexpected msgType " + b3);
				break;
			}
			return true;
		}

		internal void UpdateRoundTripTimeAndVariance(int lastRoundtripTime)
		{
			if (lastRoundtripTime >= 0)
			{
				roundTripTimeVariance -= roundTripTimeVariance / 4;
				if (lastRoundtripTime >= roundTripTime)
				{
					roundTripTime += (lastRoundtripTime - roundTripTime) / 8;
					roundTripTimeVariance += (lastRoundtripTime - roundTripTime) / 4;
				}
				else
				{
					roundTripTime += (lastRoundtripTime - roundTripTime) / 8;
					roundTripTimeVariance -= (lastRoundtripTime - roundTripTime) / 4;
				}
				if (roundTripTime < lowestRoundTripTime)
				{
					lowestRoundTripTime = roundTripTime;
				}
				if (roundTripTimeVariance > highestRoundTripTimeVariance)
				{
					highestRoundTripTimeVariance = roundTripTimeVariance;
				}
			}
		}

		internal bool ExchangeKeysForEncryption(object lockObject)
		{
			isEncryptionAvailable = false;
			if (CryptoProvider != null)
			{
				CryptoProvider.Dispose();
				CryptoProvider = null;
			}
			if (photonPeer.PayloadEncryptorType != null)
			{
				try
				{
					CryptoProvider = (ICryptoProvider)Activator.CreateInstance(photonPeer.PayloadEncryptorType);
					if (CryptoProvider == null)
					{
						Listener.DebugReturn(DebugLevel.WARNING, "Payload encryptor creation by type failed, Activator.CreateInstance() returned null for: " + photonPeer.PayloadEncryptorType);
					}
				}
				catch (Exception ex)
				{
					Listener.DebugReturn(DebugLevel.WARNING, "Payload encryptor creation by type failed: " + ex);
				}
			}
			if (CryptoProvider == null)
			{
				CryptoProvider = new DiffieHellmanCryptoProvider();
			}
			Dictionary<byte, object> dictionary = new Dictionary<byte, object>(1);
			dictionary[PhotonCodes.ClientKey] = CryptoProvider.PublicKey;
			if (lockObject != null)
			{
				lock (lockObject)
				{
					SendOptions sendParams = new SendOptions
					{
						Channel = 0,
						Encrypt = false,
						DeliveryMode = DeliveryMode.Reliable
					};
					StreamBuffer opBytes = SerializeOperationToMessage(PhotonCodes.InitEncryption, dictionary, EgMessageType.InternalOperationRequest, sendParams.Encrypt);
					return EnqueuePhotonMessage(opBytes, sendParams);
				}
			}
			SendOptions sendParams2 = new SendOptions
			{
				Channel = 0,
				Encrypt = false,
				DeliveryMode = DeliveryMode.Reliable
			};
			StreamBuffer opBytes2 = SerializeOperationToMessage(PhotonCodes.InitEncryption, dictionary, EgMessageType.InternalOperationRequest, sendParams2.Encrypt);
			return EnqueuePhotonMessage(opBytes2, sendParams2);
		}

		internal void DeriveSharedKey(OperationResponse operationResponse)
		{
			if (operationResponse.ReturnCode != 0)
			{
				EnqueueDebugReturn(DebugLevel.ERROR, "Establishing encryption keys failed. " + operationResponse.ToStringFull());
				EnqueueStatusCallback(StatusCode.EncryptionFailedToEstablish);
				return;
			}
			byte[] array = (byte[])operationResponse.Parameters[PhotonCodes.ServerKey];
			if (array == null || array.Length == 0)
			{
				EnqueueDebugReturn(DebugLevel.ERROR, "Establishing encryption keys failed. Server's public key is null or empty. " + operationResponse.ToStringFull());
				EnqueueStatusCallback(StatusCode.EncryptionFailedToEstablish);
			}
			else
			{
				CryptoProvider.DeriveSharedKey(array);
				isEncryptionAvailable = true;
				EnqueueStatusCallback(StatusCode.EncryptionEstablished);
			}
		}

		internal virtual void InitEncryption(byte[] secret)
		{
			if (photonPeer.PayloadEncryptorType != null)
			{
				try
				{
					CryptoProvider = (ICryptoProvider)Activator.CreateInstance(photonPeer.PayloadEncryptorType, secret);
					if (CryptoProvider == null)
					{
						Listener.DebugReturn(DebugLevel.WARNING, "Payload encryptor creation by type failed, Activator.CreateInstance() returned null for: " + photonPeer.PayloadEncryptorType);
					}
					else
					{
						isEncryptionAvailable = true;
					}
				}
				catch (Exception ex)
				{
					Listener.DebugReturn(DebugLevel.WARNING, "Payload encryptor creation by type failed: " + ex);
				}
			}
			if (CryptoProvider == null)
			{
				CryptoProvider = new DiffieHellmanCryptoProvider(secret);
				isEncryptionAvailable = true;
			}
		}

		internal void EnqueueActionForDispatch(MyAction action)
		{
			lock (ActionQueue)
			{
				ActionQueue.Enqueue(action);
			}
		}

		internal void EnqueueDebugReturn(DebugLevel level, string debugReturn)
		{
			lock (ActionQueue)
			{
				ActionQueue.Enqueue(delegate
				{
					Listener.DebugReturn(level, debugReturn);
				});
			}
		}

		internal void EnqueueStatusCallback(StatusCode statusValue)
		{
			lock (ActionQueue)
			{
				ActionQueue.Enqueue(delegate
				{
					Listener.OnStatusChanged(statusValue);
				});
			}
		}

		internal void SendNetworkSimulated(byte[] dataToSend)
		{
			if (!NetworkSimulationSettings.IsSimulationEnabled)
			{
				throw new NotImplementedException("SendNetworkSimulated was called, despite NetworkSimulationSettings.IsSimulationEnabled == false.");
			}
			if (usedTransportProtocol == ConnectionProtocol.Udp && NetworkSimulationSettings.OutgoingLossPercentage > 0 && lagRandomizer.Next(101) < NetworkSimulationSettings.OutgoingLossPercentage)
			{
				networkSimulationSettings.LostPackagesOut++;
				return;
			}
			int num = ((networkSimulationSettings.OutgoingJitter > 0) ? (lagRandomizer.Next(networkSimulationSettings.OutgoingJitter * 2) - networkSimulationSettings.OutgoingJitter) : 0);
			int num2 = networkSimulationSettings.OutgoingLag + num;
			int num3 = timeInt + num2;
			SimulationItem value = new SimulationItem
			{
				DelayedData = dataToSend,
				TimeToExecute = num3,
				Delay = num2
			};
			lock (NetSimListOutgoing)
			{
				if (NetSimListOutgoing.Count == 0 || usedTransportProtocol == ConnectionProtocol.Tcp)
				{
					NetSimListOutgoing.AddLast(value);
					return;
				}
				LinkedListNode<SimulationItem> linkedListNode = NetSimListOutgoing.First;
				while (linkedListNode != null && linkedListNode.Value.TimeToExecute < num3)
				{
					linkedListNode = linkedListNode.Next;
				}
				if (linkedListNode == null)
				{
					NetSimListOutgoing.AddLast(value);
				}
				else
				{
					NetSimListOutgoing.AddBefore(linkedListNode, value);
				}
			}
		}

		internal void ReceiveNetworkSimulated(byte[] dataReceived)
		{
			if (!networkSimulationSettings.IsSimulationEnabled)
			{
				throw new NotImplementedException("ReceiveNetworkSimulated was called, despite NetworkSimulationSettings.IsSimulationEnabled == false.");
			}
			if (usedTransportProtocol == ConnectionProtocol.Udp && networkSimulationSettings.IncomingLossPercentage > 0 && lagRandomizer.Next(101) < networkSimulationSettings.IncomingLossPercentage)
			{
				networkSimulationSettings.LostPackagesIn++;
				return;
			}
			int num = ((networkSimulationSettings.IncomingJitter > 0) ? (lagRandomizer.Next(networkSimulationSettings.IncomingJitter * 2) - networkSimulationSettings.IncomingJitter) : 0);
			int num2 = networkSimulationSettings.IncomingLag + num;
			int num3 = timeInt + num2;
			SimulationItem value = new SimulationItem
			{
				DelayedData = dataReceived,
				TimeToExecute = num3,
				Delay = num2
			};
			lock (NetSimListIncoming)
			{
				if (NetSimListIncoming.Count == 0 || usedTransportProtocol == ConnectionProtocol.Tcp)
				{
					NetSimListIncoming.AddLast(value);
					return;
				}
				LinkedListNode<SimulationItem> linkedListNode = NetSimListIncoming.First;
				while (linkedListNode != null && linkedListNode.Value.TimeToExecute < num3)
				{
					linkedListNode = linkedListNode.Next;
				}
				if (linkedListNode == null)
				{
					NetSimListIncoming.AddLast(value);
				}
				else
				{
					NetSimListIncoming.AddBefore(linkedListNode, value);
				}
			}
		}

		protected internal void NetworkSimRun()
		{
			while (true)
			{
				bool flag = false;
				lock (networkSimulationSettings.NetSimManualResetEvent)
				{
					flag = networkSimulationSettings.IsSimulationEnabled;
				}
				if (!flag)
				{
					networkSimulationSettings.NetSimManualResetEvent.WaitOne();
					continue;
				}
				lock (NetSimListIncoming)
				{
					SimulationItem simulationItem = null;
					while (NetSimListIncoming.First != null)
					{
						simulationItem = NetSimListIncoming.First.Value;
						if (simulationItem.stopw.ElapsedMilliseconds < simulationItem.Delay)
						{
							break;
						}
						ReceiveIncomingCommands(simulationItem.DelayedData, simulationItem.DelayedData.Length);
						NetSimListIncoming.RemoveFirst();
					}
				}
				lock (NetSimListOutgoing)
				{
					SimulationItem simulationItem2 = null;
					while (NetSimListOutgoing.First != null)
					{
						simulationItem2 = NetSimListOutgoing.First.Value;
						if (simulationItem2.stopw.ElapsedMilliseconds < simulationItem2.Delay)
						{
							break;
						}
						if (PhotonSocket != null && PhotonSocket.Connected)
						{
							PhotonSocket.Send(simulationItem2.DelayedData, simulationItem2.DelayedData.Length);
						}
						NetSimListOutgoing.RemoveFirst();
					}
				}
				Thread.Sleep(0);
			}
		}
	}
	public class PhotonClientWebSocket : IPhotonSocket
	{
		private ClientWebSocket clientWebSocket;

		private Task sendTask;

		[Preserve]
		public PhotonClientWebSocket(PeerBase peerBase)
			: base(peerBase)
		{
			if (ReportDebugOfLevel(DebugLevel.INFO))
			{
				EnqueueDebugReturn(DebugLevel.INFO, "PhotonClientWebSocket");
			}
		}

		public override bool Connect()
		{
			if (!base.Connect())
			{
				return false;
			}
			base.State = PhotonSocketState.Connecting;
			Thread thread = new Thread(AsyncConnectAndReceive);
			thread.IsBackground = true;
			thread.Start();
			return true;
		}

		private void AsyncConnectAndReceive()
		{
			Uri uri = null;
			try
			{
				uri = new Uri(ConnectAddress);
			}
			catch (Exception ex)
			{
				if (ReportDebugOfLevel(DebugLevel.ERROR))
				{
					base.Listener.DebugReturn(DebugLevel.ERROR, "Failed to create a URI from ConnectAddress (" + ConnectAddress + "). Exception: " + ex);
				}
			}
			if (uri != null && uri.HostNameType == UriHostNameType.Dns)
			{
				try
				{
					IPAddress[] hostAddresses = Dns.GetHostAddresses(uri.Host);
					IPAddress[] array = hostAddresses;
					foreach (IPAddress iPAddress in array)
					{
						if (iPAddress.AddressFamily == AddressFamily.InterNetworkV6)
						{
							base.AddressResolvedAsIpv6 = true;
							ConnectAddress += "&IPv6";
							break;
						}
					}
				}
				catch (Exception ex2)
				{
					base.Listener.DebugReturn(DebugLevel.INFO, "Dns.GetHostAddresses(" + uri.Host + ") failed: " + ex2);
				}
			}
			clientWebSocket = new ClientWebSocket();
			clientWebSocket.Options.AddSubProtocol(base.SerializationProtocol);
			CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(7000);
			Task task = clientWebSocket.ConnectAsync(new Uri(ConnectAddress), cancellationTokenSource.Token);
			try
			{
				task.Wait();
			}
			catch (Exception arg)
			{
				EnqueueDebugReturn(DebugLevel.ERROR, $"AsyncConnectAndReceive() caught exception on {ConnectAddress}: {arg}");
			}
			if (task.IsFaulted)
			{
				EnqueueDebugReturn(DebugLevel.ERROR, "ClientWebSocket IsFaulted: " + task.Exception);
			}
			if (clientWebSocket.State != WebSocketState.Open)
			{
				base.SocketErrorCode = (int)(clientWebSocket.CloseStatus.HasValue ? clientWebSocket.CloseStatus.Value : ((WebSocketCloseStatus)0));
				EnqueueDebugReturn(DebugLevel.ERROR, "ClientWebSocket is not open. State: " + clientWebSocket.State.ToString() + " CloseStatus: " + clientWebSocket.CloseStatus.ToString() + " Description: " + clientWebSocket.CloseStatusDescription);
				HandleException(StatusCode.ExceptionOnConnect);
				return;
			}
			base.State = PhotonSocketState.Connected;
			peerBase.OnConnect();
			MemoryStream memoryStream = new MemoryStream(base.MTU);
			bool flag = false;
			ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[base.MTU]);
			while (clientWebSocket.State == WebSocketState.Open)
			{
				Task<WebSocketReceiveResult> task2 = null;
				try
				{
					task2 = clientWebSocket.ReceiveAsync(buffer, CancellationToken.None);
					while (!task2.IsCompleted)
					{
						task2.Wait(50);
					}
				}
				catch (Exception)
				{
				}
				if (!task2.IsCompleted || clientWebSocket.State != WebSocketState.Open)
				{
					continue;
				}
				if (task2.IsCanceled)
				{
					EnqueueDebugReturn(DebugLevel.ERROR, "PhotonClientWebSocket readTask.IsCanceled: " + task2.Status.ToString() + " " + base.ServerAddress + ":" + base.ServerPort + " " + clientWebSocket.CloseStatusDescription);
					continue;
				}
				if (task2.Result.Count == 0)
				{
					EnqueueDebugReturn(DebugLevel.INFO, "PhotonClientWebSocket received 0 bytes. this.State: " + base.State.ToString() + " clientWebSocket.State: " + clientWebSocket.State.ToString() + " readTask.Status: " + task2.Status);
					continue;
				}
				if (!task2.Result.EndOfMessage)
				{
					flag = true;
					memoryStream.Write(buffer.Array, 0, task2.Result.Count);
					continue;
				}
				int num;
				byte[] array2;
				bool flag2;
				if (flag)
				{
					memoryStream.Write(buffer.Array, 0, task2.Result.Count);
					num = (int)memoryStream.Length;
					array2 = memoryStream.GetBuffer();
				}
				else
				{
					num = task2.Result.Count;
					array2 = buffer.Array;
					flag2 = array2[5] == 0;
				}
				flag2 = array2[5] == 0;
				HandleReceivedDatagram(array2, num, willBeReused: true);
				if (flag)
				{
					memoryStream.SetLength(0L);
					memoryStream.Position = 0L;
					flag = false;
				}
				if (peerBase.TrafficStatsEnabled)
				{
					if (flag2)
					{
						peerBase.TrafficStatsIncoming.CountReliableOpCommand(num);
					}
					else
					{
						peerBase.TrafficStatsIncoming.CountUnreliableOpCommand(num);
					}
				}
			}
			if (base.State != PhotonSocketState.Disconnecting && base.State != PhotonSocketState.Disconnected)
			{
				EnqueueDebugReturn(DebugLevel.INFO, "PhotonSocket.State is " + base.State.ToString() + " but can't receive anymore. ClientWebSocket.State: " + clientWebSocket.State);
				if (clientWebSocket.State == WebSocketState.CloseReceived)
				{
					HandleException(StatusCode.DisconnectByServerLogic);
				}
				if (clientWebSocket.State == WebSocketState.Aborted)
				{
					HandleException(StatusCode.DisconnectByServerReasonUnknown);
				}
			}
			Disconnect();
		}

		public override bool Disconnect()
		{
			if (clientWebSocket != null && clientWebSocket.State == WebSocketState.CloseReceived)
			{
				try
				{
					clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "CloseAsync due to state CloseReceived", CancellationToken.None);
				}
				catch (Exception ex)
				{
					if (ReportDebugOfLevel(DebugLevel.ALL))
					{
						EnqueueDebugReturn(DebugLevel.ALL, "Caught exception in clientWebSocket.CloseAsync(): " + ex);
					}
				}
				base.State = PhotonSocketState.Disconnected;
				return true;
			}
			if (clientWebSocket != null && clientWebSocket.State != WebSocketState.Closed && clientWebSocket.State != WebSocketState.CloseSent)
			{
				base.State = PhotonSocketState.Disconnecting;
				try
				{
					clientWebSocket.CloseOutputAsync(WebSocketCloseStatus.NormalClosure, "ws close", CancellationToken.None);
				}
				catch (Exception ex2)
				{
					if (ReportDebugOfLevel(DebugLevel.ALL))
					{
						EnqueueDebugReturn(DebugLevel.ALL, "Caught exception in clientWebSocket.CloseOutputAsync(): " + ex2);
					}
				}
			}
			base.State = PhotonSocketState.Disconnected;
			return true;
		}

		public override PhotonSocketError Send(byte[] data, int length)
		{
			if (clientWebSocket != null && clientWebSocket.State != WebSocketState.Open && base.State != PhotonSocketState.Disconnecting && base.State != PhotonSocketState.Disconnected)
			{
				if (clientWebSocket.State == WebSocketState.CloseReceived)
				{
					HandleException(StatusCode.DisconnectByServerLogic);
					return PhotonSocketError.Exception;
				}
				if (clientWebSocket.State == WebSocketState.Aborted)
				{
					HandleException(StatusCode.DisconnectByServerReasonUnknown);
					return PhotonSocketError.Exception;
				}
			}
			if (clientWebSocket == null)
			{
				if (base.State == PhotonSocketState.Disconnecting || base.State == PhotonSocketState.Disconnected)
				{
					return PhotonSocketError.Skipped;
				}
				if (ReportDebugOfLevel(DebugLevel.ERROR))
				{
					EnqueueDebugReturn(DebugLevel.ERROR, $"PhotonClientWebSocket.Send() failed: this.clientWebSocket is null. this.State: {base.State}");
				}
				return PhotonSocketError.Exception;
			}
			if (sendTask != null && !sendTask.IsCompleted && !sendTask.Wait(5))
			{
				return PhotonSocketError.Busy;
			}
			sendTask = clientWebSocket.SendAsync(new ArraySegment<byte>(data, 0, length), WebSocketMessageType.Binary, endOfMessage: true, CancellationToken.None);
			if (sendTask != null && !sendTask.IsCompleted && !sendTask.Wait(5))
			{
				return PhotonSocketError.PendingSend;
			}
			sendTask = null;
			return PhotonSocketError.Success;
		}

		public override PhotonSocketError Receive(out byte[] data)
		{
			throw new NotImplementedException();
		}
	}
	public enum PeerStateValue : byte
	{
		Disconnected = 0,
		Connecting = 1,
		InitializingApplication = 10,
		Connected = 3,
		Disconnecting = 4
	}
	public enum ConnectionProtocol : byte
	{
		Udp = 0,
		Tcp = 1,
		WebSocket = 4,
		WebSocketSecure = 5
	}
	public enum DebugLevel : byte
	{
		OFF = 0,
		ERROR = 1,
		WARNING = 2,
		INFO = 3,
		ALL = 5
	}
	public enum TargetFrameworks
	{
		Unknown,
		Net35,
		NetStandard20,
		Metro,
		NetStandard21
	}
	public class PhotonPeer
	{
		[Obsolete("Check QueuedOutgoingCommands and QueuedIncomingCommands on demand instead.")]
		public int WarningSize;

		[Obsolete("Where dynamic linking is available, this library will attempt to load it and fallback to a managed implementation. This value is always true.")]
		public const bool NativeDatagramEncrypt = true;

		[Obsolete("Use the ITrafficRecorder to capture all traffic instead.")]
		public int CommandLogSize;

		public const bool NoSocket = false;

		public const bool DebugBuild = true;

		public const int NativeEncryptorApiVersion = 2;

		public TargetFrameworks TargetFramework = TargetFrameworks.NetStandard20;

		public static bool NoNativeCallbacks;

		public bool RemoveAppIdFromWebSocketPath;

		public byte ClientSdkId = 15;

		private static string clientVersion;

		[Obsolete("A Native Socket implementation is no longer part of this DLL but delivered in a separate add-on. This value always returns false.")]
		public static readonly bool NativeSocketLibAvailable = false;

		[Obsolete("Native Payload Encryption is no longer part of this DLL but delivered in a separate add-on. This value always returns false.")]
		public static readonly bool NativePayloadEncryptionLibAvailable = false;

		[Obsolete("Native Datagram Encryption is no longer part of this DLL but delivered in a separate add-on. This value always returns false.")]
		public static readonly bool NativeDatagramEncryptionLibAvailable = false;

		internal bool UseInitV3;

		public Dictionary<ConnectionProtocol, Type> SocketImplementationConfig;

		public DebugLevel DebugOut = DebugLevel.ERROR;

		private bool reuseEventInstance;

		private bool useByteArraySlicePoolForEvents = false;

		private bool wrapIncomingStructs = false;

		public bool SendInCreationOrder = true;

		public int SendWindowSize = 50;

		public ITrafficRecorder TrafficRecorder;

		private byte quickResendAttempts;

		public byte ChannelCount = 2;

		public bool EnableEncryptedFlag = false;

		private bool crcEnabled;

		public int SentCountAllowance = 7;

		public int InitialResendTimeMax = 400;

		public int TimePingInterval = 1000;

		public bool PingUsedAsInit = false;

		private int disconnectTimeout = 10000;

		public static int OutgoingStreamBufferSize = 1200;

		private int mtu = 1200;

		public static bool AsyncKeyExchange = false;

		internal bool RandomizeSequenceNumbers;

		internal byte[] RandomizedSequenceNumbers;

		internal bool GcmDatagramEncryption;

		private Stopwatch trafficStatsStopwatch;

		private bool trafficStatsEnabled = false;

		internal PeerBase peerBase;

		private readonly object SendOutgoingLockObject = new object();

		private readonly object DispatchLockObject = new object();

		private readonly object EnqueueLock = new object();

		private Type payloadEncryptorType;

		protected internal byte[] PayloadEncryptionSecret;

		private Type encryptorType;

		protected internal IPhotonEncryptor Encryptor;

		[Obsolete("See remarks.")]
		public int CommandBufferSize { get; set; }

		[Obsolete("See remarks.")]
		public int LimitOfUnreliableCommands { get; set; }

		[Obsolete("Returns SupportClass.GetTickCount(). Should be replaced by a StopWatch or the per peer PhotonPeer.ClientTime.")]
		public int LocalTimeInMilliSeconds => SupportClass.GetTickCount();

		protected internal byte ClientSdkIdShifted => (byte)((ClientSdkId << 1) | 0);

		[Obsolete("The static string Version should be preferred.")]
		public string ClientVersion
		{
			get
			{
				if (string.IsNullOrEmpty(clientVersion))
				{
					clientVersion = $"{ExitGames.Client.Photon.Version.clientVersion[0]}.{ExitGames.Client.Photon.Version.clientVersion[1]}.{ExitGames.Client.Photon.Version.clientVersion[2]}.{ExitGames.Client.Photon.Version.clientVersion[3]}";
				}
				return clientVersion;
			}
		}

		public static string Version
		{
			get
			{
				if (string.IsNullOrEmpty(clientVersion))
				{
					clientVersion = $"{ExitGames.Client.Photon.Version.clientVersion[0]}.{ExitGames.Client.Photon.Version.clientVersion[1]}.{ExitGames.Client.Photon.Version.clientVersion[2]}.{ExitGames.Client.Photon.Version.clientVersion[3]}";
				}
				return clientVersion;
			}
		}

		public SerializationProtocol SerializationProtocolType { get; set; }

		public Type SocketImplementation { get; internal set; }

		public int SocketErrorCode => (peerBase != null && peerBase.PhotonSocket != null) ? peerBase.PhotonSocket.SocketErrorCode : 0;

		public IPhotonPeerListener Listener { get; protected set; }

		public bool ReuseEventInstance
		{
			get
			{
				return reuseEventInstance;
			}
			set
			{
				lock (DispatchLockObject)
				{
					reuseEventInstance = value;
					if (!value)
					{
						peerBase.reusableEventData = null;
					}
				}
			}
		}

		public bool UseByteArraySlicePoolForEvents
		{
			get
			{
				return useByteArraySlicePoolForEvents;
			}
			set
			{
				useByteArraySlicePoolForEvents = value;
			}
		}

		public bool WrapIncomingStructs
		{
			get
			{
				return wrapIncomingStructs;
			}
			set
			{
				wrapIncomingStructs = value;
			}
		}

		public ByteArraySlicePool ByteArraySlicePool => peerBase.SerializationProtocol.ByteArraySlicePool;

		[Obsolete("Use SendWindowSize instead.")]
		public int SequenceDeltaLimitSends
		{
			get
			{
				return SendWindowSize;
			}
			set
			{
				SendWindowSize = value;
			}
		}

		public long BytesIn => peerBase.BytesIn;

		public long BytesOut => peerBase.BytesOut;

		public int ByteCountCurrentDispatch => peerBase.ByteCountCurrentDispatch;

		public string CommandInfoCurrentDispatch => (peerBase.CommandInCurrentDispatch != null) ? peerBase.CommandInCurrentDispatch.ToString() : string.Empty;

		public int ByteCountLastOperation => peerBase.ByteCountLastOperation;

		public bool EnableServerTracing { get; set; }

		public byte QuickResendAttempts
		{
			get
			{
				return quickResendAttempts;
			}
			set
			{
				quickResendAttempts = value;
				if (quickResendAttempts > 4)
				{
					quickResendAttempts = 4;
				}
			}
		}

		public PeerStateValue PeerState
		{
			get
			{
				if (peerBase.peerConnectionState == ConnectionStateValue.Connected && !peerBase.ApplicationIsInitialized)
				{
					return PeerStateValue.InitializingApplication;
				}
				return (PeerStateValue)peerBase.peerConnectionState;
			}
		}

		public string PeerID => peerBase.PeerID;

		public int QueuedIncomingCommands => peerBase.QueuedIncomingCommandsCount;

		public int QueuedOutgoingCommands => peerBase.QueuedOutgoingCommandsCount;

		public bool CrcEnabled
		{
			get
			{
				return crcEnabled;
			}
			set
			{
				if (crcEnabled != value)
				{
					if (peerBase.peerConnectionState != ConnectionStateValue.Disconnected)
					{
						throw new Exception("CrcEnabled can only be set while disconnected.");
					}
					crcEnabled = value;
				}
			}
		}

		public int PacketLossByCrc => peerBase.packetLossByCrc;

		public int PacketLossByChallenge => peerBase.packetLossByChallenge;

		public int SentReliableCommandsCount => peerBase.SentReliableCommandsCount;

		public int ResentReliableCommands => (UsedProtocol == ConnectionProtocol.Udp) ? ((EnetPeer)peerBase).reliableCommandsRepeated : 0;

		public int DisconnectTimeout
		{
			get
			{
				return disconnectTimeout;
			}
			set
			{
				if (value < 0)
				{
					disconnectTimeout = 10000;
				}
				disconnectTimeout = value;
			}
		}

		public int ServerTimeInMilliSeconds => peerBase.serverTimeOffsetIsAvailable ? (peerBase.serverTimeOffset + ConnectionTime) : 0;

		[Obsolete("The PhotonPeer will no longer use this delegate. It uses a Stopwatch in all cases. You can access PhotonPeer.ConnectionTime.")]
		public SupportClass.IntegerMillisecondsDelegate LocalMsTimestampDelegate
		{
			set
			{
				if (PeerState != PeerStateValue.Disconnected)
				{
					throw new Exception("LocalMsTimestampDelegate only settable while disconnected. State: " + PeerState);
				}
				SupportClass.IntegerMilliseconds = value;
			}
		}

		public int ConnectionTime => peerBase.timeInt;

		public int LastSendAckTime => peerBase.timeLastSendAck;

		public int LastSendOutgoingTime => peerBase.timeLastSendOutgoing;

		public int LongestSentCall
		{
			get
			{
				return peerBase.longestSentCall;
			}
			set
			{
				peerBase.longestSentCall = value;
			}
		}

		public int RoundTripTime => peerBase.roundTripTime;

		public int RoundTripTimeVariance => peerBase.roundTripTimeVariance;

		public int LastRoundTripTime => peerBase.lastRoundTripTime;

		public int TimestampOfLastSocketReceive => peerBase.timestampOfLastReceive;

		public string ServerAddress => peerBase.ServerAddress;

		public string ServerIpAddress => IPhotonSocket.ServerIpAddress;

		public ConnectionProtocol UsedProtocol => peerBase.usedTransportProtocol;

		public ConnectionProtocol TransportProtocol { get; set; }

		public virtual bool IsSimulationEnabled
		{
			get
			{
				return NetworkSimulationSettings.IsSimulationEnabled;
			}
			set
			{
				if (value == NetworkSimulationSettings.IsSimulationEnabled)
				{
					return;
				}
				lock (SendOutgoingLockObject)
				{
					NetworkSimulationSettings.IsSimulationEnabled = value;
				}
			}
		}

		public NetworkSimulationSet NetworkSimulationSettings => peerBase.NetworkSimulationSettings;

		public int MaximumTransferUnit
		{
			get
			{
				return mtu;
			}
			set
			{
				if (PeerState != PeerStateValue.Disconnected)
				{
					throw new Exception("MaximumTransferUnit is only settable while disconnected. State: " + PeerState);
				}
				if (value < 576)
				{
					value = 576;
				}
				mtu = value;
			}
		}

		public bool IsEncryptionAvailable => peerBase.isEncryptionAvailable;

		[Obsolete("Internally not used anymore. Call SendAcksOnly() instead.")]
		public bool IsSendingOnlyAcks { get; set; }

		public TrafficStats TrafficStatsIncoming { get; internal set; }

		public TrafficStats TrafficStatsOutgoing { get; internal set; }

		public TrafficStatsGameLevel TrafficStatsGameLevel { get; internal set; }

		public long TrafficStatsElapsedMs => (trafficStatsStopwatch != null) ? trafficStatsStopwatch.ElapsedMilliseconds : 0;

		public bool TrafficStatsEnabled
		{
			get
			{
				return trafficStatsEnabled;
			}
			set
			{
				if (trafficStatsEnabled == value)
				{
					return;
				}
				trafficStatsEnabled = value;
				if (trafficStatsEnabled)
				{
					if (trafficStatsStopwatch == null)
					{
						InitializeTrafficStats();
					}
					trafficStatsStopwatch.Start();
				}
				else if (trafficStatsStopwatch != null)
				{
					trafficStatsStopwatch.Stop();
				}
			}
		}

		public Type PayloadEncryptorType
		{
			get
			{
				return payloadEncryptorType;
			}
			set
			{
				bool flag = false;
				if (value == null || typeof(ICryptoProvider).IsAssignableFrom(value))
				{
					payloadEncryptorType = value;
				}
				else
				{
					Listener.DebugReturn(DebugLevel.WARNING, "Failed to set the EncryptorType. Type must implement IPhotonEncryptor.");
				}
			}
		}

		public Type EncryptorType
		{
			get
			{
				return encryptorType;
			}
			set
			{
				bool flag = false;
				if (value == null || typeof(IPhotonEncryptor).IsAssignableFrom(value))
				{
					encryptorType = value;
				}
				else
				{
					Listener.DebugReturn(DebugLevel.WARNING, "Failed to set the EncryptorType. Type must implement IPhotonEncryptor.");
				}
			}
		}

		public int CountDiscarded { get; set; }

		public int DeltaUnreliableNumber { get; set; }

		public event Action<DisconnectMessage> OnDisconnectMessage;

		[Obsolete("Use the ITrafficRecorder to capture all traffic instead.")]
		public string CommandLogToString()
		{
			return string.Empty;
		}

		public static void MessageBufferPoolTrim(int countOfBuffers)
		{
			lock (PeerBase.MessageBufferPool)
			{
				if (countOfBuffers <= 0)
				{
					PeerBase.MessageBufferPool.Clear();
				}
				else if (countOfBuffers < PeerBase.MessageBufferPool.Count)
				{
					while (PeerBase.MessageBufferPool.Count > countOfBuffers)
					{
						PeerBase.MessageBufferPool.Dequeue();
					}
					PeerBase.MessageBufferPool.TrimExcess();
				}
			}
		}

		public static int MessageBufferPoolSize()
		{
			return PeerBase.MessageBufferPool.Count;
		}

		public void TrafficStatsReset()
		{
			TrafficStatsEnabled = false;
			InitializeTrafficStats();
			TrafficStatsEnabled = true;
		}

		internal void InitializeTrafficStats()
		{
			if (trafficStatsStopwatch == null)
			{
				trafficStatsStopwatch = new Stopwatch();
			}
			else
			{
				trafficStatsStopwatch.Reset();
			}
			TrafficStatsIncoming = new TrafficStats(peerBase.TrafficPackageHeaderSize);
			TrafficStatsOutgoing = new TrafficStats(peerBase.TrafficPackageHeaderSize);
			TrafficStatsGameLevel = new TrafficStatsGameLevel(trafficStatsStopwatch);
			if (trafficStatsEnabled)
			{
				trafficStatsStopwatch.Start();
			}
		}

		public string VitalStatsToString(bool all)
		{
			string text = "";
			if (TrafficStatsGameLevel != null)
			{
				text = TrafficStatsGameLevel.ToStringVitalStats();
			}
			if (!all)
			{
				return string.Format("Rtt(variance): {0}({1}). Since receive: {2}ms. Longest send: {5}ms. Stats elapsed: {4}sec.\n{3}", RoundTripTime, RoundTripTimeVariance, ConnectionTime - TimestampOfLastSocketReceive, text, TrafficStatsElapsedMs / 1000, LongestSentCall);
			}
			return string.Format("Rtt(variance): {0}({1}). Since receive: {2}ms. Longest send: {7}ms. Stats elapsed: {6}sec.\n{3}\n{4}\n{5}", RoundTripTime, RoundTripTimeVariance, ConnectionTime - TimestampOfLastSocketReceive, text, TrafficStatsIncoming, TrafficStatsOutgoing, TrafficStatsElapsedMs / 1000, LongestSentCall);
		}

		public PhotonPeer(ConnectionProtocol protocolType)
		{
			TransportProtocol = protocolType;
			SocketImplementationConfig = new Dictionary<ConnectionProtocol, Type>(5);
			SocketImplementationConfig[ConnectionProtocol.Udp] = typeof(SocketUdp);
			SocketImplementationConfig[ConnectionProtocol.Tcp] = typeof(SocketTcp);
			SocketImplementationConfig[ConnectionProtocol.WebSocket] = typeof(PhotonClientWebSocket);
			SocketImplementationConfig[ConnectionProtocol.WebSocketSecure] = typeof(PhotonClientWebSocket);
			CreatePeerBase();
		}

		public PhotonPeer(IPhotonPeerListener listener, ConnectionProtocol protocolType)
			: this(protocolType)
		{
			Listener = listener;
		}

		public virtual bool Connect(string serverAddress, string appId, object photonToken = null, object customInitData = null)
		{
			return Connect(serverAddress, null, appId, photonToken, customInitData);
		}

		public virtual bool Connect(string serverAddress, string proxyServerAddress, string appId, object photonToken, object customInitData = null)
		{
			lock (DispatchLockObject)
			{
				lock (SendOutgoingLockObject)
				{
					if (peerBase != null && peerBase.peerConnectionState != ConnectionStateValue.Disconnected)
					{
						Listener.DebugReturn(DebugLevel.WARNING, "Connect() can't be called if peer is not Disconnected. Not connecting.");
						return false;
					}
					if (photonToken == null)
					{
						Encryptor = null;
						RandomizedSequenceNumbers = null;
						RandomizeSequenceNumbers = false;
						GcmDatagramEncryption = false;
					}
					CreatePeerBase();
					peerBase.Reset();
					PingUsedAsInit = false;
					peerBase.ServerAddress = serverAddress;
					peerBase.ProxyServerAddress = proxyServerAddress;
					peerBase.AppId = appId;
					peerBase.PhotonToken = photonToken;
					peerBase.CustomInitData = customInitData;
					Type value = null;
					if (!SocketImplementationConfig.TryGetValue(TransportProtocol, out value))
					{
						peerBase.EnqueueDebugReturn(DebugLevel.ERROR, "Connect failed. SocketImplementationConfig is not set for protocol " + TransportProtocol.ToString() + ": " + SupportClass.DictionaryToString(SocketImplementationConfig, includeTypes: false));
						return false;
					}
					SocketImplementation = value;
					try
					{
						peerBase.PhotonSocket = (IPhotonSocket)Activator.CreateInstance(SocketImplementation, peerBase);
					}
					catch (Exception ex)
					{
						Listener.DebugReturn(DebugLevel.ERROR, "Connect() failed to create a IPhotonSocket instance for " + TransportProtocol.ToString() + ". SocketImplementationConfig: " + SupportClass.DictionaryToString(SocketImplementationConfig, includeTypes: false) + " Exception: " + ex);
						return false;
					}
					return peerBase.Connect(serverAddress, proxyServerAddress, appId, photonToken);
				}
			}
		}

		private void CreatePeerBase()
		{
			ConnectionProtocol transportProtocol = TransportProtocol;
			ConnectionProtocol connectionProtocol = transportProtocol;
			if (connectionProtocol == ConnectionProtocol.Tcp || connectionProtocol - 4 <= ConnectionProtocol.Tcp)
			{
				TPeer tPeer = peerBase as TPeer;
				if (tPeer == null)
				{
					tPeer = (TPeer)(peerBase = new TPeer());
				}
				tPeer.DoFraming = TransportProtocol == ConnectionProtocol.Tcp;
			}
			else if (!(peerBase is EnetPeer))
			{
				peerBase = new EnetPeer();
			}
			peerBase.photonPeer = this;
			peerBase.usedTransportProtocol = TransportProtocol;
		}

		public virtual void Disconnect()
		{
			lock (DispatchLockObject)
			{
				lock (SendOutgoingLockObject)
				{
					peerBase.Disconnect();
				}
			}
		}

		internal void OnDisconnectMessageCall(DisconnectMessage dm)
		{
			if (this.OnDisconnectMessage != null)
			{
				this.OnDisconnectMessage(dm);
			}
		}

		public virtual void StopThread()
		{
			lock (DispatchLockObject)
			{
				lock (SendOutgoingLockObject)
				{
					peerBase.StopConnection();
				}
			}
		}

		public virtual void FetchServerTimestamp()
		{
			peerBase.FetchServerTimestamp();
		}

		public bool EstablishEncryption()
		{
			if (AsyncKeyExchange)
			{
				SupportClass.StartBackgroundCalls(delegate
				{
					peerBase.ExchangeKeysForEncryption(SendOutgoingLockObject);
					return false;
				});
				return true;
			}
			return peerBase.ExchangeKeysForEncryption(SendOutgoingLockObject);
		}

		public bool InitDatagramEncryption(byte[] encryptionSecret, byte[] hmacSecret, bool randomizedSequenceNumbers = false, bool chainingModeGCM = false)
		{
			if (EncryptorType != null)
			{
				try
				{
					Encryptor = (IPhotonEncryptor)Activator.CreateInstance(EncryptorType);
					if (Encryptor == null)
					{
						Listener.DebugReturn(DebugLevel.WARNING, "Datagram encryptor creation by type failed, Activator.CreateInstance() returned null");
					}
				}
				catch (Exception ex)
				{
					Listener.DebugReturn(DebugLevel.WARNING, "Datagram encryptor creation by type failed: " + ex);
				}
			}
			if (Encryptor == null)
			{
				Encryptor = new EncryptorNet();
			}
			if (Encryptor == null)
			{
				throw new NullReferenceException("Can not init datagram encryption. No suitable encryptor found or provided.");
			}
			Listener.DebugReturn(DebugLevel.INFO, "Datagram encryptor of type " + Encryptor.GetType()?.ToString() + " created. Api version: " + 2);
			Listener.DebugReturn(DebugLevel.INFO, "Datagram encryptor initialization: GCM = " + chainingModeGCM + ", random seq num = " + randomizedSequenceNumbers);
			Encryptor.Init(encryptionSecret, hmacSecret, null, chainingModeGCM, mtu);
			if (randomizedSequenceNumbers)
			{
				RandomizedSequenceNumbers = encryptionSecret;
				RandomizeSequenceNumbers = true;
				GcmDatagramEncryption = chainingModeGCM;
			}
			return true;
		}

		public void InitPayloadEncryption(byte[] secret)
		{
			PayloadEncryptionSecret = secret;
		}

		public virtual void Service()
		{
			while (DispatchIncomingCommands())
			{
			}
			while (SendOutgoingCommands())
			{
			}
		}

		public virtual bool SendOutgoingCommands()
		{
			if (TrafficStatsEnabled)
			{
				TrafficStatsGameLevel.SendOutgoingCommandsCalled();
			}
			lock (SendOutgoingLockObject)
			{
				return peerBase.SendOutgoingCommands();
			}
		}

		public virtual bool SendAcksOnly()
		{
			if (TrafficStatsEnabled)
			{
				TrafficStatsGameLevel.SendOutgoingCommandsCalled();
			}
			lock (SendOutgoingLockObject)
			{
				return peerBase.SendAcksOnly();
			}
		}

		public virtual bool DispatchIncomingCommands()
		{
			if (TrafficStatsEnabled)
			{
				TrafficStatsGameLevel.DispatchIncomingCommandsCalled();
			}
			lock (DispatchLockObject)
			{
				peerBase.ByteCountCurrentDispatch = 0;
				return peerBase.DispatchIncomingCommands();
			}
		}

		public virtual bool SendOperation(byte operationCode, Dictionary<byte, object> operationParameters, SendOptions sendOptions)
		{
			if (sendOptions.Encrypt && !IsEncryptionAvailable && peerBase.usedTransportProtocol != ConnectionProtocol.WebSocketSecure)
			{
				throw new ArgumentException("Can't use encryption yet. Exchange keys first.");
			}
			if (peerBase.peerConnectionState != ConnectionStateValue.Connected)
			{
				if ((int)DebugOut >= 1)
				{
					Listener.DebugReturn(DebugLevel.ERROR, "Cannot send op: " + operationCode + " Not connected. PeerState: " + peerBase.peerConnectionState);
				}
				Listener.OnStatusChanged(StatusCode.SendError);
				return false;
			}
			if (sendOptions.Channel >= ChannelCount)
			{
				if ((int)DebugOut >= 1)
				{
					Listener.DebugReturn(DebugLevel.ERROR, "Cannot send op: Selected channel (" + sendOptions.Channel + ")>= channelCount (" + ChannelCount + ").");
				}
				Listener.OnStatusChanged(StatusCode.SendError);
				return false;
			}
			lock (EnqueueLock)
			{
				StreamBuffer opBytes = peerBase.SerializeOperationToMessage(operationCode, operationParameters, EgMessageType.Operation, sendOptions.Encrypt);
				return peerBase.EnqueuePhotonMessage(opBytes, sendOptions);
			}
		}

		public virtual bool SendOperation(byte operationCode, ParameterDictionary operationParameters, SendOptions sendOptions)
		{
			if (sendOptions.Encrypt && !IsEncryptionAvailable && peerBase.usedTransportProtocol != ConnectionProtocol.WebSocketSecure)
			{
				throw new ArgumentException("Can't use encryption yet. Exchange keys first.");
			}
			if (peerBase.peerConnectionState != ConnectionStateValue.Connected)
			{
				if ((int)DebugOut >= 1)
				{
					Listener.DebugReturn(DebugLevel.ERROR, "Cannot send op: " + operationCode + " Not connected. PeerState: " + peerBase.peerConnectionState);
				}
				Listener.OnStatusChanged(StatusCode.SendError);
				return false;
			}
			if (sendOptions.Channel >= ChannelCount)
			{
				if ((int)DebugOut >= 1)
				{
					Listener.DebugReturn(DebugLevel.ERROR, "Cannot send op: Selected channel (" + sendOptions.Channel + ")>= channelCount (" + ChannelCount + ").");
				}
				Listener.OnStatusChanged(StatusCode.SendError);
				return false;
			}
			lock (EnqueueLock)
			{
				StreamBuffer opBytes = peerBase.SerializeOperationToMessage(operationCode, operationParameters, EgMessageType.Operation, sendOptions.Encrypt);
				return peerBase.EnqueuePhotonMessage(opBytes, sendOptions);
			}
		}

		public static bool RegisterType(Type customType, byte code, SerializeMethod serializeMethod, DeserializeMethod constructor)
		{
			return Protocol.TryRegisterType(customType, code, serializeMethod, constructor);
		}

		public static bool RegisterType(Type customType, byte code, SerializeStreamMethod serializeMethod, DeserializeStreamMethod constructor)
		{
			return Protocol.TryRegisterType(customType, code, serializeMethod, constructor);
		}
	}
	public class OperationRequest
	{
		public byte OperationCode;

		public ParameterDictionary Parameters;
	}
	public class OperationResponse
	{
		public byte OperationCode;

		public short ReturnCode;

		public string DebugMessage;

		public ParameterDictionary Parameters;

		public object this[byte parameterCode]
		{
			get
			{
				Parameters.TryGetValue(parameterCode, out var value);
				return value;
			}
			set
			{
				Parameters.Add(parameterCode, value);
			}
		}

		public override string ToString()
		{
			return $"OperationResponse {OperationCode}: ReturnCode: {ReturnCode}.";
		}

		public string ToStringFull()
		{
			return string.Format("OperationResponse {0}: ReturnCode: {1} ({3}). Parameters: {2}", OperationCode, ReturnCode, SupportClass.DictionaryToString(Parameters), DebugMessage);
		}
	}
	public class DisconnectMessage
	{
		public short Code;

		public string DebugMessage;

		public Dictionary<byte, object> Parameters;
	}
	public class EventData
	{
		public byte Code;

		public readonly ParameterDictionary Parameters;

		public byte SenderKey = 254;

		private int sender = -1;

		public byte CustomDataKey = 245;

		private object customData;

		public object this[byte key]
		{
			get
			{
				Parameters.TryGetValue(key, out var value);
				return value;
			}
			internal set
			{
				Parameters.Add(key, value);
			}
		}

		public int Sender
		{
			get
			{
				if (sender == -1)
				{
					int value;
					bool flag = Parameters.TryGetValue(SenderKey, out value);
					sender = (flag ? value : (-1));
				}
				return sender;
			}
			internal set
			{
				sender = value;
			}
		}

		public object CustomData
		{
			get
			{
				if (customData == null)
				{
					Parameters.TryGetValue(CustomDataKey, out customData);
				}
				return customData;
			}
			internal set
			{
				customData = value;
			}
		}

		public EventData()
		{
			Parameters = new ParameterDictionary();
		}

		internal void Reset()
		{
			Code = 0;
			Parameters.Clear();
			sender = -1;
			customData = null;
		}

		public override string ToString()
		{
			return $"Event {Code.ToString()}.";
		}

		public string ToStringFull()
		{
			return $"Event {Code}: {SupportClass.DictionaryToString(Parameters)}";
		}
	}
	public delegate byte[] SerializeMethod(object customObject);
	public delegate short SerializeStreamMethod(StreamBuffer outStream, object customObject);
	public delegate object DeserializeMethod(byte[] serializedCustomObject);
	public delegate object DeserializeStreamMethod(StreamBuffer inStream, short length);
	internal class CustomType
	{
		public readonly byte Code;

		public readonly Type Type;

		public readonly SerializeMethod SerializeFunction;

		public readonly DeserializeMethod DeserializeFunction;

		public readonly SerializeStreamMethod SerializeStreamFunction;

		public readonly DeserializeStreamMethod DeserializeStreamFunction;

		public CustomType(Type type, byte code, SerializeMethod serializeFunction, DeserializeMethod deserializeFunction)
		{
			Type = type;
			Code = code;
			SerializeFunction = serializeFunction;
			DeserializeFunction = deserializeFunction;
		}

		public CustomType(Type type, byte code, SerializeStreamMethod serializeFunction, DeserializeStreamMethod deserializeFunction)
		{
			Type = type;
			Code = code;
			SerializeStreamFunction = serializeFunction;
			DeserializeStreamFunction = deserializeFunction;
		}
	}
	public class Protocol
	{
		internal static readonly Dictionary<Type, CustomType> TypeDict = new Dictionary<Type, CustomType>();

		internal static readonly Dictionary<byte, CustomType> CodeDict = new Dictionary<byte, CustomType>();

		private static IProtocol ProtocolDefault;

		private static readonly float[] memFloatBlock = new float[1];

		private static readonly byte[] memDeserialize = new byte[4];

		public static bool TryRegisterType(Type type, byte typeCode, SerializeMethod serializeFunction, DeserializeMethod deserializeFunction)
		{
			if (CodeDict.ContainsKey(typeCode) || TypeDict.ContainsKey(type))
			{
				return false;
			}
			CustomType value = new CustomType(type, typeCode, serializeFunction, deserializeFunction);
			CodeDict.Add(typeCode, value);
			TypeDict.Add(type, value);
			return true;
		}

		public static bool TryRegisterType(Type type, byte typeCode, SerializeStreamMethod serializeFunction, DeserializeStreamMethod deserializeFunction)
		{
			if (CodeDict.ContainsKey(typeCode) || TypeDict.ContainsKey(type))
			{
				return false;
			}
			CustomType value = new CustomType(type, typeCode, serializeFunction, deserializeFunction);
			CodeDict.Add(typeCode, value);
			TypeDict.Add(type, value);
			return true;
		}

		[Obsolete]
		public static byte[] Serialize(object obj)
		{
			if (ProtocolDefault == null)
			{
				ProtocolDefault = new Protocol16();
			}
			lock (ProtocolDefault)
			{
				return ProtocolDefault.Serialize(obj);
			}
		}

		[Obsolete]
		public static object Deserialize(byte[] serializedData)
		{
			if (ProtocolDefault == null)
			{
				ProtocolDefault = new Protocol16();
			}
			lock (ProtocolDefault)
			{
				return ProtocolDefault.Deserialize(serializedData);
			}
		}

		public static void Serialize(short value, byte[] target, ref int targetOffset)
		{
			target[targetOffset++] = (byte)(value >> 8);
			target[targetOffset++] = (byte)value;
		}

		public static void Serialize(int value, byte[] target, ref int targetOffset)
		{
			target[targetOffset++] = (byte)(value >> 24);
			target[targetOffset++] = (byte)(value >> 16);
			target[targetOffset++] = (byte)(value >> 8);
			target[targetOffset++] = (byte)value;
		}

		public static void Serialize(float value, byte[] target, ref int targetOffset)
		{
			lock (memFloatBlock)
			{
				memFloatBlock[0] = value;
				Buffer.BlockCopy(memFloatBlock, 0, target, targetOffset, 4);
			}
			if (BitConverter.IsLittleEndian)
			{
				byte b = target[targetOffset];
				byte b2 = target[targetOffset + 1];
				target[targetOffset] = target[targetOffset + 3];
				target[targetOffset + 1] = target[targetOffset + 2];
				target[targetOffset + 2] = b2;
				target[targetOffset + 3] = b;
			}
			targetOffset += 4;
		}

		public static void Deserialize(out int value, byte[] source, ref int offset)
		{
			value = (source[offset++] << 24) | (source[offset++] << 16) | (source[offset++] << 8) | source[offset++];
		}

		public static void Deserialize(out short value, byte[] source, ref int offset)
		{
			value = (short)((source[offset++] << 8) | source[offset++]);
		}

		public static void Deserialize(out float value, byte[] source, ref int offset)
		{
			if (BitConverter.IsLittleEndian)
			{
				lock (memDeserialize)
				{
					byte[] array = memDeserialize;
					array[3] = source[offset++];
					array[2] = source[offset++];
					array[1] = source[offset++];
					array[0] = source[offset++];
					value = BitConverter.ToSingle(array, 0);
					return;
				}
			}
			value = BitConverter.ToSingle(source, offset);
			offset += 4;
		}
	}
	public class Protocol16 : IProtocol
	{
		public enum GpType : byte
		{
			Unknown = 0,
			Array = 121,
			Boolean = 111,
			Byte = 98,
			ByteArray = 120,
			ObjectArray = 122,
			Short = 107,
			Float = 102,
			Dictionary = 68,
			Double = 100,
			Hashtable = 104,
			Integer = 105,
			IntegerArray = 110,
			Long = 108,
			String = 115,
			StringArray = 97,
			Custom = 99,
			Null = 42,
			EventData = 101,
			OperationRequest = 113,
			OperationResponse = 112
		}

		private readonly byte[] versionBytes = new byte[2] { 1, 6 };

		private readonly byte[] memShort = new byte[2];

		private readonly long[] memLongBlock = new long[1];

		private readonly byte[] memLongBlockBytes = new byte[8];

		private static readonly float[] memFloatBlock = new float[1];

		private static readonly byte[] memFloatBlockBytes = new byte[4];

		private readonly double[] memDoubleBlock = new double[1];

		private readonly byte[] memDoubleBlockBytes = new byte[8];

		private readonly byte[] memInteger = new byte[4];

		private readonly byte[] memLong = new byte[8];

		private readonly byte[] memFloat = new byte[4];

		private readonly byte[] memDouble = new byte[8];

		public override string ProtocolType => "GpBinaryV16";

		public override byte[] VersionBytes => versionBytes;

		private bool SerializeCustom(StreamBuffer dout, object serObject)
		{
			Type key = ((serObject is StructWrapper structWrapper) ? structWrapper.ttype : serObject.GetType());
			if (Protocol.TypeDict.TryGetValue(key, out var value))
			{
				byte code;
				if (value.SerializeStreamFunction == null)
				{
					byte[] array = value.SerializeFunction(serObject);
					dout.WriteByte(99);
					dout.WriteByte(value.Code);
					int serObject2 = array.Length;
					code = value.Code;
					SerializeLengthAsShort(dout, serObject2, "Custom Type " + code);
					dout.Write(array, 0, array.Length);
					return true;
				}
				dout.WriteByte(99);
				dout.WriteByte(value.Code);
				int position = dout.Position;
				dout.Position += 2;
				short num = value.SerializeStreamFunction(dout, serObject);
				long num2 = dout.Position;
				dout.Position = position;
				short serObject3 = num;
				code = value.Code;
				SerializeLengthAsShort(dout, serObject3, "Custom Type " + code);
				dout.Position += num;
				if (dout.Position != num2)
				{
					throw new Exception("Serialization failed. Stream position corrupted. Should be " + num2 + " is now: " + dout.Position + " serializedLength: " + num);
				}
				return true;
			}
			return false;
		}

		private object DeserializeCustom(StreamBuffer din, byte customTypeCode, DeserializationFlags flags = DeserializationFlags.None)
		{
			short num = DeserializeShort(din);
			if (num < 0)
			{
				throw new InvalidDataException("DeserializeCustom read negative length value: " + num + " before position: " + din.Position);
			}
			if (num <= din.Available && Protocol.CodeDict.TryGetValue(customTypeCode, out var value))
			{
				if (value.DeserializeStreamFunction == null)
				{
					byte[] array = new byte[num];
					din.Read(array, 0, num);
					return value.DeserializeFunction(array);
				}
				int position = din.Position;
				object result = value.DeserializeStreamFunction(din, num);
				int num2 = din.Position - position;
				if (num2 != num)
				{
					din.Position = position + num;
				}
				return result;
			}
			int num3 = ((num <= din.Available) ? num : ((short)din.Available));
			byte[] array2 = new byte[num3];
			din.Read(array2, 0, num3);
			return array2;
		}

		private Type GetTypeOfCode(byte typeCode)
		{
			switch (typeCode)
			{
			case 105:
				return typeof(int);
			case 115:
				return typeof(string);
			case 97:
				return typeof(string[]);
			case 120:
				return typeof(byte[]);
			case 110:
				return typeof(int[]);
			case 104:
				return typeof(Hashtable);
			case 68:
				return typeof(IDictionary);
			case 111:
				return typeof(bool);
			case 107:
				return typeof(short);
			case 108:
				return typeof(long);
			case 98:
				return typeof(byte);
			case 102:
				return typeof(float);
			case 100:
				return typeof(double);
			case 121:
				return typeof(Array);
			case 99:
				return typeof(CustomType);
			case 122:
				return typeof(object[]);
			case 101:
				return typeof(EventData);
			case 113:
				return typeof(OperationRequest);
			case 112:
				return typeof(OperationResponse);
			case 0:
			case 42:
				return typeof(object);
			default:
				System.Diagnostics.Debug.WriteLine("missing type: " + typeCode);
				throw new Exception("deserialize(): " + typeCode);
			}
		}

		private GpType GetCodeOfType(Type type)
		{
			switch (Type.GetTypeCode(type))
			{
			case TypeCode.Byte:
				return GpType.Byte;
			case TypeCode.String:
				return GpType.String;
			case TypeCode.Boolean:
				return GpType.Boolean;
			case TypeCode.Int16:
				return GpType.Short;
			case TypeCode.Int32:
				return GpType.Integer;
			case TypeCode.Int64:
				return GpType.Long;
			case TypeCode.Single:
				return GpType.Float;
			case TypeCode.Double:
				return GpType.Double;
			default:
				if (type.IsArray)
				{
					if (type == typeof(byte[]))
					{
						return GpType.ByteArray;
					}
					return GpType.Array;
				}
				if (type == typeof(Hashtable))
				{
					return GpType.Hashtable;
				}
				if (type == typeof(List<object>))
				{
					return GpType.ObjectArray;
				}
				if (type.IsGenericType && typeof(Dictionary<, >) == type.GetGenericTypeDefinition())
				{
					return GpType.Dictionary;
				}
				if (type == typeof(EventData))
				{
					return GpType.EventData;
				}
				if (type == typeof(OperationRequest))
				{
					return GpType.OperationRequest;
				}
				if (type == typeof(OperationResponse))
				{
					return GpType.OperationResponse;
				}
				return GpType.Unknown;
			}
		}

		private Array CreateArrayByType(byte arrayType, short length)
		{
			return Array.CreateInstance(GetTypeOfCode(arrayType), length);
		}

		public void SerializeOperationRequest(StreamBuffer stream, OperationRequest operation, bool setType)
		{
			SerializeOperationRequest(stream, operation.OperationCode, operation.Parameters, setType);
		}

		[Obsolete("Use ParameterDictionary instead.")]
		public override void SerializeOperationRequest(StreamBuffer stream, byte operationCode, Dictionary<byte, object> parameters, bool setType)
		{
			if (setType)
			{
				stream.WriteByte(113);
			}
			stream.WriteByte(operationCode);
			SerializeParameterTable(stream, parameters);
		}

		public override void SerializeOperationRequest(StreamBuffer stream, byte operationCode, ParameterDictionary parameters, bool setType)
		{
			if (setType)
			{
				stream.WriteByte(113);
			}
			stream.WriteByte(operationCode);
			SerializeParameterTable(stream, parameters);
		}

		public override OperationRequest DeserializeOperationRequest(StreamBuffer din, DeserializationFlags flags)
		{
			OperationRequest operationRequest = new OperationRequest();
			operationRequest.OperationCode = DeserializeByte(din);
			operationRequest.Parameters = DeserializeParameterDictionary(din, operationRequest.Parameters, flags);
			return operationRequest;
		}

		public override void SerializeOperationResponse(StreamBuffer stream, OperationResponse serObject, bool setType)
		{
			if (setType)
			{
				stream.WriteByte(112);
			}
			stream.WriteByte(serObject.OperationCode);
			SerializeShort(stream, serObject.ReturnCode, setType: false);
			if (string.IsNullOrEmpty(serObject.DebugMessage))
			{
				stream.WriteByte(42);
			}
			else
			{
				SerializeString(stream, serObject.DebugMessage, setType: false);
			}
			SerializeParameterTable(stream, serObject.Parameters);
		}

		public override DisconnectMessage DeserializeDisconnectMessage(StreamBuffer stream)
		{
			DisconnectMessage disconnectMessage = new DisconnectMessage();
			disconnectMessage.Code = DeserializeShort(stream);
			disconnectMessage.DebugMessage = Deserialize(stream, DeserializeByte(stream)) as string;
			disconnectMessage.Parameters = DeserializeParameterTable(stream);
			return disconnectMessage;
		}

		public override OperationResponse DeserializeOperationResponse(StreamBuffer stream, DeserializationFlags flags = DeserializationFlags.None)
		{
			OperationResponse operationResponse = new OperationResponse();
			operationResponse.OperationCode = DeserializeByte(stream);
			operationResponse.ReturnCode = DeserializeShort(stream);
			operationResponse.DebugMessage = Deserialize(stream, DeserializeByte(stream)) as string;
			operationResponse.Parameters = DeserializeParameterDictionary(stream);
			return operationResponse;
		}

		public override void SerializeEventData(StreamBuffer stream, EventData serObject, bool setType)
		{
			if (setType)
			{
				stream.WriteByte(101);
			}
			stream.WriteByte(serObject.Code);
			SerializeParameterTable(stream, serObject.Parameters);
		}

		public override EventData DeserializeEventData(StreamBuffer din, EventData target = null, DeserializationFlags flags = DeserializationFlags.None)
		{
			EventData eventData;
			if (target != null)
			{
				target.Reset();
				eventData = target;
			}
			else
			{
				eventData = new EventData();
			}
			eventData.Code = DeserializeByte(din);
			DeserializeParameterDictionary(din, eventData.Parameters);
			return eventData;
		}

		[Obsolete("Use ParameterDictionary instead of Dictionary<byte, object>.")]
		private void SerializeParameterTable(StreamBuffer stream, Dictionary<byte, object> parameters)
		{
			if (parameters == null || parameters.Count == 0)
			{
				SerializeShort(stream, 0, setType: false);
				return;
			}
			SerializeLengthAsShort(stream, parameters.Count, "ParameterTable");
			foreach (KeyValuePair<byte, object> parameter in parameters)
			{
				stream.WriteByte(parameter.Key);
				Serialize(stream, parameter.Value, setType: true);
			}
		}

		private void SerializeParameterTable(StreamBuffer stream, ParameterDictionary parameters)
		{
			if (parameters == null || parameters.Count == 0)
			{
				SerializeShort(stream, 0, setType: false);
				return;
			}
			SerializeLengthAsShort(stream, parameters.Count, "Array");
			foreach (KeyValuePair<byte, object> parameter in parameters)
			{
				stream.WriteByte(parameter.Key);
				Serialize(stream, parameter.Value, setType: true);
			}
		}

		private Dictionary<byte, object> DeserializeParameterTable(StreamBuffer stream, Dictionary<byte, object> target = null)
		{
			short num = DeserializeShort(stream);
			Dictionary<byte, object> dictionary = ((target != null) ? target : new Dictionary<byte, object>(num));
			for (int i = 0; i < num; i++)
			{
				byte key = stream.ReadByte();
				object value = Deserialize(stream, stream.ReadByte());
				dictionary[key] = value;
			}
			return dictionary;
		}

		private ParameterDictionary DeserializeParameterDictionary(StreamBuffer stream, ParameterDictionary target = null, DeserializationFlags flags = DeserializationFlags.None)
		{
			short num = DeserializeShort(stream);
			ParameterDictionary parameterDictionary = ((target != null) ? target : new ParameterDictionary(num));
			for (int i = 0; i < num; i++)
			{
				byte code = stream.ReadByte();
				object value = Deserialize(stream, stream.ReadByte(), flags);
				parameterDictionary.Add(code, value);
			}
			return parameterDictionary;
		}

		public override void Serialize(StreamBuffer dout, object serObject, bool setType)
		{
			if (serObject == null)
			{
				if (setType)
				{
					dout.WriteByte(42);
				}
				return;
			}
			Type type = ((serObject is StructWrapper structWrapper) ? structWrapper.ttype : serObject.GetType());
			switch (GetCodeOfType(type))
			{
			case GpType.Byte:
				SerializeByte(dout, serObject.Get<byte>(), setType);
				return;
			case GpType.String:
				SerializeString(dout, (string)serObject, setType);
				return;
			case GpType.Boolean:
				SerializeBoolean(dout, serObject.Get<bool>(), setType);
				return;
			case GpType.Short:
				SerializeShort(dout, serObject.Get<short>(), setType);
				return;
			case GpType.Integer:
				SerializeInteger(dout, serObject.Get<int>(), setType);
				return;
			case GpType.Long:
				SerializeLong(dout, serObject.Get<long>(), setType);
				return;
			case GpType.Float:
				SerializeFloat(dout, serObject.Get<float>(), setType);
				return;
			case GpType.Double:
				SerializeDouble(dout, serObject.Get<double>(), setType);
				return;
			case GpType.Hashtable:
				SerializeHashTable(dout, (Hashtable)serObject, setType);
				return;
			case GpType.ByteArray:
				SerializeByteArray(dout, (byte[])serObject, setType);
				return;
			case GpType.ObjectArray:
				SerializeObjectArray(dout, (IList)serObject, setType);
				return;
			case GpType.Array:
				if (serObject is int[])
				{
					SerializeIntArrayOptimized(dout, (int[])serObject, setType);
				}
				else if (type.GetElementType() == typeof(object))
				{
					SerializeObjectArray(dout, serObject as object[], setType);
				}
				else
				{
					SerializeArray(dout, (Array)serObject, setType);
				}
				return;
			case GpType.Dictionary:
				SerializeDictionary(dout, (IDictionary)serObject, setType);
				return;
			case GpType.EventData:
				SerializeEventData(dout, (EventData)serObject, setType);
				return;
			case GpType.OperationResponse:
				SerializeOperationResponse(dout, (OperationResponse)serObject, setType);
				return;
			case GpType.OperationRequest:
				SerializeOperationRequest(dout, (OperationRequest)serObject, setType);
				return;
			}
			if (serObject is ArraySegment<byte> arraySegment)
			{
				SerializeByteArraySegment(dout, arraySegment.Array, arraySegment.Offset, arraySegment.Count, setType);
			}
			else if (!SerializeCustom(dout, serObject))
			{
				if (serObject is StructWrapper)
				{
					throw new Exception("cannot serialize(): StructWrapper<" + (serObject as StructWrapper).ttype.Name + ">");
				}
				throw new Exception("cannot serialize(): " + type);
			}
		}

		private void SerializeByte(StreamBuffer dout, byte serObject, bool setType)
		{
			if (setType)
			{
				dout.WriteByte(98);
			}
			dout.WriteByte(serObject);
		}

		private void SerializeBoolean(StreamBuffer dout, bool serObject, bool setType)
		{
			if (setType)
			{
				dout.WriteByte(111);
			}
			dout.WriteByte((byte)(serObject ? 1 : 0));
		}

		public override void SerializeShort(StreamBuffer dout, short serObject, bool setType)
		{
			if (setType)
			{
				dout.WriteByte(107);
			}
			lock (memShort)
			{
				byte[] array = memShort;
				array[0] = (byte)(serObject >> 8);
				array[1] = (byte)serObject;
				dout.Write(array, 0, 2);
			}
		}

		public void SerializeLengthAsShort(StreamBuffer dout, int serObject, string type)
		{
			if (serObject > 32767 || serObject < 0)
			{
				throw new NotSupportedException($"Exceeding 32767 (short.MaxValue) entries are not supported. Failed writing {type}. Length: {serObject}");
			}
			lock (memShort)
			{
				byte[] array = memShort;
				array[0] = (byte)(serObject >> 8);
				array[1] = (byte)serObject;
				dout.Write(array, 0, 2);
			}
		}

		private void SerializeInteger(StreamBuffer dout, int serObject, bool setType)
		{
			if (setType)
			{
				dout.WriteByte(105);
			}
			lock (memInteger)
			{
				byte[] array = memInteger;
				array[0] = (byte)(serObject >> 24);
				array[1] = (byte)(serObject >> 16);
				array[2] = (byte)(serObject >> 8);
				array[3] = (byte)serObject;
				dout.Write(array, 0, 4);
			}
		}

		private void SerializeLong(StreamBuffer dout, long serObject, bool setType)
		{
			if (setType)
			{
				dout.WriteByte(108);
			}
			lock (memLongBlock)
			{
				memLongBlock[0] = serObject;
				Buffer.BlockCopy(memLongBlock, 0, memLongBlockBytes, 0, 8);
				byte[] array = memLongBlockBytes;
				if (BitConverter.IsLittleEndian)
				{
					byte b = array[0];
					byte b2 = array[1];
					byte b3 = array[2];
					byte b4 = array[3];
					array[0] = array[7];
					array[1] = array[6];
					array[2] = array[5];
					array[3] = array[4];
					array[4] = b4;
					array[5] = b3;
					array[6] = b2;
					array[7] = b;
				}
				dout.Write(array, 0, 8);
			}
		}

		private void SerializeFloat(StreamBuffer dout, float serObject, bool setType)
		{
			if (setType)
			{
				dout.WriteByte(102);
			}
			lock (memFloatBlockBytes)
			{
				memFloatBlock[0] = serObject;
				Buffer.BlockCopy(memFloatBlock, 0, memFloatBlockBytes, 0, 4);
				if (BitConverter.IsLittleEndian)
				{
					byte b = memFloatBlockBytes[0];
					byte b2 = memFloatBlockBytes[1];
					memFloatBlockBytes[0] = memFloatBlockBytes[3];
					memFloatBlockBytes[1] = memFloatBlockBytes[2];
					memFloatBlockBytes[2] = b2;
					memFloatBlockBytes[3] = b;
				}
				dout.Write(memFloatBlockBytes, 0, 4);
			}
		}

		private void SerializeDouble(StreamBuffer dout, double serObject, bool setType)
		{
			if (setType)
			{
				dout.WriteByte(100);
			}
			lock (memDoubleBlockBytes)
			{
				memDoubleBlock[0] = serObject;
				Buffer.BlockCopy(memDoubleBlock, 0, memDoubleBlockBytes, 0, 8);
				byte[] array = memDoubleBlockBytes;
				if (BitConverter.IsLittleEndian)
				{
					byte b = array[0];
					byte b2 = array[1];
					byte b3 = array[2];
					byte b4 = array[3];
					array[0] = array[7];
					array[1] = array[6];
					array[2] = array[5];
					array[3] = array[4];
					array[4] = b4;
					array[5] = b3;
					array[6] = b2;
					array[7] = b;
				}
				dout.Write(array, 0, 8);
			}
		}

		public override void SerializeString(StreamBuffer stream, string value, bool setType)
		{
			if (setType)
			{
				stream.WriteByte(115);
			}
			int byteCount = Encoding.UTF8.GetByteCount(value);
			if (byteCount > 32767)
			{
				throw new NotSupportedException("Strings that exceed a UTF8-encoded byte-length of 32767 (short.MaxValue) are not supported. Yours is: " + byteCount);
			}
			SerializeLengthAsShort(stream, byteCount, "String");
			int offset = 0;
			byte[] bufferAndAdvance = stream.GetBufferAndAdvance(byteCount, out offset);
			Encoding.UTF8.GetBytes(value, 0, value.Length, bufferAndAdvance, offset);
		}

		private void SerializeArray(StreamBuffer dout, Array serObject, bool setType)
		{
			if (setType)
			{
				dout.WriteByte(121);
			}
			SerializeLengthAsShort(dout, serObject.Length, "Array");
			Type elementType = serObject.GetType().GetElementType();
			GpType codeOfType = GetCodeOfType(elementType);
			if (codeOfType != GpType.Unknown)
			{
				dout.WriteByte((byte)codeOfType);
				if (codeOfType == GpType.Dictionary)
				{
					SerializeDictionaryHeader(dout, serObject, out var setKeyType, out var setValueType);
					for (int i = 0; i < serObject.Length; i++)
					{
						object value = serObject.GetValue(i);
						SerializeDictionaryElements(dout, value, setKeyType, setValueType);
					}
				}
				else
				{
					for (int j = 0; j < serObject.Length; j++)
					{
						object value2 = serObject.GetValue(j);
						Serialize(dout, value2, setType: false);
					}
				}
				return;
			}
			if (Protocol.TypeDict.TryGetValue(elementType, out var value3))
			{
				dout.WriteByte(99);
				dout.WriteByte(value3.Code);
				for (int k = 0; k < serObject.Length; k++)
				{
					object value4 = serObject.GetValue(k);
					byte code;
					if (value3.SerializeStreamFunction == null)
					{
						byte[] array = value3.SerializeFunction(value4);
						int serObject2 = array.Length;
						code = value3.Code;
						SerializeLengthAsShort(dout, serObject2, "Custom Type " + code);
						dout.Write(array, 0, array.Length);
						continue;
					}
					int position = dout.Position;
					dout.Position += 2;
					short num = value3.SerializeStreamFunction(dout, value4);
					long num2 = dout.Position;
					dout.Position = position;
					short serObject3 = num;
					code = value3.Code;
					SerializeLengthAsShort(dout, serObject3, "Custom Type " + code);
					dout.Position += num;
					if (dout.Position != num2)
					{
						throw new Exception("Serialization failed. Stream position corrupted. Should be " + num2 + " is now: " + dout.Position + " serializedLength: " + num);
					}
				}
				return;
			}
			throw new NotSupportedException("cannot serialize array of type " + elementType);
		}

		private void SerializeByteArray(StreamBuffer dout, byte[] serObject, bool setType)
		{
			if (setType)
			{
				dout.WriteByte(120);
			}
			SerializeInteger(dout, serObject.Length, setType: false);
			dout.Write(serObject, 0, serObject.Length);
		}

		private void SerializeByteArraySegment(StreamBuffer dout, byte[] serObject, int offset, int count, bool setType)
		{
			if (setType)
			{
				dout.WriteByte(120);
			}
			SerializeInteger(dout, count, setType: false);
			dout.Write(serObject, offset, count);
		}

		private void SerializeIntArrayOptimized(StreamBuffer inWriter, int[] serObject, bool setType)
		{
			if (setType)
			{
				inWriter.WriteByte(121);
			}
			SerializeLengthAsShort(inWriter, serObject.Length, "int[]");
			inWriter.WriteByte(105);
			byte[] array = new byte[serObject.Length * 4];
			int num = 0;
			for (int i = 0; i < serObject.Length; i++)
			{
				array[num++] = (byte)(serObject[i] >> 24);
				array[num++] = (byte)(serObject[i] >> 16);
				array[num++] = (byte)(serObject[i] >> 8);
				array[num++] = (byte)serObject[i];
			}
			inWriter.Write(array, 0, array.Length);
		}

		private void SerializeStringArray(StreamBuffer dout, string[] serObject, bool setType)
		{
			if (setType)
			{
				dout.WriteByte(97);
			}
			SerializeLengthAsShort(dout, serObject.Length, "string[]");
			for (int i = 0; i < serObject.Length; i++)
			{
				SerializeString(dout, serObject[i], setType: false);
			}
		}

		private void SerializeObjectArray(StreamBuffer dout, IList objects, bool setType)
		{
			if (setType)
			{
				dout.WriteByte(122);
			}
			SerializeLengthAsShort(dout, objects.Count, "object[]");
			for (int i = 0; i < objects.Count; i++)
			{
				object serObject = objects[i];
				Serialize(dout, serObject, setType: true);
			}
		}

		private void SerializeHashTable(StreamBuffer dout, Hashtable serObject, bool setType)
		{
			if (setType)
			{
				dout.WriteByte(104);
			}
			SerializeLengthAsShort(dout, serObject.Count, "Hashtable");
			Dictionary<object, object>.KeyCollection keys = serObject.Keys;
			foreach (object item in keys)
			{
				Serialize(dout, item, setType: true);
				Serialize(dout, serObject[item], setType: true);
			}
		}

		private void SerializeDictionary(StreamBuffer dout, IDictionary serObject, bool setType)
		{
			if (setType)
			{
				dout.WriteByte(68);
			}
			SerializeDictionaryHeader(dout, serObject, out var setKeyType, out var setValueType);
			SerializeDictionaryElements(dout, serObject, setKeyType, setValueType);
		}

		private void SerializeDictionaryHeader(StreamBuffer writer, Type dictType)
		{
			SerializeDictionaryHeader(writer, dictType, out var _, out var _);
		}

		private void SerializeDictionaryHeader(StreamBuffer writer, object dict, out bool setKeyType, out bool setValueType)
		{
			Type[] genericArguments = dict.GetType().GetGenericArguments();
			setKeyType = genericArguments[0] == typeof(object);
			setValueType = genericArguments[1] == typeof(object);
			if (setKeyType)
			{
				writer.WriteByte(0);
			}
			else
			{
				GpType codeOfType = GetCodeOfType(genericArguments[0]);
				if (codeOfType == GpType.Unknown || codeOfType == GpType.Dictionary)
				{
					throw new Exception("Unexpected - cannot serialize Dictionary with key type: " + genericArguments[0]);
				}
				writer.WriteByte((byte)codeOfType);
			}
			if (setValueType)
			{
				writer.WriteByte(0);
				return;
			}
			GpType codeOfType2 = GetCodeOfType(genericArguments[1]);
			if (codeOfType2 == GpType.Unknown)
			{
				throw new Exception("Unexpected - cannot serialize Dictionary with value type: " + genericArguments[1]);
			}
			writer.WriteByte((byte)codeOfType2);
			if (codeOfType2 == GpType.Dictionary)
			{
				SerializeDictionaryHeader(writer, genericArguments[1]);
			}
		}

		private void SerializeDictionaryElements(StreamBuffer writer, object dict, bool setKeyType, bool setValueType)
		{
			IDictionary dictionary = (IDictionary)dict;
			SerializeLengthAsShort(writer, dictionary.Count, "Dictionary elements");
			foreach (DictionaryEntry item in dictionary)
			{
				if (!setValueType && item.Value == null)
				{
					throw new Exception("Can't serialize null in Dictionary with specific value-type.");
				}
				if (!setKeyType && item.Key == null)
				{
					throw new Exception("Can't serialize null in Dictionary with specific key-type.");
				}
				Serialize(writer, item.Key, setKeyType);
				Serialize(writer, item.Value, setValueType);
			}
		}

		public override object Deserialize(StreamBuffer din, byte type, DeserializationFlags flags = DeserializationFlags.None)
		{
			switch (type)
			{
			case 105:
				return DeserializeInteger(din);
			case 115:
				return DeserializeString(din);
			case 97:
				return DeserializeStringArray(din);
			case 120:
				return DeserializeByteArray(din);
			case 110:
				return DeserializeIntArray(din);
			case 104:
				return DeserializeHashTable(din);
			case 68:
				return DeserializeDictionary(din);
			case 111:
				return DeserializeBoolean(din);
			case 107:
				return DeserializeShort(din);
			case 108:
				return DeserializeLong(din);
			case 98:
				return DeserializeByte(din);
			case 102:
				return DeserializeFloat(din);
			case 100:
				return DeserializeDouble(din);
			case 121:
				return DeserializeArray(din);
			case 99:
			{
				byte customTypeCode = din.ReadByte();
				return DeserializeCustom(din, customTypeCode);
			}
			case 122:
				return DeserializeObjectArray(din);
			case 101:
				return DeserializeEventData(din);
			case 113:
				return DeserializeOperationRequest(din, flags);
			case 112:
				return DeserializeOperationResponse(din, flags);
			case 0:
			case 42:
				return null;
			default:
				throw new Exception("Deserialize(): " + type + " pos: " + din.Position + " bytes: " + din.Length + ". " + SupportClass.ByteArrayToString(din.GetBuffer()));
			}
		}

		public override byte DeserializeByte(StreamBuffer din)
		{
			return din.ReadByte();
		}

		private bool DeserializeBoolean(StreamBuffer din)
		{
			return din.ReadByte() != 0;
		}

		public override short DeserializeShort(StreamBuffer din)
		{
			lock (memShort)
			{
				byte[] array = memShort;
				din.Read(array, 0, 2);
				return (short)((array[0] << 8) | array[1]);
			}
		}

		private int DeserializeInteger(StreamBuffer din)
		{
			lock (memInteger)
			{
				byte[] array = memInteger;
				din.Read(array, 0, 4);
				return (array[0] << 24) | (array[1] << 16) | (array[2] << 8) | array[3];
			}
		}

		private long DeserializeLong(StreamBuffer din)
		{
			lock (memLong)
			{
				byte[] array = memLong;
				din.Read(array, 0, 8);
				if (BitConverter.IsLittleEndian)
				{
					return (long)(((ulong)array[0] << 56) | ((ulong)array[1] << 48) | ((ulong)array[2] << 40) | ((ulong)array[3] << 32) | ((ulong)array[4] << 24) | ((ulong)array[5] << 16) | ((ulong)array[6] << 8) | array[7]);
				}
				return BitConverter.ToInt64(array, 0);
			}
		}

		private float DeserializeFloat(StreamBuffer din)
		{
			lock (memFloat)
			{
				byte[] array = memFloat;
				din.Read(array, 0, 4);
				if (BitConverter.IsLittleEndian)
				{
					byte b = array[0];
					byte b2 = array[1];
					array[0] = array[3];
					array[1] = array[2];
					array[2] = b2;
					array[3] = b;
				}
				return BitConverter.ToSingle(array, 0);
			}
		}

		private double DeserializeDouble(StreamBuffer din)
		{
			lock (memDouble)
			{
				byte[] array = memDouble;
				din.Read(array, 0, 8);
				if (BitConverter.IsLittleEndian)
				{
					byte b = array[0];
					byte b2 = array[1];
					byte b3 = array[2];
					byte b4 = array[3];
					array[0] = array[7];
					array[1] = array[6];
					array[2] = array[5];
					array[3] = array[4];
					array[4] = b4;
					array[5] = b3;
					array[6] = b2;
					array[7] = b;
				}
				return BitConverter.ToDouble(array, 0);
			}
		}

		private string DeserializeString(StreamBuffer din)
		{
			short num = DeserializeShort(din);
			if (num == 0)
			{
				return string.Empty;
			}
			if (num < 0)
			{
				throw new NotSupportedException("Received string type with unsupported length: " + num);
			}
			int offset = 0;
			byte[] bufferAndAdvance = din.GetBufferAndAdvance(num, out offset);
			return Encoding.UTF8.GetString(bufferAndAdvance, offset, num);
		}

		private Array DeserializeArray(StreamBuffer din)
		{
			short num = DeserializeShort(din);
			byte b = din.ReadByte();
			Array array = null;
			switch (b)
			{
			case 121:
			{
				Array array3 = DeserializeArray(din);
				Type type = array3.GetType();
				array = Array.CreateInstance(type, num);
				array.SetValue(array3, 0);
				for (short num5 = 1; num5 < num; num5++)
				{
					array3 = DeserializeArray(din);
					array.SetValue(array3, num5);
				}
				break;
			}
			case 120:
			{
				array = Array.CreateInstance(typeof(byte[]), num);
				for (short num6 = 0; num6 < num; num6++)
				{
					Array value3 = DeserializeByteArray(din);
					array.SetValue(value3, num6);
				}
				break;
			}
			case 98:
				array = DeserializeByteArray(din, num);
				break;
			case 105:
				array = DeserializeIntArray(din, num);
				break;
			case 99:
			{
				byte key = din.ReadByte();
				if (Protocol.CodeDict.TryGetValue(key, out var value))
				{
					array = Array.CreateInstance(value.Type, num);
					for (int i = 0; i < num; i++)
					{
						short num3 = DeserializeShort(din);
						if (num3 < 0)
						{
							throw new InvalidDataException("DeserializeArray read negative objLength value: " + num3 + " before position: " + din.Position);
						}
						if (value.DeserializeStreamFunction == null)
						{
							byte[] array2 = new byte[num3];
							din.Read(array2, 0, num3);
							array.SetValue(value.DeserializeFunction(array2), i);
							continue;
						}
						int position = din.Position;
						object value2 = value.DeserializeStreamFunction(din, num3);
						int num4 = din.Position - position;
						if (num4 != num3)
						{
							din.Position = position + num3;
						}
						array.SetValue(value2, i);
					}
					break;
				}
				throw new Exception("Cannot find deserializer for custom type: " + key);
			}
			case 68:
			{
				Array arrayResult = null;
				DeserializeDictionaryArray(din, num, out arrayResult);
				return arrayResult;
			}
			default:
			{
				array = CreateArrayByType(b, num);
				for (short num2 = 0; num2 < num; num2++)
				{
					array.SetValue(Deserialize(din, b), num2);
				}
				break;
			}
			}
			return array;
		}

		private byte[] DeserializeByteArray(StreamBuffer din, int size = -1)
		{
			if (size == -1)
			{
				size = DeserializeInteger(din);
			}
			byte[] array = new byte[size];
			din.Read(array, 0, size);
			return array;
		}

		private int[] DeserializeIntArray(StreamBuffer din, int size = -1)
		{
			if (size == -1)
			{
				size = DeserializeInteger(din);
			}
			int[] array = new int[size];
			for (int i = 0; i < size; i++)
			{
				array[i] = DeserializeInteger(din);
			}
			return array;
		}

		private string[] DeserializeStringArray(StreamBuffer din)
		{
			int num = DeserializeShort(din);
			string[] array = new string[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = DeserializeString(din);
			}
			return array;
		}

		private object[] DeserializeObjectArray(StreamBuffer din)
		{
			short num = DeserializeShort(din);
			object[] array = new object[num];
			for (int i = 0; i < num; i++)
			{
				byte type = din.ReadByte();
				array[i] = Deserialize(din, type);
			}
			return array;
		}

		private Hashtable DeserializeHashTable(StreamBuffer din)
		{
			int num = DeserializeShort(din);
			Hashtable hashtable = new Hashtable(num);
			for (int i = 0; i < num; i++)
			{
				object obj = Deserialize(din, din.ReadByte());
				object value = Deserialize(din, din.ReadByte());
				if (obj != null)
				{
					hashtable[obj] = value;
				}
			}
			return hashtable;
		}

		private IDictionary DeserializeDictionary(StreamBuffer din)
		{
			byte b = din.ReadByte();
			byte b2 = din.ReadByte();
			if (b == 68 || b == 121)
			{
				throw new NotSupportedException("Client serialization protocol 1.6 does not support nesting Dictionary or Arrays into Dictionary keys.");
			}
			if (b2 == 68 || b2 == 121)
			{
				throw new NotSupportedException("Client serialization protocol 1.6 does not support nesting Dictionary or Arrays into Dictionary values.");
			}
			int num = DeserializeShort(din);
			bool flag = b == 0 || b == 42;
			bool flag2 = b2 == 0 || b2 == 42;
			Type typeOfCode = GetTypeOfCode(b);
			Type typeOfCode2 = GetTypeOfCode(b2);
			Type type = typeof(Dictionary<, >).MakeGenericType(typeOfCode, typeOfCode2);
			IDictionary dictionary = Activator.CreateInstance(type) as IDictionary;
			for (int i = 0; i < num; i++)
			{
				object obj = Deserialize(din, flag ? din.ReadByte() : b);
				object value = Deserialize(din, flag2 ? din.ReadByte() : b2);
				if (obj != null)
				{
					dictionary.Add(obj, value);
				}
			}
			return dictionary;
		}

		private bool DeserializeDictionaryArray(StreamBuffer din, short size, out Array arrayResult)
		{
			byte keyTypeCode;
			byte valTypeCode;
			Type type = DeserializeDictionaryType(din, out keyTypeCode, out valTypeCode);
			arrayResult = Array.CreateInstance(type, size);
			for (short num = 0; num < size; num++)
			{
				if (!(Activator.CreateInstance(type) is IDictionary dictionary))
				{
					return false;
				}
				short num2 = DeserializeShort(din);
				for (int i = 0; i < num2; i++)
				{
					object obj;
					if (keyTypeCode != 0)
					{
						obj = Deserialize(din, keyTypeCode);
					}
					else
					{
						byte type2 = din.ReadByte();
						obj = Deserialize(din, type2);
					}
					object value;
					if (valTypeCode != 0)
					{
						value = Deserialize(din, valTypeCode);
					}
					else
					{
						byte type3 = din.ReadByte();
						value = Deserialize(din, type3);
					}
					if (obj != null)
					{
						dictionary.Add(obj, value);
					}
				}
				arrayResult.SetValue(dictionary, num);
			}
			return true;
		}

		private Type DeserializeDictionaryType(StreamBuffer reader, out byte keyTypeCode, out byte valTypeCode)
		{
			keyTypeCode = reader.ReadByte();
			valTypeCode = reader.ReadByte();
			GpType gpType = (GpType)keyTypeCode;
			GpType gpType2 = (GpType)valTypeCode;
			Type type;
			if (gpType == GpType.Unknown)
			{
				type = typeof(object);
			}
			else
			{
				if (gpType == GpType.Dictionary || gpType == GpType.Array)
				{
					throw new NotSupportedException("Client serialization protocol 1.6 does not support nesting Dictionary or Arrays into Dictionary keys.");
				}
				type = GetTypeOfCode(keyTypeCode);
			}
			Type type2;
			if (gpType2 == GpType.Unknown)
			{
				type2 = typeof(object);
			}
			else
			{
				if (gpType2 == GpType.Dictionary || gpType2 == GpType.Array)
				{
					throw new NotSupportedException("Client serialization protocol 1.6 does not support nesting Dictionary or Arrays into Dictionary values.");
				}
				type2 = GetTypeOfCode(valTypeCode);
			}
			return typeof(Dictionary<, >).MakeGenericType(type, type2);
		}
	}
	public class InvalidDataException : Exception
	{
		public InvalidDataException(string message)
			: base(message)
		{
		}
	}
	public class Protocol18 : IProtocol
	{
		public enum GpType : byte
		{
			Unknown = 0,
			Boolean = 2,
			Byte = 3,
			Short = 4,
			Float = 5,
			Double = 6,
			String = 7,
			Null = 8,
			CompressedInt = 9,
			CompressedLong = 10,
			Int1 = 11,
			Int1_ = 12,
			Int2 = 13,
			Int2_ = 14,
			L1 = 15,
			L1_ = 16,
			L2 = 17,
			L2_ = 18,
			Custom = 19,
			CustomTypeSlim = 128,
			Dictionary = 20,
			Hashtable = 21,
			ObjectArray = 23,
			OperationRequest = 24,
			OperationResponse = 25,
			EventData = 26,
			BooleanFalse = 27,
			BooleanTrue = 28,
			ShortZero = 29,
			IntZero = 30,
			LongZero = 31,
			FloatZero = 32,
			DoubleZero = 33,
			ByteZero = 34,
			Array = 64,
			BooleanArray = 66,
			ByteArray = 67,
			ShortArray = 68,
			DoubleArray = 70,
			FloatArray = 69,
			StringArray = 71,
			HashtableArray = 85,
			DictionaryArray = 84,
			CustomTypeArray = 83,
			CompressedIntArray = 73,
			CompressedLongArray = 74
		}

		private readonly byte[] versionBytes = new byte[2] { 1, 8 };

		private static readonly byte[] boolMasks = new byte[8] { 1, 2, 4, 8, 16, 32, 64, 128 };

		private readonly double[] memDoubleBlock = new double[1];

		private readonly float[] memFloatBlock = new float[1];

		private readonly byte[] memCustomTypeBodyLengthSerialized = new byte[5];

		private readonly byte[] memCompressedUInt32 = new byte[5];

		private byte[] memCompressedUInt64 = new byte[10];

		public override string ProtocolType => "GpBinaryV18";

		public override byte[] VersionBytes => versionBytes;

		public override void Serialize(StreamBuffer dout, object serObject, bool setType)
		{
			Write(dout, serObject, setType);
		}

		public override void SerializeShort(StreamBuffer dout, short serObject, bool setType)
		{
			WriteInt16(dout, serObject, setType);
		}

		public override void SerializeString(StreamBuffer dout, string serObject, bool setType)
		{
			WriteString(dout, serObject, setType);
		}

		public override object Deserialize(StreamBuffer din, byte type, DeserializationFlags flags = DeserializationFlags.None)
		{
			return Read(din, type);
		}

		public override short DeserializeShort(StreamBuffer din)
		{
			return ReadInt16(din);
		}

		public override byte DeserializeByte(StreamBuffer din)
		{
			return ReadByte(din);
		}

		private static Type GetAllowedDictionaryKeyTypes(GpType gpType)
		{
			switch (gpType)
			{
			case GpType.Byte:
			case GpType.ByteZero:
				return typeof(byte);
			case GpType.Short:
			case GpType.ShortZero:
				return typeof(short);
			case GpType.Float:
			case GpType.FloatZero:
				return typeof(float);
			case GpType.Double:
			case GpType.DoubleZero:
				return typeof(double);
			case GpType.String:
				return typeof(string);
			case GpType.CompressedInt:
			case GpType.Int1:
			case GpType.Int1_:
			case GpType.Int2:
			case GpType.Int2_:
			case GpType.IntZero:
				return typeof(int);
			case GpType.CompressedLong:
			case GpType.L1:
			case GpType.L1_:
			case GpType.L2:
			case GpType.L2_:
			case GpType.LongZero:
				return typeof(long);
			default:
				throw new Exception($"{gpType} is not a valid Type as Dictionary key.");
			}
		}

		private static Type GetClrArrayType(GpType gpType)
		{
			switch (gpType)
			{
			case GpType.Boolean:
			case GpType.BooleanFalse:
			case GpType.BooleanTrue:
				return typeof(bool);
			case GpType.Byte:
			case GpType.ByteZero:
				return typeof(byte);
			case GpType.Short:
			case GpType.ShortZero:
				return typeof(short);
			case GpType.Float:
			case GpType.FloatZero:
				return typeof(float);
			case GpType.Double:
			case GpType.DoubleZero:
				return typeof(double);
			case GpType.String:
				return typeof(string);
			case GpType.CompressedInt:
			case GpType.Int1:
			case GpType.Int1_:
			case GpType.Int2:
			case GpType.Int2_:
			case GpType.IntZero:
				return typeof(int);
			case GpType.CompressedLong:
			case GpType.L1:
			case GpType.L1_:
			case GpType.L2:
			case GpType.L2_:
			case GpType.LongZero:
				return typeof(long);
			case GpType.Hashtable:
				return typeof(Hashtable);
			case GpType.OperationRequest:
				return typeof(OperationRequest);
			case GpType.OperationResponse:
				return typeof(OperationResponse);
			case GpType.EventData:
				return typeof(EventData);
			case GpType.BooleanArray:
				return typeof(bool[]);
			case GpType.ByteArray:
				return typeof(byte[]);
			case GpType.ShortArray:
				return typeof(short[]);
			case GpType.DoubleArray:
				return typeof(double[]);
			case GpType.FloatArray:
				return typeof(float[]);
			case GpType.StringArray:
				return typeof(string[]);
			case GpType.HashtableArray:
				return typeof(Hashtable[]);
			case GpType.CompressedIntArray:
				return typeof(int[]);
			case GpType.CompressedLongArray:
				return typeof(long[]);
			default:
				return null;
			}
		}

		private GpType GetCodeOfType(Type type)
		{
			if (type == null)
			{
				return GpType.Null;
			}
			if (type == typeof(StructWrapper<>))
			{
				return GpType.Unknown;
			}
			if (type.IsPrimitive || type.IsEnum)
			{
				TypeCode typeCode = Type.GetTypeCode(type);
				return GetCodeOfTypeCode(typeCode);
			}
			if (type == typeof(string))
			{
				return GpType.String;
			}
			if (type.IsArray)
			{
				Type elementType = type.GetElementType();
				if (elementType == null)
				{
					throw new InvalidDataException($"Arrays of type {type} are not supported");
				}
				if (elementType.IsPrimitive)
				{
					switch (Type.GetTypeCode(elementType))
					{
					case TypeCode.Byte:
						return GpType.ByteArray;
					case TypeCode.Int16:
						return GpType.ShortArray;
					case TypeCode.Int32:
						return GpType.CompressedIntArray;
					case TypeCode.Int64:
						return GpType.CompressedLongArray;
					case TypeCode.Boolean:
						return GpType.BooleanArray;
					case TypeCode.Single:
						return GpType.FloatArray;
					case TypeCode.Double:
						return GpType.DoubleArray;
					}
				}
				if (elementType.IsArray)
				{
					return GpType.Array;
				}
				if (elementType == typeof(string))
				{
					return GpType.StringArray;
				}
				if (elementType == typeof(object) || elementType == typeof(StructWrapper))
				{
					return GpType.ObjectArray;
				}
				if (elementType == typeof(Hashtable))
				{
					return GpType.HashtableArray;
				}
				if (elementType.IsGenericType && typeof(Dictionary<, >) == elementType.GetGenericTypeDefinition())
				{
					return GpType.DictionaryArray;
				}
				return GpType.CustomTypeArray;
			}
			if (type == typeof(Hashtable))
			{
				return GpType.Hashtable;
			}
			if (type == typeof(List<object>))
			{
				return GpType.ObjectArray;
			}
			if (type.IsGenericType && typeof(Dictionary<, >) == type.GetGenericTypeDefinition())
			{
				return GpType.Dictionary;
			}
			if (type == typeof(EventData))
			{
				return GpType.EventData;
			}
			if (type == typeof(OperationRequest))
			{
				return GpType.OperationRequest;
			}
			if (type == typeof(OperationResponse))
			{
				return GpType.OperationResponse;
			}
			return GpType.Unknown;
		}

		private GpType GetCodeOfTypeCode(TypeCode type)
		{
			return type switch
			{
				TypeCode.Byte => GpType.Byte, 
				TypeCode.String => GpType.String, 
				TypeCode.Boolean => GpType.Boolean, 
				TypeCode.Int16 => GpType.Short, 
				TypeCode.Int32 => GpType.CompressedInt, 
				TypeCode.Int64 => GpType.CompressedLong, 
				TypeCode.Single => GpType.Float, 
				TypeCode.Double => GpType.Double, 
				_ => GpType.Unknown, 
			};
		}

		private object Read(StreamBuffer stream, DeserializationFlags flags, ParameterDictionary parameters)
		{
			return Read(stream, ReadByte(stream), flags, parameters);
		}

		private object Read(StreamBuffer stream, byte gpType, DeserializationFlags flags = DeserializationFlags.None, ParameterDictionary parameters = null)
		{
			int num = ((gpType >= 128) ? (gpType - 128) : gpType);
			num = ((num >= 64) ? (num - 64) : num);
			bool flag = (flags & DeserializationFlags.WrapIncomingStructs) == DeserializationFlags.WrapIncomingStructs;
			if (gpType >= 128 && gpType <= 228)
			{
				return ReadCustomType(stream, gpType);
			}
			switch ((GpType)gpType)
			{
			case GpType.Boolean:
			{
				bool flag3 = ReadBoolean(stream);
				return flag ? parameters.wrapperPools.Acquire(flag3) : ((object)flag3);
			}
			case GpType.BooleanTrue:
			{
				bool flag4 = true;
				return flag ? parameters.wrapperPools.Acquire(flag4) : ((object)flag4);
			}
			case GpType.BooleanFalse:
			{
				bool flag2 = false;
				return flag ? parameters.wrapperPools.Acquire(flag2) : ((object)flag2);
			}
			case GpType.Byte:
			{
				byte b = ReadByte(stream);
				return flag ? parameters.wrapperPools.Acquire(b) : ((object)b);
			}
			case GpType.ByteZero:
			{
				byte b2 = 0;
				return flag ? parameters.wrapperPools.Acquire(b2) : ((object)b2);
			}
			case GpType.Short:
			{
				short num3 = ReadInt16(stream);
				return flag ? parameters.wrapperPools.Acquire(num3) : ((object)num3);
			}
			case GpType.ShortZero:
			{
				short num19 = 0;
				return flag ? parameters.wrapperPools.Acquire(num19) : ((object)num19);
			}
			case GpType.Float:
			{
				float num12 = ReadSingle(stream);
				return flag ? parameters.wrapperPools.Acquire(num12) : ((object)num12);
			}
			case GpType.FloatZero:
			{
				float num10 = 0f;
				return flag ? parameters.wrapperPools.Acquire(num10) : ((object)num10);
			}
			case GpType.Double:
			{
				double num15 = ReadDouble(stream);
				return flag ? parameters.wrapperPools.Acquire(num15) : ((object)num15);
			}
			case GpType.DoubleZero:
			{
				double num13 = 0.0;
				return flag ? parameters.wrapperPools.Acquire(num13) : ((object)num13);
			}
			case GpType.String:
				return ReadString(stream);
			case GpType.Int1:
			{
				int num4 = ReadInt1(stream, signNegative: false);
				return flag ? parameters.wrapperPools.Acquire(num4) : ((object)num4);
			}
			case GpType.Int2:
			{
				int num18 = ReadInt2(stream, signNegative: false);
				return flag ? parameters.wrapperPools.Acquire(num18) : ((object)num18);
			}
			case GpType.Int1_:
			{
				int num16 = ReadInt1(stream, signNegative: true);
				return flag ? parameters.wrapperPools.Acquire(num16) : ((object)num16);
			}
			case GpType.Int2_:
			{
				int num9 = ReadInt2(stream, signNegative: true);
				return flag ? parameters.wrapperPools.Acquire(num9) : ((object)num9);
			}
			case GpType.CompressedInt:
			{
				int num7 = ReadCompressedInt32(stream);
				return flag ? parameters.wrapperPools.Acquire(num7) : ((object)num7);
			}
			case GpType.IntZero:
			{
				int num5 = 0;
				return flag ? parameters.wrapperPools.Acquire(num5) : ((object)num5);
			}
			case GpType.L1:
			{
				long num17 = ReadInt1(stream, signNegative: false);
				return flag ? parameters.wrapperPools.Acquire(num17) : ((object)num17);
			}
			case GpType.L2:
			{
				long num14 = ReadInt2(stream, signNegative: false);
				return flag ? parameters.wrapperPools.Acquire(num14) : ((object)num14);
			}
			case GpType.L1_:
			{
				long num11 = ReadInt1(stream, signNegative: true);
				return flag ? parameters.wrapperPools.Acquire(num11) : ((object)num11);
			}
			case GpType.L2_:
			{
				long num8 = ReadInt2(stream, signNegative: true);
				return flag ? parameters.wrapperPools.Acquire(num8) : ((object)num8);
			}
			case GpType.CompressedLong:
			{
				long num6 = ReadCompressedInt64(stream);
				return flag ? parameters.wrapperPools.Acquire(num6) : ((object)num6);
			}
			case GpType.LongZero:
			{
				long num2 = 0L;
				return flag ? parameters.wrapperPools.Acquire(num2) : ((object)num2);
			}
			case GpType.Hashtable:
				return ReadHashtable(stream, flags, parameters);
			case GpType.Dictionary:
				return ReadDictionary(stream, flags, parameters);
			case GpType.Custom:
				return ReadCustomType(stream, 0);
			case GpType.OperationRequest:
				return DeserializeOperationRequest(stream);
			case GpType.OperationResponse:
				return DeserializeOperationResponse(stream, flags);
			case GpType.EventData:
				return DeserializeEventData(stream);
			case GpType.ObjectArray:
				return ReadObjectArray(stream, flags, parameters);
			case GpType.BooleanArray:
				return ReadBooleanArray(stream);
			case GpType.ByteArray:
				return ReadByteArray(stream);
			case GpType.ShortArray:
				return ReadInt16Array(stream);
			case GpType.DoubleArray:
				return ReadDoubleArray(stream);
			case GpType.FloatArray:
				return ReadSingleArray(stream);
			case GpType.StringArray:
				return ReadStringArray(stream);
			case GpType.HashtableArray:
				return ReadHashtableArray(stream, flags, parameters);
			case GpType.DictionaryArray:
				return ReadDictionaryArray(stream, flags, parameters);
			case GpType.CustomTypeArray:
				return ReadCustomTypeArray(stream);
			case GpType.CompressedIntArray:
				return ReadCompressedInt32Array(stream);
			case GpType.CompressedLongArray:
				return ReadCompressedInt64Array(stream);
			case GpType.Array:
				return ReadArrayInArray(stream, flags, parameters);
			case GpType.Null:
				return null;
			default:
				throw new InvalidDataException(string.Format("GpTypeCode not found: {0}(0x{0:X}). Is not a CustomType either. Pos: {1} Available: {2}", gpType, stream.Position, stream.Available));
			}
		}

		internal bool ReadBoolean(StreamBuffer stream)
		{
			return stream.ReadByte() > 0;
		}

		internal byte ReadByte(StreamBuffer stream)
		{
			return stream.ReadByte();
		}

		internal short ReadInt16(StreamBuffer stream)
		{
			int offset;
			byte[] bufferAndAdvance = stream.GetBufferAndAdvance(2, out offset);
			return (short)(bufferAndAdvance[offset++] | (bufferAndAdvance[offset] << 8));
		}

		internal ushort ReadUShort(StreamBuffer stream)
		{
			int offset;
			byte[] bufferAndAdvance = stream.GetBufferAndAdvance(2, out offset);
			return (ushort)(bufferAndAdvance[offset++] | (bufferAndAdvance[offset] << 8));
		}

		internal int ReadInt32(StreamBuffer stream)
		{
			int offset;
			byte[] bufferAndAdvance = stream.GetBufferAndAdvance(4, out offset);
			return (bufferAndAdvance[offset++] << 24) | (bufferAndAdvance[offset++] << 16) | (bufferAndAdvance[offset++] << 8) | bufferAndAdvance[offset];
		}

		internal long ReadInt64(StreamBuffer stream)
		{
			int offset;
			byte[] bufferAndAdvance = stream.GetBufferAndAdvance(4, out offset);
			return (long)(((ulong)bufferAndAdvance[offset++] << 56) | ((ulong)bufferAndAdvance[offset++] << 48) | ((ulong)bufferAndAdvance[offset++] << 40) | ((ulong)bufferAndAdvance[offset++] << 32) | ((ulong)bufferAndAdvance[offset++] << 24) | ((ulong)bufferAndAdvance[offset++] << 16) | ((ulong)bufferAndAdvance[offset++] << 8) | bufferAndAdvance[offset]);
		}

		internal float ReadSingle(StreamBuffer stream)
		{
			int offset;
			byte[] bufferAndAdvance = stream.GetBufferAndAdvance(4, out offset);
			return BitConverter.ToSingle(bufferAndAdvance, offset);
		}

		internal double ReadDouble(StreamBuffer stream)
		{
			int offset;
			byte[] bufferAndAdvance = stream.GetBufferAndAdvance(8, out offset);
			return BitConverter.ToDouble(bufferAndAdvance, offset);
		}

		internal ByteArraySlice ReadNonAllocByteArray(StreamBuffer stream)
		{
			uint num = ReadCompressedUInt32(stream);
			ByteArraySlice byteArraySlice = ByteArraySlicePool.Acquire((int)num);
			stream.Read(byteArraySlice.Buffer, 0, (int)num);
			byteArraySlice.Count = (int)num;
			return byteArraySlice;
		}

		internal byte[] ReadByteArray(StreamBuffer stream)
		{
			uint num = ReadCompressedUInt32(stream);
			byte[] array = new byte[num];
			stream.Read(array, 0, (int)num);
			return array;
		}

		public object ReadCustomType(StreamBuffer stream, byte gpType = 0)
		{
			byte b = 0;
			b = ((gpType != 0) ? ((byte)(gpType - 128)) : stream.ReadByte());
			int num = (int)ReadCompressedUInt32(stream);
			if (num < 0)
			{
				throw new InvalidDataException("ReadCustomType read negative size value: " + num + " before position: " + stream.Position);
			}
			bool flag = num <= stream.Available;
			if (!flag || num > 32767 || !Protocol.CodeDict.TryGetValue(b, out var value))
			{
				UnknownType unknownType = new UnknownType
				{
					TypeCode = b,
					Size = num
				};
				int num2 = (flag ? num : stream.Available);
				if (num2 > 0)
				{
					byte[] array = new byte[num2];
					stream.Read(array, 0, num2);
					unknownType.Data = array;
				}
				return unknownType;
			}
			if (value.DeserializeStreamFunction == null)
			{
				byte[] array2 = new byte[num];
				stream.Read(array2, 0, num);
				return value.DeserializeFunction(array2);
			}
			int position = stream.Position;
			object result = value.DeserializeStreamFunction(stream, (short)num);
			int num3 = stream.Position - position;
			if (num3 != num)
			{
				stream.Position = position + num;
			}
			return result;
		}

		public override EventData DeserializeEventData(StreamBuffer din, EventData target = null, DeserializationFlags flags = DeserializationFlags.None)
		{
			EventData eventData;
			if (target != null)
			{
				target.Reset();
				eventData = target;
			}
			else
			{
				eventData = new EventData();
			}
			eventData.Code = ReadByte(din);
			short num = ReadByte(din);
			bool flag = (flags & DeserializationFlags.AllowPooledByteArray) == DeserializationFlags.AllowPooledByteArray;
			for (uint num2 = 0u; num2 < num; num2++)
			{
				byte b = din.ReadByte();
				byte b2 = din.ReadByte();
				object value;
				if (!flag)
				{
					value = Read(din, b2, flags, eventData.Parameters);
				}
				else if (b2 == 67)
				{
					value = ReadNonAllocByteArray(din);
				}
				else
				{
					if (b == eventData.SenderKey)
					{
						switch ((GpType)b2)
						{
						case GpType.Int1:
							eventData.Sender = ReadInt1(din, signNegative: false);
							break;
						case GpType.Int2:
							eventData.Sender = ReadInt2(din, signNegative: false);
							break;
						case GpType.Int1_:
							eventData.Sender = ReadInt1(din, signNegative: true);
							break;
						case GpType.Int2_:
							eventData.Sender = ReadInt2(din, signNegative: true);
							break;
						case GpType.CompressedInt:
							eventData.Sender = ReadCompressedInt32(din);
							break;
						case GpType.IntZero:
							eventData.Sender = 0;
							break;
						}
						continue;
					}
					value = Read(din, b2, flags, eventData.Parameters);
				}
				eventData.Parameters.Add(b, value);
			}
			return eventData;
		}

		[Obsolete("Use ParameterDictionary instead.")]
		private Dictionary<byte, object> ReadParameterTable(StreamBuffer stream, Dictionary<byte, object> target = null, DeserializationFlags flags = DeserializationFlags.None)
		{
			short num = ReadByte(stream);
			Dictionary<byte, object> dictionary = ((target != null) ? target : new Dictionary<byte, object>(num));
			for (uint num2 = 0u; num2 < num; num2++)
			{
				byte key = stream.ReadByte();
				byte b = stream.ReadByte();
				object value = ((b != 67 || (flags & DeserializationFlags.AllowPooledByteArray) != DeserializationFlags.AllowPooledByteArray) ? Read(stream, b, flags) : ReadNonAllocByteArray(stream));
				dictionary[key] = value;
			}
			return dictionary;
		}

		private ParameterDictionary ReadParameterDictionary(StreamBuffer stream, ParameterDictionary target = null, DeserializationFlags flags = DeserializationFlags.None)
		{
			short num = ReadByte(stream);
			ParameterDictionary parameterDictionary = ((target != null) ? target : new ParameterDictionary(num));
			bool flag = (flags & DeserializationFlags.AllowPooledByteArray) == DeserializationFlags.AllowPooledByteArray;
			for (uint num2 = 0u; num2 < num; num2++)
			{
				byte code = stream.ReadByte();
				byte b = stream.ReadByte();
				object value = ((!flag || b != 67) ? Read(stream, b, flags, parameterDictionary) : ReadNonAllocByteArray(stream));
				parameterDictionary.Add(code, value);
			}
			return parameterDictionary;
		}

		public Hashtable ReadHashtable(StreamBuffer stream, DeserializationFlags flags, ParameterDictionary parameters)
		{
			int num = (int)ReadCompressedUInt32(stream);
			Hashtable hashtable = new Hashtable(num);
			for (uint num2 = 0u; num2 < num; num2++)
			{
				object obj = Read(stream, flags, parameters);
				object value = Read(stream, flags, parameters);
				if (obj != null)
				{
					if (!(obj is StructWrapper<byte> obj2))
					{
						hashtable[obj] = value;
					}
					else
					{
						hashtable[obj2.Unwrap<byte>()] = value;
					}
				}
			}
			return hashtable;
		}

		public int[] ReadIntArray(StreamBuffer stream)
		{
			int num = ReadInt32(stream);
			int[] array = new int[num];
			for (uint num2 = 0u; num2 < num; num2++)
			{
				array[num2] = ReadInt32(stream);
			}
			return array;
		}

		public override OperationRequest DeserializeOperationRequest(StreamBuffer din, DeserializationFlags flags = DeserializationFlags.None)
		{
			OperationRequest operationRequest = new OperationRequest();
			operationRequest.OperationCode = ReadByte(din);
			operationRequest.Parameters = ReadParameterDictionary(din, operationRequest.Parameters, flags);
			return operationRequest;
		}

		public override OperationResponse DeserializeOperationResponse(StreamBuffer stream, DeserializationFlags flags = DeserializationFlags.None)
		{
			OperationResponse operationResponse = new OperationResponse();
			operationResponse.OperationCode = ReadByte(stream);
			operationResponse.ReturnCode = ReadInt16(stream);
			operationResponse.DebugMessage = Read(stream, ReadByte(stream), flags, operationResponse.Parameters) as string;
			operationResponse.Parameters = ReadParameterDictionary(stream, operationResponse.Parameters, flags);
			return operationResponse;
		}

		public override DisconnectMessage DeserializeDisconnectMessage(StreamBuffer stream)
		{
			DisconnectMessage disconnectMessage = new DisconnectMessage();
			disconnectMessage.Code = ReadInt16(stream);
			disconnectMessage.DebugMessage = Read(stream, ReadByte(stream)) as string;
			disconnectMessage.Parameters = ReadParameterTable(stream);
			return disconnectMessage;
		}

		internal string ReadString(StreamBuffer stream)
		{
			int num = (int)ReadCompressedUInt32(stream);
			if (num == 0)
			{
				return string.Empty;
			}
			int offset = 0;
			byte[] bufferAndAdvance = stream.GetBufferAndAdvance(num, out offset);
			return Encoding.UTF8.GetString(bufferAndAdvance, offset, num);
		}

		private object ReadCustomTypeArray(StreamBuffer stream)
		{
			uint num = ReadCompressedUInt32(stream);
			byte b = stream.ReadByte();
			if (!Protocol.CodeDict.TryGetValue(b, out var value))
			{
				int position = stream.Position;
				for (uint num2 = 0u; num2 < num; num2++)
				{
					int num3 = (int)ReadCompressedUInt32(stream);
					int available = stream.Available;
					int num4 = ((num3 > available) ? available : num3);
					stream.Position += num4;
				}
				return new UnknownType[1]
				{
					new UnknownType
					{
						TypeCode = b,
						Size = stream.Position - position
					}
				};
			}
			Array array = Array.CreateInstance(value.Type, (int)num);
			for (uint num5 = 0u; num5 < num; num5++)
			{
				int num6 = (int)ReadCompressedUInt32(stream);
				if (num6 < 0)
				{
					throw new InvalidDataException("ReadCustomTypeArray read negative size value: " + num6 + " before position: " + stream.Position);
				}
				if (num6 > stream.Available || num6 > 32767)
				{
					stream.Position = stream.Length;
					throw new InvalidDataException("ReadCustomTypeArray read size value: " + num6 + " larger than short.MaxValue or available data: " + stream.Available);
				}
				object obj;
				if (value.DeserializeStreamFunction == null)
				{
					byte[] array2 = new byte[num6];
					stream.Read(array2, 0, num6);
					obj = value.DeserializeFunction(array2);
				}
				else
				{
					int position2 = stream.Position;
					obj = value.DeserializeStreamFunction(stream, (short)num6);
					int num7 = stream.Position - position2;
					if (num7 != num6)
					{
						stream.Position = position2 + num6;
					}
				}
				if (obj != null && value.Type.IsAssignableFrom(obj.GetType()))
				{
					array.SetValue(obj, (int)num5);
				}
			}
			return array;
		}

		private Type ReadDictionaryType(StreamBuffer stream, out GpType keyReadType, out GpType valueReadType)
		{
			keyReadType = (GpType)stream.ReadByte();
			GpType gpType = (valueReadType = (GpType)stream.ReadByte());
			Type type = ((keyReadType != GpType.Unknown) ? GetAllowedDictionaryKeyTypes(keyReadType) : typeof(object));
			Type type2;
			switch (gpType)
			{
			case GpType.Unknown:
				type2 = typeof(object);
				break;
			case GpType.Dictionary:
				type2 = ReadDictionaryType(stream);
				break;
			case GpType.Array:
				type2 = GetDictArrayType(stream);
				valueReadType = GpType.Unknown;
				break;
			case GpType.ObjectArray:
				type2 = typeof(object[]);
				break;
			case GpType.HashtableArray:
				type2 = typeof(Hashtable[]);
				break;
			default:
				type2 = GetClrArrayType(gpType);
				break;
			}
			return typeof(Dictionary<, >).MakeGenericType(type, type2);
		}

		private Type ReadDictionaryType(StreamBuffer stream)
		{
			GpType gpType = (GpType)stream.ReadByte();
			GpType gpType2 = (GpType)stream.ReadByte();
			Type type = ((gpType != GpType.Unknown) ? GetAllowedDictionaryKeyTypes(gpType) : typeof(object));
			Type type2 = gpType2 switch
			{
				GpType.Unknown => typeof(object), 
				GpType.Dictionary => ReadDictionaryType(stream), 
				GpType.Array => GetDictArrayType(stream), 
				_ => GetClrArrayType(gpType2), 
			};
			return typeof(Dictionary<, >).MakeGenericType(type, type2);
		}

		private Type GetDictArrayType(StreamBuffer stream)
		{
			GpType gpType = (GpType)stream.ReadByte();
			int num = 0;
			while (gpType == GpType.Array)
			{
				num++;
				gpType = (GpType)stream.ReadByte();
			}
			Type clrArrayType = GetClrArrayType(gpType);
			Type type = clrArrayType.MakeArrayType();
			for (uint num2 = 0u; num2 < num; num2++)
			{
				type = type.MakeArrayType();
			}
			return type;
		}

		private IDictionary ReadDictionary(StreamBuffer stream, DeserializationFlags flags, ParameterDictionary parameters)
		{
			GpType keyReadType;
			GpType valueReadType;
			Type type = ReadDictionaryType(stream, out keyReadType, out valueReadType);
			if (type == null)
			{
				return null;
			}
			if (!(Activator.CreateInstance(type) is IDictionary dictionary))
			{
				return null;
			}
			ReadDictionaryElements(stream, keyReadType, valueReadType, dictionary, flags, parameters);
			return dictionary;
		}

		private bool ReadDictionaryElements(StreamBuffer stream, GpType keyReadType, GpType valueReadType, IDictionary dictionary, DeserializationFlags flags, ParameterDictionary parameters)
		{
			uint num = ReadCompressedUInt32(stream);
			for (uint num2 = 0u; num2 < num; num2++)
			{
				object obj = ((keyReadType == GpType.Unknown) ? Read(stream, flags, parameters) : Read(stream, (byte)keyReadType));
				object value = ((valueReadType == GpType.Unknown) ? Read(stream, flags, parameters) : Read(stream, (byte)valueReadType));
				if (obj != null)
				{
					dictionary.Add(obj, value);
				}
			}
			return true;
		}

		private object[] ReadObjectArray(StreamBuffer stream, DeserializationFlags flags, ParameterDictionary parameters)
		{
			uint num = ReadCompressedUInt32(stream);
			object[] array = new object[num];
			for (uint num2 = 0u; num2 < num; num2++)
			{
				object obj = Read(stream, flags, parameters);
				array[num2] = obj;
			}
			return array;
		}

		private StructWrapper[] ReadWrapperArray(StreamBuffer stream, DeserializationFlags flags, ParameterDictionary parameters)
		{
			uint num = ReadCompressedUInt32(stream);
			StructWrapper[] array = new StructWrapper[num];
			for (uint num2 = 0u; num2 < num; num2++)
			{
				object obj = Read(stream, flags, parameters);
				array[num2] = obj as StructWrapper;
				if (obj == null)
				{
					System.Diagnostics.Debug.WriteLine("Error: ReadWrapperArray hit null");
				}
				if (array[num2] == null)
				{
					System.Diagnostics.Debug.WriteLine("Error: ReadWrapperArray null wrapper");
				}
			}
			return array;
		}

		private bool[] ReadBooleanArray(StreamBuffer stream)
		{
			uint num = ReadCompressedUInt32(stream);
			bool[] array = new bool[num];
			int num2 = (int)num / 8;
			int num3 = 0;
			while (num2 > 0)
			{
				byte b = stream.ReadByte();
				array[num3++] = (b & 1) == 1;
				array[num3++] = (b & 2) == 2;
				array[num3++] = (b & 4) == 4;
				array[num3++] = (b & 8) == 8;
				array[num3++] = (b & 0x10) == 16;
				array[num3++] = (b & 0x20) == 32;
				array[num3++] = (b & 0x40) == 64;
				array[num3++] = (b & 0x80) == 128;
				num2--;
			}
			if (num3 < num)
			{
				byte b2 = stream.ReadByte();
				int num4 = 0;
				while (num3 < num)
				{
					array[num3++] = (b2 & boolMasks[num4]) == boolMasks[num4];
					num4++;
				}
			}
			return array;
		}

		internal short[] ReadInt16Array(StreamBuffer stream)
		{
			uint num = ReadCompressedUInt32(stream);
			short[] array = new short[num];
			for (uint num2 = 0u; num2 < array.Length; num2++)
			{
				array[num2] = ReadInt16(stream);
			}
			return array;
		}

		private float[] ReadSingleArray(StreamBuffer stream)
		{
			int num = (int)ReadCompressedUInt32(stream);
			int num2 = num * 4;
			float[] array = new float[num];
			int offset;
			byte[] bufferAndAdvance = stream.GetBufferAndAdvance(num2, out offset);
			Buffer.BlockCopy(bufferAndAdvance, offset, array, 0, num2);
			return array;
		}

		private double[] ReadDoubleArray(StreamBuffer stream)
		{
			int num = (int)ReadCompressedUInt32(stream);
			int num2 = num * 8;
			double[] array = new double[num];
			int offset;
			byte[] bufferAndAdvance = stream.GetBufferAndAdvance(num2, out offset);
			Buffer.BlockCopy(bufferAndAdvance, offset, array, 0, num2);
			return array;
		}

		internal string[] ReadStringArray(StreamBuffer stream)
		{
			uint num = ReadCompressedUInt32(stream);
			string[] array = new string[num];
			for (uint num2 = 0u; num2 < array.Length; num2++)
			{
				array[num2] = ReadString(stream);
			}
			return array;
		}

		private Hashtable[] ReadHashtableArray(StreamBuffer stream, DeserializationFlags flags, ParameterDictionary parameters)
		{
			uint num = ReadCompressedUInt32(stream);
			Hashtable[] array = new Hashtable[num];
			for (uint num2 = 0u; num2 < num; num2++)
			{
				array[num2] = ReadHashtable(stream, flags, parameters);
			}
			return array;
		}

		private IDictionary[] ReadDictionaryArray(StreamBuffer stream, DeserializationFlags flags, ParameterDictionary parameters)
		{
			GpType keyReadType;
			GpType valueReadType;
			Type type = ReadDictionaryType(stream, out keyReadType, out valueReadType);
			uint num = ReadCompressedUInt32(stream);
			IDictionary[] array = (IDictionary[])Array.CreateInstance(type, (int)num);
			for (uint num2 = 0u; num2 < num; num2++)
			{
				array[num2] = (IDictionary)Activator.CreateInstance(type);
				ReadDictionaryElements(stream, keyReadType, valueReadType, array[num2], flags, parameters);
			}
			return array;
		}

		private Array ReadArrayInArray(StreamBuffer stream, DeserializationFlags flags, ParameterDictionary parameters)
		{
			uint num = ReadCompressedUInt32(stream);
			Array array = null;
			Type type = null;
			for (uint num2 = 0u; num2 < num; num2++)
			{
				object obj = Read(stream, flags, parameters);
				if (obj is Array array2)
				{
					if (array == null)
					{
						type = array2.GetType();
						array = Array.CreateInstance(type, (int)num);
					}
					if (type.IsAssignableFrom(array2.GetType()))
					{
						array.SetValue(array2, (int)num2);
					}
				}
			}
			return array;
		}

		internal int ReadInt1(StreamBuffer stream, bool signNegative)
		{
			if (signNegative)
			{
				return -stream.ReadByte();
			}
			return stream.ReadByte();
		}

		internal int ReadInt2(StreamBuffer stream, bool signNegative)
		{
			if (signNegative)
			{
				return -ReadUShort(stream);
			}
			return ReadUShort(stream);
		}

		internal int ReadCompressedInt32(StreamBuffer stream)
		{
			uint value = ReadCompressedUInt32(stream);
			return DecodeZigZag32(value);
		}

		private uint ReadCompressedUInt32(StreamBuffer stream)
		{
			uint num = 0u;
			int num2 = 0;
			byte[] buffer = stream.GetBuffer();
			int num3 = stream.Position;
			while (num2 != 35)
			{
				if (num3 >= stream.Length)
				{
					stream.Position = stream.Length;
					throw new EndOfStreamException("Failed to read full uint. offset: " + num3 + " stream.Length: " + stream.Length + " data.Length: " + buffer.Length + " stream.Available: " + stream.Available);
				}
				byte b = buffer[num3];
				num3++;
				num |= (uint)((b & 0x7F) << num2);
				num2 += 7;
				if ((b & 0x80) == 0)
				{
					break;
				}
			}
			stream.Position = num3;
			return num;
		}

		internal long ReadCompressedInt64(StreamBuffer stream)
		{
			ulong value = ReadCompressedUInt64(stream);
			return DecodeZigZag64(value);
		}

		private ulong ReadCompressedUInt64(StreamBuffer stream)
		{
			ulong num = 0uL;
			int num2 = 0;
			byte[] buffer = stream.GetBuffer();
			int num3 = stream.Position;
			while (num2 != 70)
			{
				if (num3 >= buffer.Length)
				{
					throw new EndOfStreamException("Failed to read full ulong.");
				}
				byte b = buffer[num3];
				num3++;
				num |= (ulong)((long)(b & 0x7F) << num2);
				num2 += 7;
				if ((b & 0x80) == 0)
				{
					break;
				}
			}
			stream.Position = num3;
			return num;
		}

		internal int[] ReadCompressedInt32Array(StreamBuffer stream)
		{
			uint num = ReadCompressedUInt32(stream);
			int[] array = new int[num];
			for (uint num2 = 0u; num2 < array.Length; num2++)
			{
				array[num2] = ReadCompressedInt32(stream);
			}
			return array;
		}

		internal long[] ReadCompressedInt64Array(StreamBuffer stream)
		{
			uint num = ReadCompressedUInt32(stream);
			long[] array = new long[num];
			for (uint num2 = 0u; num2 < array.Length; num2++)
			{
				array[num2] = ReadCompressedInt64(stream);
			}
			return array;
		}

		private int DecodeZigZag32(uint value)
		{
			return (int)((value >> 1) ^ (0L - (long)(value & 1)));
		}

		private long DecodeZigZag64(ulong value)
		{
			return (long)((value >> 1) ^ (0L - (value & 1)));
		}

		internal void Write(StreamBuffer stream, object value, bool writeType)
		{
			if (value == null)
			{
				Write(stream, value, GpType.Null, writeType);
			}
			else
			{
				Write(stream, value, GetCodeOfType(value.GetType()), writeType);
			}
		}

		private void Write(StreamBuffer stream, object value, GpType gpType, bool writeType)
		{
			switch (gpType)
			{
			case GpType.Unknown:
				if (value is ByteArraySlice)
				{
					ByteArraySlice buffer = (ByteArraySlice)value;
					WriteByteArraySlice(stream, buffer, writeType);
					break;
				}
				if (value is ArraySegment<byte> seg)
				{
					WriteArraySegmentByte(stream, seg, writeType);
					break;
				}
				if (value is StructWrapper structWrapper)
				{
					switch (structWrapper.wrappedType)
					{
					case WrappedType.Bool:
						WriteBoolean(stream, value.Get<bool>(), writeType);
						break;
					case WrappedType.Byte:
						WriteByte(stream, value.Get<byte>(), writeType);
						break;
					case WrappedType.Int16:
						WriteInt16(stream, value.Get<short>(), writeType);
						break;
					case WrappedType.Int32:
						WriteCompressedInt32(stream, value.Get<int>(), writeType);
						break;
					case WrappedType.Int64:
						WriteCompressedInt64(stream, value.Get<long>(), writeType);
						break;
					case WrappedType.Single:
						WriteSingle(stream, value.Get<float>(), writeType);
						break;
					case WrappedType.Double:
						WriteDouble(stream, value.Get<double>(), writeType);
						break;
					default:
						WriteCustomType(stream, value, writeType);
						break;
					}
					break;
				}
				goto case GpType.Custom;
			case GpType.Custom:
				WriteCustomType(stream, value, writeType);
				break;
			case GpType.CustomTypeArray:
				WriteCustomTypeArray(stream, value, writeType);
				break;
			case GpType.Array:
				WriteArrayInArray(stream, value, writeType);
				break;
			case GpType.CompressedInt:
				WriteCompressedInt32(stream, (int)value, writeType);
				break;
			case GpType.CompressedLong:
				WriteCompressedInt64(stream, (long)value, writeType);
				break;
			case GpType.Dictionary:
				WriteDictionary(stream, (IDictionary)value, writeType);
				break;
			case GpType.Byte:
				WriteByte(stream, (byte)value, writeType);
				break;
			case GpType.Double:
				WriteDouble(stream, (double)value, writeType);
				break;
			case GpType.EventData:
				SerializeEventData(stream, (EventData)value, writeType);
				break;
			case GpType.Float:
				WriteSingle(stream, (float)value, writeType);
				break;
			case GpType.Hashtable:
				WriteHashtable(stream, (Hashtable)value, writeType);
				break;
			case GpType.Short:
				WriteInt16(stream, (short)value, writeType);
				break;
			case GpType.CompressedIntArray:
				WriteInt32ArrayCompressed(stream, (int[])value, writeType);
				break;
			case GpType.CompressedLongArray:
				WriteInt64ArrayCompressed(stream, (long[])value, writeType);
				break;
			case GpType.Boolean:
				WriteBoolean(stream, (bool)value, writeType);
				break;
			case GpType.OperationResponse:
				SerializeOperationResponse(stream, (OperationResponse)value, writeType);
				break;
			case GpType.OperationRequest:
				SerializeOperationRequest(stream, (OperationRequest)value, writeType);
				break;
			case GpType.String:
				WriteString(stream, (string)value, writeType);
				break;
			case GpType.ByteArray:
				WriteByteArray(stream, (byte[])value, writeType);
				break;
			case GpType.ObjectArray:
				WriteObjectArray(stream, (IList)value, writeType);
				break;
			case GpType.DictionaryArray:
				WriteDictionaryArray(stream, (IDictionary[])value, writeType);
				break;
			case GpType.DoubleArray:
				WriteDoubleArray(stream, (double[])value, writeType);
				break;
			case GpType.FloatArray:
				WriteSingleArray(stream, (float[])value, writeType);
				break;
			case GpType.HashtableArray:
				WriteHashtableArray(stream, value, writeType);
				break;
			case GpType.ShortArray:
				WriteInt16Array(stream, (short[])value, writeType);
				break;
			case GpType.BooleanArray:
				WriteBoolArray(stream, (bool[])value, writeType);
				break;
			case GpType.StringArray:
				WriteStringArray(stream, value, writeType);
				break;
			case GpType.Null:
				if (writeType)
				{
					stream.WriteByte(8);
				}
				break;
			}
		}

		public override void SerializeEventData(StreamBuffer stream, EventData serObject, bool setType)
		{
			if (setType)
			{
				stream.WriteByte(26);
			}
			stream.WriteByte(serObject.Code);
			WriteParameterTable(stream, serObject.Parameters);
		}

		private void WriteParameterTable(StreamBuffer stream, Dictionary<byte, object> parameters)
		{
			if (parameters == null || parameters.Count == 0)
			{
				WriteByte(stream, 0, writeType: false);
				return;
			}
			WriteByte(stream, (byte)parameters.Count, writeType: false);
			foreach (KeyValuePair<byte, object> parameter in parameters)
			{
				stream.WriteByte(parameter.Key);
				Write(stream, parameter.Value, writeType: true);
			}
		}

		private void WriteParameterTable(StreamBuffer stream, ParameterDictionary parameters)
		{
			if (parameters == null || parameters.Count == 0)
			{
				WriteByte(stream, 0, writeType: false);
				return;
			}
			WriteByte(stream, (byte)parameters.Count, writeType: false);
			foreach (KeyValuePair<byte, object> parameter in parameters)
			{
				stream.WriteByte(parameter.Key);
				Write(stream, parameter.Value, writeType: true);
			}
		}

		private void SerializeOperationRequest(StreamBuffer stream, OperationRequest operation, bool setType)
		{
			SerializeOperationRequest(stream, operation.OperationCode, operation.Parameters, setType);
		}

		[Obsolete("Use ParameterDictionary instead.")]
		public override void SerializeOperationRequest(StreamBuffer stream, byte operationCode, Dictionary<byte, object> parameters, bool setType)
		{
			if (setType)
			{
				stream.WriteByte(24);
			}
			stream.WriteByte(operationCode);
			WriteParameterTable(stream, parameters);
		}

		public override void SerializeOperationRequest(StreamBuffer stream, byte operationCode, ParameterDictionary parameters, bool setType)
		{
			if (setType)
			{
				stream.WriteByte(24);
			}
			stream.WriteByte(operationCode);
			WriteParameterTable(stream, parameters);
		}

		public override void SerializeOperationResponse(StreamBuffer stream, OperationResponse serObject, bool setType)
		{
			if (setType)
			{
				stream.WriteByte(25);
			}
			stream.WriteByte(serObject.OperationCode);
			WriteInt16(stream, serObject.ReturnCode, writeType: false);
			if (string.IsNullOrEmpty(serObject.DebugMessage))
			{
				stream.WriteByte(8);
			}
			else
			{
				stream.WriteByte(7);
				WriteString(stream, serObject.DebugMessage, writeType: false);
			}
			WriteParameterTable(stream, serObject.Parameters);
		}

		internal void WriteByte(StreamBuffer stream, byte value, bool writeType)
		{
			if (writeType)
			{
				if (value == 0)
				{
					stream.WriteByte(34);
					return;
				}
				stream.WriteByte(3);
			}
			stream.WriteByte(value);
		}

		internal void WriteBoolean(StreamBuffer stream, bool value, bool writeType)
		{
			if (writeType)
			{
				if (value)
				{
					stream.WriteByte(28);
				}
				else
				{
					stream.WriteByte(27);
				}
			}
			else
			{
				stream.WriteByte((byte)(value ? 1 : 0));
			}
		}

		internal void WriteUShort(StreamBuffer stream, ushort value)
		{
			stream.WriteBytes((byte)value, (byte)(value >> 8));
		}

		internal void WriteInt16(StreamBuffer stream, short value, bool writeType)
		{
			if (writeType)
			{
				if (value == 0)
				{
					stream.WriteByte(29);
					return;
				}
				stream.WriteByte(4);
			}
			stream.WriteBytes((byte)value, (byte)(value >> 8));
		}

		internal void WriteDouble(StreamBuffer stream, double value, bool writeType)
		{
			if (writeType)
			{
				stream.WriteByte(6);
			}
			int offset;
			byte[] bufferAndAdvance = stream.GetBufferAndAdvance(8, out offset);
			lock (memDoubleBlock)
			{
				memDoubleBlock[0] = value;
				Buffer.BlockCopy(memDoubleBlock, 0, bufferAndAdvance, offset, 8);
			}
		}

		internal void WriteSingle(StreamBuffer stream, float value, bool writeType)
		{
			if (writeType)
			{
				stream.WriteByte(5);
			}
			int offset;
			byte[] bufferAndAdvance = stream.GetBufferAndAdvance(4, out offset);
			lock (memFloatBlock)
			{
				memFloatBlock[0] = value;
				Buffer.BlockCopy(memFloatBlock, 0, bufferAndAdvance, offset, 4);
			}
		}

		internal void WriteString(StreamBuffer stream, string value, bool writeType)
		{
			if (writeType)
			{
				stream.WriteByte(7);
			}
			int byteCount = Encoding.UTF8.GetByteCount(value);
			if (byteCount > 32767)
			{
				throw new NotSupportedException("Strings that exceed a UTF8-encoded byte-length of 32767 (short.MaxValue) are not supported. Yours is: " + byteCount);
			}
			WriteIntLength(stream, byteCount);
			int offset = 0;
			byte[] bufferAndAdvance = stream.GetBufferAndAdvance(byteCount, out offset);
			Encoding.UTF8.GetBytes(value, 0, value.Length, bufferAndAdvance, offset);
		}

		private void WriteHashtable(StreamBuffer stream, object value, bool writeType)
		{
			Hashtable hashtable = (Hashtable)value;
			if (writeType)
			{
				stream.WriteByte(21);
			}
			WriteIntLength(stream, hashtable.Count);
			Dictionary<object, object>.KeyCollection keys = hashtable.Keys;
			foreach (object item in keys)
			{
				Write(stream, item, writeType: true);
				Write(stream, hashtable[item], writeType: true);
			}
		}

		internal void WriteByteArray(StreamBuffer stream, byte[] value, bool writeType)
		{
			if (writeType)
			{
				stream.WriteByte(67);
			}
			WriteIntLength(stream, value.Length);
			stream.Write(value, 0, value.Length);
		}

		private void WriteArraySegmentByte(StreamBuffer stream, ArraySegment<byte> seg, bool writeType)
		{
			if (writeType)
			{
				stream.WriteByte(67);
			}
			int count = seg.Count;
			WriteIntLength(stream, count);
			if (count > 0)
			{
				stream.Write(seg.Array, seg.Offset, count);
			}
		}

		private void WriteByteArraySlice(StreamBuffer stream, ByteArraySlice buffer, bool writeType)
		{
			if (writeType)
			{
				stream.WriteByte(67);
			}
			int count = buffer.Count;
			WriteIntLength(stream, count);
			stream.Write(buffer.Buffer, buffer.Offset, count);
			buffer.Release();
		}

		internal void WriteInt32ArrayCompressed(StreamBuffer stream, int[] value, bool writeType)
		{
			if (writeType)
			{
				stream.WriteByte(73);
			}
			WriteIntLength(stream, value.Length);
			for (int i = 0; i < value.Length; i++)
			{
				WriteCompressedInt32(stream, value[i], writeType: false);
			}
		}

		private void WriteInt64ArrayCompressed(StreamBuffer stream, long[] values, bool setType)
		{
			if (setType)
			{
				stream.WriteByte(74);
			}
			WriteIntLength(stream, values.Length);
			for (int i = 0; i < values.Length; i++)
			{
				WriteCompressedInt64(stream, values[i], writeType: false);
			}
		}

		internal void WriteBoolArray(StreamBuffer stream, bool[] value, bool writeType)
		{
			if (writeType)
			{
				stream.WriteByte(66);
			}
			WriteIntLength(stream, value.Length);
			int num = value.Length >> 3;
			uint num2 = (uint)(num + 1);
			byte[] array = new byte[num2];
			int num3 = 0;
			int i = 0;
			while (num > 0)
			{
				byte b = 0;
				if (value[i++])
				{
					b |= 1;
				}
				if (value[i++])
				{
					b |= 2;
				}
				if (value[i++])
				{
					b |= 4;
				}
				if (value[i++])
				{
					b |= 8;
				}
				if (value[i++])
				{
					b |= 0x10;
				}
				if (value[i++])
				{
					b |= 0x20;
				}
				if (value[i++])
				{
					b |= 0x40;
				}
				if (value[i++])
				{
					b |= 0x80;
				}
				array[num3] = b;
				num--;
				num3++;
			}
			if (i < value.Length)
			{
				byte b2 = 0;
				int num4 = 0;
				for (; i < value.Length; i++)
				{
					if (value[i])
					{
						b2 |= (byte)(1 << num4);
					}
					num4++;
				}
				array[num3] = b2;
				num3++;
			}
			stream.Write(array, 0, num3);
		}

		internal void WriteInt16Array(StreamBuffer stream, short[] value, bool writeType)
		{
			if (writeType)
			{
				stream.WriteByte(68);
			}
			WriteIntLength(stream, value.Length);
			for (int i = 0; i < value.Length; i++)
			{
				WriteInt16(stream, value[i], writeType: false);
			}
		}

		internal void WriteSingleArray(StreamBuffer stream, float[] values, bool setType)
		{
			if (setType)
			{
				stream.WriteByte(69);
			}
			WriteIntLength(stream, values.Length);
			int num = values.Length * 4;
			int offset;
			byte[] bufferAndAdvance = stream.GetBufferAndAdvance(num, out offset);
			Buffer.BlockCopy(values, 0, bufferAndAdvance, offset, num);
		}

		internal void WriteDoubleArray(StreamBuffer stream, double[] values, bool setType)
		{
			if (setType)
			{
				stream.WriteByte(70);
			}
			WriteIntLength(stream, values.Length);
			int num = values.Length * 8;
			int offset;
			byte[] bufferAndAdvance = stream.GetBufferAndAdvance(num, out offset);
			Buffer.BlockCopy(values, 0, bufferAndAdvance, offset, num);
		}

		internal void WriteStringArray(StreamBuffer stream, object value0, bool writeType)
		{
			string[] array = (string[])value0;
			if (writeType)
			{
				stream.WriteByte(71);
			}
			WriteIntLength(stream, array.Length);
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == null)
				{
					throw new InvalidDataException("Unexpected - cannot serialize string array with null element " + i);
				}
				WriteString(stream, array[i], writeType: false);
			}
		}

		private void WriteObjectArray(StreamBuffer stream, object array, bool writeType)
		{
			WriteObjectArray(stream, (IList)array, writeType);
		}

		private void WriteObjectArray(StreamBuffer stream, IList array, bool writeType)
		{
			if (writeType)
			{
				stream.WriteByte(23);
			}
			WriteIntLength(stream, array.Count);
			for (int i = 0; i < array.Count; i++)
			{
				object value = array[i];
				Write(stream, value, writeType: true);
			}
		}

		private void WriteArrayInArray(StreamBuffer stream, object value, bool writeType)
		{
			object[] array = (object[])value;
			stream.WriteByte(64);
			WriteIntLength(stream, array.Length);
			object[] array2 = array;
			foreach (object value2 in array2)
			{
				Write(stream, value2, writeType: true);
			}
		}

		private void WriteCustomTypeBody(CustomType customType, StreamBuffer stream, object value)
		{
			if (customType.SerializeStreamFunction == null)
			{
				byte[] array = customType.SerializeFunction(value);
				WriteIntLength(stream, array.Length);
				stream.Write(array, 0, array.Length);
				return;
			}
			int position = stream.Position;
			stream.Position++;
			uint num = (uint)customType.SerializeStreamFunction(stream, value);
			int num2 = stream.Position - position - 1;
			if (num2 != num)
			{
				System.Diagnostics.Debug.WriteLine("Serialization for Custom Type '" + value.GetType()?.ToString() + "' returns size " + num + " bytes but wrote " + num2 + " bytes. Sending the latter as size.");
			}
			int num3 = WriteCompressedUInt32(memCustomTypeBodyLengthSerialized, (uint)num2);
			if (num3 == 1)
			{
				stream.GetBuffer()[position] = memCustomTypeBodyLengthSerialized[0];
				return;
			}
			for (int i = 0; i < num3 - 1; i++)
			{
				stream.WriteByte(0);
			}
			Buffer.BlockCopy(stream.GetBuffer(), position + 1, stream.GetBuffer(), position + num3, num2);
			Buffer.BlockCopy(memCustomTypeBodyLengthSerialized, 0, stream.GetBuffer(), position, num3);
			stream.Position = position + num3 + num2;
		}

		private void WriteCustomType(StreamBuffer stream, object value, bool writeType)
		{
			Type type = ((!(value is StructWrapper structWrapper)) ? value.GetType() : structWrapper.ttype);
			if (Protocol.TypeDict.TryGetValue(type, out var value2))
			{
				if (writeType)
				{
					if (value2.Code < 100)
					{
						stream.WriteByte((byte)(128 + value2.Code));
					}
					else
					{
						stream.WriteByte(19);
						stream.WriteByte(value2.Code);
					}
				}
				else
				{
					stream.WriteByte(value2.Code);
				}
				WriteCustomTypeBody(value2, stream, value);
				return;
			}
			throw new Exception("Write failed. Custom type not found: " + type);
		}

		private void WriteCustomTypeArray(StreamBuffer stream, object value, bool writeType)
		{
			IList list = (IList)value;
			Type elementType = value.GetType().GetElementType();
			if (Protocol.TypeDict.TryGetValue(elementType, out var value2))
			{
				if (writeType)
				{
					stream.WriteByte(83);
				}
				WriteIntLength(stream, list.Count);
				stream.WriteByte(value2.Code);
				{
					foreach (object item in list)
					{
						WriteCustomTypeBody(value2, stream, item);
					}
					return;
				}
			}
			throw new Exception("Write failed. Custom type of element not found: " + elementType);
		}

		private bool WriteArrayHeader(StreamBuffer stream, Type type)
		{
			Type elementType = type.GetElementType();
			while (elementType.IsArray)
			{
				stream.WriteByte(64);
				elementType = elementType.GetElementType();
			}
			GpType codeOfType = GetCodeOfType(elementType);
			if (codeOfType == GpType.Unknown)
			{
				return false;
			}
			stream.WriteByte((byte)(codeOfType | GpType.CustomTypeSlim));
			return true;
		}

		private void WriteDictionaryElements(StreamBuffer stream, IDictionary dictionary, GpType keyWriteType, GpType valueWriteType)
		{
			WriteIntLength(stream, dictionary.Count);
			foreach (DictionaryEntry item in dictionary)
			{
				Write(stream, item.Key, keyWriteType == GpType.Unknown);
				Write(stream, item.Value, valueWriteType == GpType.Unknown);
			}
		}

		private void WriteDictionary(StreamBuffer stream, object dict, bool setType)
		{
			if (setType)
			{
				stream.WriteByte(20);
			}
			WriteDictionaryHeader(stream, dict.GetType(), out var keyWriteType, out var valueWriteType);
			IDictionary dictionary = (IDictionary)dict;
			WriteDictionaryElements(stream, dictionary, keyWriteType, valueWriteType);
		}

		private void WriteDictionaryHeader(StreamBuffer stream, Type type, out GpType keyWriteType, out GpType valueWriteType)
		{
			Type[] genericArguments = type.GetGenericArguments();
			if (genericArguments[0] == typeof(object))
			{
				stream.WriteByte(0);
				keyWriteType = GpType.Unknown;
			}
			else
			{
				if (!genericArguments[0].IsPrimitive && genericArguments[0] != typeof(string))
				{
					throw new InvalidDataException("Unexpected - cannot serialize Dictionary with key type: " + genericArguments[0]);
				}
				keyWriteType = GetCodeOfType(genericArguments[0]);
				if (keyWriteType == GpType.Unknown)
				{
					throw new InvalidDataException("Unexpected - cannot serialize Dictionary with key type: " + genericArguments[0]);
				}
				stream.WriteByte((byte)keyWriteType);
			}
			if (genericArguments[1] == typeof(object))
			{
				stream.WriteByte(0);
				valueWriteType = GpType.Unknown;
				return;
			}
			if (genericArguments[1].IsArray)
			{
				if (WriteArrayType(stream, genericArguments[1], out valueWriteType))
				{
					return;
				}
				throw new InvalidDataException("Unexpected - cannot serialize Dictionary with value type: " + genericArguments[1]);
			}
			valueWriteType = GetCodeOfType(genericArguments[1]);
			if (valueWriteType == GpType.Unknown)
			{
				throw new InvalidDataException("Unexpected - cannot serialize Dictionary with value type: " + genericArguments[1]);
			}
			if (valueWriteType == GpType.Array)
			{
				if (!WriteArrayHeader(stream, genericArguments[1]))
				{
					throw new InvalidDataException("Unexpected - cannot serialize Dictionary with value type: " + genericArguments[1]);
				}
			}
			else if (valueWriteType == GpType.Dictionary)
			{
				stream.WriteByte((byte)valueWriteType);
				WriteDictionaryHeader(stream, genericArguments[1], out var _, out var _);
			}
			else
			{
				stream.WriteByte((byte)valueWriteType);
			}
		}

		private bool WriteArrayType(StreamBuffer stream, Type type, out GpType writeType)
		{
			Type elementType = type.GetElementType();
			if (elementType == null)
			{
				throw new InvalidDataException("Unexpected - cannot serialize array with type: " + type);
			}
			if (elementType.IsArray)
			{
				while (elementType != null && elementType.IsArray)
				{
					stream.WriteByte(64);
					elementType = elementType.GetElementType();
				}
				byte value = (byte)(GetCodeOfType(elementType) | GpType.Array);
				stream.WriteByte(value);
				writeType = GpType.Array;
				return true;
			}
			if (elementType.IsPrimitive)
			{
				byte b = (byte)(GetCodeOfType(elementType) | GpType.Array);
				if (b == 226)
				{
					b = 67;
				}
				stream.WriteByte(b);
				if (Enum.IsDefined(typeof(GpType), b))
				{
					writeType = (GpType)b;
					return true;
				}
				writeType = GpType.Unknown;
				return false;
			}
			if (elementType == typeof(string))
			{
				stream.WriteByte(71);
				writeType = GpType.StringArray;
				return true;
			}
			if (elementType == typeof(object))
			{
				stream.WriteByte(23);
				writeType = GpType.ObjectArray;
				return true;
			}
			if (elementType == typeof(Hashtable))
			{
				stream.WriteByte(85);
				writeType = GpType.HashtableArray;
				return true;
			}
			writeType = GpType.Unknown;
			return false;
		}

		private void WriteHashtableArray(StreamBuffer stream, object value, bool writeType)
		{
			Hashtable[] array = (Hashtable[])value;
			if (writeType)
			{
				stream.WriteByte(85);
			}
			WriteIntLength(stream, array.Length);
			Hashtable[] array2 = array;
			foreach (Hashtable value2 in array2)
			{
				WriteHashtable(stream, value2, writeType: false);
			}
		}

		private void WriteDictionaryArray(StreamBuffer stream, IDictionary[] dictArray, bool writeType)
		{
			stream.WriteByte(84);
			WriteDictionaryHeader(stream, dictArray.GetType().GetElementType(), out var keyWriteType, out var valueWriteType);
			WriteIntLength(stream, dictArray.Length);
			foreach (IDictionary dictionary in dictArray)
			{
				WriteDictionaryElements(stream, dictionary, keyWriteType, valueWriteType);
			}
		}

		private void WriteIntLength(StreamBuffer stream, int value)
		{
			WriteCompressedUInt32(stream, (uint)value);
		}

		private void WriteVarInt32(StreamBuffer stream, int value, bool writeType)
		{
			WriteCompressedInt32(stream, value, writeType);
		}

		private void WriteCompressedInt32(StreamBuffer stream, int value, bool writeType)
		{
			if (writeType)
			{
				if (value == 0)
				{
					stream.WriteByte(30);
					return;
				}
				if (value > 0)
				{
					if (value <= 255)
					{
						stream.WriteByte(11);
						stream.WriteByte((byte)value);
						return;
					}
					if (value <= 65535)
					{
						stream.WriteByte(13);
						WriteUShort(stream, (ushort)value);
						return;
					}
				}
				else if (value >= -65535)
				{
					if (value >= -255)
					{
						stream.WriteByte(12);
						stream.WriteByte((byte)(-value));
						return;
					}
					if (value >= -65535)
					{
						stream.WriteByte(14);
						WriteUShort(stream, (ushort)(-value));
						return;
					}
				}
			}
			if (writeType)
			{
				stream.WriteByte(9);
			}
			uint value2 = EncodeZigZag32(value);
			WriteCompressedUInt32(stream, value2);
		}

		private void WriteCompressedInt64(StreamBuffer stream, long value, bool writeType)
		{
			if (writeType)
			{
				if (value == 0)
				{
					stream.WriteByte(31);
					return;
				}
				if (value > 0)
				{
					if (value <= 255)
					{
						stream.WriteByte(15);
						stream.WriteByte((byte)value);
						return;
					}
					if (value <= 65535)
					{
						stream.WriteByte(17);
						WriteUShort(stream, (ushort)value);
						return;
					}
				}
				else if (value >= -65535)
				{
					if (value >= -255)
					{
						stream.WriteByte(16);
						stream.WriteByte((byte)(-value));
						return;
					}
					if (value >= -65535)
					{
						stream.WriteByte(18);
						WriteUShort(stream, (ushort)(-value));
						return;
					}
				}
			}
			if (writeType)
			{
				stream.WriteByte(10);
			}
			ulong value2 = EncodeZigZag64(value);
			WriteCompressedUInt64(stream, value2);
		}

		private void WriteCompressedUInt32(StreamBuffer stream, uint value)
		{
			lock (memCompressedUInt32)
			{
				stream.Write(memCompressedUInt32, 0, WriteCompressedUInt32(memCompressedUInt32, value));
			}
		}

		private int WriteCompressedUInt32(byte[] buffer, uint value)
		{
			int num = 0;
			buffer[num] = (byte)(value & 0x7F);
			for (value >>= 7; value != 0; value >>= 7)
			{
				buffer[num] |= 128;
				buffer[++num] = (byte)(value & 0x7F);
			}
			return num + 1;
		}

		private void WriteCompressedUInt64(StreamBuffer stream, ulong value)
		{
			int num = 0;
			lock (memCompressedUInt64)
			{
				memCompressedUInt64[num] = (byte)(value & 0x7F);
				for (value >>= 7; value != 0; value >>= 7)
				{
					memCompressedUInt64[num] |= 128;
					memCompressedUInt64[++num] = (byte)(value & 0x7F);
				}
				num++;
				stream.Write(memCompressedUInt64, 0, num);
			}
		}

		private uint EncodeZigZag32(int value)
		{
			return (uint)((value << 1) ^ (value >> 31));
		}

		private ulong EncodeZigZag64(long value)
		{
			return (ulong)((value << 1) ^ (value >> 63));
		}
	}
	public enum DeliveryMode
	{
		Unreliable,
		Reliable,
		UnreliableUnsequenced,
		ReliableUnsequenced
	}
	public struct SendOptions
	{
		public static readonly SendOptions SendReliable = new SendOptions
		{
			Reliability = true
		};

		public static readonly SendOptions SendUnreliable = new SendOptions
		{
			Reliability = false
		};

		public DeliveryMode DeliveryMode;

		public bool Encrypt;

		public byte Channel;

		public bool Reliability
		{
			get
			{
				return DeliveryMode == DeliveryMode.Reliable;
			}
			set
			{
				DeliveryMode = (value ? DeliveryMode.Reliable : DeliveryMode.Unreliable);
			}
		}
	}
	public class SocketTcp : IPhotonSocket, IDisposable
	{
		private Socket sock;

		private readonly object syncer = new object();

		[Preserve]
		public SocketTcp(PeerBase npeer)
			: base(npeer)
		{
			if (ReportDebugOfLevel(DebugLevel.INFO))
			{
				base.Listener.DebugReturn(DebugLevel.INFO, "SocketTcp, .Net, Unity.");
			}
			PollReceive = false;
		}

		~SocketTcp()
		{
			Dispose();
		}

		public void Dispose()
		{
			base.State = PhotonSocketState.Disconnecting;
			if (sock != null)
			{
				try
				{
					if (sock.Connected)
					{
						sock.Close();
					}
				}
				catch (Exception ex)
				{
					EnqueueDebugReturn(DebugLevel.INFO, "Exception in Dispose(): " + ex);
				}
			}
			sock = null;
			base.State = PhotonSocketState.Disconnected;
		}

		public override bool Connect()
		{
			lock (syncer)
			{
				if (!base.Connect())
				{
					return false;
				}
				base.State = PhotonSocketState.Connecting;
			}
			Thread thread = new Thread(DnsAndConnect);
			thread.IsBackground = true;
			thread.Start();
			return true;
		}

		public override bool Disconnect()
		{
			if (ReportDebugOfLevel(DebugLevel.INFO))
			{
				EnqueueDebugReturn(DebugLevel.INFO, "SocketTcp.Disconnect()");
			}
			lock (syncer)
			{
				base.State = PhotonSocketState.Disconnecting;
				if (sock != null)
				{
					try
					{
						sock.Close();
					}
					catch (Exception ex)
					{
						if (ReportDebugOfLevel(DebugLevel.INFO))
						{
							EnqueueDebugReturn(DebugLevel.INFO, "Exception in Disconnect(): " + ex);
						}
					}
				}
				base.State = PhotonSocketState.Disconnected;
			}
			return true;
		}

		public override PhotonSocketError Send(byte[] data, int length)
		{
			try
			{
				if (sock == null || !sock.Connected)
				{
					return PhotonSocketError.Skipped;
				}
				sock.Send(data, 0, length, SocketFlags.None);
			}
			catch (Exception ex)
			{
				if (base.State != PhotonSocketState.Disconnecting && base.State != PhotonSocketState.Disconnected)
				{
					if (ReportDebugOfLevel(DebugLevel.INFO))
					{
						string text = "";
						if (sock != null)
						{
							text = string.Format(" Local: {0} Remote: {1} ({2}, {3})", sock.LocalEndPoint, sock.RemoteEndPoint, sock.Connected ? "connected" : "not connected", sock.IsBound ? "bound" : "not bound");
						}
						EnqueueDebugReturn(DebugLevel.INFO, string.Format("Cannot send to: {0} ({4}). Uptime: {1} ms. {2} {3}", base.ServerAddress, peerBase.timeInt, base.AddressResolvedAsIpv6 ? " IPv6" : string.Empty, text, ex));
					}
					HandleException(StatusCode.SendError);
				}
				return PhotonSocketError.Exception;
			}
			return PhotonSocketError.Success;
		}

		public override PhotonSocketError Receive(out byte[] data)
		{
			data = null;
			return PhotonSocketError.NoData;
		}

		internal void DnsAndConnect()
		{
			IPAddress[] ipAddresses = GetIpAddresses(base.ServerAddress);
			if (ipAddresses == null)
			{
				return;
			}
			string text = string.Empty;
			IPAddress[] array = ipAddresses;
			foreach (IPAddress iPAddress in array)
			{
				try
				{
					sock = new Socket(iPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
					sock.NoDelay = true;
					sock.ReceiveTimeout = peerBase.DisconnectTimeout;
					sock.SendTimeout = peerBase.DisconnectTimeout;
					sock.Connect(iPAddress, base.ServerPort);
					if (sock != null && sock.Connected)
					{
						break;
					}
				}
				catch (SecurityException ex)
				{
					if (ReportDebugOfLevel(DebugLevel.ERROR))
					{
						text = text + ex?.ToString() + " ";
						EnqueueDebugReturn(DebugLevel.WARNING, "SecurityException catched: " + ex);
					}
				}
				catch (SocketException ex2)
				{
					if (ReportDebugOfLevel(DebugLevel.WARNING))
					{
						text = text + ex2?.ToString() + " " + ex2.ErrorCode + "; ";
						EnqueueDebugReturn(DebugLevel.WARNING, "SocketException catched: " + ex2?.ToString() + " ErrorCode: " + ex2.ErrorCode);
					}
				}
				catch (Exception ex3)
				{
					if (ReportDebugOfLevel(DebugLevel.WARNING))
					{
						text = text + ex3?.ToString() + "; ";
						EnqueueDebugReturn(DebugLevel.WARNING, "Exception catched: " + ex3);
					}
				}
			}
			if (sock == null || !sock.Connected)
			{
				if (ReportDebugOfLevel(DebugLevel.ERROR))
				{
					EnqueueDebugReturn(DebugLevel.ERROR, "Failed to connect to server after testing each known IP. Error(s): " + text);
				}
				HandleException(StatusCode.ExceptionOnConnect);
			}
			else
			{
				base.AddressResolvedAsIpv6 = sock.AddressFamily == AddressFamily.InterNetworkV6;
				IPhotonSocket.ServerIpAddress = sock.RemoteEndPoint.ToString();
				base.State = PhotonSocketState.Connected;
				peerBase.OnConnect();
				Thread thread = new Thread(ReceiveLoop);
				thread.IsBackground = true;
				thread.Start();
			}
		}

		public void ReceiveLoop()
		{
			StreamBuffer streamBuffer = new StreamBuffer(base.MTU);
			byte[] array = new byte[9];
			while (base.State == PhotonSocketState.Connected)
			{
				streamBuffer.SetLength(0L);
				try
				{
					int num = 0;
					int num2 = 0;
					while (num < 9)
					{
						try
						{
							num2 = sock.Receive(array, num, 9 - num, SocketFlags.None);
						}
						catch (SocketException ex)
						{
							if (base.State != PhotonSocketState.Disconnecting && base.State > PhotonSocketState.Disconnected && ex.SocketErrorCode == SocketError.WouldBlock)
							{
								if (ReportDebugOfLevel(DebugLevel.ALL))
								{
									EnqueueDebugReturn(DebugLevel.ALL, "ReceiveLoop() got a WouldBlock exception. This is non-fatal. Going to continue.");
								}
								continue;
							}
							throw;
						}
						num += num2;
						if (num2 == 0)
						{
							throw new SocketException(10054);
						}
					}
					if (array[0] == 240)
					{
						HandleReceivedDatagram(array, array.Length, willBeReused: true);
						continue;
					}
					int num3 = (array[1] << 24) | (array[2] << 16) | (array[3] << 8) | array[4];
					if (peerBase.TrafficStatsEnabled && array[0] == 251)
					{
						if (array[6] == 0)
						{
							peerBase.TrafficStatsIncoming.CountReliableOpCommand(num3);
						}
						else
						{
							peerBase.TrafficStatsIncoming.CountUnreliableOpCommand(num3);
						}
					}
					if (ReportDebugOfLevel(DebugLevel.ALL))
					{
						EnqueueDebugReturn(DebugLevel.ALL, "TCP < " + num3);
					}
					streamBuffer.SetCapacityMinimum(num3 - 7);
					streamBuffer.Write(array, 7, num - 7);
					num = 0;
					num3 -= 9;
					while (num < num3)
					{
						try
						{
							num2 = sock.Receive(streamBuffer.GetBuffer(), streamBuffer.Position, num3 - num, SocketFlags.None);
						}
						catch (SocketException ex2)
						{
							if (base.State != PhotonSocketState.Disconnecting && base.State > PhotonSocketState.Disconnected && ex2.SocketErrorCode == SocketError.WouldBlock)
							{
								if (ReportDebugOfLevel(DebugLevel.ALL))
								{
									EnqueueDebugReturn(DebugLevel.ALL, "ReceiveLoop() got a WouldBlock exception. This is non-fatal. Going to continue.");
								}
								continue;
							}
							throw;
						}
						streamBuffer.Position += num2;
						num += num2;
						if (num2 == 0)
						{
							throw new SocketException(10054);
						}
					}
					HandleReceivedDatagram(streamBuffer.ToArray(), streamBuffer.Length, willBeReused: false);
					if (ReportDebugOfLevel(DebugLevel.ALL))
					{
						EnqueueDebugReturn(DebugLevel.ALL, "TCP < " + streamBuffer.Length + ((streamBuffer.Length == num3 + 2) ? " OK" : " BAD"));
					}
				}
				catch (SocketException ex3)
				{
					if (base.State != PhotonSocketState.Disconnecting && base.State != PhotonSocketState.Disconnected)
					{
						if (ReportDebugOfLevel(DebugLevel.ERROR))
						{
							EnqueueDebugReturn(DebugLevel.ERROR, "Receiving failed. SocketException: " + ex3.SocketErrorCode);
						}
						if (ex3.SocketErrorCode == SocketError.ConnectionReset || ex3.SocketErrorCode == SocketError.ConnectionAborted)
						{
							HandleException(StatusCode.DisconnectByServerTimeout);
						}
						else
						{
							HandleException(StatusCode.ExceptionOnReceive);
						}
					}
				}
				catch (Exception ex4)
				{
					if (base.State != PhotonSocketState.Disconnecting && base.State != PhotonSocketState.Disconnected)
					{
						if (ReportDebugOfLevel(DebugLevel.ERROR))
						{
							EnqueueDebugReturn(DebugLevel.ERROR, "Receive issue. State: " + base.State.ToString() + ". Server: '" + base.ServerAddress + "' Exception: " + ex4);
						}
						HandleException(StatusCode.ExceptionOnReceive);
					}
				}
			}
			lock (syncer)
			{
				if (base.State != PhotonSocketState.Disconnecting && base.State != PhotonSocketState.Disconnected)
				{
					Disconnect();
				}
			}
		}
	}
	public class SocketTcpAsync : IPhotonSocket, IDisposable
	{
		private class ReceiveContext
		{
			public Socket workSocket;

			public int ReceivedHeaderBytes;

			public byte[] HeaderBuffer;

			public int ExpectedMessageBytes;

			public int ReceivedMessageBytes;

			public byte[] MessageBuffer;

			public bool ReadingHeader => ExpectedMessageBytes == 0;

			public bool ReadingMessage => ExpectedMessageBytes != 0;

			public byte[] CurrentBuffer => ReadingHeader ? HeaderBuffer : MessageBuffer;

			public int CurrentOffset => ReadingHeader ? ReceivedHeaderBytes : ReceivedMessageBytes;

			public int CurrentExpected => ReadingHeader ? 9 : ExpectedMessageBytes;

			public ReceiveContext(Socket socket, byte[] headerBuffer, byte[] messageBuffer)
			{
				HeaderBuffer = headerBuffer;
				MessageBuffer = messageBuffer;
				workSocket = socket;
			}

			public void Reset()
			{
				ReceivedHeaderBytes = 0;
				ExpectedMessageBytes = 0;
				ReceivedMessageBytes = 0;
			}
		}

		private Socket sock;

		private readonly object syncer = new object();

		[Preserve]
		public SocketTcpAsync(PeerBase npeer)
			: base(npeer)
		{
			if (ReportDebugOfLevel(DebugLevel.INFO))
			{
				base.Listener.DebugReturn(DebugLevel.INFO, "SocketTcpAsync, .Net, Unity.");
			}
			PollReceive = false;
		}

		~SocketTcpAsync()
		{
			Dispose();
		}

		public void Dispose()
		{
			base.State = PhotonSocketState.Disconnecting;
			if (sock != null)
			{
				try
				{
					if (sock.Connected)
					{
						sock.Close();
					}
				}
				catch (Exception ex)
				{
					EnqueueDebugReturn(DebugLevel.INFO, "Exception in Dispose(): " + ex);
				}
			}
			sock = null;
			base.State = PhotonSocketState.Disconnected;
		}

		public override bool Connect()
		{
			lock (syncer)
			{
				if (!base.Connect())
				{
					return false;
				}
				base.State = PhotonSocketState.Connecting;
			}
			Thread thread = new Thread(DnsAndConnect);
			thread.IsBackground = true;
			thread.Start();
			return true;
		}

		public override bool Disconnect()
		{
			if (ReportDebugOfLevel(DebugLevel.INFO))
			{
				EnqueueDebugReturn(DebugLevel.INFO, "SocketTcpAsync.Disconnect()");
			}
			lock (syncer)
			{
				base.State = PhotonSocketState.Disconnecting;
				if (sock != null)
				{
					try
					{
						sock.Close();
					}
					catch (Exception ex)
					{
						if (ReportDebugOfLevel(DebugLevel.INFO))
						{
							EnqueueDebugReturn(DebugLevel.INFO, "Exception in Disconnect(): " + ex);
						}
					}
				}
				base.State = PhotonSocketState.Disconnected;
			}
			return true;
		}

		public override PhotonSocketError Send(byte[] data, int length)
		{
			try
			{
				if (sock == null || !sock.Connected)
				{
					return PhotonSocketError.Skipped;
				}
				sock.Send(data, 0, length, SocketFlags.None);
			}
			catch (Exception ex)
			{
				if (base.State != PhotonSocketState.Disconnecting && base.State != PhotonSocketState.Disconnected)
				{
					if (ReportDebugOfLevel(DebugLevel.INFO))
					{
						string text = "";
						if (sock != null)
						{
							text = string.Format(" Local: {0} Remote: {1} ({2}, {3})", sock.LocalEndPoint, sock.RemoteEndPoint, sock.Connected ? "connected" : "not connected", sock.IsBound ? "bound" : "not bound");
						}
						EnqueueDebugReturn(DebugLevel.INFO, string.Format("Cannot send to: {0} ({4}). Uptime: {1} ms. {2} {3}", base.ServerAddress, peerBase.timeInt, base.AddressResolvedAsIpv6 ? " IPv6" : string.Empty, text, ex));
					}
					HandleException(StatusCode.SendError);
				}
				return PhotonSocketError.Exception;
			}
			return PhotonSocketError.Success;
		}

		public override PhotonSocketError Receive(out byte[] data)
		{
			data = null;
			return PhotonSocketError.NoData;
		}

		internal void DnsAndConnect()
		{
			IPAddress[] ipAddresses = GetIpAddresses(base.ServerAddress);
			if (ipAddresses == null)
			{
				return;
			}
			string text = string.Empty;
			IPAddress[] array = ipAddresses;
			foreach (IPAddress iPAddress in array)
			{
				try
				{
					sock = new Socket(iPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
					sock.NoDelay = true;
					sock.ReceiveTimeout = peerBase.DisconnectTimeout;
					sock.SendTimeout = peerBase.DisconnectTimeout;
					sock.Connect(iPAddress, base.ServerPort);
					if (sock != null && sock.Connected)
					{
						break;
					}
				}
				catch (SecurityException ex)
				{
					if (ReportDebugOfLevel(DebugLevel.ERROR))
					{
						text = text + ex?.ToString() + " ";
						EnqueueDebugReturn(DebugLevel.WARNING, "SecurityException catched: " + ex);
					}
				}
				catch (SocketException ex2)
				{
					if (ReportDebugOfLevel(DebugLevel.WARNING))
					{
						text = text + ex2?.ToString() + " " + ex2.ErrorCode + "; ";
						EnqueueDebugReturn(DebugLevel.WARNING, "SocketException catched: " + ex2?.ToString() + " ErrorCode: " + ex2.ErrorCode);
					}
				}
				catch (Exception ex3)
				{
					if (ReportDebugOfLevel(DebugLevel.WARNING))
					{
						text = text + ex3?.ToString() + "; ";
						EnqueueDebugReturn(DebugLevel.WARNING, "Exception catched: " + ex3);
					}
				}
			}
			if (sock == null || !sock.Connected)
			{
				if (ReportDebugOfLevel(DebugLevel.ERROR))
				{
					EnqueueDebugReturn(DebugLevel.ERROR, "Failed to connect to server after testing each known IP. Error(s): " + text);
				}
				HandleException(StatusCode.ExceptionOnConnect);
			}
			else
			{
				base.AddressResolvedAsIpv6 = sock.AddressFamily == AddressFamily.InterNetworkV6;
				IPhotonSocket.ServerIpAddress = sock.RemoteEndPoint.ToString();
				base.State = PhotonSocketState.Connected;
				peerBase.OnConnect();
				ReceiveAsync();
			}
		}

		private void ReceiveAsync(ReceiveContext context = null)
		{
			if (context == null)
			{
				context = new ReceiveContext(sock, new byte[9], new byte[base.MTU]);
			}
			try
			{
				sock.BeginReceive(context.CurrentBuffer, context.CurrentOffset, context.CurrentExpected - context.CurrentOffset, SocketFlags.None, ReceiveAsync, context);
			}
			catch (Exception ex)
			{
				if (base.State != PhotonSocketState.Disconnecting && base.State != PhotonSocketState.Disconnected)
				{
					if (ReportDebugOfLevel(DebugLevel.ERROR))
					{
						EnqueueDebugReturn(DebugLevel.ERROR, "SocketTcpAsync.ReceiveAsync Exception. State: " + base.State.ToString() + ". Server: '" + base.ServerAddress + "' Exception: " + ex);
					}
					HandleException(StatusCode.ExceptionOnReceive);
				}
			}
		}

		private void ReceiveAsync(IAsyncResult ar)
		{
			if (base.State == PhotonSocketState.Disconnecting || base.State == PhotonSocketState.Disconnected)
			{
				return;
			}
			int num = 0;
			try
			{
				num = sock.EndReceive(ar);
				if (num == 0)
				{
					throw new SocketException(10054);
				}
			}
			catch (SocketException ex)
			{
				if (base.State != PhotonSocketState.Disconnecting && base.State != PhotonSocketState.Disconnected)
				{
					if (ReportDebugOfLevel(DebugLevel.ERROR))
					{
						EnqueueDebugReturn(DebugLevel.ERROR, "SocketTcpAsync.EndReceive SocketException. State: " + base.State.ToString() + ". Server: '" + base.ServerAddress + "' ErrorCode: " + ex.ErrorCode + " SocketErrorCode: " + ex.SocketErrorCode.ToString() + " Message: " + ex.Message + " " + ex);
					}
					HandleException(StatusCode.ExceptionOnReceive);
					return;
				}
			}
			catch (Exception ex2)
			{
				if (base.State != PhotonSocketState.Disconnecting && base.State != PhotonSocketState.Disconnected)
				{
					if (ReportDebugOfLevel(DebugLevel.ERROR))
					{
						EnqueueDebugReturn(DebugLevel.ERROR, "SocketTcpAsync.EndReceive Exception. State: " + base.State.ToString() + ". Server: '" + base.ServerAddress + "' Exception: " + ex2);
					}
					HandleException(StatusCode.ExceptionOnReceive);
					return;
				}
			}
			ReceiveContext receiveContext = (ReceiveContext)ar.AsyncState;
			if (num + receiveContext.CurrentOffset != receiveContext.CurrentExpected)
			{
				if (receiveContext.ReadingHeader)
				{
					receiveContext.ReceivedHeaderBytes += num;
				}
				else
				{
					receiveContext.ReceivedMessageBytes += num;
				}
				ReceiveAsync(receiveContext);
			}
			else if (receiveContext.ReadingHeader)
			{
				byte[] headerBuffer = receiveContext.HeaderBuffer;
				if (headerBuffer[0] == 240)
				{
					HandleReceivedDatagram(headerBuffer, headerBuffer.Length, willBeReused: true);
					receiveContext.Reset();
					ReceiveAsync(receiveContext);
					return;
				}
				int num2 = (headerBuffer[1] << 24) | (headerBuffer[2] << 16) | (headerBuffer[3] << 8) | headerBuffer[4];
				receiveContext.ExpectedMessageBytes = num2 - 7;
				if (receiveContext.ExpectedMessageBytes > receiveContext.MessageBuffer.Length)
				{
					receiveContext.MessageBuffer = new byte[receiveContext.ExpectedMessageBytes];
				}
				receiveContext.MessageBuffer[0] = headerBuffer[7];
				receiveContext.MessageBuffer[1] = headerBuffer[8];
				receiveContext.ReceivedMessageBytes = 2;
				ReceiveAsync(receiveContext);
			}
			else
			{
				HandleReceivedDatagram(receiveContext.MessageBuffer, receiveContext.ExpectedMessageBytes, willBeReused: true);
				receiveContext.Reset();
				ReceiveAsync(receiveContext);
			}
		}
	}
	public class SocketUdp : IPhotonSocket, IDisposable
	{
		private Socket sock;

		private readonly object syncer = new object();

		[Preserve]
		public SocketUdp(PeerBase npeer)
			: base(npeer)
		{
			if (ReportDebugOfLevel(DebugLevel.INFO))
			{
				base.Listener.DebugReturn(DebugLevel.INFO, "SocketUdp, .Net, Unity.");
			}
			PollReceive = false;
		}

		~SocketUdp()
		{
			Dispose();
		}

		public void Dispose()
		{
			base.State = PhotonSocketState.Disconnecting;
			if (sock != null)
			{
				try
				{
					if (sock.Connected)
					{
						sock.Close(1);
					}
				}
				catch (Exception ex)
				{
					EnqueueDebugReturn(DebugLevel.INFO, "Exception in Dispose(): " + ex);
				}
			}
			sock = null;
			base.State = PhotonSocketState.Disconnected;
		}

		public override bool Connect()
		{
			lock (syncer)
			{
				if (!base.Connect())
				{
					return false;
				}
				base.State = PhotonSocketState.Connecting;
			}
			Thread thread = new Thread(DnsAndConnect);
			thread.IsBackground = true;
			thread.Start();
			return true;
		}

		public override bool Disconnect()
		{
			if (ReportDebugOfLevel(DebugLevel.INFO))
			{
				EnqueueDebugReturn(DebugLevel.INFO, "SocketUdp.Disconnect()");
			}
			lock (syncer)
			{
				base.State = PhotonSocketState.Disconnecting;
				if (sock != null)
				{
					try
					{
						sock.Close(1);
					}
					catch (Exception ex)
					{
						if (ReportDebugOfLevel(DebugLevel.INFO))
						{
							EnqueueDebugReturn(DebugLevel.INFO, "Exception in Disconnect(): " + ex);
						}
					}
				}
				base.State = PhotonSocketState.Disconnected;
			}
			return true;
		}

		public override PhotonSocketError Send(byte[] data, int length)
		{
			try
			{
				if (sock == null || !sock.Connected)
				{
					return PhotonSocketError.Skipped;
				}
				sock.Send(data, 0, length, SocketFlags.None);
			}
			catch (SocketException ex)
			{
				if (ex.SocketErrorCode == SocketError.WouldBlock)
				{
					return PhotonSocketError.Busy;
				}
				if (base.State == PhotonSocketState.Disconnecting || base.State == PhotonSocketState.Disconnected)
				{
					return PhotonSocketError.Exception;
				}
				base.SocketErrorCode = (int)ex.SocketErrorCode;
				if (ReportDebugOfLevel(DebugLevel.INFO))
				{
					string text = "";
					if (sock != null)
					{
						text = string.Format(" Local: {0} Remote: {1} ({2}, {3})", sock.LocalEndPoint, sock.RemoteEndPoint, sock.Connected ? "connected" : "not connected", sock.IsBound ? "bound" : "not bound");
					}
					EnqueueDebugReturn(DebugLevel.INFO, string.Format("Cannot send to: {0}. Uptime: {1} ms. {2} {3}\n{4}", base.ServerAddress, peerBase.timeInt, base.AddressResolvedAsIpv6 ? " IPv6" : string.Empty, text, ex));
				}
				HandleException(StatusCode.SendError);
				return PhotonSocketError.Exception;
			}
			catch (Exception ex2)
			{
				if (base.State == PhotonSocketState.Disconnecting || base.State == PhotonSocketState.Disconnected)
				{
					return PhotonSocketError.Exception;
				}
				if (ReportDebugOfLevel(DebugLevel.INFO))
				{
					string text2 = "";
					if (sock != null)
					{
						text2 = string.Format(" Local: {0} Remote: {1} ({2}, {3})", sock.LocalEndPoint, sock.RemoteEndPoint, sock.Connected ? "connected" : "not connected", sock.IsBound ? "bound" : "not bound");
					}
					EnqueueDebugReturn(DebugLevel.INFO, string.Format("Cannot send to: {0}. Uptime: {1} ms. {2} {3}\n{4}", base.ServerAddress, peerBase.timeInt, base.AddressResolvedAsIpv6 ? " IPv6" : string.Empty, text2, ex2));
				}
				if (!sock.Connected)
				{
					EnqueueDebugReturn(DebugLevel.INFO, "Caught Exception in Send(). Ending connection with StatusCode.SendError.");
					HandleException(StatusCode.SendError);
				}
				return PhotonSocketError.Exception;
			}
			return PhotonSocketError.Success;
		}

		public override PhotonSocketError Receive(out byte[] data)
		{
			data = null;
			return PhotonSocketError.NoData;
		}

		internal void DnsAndConnect()
		{
			IPAddress[] ipAddresses = GetIpAddresses(base.ServerAddress);
			if (ipAddresses == null)
			{
				return;
			}
			string text = string.Empty;
			IPAddress[] array = ipAddresses;
			foreach (IPAddress iPAddress in array)
			{
				try
				{
					sock = new Socket(iPAddress.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
					sock.Blocking = false;
					sock.Connect(iPAddress, base.ServerPort);
					if (sock != null && sock.Connected)
					{
						break;
					}
				}
				catch (SocketException ex)
				{
					if (ReportDebugOfLevel(DebugLevel.WARNING))
					{
						text = text + ex?.ToString() + " " + ex.ErrorCode + "; ";
						EnqueueDebugReturn(DebugLevel.WARNING, "SocketException caught: " + ex?.ToString() + " ErrorCode: " + ex.ErrorCode);
					}
				}
				catch (Exception ex2)
				{
					if (ReportDebugOfLevel(DebugLevel.WARNING))
					{
						text = text + ex2?.ToString() + "; ";
						EnqueueDebugReturn(DebugLevel.WARNING, "Exception caught: " + ex2);
					}
				}
			}
			if (sock == null || !sock.Connected)
			{
				if (ReportDebugOfLevel(DebugLevel.ERROR))
				{
					EnqueueDebugReturn(DebugLevel.ERROR, "Failed to connect to server after testing each known IP. Error(s): " + text);
				}
				HandleException(StatusCode.ExceptionOnConnect);
			}
			else
			{
				base.AddressResolvedAsIpv6 = sock.AddressFamily == AddressFamily.InterNetworkV6;
				IPhotonSocket.ServerIpAddress = sock.RemoteEndPoint.ToString();
				base.State = PhotonSocketState.Connected;
				peerBase.OnConnect();
				Thread thread = new Thread(ReceiveLoop);
				thread.IsBackground = true;
				thread.Start();
			}
		}

		public void ReceiveLoop()
		{
			byte[] array = new byte[base.MTU];
			while (base.State == PhotonSocketState.Connected)
			{
				try
				{
					if (sock.Poll(5000, SelectMode.SelectRead))
					{
						int length = sock.Receive(array);
						HandleReceivedDatagram(array, length, willBeReused: true);
					}
				}
				catch (SocketException ex)
				{
					if (base.State != PhotonSocketState.Disconnecting && base.State != PhotonSocketState.Disconnected)
					{
						if (ReportDebugOfLevel(DebugLevel.ERROR))
						{
							EnqueueDebugReturn(DebugLevel.ERROR, "Receive issue. State: " + base.State.ToString() + ". Server: '" + base.ServerAddress + "' ErrorCode: " + ex.ErrorCode + " SocketErrorCode: " + ex.SocketErrorCode.ToString() + " Message: " + ex.Message + " " + ex);
						}
						base.SocketErrorCode = (int)ex.SocketErrorCode;
						HandleException(StatusCode.ExceptionOnReceive);
					}
				}
				catch (Exception ex2)
				{
					if (base.State != PhotonSocketState.Disconnecting && base.State != PhotonSocketState.Disconnected)
					{
						if (ReportDebugOfLevel(DebugLevel.ERROR))
						{
							EnqueueDebugReturn(DebugLevel.ERROR, "Receive issue. State: " + base.State.ToString() + ". Server: '" + base.ServerAddress + "' Message: " + ex2.Message + " Exception: " + ex2);
						}
						HandleException(StatusCode.ExceptionOnReceive);
					}
				}
			}
			lock (syncer)
			{
				if (base.State != PhotonSocketState.Disconnecting && base.State != PhotonSocketState.Disconnected)
				{
					Disconnect();
				}
			}
		}
	}
	public class SocketUdpAsync : IPhotonSocket, IDisposable
	{
		private Socket sock;

		private readonly object syncer = new object();

		[Preserve]
		public SocketUdpAsync(PeerBase npeer)
			: base(npeer)
		{
			if (ReportDebugOfLevel(DebugLevel.INFO))
			{
				base.Listener.DebugReturn(DebugLevel.INFO, "SocketUdpAsync, .Net, Unity.");
			}
			PollReceive = false;
		}

		~SocketUdpAsync()
		{
			Dispose();
		}

		public void Dispose()
		{
			base.State = PhotonSocketState.Disconnecting;
			if (sock != null)
			{
				try
				{
					if (sock.Connected)
					{
						sock.Close();
					}
				}
				catch (Exception ex)
				{
					EnqueueDebugReturn(DebugLevel.INFO, "Exception in Dispose(): " + ex);
				}
			}
			sock = null;
			base.State = PhotonSocketState.Disconnected;
		}

		public override bool Connect()
		{
			lock (syncer)
			{
				if (!base.Connect())
				{
					return false;
				}
				base.State = PhotonSocketState.Connecting;
			}
			Thread thread = new Thread(DnsAndConnect);
			thread.IsBackground = true;
			thread.Start();
			return true;
		}

		public override bool Disconnect()
		{
			if (ReportDebugOfLevel(DebugLevel.INFO))
			{
				EnqueueDebugReturn(DebugLevel.INFO, "SocketUdpAsync.Disconnect()");
			}
			lock (syncer)
			{
				base.State = PhotonSocketState.Disconnecting;
				if (sock != null)
				{
					try
					{
						sock.Close();
					}
					catch (Exception ex)
					{
						if (ReportDebugOfLevel(DebugLevel.INFO))
						{
							EnqueueDebugReturn(DebugLevel.INFO, "Exception in Disconnect(): " + ex);
						}
					}
				}
				base.State = PhotonSocketState.Disconnected;
			}
			return true;
		}

		public override PhotonSocketError Send(byte[] data, int length)
		{
			try
			{
				if (sock == null || !sock.Connected)
				{
					return PhotonSocketError.Skipped;
				}
				sock.Send(data, 0, length, SocketFlags.None);
			}
			catch (Exception ex)
			{
				if (base.State != PhotonSocketState.Disconnecting && base.State != PhotonSocketState.Disconnected)
				{
					if (ReportDebugOfLevel(DebugLevel.INFO))
					{
						string text = "";
						if (sock != null)
						{
							text = string.Format(" Local: {0} Remote: {1} ({2}, {3})", sock.LocalEndPoint, sock.RemoteEndPoint, sock.Connected ? "connected" : "not connected", sock.IsBound ? "bound" : "not bound");
						}
						EnqueueDebugReturn(DebugLevel.INFO, string.Format("Cannot send to: {0}. Uptime: {1} ms. {2} {3}\n{4}", base.ServerAddress, peerBase.timeInt, base.AddressResolvedAsIpv6 ? " IPv6" : string.Empty, text, ex));
					}
					if (!sock.Connected)
					{
						EnqueueDebugReturn(DebugLevel.INFO, "Socket got closed by the local system. Disconnecting from within Send with StatusCode.Disconnect.");
						HandleException(StatusCode.SendError);
					}
				}
				return PhotonSocketError.Exception;
			}
			return PhotonSocketError.Success;
		}

		public override PhotonSocketError Receive(out byte[] data)
		{
			data = null;
			return PhotonSocketError.NoData;
		}

		internal void DnsAndConnect()
		{
			IPAddress[] ipAddresses = GetIpAddresses(base.ServerAddress);
			if (ipAddresses == null)
			{
				return;
			}
			string text = string.Empty;
			IPAddress[] array = ipAddresses;
			foreach (IPAddress iPAddress in array)
			{
				try
				{
					sock = new Socket(iPAddress.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
					sock.Connect(iPAddress, base.ServerPort);
					if (sock != null && sock.Connected)
					{
						break;
					}
				}
				catch (SocketException ex)
				{
					if (ReportDebugOfLevel(DebugLevel.WARNING))
					{
						text = text + ex?.ToString() + " " + ex.ErrorCode + "; ";
						EnqueueDebugReturn(DebugLevel.WARNING, "SocketException catched: " + ex?.ToString() + " ErrorCode: " + ex.ErrorCode);
					}
				}
				catch (Exception ex2)
				{
					if (ReportDebugOfLevel(DebugLevel.WARNING))
					{
						text = text + ex2?.ToString() + "; ";
						EnqueueDebugReturn(DebugLevel.WARNING, "Exception catched: " + ex2);
					}
				}
			}
			if (sock == null || !sock.Connected)
			{
				if (ReportDebugOfLevel(DebugLevel.ERROR))
				{
					EnqueueDebugReturn(DebugLevel.ERROR, "Failed to connect to server after testing each known IP. Error(s): " + text);
				}
				HandleException(StatusCode.ExceptionOnConnect);
			}
			else
			{
				base.AddressResolvedAsIpv6 = sock.AddressFamily == AddressFamily.InterNetworkV6;
				IPhotonSocket.ServerIpAddress = sock.RemoteEndPoint.ToString();
				base.State = PhotonSocketState.Connected;
				peerBase.OnConnect();
				StartReceive();
			}
		}

		public void StartReceive()
		{
			byte[] array = new byte[base.MTU];
			try
			{
				sock.BeginReceive(array, 0, array.Length, SocketFlags.None, OnReceive, array);
			}
			catch (Exception ex)
			{
				if (base.State != PhotonSocketState.Disconnecting && base.State != PhotonSocketState.Disconnected)
				{
					if (ReportDebugOfLevel(DebugLevel.ERROR))
					{
						EnqueueDebugReturn(DebugLevel.ERROR, "Receive issue. State: " + base.State.ToString() + ". Server: '" + base.ServerAddress + "' Exception: " + ex);
					}
					HandleException(StatusCode.ExceptionOnReceive);
				}
			}
		}

		private void OnReceive(IAsyncResult ar)
		{
			if (base.State == PhotonSocketState.Disconnecting || base.State == PhotonSocketState.Disconnected)
			{
				return;
			}
			int length = 0;
			try
			{
				length = sock.EndReceive(ar);
			}
			catch (SocketException ex)
			{
				if (base.State != PhotonSocketState.Disconnecting && base.State != PhotonSocketState.Disconnected)
				{
					if (ReportDebugOfLevel(DebugLevel.ERROR))
					{
						EnqueueDebugReturn(DebugLevel.ERROR, "SocketException in EndReceive. State: " + base.State.ToString() + ". Server: '" + base.ServerAddress + "' ErrorCode: " + ex.ErrorCode + " SocketErrorCode: " + ex.SocketErrorCode.ToString() + " Message: " + ex.Message + " " + ex);
					}
					HandleException(StatusCode.ExceptionOnReceive);
				}
			}
			catch (Exception ex2)
			{
				if (base.State != PhotonSocketState.Disconnecting && base.State != PhotonSocketState.Disconnected)
				{
					if (ReportDebugOfLevel(DebugLevel.ERROR))
					{
						EnqueueDebugReturn(DebugLevel.ERROR, "Exception in EndReceive. State: " + base.State.ToString() + ". Server: '" + base.ServerAddress + "' Exception: " + ex2);
					}
					HandleException(StatusCode.ExceptionOnReceive);
				}
			}
			if (base.State == PhotonSocketState.Disconnecting || base.State == PhotonSocketState.Disconnected)
			{
				return;
			}
			byte[] array = (byte[])ar.AsyncState;
			HandleReceivedDatagram(array, length, willBeReused: true);
			try
			{
				sock.BeginReceive(array, 0, array.Length, SocketFlags.None, OnReceive, array);
			}
			catch (SocketException ex3)
			{
				if (base.State != PhotonSocketState.Disconnecting && base.State != PhotonSocketState.Disconnected)
				{
					if (ReportDebugOfLevel(DebugLevel.ERROR))
					{
						EnqueueDebugReturn(DebugLevel.ERROR, "SocketException in BeginReceive. State: " + base.State.ToString() + ". Server: '" + base.ServerAddress + "' ErrorCode: " + ex3.ErrorCode + " SocketErrorCode: " + ex3.SocketErrorCode.ToString() + " Message: " + ex3.Message + " " + ex3);
					}
					HandleException(StatusCode.ExceptionOnReceive);
				}
			}
			catch (Exception ex4)
			{
				if (base.State != PhotonSocketState.Disconnecting && base.State != PhotonSocketState.Disconnected)
				{
					if (ReportDebugOfLevel(DebugLevel.ERROR))
					{
						EnqueueDebugReturn(DebugLevel.ERROR, "Exception in BeginReceive. State: " + base.State.ToString() + ". Server: '" + base.ServerAddress + "' Exception: " + ex4);
					}
					HandleException(StatusCode.ExceptionOnReceive);
				}
			}
		}
	}
	public class SocketUdpBlocking : IPhotonSocket, IDisposable
	{
		private Socket sock;

		private readonly object syncer = new object();

		[Preserve]
		public SocketUdpBlocking(PeerBase npeer)
			: base(npeer)
		{
			if (ReportDebugOfLevel(DebugLevel.INFO))
			{
				base.Listener.DebugReturn(DebugLevel.INFO, "SocketUdpBlocking, .Net, Unity.");
			}
			PollReceive = false;
		}

		~SocketUdpBlocking()
		{
			Dispose();
		}

		public void Dispose()
		{
			base.State = PhotonSocketState.Disconnecting;
			if (sock != null)
			{
				try
				{
					if (sock.Connected)
					{
						sock.Close(1);
					}
				}
				catch (Exception ex)
				{
					EnqueueDebugReturn(DebugLevel.INFO, "Exception in Dispose(): " + ex);
				}
			}
			sock = null;
			base.State = PhotonSocketState.Disconnected;
		}

		public override bool Connect()
		{
			lock (syncer)
			{
				if (!base.Connect())
				{
					return false;
				}
				base.State = PhotonSocketState.Connecting;
			}
			Thread thread = new Thread(DnsAndConnect);
			thread.IsBackground = true;
			thread.Start();
			return true;
		}

		public override bool Disconnect()
		{
			if (ReportDebugOfLevel(DebugLevel.INFO))
			{
				EnqueueDebugReturn(DebugLevel.INFO, "SocketUdpBlocking.Disconnect()");
			}
			lock (syncer)
			{
				base.State = PhotonSocketState.Disconnecting;
				if (sock != null)
				{
					try
					{
						sock.Close(1);
					}
					catch (Exception ex)
					{
						if (ReportDebugOfLevel(DebugLevel.INFO))
						{
							EnqueueDebugReturn(DebugLevel.INFO, "Exception in Disconnect(): " + ex);
						}
					}
				}
				base.State = PhotonSocketState.Disconnected;
			}
			return true;
		}

		public override PhotonSocketError Send(byte[] data, int length)
		{
			try
			{
				if (sock == null || !sock.Connected)
				{
					return PhotonSocketError.Skipped;
				}
				sock.Send(data, 0, length, SocketFlags.None);
			}
			catch (Exception ex)
			{
				if (base.State != PhotonSocketState.Disconnecting && base.State != PhotonSocketState.Disconnected)
				{
					if (ReportDebugOfLevel(DebugLevel.INFO))
					{
						string text = "";
						if (sock != null)
						{
							text = string.Format(" Local: {0} Remote: {1} ({2}, {3})", sock.LocalEndPoint, sock.RemoteEndPoint, sock.Connected ? "connected" : "not connected", sock.IsBound ? "bound" : "not bound");
						}
						EnqueueDebugReturn(DebugLevel.INFO, string.Format("Cannot send to: {0}. Uptime: {1} ms. {2} {3}\n{4}", base.ServerAddress, peerBase.timeInt, base.AddressResolvedAsIpv6 ? " IPv6" : string.Empty, text, ex));
					}
					if (!sock.Connected)
					{
						EnqueueDebugReturn(DebugLevel.INFO, "Socket got closed by the local system. Disconnecting from within Send with StatusCode.Disconnect.");
						HandleException(StatusCode.SendError);
					}
				}
				return PhotonSocketError.Exception;
			}
			return PhotonSocketError.Success;
		}

		public override PhotonSocketError Receive(out byte[] data)
		{
			data = null;
			return PhotonSocketError.NoData;
		}

		internal void DnsAndConnect()
		{
			IPAddress[] ipAddresses = GetIpAddresses(base.ServerAddress);
			if (ipAddresses == null)
			{
				return;
			}
			string text = string.Empty;
			IPAddress[] array = ipAddresses;
			foreach (IPAddress iPAddress in array)
			{
				try
				{
					sock = new Socket(iPAddress.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
					sock.Blocking = false;
					sock.Connect(iPAddress, base.ServerPort);
					if (sock != null && sock.Connected)
					{
						break;
					}
				}
				catch (SocketException ex)
				{
					if (ReportDebugOfLevel(DebugLevel.WARNING))
					{
						text = text + ex?.ToString() + " " + ex.ErrorCode + "; ";
						EnqueueDebugReturn(DebugLevel.WARNING, "SocketException caught: " + ex?.ToString() + " ErrorCode: " + ex.ErrorCode);
					}
				}
				catch (Exception ex2)
				{
					if (ReportDebugOfLevel(DebugLevel.WARNING))
					{
						text = text + ex2?.ToString() + "; ";
						EnqueueDebugReturn(DebugLevel.WARNING, "Exception caught: " + ex2);
					}
				}
			}
			if (sock == null || !sock.Connected)
			{
				if (ReportDebugOfLevel(DebugLevel.ERROR))
				{
					EnqueueDebugReturn(DebugLevel.ERROR, "Failed to connect to server after testing each known IP. Error(s): " + text);
				}
				HandleException(StatusCode.ExceptionOnConnect);
			}
			else
			{
				base.AddressResolvedAsIpv6 = sock.AddressFamily == AddressFamily.InterNetworkV6;
				IPhotonSocket.ServerIpAddress = sock.RemoteEndPoint.ToString();
				base.State = PhotonSocketState.Connected;
				peerBase.OnConnect();
				Thread thread = new Thread(ReceiveLoop);
				thread.IsBackground = true;
				thread.Start();
			}
		}

		public void ReceiveLoop()
		{
			byte[] array = new byte[base.MTU];
			while (base.State == PhotonSocketState.Connected)
			{
				try
				{
					if (sock.Poll(5000, SelectMode.SelectRead))
					{
						int length = sock.Receive(array);
						HandleReceivedDatagram(array, length, willBeReused: true);
					}
				}
				catch (SocketException ex)
				{
					if (base.State != PhotonSocketState.Disconnecting && base.State != PhotonSocketState.Disconnected)
					{
						if (ReportDebugOfLevel(DebugLevel.ERROR))
						{
							EnqueueDebugReturn(DebugLevel.ERROR, "Receive issue. State: " + base.State.ToString() + ". Server: '" + base.ServerAddress + "' ErrorCode: " + ex.ErrorCode + " SocketErrorCode: " + ex.SocketErrorCode.ToString() + " Message: " + ex.Message + " " + ex);
						}
						HandleException(StatusCode.ExceptionOnReceive);
					}
				}
				catch (Exception ex2)
				{
					if (base.State != PhotonSocketState.Disconnecting && base.State != PhotonSocketState.Disconnected)
					{
						if (ReportDebugOfLevel(DebugLevel.ERROR))
						{
							EnqueueDebugReturn(DebugLevel.ERROR, "Receive issue. State: " + base.State.ToString() + ". Server: '" + base.ServerAddress + "' Message: " + ex2.Message + " Exception: " + ex2);
						}
						HandleException(StatusCode.ExceptionOnReceive);
					}
				}
			}
			lock (syncer)
			{
				if (base.State != PhotonSocketState.Disconnecting && base.State != PhotonSocketState.Disconnected)
				{
					Disconnect();
				}
			}
		}
	}
	public class StreamBuffer
	{
		private const int DefaultInitialSize = 0;

		private int pos;

		private int len;

		private byte[] buf;

		public bool CanRead => true;

		public bool CanSeek => true;

		public bool CanWrite => true;

		public int Length => len;

		public int Position
		{
			get
			{
				return pos;
			}
			set
			{
				pos = value;
				if (len < pos)
				{
					len = pos;
					CheckSize(len);
				}
			}
		}

		public int Available
		{
			get
			{
				int num = len - pos;
				return (num >= 0) ? num : 0;
			}
		}

		public StreamBuffer(int size = 0)
		{
			buf = new byte[size];
		}

		public StreamBuffer(byte[] buf)
		{
			this.buf = buf;
			len = buf.Length;
		}

		public byte[] ToArray()
		{
			byte[] array = new byte[len];
			Buffer.BlockCopy(buf, 0, array, 0, len);
			return array;
		}

		public byte[] ToArrayFromPos()
		{
			int num = len - pos;
			if (num <= 0)
			{
				return new byte[0];
			}
			byte[] array = new byte[num];
			Buffer.BlockCopy(buf, pos, array, 0, num);
			return array;
		}

		public void Compact()
		{
			long num = Length - Position;
			if (num > 0)
			{
				Buffer.BlockCopy(buf, Position, buf, 0, (int)num);
			}
			Position = 0;
			SetLength(num);
		}

		public byte[] GetBuffer()
		{
			return buf;
		}

		public byte[] GetBufferAndAdvance(int length, out int offset)
		{
			offset = Position;
			Position += length;
			return buf;
		}

		public void Flush()
		{
		}

		public long Seek(long offset, SeekOrigin origin)
		{
			int num = 0;
			num = origin switch
			{
				SeekOrigin.Begin => (int)offset, 
				SeekOrigin.Current => pos + (int)offset, 
				SeekOrigin.End => len + (int)offset, 
				_ => throw new ArgumentException("Invalid seek origin"), 
			};
			if (num < 0)
			{
				throw new ArgumentException("Seek before begin");
			}
			if (num > len)
			{
				throw new ArgumentException("Seek after end");
			}
			pos = num;
			return pos;
		}

		public void SetLength(long value)
		{
			len = (int)value;
			CheckSize(len);
			if (pos > len)
			{
				pos = len;
			}
		}

		public void SetCapacityMinimum(int neededSize)
		{
			CheckSize(neededSize);
		}

		public int Read(byte[] buffer, int dstOffset, int count)
		{
			int num = len - pos;
			if (num <= 0)
			{
				return 0;
			}
			if (count > num)
			{
				count = num;
			}
			Buffer.BlockCopy(buf, pos, buffer, dstOffset, count);
			pos += count;
			return count;
		}

		public void Write(byte[] buffer, int srcOffset, int count)
		{
			int num = pos + count;
			CheckSize(num);
			if (num > len)
			{
				len = num;
			}
			Buffer.BlockCopy(buffer, srcOffset, buf, pos, count);
			pos = num;
		}

		public byte ReadByte()
		{
			if (pos >= len)
			{
				throw new EndOfStreamException("SteamBuffer.ReadByte() failed. pos:" + pos + " len:" + len);
			}
			return buf[pos++];
		}

		public void WriteByte(byte value)
		{
			if (pos >= len)
			{
				len = pos + 1;
				CheckSize(len);
			}
			buf[pos++] = value;
		}

		public void WriteBytes(byte v0, byte v1)
		{
			int num = pos + 2;
			if (len < num)
			{
				len = num;
				CheckSize(len);
			}
			buf[pos++] = v0;
			buf[pos++] = v1;
		}

		public void WriteBytes(byte v0, byte v1, byte v2)
		{
			int num = pos + 3;
			if (len < num)
			{
				len = num;
				CheckSize(len);
			}
			buf[pos++] = v0;
			buf[pos++] = v1;
			buf[pos++] = v2;
		}

		public void WriteBytes(byte v0, byte v1, byte v2, byte v3)
		{
			int num = pos + 4;
			if (len < num)
			{
				len = num;
				CheckSize(len);
			}
			buf[pos++] = v0;
			buf[pos++] = v1;
			buf[pos++] = v2;
			buf[pos++] = v3;
		}

		public void WriteBytes(byte v0, byte v1, byte v2, byte v3, byte v4, byte v5, byte v6, byte v7)
		{
			int num = pos + 8;
			if (len < num)
			{
				len = num;
				CheckSize(len);
			}
			buf[pos++] = v0;
			buf[pos++] = v1;
			buf[pos++] = v2;
			buf[pos++] = v3;
			buf[pos++] = v4;
			buf[pos++] = v5;
			buf[pos++] = v6;
			buf[pos++] = v7;
		}

		private bool CheckSize(int size)
		{
			if (size <= buf.Length)
			{
				return false;
			}
			int num = buf.Length;
			if (num == 0)
			{
				num = 1;
			}
			while (size > num)
			{
				num *= 2;
			}
			byte[] dst = new byte[num];
			Buffer.BlockCopy(buf, 0, dst, 0, buf.Length);
			buf = dst;
			return true;
		}
	}
	public class SupportClass
	{
		[Obsolete("Use a Stopwatch (or equivalent) instead.")]
		public delegate int IntegerMillisecondsDelegate();

		public class ThreadSafeRandom
		{
			private static readonly System.Random _r = new System.Random();

			public static int Next()
			{
				lock (_r)
				{
					return _r.Next();
				}
			}
		}

		private static List<Thread> threadList;

		private static readonly object ThreadListLock = new object();

		[Obsolete("Use a Stopwatch (or equivalent) instead.")]
		protected internal static IntegerMillisecondsDelegate IntegerMilliseconds = () => Environment.TickCount;

		private static uint[] crcLookupTable;

		public static List<MethodInfo> GetMethods(Type type, Type attribute)
		{
			List<MethodInfo> list = new List<MethodInfo>();
			if (type == null)
			{
				return list;
			}
			MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			MethodInfo[] array = methods;
			foreach (MethodInfo methodInfo in array)
			{
				if (attribute == null || methodInfo.IsDefined(attribute, inherit: false))
				{
					list.Add(methodInfo);
				}
			}
			return list;
		}

		[Obsolete("Use a Stopwatch (or equivalent) instead.")]
		public static int GetTickCount()
		{
			return IntegerMilliseconds();
		}

		public static byte StartBackgroundCalls(Func<bool> myThread, int millisecondsInterval = 100, string taskName = "")
		{
			lock (ThreadListLock)
			{
				if (threadList == null)
				{
					threadList = new List<Thread>();
				}
				Thread thread = new Thread((ThreadStart)delegate
				{
					try
					{
						while (myThread())
						{
							Thread.Sleep(millisecondsInterval);
						}
					}
					catch (ThreadAbortException)
					{
					}
				});
				if (!string.IsNullOrEmpty(taskName))
				{
					thread.Name = taskName;
				}
				thread.IsBackground = true;
				thread.Start();
				for (int num = 0; num < threadList.Count; num++)
				{
					if (threadList[num] == null)
					{
						threadList[num] = thread;
						return (byte)num;
					}
				}
				if (threadList.Count >= 255)
				{
					throw new NotSupportedException("StartBackgroundCalls() can run a maximum of 255 threads.");
				}
				threadList.Add(thread);
				return (byte)(threadList.Count - 1);
			}
		}

		public static bool StopBackgroundCalls(byte id)
		{
			lock (ThreadListLock)
			{
				if (threadList == null || id >= threadList.Count || threadList[id] == null)
				{
					return false;
				}
				threadList[id].Abort();
				threadList[id] = null;
				return true;
			}
		}

		public static bool StopAllBackgroundCalls()
		{
			lock (ThreadListLock)
			{
				if (threadList == null)
				{
					return false;
				}
				foreach (Thread thread in threadList)
				{
					thread?.Abort();
				}
				threadList.Clear();
			}
			return true;
		}

		public static void WriteStackTrace(Exception throwable, TextWriter stream)
		{
			if (stream != null)
			{
				stream.WriteLine(throwable.ToString());
				stream.WriteLine(throwable.StackTrace);
				stream.Flush();
			}
			else
			{
				System.Diagnostics.Debug.WriteLine(throwable.ToString());
				System.Diagnostics.Debug.WriteLine(throwable.StackTrace);
			}
		}

		public static void WriteStackTrace(Exception throwable)
		{
			WriteStackTrace(throwable, null);
		}

		public static string DictionaryToString(IDictionary dictionary, bool includeTypes = true)
		{
			if (dictionary == null)
			{
				return "null";
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{");
			foreach (object key in dictionary.Keys)
			{
				if (stringBuilder.Length > 1)
				{
					stringBuilder.Append(", ");
				}
				Type type;
				string text;
				if (dictionary[key] == null)
				{
					type = typeof(object);
					text = "null";
				}
				else
				{
					type = dictionary[key].GetType();
					text = dictionary[key].ToString();
				}
				if (type == typeof(IDictionary) || type == typeof(Hashtable))
				{
					text = DictionaryToString((IDictionary)dictionary[key]);
				}
				else if (type == typeof(NonAllocDictionary<byte, object>))
				{
					text = DictionaryToString((NonAllocDictionary<byte, object>)dictionary[key]);
				}
				else if (type == typeof(string[]))
				{
					text = string.Format("{{{0}}}", string.Join(",", (string[])dictionary[key]));
				}
				else if (type == typeof(byte[]))
				{
					text = $"byte[{((byte[])dictionary[key]).Length}]";
				}
				else if (dictionary[key] is StructWrapper structWrapper)
				{
					stringBuilder.AppendFormat("{0}={1}", key, structWrapper.ToString(includeTypes));
					continue;
				}
				if (includeTypes)
				{
					stringBuilder.AppendFormat("({0}){1}=({2}){3}", key.GetType().Name, key, type.Name, text);
				}
				else
				{
					stringBuilder.AppendFormat("{0}={1}", key, text);
				}
			}
			stringBuilder.Append("}");
			return stringBuilder.ToString();
		}

		public static string DictionaryToString(NonAllocDictionary<byte, object> dictionary, bool includeTypes = true)
		{
			if (dictionary == null)
			{
				return "null";
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("{");
			foreach (byte key in dictionary.Keys)
			{
				if (stringBuilder.Length > 1)
				{
					stringBuilder.Append(", ");
				}
				Type type;
				string text;
				if (dictionary[key] == null)
				{
					type = typeof(object);
					text = "null";
				}
				else
				{
					type = dictionary[key].GetType();
					text = dictionary[key].ToString();
				}
				if (type == typeof(IDictionary) || type == typeof(Hashtable))
				{
					text = DictionaryToString((IDictionary)dictionary[key]);
				}
				else if (type == typeof(NonAllocDictionary<byte, object>))
				{
					text = DictionaryToString((NonAllocDictionary<byte, object>)dictionary[key]);
				}
				else if (type == typeof(string[]))
				{
					text = string.Format("{{{0}}}", string.Join(",", (string[])dictionary[key]));
				}
				else if (type == typeof(byte[]))
				{
					text = $"byte[{((byte[])dictionary[key]).Length}]";
				}
				else if (dictionary[key] is StructWrapper structWrapper)
				{
					stringBuilder.AppendFormat("{0}={1}", key, structWrapper.ToString(includeTypes));
					continue;
				}
				if (includeTypes)
				{
					stringBuilder.AppendFormat("({0}){1}=({2}){3}", key.GetType().Name, key, type.Name, text);
				}
				else
				{
					stringBuilder.AppendFormat("{0}={1}", key, text);
				}
			}
			stringBuilder.Append("}");
			return stringBuilder.ToString();
		}

		[Obsolete("Use DictionaryToString() instead.")]
		public static string HashtableToString(Hashtable hash)
		{
			return DictionaryToString(hash);
		}

		public static string ByteArrayToString(byte[] list, int length = -1)
		{
			if (list == null)
			{
				return string.Empty;
			}
			if (length < 0 || length > list.Length)
			{
				length = list.Length;
			}
			return BitConverter.ToString(list, 0, length);
		}

		private static uint[] InitializeTable(uint polynomial)
		{
			uint[] array = new uint[256];
			for (int i = 0; i < 256; i++)
			{
				uint num = (uint)i;
				for (int j = 0; j < 8; j++)
				{
					num = (((num & 1) != 1) ? (num >> 1) : ((num >> 1) ^ polynomial));
				}
				array[i] = num;
			}
			return array;
		}

		public static uint CalculateCrc(byte[] buffer, int length)
		{
			uint num = uint.MaxValue;
			uint polynomial = 3988292384u;
			if (crcLookupTable == null)
			{
				crcLookupTable = InitializeTable(polynomial);
			}
			for (int i = 0; i < length; i++)
			{
				num = (num >> 8) ^ crcLookupTable[buffer[i] ^ (num & 0xFF)];
			}
			return num;
		}
	}
	public class Pool<T> where T : class
	{
		private readonly Func<T> createFunction;

		private readonly Queue<T> pool;

		private readonly Action<T> resetFunction;

		public int Count
		{
			get
			{
				lock (pool)
				{
					return pool.Count;
				}
			}
		}

		public Pool(Func<T> createFunction, Action<T> resetFunction, int poolCapacity)
		{
			this.createFunction = createFunction;
			this.resetFunction = resetFunction;
			pool = new Queue<T>();
			CreatePoolItems(poolCapacity);
		}

		public Pool(Func<T> createFunction, int poolCapacity)
			: this(createFunction, (Action<T>)null, poolCapacity)
		{
		}

		private void CreatePoolItems(int numItems)
		{
			for (int i = 0; i < numItems; i++)
			{
				T item = createFunction();
				pool.Enqueue(item);
			}
		}

		[Obsolete("Use Release() rather than Push()")]
		public void Push(T item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("Pushing null as item is not allowed.");
			}
			if (resetFunction != null)
			{
				resetFunction(item);
			}
			lock (pool)
			{
				pool.Enqueue(item);
			}
		}

		public void Release(T item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("Pushing null as item is not allowed.");
			}
			if (resetFunction != null)
			{
				resetFunction(item);
			}
			lock (pool)
			{
				pool.Enqueue(item);
			}
		}

		[Obsolete("Use Acquire() rather than Pop()")]
		public T Pop()
		{
			T result;
			lock (pool)
			{
				if (pool.Count == 0)
				{
					return createFunction();
				}
				result = pool.Dequeue();
			}
			return result;
		}

		public T Acquire()
		{
			T result;
			lock (pool)
			{
				if (pool.Count == 0)
				{
					return createFunction();
				}
				result = pool.Dequeue();
			}
			return result;
		}
	}
	public class PreserveAttribute : Attribute
	{
	}
	internal class TPeer : PeerBase
	{
		internal const int TCP_HEADER_BYTES = 7;

		internal const int MSG_HEADER_BYTES = 2;

		public const int ALL_HEADER_BYTES = 9;

		private Queue<StreamBuffer> incomingList = new Queue<StreamBuffer>(32);

		internal List<StreamBuffer> outgoingStream;

		private int lastPingActivity;

		private readonly byte[] pingRequest = new byte[5] { 240, 0, 0, 0, 0 };

		private readonly ParameterDictionary pingParamDict = new ParameterDictionary();

		internal static readonly byte[] tcpFramedMessageHead = new byte[9] { 251, 0, 0, 0, 0, 0, 0, 243, 2 };

		internal static readonly byte[] tcpMsgHead = new byte[2] { 243, 2 };

		protected internal bool DoFraming = true;

		private bool waitForInitResponse = true;

		internal override int QueuedIncomingCommandsCount => incomingList.Count;

		internal override int QueuedOutgoingCommandsCount => outgoingCommandsInStream;

		internal TPeer()
		{
			TrafficPackageHeaderSize = 0;
		}

		internal override bool IsTransportEncrypted()
		{
			return usedTransportProtocol == ConnectionProtocol.WebSocketSecure;
		}

		internal override void Reset()
		{
			base.Reset();
			if (photonPeer.PayloadEncryptionSecret != null && usedTransportProtocol != ConnectionProtocol.WebSocketSecure)
			{
				InitEncryption(photonPeer.PayloadEncryptionSecret);
			}
			incomingList = new Queue<StreamBuffer>(32);
			timestampOfLastReceive = base.timeInt;
			lastPingActivity = base.timeInt;
			waitForInitResponse = true;
		}

		internal override bool Connect(string serverAddress, string proxyServerAddress, string appID, object photonToken)
		{
			outgoingStream = new List<StreamBuffer>();
			messageHeader = (DoFraming ? tcpFramedMessageHead : tcpMsgHead);
			if (usedTransportProtocol == ConnectionProtocol.WebSocket || usedTransportProtocol == ConnectionProtocol.WebSocketSecure)
			{
				PhotonSocket.ConnectAddress = PrepareWebSocketUrl(serverAddress, appID, photonToken);
			}
			if (PhotonSocket.Connect())
			{
				peerConnectionState = ConnectionStateValue.Connecting;
				return true;
			}
			return false;
		}

		public override void OnConnect()
		{
			lastPingActivity = base.timeInt;
			if (DoFraming || PhotonToken != null)
			{
				waitForInitResponse = true;
				byte[] data = WriteInitRequest();
				EnqueueInit(data);
			}
			else
			{
				waitForInitResponse = false;
			}
			SendOutgoingCommands();
		}

		internal override void Disconnect()
		{
			if (peerConnectionState != ConnectionStateValue.Disconnected && peerConnectionState != ConnectionStateValue.Disconnecting)
			{
				if ((int)base.debugOut >= 5)
				{
					base.Listener.DebugReturn(DebugLevel.ALL, "TPeer.Disconnect()");
				}
				StopConnection();
			}
		}

		internal override void StopConnection()
		{
			peerConnectionState = ConnectionStateValue.Disconnecting;
			if (PhotonSocket != null)
			{
				PhotonSocket.Disconnect();
			}
			lock (incomingList)
			{
				incomingList.Clear();
			}
			peerConnectionState = ConnectionStateValue.Disconnected;
			EnqueueStatusCallback(StatusCode.Disconnect);
		}

		internal override void FetchServerTimestamp()
		{
			SendPing();
			serverTimeOffsetIsAvailable = false;
		}

		private void EnqueueInit(byte[] data)
		{
			StreamBuffer streamBuffer = new StreamBuffer(data.Length + 32);
			byte[] array = new byte[7] { 251, 0, 0, 0, 0, 0, 1 };
			int targetOffset = 1;
			Protocol.Serialize(data.Length + array.Length, array, ref targetOffset);
			streamBuffer.Write(array, 0, array.Length);
			streamBuffer.Write(data, 0, data.Length);
			if (base.TrafficStatsEnabled)
			{
				base.TrafficStatsOutgoing.CountControlCommand(streamBuffer.Length);
			}
			EnqueueMessageAsPayload(DeliveryMode.Reliable, streamBuffer, 0);
		}

		internal override bool DispatchIncomingCommands()
		{
			if (peerConnectionState == ConnectionStateValue.Connected && base.timeInt - timestampOfLastReceive > base.DisconnectTimeout)
			{
				EnqueueStatusCallback(StatusCode.TimeoutDisconnect);
				EnqueueActionForDispatch(Disconnect);
			}
			while (true)
			{
				MyAction myAction;
				lock (ActionQueue)
				{
					if (ActionQueue.Count <= 0)
					{
						break;
					}
					myAction = ActionQueue.Dequeue();
					goto IL_0097;
				}
				IL_0097:
				myAction();
			}
			StreamBuffer streamBuffer;
			lock (incomingList)
			{
				if (incomingList.Count <= 0)
				{
					return false;
				}
				streamBuffer = incomingList.Dequeue();
			}
			ByteCountCurrentDispatch = streamBuffer.Length + 3;
			bool result = DeserializeMessageAndCallback(streamBuffer);
			PeerBase.MessageBufferPoolPut(streamBuffer);
			return result;
		}

		internal override bool SendOutgoingCommands()
		{
			if (peerConnectionState == ConnectionStateValue.Disconnected)
			{
				return false;
			}
			SendPing();
			if (!PhotonSocket.Connected)
			{
				return false;
			}
			timeLastSendOutgoing = base.timeInt;
			lock (outgoingStream)
			{
				int num = 0;
				int num2 = 0;
				PhotonSocketError photonSocketError = PhotonSocketError.Success;
				for (int i = 0; i < outgoingStream.Count; i++)
				{
					StreamBuffer streamBuffer = outgoingStream[i];
					photonSocketError = SendData(streamBuffer.GetBuffer(), streamBuffer.Length);
					if (photonSocketError == PhotonSocketError.Busy)
					{
						break;
					}
					num2 += streamBuffer.Length;
					num++;
					if (photonSocketError != PhotonSocketError.PendingSend)
					{
						PeerBase.MessageBufferPoolPut(streamBuffer);
					}
					if (num2 >= base.mtu || photonSocketError == PhotonSocketError.PendingSend)
					{
						break;
					}
				}
				outgoingStream.RemoveRange(0, num);
				outgoingCommandsInStream -= num;
				if (photonSocketError == PhotonSocketError.Busy || photonSocketError == PhotonSocketError.PendingSend)
				{
					return false;
				}
				return outgoingStream.Count > 0;
			}
		}

		internal override bool SendAcksOnly()
		{
			if (peerConnectionState == ConnectionStateValue.Disconnected)
			{
				return false;
			}
			SendPing();
			return false;
		}

		internal override bool EnqueuePhotonMessage(StreamBuffer opBytes, SendOptions sendParams)
		{
			return EnqueueMessageAsPayload(sendParams.DeliveryMode, opBytes, sendParams.Channel);
		}

		internal bool EnqueueMessageAsPayload(DeliveryMode deliveryMode, StreamBuffer opMessage, byte channelId)
		{
			if (opMessage == null)
			{
				return false;
			}
			if (DoFraming)
			{
				byte[] buffer = opMessage.GetBuffer();
				int targetOffset = 1;
				Protocol.Serialize(opMessage.Length, buffer, ref targetOffset);
				buffer[5] = channelId;
				switch (deliveryMode)
				{
				case DeliveryMode.Unreliable:
					buffer[6] = 0;
					break;
				case DeliveryMode.Reliable:
					buffer[6] = 1;
					break;
				case DeliveryMode.UnreliableUnsequenced:
					buffer[6] = 2;
					break;
				case DeliveryMode.ReliableUnsequenced:
					buffer[6] = 3;
					break;
				default:
					throw new ArgumentOutOfRangeException("DeliveryMode", deliveryMode, null);
				}
			}
			lock (outgoingStream)
			{
				outgoingStream.Add(opMessage);
				outgoingCommandsInStream++;
			}
			int num = (ByteCountLastOperation = opMessage.Length);
			if (base.TrafficStatsEnabled)
			{
				switch (deliveryMode)
				{
				case DeliveryMode.Unreliable:
				case DeliveryMode.UnreliableUnsequenced:
					base.TrafficStatsOutgoing.CountUnreliableOpCommand(num);
					break;
				case DeliveryMode.Reliable:
				case DeliveryMode.ReliableUnsequenced:
					base.TrafficStatsOutgoing.CountReliableOpCommand(num);
					break;
				}
				base.TrafficStatsGameLevel.CountOperation(num);
			}
			return true;
		}

		internal void SendPing()
		{
			if (base.timeInt - lastPingActivity < base.timePingInterval || (peerConnectionState != ConnectionStateValue.Connected && (peerConnectionState != ConnectionStateValue.Connecting || waitForInitResponse)))
			{
				return;
			}
			int num = (lastPingActivity = base.timeInt);
			StreamBuffer streamBuffer;
			if (!DoFraming)
			{
				lock (pingParamDict)
				{
					pingParamDict[1] = num;
					streamBuffer = SerializeOperationToMessage(PhotonCodes.Ping, pingParamDict, EgMessageType.InternalOperationRequest, encrypt: false);
				}
			}
			else
			{
				int targetOffset = 1;
				Protocol.Serialize(num, pingRequest, ref targetOffset);
				streamBuffer = PeerBase.MessageBufferPoolGet();
				streamBuffer.Write(pingRequest, 0, pingRequest.Length);
			}
			if (base.TrafficStatsEnabled)
			{
				base.TrafficStatsOutgoing.CountControlCommand(streamBuffer.Length);
			}
			if (SendData(streamBuffer.GetBuffer(), streamBuffer.Length) == PhotonSocketError.Success)
			{
				PeerBase.MessageBufferPoolPut(streamBuffer);
			}
		}

		internal PhotonSocketError SendData(byte[] data, int length)
		{
			PhotonSocketError result = PhotonSocketError.Success;
			try
			{
				bytesOut += length;
				if (base.TrafficStatsEnabled)
				{
					base.TrafficStatsOutgoing.TotalPacketCount++;
					base.TrafficStatsOutgoing.TotalCommandsInPackets++;
				}
				if (base.NetworkSimulationSettings.IsSimulationEnabled)
				{
					byte[] array = new byte[length];
					Buffer.BlockCopy(data, 0, array, 0, length);
					SendNetworkSimulated(array);
				}
				else
				{
					int num = base.timeInt;
					result = PhotonSocket.Send(data, length);
					int num2 = base.timeInt - num;
					if (num2 > longestSentCall)
					{
						longestSentCall = num2;
					}
				}
			}
			catch (Exception ex)
			{
				if ((int)base.debugOut >= 1)
				{
					base.Listener.DebugReturn(DebugLevel.ERROR, ex.ToString());
				}
				SupportClass.WriteStackTrace(ex);
			}
			return result;
		}

		internal override void ReceiveIncomingCommands(byte[] inbuff, int dataLength)
		{
			if (inbuff == null)
			{
				if ((int)base.debugOut >= 1)
				{
					EnqueueDebugReturn(DebugLevel.ERROR, "checkAndQueueIncomingCommands() inBuff: null");
				}
				return;
			}
			timestampOfLastReceive = base.timeInt;
			bytesIn += dataLength + 7;
			if (base.TrafficStatsEnabled)
			{
				base.TrafficStatsIncoming.TotalPacketCount++;
				base.TrafficStatsIncoming.TotalCommandsInPackets++;
			}
			if (inbuff[0] == 243)
			{
				byte b = (byte)(inbuff[1] & 0x7F);
				byte b2 = inbuff[2];
				if (b != 7 || b2 != PhotonCodes.Ping)
				{
					StreamBuffer streamBuffer = PeerBase.MessageBufferPoolGet();
					streamBuffer.Write(inbuff, 0, dataLength);
					streamBuffer.Position = 0;
					lock (incomingList)
					{
						incomingList.Enqueue(streamBuffer);
						return;
					}
				}
				DeserializeMessageAndCallback(new StreamBuffer(inbuff));
			}
			else if (inbuff[0] == 240)
			{
				base.TrafficStatsIncoming.CountControlCommand(dataLength);
				ReadPingResult(inbuff);
			}
			else if ((int)base.debugOut >= 1 && dataLength > 0)
			{
				EnqueueDebugReturn(DebugLevel.ERROR, "receiveIncomingCommands() MagicNumber should be 0xF0 or 0xF3. Is: " + inbuff[0] + " dataLength: " + dataLength);
			}
		}

		private void ReadPingResult(byte[] inbuff)
		{
			int value = 0;
			int value2 = 0;
			int offset = 1;
			Protocol.Deserialize(out value, inbuff, ref offset);
			Protocol.Deserialize(out value2, inbuff, ref offset);
			lastRoundTripTime = base.timeInt - value2;
			if (!serverTimeOffsetIsAvailable)
			{
				roundTripTime = lastRoundTripTime;
			}
			UpdateRoundTripTimeAndVariance(lastRoundTripTime);
			if (!serverTimeOffsetIsAvailable)
			{
				serverTimeOffset = value + (lastRoundTripTime >> 1) - base.timeInt;
				serverTimeOffsetIsAvailable = true;
			}
		}

		protected internal void ReadPingResult(OperationResponse operationResponse)
		{
			int num = (int)operationResponse.Parameters[2];
			int num2 = (int)operationResponse.Parameters[1];
			lastRoundTripTime = base.timeInt - num2;
			if (!serverTimeOffsetIsAvailable)
			{
				roundTripTime = lastRoundTripTime;
			}
			UpdateRoundTripTimeAndVariance(lastRoundTripTime);
			if (!serverTimeOffsetIsAvailable)
			{
				serverTimeOffset = num + (lastRoundTripTime >> 1) - base.timeInt;
				serverTimeOffsetIsAvailable = true;
			}
		}
	}
	public class TrafficStatsGameLevel
	{
		private Stopwatch watch;

		private int timeOfLastDispatchCall;

		private int timeOfLastSendCall;

		public int OperationByteCount { get; set; }

		public int OperationCount { get; set; }

		public int ResultByteCount { get; set; }

		public int ResultCount { get; set; }

		public int EventByteCount { get; set; }

		public int EventCount { get; set; }

		public int LongestOpResponseCallback { get; set; }

		public byte LongestOpResponseCallbackOpCode { get; set; }

		public int LongestEventCallback { get; set; }

		public int LongestMessageCallback { get; set; }

		public int LongestRawMessageCallback { get; set; }

		public byte LongestEventCallbackCode { get; set; }

		public int LongestDeltaBetweenDispatching { get; set; }

		public int LongestDeltaBetweenSending { get; set; }

		[Obsolete("Use DispatchIncomingCommandsCalls, which has proper naming.")]
		public int DispatchCalls => DispatchIncomingCommandsCalls;

		public int DispatchIncomingCommandsCalls { get; set; }

		public int SendOutgoingCommandsCalls { get; set; }

		public int TotalByteCount => OperationByteCount + ResultByteCount + EventByteCount;

		public int TotalMessageCount => OperationCount + ResultCount + EventCount;

		public int TotalIncomingByteCount => ResultByteCount + EventByteCount;

		public int TotalIncomingMessageCount => ResultCount + EventCount;

		public int TotalOutgoingByteCount => OperationByteCount;

		public int TotalOutgoingMessageCount => OperationCount;

		internal TrafficStatsGameLevel(Stopwatch sw)
		{
			watch = sw;
		}

		internal void CountOperation(int operationBytes)
		{
			OperationByteCount += operationBytes;
			OperationCount++;
		}

		internal void CountResult(int resultBytes)
		{
			ResultByteCount += resultBytes;
			ResultCount++;
		}

		internal void CountEvent(int eventBytes)
		{
			EventByteCount += eventBytes;
			EventCount++;
		}

		internal void TimeForResponseCallback(byte code, int time)
		{
			if (time > LongestOpResponseCallback)
			{
				LongestOpResponseCallback = time;
				LongestOpResponseCallbackOpCode = code;
			}
		}

		internal void TimeForEventCallback(byte code, int time)
		{
			if (time > LongestEventCallback)
			{
				LongestEventCallback = time;
				LongestEventCallbackCode = code;
			}
		}

		internal void TimeForMessageCallback(int time)
		{
			if (time > LongestMessageCallback)
			{
				LongestMessageCallback = time;
			}
		}

		internal void TimeForRawMessageCallback(int time)
		{
			if (time > LongestRawMessageCallback)
			{
				LongestRawMessageCallback = time;
			}
		}

		internal void DispatchIncomingCommandsCalled()
		{
			if (timeOfLastDispatchCall != 0)
			{
				int num = (int)watch.ElapsedMilliseconds - timeOfLastDispatchCall;
				if (num > LongestDeltaBetweenDispatching)
				{
					LongestDeltaBetweenDispatching = num;
				}
			}
			DispatchIncomingCommandsCalls++;
			timeOfLastDispatchCall = (int)watch.ElapsedMilliseconds;
		}

		internal void SendOutgoingCommandsCalled()
		{
			if (timeOfLastSendCall != 0)
			{
				int num = (int)watch.ElapsedMilliseconds - timeOfLastSendCall;
				if (num > LongestDeltaBetweenSending)
				{
					LongestDeltaBetweenSending = num;
				}
			}
			SendOutgoingCommandsCalls++;
			timeOfLastSendCall = (int)watch.ElapsedMilliseconds;
		}

		public void ResetMaximumCounters()
		{
			LongestDeltaBetweenDispatching = 0;
			LongestDeltaBetweenSending = 0;
			LongestEventCallback = 0;
			LongestEventCallbackCode = 0;
			LongestOpResponseCallback = 0;
			LongestOpResponseCallbackOpCode = 0;
			timeOfLastDispatchCall = 0;
			timeOfLastSendCall = 0;
		}

		public override string ToString()
		{
			return $"OperationByteCount: {OperationByteCount} ResultByteCount: {ResultByteCount} EventByteCount: {EventByteCount}";
		}

		public string ToStringVitalStats()
		{
			return string.Format("Longest delta between Send: {0}ms Dispatch: {1}ms. Longest callback OnEv: {3}={2}ms OnResp: {5}={4}ms. Calls of Send: {6} Dispatch: {7}.", LongestDeltaBetweenSending, LongestDeltaBetweenDispatching, LongestEventCallback, LongestEventCallbackCode, LongestOpResponseCallback, LongestOpResponseCallbackOpCode, SendOutgoingCommandsCalls, DispatchIncomingCommandsCalls);
		}
	}
	public class TrafficStats
	{
		public int PackageHeaderSize { get; internal set; }

		public int ReliableCommandCount { get; internal set; }

		public int UnreliableCommandCount { get; internal set; }

		public int FragmentCommandCount { get; internal set; }

		public int ControlCommandCount { get; internal set; }

		public int TotalPacketCount { get; internal set; }

		public int TotalCommandsInPackets { get; internal set; }

		public int ReliableCommandBytes { get; internal set; }

		public int UnreliableCommandBytes { get; internal set; }

		public int FragmentCommandBytes { get; internal set; }

		public int ControlCommandBytes { get; internal set; }

		public int TotalCommandCount => ReliableCommandCount + UnreliableCommandCount + FragmentCommandCount + ControlCommandCount;

		public int TotalCommandBytes => ReliableCommandBytes + UnreliableCommandBytes + FragmentCommandBytes + ControlCommandBytes;

		public int TotalPacketBytes => TotalCommandBytes + TotalPacketCount * PackageHeaderSize;

		public int TimestampOfLastAck { get; set; }

		public int TimestampOfLastReliableCommand { get; set; }

		internal TrafficStats(int packageHeaderSize)
		{
			PackageHeaderSize = packageHeaderSize;
		}

		internal void CountControlCommand(int size)
		{
			ControlCommandBytes += size;
			ControlCommandCount++;
		}

		internal void CountReliableOpCommand(int size)
		{
			ReliableCommandBytes += size;
			ReliableCommandCount++;
		}

		internal void CountUnreliableOpCommand(int size)
		{
			UnreliableCommandBytes += size;
			UnreliableCommandCount++;
		}

		internal void CountFragmentOpCommand(int size)
		{
			FragmentCommandBytes += size;
			FragmentCommandCount++;
		}

		public override string ToString()
		{
			return $"TotalPacketBytes: {TotalPacketBytes} TotalCommandBytes: {TotalCommandBytes} TotalPacketCount: {TotalPacketCount} TotalCommandsInPackets: {TotalCommandsInPackets}";
		}
	}
	internal static class Version
	{
		internal static readonly byte[] clientVersion = new byte[5] { 4, 1, 8, 15, 0 };
	}
}
namespace ExitGames.Client.Photon.StructWrapping
{
	public enum WrappedType
	{
		Unknown,
		Bool,
		Byte,
		Int16,
		Int32,
		Int64,
		Single,
		Double
	}
	public enum Pooling
	{
		Disconnected = 0,
		Connected = 1,
		ReleaseOnUnwrap = 2,
		Readonly = 4,
		CheckedOut = 8
	}
	public abstract class StructWrapper : IDisposable
	{
		public readonly WrappedType wrappedType;

		public readonly Type ttype;

		public StructWrapper(Type ttype, WrappedType wrappedType)
		{
			this.ttype = ttype;
			this.wrappedType = wrappedType;
		}

		public abstract object Box();

		public abstract void DisconnectFromPool();

		public abstract void Dispose();

		public abstract string ToString(bool writeType);

		public static implicit operator StructWrapper(bool value)
		{
			return value.Wrap();
		}

		public static implicit operator StructWrapper(byte value)
		{
			return value.Wrap();
		}

		public static implicit operator StructWrapper(float value)
		{
			return value.Wrap();
		}

		public static implicit operator StructWrapper(double value)
		{
			return value.Wrap();
		}

		public static implicit operator StructWrapper(short value)
		{
			return value.Wrap();
		}

		public static implicit operator StructWrapper(int value)
		{
			return value.Wrap();
		}

		public static implicit operator StructWrapper(long value)
		{
			return value.Wrap();
		}

		public static implicit operator bool(StructWrapper wrapper)
		{
			return (wrapper as StructWrapper<bool>).Unwrap();
		}

		public static implicit operator byte(StructWrapper wrapper)
		{
			return (wrapper as StructWrapper<byte>).Unwrap();
		}

		public static implicit operator float(StructWrapper wrapper)
		{
			return (wrapper as StructWrapper<float>).Unwrap();
		}

		public static implicit operator double(StructWrapper wrapper)
		{
			return (wrapper as StructWrapper<double>).Unwrap();
		}

		public static implicit operator short(StructWrapper wrapper)
		{
			return (wrapper as StructWrapper<short>).Unwrap();
		}

		public static implicit operator int(StructWrapper wrapper)
		{
			return (wrapper as StructWrapper<int>).Unwrap();
		}

		public static implicit operator long(StructWrapper wrapper)
		{
			return (wrapper as StructWrapper<long>).Unwrap();
		}

		public static implicit operator StructWrapper(UnityEngine.Vector2 value)
		{
			return value.Wrap();
		}

		public static implicit operator StructWrapper(UnityEngine.Vector3 value)
		{
			return value.Wrap();
		}

		public static implicit operator StructWrapper(UnityEngine.Quaternion value)
		{
			return value.Wrap();
		}

		public static implicit operator UnityEngine.Vector2(StructWrapper wrapper)
		{
			return (wrapper as StructWrapper<UnityEngine.Vector2>).Unwrap();
		}

		public static implicit operator UnityEngine.Vector3(StructWrapper wrapper)
		{
			return (wrapper as StructWrapper<UnityEngine.Vector3>).Unwrap();
		}

		public static implicit operator UnityEngine.Quaternion(StructWrapper wrapper)
		{
			return (wrapper as StructWrapper<UnityEngine.Quaternion>).Unwrap();
		}
	}
	public class StructWrapper<T> : StructWrapper
	{
		internal Pooling pooling;

		internal T value;

		internal static StructWrapperPool<T> staticPool = new StructWrapperPool<T>(isStaticPool: true);

		public StructWrapperPool<T> ReturnPool { get; internal set; }

		public StructWrapper(Pooling releasing)
			: base(typeof(T), StructWrapperPool.GetWrappedType(typeof(T)))
		{
			pooling = releasing;
		}

		public StructWrapper(Pooling releasing, Type tType, WrappedType wType)
			: base(tType, wType)
		{
			pooling = releasing;
		}

		public StructWrapper<T> Poke(byte value)
		{
			if (pooling == Pooling.Readonly)
			{
				throw new InvalidOperationException("Trying to Poke the value of a readonly StructWrapper<byte>. Value cannot be modified.");
			}
			return this;
		}

		public StructWrapper<T> Poke(bool value)
		{
			if (pooling == Pooling.Readonly)
			{
				throw new InvalidOperationException("Trying to Poke the value of a readonly StructWrapper<bool>. Value cannot be modified.");
			}
			return this;
		}

		public StructWrapper<T> Poke(T value)
		{
			this.value = value;
			return this;
		}

		public T Unwrap()
		{
			T result = value;
			if (pooling != Pooling.Readonly)
			{
				ReturnPool.Release(this);
			}
			return result;
		}

		public T Peek()
		{
			return value;
		}

		public override object Box()
		{
			T val = value;
			if (ReturnPool != null)
			{
				ReturnPool.Release(this);
			}
			return val;
		}

		public override void Dispose()
		{
			if ((pooling & Pooling.CheckedOut) == Pooling.CheckedOut && ReturnPool != null)
			{
				ReturnPool.Release(this);
			}
		}

		public override void DisconnectFromPool()
		{
			if (pooling != Pooling.Readonly)
			{
				pooling = Pooling.Disconnected;
				ReturnPool = null;
			}
		}

		public override string ToString()
		{
			return Unwrap().ToString();
		}

		public override string ToString(bool writeTypeInfo)
		{
			if (writeTypeInfo)
			{
				return $"(StructWrapper<{wrappedType}>){Unwrap().ToString()}";
			}
			return Unwrap().ToString();
		}

		public static implicit operator StructWrapper<T>(T value)
		{
			return staticPool.Acquire(value);
		}
	}
	public class StructWrapperPool
	{
		public static WrappedType GetWrappedType(Type type)
		{
			if (type == typeof(bool))
			{
				return WrappedType.Bool;
			}
			if (type == typeof(byte))
			{
				return WrappedType.Byte;
			}
			if (type == typeof(short))
			{
				return WrappedType.Int16;
			}
			if (type == typeof(int))
			{
				return WrappedType.Int32;
			}
			if (type == typeof(long))
			{
				return WrappedType.Int64;
			}
			if (type == typeof(float))
			{
				return WrappedType.Single;
			}
			if (type == typeof(double))
			{
				return WrappedType.Double;
			}
			return WrappedType.Unknown;
		}
	}
	public class StructWrapperPool<T> : StructWrapperPool
	{
		public const int GROWBY = 4;

		public readonly Type tType = typeof(T);

		public readonly WrappedType wType = StructWrapperPool.GetWrappedType(typeof(T));

		public Stack<StructWrapper<T>> pool;

		public readonly bool isStaticPool;

		public int Count => pool.Count;

		public StructWrapperPool(bool isStaticPool)
		{
			pool = new Stack<StructWrapper<T>>();
			this.isStaticPool = isStaticPool;
		}

		public StructWrapper<T> Acquire()
		{
			StructWrapper<T> structWrapper;
			if (pool.Count == 0)
			{
				int num = 1;
				while (true)
				{
					Pooling releasing = ((!isStaticPool) ? Pooling.Connected : ((Pooling)3));
					structWrapper = new StructWrapper<T>(releasing, tType, wType);
					structWrapper.ReturnPool = this;
					if (num == 4)
					{
						break;
					}
					pool.Push(structWrapper);
					num++;
					bool flag = true;
				}
			}
			else
			{
				structWrapper = pool.Pop();
			}
			structWrapper.pooling |= Pooling.CheckedOut;
			return structWrapper;
		}

		public StructWrapper<T> Acquire(T value)
		{
			StructWrapper<T> structWrapper = Acquire();
			structWrapper.value = value;
			return structWrapper;
		}

		internal void Release(StructWrapper<T> obj)
		{
			obj.pooling &= (Pooling)(-9);
			pool.Push(obj);
		}
	}
	public class StructWrapperPools
	{
		public static readonly StructWrapper<byte>[] mappedByteWrappers = new StructWrapper<byte>[256]
		{
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 0
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 1
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 2
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 3
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 4
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 5
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 6
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 7
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 8
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 9
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 10
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 11
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 12
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 13
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 14
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 15
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 16
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 17
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 18
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 19
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 20
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 21
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 22
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 23
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 24
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 25
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 26
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 27
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 28
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 29
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 30
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 31
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 32
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 33
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 34
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 35
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 36
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 37
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 38
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 39
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 40
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 41
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 42
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 43
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 44
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 45
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 46
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 47
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 48
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 49
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 50
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 51
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 52
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 53
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 54
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 55
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 56
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 57
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 58
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 59
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 60
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 61
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 62
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 63
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 64
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 65
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 66
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 67
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 68
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 69
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 70
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 71
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 72
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 73
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 74
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 75
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 76
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 77
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 78
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 79
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 80
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 81
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 82
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 83
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 84
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 85
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 86
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 87
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 88
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 89
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 90
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 91
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 92
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 93
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 94
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 95
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 96
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 97
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 98
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 99
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 100
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 101
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 102
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 103
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 104
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 105
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 106
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 107
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 108
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 109
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 110
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 111
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 112
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 113
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 114
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 115
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 116
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 117
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 118
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 119
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 120
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 121
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 122
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 123
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 124
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 125
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 126
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 127
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 128
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 129
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 130
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 131
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 132
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 133
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 134
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 135
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 136
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 137
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 138
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 139
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 140
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 141
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 142
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 143
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 144
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 145
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 146
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 147
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 148
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 149
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 150
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 151
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 152
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 153
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 154
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 155
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 156
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 157
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 158
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 159
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 160
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 161
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 162
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 163
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 164
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 165
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 166
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 167
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 168
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 169
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 170
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 171
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 172
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 173
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 174
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 175
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 176
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 177
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 178
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 179
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 180
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 181
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 182
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 183
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 184
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 185
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 186
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 187
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 188
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 189
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 190
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 191
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 192
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 193
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 194
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 195
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 196
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 197
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 198
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 199
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 200
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 201
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 202
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 203
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 204
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 205
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 206
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 207
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 208
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 209
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 210
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 211
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 212
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 213
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 214
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 215
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 216
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 217
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 218
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 219
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 220
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 221
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 222
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 223
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 224
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 225
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 226
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 227
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 228
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 229
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 230
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 231
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 232
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 233
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 234
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 235
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 236
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 237
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 238
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 239
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 240
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 241
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 242
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 243
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 244
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 245
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 246
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 247
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 248
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 249
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 250
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 251
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 252
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 253
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = 254
			},
			new StructWrapper<byte>(Pooling.Readonly)
			{
				value = byte.MaxValue
			}
		};

		public static readonly StructWrapper<bool>[] mappedBoolWrappers = new StructWrapper<bool>[2]
		{
			new StructWrapper<bool>(Pooling.Readonly)
			{
				value = false
			},
			new StructWrapper<bool>(Pooling.Readonly)
			{
				value = true
			}
		};

		private readonly Dictionary<Type, StructWrapperPool> pools = new Dictionary<Type, StructWrapperPool>();

		private readonly List<IDisposable> used = new List<IDisposable>();

		private StructWrapperPool<T> GetPoolForType<T>()
		{
			if (pools.TryGetValue(typeof(T), out var value))
			{
				return value as StructWrapperPool<T>;
			}
			StructWrapperPool<T> structWrapperPool = new StructWrapperPool<T>(isStaticPool: false);
			pools.Add(typeof(T), structWrapperPool);
			return structWrapperPool;
		}

		public StructWrapper<byte> Acquire(byte value)
		{
			return mappedByteWrappers[value];
		}

		public StructWrapper<bool> Acquire(bool value)
		{
			return mappedBoolWrappers[value ? 1 : 0];
		}

		public StructWrapper<T> Acquire<T>(T value)
		{
			StructWrapperPool<T> poolForType = GetPoolForType<T>();
			StructWrapper<T> structWrapper = poolForType.Acquire(value);
			used.Add(structWrapper);
			return structWrapper;
		}

		public void Clear()
		{
			foreach (IDisposable item in used)
			{
				item.Dispose();
			}
			used.Clear();
		}
	}
	public static class StructWrapperUtility
	{
		public static Type GetWrappedType(this object obj)
		{
			if (!(obj is StructWrapper { ttype: var ttype }))
			{
				return obj.GetType();
			}
			return ttype;
		}

		public static StructWrapper<T> Wrap<T>(this T value, bool persistant)
		{
			StructWrapper<T> structWrapper = StructWrapper<T>.staticPool.Acquire(value);
			if (persistant)
			{
				structWrapper.DisconnectFromPool();
			}
			return structWrapper;
		}

		public static StructWrapper<T> Wrap<T>(this T value)
		{
			return StructWrapper<T>.staticPool.Acquire(value);
		}

		public static StructWrapper<byte> Wrap(this byte value)
		{
			return StructWrapperPools.mappedByteWrappers[value];
		}

		public static StructWrapper<bool> Wrap(this bool value)
		{
			return StructWrapperPools.mappedBoolWrappers[value ? 1 : 0];
		}

		public static bool IsType<T>(this object obj)
		{
			if (obj is T)
			{
				return true;
			}
			if (obj is StructWrapper<T>)
			{
				return true;
			}
			return false;
		}

		public static T DisconnectPooling<T>(this T table) where T : IEnumerable<object>
		{
			foreach (object item in table)
			{
				if (item is StructWrapper structWrapper)
				{
					structWrapper.DisconnectFromPool();
				}
			}
			return table;
		}

		public static List<object> ReleaseAllWrappers(this List<object> collection)
		{
			foreach (object item in collection)
			{
				if (item is StructWrapper structWrapper)
				{
					structWrapper.Dispose();
				}
			}
			return collection;
		}

		public static object[] ReleaseAllWrappers(this object[] collection)
		{
			foreach (object obj in collection)
			{
				if (obj is StructWrapper structWrapper)
				{
					structWrapper.Dispose();
				}
			}
			return collection;
		}

		public static Hashtable ReleaseAllWrappers(this Hashtable table)
		{
			foreach (object value in table.Values)
			{
				if (value is StructWrapper structWrapper)
				{
					structWrapper.Dispose();
				}
			}
			return table;
		}

		public static void BoxAll(this Hashtable table, bool recursive = false)
		{
			foreach (object value in table.Values)
			{
				if (recursive && value is Hashtable table2)
				{
					table2.BoxAll();
				}
				if (value is StructWrapper structWrapper)
				{
					structWrapper.Box();
				}
			}
		}

		public static T Unwrap<T>(this object obj)
		{
			if (!(obj is StructWrapper<T> { value: var value } structWrapper))
			{
				return (T)obj;
			}
			if ((structWrapper.pooling & Pooling.ReleaseOnUnwrap) == Pooling.ReleaseOnUnwrap)
			{
				structWrapper.Dispose();
			}
			return structWrapper.value;
		}

		public static T Get<T>(this object obj)
		{
			if (!(obj is StructWrapper<T> { value: var value }))
			{
				return (T)obj;
			}
			return value;
		}

		public static T Unwrap<T>(this Hashtable table, object key)
		{
			object obj = table[key];
			return obj.Unwrap<T>();
		}

		public static bool TryUnwrapValue<T>(this Hashtable table, byte key, out T value) where T : new()
		{
			if (!table.TryGetValue(key, out var value2))
			{
				value = default(T);
				return false;
			}
			value = value2.Unwrap<T>();
			return true;
		}

		public static bool TryGetValue<T>(this Hashtable table, byte key, out T value) where T : new()
		{
			if (!table.TryGetValue(key, out var value2))
			{
				value = default(T);
				return false;
			}
			value = value2.Get<T>();
			return true;
		}

		public static bool TryGetValue<T>(this Hashtable table, object key, out T value) where T : new()
		{
			if (!table.TryGetValue(key, out var value2))
			{
				value = default(T);
				return false;
			}
			value = value2.Get<T>();
			return true;
		}

		public static bool TryUnwrapValue<T>(this Hashtable table, object key, out T value) where T : new()
		{
			if (!table.TryGetValue(key, out var value2))
			{
				value = default(T);
				return false;
			}
			value = value2.Unwrap<T>();
			return true;
		}

		public static T Unwrap<T>(this Hashtable table, byte key)
		{
			object obj = table[key];
			return obj.Unwrap<T>();
		}

		public static T Get<T>(this Hashtable table, byte key)
		{
			object obj = table[key];
			return obj.Get<T>();
		}
	}
}
namespace ExitGames.Client.Photon.Encryption
{
	public interface IPhotonEncryptor
	{
		void Init(byte[] encryptionSecret, byte[] hmacSecret, byte[] ivBytes = null, bool chainingModeGCM = false, int mtu = 1200);

		void Encrypt2(byte[] data, int len, byte[] header, byte[] output, int outOffset, ref int outSize);

		byte[] Decrypt2(byte[] data, int offset, int len, byte[] header, out int outLen);

		int CalculateEncryptedSize(int unencryptedSize);

		int CalculateFragmentLength();
	}
	public class EncryptorNet : IPhotonEncryptor
	{
		protected Aes encryptorIn;

		protected Aes encryptorOut;

		protected HMACSHA256 hmacsha256In;

		protected HMACSHA256 hmacsha256Out;

		public void Init(byte[] encryptionSecret, byte[] hmacSecret, byte[] ivBytes = null, bool chainingModeGCM = false, int mtu = 1200)
		{
			throw new NotImplementedException();
		}

		public void Encrypt2(byte[] data, int len, byte[] header, byte[] output, int outOffset, ref int outSize)
		{
			throw new NotImplementedException();
		}

		public byte[] Decrypt2(byte[] data, int offset, int len, byte[] header, out int outLen)
		{
			throw new NotImplementedException();
		}

		public int CalculateEncryptedSize(int unencryptedSize)
		{
			throw new NotImplementedException();
		}

		public int CalculateFragmentLength()
		{
			throw new NotImplementedException();
		}
	}
}
namespace Photon.SocketServer.Security
{
	internal class DiffieHellmanCryptoProvider : ICryptoProvider, IDisposable
	{
		private static readonly BigInteger primeRoot = new BigInteger(OakleyGroups.Generator);

		private readonly BigInteger prime;

		private readonly BigInteger secret;

		private readonly BigInteger publicKey;

		private Rijndael crypto;

		private byte[] sharedKey;

		public bool IsInitialized => crypto != null;

		public byte[] PublicKey
		{
			get
			{
				BigInteger bigInteger = publicKey;
				return MsBigIntArrayToPhotonBigIntArray(bigInteger.ToByteArray());
			}
		}

		public DiffieHellmanCryptoProvider()
		{
			prime = new BigInteger(OakleyGroups.OakleyPrime768);
			secret = GenerateRandomSecret(160);
			publicKey = CalculatePublicKey();
		}

		public DiffieHellmanCryptoProvider(byte[] cryptoKey)
		{
			crypto = new RijndaelManaged();
			crypto.Key = cryptoKey;
			crypto.IV = new byte[16];
			crypto.Padding = PaddingMode.PKCS7;
		}

		public void DeriveSharedKey(byte[] otherPartyPublicKey)
		{
			otherPartyPublicKey = PhotonBigIntArrayToMsBigIntArray(otherPartyPublicKey);
			BigInteger otherPartyPublicKey2 = new BigInteger(otherPartyPublicKey);
			sharedKey = MsBigIntArrayToPhotonBigIntArray(CalculateSharedKey(otherPartyPublicKey2).ToByteArray());
			byte[] key;
			using (SHA256 sHA = new SHA256Managed())
			{
				key = sHA.ComputeHash(sharedKey);
			}
			crypto = new RijndaelManaged();
			crypto.Key = key;
			crypto.IV = new byte[16];
			crypto.Padding = PaddingMode.PKCS7;
		}

		private byte[] PhotonBigIntArrayToMsBigIntArray(byte[] array)
		{
			Array.Reverse((Array)array);
			if ((array[^1] & 0x80) == 128)
			{
				byte[] array2 = new byte[array.Length + 1];
				Buffer.BlockCopy(array, 0, array2, 0, array.Length);
				return array2;
			}
			return array;
		}

		private byte[] MsBigIntArrayToPhotonBigIntArray(byte[] array)
		{
			Array.Reverse((Array)array);
			if (array[0] == 0)
			{
				byte[] array2 = new byte[array.Length - 1];
				Buffer.BlockCopy(array, 1, array2, 0, array.Length - 1);
				return array2;
			}
			return array;
		}

		public byte[] Encrypt(byte[] data)
		{
			return Encrypt(data, 0, data.Length);
		}

		public byte[] Encrypt(byte[] data, int offset, int count)
		{
			using ICryptoTransform cryptoTransform = crypto.CreateEncryptor();
			return cryptoTransform.TransformFinalBlock(data, offset, count);
		}

		public byte[] Decrypt(byte[] data)
		{
			return Decrypt(data, 0, data.Length);
		}

		public byte[] Decrypt(byte[] data, int offset, int count)
		{
			using ICryptoTransform cryptoTransform = crypto.CreateDecryptor();
			return cryptoTransform.TransformFinalBlock(data, offset, count);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected void Dispose(bool disposing)
		{
			if (disposing)
			{
			}
		}

		private BigInteger CalculatePublicKey()
		{
			return BigInteger.ModPow(primeRoot, secret, prime);
		}

		private BigInteger CalculateSharedKey(BigInteger otherPartyPublicKey)
		{
			return BigInteger.ModPow(otherPartyPublicKey, secret, prime);
		}

		private BigInteger GenerateRandomSecret(int secretLength)
		{
			RNGCryptoServiceProvider rNGCryptoServiceProvider = new RNGCryptoServiceProvider();
			byte[] array = new byte[secretLength / 8];
			BigInteger bigInteger;
			do
			{
				rNGCryptoServiceProvider.GetBytes(array);
				bigInteger = new BigInteger(array);
			}
			while (bigInteger >= prime - 1 || bigInteger < 2L);
			return bigInteger;
		}
	}
	internal interface ICryptoProvider : IDisposable
	{
		bool IsInitialized { get; }

		byte[] PublicKey { get; }

		void DeriveSharedKey(byte[] otherPartyPublicKey);

		byte[] Encrypt(byte[] data);

		byte[] Encrypt(byte[] data, int offset, int count);

		byte[] Decrypt(byte[] data);

		byte[] Decrypt(byte[] data, int offset, int count);
	}
	internal static class OakleyGroups
	{
		public static readonly int Generator = 22;

		public static readonly byte[] OakleyPrime768 = new byte[97]
		{
			255, 255, 255, 255, 255, 255, 255, 255, 32, 54,
			58, 166, 233, 66, 76, 244, 198, 126, 94, 98,
			118, 181, 133, 228, 69, 194, 81, 109, 109, 53,
			225, 79, 55, 20, 95, 242, 109, 10, 43, 48,
			27, 67, 58, 205, 179, 25, 149, 239, 221, 4,
			52, 142, 121, 8, 74, 81, 34, 155, 19, 59,
			166, 190, 11, 2, 116, 204, 103, 138, 8, 78,
			2, 41, 209, 28, 220, 128, 139, 98, 198, 196,
			52, 194, 104, 33, 162, 218, 15, 201, 255, 255,
			255, 255, 255, 255, 255, 255, 0
		};

		public static readonly byte[] OakleyPrime1024 = new byte[128]
		{
			255, 255, 255, 255, 255, 255, 255, 255, 201, 15,
			218, 162, 33, 104, 194, 52, 196, 198, 98, 139,
			128, 220, 28, 209, 41, 2, 78, 8, 138, 103,
			204, 116, 2, 11, 190, 166, 59, 19, 155, 34,
			81, 74, 8, 121, 142, 52, 4, 221, 239, 149,
			25, 179, 205, 58, 67, 27, 48, 43, 10, 109,
			242, 95, 20, 55, 79, 225, 53, 109, 109, 81,
			194, 69, 228, 133, 181, 118, 98, 94, 126, 198,
			244, 76, 66, 233, 166, 55, 237, 107, 11, 255,
			92, 182, 244, 6, 183, 237, 238, 56, 107, 251,
			90, 137, 159, 165, 174, 159, 36, 17, 124, 75,
			31, 230, 73, 40, 102, 81, 236, 230, 83, 129,
			255, 255, 255, 255, 255, 255, 255, 255
		};

		public static readonly byte[] OakleyPrime1536 = new byte[192]
		{
			255, 255, 255, 255, 255, 255, 255, 255, 201, 15,
			218, 162, 33, 104, 194, 52, 196, 198, 98, 139,
			128, 220, 28, 209, 41, 2, 78, 8, 138, 103,
			204, 116, 2, 11, 190, 166, 59, 19, 155, 34,
			81, 74, 8, 121, 142, 52, 4, 221, 239, 149,
			25, 179, 205, 58, 67, 27, 48, 43, 10, 109,
			242, 95, 20, 55, 79, 225, 53, 109, 109, 81,
			194, 69, 228, 133, 181, 118, 98, 94, 126, 198,
			244, 76, 66, 233, 166, 55, 237, 107, 11, 255,
			92, 182, 244, 6, 183, 237, 238, 56, 107, 251,
			90, 137, 159, 165, 174, 159, 36, 17, 124, 75,
			31, 230, 73, 40, 102, 81, 236, 228, 91, 61,
			194, 0, 124, 184, 161, 99, 191, 5, 152, 218,
			72, 54, 28, 85, 211, 154, 105, 22, 63, 168,
			253, 36, 207, 95, 131, 101, 93, 35, 220, 163,
			173, 150, 28, 98, 243, 86, 32, 133, 82, 187,
			158, 213, 41, 7, 112, 150, 150, 109, 103, 12,
			53, 78, 74, 188, 152, 4, 241, 116, 108, 8,
			202, 35, 115, 39, 255, 255, 255, 255, 255, 255,
			255, 255
		};
	}
}
namespace Photon.SocketServer.Numeric
{
	internal class BigInteger
	{
		private const int maxLength = 70;

		public static readonly int[] primesBelow2000 = new int[303]
		{
			2, 3, 5, 7, 11, 13, 17, 19, 23, 29,
			31, 37, 41, 43, 47, 53, 59, 61, 67, 71,
			73, 79, 83, 89, 97, 101, 103, 107, 109, 113,
			127, 131, 137, 139, 149, 151, 157, 163, 167, 173,
			179, 181, 191, 193, 197, 199, 211, 223, 227, 229,
			233, 239, 241, 251, 257, 263, 269, 271, 277, 281,
			283, 293, 307, 311, 313, 317, 331, 337, 347, 349,
			353, 359, 367, 373, 379, 383, 389, 397, 401, 409,
			419, 421, 431, 433, 439, 443, 449, 457, 461, 463,
			467, 479, 487, 491, 499, 503, 509, 521, 523, 541,
			547, 557, 563, 569, 571, 577, 587, 593, 599, 601,
			607, 613, 617, 619, 631, 641, 643, 647, 653, 659,
			661, 673, 677, 683, 691, 701, 709, 719, 727, 733,
			739, 743, 751, 757, 761, 769, 773, 787, 797, 809,
			811, 821, 823, 827, 829, 839, 853, 857, 859, 863,
			877, 881, 883, 887, 907, 911, 919, 929, 937, 941,
			947, 953, 967, 971, 977, 983, 991, 997, 1009, 1013,
			1019, 1021, 1031, 1033, 1039, 1049, 1051, 1061, 1063, 1069,
			1087, 1091, 1093, 1097, 1103, 1109, 1117, 1123, 1129, 1151,
			1153, 1163, 1171, 1181, 1187, 1193, 1201, 1213, 1217, 1223,
			1229, 1231, 1237, 1249, 1259, 1277, 1279, 1283, 1289, 1291,
			1297, 1301, 1303, 1307, 1319, 1321, 1327, 1361, 1367, 1373,
			1381, 1399, 1409, 1423, 1427, 1429, 1433, 1439, 1447, 1451,
			1453, 1459, 1471, 1481, 1483, 1487, 1489, 1493, 1499, 1511,
			1523, 1531, 1543, 1549, 1553, 1559, 1567, 1571, 1579, 1583,
			1597, 1601, 1607, 1609, 1613, 1619, 1621, 1627, 1637, 1657,
			1663, 1667, 1669, 1693, 1697, 1699, 1709, 1721, 1723, 1733,
			1741, 1747, 1753, 1759, 1777, 1783, 1787, 1789, 1801, 1811,
			1823, 1831, 1847, 1861, 1867, 1871, 1873, 1877, 1879, 1889,
			1901, 1907, 1913, 1931, 1933, 1949, 1951, 1973, 1979, 1987,
			1993, 1997, 1999
		};

		private uint[] data = null;

		public int dataLength;

		public BigInteger()
		{
			data = new uint[70];
			dataLength = 1;
		}

		public BigInteger(long value)
		{
			data = new uint[70];
			long num = value;
			dataLength = 0;
			while (value != 0L && dataLength < 70)
			{
				data[dataLength] = (uint)(value & 0xFFFFFFFFu);
				value >>= 32;
				dataLength++;
			}
			if (num > 0)
			{
				if (value != 0L || (data[69] & 0x80000000u) != 0)
				{
					throw new ArithmeticException("Positive overflow in constructor.");
				}
			}
			else if (num < 0 && (value != -1 || (data[dataLength - 1] & 0x80000000u) == 0))
			{
				throw new ArithmeticException("Negative underflow in constructor.");
			}
			if (dataLength == 0)
			{
				dataLength = 1;
			}
		}

		public BigInteger(ulong value)
		{
			data = new uint[70];
			dataLength = 0;
			while (value != 0L && dataLength < 70)
			{
				data[dataLength] = (uint)(value & 0xFFFFFFFFu);
				value >>= 32;
				dataLength++;
			}
			if (value != 0L || (data[69] & 0x80000000u) != 0)
			{
				throw new ArithmeticException("Positive overflow in constructor.");
			}
			if (dataLength == 0)
			{
				dataLength = 1;
			}
		}

		public BigInteger(BigInteger bi)
		{
			data = new uint[70];
			dataLength = bi.dataLength;
			for (int i = 0; i < dataLength; i++)
			{
				data[i] = bi.data[i];
			}
		}

		public BigInteger(string value, int radix)
		{
			BigInteger bigInteger = new BigInteger(1L);
			BigInteger bigInteger2 = new BigInteger();
			value = value.ToUpper().Trim();
			int num = 0;
			if (value[0] == '-')
			{
				num = 1;
			}
			for (int num2 = value.Length - 1; num2 >= num; num2--)
			{
				int num3 = value[num2];
				num3 = ((num3 >= 48 && num3 <= 57) ? (num3 - 48) : ((num3 < 65 || num3 > 90) ? 9999999 : (num3 - 65 + 10)));
				if (num3 >= radix)
				{
					throw new ArithmeticException("Invalid string in constructor.");
				}
				if (value[0] == '-')
				{
					num3 = -num3;
				}
				bigInteger2 += bigInteger * num3;
				if (num2 - 1 >= num)
				{
					bigInteger *= (BigInteger)radix;
				}
			}
			if (value[0] == '-')
			{
				if ((bigInteger2.data[69] & 0x80000000u) == 0)
				{
					throw new ArithmeticException("Negative underflow in constructor.");
				}
			}
			else if ((bigInteger2.data[69] & 0x80000000u) != 0)
			{
				throw new ArithmeticException("Positive overflow in constructor.");
			}
			data = new uint[70];
			for (int i = 0; i < bigInteger2.dataLength; i++)
			{
				data[i] = bigInteger2.data[i];
			}
			dataLength = bigInteger2.dataLength;
		}

		public BigInteger(byte[] inData)
		{
			dataLength = inData.Length >> 2;
			int num = inData.Length & 3;
			if (num != 0)
			{
				dataLength++;
			}
			if (dataLength > 70)
			{
				throw new ArithmeticException("Byte overflow in constructor.");
			}
			data = new uint[70];
			int num2 = inData.Length - 1;
			int num3 = 0;
			while (num2 >= 3)
			{
				data[num3] = (uint)((inData[num2 - 3] << 24) + (inData[num2 - 2] << 16) + (inData[num2 - 1] << 8) + inData[num2]);
				num2 -= 4;
				num3++;
			}
			switch (num)
			{
			case 1:
				data[dataLength - 1] = inData[0];
				break;
			case 2:
				data[dataLength - 1] = (uint)((inData[0] << 8) + inData[1]);
				break;
			case 3:
				data[dataLength - 1] = (uint)((inData[0] << 16) + (inData[1] << 8) + inData[2]);
				break;
			}
			while (dataLength > 1 && data[dataLength - 1] == 0)
			{
				dataLength--;
			}
		}

		public BigInteger(byte[] inData, int inLen)
		{
			dataLength = inLen >> 2;
			int num = inLen & 3;
			if (num != 0)
			{
				dataLength++;
			}
			if (dataLength > 70 || inLen > inData.Length)
			{
				throw new ArithmeticException("Byte overflow in constructor.");
			}
			data = new uint[70];
			int num2 = inLen - 1;
			int num3 = 0;
			while (num2 >= 3)
			{
				data[num3] = (uint)((inData[num2 - 3] << 24) + (inData[num2 - 2] << 16) + (inData[num2 - 1] << 8) + inData[num2]);
				num2 -= 4;
				num3++;
			}
			switch (num)
			{
			case 1:
				data[dataLength - 1] = inData[0];
				break;
			case 2:
				data[dataLength - 1] = (uint)((inData[0] << 8) + inData[1]);
				break;
			case 3:
				data[dataLength - 1] = (uint)((inData[0] << 16) + (inData[1] << 8) + inData[2]);
				break;
			}
			if (dataLength == 0)
			{
				dataLength = 1;
			}
			while (dataLength > 1 && data[dataLength - 1] == 0)
			{
				dataLength--;
			}
		}

		public BigInteger(uint[] inData)
		{
			dataLength = inData.Length;
			if (dataLength > 70)
			{
				throw new ArithmeticException("Byte overflow in constructor.");
			}
			data = new uint[70];
			int num = dataLength - 1;
			int num2 = 0;
			while (num >= 0)
			{
				data[num2] = inData[num];
				num--;
				num2++;
			}
			while (dataLength > 1 && data[dataLength - 1] == 0)
			{
				dataLength--;
			}
		}

		public static implicit operator BigInteger(long value)
		{
			return new BigInteger(value);
		}

		public static implicit operator BigInteger(ulong value)
		{
			return new BigInteger(value);
		}

		public static implicit operator BigInteger(int value)
		{
			return new BigInteger(value);
		}

		public static implicit operator BigInteger(uint value)
		{
			return new BigInteger((ulong)value);
		}

		public static BigInteger operator +(BigInteger bi1, BigInteger bi2)
		{
			BigInteger bigInteger = new BigInteger();
			bigInteger.dataLength = ((bi1.dataLength > bi2.dataLength) ? bi1.dataLength : bi2.dataLength);
			long num = 0L;
			for (int i = 0; i < bigInteger.dataLength; i++)
			{
				long num2 = (long)bi1.data[i] + (long)bi2.data[i] + num;
				num = num2 >> 32;
				bigInteger.data[i] = (uint)(num2 & 0xFFFFFFFFu);
			}
			if (num != 0L && bigInteger.dataLength < 70)
			{
				bigInteger.data[bigInteger.dataLength] = (uint)num;
				bigInteger.dataLength++;
			}
			while (bigInteger.dataLength > 1 && bigInteger.data[bigInteger.dataLength - 1] == 0)
			{
				bigInteger.dataLength--;
			}
			int num3 = 69;
			if ((bi1.data[num3] & 0x80000000u) == (bi2.data[num3] & 0x80000000u) && (bigInteger.data[num3] & 0x80000000u) != (bi1.data[num3] & 0x80000000u))
			{
				throw new ArithmeticException();
			}
			return bigInteger;
		}

		public static BigInteger operator ++(BigInteger bi1)
		{
			BigInteger bigInteger = new BigInteger(bi1);
			long num = 1L;
			int num2 = 0;
			while (num != 0L && num2 < 70)
			{
				long num3 = bigInteger.data[num2];
				num3++;
				bigInteger.data[num2] = (uint)(num3 & 0xFFFFFFFFu);
				num = num3 >> 32;
				num2++;
			}
			if (num2 > bigInteger.dataLength)
			{
				bigInteger.dataLength = num2;
			}
			else
			{
				while (bigInteger.dataLength > 1 && bigInteger.data[bigInteger.dataLength - 1] == 0)
				{
					bigInteger.dataLength--;
				}
			}
			int num4 = 69;
			if ((bi1.data[num4] & 0x80000000u) == 0 && (bigInteger.data[num4] & 0x80000000u) != (bi1.data[num4] & 0x80000000u))
			{
				throw new ArithmeticException("Overflow in ++.");
			}
			return bigInteger;
		}

		public static BigInteger operator -(BigInteger bi1, BigInteger bi2)
		{
			BigInteger bigInteger = new BigInteger();
			bigInteger.dataLength = ((bi1.dataLength > bi2.dataLength) ? bi1.dataLength : bi2.dataLength);
			long num = 0L;
			for (int i = 0; i < bigInteger.dataLength; i++)
			{
				long num2 = (long)bi1.data[i] - (long)bi2.data[i] - num;
				bigInteger.data[i] = (uint)(num2 & 0xFFFFFFFFu);
				num = ((num2 >= 0) ? 0 : 1);
			}
			if (num != 0)
			{
				for (int j = bigInteger.dataLength; j < 70; j++)
				{
					bigInteger.data[j] = uint.MaxValue;
				}
				bigInteger.dataLength = 70;
			}
			while (bigInteger.dataLength > 1 && bigInteger.data[bigInteger.dataLength - 1] == 0)
			{
				bigInteger.dataLength--;
			}
			int num3 = 69;
			if ((bi1.data[num3] & 0x80000000u) != (bi2.data[num3] & 0x80000000u) && (bigInteger.data[num3] & 0x80000000u) != (bi1.data[num3] & 0x80000000u))
			{
				throw new ArithmeticException();
			}
			return bigInteger;
		}

		public static BigInteger operator --(BigInteger bi1)
		{
			BigInteger bigInteger = new BigInteger(bi1);
			bool flag = true;
			int num = 0;
			while (flag && num < 70)
			{
				long num2 = bigInteger.data[num];
				num2--;
				bigInteger.data[num] = (uint)(num2 & 0xFFFFFFFFu);
				if (num2 >= 0)
				{
					flag = false;
				}
				num++;
			}
			if (num > bigInteger.dataLength)
			{
				bigInteger.dataLength = num;
			}
			while (bigInteger.dataLength > 1 && bigInteger.data[bigInteger.dataLength - 1] == 0)
			{
				bigInteger.dataLength--;
			}
			int num3 = 69;
			if ((bi1.data[num3] & 0x80000000u) != 0 && (bigInteger.data[num3] & 0x80000000u) != (bi1.data[num3] & 0x80000000u))
			{
				throw new ArithmeticException("Underflow in --.");
			}
			return bigInteger;
		}

		public static BigInteger operator *(BigInteger bi1, BigInteger bi2)
		{
			int num = 69;
			bool flag = false;
			bool flag2 = false;
			try
			{
				if ((bi1.data[num] & 0x80000000u) != 0)
				{
					flag = true;
					bi1 = -bi1;
				}
				if ((bi2.data[num] & 0x80000000u) != 0)
				{
					flag2 = true;
					bi2 = -bi2;
				}
			}
			catch (Exception)
			{
			}
			BigInteger bigInteger = new BigInteger();
			try
			{
				for (int i = 0; i < bi1.dataLength; i++)
				{
					if (bi1.data[i] != 0)
					{
						ulong num2 = 0uL;
						int num3 = 0;
						int num4 = i;
						while (num3 < bi2.dataLength)
						{
							ulong num5 = (ulong)((long)bi1.data[i] * (long)bi2.data[num3] + bigInteger.data[num4]) + num2;
							bigInteger.data[num4] = (uint)(num5 & 0xFFFFFFFFu);
							num2 = num5 >> 32;
							num3++;
							num4++;
						}
						if (num2 != 0)
						{
							bigInteger.data[i + bi2.dataLength] = (uint)num2;
						}
					}
				}
			}
			catch (Exception)
			{
				throw new ArithmeticException("Multiplication overflow.");
			}
			bigInteger.dataLength = bi1.dataLength + bi2.dataLength;
			if (bigInteger.dataLength > 70)
			{
				bigInteger.dataLength = 70;
			}
			while (bigInteger.dataLength > 1 && bigInteger.data[bigInteger.dataLength - 1] == 0)
			{
				bigInteger.dataLength--;
			}
			if ((bigInteger.data[num] & 0x80000000u) != 0)
			{
				if (flag != flag2 && bigInteger.data[num] == 2147483648u)
				{
					if (bigInteger.dataLength == 1)
					{
						return bigInteger;
					}
					bool flag3 = true;
					for (int j = 0; j < bigInteger.dataLength - 1 && flag3; j++)
					{
						if (bigInteger.data[j] != 0)
						{
							flag3 = false;
						}
					}
					if (flag3)
					{
						return bigInteger;
					}
				}
				throw new ArithmeticException("Multiplication overflow.");
			}
			if (flag != flag2)
			{
				return -bigInteger;
			}
			return bigInteger;
		}

		public static BigInteger operator <<(BigInteger bi1, int shiftVal)
		{
			BigInteger bigInteger = new BigInteger(bi1);
			bigInteger.dataLength = shiftLeft(bigInteger.data, shiftVal);
			return bigInteger;
		}

		private static int shiftLeft(uint[] buffer, int shiftVal)
		{
			int num = 32;
			int num2 = buffer.Length;
			while (num2 > 1 && buffer[num2 - 1] == 0)
			{
				num2--;
			}
			for (int num3 = shiftVal; num3 > 0; num3 -= num)
			{
				if (num3 < num)
				{
					num = num3;
				}
				ulong num4 = 0uL;
				for (int i = 0; i < num2; i++)
				{
					ulong num5 = (ulong)buffer[i] << num;
					num5 |= num4;
					buffer[i] = (uint)(num5 & 0xFFFFFFFFu);
					num4 = num5 >> 32;
				}
				if (num4 != 0 && num2 + 1 <= buffer.Length)
				{
					buffer[num2] = (uint)num4;
					num2++;
				}
			}
			return num2;
		}

		public static BigInteger operator >>(BigInteger bi1, int shiftVal)
		{
			BigInteger bigInteger = new BigInteger(bi1);
			bigInteger.dataLength = shiftRight(bigInteger.data, shiftVal);
			if ((bi1.data[69] & 0x80000000u) != 0)
			{
				for (int num = 69; num >= bigInteger.dataLength; num--)
				{
					bigInteger.data[num] = uint.MaxValue;
				}
				uint num2 = 2147483648u;
				for (int i = 0; i < 32; i++)
				{
					if ((bigInteger.data[bigInteger.dataLength - 1] & num2) != 0)
					{
						break;
					}
					bigInteger.data[bigInteger.dataLength - 1] |= num2;
					num2 >>= 1;
				}
				bigInteger.dataLength = 70;
			}
			return bigInteger;
		}

		private static int shiftRight(uint[] buffer, int shiftVal)
		{
			int num = 32;
			int num2 = 0;
			int num3 = buffer.Length;
			while (num3 > 1 && buffer[num3 - 1] == 0)
			{
				num3--;
			}
			for (int num4 = shiftVal; num4 > 0; num4 -= num)
			{
				if (num4 < num)
				{
					num = num4;
					num2 = 32 - num;
				}
				ulong num5 = 0uL;
				for (int num6 = num3 - 1; num6 >= 0; num6--)
				{
					ulong num7 = (ulong)buffer[num6] >> num;
					num7 |= num5;
					num5 = (ulong)buffer[num6] << num2;
					buffer[num6] = (uint)num7;
				}
			}
			while (num3 > 1 && buffer[num3 - 1] == 0)
			{
				num3--;
			}
			return num3;
		}

		public static BigInteger operator ~(BigInteger bi1)
		{
			BigInteger bigInteger = new BigInteger(bi1);
			for (int i = 0; i < 70; i++)
			{
				bigInteger.data[i] = ~bi1.data[i];
			}
			bigInteger.dataLength = 70;
			while (bigInteger.dataLength > 1 && bigInteger.data[bigInteger.dataLength - 1] == 0)
			{
				bigInteger.dataLength--;
			}
			return bigInteger;
		}

		public static BigInteger operator -(BigInteger bi1)
		{
			if (bi1.dataLength == 1 && bi1.data[0] == 0)
			{
				return new BigInteger();
			}
			BigInteger bigInteger = new BigInteger(bi1);
			for (int i = 0; i < 70; i++)
			{
				bigInteger.data[i] = ~bi1.data[i];
			}
			long num = 1L;
			int num2 = 0;
			while (num != 0L && num2 < 70)
			{
				long num3 = bigInteger.data[num2];
				num3++;
				bigInteger.data[num2] = (uint)(num3 & 0xFFFFFFFFu);
				num = num3 >> 32;
				num2++;
			}
			if ((bi1.data[69] & 0x80000000u) == (bigInteger.data[69] & 0x80000000u))
			{
				throw new ArithmeticException("Overflow in negation.\n");
			}
			bigInteger.dataLength = 70;
			while (bigInteger.dataLength > 1 && bigInteger.data[bigInteger.dataLength - 1] == 0)
			{
				bigInteger.dataLength--;
			}
			return bigInteger;
		}

		public static bool operator ==(BigInteger bi1, BigInteger bi2)
		{
			return bi1.Equals(bi2);
		}

		public static bool operator !=(BigInteger bi1, BigInteger bi2)
		{
			return !bi1.Equals(bi2);
		}

		public override bool Equals(object o)
		{
			BigInteger bigInteger = (BigInteger)o;
			if (dataLength != bigInteger.dataLength)
			{
				return false;
			}
			for (int i = 0; i < dataLength; i++)
			{
				if (data[i] != bigInteger.data[i])
				{
					return false;
				}
			}
			return true;
		}

		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		public static bool operator >(BigInteger bi1, BigInteger bi2)
		{
			int num = 69;
			if ((bi1.data[num] & 0x80000000u) != 0 && (bi2.data[num] & 0x80000000u) == 0)
			{
				return false;
			}
			if ((bi1.data[num] & 0x80000000u) == 0 && (bi2.data[num] & 0x80000000u) != 0)
			{
				return true;
			}
			int num2 = ((bi1.dataLength > bi2.dataLength) ? bi1.dataLength : bi2.dataLength);
			num = num2 - 1;
			while (num >= 0 && bi1.data[num] == bi2.data[num])
			{
				num--;
			}
			if (num >= 0)
			{
				if (bi1.data[num] > bi2.data[num])
				{
					return true;
				}
				return false;
			}
			return false;
		}

		public static bool operator <(BigInteger bi1, BigInteger bi2)
		{
			int num = 69;
			if ((bi1.data[num] & 0x80000000u) != 0 && (bi2.data[num] & 0x80000000u) == 0)
			{
				return true;
			}
			if ((bi1.data[num] & 0x80000000u) == 0 && (bi2.data[num] & 0x80000000u) != 0)
			{
				return false;
			}
			int num2 = ((bi1.dataLength > bi2.dataLength) ? bi1.dataLength : bi2.dataLength);
			num = num2 - 1;
			while (num >= 0 && bi1.data[num] == bi2.data[num])
			{
				num--;
			}
			if (num >= 0)
			{
				if (bi1.data[num] < bi2.data[num])
				{
					return true;
				}
				return false;
			}
			return false;
		}

		public static bool operator >=(BigInteger bi1, BigInteger bi2)
		{
			return bi1 == bi2 || bi1 > bi2;
		}

		public static bool operator <=(BigInteger bi1, BigInteger bi2)
		{
			return bi1 == bi2 || bi1 < bi2;
		}

		private static void multiByteDivide(BigInteger bi1, BigInteger bi2, BigInteger outQuotient, BigInteger outRemainder)
		{
			uint[] array = new uint[70];
			int num = bi1.dataLength + 1;
			uint[] array2 = new uint[num];
			uint num2 = 2147483648u;
			uint num3 = bi2.data[bi2.dataLength - 1];
			int num4 = 0;
			int num5 = 0;
			while (num2 != 0 && (num3 & num2) == 0)
			{
				num4++;
				num2 >>= 1;
			}
			for (int i = 0; i < bi1.dataLength; i++)
			{
				array2[i] = bi1.data[i];
			}
			shiftLeft(array2, num4);
			bi2 <<= num4;
			int num6 = num - bi2.dataLength;
			int num7 = num - 1;
			ulong num8 = bi2.data[bi2.dataLength - 1];
			ulong num9 = bi2.data[bi2.dataLength - 2];
			int num10 = bi2.dataLength + 1;
			uint[] array3 = new uint[num10];
			while (num6 > 0)
			{
				ulong num11 = ((ulong)array2[num7] << 32) + array2[num7 - 1];
				ulong num12 = num11 / num8;
				ulong num13 = num11 % num8;
				bool flag = false;
				while (!flag)
				{
					flag = true;
					if (num12 == 4294967296L || num12 * num9 > (num13 << 32) + array2[num7 - 2])
					{
						num12--;
						num13 += num8;
						if (num13 < 4294967296L)
						{
							flag = false;
						}
					}
				}
				for (int j = 0; j < num10; j++)
				{
					array3[j] = array2[num7 - j];
				}
				BigInteger bigInteger = new BigInteger(array3);
				BigInteger bigInteger2;
				for (bigInteger2 = bi2 * (long)num12; bigInteger2 > bigInteger; bigInteger2 -= bi2)
				{
					num12--;
				}
				BigInteger bigInteger3 = bigInteger - bigInteger2;
				for (int k = 0; k < num10; k++)
				{
					array2[num7 - k] = bigInteger3.data[bi2.dataLength - k];
				}
				array[num5++] = (uint)num12;
				num7--;
				num6--;
			}
			outQuotient.dataLength = num5;
			int l = 0;
			int num14 = outQuotient.dataLength - 1;
			while (num14 >= 0)
			{
				outQuotient.data[l] = array[num14];
				num14--;
				l++;
			}
			for (; l < 70; l++)
			{
				outQuotient.data[l] = 0u;
			}
			while (outQuotient.dataLength > 1 && outQuotient.data[outQuotient.dataLength - 1] == 0)
			{
				outQuotient.dataLength--;
			}
			if (outQuotient.dataLength == 0)
			{
				outQuotient.dataLength = 1;
			}
			outRemainder.dataLength = shiftRight(array2, num4);
			for (l = 0; l < outRemainder.dataLength; l++)
			{
				outRemainder.data[l] = array2[l];
			}
			for (; l < 70; l++)
			{
				outRemainder.data[l] = 0u;
			}
		}

		private static void singleByteDivide(BigInteger bi1, BigInteger bi2, BigInteger outQuotient, BigInteger outRemainder)
		{
			uint[] array = new uint[70];
			int num = 0;
			for (int i = 0; i < 70; i++)
			{
				outRemainder.data[i] = bi1.data[i];
			}
			outRemainder.dataLength = bi1.dataLength;
			while (outRemainder.dataLength > 1 && outRemainder.data[outRemainder.dataLength - 1] == 0)
			{
				outRemainder.dataLength--;
			}
			ulong num2 = bi2.data[0];
			int num3 = outRemainder.dataLength - 1;
			ulong num4 = outRemainder.data[num3];
			if (num4 >= num2)
			{
				ulong num5 = num4 / num2;
				array[num++] = (uint)num5;
				outRemainder.data[num3] = (uint)(num4 % num2);
			}
			num3--;
			while (num3 >= 0)
			{
				num4 = ((ulong)outRemainder.data[num3 + 1] << 32) + outRemainder.data[num3];
				ulong num6 = num4 / num2;
				array[num++] = (uint)num6;
				outRemainder.data[num3 + 1] = 0u;
				outRemainder.data[num3--] = (uint)(num4 % num2);
			}
			outQuotient.dataLength = num;
			int j = 0;
			int num7 = outQuotient.dataLength - 1;
			while (num7 >= 0)
			{
				outQuotient.data[j] = array[num7];
				num7--;
				j++;
			}
			for (; j < 70; j++)
			{
				outQuotient.data[j] = 0u;
			}
			while (outQuotient.dataLength > 1 && outQuotient.data[outQuotient.dataLength - 1] == 0)
			{
				outQuotient.dataLength--;
			}
			if (outQuotient.dataLength == 0)
			{
				outQuotient.dataLength = 1;
			}
			while (outRemainder.dataLength > 1 && outRemainder.data[outRemainder.dataLength - 1] == 0)
			{
				outRemainder.dataLength--;
			}
		}

		public static BigInteger operator /(BigInteger bi1, BigInteger bi2)
		{
			BigInteger bigInteger = new BigInteger();
			BigInteger outRemainder = new BigInteger();
			int num = 69;
			bool flag = false;
			bool flag2 = false;
			if ((bi1.data[num] & 0x80000000u) != 0)
			{
				bi1 = -bi1;
				flag2 = true;
			}
			if ((bi2.data[num] & 0x80000000u) != 0)
			{
				bi2 = -bi2;
				flag = true;
			}
			if (bi1 < bi2)
			{
				return bigInteger;
			}
			if (bi2.dataLength == 1)
			{
				singleByteDivide(bi1, bi2, bigInteger, outRemainder);
			}
			else
			{
				multiByteDivide(bi1, bi2, bigInteger, outRemainder);
			}
			if (flag2 != flag)
			{
				return -bigInteger;
			}
			return bigInteger;
		}

		public static BigInteger operator %(BigInteger bi1, BigInteger bi2)
		{
			BigInteger outQuotient = new BigInteger();
			BigInteger bigInteger = new BigInteger(bi1);
			int num = 69;
			bool flag = false;
			if ((bi1.data[num] & 0x80000000u) != 0)
			{
				bi1 = -bi1;
				flag = true;
			}
			if ((bi2.data[num] & 0x80000000u) != 0)
			{
				bi2 = -bi2;
			}
			if (bi1 < bi2)
			{
				return bigInteger;
			}
			if (bi2.dataLength == 1)
			{
				singleByteDivide(bi1, bi2, outQuotient, bigInteger);
			}
			else
			{
				multiByteDivide(bi1, bi2, outQuotient, bigInteger);
			}
			if (flag)
			{
				return -bigInteger;
			}
			return bigInteger;
		}

		public static BigInteger operator &(BigInteger bi1, BigInteger bi2)
		{
			BigInteger bigInteger = new BigInteger();
			int num = ((bi1.dataLength > bi2.dataLength) ? bi1.dataLength : bi2.dataLength);
			for (int i = 0; i < num; i++)
			{
				uint num2 = bi1.data[i] & bi2.data[i];
				bigInteger.data[i] = num2;
			}
			bigInteger.dataLength = 70;
			while (bigInteger.dataLength > 1 && bigInteger.data[bigInteger.dataLength - 1] == 0)
			{
				bigInteger.dataLength--;
			}
			return bigInteger;
		}

		public static BigInteger operator |(BigInteger bi1, BigInteger bi2)
		{
			BigInteger bigInteger = new BigInteger();
			int num = ((bi1.dataLength > bi2.dataLength) ? bi1.dataLength : bi2.dataLength);
			for (int i = 0; i < num; i++)
			{
				uint num2 = bi1.data[i] | bi2.data[i];
				bigInteger.data[i] = num2;
			}
			bigInteger.dataLength = 70;
			while (bigInteger.dataLength > 1 && bigInteger.data[bigInteger.dataLength - 1] == 0)
			{
				bigInteger.dataLength--;
			}
			return bigInteger;
		}

		public static BigInteger operator ^(BigInteger bi1, BigInteger bi2)
		{
			BigInteger bigInteger = new BigInteger();
			int num = ((bi1.dataLength > bi2.dataLength) ? bi1.dataLength : bi2.dataLength);
			for (int i = 0; i < num; i++)
			{
				uint num2 = bi1.data[i] ^ bi2.data[i];
				bigInteger.data[i] = num2;
			}
			bigInteger.dataLength = 70;
			while (bigInteger.dataLength > 1 && bigInteger.data[bigInteger.dataLength - 1] == 0)
			{
				bigInteger.dataLength--;
			}
			return bigInteger;
		}

		public BigInteger max(BigInteger bi)
		{
			if (this > bi)
			{
				return new BigInteger(this);
			}
			return new BigInteger(bi);
		}

		public BigInteger min(BigInteger bi)
		{
			if (this < bi)
			{
				return new BigInteger(this);
			}
			return new BigInteger(bi);
		}

		public BigInteger abs()
		{
			if ((data[69] & 0x80000000u) != 0)
			{
				return -this;
			}
			return new BigInteger(this);
		}

		public override string ToString()
		{
			return ToString(10);
		}

		public string ToString(int radix)
		{
			if (radix < 2 || radix > 36)
			{
				throw new ArgumentException("Radix must be >= 2 and <= 36");
			}
			string text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			string text2 = "";
			BigInteger bigInteger = this;
			bool flag = false;
			if ((bigInteger.data[69] & 0x80000000u) != 0)
			{
				flag = true;
				try
				{
					bigInteger = -bigInteger;
				}
				catch (Exception)
				{
				}
			}
			BigInteger bigInteger2 = new BigInteger();
			BigInteger bigInteger3 = new BigInteger();
			BigInteger bi = new BigInteger(radix);
			if (bigInteger.dataLength == 1 && bigInteger.data[0] == 0)
			{
				text2 = "0";
			}
			else
			{
				while (bigInteger.dataLength > 1 || (bigInteger.dataLength == 1 && bigInteger.data[0] != 0))
				{
					singleByteDivide(bigInteger, bi, bigInteger2, bigInteger3);
					text2 = ((bigInteger3.data[0] >= 10) ? (text[(int)(bigInteger3.data[0] - 10)] + text2) : (bigInteger3.data[0] + text2));
					bigInteger = bigInteger2;
				}
				if (flag)
				{
					text2 = "-" + text2;
				}
			}
			return text2;
		}

		public string ToHexString()
		{
			string text = data[dataLength - 1].ToString("X");
			for (int num = dataLength - 2; num >= 0; num--)
			{
				text += data[num].ToString("X8");
			}
			return text;
		}

		public BigInteger ModPow(BigInteger exp, BigInteger n)
		{
			if ((exp.data[69] & 0x80000000u) != 0)
			{
				throw new ArithmeticException("Positive exponents only.");
			}
			BigInteger bigInteger = 1;
			bool flag = false;
			BigInteger bigInteger2;
			if ((data[69] & 0x80000000u) != 0)
			{
				bigInteger2 = -this % n;
				flag = true;
			}
			else
			{
				bigInteger2 = this % n;
			}
			if ((n.data[69] & 0x80000000u) != 0)
			{
				n = -n;
			}
			BigInteger bigInteger3 = new BigInteger();
			int num = n.dataLength << 1;
			bigInteger3.data[num] = 1u;
			bigInteger3.dataLength = num + 1;
			bigInteger3 /= n;
			int num2 = exp.bitCount();
			int num3 = 0;
			for (int i = 0; i < exp.dataLength; i++)
			{
				uint num4 = 1u;
				for (int j = 0; j < 32; j++)
				{
					if ((exp.data[i] & num4) != 0)
					{
						bigInteger = BarrettReduction(bigInteger * bigInteger2, n, bigInteger3);
					}
					num4 <<= 1;
					bigInteger2 = BarrettReduction(bigInteger2 * bigInteger2, n, bigInteger3);
					if (bigInteger2.dataLength == 1 && bigInteger2.data[0] == 1)
					{
						if (flag && (exp.data[0] & 1) != 0)
						{
							return -bigInteger;
						}
						return bigInteger;
					}
					num3++;
					if (num3 == num2)
					{
						break;
					}
				}
			}
			if (flag && (exp.data[0] & 1) != 0)
			{
				return -bigInteger;
			}
			return bigInteger;
		}

		private BigInteger BarrettReduction(BigInteger x, BigInteger n, BigInteger constant)
		{
			int num = n.dataLength;
			int num2 = num + 1;
			int num3 = num - 1;
			BigInteger bigInteger = new BigInteger();
			int num4 = num3;
			int num5 = 0;
			while (num4 < x.dataLength)
			{
				bigInteger.data[num5] = x.data[num4];
				num4++;
				num5++;
			}
			bigInteger.dataLength = x.dataLength - num3;
			if (bigInteger.dataLength <= 0)
			{
				bigInteger.dataLength = 1;
			}
			BigInteger bigInteger2 = bigInteger * constant;
			BigInteger bigInteger3 = new BigInteger();
			int num6 = num2;
			int num7 = 0;
			while (num6 < bigInteger2.dataLength)
			{
				bigInteger3.data[num7] = bigInteger2.data[num6];
				num6++;
				num7++;
			}
			bigInteger3.dataLength = bigInteger2.dataLength - num2;
			if (bigInteger3.dataLength <= 0)
			{
				bigInteger3.dataLength = 1;
			}
			BigInteger bigInteger4 = new BigInteger();
			int num8 = ((x.dataLength > num2) ? num2 : x.dataLength);
			for (int i = 0; i < num8; i++)
			{
				bigInteger4.data[i] = x.data[i];
			}
			bigInteger4.dataLength = num8;
			BigInteger bigInteger5 = new BigInteger();
			for (int j = 0; j < bigInteger3.dataLength; j++)
			{
				if (bigInteger3.data[j] != 0)
				{
					ulong num9 = 0uL;
					int num10 = j;
					int num11 = 0;
					while (num11 < n.dataLength && num10 < num2)
					{
						ulong num12 = (ulong)((long)bigInteger3.data[j] * (long)n.data[num11] + bigInteger5.data[num10]) + num9;
						bigInteger5.data[num10] = (uint)(num12 & 0xFFFFFFFFu);
						num9 = num12 >> 32;
						num11++;
						num10++;
					}
					if (num10 < num2)
					{
						bigInteger5.data[num10] = (uint)num9;
					}
				}
			}
			bigInteger5.dataLength = num2;
			while (bigInteger5.dataLength > 1 && bigInteger5.data[bigInteger5.dataLength - 1] == 0)
			{
				bigInteger5.dataLength--;
			}
			bigInteger4 -= bigInteger5;
			if ((bigInteger4.data[69] & 0x80000000u) != 0)
			{
				BigInteger bigInteger6 = new BigInteger();
				bigInteger6.data[num2] = 1u;
				bigInteger6.dataLength = num2 + 1;
				bigInteger4 += bigInteger6;
			}
			for (; bigInteger4 >= n; bigInteger4 -= n)
			{
			}
			return bigInteger4;
		}

		public BigInteger gcd(BigInteger bi)
		{
			BigInteger bigInteger = (((data[69] & 0x80000000u) == 0) ? this : (-this));
			BigInteger bigInteger2 = (((bi.data[69] & 0x80000000u) == 0) ? bi : (-bi));
			BigInteger bigInteger3 = bigInteger2;
			while (bigInteger.dataLength > 1 || (bigInteger.dataLength == 1 && bigInteger.data[0] != 0))
			{
				bigInteger3 = bigInteger;
				bigInteger = bigInteger2 % bigInteger;
				bigInteger2 = bigInteger3;
			}
			return bigInteger3;
		}

		public static BigInteger GenerateRandom(int bits)
		{
			BigInteger bigInteger = new BigInteger();
			bigInteger.genRandomBits(bits, new System.Random());
			return bigInteger;
		}

		public void genRandomBits(int bits, System.Random rand)
		{
			int num = bits >> 5;
			int num2 = bits & 0x1F;
			if (num2 != 0)
			{
				num++;
			}
			if (num > 70)
			{
				throw new ArithmeticException("Number of required bits > maxLength.");
			}
			for (int i = 0; i < num; i++)
			{
				data[i] = (uint)(rand.NextDouble() * 4294967296.0);
			}
			for (int j = num; j < 70; j++)
			{
				data[j] = 0u;
			}
			if (num2 != 0)
			{
				uint num3 = (uint)(1 << num2 - 1);
				data[num - 1] |= num3;
				num3 = uint.MaxValue >> 32 - num2;
				data[num - 1] &= num3;
			}
			else
			{
				data[num - 1] |= 2147483648u;
			}
			dataLength = num;
			if (dataLength == 0)
			{
				dataLength = 1;
			}
		}

		public int bitCount()
		{
			while (dataLength > 1 && data[dataLength - 1] == 0)
			{
				dataLength--;
			}
			uint num = data[dataLength - 1];
			uint num2 = 2147483648u;
			int num3 = 32;
			while (num3 > 0 && (num & num2) == 0)
			{
				num3--;
				num2 >>= 1;
			}
			return num3 + (dataLength - 1 << 5);
		}

		public bool FermatLittleTest(int confidence)
		{
			BigInteger bigInteger = (((data[69] & 0x80000000u) == 0) ? this : (-this));
			if (bigInteger.dataLength == 1)
			{
				if (bigInteger.data[0] == 0 || bigInteger.data[0] == 1)
				{
					return false;
				}
				if (bigInteger.data[0] == 2 || bigInteger.data[0] == 3)
				{
					return true;
				}
			}
			if ((bigInteger.data[0] & 1) == 0)
			{
				return false;
			}
			int num = bigInteger.bitCount();
			BigInteger bigInteger2 = new BigInteger();
			BigInteger exp = bigInteger - new BigInteger(1L);
			System.Random random = new System.Random();
			for (int i = 0; i < confidence; i++)
			{
				bool flag = false;
				while (!flag)
				{
					int num2;
					for (num2 = 0; num2 < 2; num2 = (int)(random.NextDouble() * (double)num))
					{
					}
					bigInteger2.genRandomBits(num2, random);
					int num3 = bigInteger2.dataLength;
					if (num3 > 1 || (num3 == 1 && bigInteger2.data[0] != 1))
					{
						flag = true;
					}
				}
				BigInteger bigInteger3 = bigInteger2.gcd(bigInteger);
				if (bigInteger3.dataLength == 1 && bigInteger3.data[0] != 1)
				{
					return false;
				}
				BigInteger bigInteger4 = bigInteger2.ModPow(exp, bigInteger);
				int num4 = bigInteger4.dataLength;
				if (num4 > 1 || (num4 == 1 && bigInteger4.data[0] != 1))
				{
					return false;
				}
			}
			return true;
		}

		public bool RabinMillerTest(int confidence)
		{
			BigInteger bigInteger = (((data[69] & 0x80000000u) == 0) ? this : (-this));
			if (bigInteger.dataLength == 1)
			{
				if (bigInteger.data[0] == 0 || bigInteger.data[0] == 1)
				{
					return false;
				}
				if (bigInteger.data[0] == 2 || bigInteger.data[0] == 3)
				{
					return true;
				}
			}
			if ((bigInteger.data[0] & 1) == 0)
			{
				return false;
			}
			BigInteger bigInteger2 = bigInteger - new BigInteger(1L);
			int num = 0;
			for (int i = 0; i < bigInteger2.dataLength; i++)
			{
				uint num2 = 1u;
				for (int j = 0; j < 32; j++)
				{
					if ((bigInteger2.data[i] & num2) != 0)
					{
						i = bigInteger2.dataLength;
						break;
					}
					num2 <<= 1;
					num++;
				}
			}
			BigInteger exp = bigInteger2 >> num;
			int num3 = bigInteger.bitCount();
			BigInteger bigInteger3 = new BigInteger();
			System.Random random = new System.Random();
			for (int k = 0; k < confidence; k++)
			{
				bool flag = false;
				while (!flag)
				{
					int num4;
					for (num4 = 0; num4 < 2; num4 = (int)(random.NextDouble() * (double)num3))
					{
					}
					bigInteger3.genRandomBits(num4, random);
					int num5 = bigInteger3.dataLength;
					if (num5 > 1 || (num5 == 1 && bigInteger3.data[0] != 1))
					{
						flag = true;
					}
				}
				BigInteger bigInteger4 = bigInteger3.gcd(bigInteger);
				if (bigInteger4.dataLength == 1 && bigInteger4.data[0] != 1)
				{
					return false;
				}
				BigInteger bigInteger5 = bigInteger3.ModPow(exp, bigInteger);
				bool flag2 = false;
				if (bigInteger5.dataLength == 1 && bigInteger5.data[0] == 1)
				{
					flag2 = true;
				}
				int num6 = 0;
				while (!flag2 && num6 < num)
				{
					if (bigInteger5 == bigInteger2)
					{
						flag2 = true;
						break;
					}
					bigInteger5 = bigInteger5 * bigInteger5 % bigInteger;
					num6++;
				}
				if (!flag2)
				{
					return false;
				}
			}
			return true;
		}

		public bool SolovayStrassenTest(int confidence)
		{
			BigInteger bigInteger = (((data[69] & 0x80000000u) == 0) ? this : (-this));
			if (bigInteger.dataLength == 1)
			{
				if (bigInteger.data[0] == 0 || bigInteger.data[0] == 1)
				{
					return false;
				}
				if (bigInteger.data[0] == 2 || bigInteger.data[0] == 3)
				{
					return true;
				}
			}
			if ((bigInteger.data[0] & 1) == 0)
			{
				return false;
			}
			int num = bigInteger.bitCount();
			BigInteger bigInteger2 = new BigInteger();
			BigInteger bigInteger3 = bigInteger - 1;
			BigInteger exp = bigInteger3 >> 1;
			System.Random random = new System.Random();
			for (int i = 0; i < confidence; i++)
			{
				bool flag = false;
				while (!flag)
				{
					int num2;
					for (num2 = 0; num2 < 2; num2 = (int)(random.NextDouble() * (double)num))
					{
					}
					bigInteger2.genRandomBits(num2, random);
					int num3 = bigInteger2.dataLength;
					if (num3 > 1 || (num3 == 1 && bigInteger2.data[0] != 1))
					{
						flag = true;
					}
				}
				BigInteger bigInteger4 = bigInteger2.gcd(bigInteger);
				if (bigInteger4.dataLength == 1 && bigInteger4.data[0] != 1)
				{
					return false;
				}
				BigInteger bigInteger5 = bigInteger2.ModPow(exp, bigInteger);
				if (bigInteger5 == bigInteger3)
				{
					bigInteger5 = -1;
				}
				BigInteger bigInteger6 = Jacobi(bigInteger2, bigInteger);
				if (bigInteger5 != bigInteger6)
				{
					return false;
				}
			}
			return true;
		}

		public bool LucasStrongTest()
		{
			BigInteger bigInteger = (((data[69] & 0x80000000u) == 0) ? this : (-this));
			if (bigInteger.dataLength == 1)
			{
				if (bigInteger.data[0] == 0 || bigInteger.data[0] == 1)
				{
					return false;
				}
				if (bigInteger.data[0] == 2 || bigInteger.data[0] == 3)
				{
					return true;
				}
			}
			if ((bigInteger.data[0] & 1) == 0)
			{
				return false;
			}
			return LucasStrongTestHelper(bigInteger);
		}

		private bool LucasStrongTestHelper(BigInteger thisVal)
		{
			long num = 5L;
			long num2 = -1L;
			long num3 = 0L;
			for (bool flag = false; !flag; num3++)
			{
				switch (Jacobi(num, thisVal))
				{
				case -1:
					flag = true;
					continue;
				case 0:
					if (Math.Abs(num) < thisVal)
					{
						return false;
					}
					break;
				}
				if (num3 == 20)
				{
					BigInteger bigInteger = thisVal.sqrt();
					if (bigInteger * bigInteger == thisVal)
					{
						return false;
					}
				}
				num = (Math.Abs(num) + 2) * num2;
				num2 = -num2;
			}
			long num4 = 1 - num >> 2;
			BigInteger bigInteger2 = thisVal + 1;
			int num5 = 0;
			for (int i = 0; i < bigInteger2.dataLength; i++)
			{
				uint num6 = 1u;
				for (int j = 0; j < 32; j++)
				{
					if ((bigInteger2.data[i] & num6) != 0)
					{
						i = bigInteger2.dataLength;
						break;
					}
					num6 <<= 1;
					num5++;
				}
			}
			BigInteger k = bigInteger2 >> num5;
			BigInteger bigInteger3 = new BigInteger();
			int num7 = thisVal.dataLength << 1;
			bigInteger3.data[num7] = 1u;
			bigInteger3.dataLength = num7 + 1;
			bigInteger3 /= thisVal;
			BigInteger[] array = LucasSequenceHelper(1, num4, k, thisVal, bigInteger3, 0);
			bool flag2 = false;
			if ((array[0].dataLength == 1 && array[0].data[0] == 0) || (array[1].dataLength == 1 && array[1].data[0] == 0))
			{
				flag2 = true;
			}
			for (int l = 1; l < num5; l++)
			{
				if (!flag2)
				{
					array[1] = thisVal.BarrettReduction(array[1] * array[1], thisVal, bigInteger3);
					array[1] = (array[1] - (array[2] << 1)) % thisVal;
					if (array[1].dataLength == 1 && array[1].data[0] == 0)
					{
						flag2 = true;
					}
				}
				array[2] = thisVal.BarrettReduction(array[2] * array[2], thisVal, bigInteger3);
			}
			if (flag2)
			{
				BigInteger bigInteger4 = thisVal.gcd(num4);
				if (bigInteger4.dataLength == 1 && bigInteger4.data[0] == 1)
				{
					if ((array[2].data[69] & 0x80000000u) != 0)
					{
						BigInteger[] array2 = array;
						array2[2] += thisVal;
					}
					BigInteger bigInteger5 = num4 * Jacobi(num4, thisVal) % thisVal;
					if ((bigInteger5.data[69] & 0x80000000u) != 0)
					{
						bigInteger5 += thisVal;
					}
					if (array[2] != bigInteger5)
					{
						flag2 = false;
					}
				}
			}
			return flag2;
		}

		public bool isProbablePrime(int confidence)
		{
			BigInteger bigInteger = (((data[69] & 0x80000000u) == 0) ? this : (-this));
			for (int i = 0; i < primesBelow2000.Length; i++)
			{
				BigInteger bigInteger2 = primesBelow2000[i];
				if (bigInteger2 >= bigInteger)
				{
					break;
				}
				BigInteger bigInteger3 = bigInteger % bigInteger2;
				if (bigInteger3.IntValue() == 0)
				{
					return false;
				}
			}
			if (bigInteger.RabinMillerTest(confidence))
			{
				return true;
			}
			return false;
		}

		public bool isProbablePrime()
		{
			BigInteger bigInteger = (((data[69] & 0x80000000u) == 0) ? this : (-this));
			if (bigInteger.dataLength == 1)
			{
				if (bigInteger.data[0] == 0 || bigInteger.data[0] == 1)
				{
					return false;
				}
				if (bigInteger.data[0] == 2 || bigInteger.data[0] == 3)
				{
					return true;
				}
			}
			if ((bigInteger.data[0] & 1) == 0)
			{
				return false;
			}
			for (int i = 0; i < primesBelow2000.Length; i++)
			{
				BigInteger bigInteger2 = primesBelow2000[i];
				if (bigInteger2 >= bigInteger)
				{
					break;
				}
				BigInteger bigInteger3 = bigInteger % bigInteger2;
				if (bigInteger3.IntValue() == 0)
				{
					return false;
				}
			}
			BigInteger bigInteger4 = bigInteger - new BigInteger(1L);
			int num = 0;
			for (int j = 0; j < bigInteger4.dataLength; j++)
			{
				uint num2 = 1u;
				for (int k = 0; k < 32; k++)
				{
					if ((bigInteger4.data[j] & num2) != 0)
					{
						j = bigInteger4.dataLength;
						break;
					}
					num2 <<= 1;
					num++;
				}
			}
			BigInteger exp = bigInteger4 >> num;
			int num3 = bigInteger.bitCount();
			BigInteger bigInteger5 = 2;
			BigInteger bigInteger6 = bigInteger5.ModPow(exp, bigInteger);
			bool flag = false;
			if (bigInteger6.dataLength == 1 && bigInteger6.data[0] == 1)
			{
				flag = true;
			}
			int num4 = 0;
			while (!flag && num4 < num)
			{
				if (bigInteger6 == bigInteger4)
				{
					flag = true;
					break;
				}
				bigInteger6 = bigInteger6 * bigInteger6 % bigInteger;
				num4++;
			}
			if (flag)
			{
				flag = LucasStrongTestHelper(bigInteger);
			}
			return flag;
		}

		public int IntValue()
		{
			return (int)data[0];
		}

		public long LongValue()
		{
			long num = 0L;
			num = data[0];
			try
			{
				num |= (long)((ulong)data[1] << 32);
			}
			catch (Exception)
			{
				if ((data[0] & 0x80000000u) != 0)
				{
					num = (int)data[0];
				}
			}
			return num;
		}

		public static int Jacobi(BigInteger a, BigInteger b)
		{
			if ((b.data[0] & 1) == 0)
			{
				throw new ArgumentException("Jacobi defined only for odd integers.");
			}
			if (a >= b)
			{
				a %= b;
			}
			if (a.dataLength == 1 && a.data[0] == 0)
			{
				return 0;
			}
			if (a.dataLength == 1 && a.data[0] == 1)
			{
				return 1;
			}
			if (a < 0)
			{
				if (((b - 1).data[0] & 2) == 0)
				{
					return Jacobi(-a, b);
				}
				return -Jacobi(-a, b);
			}
			int num = 0;
			for (int i = 0; i < a.dataLength; i++)
			{
				uint num2 = 1u;
				for (int j = 0; j < 32; j++)
				{
					if ((a.data[i] & num2) != 0)
					{
						i = a.dataLength;
						break;
					}
					num2 <<= 1;
					num++;
				}
			}
			BigInteger bigInteger = a >> num;
			int num3 = 1;
			if ((num & 1) != 0 && ((b.data[0] & 7) == 3 || (b.data[0] & 7) == 5))
			{
				num3 = -1;
			}
			if ((b.data[0] & 3) == 3 && (bigInteger.data[0] & 3) == 3)
			{
				num3 = -num3;
			}
			if (bigInteger.dataLength == 1 && bigInteger.data[0] == 1)
			{
				return num3;
			}
			return num3 * Jacobi(b % bigInteger, bigInteger);
		}

		public static BigInteger genPseudoPrime(int bits, int confidence, System.Random rand)
		{
			BigInteger bigInteger = new BigInteger();
			bool flag = false;
			while (!flag)
			{
				bigInteger.genRandomBits(bits, rand);
				bigInteger.data[0] |= 1u;
				flag = bigInteger.isProbablePrime(confidence);
			}
			return bigInteger;
		}

		public BigInteger genCoPrime(int bits, System.Random rand)
		{
			bool flag = false;
			BigInteger bigInteger = new BigInteger();
			while (!flag)
			{
				bigInteger.genRandomBits(bits, rand);
				BigInteger bigInteger2 = bigInteger.gcd(this);
				if (bigInteger2.dataLength == 1 && bigInteger2.data[0] == 1)
				{
					flag = true;
				}
			}
			return bigInteger;
		}

		public BigInteger modInverse(BigInteger modulus)
		{
			BigInteger[] array = new BigInteger[2] { 0, 1 };
			BigInteger[] array2 = new BigInteger[2];
			BigInteger[] array3 = new BigInteger[2] { 0, 0 };
			int num = 0;
			BigInteger bi = modulus;
			BigInteger bigInteger = this;
			while (bigInteger.dataLength > 1 || (bigInteger.dataLength == 1 && bigInteger.data[0] != 0))
			{
				BigInteger bigInteger2 = new BigInteger();
				BigInteger bigInteger3 = new BigInteger();
				if (num > 1)
				{
					BigInteger bigInteger4 = (array[0] - array[1] * array2[0]) % modulus;
					array[0] = array[1];
					array[1] = bigInteger4;
				}
				if (bigInteger.dataLength == 1)
				{
					singleByteDivide(bi, bigInteger, bigInteger2, bigInteger3);
				}
				else
				{
					multiByteDivide(bi, bigInteger, bigInteger2, bigInteger3);
				}
				array2[0] = array2[1];
				array3[0] = array3[1];
				array2[1] = bigInteger2;
				array3[1] = bigInteger3;
				bi = bigInteger;
				bigInteger = bigInteger3;
				num++;
			}
			if (array3[0].dataLength > 1 || (array3[0].dataLength == 1 && array3[0].data[0] != 1))
			{
				throw new ArithmeticException("No inverse!");
			}
			BigInteger bigInteger5 = (array[0] - array[1] * array2[0]) % modulus;
			if ((bigInteger5.data[69] & 0x80000000u) != 0)
			{
				bigInteger5 += modulus;
			}
			return bigInteger5;
		}

		public byte[] GetBytes()
		{
			if (this == 0)
			{
				return new byte[1];
			}
			int num = bitCount();
			int num2 = num >> 3;
			if ((num & 7) != 0)
			{
				num2++;
			}
			byte[] array = new byte[num2];
			int num3 = num2 & 3;
			if (num3 == 0)
			{
				num3 = 4;
			}
			int num4 = 0;
			for (int num5 = dataLength - 1; num5 >= 0; num5--)
			{
				uint num6 = data[num5];
				for (int num7 = num3 - 1; num7 >= 0; num7--)
				{
					array[num4 + num7] = (byte)(num6 & 0xFF);
					num6 >>= 8;
				}
				num4 += num3;
				num3 = 4;
			}
			return array;
		}

		public void setBit(uint bitNum)
		{
			uint num = bitNum >> 5;
			byte b = (byte)(bitNum & 0x1F);
			uint num2 = (uint)(1 << (int)b);
			data[num] |= num2;
			if (num >= dataLength)
			{
				dataLength = (int)(num + 1);
			}
		}

		public void unsetBit(uint bitNum)
		{
			uint num = bitNum >> 5;
			if (num < dataLength)
			{
				byte b = (byte)(bitNum & 0x1F);
				uint num2 = (uint)(1 << (int)b);
				uint num3 = 0xFFFFFFFFu ^ num2;
				data[num] &= num3;
				if (dataLength > 1 && data[dataLength - 1] == 0)
				{
					dataLength--;
				}
			}
		}

		public BigInteger sqrt()
		{
			uint num = (uint)bitCount();
			num = (((num & 1) == 0) ? (num >> 1) : ((num >> 1) + 1));
			uint num2 = num >> 5;
			byte b = (byte)(num & 0x1F);
			BigInteger bigInteger = new BigInteger();
			uint num3;
			if (b == 0)
			{
				num3 = 2147483648u;
			}
			else
			{
				num3 = (uint)(1 << (int)b);
				num2++;
			}
			bigInteger.dataLength = (int)num2;
			for (int num4 = (int)(num2 - 1); num4 >= 0; num4--)
			{
				while (num3 != 0)
				{
					bigInteger.data[num4] ^= num3;
					if (bigInteger * bigInteger > this)
					{
						bigInteger.data[num4] ^= num3;
					}
					num3 >>= 1;
				}
				num3 = 2147483648u;
			}
			return bigInteger;
		}

		public static BigInteger[] LucasSequence(BigInteger P, BigInteger Q, BigInteger k, BigInteger n)
		{
			if (k.dataLength == 1 && k.data[0] == 0)
			{
				return new BigInteger[3]
				{
					0,
					2 % n,
					1 % n
				};
			}
			BigInteger bigInteger = new BigInteger();
			int num = n.dataLength << 1;
			bigInteger.data[num] = 1u;
			bigInteger.dataLength = num + 1;
			bigInteger /= n;
			int num2 = 0;
			for (int i = 0; i < k.dataLength; i++)
			{
				uint num3 = 1u;
				for (int j = 0; j < 32; j++)
				{
					if ((k.data[i] & num3) != 0)
					{
						i = k.dataLength;
						break;
					}
					num3 <<= 1;
					num2++;
				}
			}
			BigInteger k2 = k >> num2;
			return LucasSequenceHelper(P, Q, k2, n, bigInteger, num2);
		}

		private static BigInteger[] LucasSequenceHelper(BigInteger P, BigInteger Q, BigInteger k, BigInteger n, BigInteger constant, int s)
		{
			BigInteger[] array = new BigInteger[3];
			if ((k.data[0] & 1) == 0)
			{
				throw new ArgumentException("Argument k must be odd.");
			}
			int num = k.bitCount();
			uint num2 = (uint)(1 << (num & 0x1F) - 1);
			BigInteger bigInteger = 2 % n;
			BigInteger bigInteger2 = 1 % n;
			BigInteger bigInteger3 = P % n;
			BigInteger bigInteger4 = bigInteger2;
			bool flag = true;
			for (int num3 = k.dataLength - 1; num3 >= 0; num3--)
			{
				while (num2 != 0 && (num3 != 0 || num2 != 1))
				{
					if ((k.data[num3] & num2) != 0)
					{
						bigInteger4 = bigInteger4 * bigInteger3 % n;
						bigInteger = (bigInteger * bigInteger3 - P * bigInteger2) % n;
						bigInteger3 = n.BarrettReduction(bigInteger3 * bigInteger3, n, constant);
						bigInteger3 = (bigInteger3 - (bigInteger2 * Q << 1)) % n;
						if (flag)
						{
							flag = false;
						}
						else
						{
							bigInteger2 = n.BarrettReduction(bigInteger2 * bigInteger2, n, constant);
						}
						bigInteger2 = bigInteger2 * Q % n;
					}
					else
					{
						bigInteger4 = (bigInteger4 * bigInteger - bigInteger2) % n;
						bigInteger3 = (bigInteger * bigInteger3 - P * bigInteger2) % n;
						bigInteger = n.BarrettReduction(bigInteger * bigInteger, n, constant);
						bigInteger = (bigInteger - (bigInteger2 << 1)) % n;
						if (flag)
						{
							bigInteger2 = Q % n;
							flag = false;
						}
						else
						{
							bigInteger2 = n.BarrettReduction(bigInteger2 * bigInteger2, n, constant);
						}
					}
					num2 >>= 1;
				}
				num2 = 2147483648u;
			}
			bigInteger4 = (bigInteger4 * bigInteger - bigInteger2) % n;
			bigInteger = (bigInteger * bigInteger3 - P * bigInteger2) % n;
			if (flag)
			{
				flag = false;
			}
			else
			{
				bigInteger2 = n.BarrettReduction(bigInteger2 * bigInteger2, n, constant);
			}
			bigInteger2 = bigInteger2 * Q % n;
			for (int i = 0; i < s; i++)
			{
				bigInteger4 = bigInteger4 * bigInteger % n;
				bigInteger = (bigInteger * bigInteger - (bigInteger2 << 1)) % n;
				if (flag)
				{
					bigInteger2 = Q % n;
					flag = false;
				}
				else
				{
					bigInteger2 = n.BarrettReduction(bigInteger2 * bigInteger2, n, constant);
				}
			}
			array[0] = bigInteger4;
			array[1] = bigInteger;
			array[2] = bigInteger2;
			return array;
		}

		public static void MulDivTest(int rounds)
		{
			System.Random random = new System.Random();
			byte[] array = new byte[64];
			byte[] array2 = new byte[64];
			for (int i = 0; i < rounds; i++)
			{
				int num;
				for (num = 0; num == 0; num = (int)(random.NextDouble() * 65.0))
				{
				}
				int num2;
				for (num2 = 0; num2 == 0; num2 = (int)(random.NextDouble() * 65.0))
				{
				}
				bool flag = false;
				while (!flag)
				{
					for (int j = 0; j < 64; j++)
					{
						if (j < num)
						{
							array[j] = (byte)(random.NextDouble() * 256.0);
						}
						else
						{
							array[j] = 0;
						}
						if (array[j] != 0)
						{
							flag = true;
						}
					}
				}
				flag = false;
				while (!flag)
				{
					for (int k = 0; k < 64; k++)
					{
						if (k < num2)
						{
							array2[k] = (byte)(random.NextDouble() * 256.0);
						}
						else
						{
							array2[k] = 0;
						}
						if (array2[k] != 0)
						{
							flag = true;
						}
					}
				}
				while (array[0] == 0)
				{
					array[0] = (byte)(random.NextDouble() * 256.0);
				}
				while (array2[0] == 0)
				{
					array2[0] = (byte)(random.NextDouble() * 256.0);
				}
				Console.WriteLine(i);
				BigInteger bigInteger = new BigInteger(array, num);
				BigInteger bigInteger2 = new BigInteger(array2, num2);
				BigInteger bigInteger3 = bigInteger / bigInteger2;
				BigInteger bigInteger4 = bigInteger % bigInteger2;
				BigInteger bigInteger5 = bigInteger3 * bigInteger2 + bigInteger4;
				if (bigInteger5 != bigInteger)
				{
					Console.WriteLine("Error at " + i);
					Console.WriteLine(bigInteger?.ToString() + "\n");
					Console.WriteLine(bigInteger2?.ToString() + "\n");
					Console.WriteLine(bigInteger3?.ToString() + "\n");
					Console.WriteLine(bigInteger4?.ToString() + "\n");
					Console.WriteLine(bigInteger5?.ToString() + "\n");
					break;
				}
			}
		}

		public static void RSATest(int rounds)
		{
			System.Random random = new System.Random(1);
			byte[] array = new byte[64];
			BigInteger bigInteger = new BigInteger("a932b948feed4fb2b692609bd22164fc9edb59fae7880cc1eaff7b3c9626b7e5b241c27a974833b2622ebe09beb451917663d47232488f23a117fc97720f1e7", 16);
			BigInteger bigInteger2 = new BigInteger("4adf2f7a89da93248509347d2ae506d683dd3a16357e859a980c4f77a4e2f7a01fae289f13a851df6e9db5adaa60bfd2b162bbbe31f7c8f828261a6839311929d2cef4f864dde65e556ce43c89bbbf9f1ac5511315847ce9cc8dc92470a747b8792d6a83b0092d2e5ebaf852c85cacf34278efa99160f2f8aa7ee7214de07b7", 16);
			BigInteger bigInteger3 = new BigInteger("e8e77781f36a7b3188d711c2190b560f205a52391b3479cdb99fa010745cbeba5f2adc08e1de6bf38398a0487c4a73610d94ec36f17f3f46ad75e17bc1adfec99839589f45f95ccc94cb2a5c500b477eb3323d8cfab0c8458c96f0147a45d27e45a4d11d54d77684f65d48f15fafcc1ba208e71e921b9bd9017c16a5231af7f", 16);
			Console.WriteLine("e =\n" + bigInteger.ToString(10));
			Console.WriteLine("\nd =\n" + bigInteger2.ToString(10));
			Console.WriteLine("\nn =\n" + bigInteger3.ToString(10) + "\n");
			for (int i = 0; i < rounds; i++)
			{
				int num;
				for (num = 0; num == 0; num = (int)(random.NextDouble() * 65.0))
				{
				}
				bool flag = false;
				while (!flag)
				{
					for (int j = 0; j < 64; j++)
					{
						if (j < num)
						{
							array[j] = (byte)(random.NextDouble() * 256.0);
						}
						else
						{
							array[j] = 0;
						}
						if (array[j] != 0)
						{
							flag = true;
						}
					}
				}
				while (array[0] == 0)
				{
					array[0] = (byte)(random.NextDouble() * 256.0);
				}
				Console.Write("Round = " + i);
				BigInteger bigInteger4 = new BigInteger(array, num);
				BigInteger bigInteger5 = bigInteger4.ModPow(bigInteger, bigInteger3);
				BigInteger bigInteger6 = bigInteger5.ModPow(bigInteger2, bigInteger3);
				if (bigInteger6 != bigInteger4)
				{
					Console.WriteLine("\nError at round " + i);
					Console.WriteLine(bigInteger4?.ToString() + "\n");
					break;
				}
				Console.WriteLine(" <PASSED>.");
			}
		}

		public static void RSATest2(int rounds)
		{
			System.Random random = new System.Random();
			byte[] array = new byte[64];
			byte[] inData = new byte[64]
			{
				133, 132, 100, 253, 112, 106, 159, 240, 148, 12,
				62, 44, 116, 52, 5, 201, 85, 179, 133, 50,
				152, 113, 249, 65, 33, 95, 2, 158, 234, 86,
				141, 140, 68, 204, 238, 238, 61, 44, 157, 44,
				18, 65, 30, 241, 197, 50, 195, 170, 49, 74,
				82, 216, 232, 175, 66, 244, 114, 161, 42, 13,
				151, 177, 49, 179
			};
			byte[] inData2 = new byte[64]
			{
				153, 152, 202, 184, 94, 215, 229, 220, 40, 92,
				111, 14, 21, 9, 89, 110, 132, 243, 129, 205,
				222, 66, 220, 147, 194, 122, 98, 172, 108, 175,
				222, 116, 227, 203, 96, 32, 56, 156, 33, 195,
				220, 200, 162, 77, 198, 42, 53, 127, 243, 169,
				232, 29, 123, 44, 120, 250, 184, 2, 85, 128,
				155, 194, 165, 203
			};
			BigInteger bigInteger = new BigInteger(inData);
			BigInteger bigInteger2 = new BigInteger(inData2);
			BigInteger bigInteger3 = (bigInteger - 1) * (bigInteger2 - 1);
			BigInteger bigInteger4 = bigInteger * bigInteger2;
			for (int i = 0; i < rounds; i++)
			{
				BigInteger bigInteger5 = bigInteger3.genCoPrime(512, random);
				BigInteger bigInteger6 = bigInteger5.modInverse(bigInteger3);
				Console.WriteLine("\ne =\n" + bigInteger5.ToString(10));
				Console.WriteLine("\nd =\n" + bigInteger6.ToString(10));
				Console.WriteLine("\nn =\n" + bigInteger4.ToString(10) + "\n");
				int num;
				for (num = 0; num == 0; num = (int)(random.NextDouble() * 65.0))
				{
				}
				bool flag = false;
				while (!flag)
				{
					for (int j = 0; j < 64; j++)
					{
						if (j < num)
						{
							array[j] = (byte)(random.NextDouble() * 256.0);
						}
						else
						{
							array[j] = 0;
						}
						if (array[j] != 0)
						{
							flag = true;
						}
					}
				}
				while (array[0] == 0)
				{
					array[0] = (byte)(random.NextDouble() * 256.0);
				}
				Console.Write("Round = " + i);
				BigInteger bigInteger7 = new BigInteger(array, num);
				BigInteger bigInteger8 = bigInteger7.ModPow(bigInteger5, bigInteger4);
				BigInteger bigInteger9 = bigInteger8.ModPow(bigInteger6, bigInteger4);
				if (bigInteger9 != bigInteger7)
				{
					Console.WriteLine("\nError at round " + i);
					Console.WriteLine(bigInteger7?.ToString() + "\n");
					break;
				}
				Console.WriteLine(" <PASSED>.");
			}
		}

		public static void SqrtTest(int rounds)
		{
			System.Random random = new System.Random();
			for (int i = 0; i < rounds; i++)
			{
				int num;
				for (num = 0; num == 0; num = (int)(random.NextDouble() * 1024.0))
				{
				}
				Console.Write("Round = " + i);
				BigInteger bigInteger = new BigInteger();
				bigInteger.genRandomBits(num, random);
				BigInteger bigInteger2 = bigInteger.sqrt();
				BigInteger bigInteger3 = (bigInteger2 + 1) * (bigInteger2 + 1);
				if (bigInteger3 <= bigInteger)
				{
					Console.WriteLine("\nError at round " + i);
					Console.WriteLine(bigInteger?.ToString() + "\n");
					break;
				}
				Console.WriteLine(" <PASSED>.");
			}
		}

		public static void Main(string[] args)
		{
			byte[] inData = new byte[65]
			{
				0, 133, 132, 100, 253, 112, 106, 159, 240, 148,
				12, 62, 44, 116, 52, 5, 201, 85, 179, 133,
				50, 152, 113, 249, 65, 33, 95, 2, 158, 234,
				86, 141, 140, 68, 204, 238, 238, 61, 44, 157,
				44, 18, 65, 30, 241, 197, 50, 195, 170, 49,
				74, 82, 216, 232, 175, 66, 244, 114, 161, 42,
				13, 151, 177, 49, 179
			};
			byte[] array = new byte[65]
			{
				0, 153, 152, 202, 184, 94, 215, 229, 220, 40,
				92, 111, 14, 21, 9, 89, 110, 132, 243, 129,
				205, 222, 66, 220, 147, 194, 122, 98, 172, 108,
				175, 222, 116, 227, 203, 96, 32, 56, 156, 33,
				195, 220, 200, 162, 77, 198, 42, 53, 127, 243,
				169, 232, 29, 123, 44, 120, 250, 184, 2, 85,
				128, 155, 194, 165, 203
			};
			Console.WriteLine("List of primes < 2000\n---------------------");
			int num = 100;
			int num2 = 0;
			for (int i = 0; i < 2000; i++)
			{
				if (i >= num)
				{
					Console.WriteLine();
					num += 100;
				}
				BigInteger bigInteger = new BigInteger(-i);
				if (bigInteger.isProbablePrime())
				{
					Console.Write(i + ", ");
					num2++;
				}
			}
			Console.WriteLine("\nCount = " + num2);
			BigInteger bigInteger2 = new BigInteger(inData);
			Console.WriteLine("\n\nPrimality testing for\n" + bigInteger2.ToString() + "\n");
			Console.WriteLine("SolovayStrassenTest(5) = " + bigInteger2.SolovayStrassenTest(5));
			Console.WriteLine("RabinMillerTest(5) = " + bigInteger2.RabinMillerTest(5));
			Console.WriteLine("FermatLittleTest(5) = " + bigInteger2.FermatLittleTest(5));
			Console.WriteLine("isProbablePrime() = " + bigInteger2.isProbablePrime());
			Console.Write("\nGenerating 512-bits random pseudoprime. . .");
			System.Random rand = new System.Random();
			Console.WriteLine("\n" + genPseudoPrime(512, 5, rand));
		}
	}
}
