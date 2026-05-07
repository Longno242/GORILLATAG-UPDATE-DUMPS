using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("clipper_library")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("clipper_library")]
[assembly: AssemblyCopyright("Angus Johnson 2010-2012")]
[assembly: AssemblyTrademark("")]
[assembly: ComVisible(false)]
[assembly: Guid("51a6bdca-bc4e-4b2c-ae69-36e2497204f2")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: AssemblyVersion("1.0.0.0")]
namespace Pathfinding.ClipperLib;

public struct DoublePoint
{
	public double X;

	public double Y;

	public DoublePoint(double x = 0.0, double y = 0.0)
	{
		X = x;
		Y = y;
	}

	public DoublePoint(DoublePoint dp)
	{
		X = dp.X;
		Y = dp.Y;
	}

	public DoublePoint(IntPoint ip)
	{
		X = ip.X;
		Y = ip.Y;
	}
}
public class PolyTree : PolyNode
{
	internal List<PolyNode> m_AllPolys = new List<PolyNode>();

	public int Total => m_AllPolys.Count;

	~PolyTree()
	{
		Clear();
	}

	public void Clear()
	{
		for (int i = 0; i < m_AllPolys.Count; i++)
		{
			m_AllPolys[i] = null;
		}
		m_AllPolys.Clear();
		m_Childs.Clear();
	}

	public PolyNode GetFirst()
	{
		if (m_Childs.Count > 0)
		{
			return m_Childs[0];
		}
		return null;
	}
}
public class PolyNode
{
	internal PolyNode m_Parent;

	internal List<IntPoint> m_polygon = new List<IntPoint>();

	internal int m_Index;

	internal List<PolyNode> m_Childs = new List<PolyNode>();

	public int ChildCount => m_Childs.Count;

	public List<IntPoint> Contour => m_polygon;

	public List<PolyNode> Childs => m_Childs;

	public PolyNode Parent => m_Parent;

	public bool IsHole => IsHoleNode();

	public bool IsOpen { get; set; }

	private bool IsHoleNode()
	{
		bool flag = true;
		for (PolyNode parent = m_Parent; parent != null; parent = parent.m_Parent)
		{
			flag = !flag;
		}
		return flag;
	}

	internal void AddChild(PolyNode Child)
	{
		int count = m_Childs.Count;
		m_Childs.Add(Child);
		Child.m_Parent = this;
		Child.m_Index = count;
	}

	public PolyNode GetNext()
	{
		if (m_Childs.Count > 0)
		{
			return m_Childs[0];
		}
		return GetNextSiblingUp();
	}

	internal PolyNode GetNextSiblingUp()
	{
		if (m_Parent == null)
		{
			return null;
		}
		if (m_Index == m_Parent.m_Childs.Count - 1)
		{
			return m_Parent.GetNextSiblingUp();
		}
		return m_Parent.m_Childs[m_Index + 1];
	}
}
internal struct Int128
{
	private long hi;

	private ulong lo;

	public Int128(long _lo)
	{
		lo = (ulong)_lo;
		if (_lo < 0)
		{
			hi = -1L;
		}
		else
		{
			hi = 0L;
		}
	}

	public Int128(long _hi, ulong _lo)
	{
		lo = _lo;
		hi = _hi;
	}

	public Int128(Int128 val)
	{
		hi = val.hi;
		lo = val.lo;
	}

	public bool IsNegative()
	{
		return hi < 0;
	}

	public override bool Equals(object obj)
	{
		if (obj == null || !(obj is Int128 @int))
		{
			return false;
		}
		return @int.hi == hi && @int.lo == lo;
	}

	public override int GetHashCode()
	{
		return hi.GetHashCode() ^ lo.GetHashCode();
	}

	public static Int128 Int128Mul(long lhs, long rhs)
	{
		bool flag = lhs < 0 != rhs < 0;
		if (lhs < 0)
		{
			lhs = -lhs;
		}
		if (rhs < 0)
		{
			rhs = -rhs;
		}
		ulong num = (ulong)lhs >> 32;
		ulong num2 = (ulong)(lhs & 0xFFFFFFFFu);
		ulong num3 = (ulong)rhs >> 32;
		ulong num4 = (ulong)(rhs & 0xFFFFFFFFu);
		ulong num5 = num * num3;
		ulong num6 = num2 * num4;
		ulong num7 = num * num4 + num2 * num3;
		long num8 = (long)(num5 + (num7 >> 32));
		ulong num9 = (num7 << 32) + num6;
		if (num9 < num6)
		{
			num8++;
		}
		Int128 @int = new Int128(num8, num9);
		return (!flag) ? @int : (-@int);
	}

	public double ToDouble()
	{
		if (hi < 0)
		{
			if (lo == 0)
			{
				return (double)hi * 1.8446744073709552E+19;
			}
			return 0.0 - ((double)(~lo) + (double)(~hi) * 1.8446744073709552E+19);
		}
		return (double)lo + (double)hi * 1.8446744073709552E+19;
	}

	public static bool operator ==(Int128 val1, Int128 val2)
	{
		if ((object)val1 == (object)val2)
		{
			return true;
		}
		if ((object)val1 == null || (object)val2 == null)
		{
			return false;
		}
		return val1.hi == val2.hi && val1.lo == val2.lo;
	}

	public static bool operator !=(Int128 val1, Int128 val2)
	{
		return !(val1 == val2);
	}

	public static bool operator >(Int128 val1, Int128 val2)
	{
		if (val1.hi != val2.hi)
		{
			return val1.hi > val2.hi;
		}
		return val1.lo > val2.lo;
	}

	public static bool operator <(Int128 val1, Int128 val2)
	{
		if (val1.hi != val2.hi)
		{
			return val1.hi < val2.hi;
		}
		return val1.lo < val2.lo;
	}

	public static Int128 operator +(Int128 lhs, Int128 rhs)
	{
		lhs.hi += rhs.hi;
		lhs.lo += rhs.lo;
		if (lhs.lo < rhs.lo)
		{
			lhs.hi++;
		}
		return lhs;
	}

	public static Int128 operator -(Int128 lhs, Int128 rhs)
	{
		return lhs + -rhs;
	}

	public static Int128 operator -(Int128 val)
	{
		if (val.lo == 0)
		{
			return new Int128(-val.hi, 0uL);
		}
		return new Int128(~val.hi, ~val.lo + 1);
	}

	public static Int128 operator /(Int128 lhs, Int128 rhs)
	{
		if (rhs.lo == 0 && rhs.hi == 0)
		{
			throw new ClipperException("Int128: divide by zero");
		}
		bool flag = rhs.hi < 0 != lhs.hi < 0;
		if (lhs.hi < 0)
		{
			lhs = -lhs;
		}
		if (rhs.hi < 0)
		{
			rhs = -rhs;
		}
		if (rhs < lhs)
		{
			Int128 @int = new Int128(0L);
			Int128 int2 = new Int128(1L);
			while (rhs.hi >= 0 && !(rhs > lhs))
			{
				rhs.hi <<= 1;
				if ((long)rhs.lo < 0L)
				{
					rhs.hi++;
				}
				rhs.lo <<= 1;
				int2.hi <<= 1;
				if ((long)int2.lo < 0L)
				{
					int2.hi++;
				}
				int2.lo <<= 1;
			}
			rhs.lo >>= 1;
			if ((rhs.hi & 1) == 1)
			{
				rhs.lo |= 9223372036854775808uL;
			}
			rhs.hi >>>= 1;
			int2.lo >>= 1;
			if ((int2.hi & 1) == 1)
			{
				int2.lo |= 9223372036854775808uL;
			}
			int2.hi >>= 1;
			while (int2.hi != 0 || int2.lo != 0)
			{
				if (!(lhs < rhs))
				{
					lhs -= rhs;
					@int.hi |= int2.hi;
					@int.lo |= int2.lo;
				}
				rhs.lo >>= 1;
				if ((rhs.hi & 1) == 1)
				{
					rhs.lo |= 9223372036854775808uL;
				}
				rhs.hi >>= 1;
				int2.lo >>= 1;
				if ((int2.hi & 1) == 1)
				{
					int2.lo |= 9223372036854775808uL;
				}
				int2.hi >>= 1;
			}
			return (!flag) ? @int : (-@int);
		}
		if (rhs == lhs)
		{
			return new Int128(1L);
		}
		return new Int128(0L);
	}
}
public struct IntPoint
{
	public long X;

	public long Y;

	public IntPoint(long X, long Y)
	{
		this.X = X;
		this.Y = Y;
	}

	public IntPoint(double x, double y)
	{
		X = (long)x;
		Y = (long)y;
	}

	public IntPoint(IntPoint pt)
	{
		X = pt.X;
		Y = pt.Y;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is IntPoint intPoint)
		{
			return X == intPoint.X && Y == intPoint.Y;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public static bool operator ==(IntPoint a, IntPoint b)
	{
		return a.X == b.X && a.Y == b.Y;
	}

	public static bool operator !=(IntPoint a, IntPoint b)
	{
		return a.X != b.X || a.Y != b.Y;
	}
}
public struct IntRect
{
	public long left;

	public long top;

	public long right;

	public long bottom;

	public IntRect(long l, long t, long r, long b)
	{
		left = l;
		top = t;
		right = r;
		bottom = b;
	}

	public IntRect(IntRect ir)
	{
		left = ir.left;
		top = ir.top;
		right = ir.right;
		bottom = ir.bottom;
	}
}
public enum ClipType
{
	ctIntersection,
	ctUnion,
	ctDifference,
	ctXor
}
public enum PolyType
{
	ptSubject,
	ptClip
}
public enum PolyFillType
{
	pftEvenOdd,
	pftNonZero,
	pftPositive,
	pftNegative
}
public enum JoinType
{
	jtSquare,
	jtRound,
	jtMiter
}
public enum EndType
{
	etClosed,
	etButt,
	etSquare,
	etRound
}
internal enum EdgeSide
{
	esLeft,
	esRight
}
internal enum Direction
{
	dRightToLeft,
	dLeftToRight
}
internal class TEdge
{
	public IntPoint Bot;

	public IntPoint Curr;

	public IntPoint Top;

	public IntPoint Delta;

	public double Dx;

	public PolyType PolyTyp;

	public EdgeSide Side;

	public int WindDelta;

	public int WindCnt;

	public int WindCnt2;

	public int OutIdx;

	public TEdge Next;

	public TEdge Prev;

	public TEdge NextInLML;

	public TEdge NextInAEL;

	public TEdge PrevInAEL;

	public TEdge NextInSEL;

	public TEdge PrevInSEL;
}
internal class IntersectNode
{
	public TEdge Edge1;

	public TEdge Edge2;

	public IntPoint Pt;

	public IntersectNode Next;
}
internal class LocalMinima
{
	public long Y;

	public TEdge LeftBound;

	public TEdge RightBound;

	public LocalMinima Next;
}
internal class Scanbeam
{
	public long Y;

	public Scanbeam Next;
}
internal class OutRec
{
	public int Idx;

	public bool IsHole;

	public bool IsOpen;

	public OutRec FirstLeft;

	public OutPt Pts;

	public OutPt BottomPt;

	public PolyNode PolyNode;
}
internal class OutPt
{
	public int Idx;

	public IntPoint Pt;

	public OutPt Next;

	public OutPt Prev;
}
internal class Join
{
	public OutPt OutPt1;

	public OutPt OutPt2;

	public IntPoint OffPt;
}
public class ClipperBase
{
	protected const double horizontal = -3.4E+38;

	protected const int Skip = -2;

	protected const int Unassigned = -1;

	protected const double tolerance = 1E-20;

	internal const long loRange = 1073741823L;

	internal const long hiRange = 4611686018427387903L;

	internal LocalMinima m_MinimaList;

	internal LocalMinima m_CurrentLM;

	internal List<List<TEdge>> m_edges = new List<List<TEdge>>();

	internal bool m_UseFullRange;

	internal bool m_HasOpenPaths;

	public bool PreserveCollinear { get; set; }

	internal ClipperBase()
	{
		m_MinimaList = null;
		m_CurrentLM = null;
		m_UseFullRange = false;
		m_HasOpenPaths = false;
	}

	internal static bool near_zero(double val)
	{
		return val > -1E-20 && val < 1E-20;
	}

	internal static bool IsHorizontal(TEdge e)
	{
		return e.Delta.Y == 0;
	}

	internal bool PointIsVertex(IntPoint pt, OutPt pp)
	{
		OutPt outPt = pp;
		do
		{
			if (outPt.Pt == pt)
			{
				return true;
			}
			outPt = outPt.Next;
		}
		while (outPt != pp);
		return false;
	}

	internal bool PointOnLineSegment(IntPoint pt, IntPoint linePt1, IntPoint linePt2, bool UseFullRange)
	{
		if (UseFullRange)
		{
			return (pt.X == linePt1.X && pt.Y == linePt1.Y) || (pt.X == linePt2.X && pt.Y == linePt2.Y) || (pt.X > linePt1.X == pt.X < linePt2.X && pt.Y > linePt1.Y == pt.Y < linePt2.Y && Int128.Int128Mul(pt.X - linePt1.X, linePt2.Y - linePt1.Y) == Int128.Int128Mul(linePt2.X - linePt1.X, pt.Y - linePt1.Y));
		}
		return (pt.X == linePt1.X && pt.Y == linePt1.Y) || (pt.X == linePt2.X && pt.Y == linePt2.Y) || (pt.X > linePt1.X == pt.X < linePt2.X && pt.Y > linePt1.Y == pt.Y < linePt2.Y && (pt.X - linePt1.X) * (linePt2.Y - linePt1.Y) == (linePt2.X - linePt1.X) * (pt.Y - linePt1.Y));
	}

	internal bool PointOnPolygon(IntPoint pt, OutPt pp, bool UseFullRange)
	{
		OutPt outPt = pp;
		do
		{
			if (PointOnLineSegment(pt, outPt.Pt, outPt.Next.Pt, UseFullRange))
			{
				return true;
			}
			outPt = outPt.Next;
		}
		while (outPt != pp);
		return false;
	}

	internal bool PointInPolygon(IntPoint pt, OutPt pp, bool UseFullRange)
	{
		OutPt outPt = pp;
		bool flag = false;
		if (UseFullRange)
		{
			do
			{
				if (outPt.Pt.Y > pt.Y != outPt.Prev.Pt.Y > pt.Y && new Int128(pt.X - outPt.Pt.X) < Int128.Int128Mul(outPt.Prev.Pt.X - outPt.Pt.X, pt.Y - outPt.Pt.Y) / new Int128(outPt.Prev.Pt.Y - outPt.Pt.Y))
				{
					flag = !flag;
				}
				outPt = outPt.Next;
			}
			while (outPt != pp);
		}
		else
		{
			do
			{
				if (outPt.Pt.Y > pt.Y != outPt.Prev.Pt.Y > pt.Y && pt.X - outPt.Pt.X < (outPt.Prev.Pt.X - outPt.Pt.X) * (pt.Y - outPt.Pt.Y) / (outPt.Prev.Pt.Y - outPt.Pt.Y))
				{
					flag = !flag;
				}
				outPt = outPt.Next;
			}
			while (outPt != pp);
		}
		return flag;
	}

	internal static bool SlopesEqual(TEdge e1, TEdge e2, bool UseFullRange)
	{
		if (UseFullRange)
		{
			return Int128.Int128Mul(e1.Delta.Y, e2.Delta.X) == Int128.Int128Mul(e1.Delta.X, e2.Delta.Y);
		}
		return e1.Delta.Y * e2.Delta.X == e1.Delta.X * e2.Delta.Y;
	}

	protected static bool SlopesEqual(IntPoint pt1, IntPoint pt2, IntPoint pt3, bool UseFullRange)
	{
		if (UseFullRange)
		{
			return Int128.Int128Mul(pt1.Y - pt2.Y, pt2.X - pt3.X) == Int128.Int128Mul(pt1.X - pt2.X, pt2.Y - pt3.Y);
		}
		return (pt1.Y - pt2.Y) * (pt2.X - pt3.X) - (pt1.X - pt2.X) * (pt2.Y - pt3.Y) == 0;
	}

	protected static bool SlopesEqual(IntPoint pt1, IntPoint pt2, IntPoint pt3, IntPoint pt4, bool UseFullRange)
	{
		if (UseFullRange)
		{
			return Int128.Int128Mul(pt1.Y - pt2.Y, pt3.X - pt4.X) == Int128.Int128Mul(pt1.X - pt2.X, pt3.Y - pt4.Y);
		}
		return (pt1.Y - pt2.Y) * (pt3.X - pt4.X) - (pt1.X - pt2.X) * (pt3.Y - pt4.Y) == 0;
	}

	public virtual void Clear()
	{
		DisposeLocalMinimaList();
		for (int i = 0; i < m_edges.Count; i++)
		{
			for (int j = 0; j < m_edges[i].Count; j++)
			{
				m_edges[i][j] = null;
			}
			m_edges[i].Clear();
		}
		m_edges.Clear();
		m_UseFullRange = false;
		m_HasOpenPaths = false;
	}

	private void DisposeLocalMinimaList()
	{
		while (m_MinimaList != null)
		{
			LocalMinima next = m_MinimaList.Next;
			m_MinimaList = null;
			m_MinimaList = next;
		}
		m_CurrentLM = null;
	}

	private void RangeTest(IntPoint Pt, ref bool useFullRange)
	{
		if (useFullRange)
		{
			if (Pt.X > 4611686018427387903L || Pt.Y > 4611686018427387903L || -Pt.X > 4611686018427387903L || -Pt.Y > 4611686018427387903L)
			{
				throw new ClipperException("Coordinate outside allowed range");
			}
		}
		else if (Pt.X > 1073741823 || Pt.Y > 1073741823 || -Pt.X > 1073741823 || -Pt.Y > 1073741823)
		{
			useFullRange = true;
			RangeTest(Pt, ref useFullRange);
		}
	}

	private void InitEdge(TEdge e, TEdge eNext, TEdge ePrev, IntPoint pt)
	{
		e.Next = eNext;
		e.Prev = ePrev;
		e.Curr = pt;
		e.OutIdx = -1;
	}

	private void InitEdge2(TEdge e, PolyType polyType)
	{
		if (e.Curr.Y >= e.Next.Curr.Y)
		{
			e.Bot = e.Curr;
			e.Top = e.Next.Curr;
		}
		else
		{
			e.Top = e.Curr;
			e.Bot = e.Next.Curr;
		}
		SetDx(e);
		e.PolyTyp = polyType;
	}

	public bool AddPath(List<IntPoint> pg, PolyType polyType, bool Closed)
	{
		if (!Closed)
		{
			throw new ClipperException("AddPath: Open paths have been disabled.");
		}
		int num = pg.Count - 1;
		bool flag = num > 0 && (Closed || pg[0] == pg[num]);
		while (num > 0 && pg[num] == pg[0])
		{
			num--;
		}
		while (num > 0 && pg[num] == pg[num - 1])
		{
			num--;
		}
		if ((Closed && num < 2) || (!Closed && num < 1))
		{
			return false;
		}
		List<TEdge> list = new List<TEdge>(num + 1);
		for (int i = 0; i <= num; i++)
		{
			list.Add(new TEdge());
		}
		try
		{
			list[1].Curr = pg[1];
			RangeTest(pg[0], ref m_UseFullRange);
			RangeTest(pg[num], ref m_UseFullRange);
			InitEdge(list[0], list[1], list[num], pg[0]);
			InitEdge(list[num], list[0], list[num - 1], pg[num]);
			for (int num2 = num - 1; num2 >= 1; num2--)
			{
				RangeTest(pg[num2], ref m_UseFullRange);
				InitEdge(list[num2], list[num2 + 1], list[num2 - 1], pg[num2]);
			}
		}
		catch
		{
			return false;
		}
		TEdge tEdge = list[0];
		if (!flag)
		{
			tEdge.Prev.OutIdx = -2;
		}
		TEdge tEdge2 = tEdge;
		TEdge tEdge3 = tEdge;
		while (true)
		{
			if (tEdge2.Curr == tEdge2.Next.Curr)
			{
				if (tEdge2 == tEdge2.Next)
				{
					break;
				}
				if (tEdge2 == tEdge)
				{
					tEdge = tEdge2.Next;
				}
				tEdge2 = RemoveEdge(tEdge2);
				tEdge3 = tEdge2;
				continue;
			}
			if (tEdge2.Prev == tEdge2.Next)
			{
				break;
			}
			if ((flag || (tEdge2.Prev.OutIdx != -2 && tEdge2.OutIdx != -2 && tEdge2.Next.OutIdx != -2)) && SlopesEqual(tEdge2.Prev.Curr, tEdge2.Curr, tEdge2.Next.Curr, m_UseFullRange) && Closed && (!PreserveCollinear || !Pt2IsBetweenPt1AndPt3(tEdge2.Prev.Curr, tEdge2.Curr, tEdge2.Next.Curr)))
			{
				if (tEdge2 == tEdge)
				{
					tEdge = tEdge2.Next;
				}
				tEdge2 = RemoveEdge(tEdge2);
				tEdge2 = tEdge2.Prev;
				tEdge3 = tEdge2;
			}
			else
			{
				tEdge2 = tEdge2.Next;
				if (tEdge2 == tEdge3)
				{
					break;
				}
			}
		}
		if ((!Closed && tEdge2 == tEdge2.Next) || (Closed && tEdge2.Prev == tEdge2.Next))
		{
			return false;
		}
		m_edges.Add(list);
		if (!Closed)
		{
			m_HasOpenPaths = true;
		}
		TEdge tEdge4 = tEdge;
		tEdge2 = tEdge;
		do
		{
			InitEdge2(tEdge2, polyType);
			if (tEdge2.Top.Y < tEdge4.Top.Y)
			{
				tEdge4 = tEdge2;
			}
			tEdge2 = tEdge2.Next;
		}
		while (tEdge2 != tEdge);
		if (AllHorizontal(tEdge2))
		{
			if (flag)
			{
				tEdge2.Prev.OutIdx = -2;
			}
			AscendToMax(ref tEdge2, Appending: false, IsClosed: false);
			return true;
		}
		tEdge2 = tEdge.Prev;
		if (tEdge2.Prev == tEdge2.Next)
		{
			tEdge4 = tEdge2.Next;
		}
		else if (!flag && tEdge2.Top.Y == tEdge4.Top.Y)
		{
			tEdge4 = (((IsHorizontal(tEdge2) || IsHorizontal(tEdge2.Next)) && tEdge2.Next.Bot.Y == tEdge4.Top.Y) ? tEdge2.Next : (SharedVertWithPrevAtTop(tEdge2) ? tEdge2 : ((!(tEdge2.Top == tEdge2.Prev.Top)) ? tEdge2.Next : tEdge2.Prev)));
		}
		else
		{
			tEdge2 = tEdge4;
			while (IsHorizontal(tEdge4) || tEdge4.Top == tEdge4.Next.Top || tEdge4.Top == tEdge4.Next.Bot)
			{
				tEdge4 = tEdge4.Next;
				if (tEdge4 == tEdge2)
				{
					while (IsHorizontal(tEdge4) || !SharedVertWithPrevAtTop(tEdge4))
					{
						tEdge4 = tEdge4.Next;
					}
					break;
				}
			}
		}
		tEdge2 = tEdge4;
		do
		{
			tEdge2 = AddBoundsToLML(tEdge2, Closed);
		}
		while (tEdge2 != tEdge4);
		return true;
	}

	public bool AddPaths(List<List<IntPoint>> ppg, PolyType polyType, bool closed)
	{
		bool result = false;
		for (int i = 0; i < ppg.Count; i++)
		{
			if (AddPath(ppg[i], polyType, closed))
			{
				result = true;
			}
		}
		return result;
	}

	public bool AddPolygon(List<IntPoint> pg, PolyType polyType)
	{
		return AddPath(pg, polyType, Closed: true);
	}

	public bool AddPolygons(List<List<IntPoint>> ppg, PolyType polyType)
	{
		bool result = false;
		for (int i = 0; i < ppg.Count; i++)
		{
			if (AddPath(ppg[i], polyType, Closed: true))
			{
				result = true;
			}
		}
		return result;
	}

	internal bool Pt2IsBetweenPt1AndPt3(IntPoint pt1, IntPoint pt2, IntPoint pt3)
	{
		if (pt1 == pt3 || pt1 == pt2 || pt3 == pt2)
		{
			return false;
		}
		if (pt1.X != pt3.X)
		{
			return pt2.X > pt1.X == pt2.X < pt3.X;
		}
		return pt2.Y > pt1.Y == pt2.Y < pt3.Y;
	}

	private TEdge RemoveEdge(TEdge e)
	{
		e.Prev.Next = e.Next;
		e.Next.Prev = e.Prev;
		TEdge next = e.Next;
		e.Prev = null;
		return next;
	}

	private TEdge GetLastHorz(TEdge Edge)
	{
		TEdge tEdge = Edge;
		while (tEdge.OutIdx != -2 && tEdge.Next != Edge && IsHorizontal(tEdge.Next))
		{
			tEdge = tEdge.Next;
		}
		return tEdge;
	}

	private bool SharedVertWithPrevAtTop(TEdge Edge)
	{
		TEdge tEdge = Edge;
		bool flag = true;
		while (tEdge.Prev != Edge)
		{
			if (tEdge.Top == tEdge.Prev.Top)
			{
				if (tEdge.Bot == tEdge.Prev.Bot)
				{
					tEdge = tEdge.Prev;
					continue;
				}
				flag = true;
				break;
			}
			flag = false;
			break;
		}
		while (tEdge != Edge)
		{
			flag = !flag;
			tEdge = tEdge.Next;
		}
		return flag;
	}

	private bool SharedVertWithNextIsBot(TEdge Edge)
	{
		bool flag = true;
		TEdge tEdge = Edge;
		while (tEdge.Prev != Edge)
		{
			bool flag2 = tEdge.Next.Bot == tEdge.Bot;
			bool flag3 = tEdge.Prev.Bot == tEdge.Bot;
			if (flag2 != flag3)
			{
				flag = flag2;
				break;
			}
			flag2 = tEdge.Next.Top == tEdge.Top;
			flag3 = tEdge.Prev.Top == tEdge.Top;
			if (flag2 != flag3)
			{
				flag = flag3;
				break;
			}
			tEdge = tEdge.Prev;
		}
		while (tEdge != Edge)
		{
			flag = !flag;
			tEdge = tEdge.Next;
		}
		return flag;
	}

	private bool MoreBelow(TEdge Edge)
	{
		TEdge tEdge = Edge;
		if (IsHorizontal(tEdge))
		{
			while (IsHorizontal(tEdge.Next))
			{
				tEdge = tEdge.Next;
			}
			return tEdge.Next.Bot.Y > tEdge.Bot.Y;
		}
		if (IsHorizontal(tEdge.Next))
		{
			while (IsHorizontal(tEdge.Next))
			{
				tEdge = tEdge.Next;
			}
			return tEdge.Next.Bot.Y > tEdge.Bot.Y;
		}
		return tEdge.Bot == tEdge.Next.Top;
	}

	private bool JustBeforeLocMin(TEdge Edge)
	{
		TEdge tEdge = Edge;
		if (IsHorizontal(tEdge))
		{
			while (IsHorizontal(tEdge.Next))
			{
				tEdge = tEdge.Next;
			}
			return tEdge.Next.Top.Y < tEdge.Bot.Y;
		}
		return SharedVertWithNextIsBot(tEdge);
	}

	private bool MoreAbove(TEdge Edge)
	{
		if (IsHorizontal(Edge))
		{
			Edge = GetLastHorz(Edge);
			return Edge.Next.Top.Y < Edge.Top.Y;
		}
		if (IsHorizontal(Edge.Next))
		{
			Edge = GetLastHorz(Edge.Next);
			return Edge.Next.Top.Y < Edge.Top.Y;
		}
		return Edge.Next.Top.Y < Edge.Top.Y;
	}

	private bool AllHorizontal(TEdge Edge)
	{
		if (!IsHorizontal(Edge))
		{
			return false;
		}
		for (TEdge next = Edge.Next; next != Edge; next = next.Next)
		{
			if (!IsHorizontal(next))
			{
				return false;
			}
		}
		return true;
	}

	private void SetDx(TEdge e)
	{
		e.Delta.X = e.Top.X - e.Bot.X;
		e.Delta.Y = e.Top.Y - e.Bot.Y;
		if (e.Delta.Y == 0)
		{
			e.Dx = -3.4E+38;
		}
		else
		{
			e.Dx = (double)e.Delta.X / (double)e.Delta.Y;
		}
	}

	private void DoMinimaLML(TEdge E1, TEdge E2, bool IsClosed)
	{
		if (E1 == null)
		{
			if (E2 != null)
			{
				LocalMinima localMinima = new LocalMinima();
				localMinima.Next = null;
				localMinima.Y = E2.Bot.Y;
				localMinima.LeftBound = null;
				E2.WindDelta = 0;
				localMinima.RightBound = E2;
				InsertLocalMinima(localMinima);
			}
			return;
		}
		LocalMinima localMinima2 = new LocalMinima();
		localMinima2.Y = E1.Bot.Y;
		localMinima2.Next = null;
		if (IsHorizontal(E2))
		{
			if (E2.Bot.X != E1.Bot.X)
			{
				ReverseHorizontal(E2);
			}
			localMinima2.LeftBound = E1;
			localMinima2.RightBound = E2;
		}
		else if (E2.Dx < E1.Dx)
		{
			localMinima2.LeftBound = E1;
			localMinima2.RightBound = E2;
		}
		else
		{
			localMinima2.LeftBound = E2;
			localMinima2.RightBound = E1;
		}
		localMinima2.LeftBound.Side = EdgeSide.esLeft;
		localMinima2.RightBound.Side = EdgeSide.esRight;
		if (!IsClosed)
		{
			localMinima2.LeftBound.WindDelta = 0;
		}
		else if (localMinima2.LeftBound.Next == localMinima2.RightBound)
		{
			localMinima2.LeftBound.WindDelta = -1;
		}
		else
		{
			localMinima2.LeftBound.WindDelta = 1;
		}
		localMinima2.RightBound.WindDelta = -localMinima2.LeftBound.WindDelta;
		InsertLocalMinima(localMinima2);
	}

	private TEdge DescendToMin(ref TEdge E)
	{
		E.NextInLML = null;
		if (IsHorizontal(E))
		{
			TEdge tEdge = E;
			while (IsHorizontal(tEdge.Next))
			{
				tEdge = tEdge.Next;
			}
			if (tEdge.Bot != tEdge.Next.Top)
			{
				ReverseHorizontal(E);
			}
		}
		while (true)
		{
			E = E.Next;
			if (E.OutIdx == -2)
			{
				break;
			}
			if (IsHorizontal(E))
			{
				TEdge tEdge = GetLastHorz(E);
				if (tEdge == E.Prev || (tEdge.Next.Top.Y < E.Top.Y && tEdge.Next.Bot.X > E.Prev.Bot.X))
				{
					break;
				}
				if (E.Top.X != E.Prev.Bot.X)
				{
					ReverseHorizontal(E);
				}
				if (tEdge.OutIdx == -2)
				{
					tEdge = tEdge.Prev;
				}
				while (E != tEdge)
				{
					E.NextInLML = E.Prev;
					E = E.Next;
					if (E.Top.X != E.Prev.Bot.X)
					{
						ReverseHorizontal(E);
					}
				}
			}
			else if (E.Bot.Y == E.Prev.Bot.Y)
			{
				break;
			}
			E.NextInLML = E.Prev;
		}
		return E.Prev;
	}

	private void AscendToMax(ref TEdge E, bool Appending, bool IsClosed)
	{
		if (E.OutIdx == -2)
		{
			E = E.Next;
			if (!MoreAbove(E.Prev))
			{
				return;
			}
		}
		if (IsHorizontal(E) && Appending && E.Bot != E.Prev.Bot)
		{
			ReverseHorizontal(E);
		}
		TEdge tEdge = E;
		while (E.Next.OutIdx != -2 && (E.Next.Top.Y != E.Top.Y || IsHorizontal(E.Next)))
		{
			E.NextInLML = E.Next;
			E = E.Next;
			if (IsHorizontal(E) && E.Bot.X != E.Prev.Top.X)
			{
				ReverseHorizontal(E);
			}
		}
		if (!Appending)
		{
			if (tEdge.OutIdx == -2)
			{
				tEdge = tEdge.Next;
			}
			if (tEdge != E.Next)
			{
				DoMinimaLML(null, tEdge, IsClosed);
			}
		}
		E = E.Next;
	}

	private TEdge AddBoundsToLML(TEdge E, bool Closed)
	{
		TEdge tEdge;
		if (E.OutIdx == -2)
		{
			if (MoreBelow(E))
			{
				E = E.Next;
				tEdge = DescendToMin(ref E);
			}
			else
			{
				tEdge = null;
			}
		}
		else
		{
			tEdge = DescendToMin(ref E);
		}
		bool appending;
		if (E.OutIdx == -2)
		{
			DoMinimaLML(null, tEdge, Closed);
			appending = false;
			if (E.Bot != E.Prev.Bot && MoreBelow(E))
			{
				E = E.Next;
				tEdge = DescendToMin(ref E);
				DoMinimaLML(tEdge, E, Closed);
				appending = true;
			}
			else if (JustBeforeLocMin(E))
			{
				E = E.Next;
			}
		}
		else
		{
			DoMinimaLML(tEdge, E, Closed);
			appending = true;
		}
		AscendToMax(ref E, appending, Closed);
		if (E.OutIdx == -2 && E.Top != E.Prev.Top)
		{
			if (MoreAbove(E))
			{
				E = E.Next;
				AscendToMax(ref E, Appending: false, Closed);
			}
			else if (E.Top == E.Next.Top || (IsHorizontal(E.Next) && E.Top == E.Next.Bot))
			{
				E = E.Next;
			}
		}
		return E;
	}

	private void InsertLocalMinima(LocalMinima newLm)
	{
		if (m_MinimaList == null)
		{
			m_MinimaList = newLm;
			return;
		}
		if (newLm.Y >= m_MinimaList.Y)
		{
			newLm.Next = m_MinimaList;
			m_MinimaList = newLm;
			return;
		}
		LocalMinima localMinima = m_MinimaList;
		while (localMinima.Next != null && newLm.Y < localMinima.Next.Y)
		{
			localMinima = localMinima.Next;
		}
		newLm.Next = localMinima.Next;
		localMinima.Next = newLm;
	}

	protected void PopLocalMinima()
	{
		if (m_CurrentLM != null)
		{
			m_CurrentLM = m_CurrentLM.Next;
		}
	}

	private void ReverseHorizontal(TEdge e)
	{
		long x = e.Top.X;
		e.Top.X = e.Bot.X;
		e.Bot.X = x;
	}

	protected virtual void Reset()
	{
		m_CurrentLM = m_MinimaList;
		if (m_CurrentLM == null)
		{
			return;
		}
		for (LocalMinima localMinima = m_MinimaList; localMinima != null; localMinima = localMinima.Next)
		{
			TEdge leftBound = localMinima.LeftBound;
			if (leftBound != null)
			{
				leftBound.Curr = leftBound.Bot;
				leftBound.Side = EdgeSide.esLeft;
				if (leftBound.OutIdx != -2)
				{
					leftBound.OutIdx = -1;
				}
			}
			leftBound = localMinima.RightBound;
			leftBound.Curr = leftBound.Bot;
			leftBound.Side = EdgeSide.esRight;
			if (leftBound.OutIdx != -2)
			{
				leftBound.OutIdx = -1;
			}
		}
	}

	public IntRect GetBounds()
	{
		IntRect result = default(IntRect);
		LocalMinima localMinima = m_MinimaList;
		if (localMinima == null)
		{
			return result;
		}
		result.left = localMinima.LeftBound.Bot.X;
		result.top = localMinima.LeftBound.Bot.Y;
		result.right = localMinima.LeftBound.Bot.X;
		result.bottom = localMinima.LeftBound.Bot.Y;
		while (localMinima != null)
		{
			if (localMinima.LeftBound.Bot.Y > result.bottom)
			{
				result.bottom = localMinima.LeftBound.Bot.Y;
			}
			TEdge tEdge = localMinima.LeftBound;
			while (true)
			{
				TEdge tEdge2 = tEdge;
				while (tEdge.NextInLML != null)
				{
					if (tEdge.Bot.X < result.left)
					{
						result.left = tEdge.Bot.X;
					}
					if (tEdge.Bot.X > result.right)
					{
						result.right = tEdge.Bot.X;
					}
					tEdge = tEdge.NextInLML;
				}
				if (tEdge.Bot.X < result.left)
				{
					result.left = tEdge.Bot.X;
				}
				if (tEdge.Bot.X > result.right)
				{
					result.right = tEdge.Bot.X;
				}
				if (tEdge.Top.X < result.left)
				{
					result.left = tEdge.Top.X;
				}
				if (tEdge.Top.X > result.right)
				{
					result.right = tEdge.Top.X;
				}
				if (tEdge.Top.Y < result.top)
				{
					result.top = tEdge.Top.Y;
				}
				if (tEdge2 == localMinima.LeftBound)
				{
					tEdge = localMinima.RightBound;
					continue;
				}
				break;
			}
			localMinima = localMinima.Next;
		}
		return result;
	}
}
public class Clipper : ClipperBase
{
	private class PolyOffsetBuilder
	{
		private const int m_buffLength = 128;

		private List<List<IntPoint>> m_p;

		private List<IntPoint> currentPoly;

		private List<DoublePoint> normals = new List<DoublePoint>();

		private double m_delta;

		private double m_sinA;

		private double m_sin;

		private double m_cos;

		private double m_miterLim;

		private double m_Steps360;

		private int m_i;

		private int m_j;

		private int m_k;

		public PolyOffsetBuilder(List<List<IntPoint>> pts, out List<List<IntPoint>> solution, double delta, JoinType jointype, EndType endtype, double limit = 0.0)
		{
			solution = new List<List<IntPoint>>();
			if (ClipperBase.near_zero(delta))
			{
				solution = pts;
				return;
			}
			m_p = pts;
			if (endtype != EndType.etClosed && delta < 0.0)
			{
				delta = 0.0 - delta;
			}
			m_delta = delta;
			if (jointype == JoinType.jtMiter)
			{
				if (limit > 2.0)
				{
					m_miterLim = 2.0 / (limit * limit);
				}
				else
				{
					m_miterLim = 0.5;
				}
				if (endtype == EndType.etRound)
				{
					limit = 0.25;
				}
			}
			if (jointype == JoinType.jtRound || endtype == EndType.etRound)
			{
				if (limit <= 0.0)
				{
					limit = 0.25;
				}
				else if (limit > Math.Abs(delta) * 0.25)
				{
					limit = Math.Abs(delta) * 0.25;
				}
				m_Steps360 = Math.PI / Math.Acos(1.0 - limit / Math.Abs(delta));
				m_sin = Math.Sin(Math.PI * 2.0 / m_Steps360);
				m_cos = Math.Cos(Math.PI * 2.0 / m_Steps360);
				m_Steps360 /= Math.PI * 2.0;
				if (delta < 0.0)
				{
					m_sin = 0.0 - m_sin;
				}
			}
			double num = delta * delta;
			solution.Capacity = pts.Count;
			for (m_i = 0; m_i < pts.Count; m_i++)
			{
				int count = pts[m_i].Count;
				if (count != 0 && (count >= 3 || !(delta <= 0.0)))
				{
					if (count == 1)
					{
						if (jointype == JoinType.jtRound)
						{
							double num2 = 1.0;
							double num3 = 0.0;
							for (long num4 = 1L; num4 <= Round(m_Steps360 * 2.0 * Math.PI); num4++)
							{
								AddPoint(new IntPoint(Round((double)m_p[m_i][0].X + num2 * delta), Round((double)m_p[m_i][0].Y + num3 * delta)));
								double num5 = num2;
								num2 = num2 * m_cos - m_sin * num3;
								num3 = num5 * m_sin + num3 * m_cos;
							}
						}
						else
						{
							double num6 = -1.0;
							double num7 = -1.0;
							for (int i = 0; i < 4; i++)
							{
								AddPoint(new IntPoint(Round((double)m_p[m_i][0].X + num6 * delta), Round((double)m_p[m_i][0].Y + num7 * delta)));
								if (num6 < 0.0)
								{
									num6 = 1.0;
								}
								else if (num7 < 0.0)
								{
									num7 = 1.0;
								}
								else
								{
									num6 = -1.0;
								}
							}
						}
					}
					else
					{
						normals.Clear();
						normals.Capacity = count;
						for (int j = 0; j < count - 1; j++)
						{
							normals.Add(GetUnitNormal(pts[m_i][j], pts[m_i][j + 1]));
						}
						if (endtype == EndType.etClosed)
						{
							normals.Add(GetUnitNormal(pts[m_i][count - 1], pts[m_i][0]));
						}
						else
						{
							normals.Add(new DoublePoint(normals[count - 2]));
						}
						currentPoly = new List<IntPoint>();
						if (endtype == EndType.etClosed)
						{
							m_k = count - 1;
							for (m_j = 0; m_j < count; m_j++)
							{
								OffsetPoint(jointype);
							}
							solution.Add(currentPoly);
						}
						else
						{
							m_k = 0;
							for (m_j = 1; m_j < count - 1; m_j++)
							{
								OffsetPoint(jointype);
							}
							IntPoint pt;
							if (endtype == EndType.etButt)
							{
								m_j = count - 1;
								pt = new IntPoint(Round((double)pts[m_i][m_j].X + normals[m_j].X * delta), Round((double)pts[m_i][m_j].Y + normals[m_j].Y * delta));
								AddPoint(pt);
								pt = new IntPoint(Round((double)pts[m_i][m_j].X - normals[m_j].X * delta), Round((double)pts[m_i][m_j].Y - normals[m_j].Y * delta));
								AddPoint(pt);
							}
							else
							{
								m_j = count - 1;
								m_k = count - 2;
								m_sinA = 0.0;
								normals[m_j] = new DoublePoint(0.0 - normals[m_j].X, 0.0 - normals[m_j].Y);
								if (endtype == EndType.etSquare)
								{
									DoSquare();
								}
								else
								{
									DoRound();
								}
							}
							for (int num8 = count - 1; num8 > 0; num8--)
							{
								normals[num8] = new DoublePoint(0.0 - normals[num8 - 1].X, 0.0 - normals[num8 - 1].Y);
							}
							normals[0] = new DoublePoint(0.0 - normals[1].X, 0.0 - normals[1].Y);
							m_k = count - 1;
							for (m_j = m_k - 1; m_j > 0; m_j--)
							{
								OffsetPoint(jointype);
							}
							if (endtype == EndType.etButt)
							{
								pt = new IntPoint(Round((double)pts[m_i][0].X - normals[0].X * delta), Round((double)pts[m_i][0].Y - normals[0].Y * delta));
								AddPoint(pt);
								pt = new IntPoint(Round((double)pts[m_i][0].X + normals[0].X * delta), Round((double)pts[m_i][0].Y + normals[0].Y * delta));
								AddPoint(pt);
							}
							else
							{
								m_k = 1;
								m_sinA = 0.0;
								if (endtype == EndType.etSquare)
								{
									DoSquare();
								}
								else
								{
									DoRound();
								}
							}
							solution.Add(currentPoly);
						}
					}
				}
			}
			Clipper clipper = new Clipper();
			clipper.AddPaths(solution, PolyType.ptSubject, closed: true);
			if (delta > 0.0)
			{
				clipper.Execute(ClipType.ctUnion, solution, PolyFillType.pftPositive, PolyFillType.pftPositive);
				return;
			}
			IntRect bounds = clipper.GetBounds();
			clipper.AddPath(new List<IntPoint>(4)
			{
				new IntPoint(bounds.left - 10, bounds.bottom + 10),
				new IntPoint(bounds.right + 10, bounds.bottom + 10),
				new IntPoint(bounds.right + 10, bounds.top - 10),
				new IntPoint(bounds.left - 10, bounds.top - 10)
			}, PolyType.ptSubject, Closed: true);
			clipper.ReverseSolution = true;
			clipper.Execute(ClipType.ctUnion, solution, PolyFillType.pftNegative, PolyFillType.pftNegative);
			if (solution.Count > 0)
			{
				solution.RemoveAt(0);
			}
		}

		private void OffsetPoint(JoinType jointype)
		{
			m_sinA = normals[m_k].X * normals[m_j].Y - normals[m_j].X * normals[m_k].Y;
			if (m_sinA < 5E-05 && m_sinA > -5E-05)
			{
				return;
			}
			if (m_sinA > 1.0)
			{
				m_sinA = 1.0;
			}
			else if (m_sinA < -1.0)
			{
				m_sinA = -1.0;
			}
			if (m_sinA * m_delta < 0.0)
			{
				AddPoint(new IntPoint(Round((double)m_p[m_i][m_j].X + normals[m_k].X * m_delta), Round((double)m_p[m_i][m_j].Y + normals[m_k].Y * m_delta)));
				AddPoint(m_p[m_i][m_j]);
				AddPoint(new IntPoint(Round((double)m_p[m_i][m_j].X + normals[m_j].X * m_delta), Round((double)m_p[m_i][m_j].Y + normals[m_j].Y * m_delta)));
			}
			else
			{
				switch (jointype)
				{
				case JoinType.jtMiter:
				{
					double num = 1.0 + (normals[m_j].X * normals[m_k].X + normals[m_j].Y * normals[m_k].Y);
					if (num >= m_miterLim)
					{
						DoMiter(num);
					}
					else
					{
						DoSquare();
					}
					break;
				}
				case JoinType.jtSquare:
					DoSquare();
					break;
				case JoinType.jtRound:
					DoRound();
					break;
				}
			}
			m_k = m_j;
		}

		internal void AddPoint(IntPoint pt)
		{
			if (currentPoly.Count == currentPoly.Capacity)
			{
				currentPoly.Capacity += 128;
			}
			currentPoly.Add(pt);
		}

		internal void DoSquare()
		{
			double num = Math.Tan(Math.Atan2(m_sinA, normals[m_k].X * normals[m_j].X + normals[m_k].Y * normals[m_j].Y) / 4.0);
			AddPoint(new IntPoint(Round((double)m_p[m_i][m_j].X + m_delta * (normals[m_k].X - normals[m_k].Y * num)), Round((double)m_p[m_i][m_j].Y + m_delta * (normals[m_k].Y + normals[m_k].X * num))));
			AddPoint(new IntPoint(Round((double)m_p[m_i][m_j].X + m_delta * (normals[m_j].X + normals[m_j].Y * num)), Round((double)m_p[m_i][m_j].Y + m_delta * (normals[m_j].Y - normals[m_j].X * num))));
		}

		internal void DoMiter(double r)
		{
			double num = m_delta / r;
			AddPoint(new IntPoint(Round((double)m_p[m_i][m_j].X + (normals[m_k].X + normals[m_j].X) * num), Round((double)m_p[m_i][m_j].Y + (normals[m_k].Y + normals[m_j].Y) * num)));
		}

		internal void DoRound()
		{
			double value = Math.Atan2(m_sinA, normals[m_k].X * normals[m_j].X + normals[m_k].Y * normals[m_j].Y);
			int num = (int)Round(m_Steps360 * Math.Abs(value));
			double num2 = normals[m_k].X;
			double num3 = normals[m_k].Y;
			for (int i = 0; i < num; i++)
			{
				AddPoint(new IntPoint(Round((double)m_p[m_i][m_j].X + num2 * m_delta), Round((double)m_p[m_i][m_j].Y + num3 * m_delta)));
				double num4 = num2;
				num2 = num2 * m_cos - m_sin * num3;
				num3 = num4 * m_sin + num3 * m_cos;
			}
			AddPoint(new IntPoint(Round((double)m_p[m_i][m_j].X + normals[m_j].X * m_delta), Round((double)m_p[m_i][m_j].Y + normals[m_j].Y * m_delta)));
		}
	}

	internal enum NodeType
	{
		ntAny,
		ntOpen,
		ntClosed
	}

	public const int ioReverseSolution = 1;

	public const int ioStrictlySimple = 2;

	public const int ioPreserveCollinear = 4;

	private List<OutRec> m_PolyOuts;

	private ClipType m_ClipType;

	private Scanbeam m_Scanbeam;

	private TEdge m_ActiveEdges;

	private TEdge m_SortedEdges;

	private IntersectNode m_IntersectNodes;

	private bool m_ExecuteLocked;

	private PolyFillType m_ClipFillType;

	private PolyFillType m_SubjFillType;

	private List<Join> m_Joins;

	private List<Join> m_GhostJoins;

	private bool m_UsingPolyTree;

	public bool ReverseSolution { get; set; }

	public bool StrictlySimple { get; set; }

	public Clipper(int InitOptions = 0)
	{
		m_Scanbeam = null;
		m_ActiveEdges = null;
		m_SortedEdges = null;
		m_IntersectNodes = null;
		m_ExecuteLocked = false;
		m_UsingPolyTree = false;
		m_PolyOuts = new List<OutRec>();
		m_Joins = new List<Join>();
		m_GhostJoins = new List<Join>();
		ReverseSolution = (1 & InitOptions) != 0;
		StrictlySimple = (2 & InitOptions) != 0;
		base.PreserveCollinear = (4 & InitOptions) != 0;
	}

	public override void Clear()
	{
		if (m_edges.Count != 0)
		{
			DisposeAllPolyPts();
			base.Clear();
		}
	}

	private void DisposeScanbeamList()
	{
		while (m_Scanbeam != null)
		{
			Scanbeam next = m_Scanbeam.Next;
			m_Scanbeam = null;
			m_Scanbeam = next;
		}
	}

	protected override void Reset()
	{
		base.Reset();
		m_Scanbeam = null;
		m_ActiveEdges = null;
		m_SortedEdges = null;
		DisposeAllPolyPts();
		for (LocalMinima localMinima = m_MinimaList; localMinima != null; localMinima = localMinima.Next)
		{
			InsertScanbeam(localMinima.Y);
		}
	}

	private void InsertScanbeam(long Y)
	{
		if (m_Scanbeam == null)
		{
			m_Scanbeam = new Scanbeam();
			m_Scanbeam.Next = null;
			m_Scanbeam.Y = Y;
			return;
		}
		if (Y > m_Scanbeam.Y)
		{
			Scanbeam scanbeam = new Scanbeam();
			scanbeam.Y = Y;
			scanbeam.Next = m_Scanbeam;
			m_Scanbeam = scanbeam;
			return;
		}
		Scanbeam scanbeam2 = m_Scanbeam;
		while (scanbeam2.Next != null && Y <= scanbeam2.Next.Y)
		{
			scanbeam2 = scanbeam2.Next;
		}
		if (Y != scanbeam2.Y)
		{
			Scanbeam scanbeam3 = new Scanbeam();
			scanbeam3.Y = Y;
			scanbeam3.Next = scanbeam2.Next;
			scanbeam2.Next = scanbeam3;
		}
	}

	public bool Execute(ClipType clipType, List<List<IntPoint>> solution, PolyFillType subjFillType, PolyFillType clipFillType)
	{
		if (m_ExecuteLocked)
		{
			return false;
		}
		if (m_HasOpenPaths)
		{
			throw new ClipperException("Error: PolyTree struct is need for open path clipping.");
		}
		m_ExecuteLocked = true;
		solution.Clear();
		m_SubjFillType = subjFillType;
		m_ClipFillType = clipFillType;
		m_ClipType = clipType;
		m_UsingPolyTree = false;
		bool flag = ExecuteInternal();
		if (flag)
		{
			BuildResult(solution);
		}
		m_ExecuteLocked = false;
		return flag;
	}

	public bool Execute(ClipType clipType, PolyTree polytree, PolyFillType subjFillType, PolyFillType clipFillType)
	{
		if (m_ExecuteLocked)
		{
			return false;
		}
		m_ExecuteLocked = true;
		m_SubjFillType = subjFillType;
		m_ClipFillType = clipFillType;
		m_ClipType = clipType;
		m_UsingPolyTree = true;
		bool flag = ExecuteInternal();
		if (flag)
		{
			BuildResult2(polytree);
		}
		m_ExecuteLocked = false;
		return flag;
	}

	public bool Execute(ClipType clipType, List<List<IntPoint>> solution)
	{
		return Execute(clipType, solution, PolyFillType.pftEvenOdd, PolyFillType.pftEvenOdd);
	}

	public bool Execute(ClipType clipType, PolyTree polytree)
	{
		return Execute(clipType, polytree, PolyFillType.pftEvenOdd, PolyFillType.pftEvenOdd);
	}

	internal void FixHoleLinkage(OutRec outRec)
	{
		if (outRec.FirstLeft != null && (outRec.IsHole == outRec.FirstLeft.IsHole || outRec.FirstLeft.Pts == null))
		{
			OutRec firstLeft = outRec.FirstLeft;
			while (firstLeft != null && (firstLeft.IsHole == outRec.IsHole || firstLeft.Pts == null))
			{
				firstLeft = firstLeft.FirstLeft;
			}
			outRec.FirstLeft = firstLeft;
		}
	}

	private bool ExecuteInternal()
	{
		try
		{
			Reset();
			if (m_CurrentLM == null)
			{
				return false;
			}
			long botY = PopScanbeam();
			do
			{
				InsertLocalMinimaIntoAEL(botY);
				m_GhostJoins.Clear();
				ProcessHorizontals(isTopOfScanbeam: false);
				if (m_Scanbeam == null)
				{
					break;
				}
				long num = PopScanbeam();
				if (!ProcessIntersections(botY, num))
				{
					return false;
				}
				ProcessEdgesAtTopOfScanbeam(num);
				botY = num;
			}
			while (m_Scanbeam != null || m_CurrentLM != null);
			for (int i = 0; i < m_PolyOuts.Count; i++)
			{
				OutRec outRec = m_PolyOuts[i];
				if (outRec.Pts != null && !outRec.IsOpen && (outRec.IsHole ^ ReverseSolution) == Area(outRec) > 0.0)
				{
					ReversePolyPtLinks(outRec.Pts);
				}
			}
			JoinCommonEdges();
			for (int j = 0; j < m_PolyOuts.Count; j++)
			{
				OutRec outRec2 = m_PolyOuts[j];
				if (outRec2.Pts != null && !outRec2.IsOpen)
				{
					FixupOutPolygon(outRec2);
				}
			}
			if (StrictlySimple)
			{
				DoSimplePolygons();
			}
			return true;
		}
		finally
		{
			m_Joins.Clear();
			m_GhostJoins.Clear();
		}
	}

	private long PopScanbeam()
	{
		long y = m_Scanbeam.Y;
		Scanbeam scanbeam = m_Scanbeam;
		m_Scanbeam = m_Scanbeam.Next;
		scanbeam = null;
		return y;
	}

	private void DisposeAllPolyPts()
	{
		for (int i = 0; i < m_PolyOuts.Count; i++)
		{
			DisposeOutRec(i);
		}
		m_PolyOuts.Clear();
	}

	private void DisposeOutRec(int index)
	{
		OutRec outRec = m_PolyOuts[index];
		if (outRec.Pts != null)
		{
			DisposeOutPts(outRec.Pts);
		}
		outRec = null;
		m_PolyOuts[index] = null;
	}

	private void DisposeOutPts(OutPt pp)
	{
		if (pp != null)
		{
			OutPt outPt = null;
			pp.Prev.Next = null;
			while (pp != null)
			{
				outPt = pp;
				pp = pp.Next;
				outPt = null;
			}
		}
	}

	private void AddJoin(OutPt Op1, OutPt Op2, IntPoint OffPt)
	{
		Join obj = new Join();
		obj.OutPt1 = Op1;
		obj.OutPt2 = Op2;
		obj.OffPt = OffPt;
		m_Joins.Add(obj);
	}

	private void AddGhostJoin(OutPt Op, IntPoint OffPt)
	{
		Join obj = new Join();
		obj.OutPt1 = Op;
		obj.OffPt = OffPt;
		m_GhostJoins.Add(obj);
	}

	private void InsertLocalMinimaIntoAEL(long botY)
	{
		while (m_CurrentLM != null && m_CurrentLM.Y == botY)
		{
			TEdge leftBound = m_CurrentLM.LeftBound;
			TEdge rightBound = m_CurrentLM.RightBound;
			PopLocalMinima();
			OutPt outPt = null;
			if (leftBound == null)
			{
				InsertEdgeIntoAEL(rightBound, null);
				SetWindingCount(rightBound);
				if (IsContributing(rightBound))
				{
					outPt = AddOutPt(rightBound, rightBound.Bot);
				}
			}
			else
			{
				InsertEdgeIntoAEL(leftBound, null);
				InsertEdgeIntoAEL(rightBound, leftBound);
				SetWindingCount(leftBound);
				rightBound.WindCnt = leftBound.WindCnt;
				rightBound.WindCnt2 = leftBound.WindCnt2;
				if (IsContributing(leftBound))
				{
					outPt = AddLocalMinPoly(leftBound, rightBound, leftBound.Bot);
				}
				InsertScanbeam(leftBound.Top.Y);
			}
			if (ClipperBase.IsHorizontal(rightBound))
			{
				AddEdgeToSEL(rightBound);
			}
			else
			{
				InsertScanbeam(rightBound.Top.Y);
			}
			if (leftBound == null)
			{
				continue;
			}
			if (outPt != null && ClipperBase.IsHorizontal(rightBound) && m_GhostJoins.Count > 0 && rightBound.WindDelta != 0)
			{
				for (int i = 0; i < m_GhostJoins.Count; i++)
				{
					Join obj = m_GhostJoins[i];
					if (HorzSegmentsOverlap(obj.OutPt1.Pt, obj.OffPt, rightBound.Bot, rightBound.Top))
					{
						AddJoin(obj.OutPt1, outPt, obj.OffPt);
					}
				}
			}
			if (leftBound.OutIdx >= 0 && leftBound.PrevInAEL != null && leftBound.PrevInAEL.Curr.X == leftBound.Bot.X && leftBound.PrevInAEL.OutIdx >= 0 && ClipperBase.SlopesEqual(leftBound.PrevInAEL, leftBound, m_UseFullRange) && leftBound.WindDelta != 0 && leftBound.PrevInAEL.WindDelta != 0)
			{
				OutPt op = AddOutPt(leftBound.PrevInAEL, leftBound.Bot);
				AddJoin(outPt, op, leftBound.Top);
			}
			if (leftBound.NextInAEL == rightBound)
			{
				continue;
			}
			if (rightBound.OutIdx >= 0 && rightBound.PrevInAEL.OutIdx >= 0 && ClipperBase.SlopesEqual(rightBound.PrevInAEL, rightBound, m_UseFullRange) && rightBound.WindDelta != 0 && rightBound.PrevInAEL.WindDelta != 0)
			{
				OutPt op2 = AddOutPt(rightBound.PrevInAEL, rightBound.Bot);
				AddJoin(outPt, op2, rightBound.Top);
			}
			TEdge nextInAEL = leftBound.NextInAEL;
			if (nextInAEL != null)
			{
				while (nextInAEL != rightBound)
				{
					IntersectEdges(rightBound, nextInAEL, leftBound.Curr);
					nextInAEL = nextInAEL.NextInAEL;
				}
			}
		}
	}

	private void InsertEdgeIntoAEL(TEdge edge, TEdge startEdge)
	{
		if (m_ActiveEdges == null)
		{
			edge.PrevInAEL = null;
			edge.NextInAEL = null;
			m_ActiveEdges = edge;
			return;
		}
		if (startEdge == null && E2InsertsBeforeE1(m_ActiveEdges, edge))
		{
			edge.PrevInAEL = null;
			edge.NextInAEL = m_ActiveEdges;
			m_ActiveEdges.PrevInAEL = edge;
			m_ActiveEdges = edge;
			return;
		}
		if (startEdge == null)
		{
			startEdge = m_ActiveEdges;
		}
		while (startEdge.NextInAEL != null && !E2InsertsBeforeE1(startEdge.NextInAEL, edge))
		{
			startEdge = startEdge.NextInAEL;
		}
		edge.NextInAEL = startEdge.NextInAEL;
		if (startEdge.NextInAEL != null)
		{
			startEdge.NextInAEL.PrevInAEL = edge;
		}
		edge.PrevInAEL = startEdge;
		startEdge.NextInAEL = edge;
	}

	private bool E2InsertsBeforeE1(TEdge e1, TEdge e2)
	{
		if (e2.Curr.X == e1.Curr.X)
		{
			if (e2.Top.Y > e1.Top.Y)
			{
				return e2.Top.X < TopX(e1, e2.Top.Y);
			}
			return e1.Top.X > TopX(e2, e1.Top.Y);
		}
		return e2.Curr.X < e1.Curr.X;
	}

	private bool IsEvenOddFillType(TEdge edge)
	{
		if (edge.PolyTyp == PolyType.ptSubject)
		{
			return m_SubjFillType == PolyFillType.pftEvenOdd;
		}
		return m_ClipFillType == PolyFillType.pftEvenOdd;
	}

	private bool IsEvenOddAltFillType(TEdge edge)
	{
		if (edge.PolyTyp == PolyType.ptSubject)
		{
			return m_ClipFillType == PolyFillType.pftEvenOdd;
		}
		return m_SubjFillType == PolyFillType.pftEvenOdd;
	}

	private bool IsContributing(TEdge edge)
	{
		PolyFillType polyFillType;
		PolyFillType polyFillType2;
		if (edge.PolyTyp == PolyType.ptSubject)
		{
			polyFillType = m_SubjFillType;
			polyFillType2 = m_ClipFillType;
		}
		else
		{
			polyFillType = m_ClipFillType;
			polyFillType2 = m_SubjFillType;
		}
		switch (polyFillType)
		{
		case PolyFillType.pftEvenOdd:
			if (edge.WindDelta == 0 && edge.WindCnt != 1)
			{
				return false;
			}
			break;
		case PolyFillType.pftNonZero:
			if (Math.Abs(edge.WindCnt) != 1)
			{
				return false;
			}
			break;
		case PolyFillType.pftPositive:
			if (edge.WindCnt != 1)
			{
				return false;
			}
			break;
		default:
			if (edge.WindCnt != -1)
			{
				return false;
			}
			break;
		}
		switch (m_ClipType)
		{
		case ClipType.ctIntersection:
			switch (polyFillType2)
			{
			case PolyFillType.pftEvenOdd:
			case PolyFillType.pftNonZero:
				return edge.WindCnt2 != 0;
			case PolyFillType.pftPositive:
				return edge.WindCnt2 > 0;
			default:
				return edge.WindCnt2 < 0;
			}
		case ClipType.ctUnion:
			switch (polyFillType2)
			{
			case PolyFillType.pftEvenOdd:
			case PolyFillType.pftNonZero:
				return edge.WindCnt2 == 0;
			case PolyFillType.pftPositive:
				return edge.WindCnt2 <= 0;
			default:
				return edge.WindCnt2 >= 0;
			}
		case ClipType.ctDifference:
			if (edge.PolyTyp == PolyType.ptSubject)
			{
				switch (polyFillType2)
				{
				case PolyFillType.pftEvenOdd:
				case PolyFillType.pftNonZero:
					return edge.WindCnt2 == 0;
				case PolyFillType.pftPositive:
					return edge.WindCnt2 <= 0;
				default:
					return edge.WindCnt2 >= 0;
				}
			}
			switch (polyFillType2)
			{
			case PolyFillType.pftEvenOdd:
			case PolyFillType.pftNonZero:
				return edge.WindCnt2 != 0;
			case PolyFillType.pftPositive:
				return edge.WindCnt2 > 0;
			default:
				return edge.WindCnt2 < 0;
			}
		case ClipType.ctXor:
			if (edge.WindDelta == 0)
			{
				switch (polyFillType2)
				{
				case PolyFillType.pftEvenOdd:
				case PolyFillType.pftNonZero:
					return edge.WindCnt2 == 0;
				case PolyFillType.pftPositive:
					return edge.WindCnt2 <= 0;
				default:
					return edge.WindCnt2 >= 0;
				}
			}
			return true;
		default:
			return true;
		}
	}

	private void SetWindingCount(TEdge edge)
	{
		TEdge prevInAEL = edge.PrevInAEL;
		while (prevInAEL != null && (prevInAEL.PolyTyp != edge.PolyTyp || prevInAEL.WindDelta == 0))
		{
			prevInAEL = prevInAEL.PrevInAEL;
		}
		if (prevInAEL == null)
		{
			edge.WindCnt = ((edge.WindDelta == 0) ? 1 : edge.WindDelta);
			edge.WindCnt2 = 0;
			prevInAEL = m_ActiveEdges;
		}
		else if (edge.WindDelta == 0 && m_ClipType != ClipType.ctUnion)
		{
			edge.WindCnt = 1;
			edge.WindCnt2 = prevInAEL.WindCnt2;
			prevInAEL = prevInAEL.NextInAEL;
		}
		else if (IsEvenOddFillType(edge))
		{
			if (edge.WindDelta == 0)
			{
				bool flag = true;
				for (TEdge prevInAEL2 = prevInAEL.PrevInAEL; prevInAEL2 != null; prevInAEL2 = prevInAEL2.PrevInAEL)
				{
					if (prevInAEL2.PolyTyp == prevInAEL.PolyTyp && prevInAEL2.WindDelta != 0)
					{
						flag = !flag;
					}
				}
				edge.WindCnt = ((!flag) ? 1 : 0);
			}
			else
			{
				edge.WindCnt = edge.WindDelta;
			}
			edge.WindCnt2 = prevInAEL.WindCnt2;
			prevInAEL = prevInAEL.NextInAEL;
		}
		else
		{
			if (prevInAEL.WindCnt * prevInAEL.WindDelta < 0)
			{
				if (Math.Abs(prevInAEL.WindCnt) > 1)
				{
					if (prevInAEL.WindDelta * edge.WindDelta < 0)
					{
						edge.WindCnt = prevInAEL.WindCnt;
					}
					else
					{
						edge.WindCnt = prevInAEL.WindCnt + edge.WindDelta;
					}
				}
				else
				{
					edge.WindCnt = ((edge.WindDelta == 0) ? 1 : edge.WindDelta);
				}
			}
			else if (edge.WindDelta == 0)
			{
				edge.WindCnt = ((prevInAEL.WindCnt >= 0) ? (prevInAEL.WindCnt + 1) : (prevInAEL.WindCnt - 1));
			}
			else if (prevInAEL.WindDelta * edge.WindDelta < 0)
			{
				edge.WindCnt = prevInAEL.WindCnt;
			}
			else
			{
				edge.WindCnt = prevInAEL.WindCnt + edge.WindDelta;
			}
			edge.WindCnt2 = prevInAEL.WindCnt2;
			prevInAEL = prevInAEL.NextInAEL;
		}
		if (IsEvenOddAltFillType(edge))
		{
			while (prevInAEL != edge)
			{
				if (prevInAEL.WindDelta != 0)
				{
					edge.WindCnt2 = ((edge.WindCnt2 == 0) ? 1 : 0);
				}
				prevInAEL = prevInAEL.NextInAEL;
			}
		}
		else
		{
			while (prevInAEL != edge)
			{
				edge.WindCnt2 += prevInAEL.WindDelta;
				prevInAEL = prevInAEL.NextInAEL;
			}
		}
	}

	private void AddEdgeToSEL(TEdge edge)
	{
		if (m_SortedEdges == null)
		{
			m_SortedEdges = edge;
			edge.PrevInSEL = null;
			edge.NextInSEL = null;
		}
		else
		{
			edge.NextInSEL = m_SortedEdges;
			edge.PrevInSEL = null;
			m_SortedEdges.PrevInSEL = edge;
			m_SortedEdges = edge;
		}
	}

	private void CopyAELToSEL()
	{
		for (TEdge tEdge = (m_SortedEdges = m_ActiveEdges); tEdge != null; tEdge = tEdge.NextInAEL)
		{
			tEdge.PrevInSEL = tEdge.PrevInAEL;
			tEdge.NextInSEL = tEdge.NextInAEL;
		}
	}

	private void SwapPositionsInAEL(TEdge edge1, TEdge edge2)
	{
		if (edge1.NextInAEL == edge1.PrevInAEL || edge2.NextInAEL == edge2.PrevInAEL)
		{
			return;
		}
		if (edge1.NextInAEL == edge2)
		{
			TEdge nextInAEL = edge2.NextInAEL;
			if (nextInAEL != null)
			{
				nextInAEL.PrevInAEL = edge1;
			}
			TEdge prevInAEL = edge1.PrevInAEL;
			if (prevInAEL != null)
			{
				prevInAEL.NextInAEL = edge2;
			}
			edge2.PrevInAEL = prevInAEL;
			edge2.NextInAEL = edge1;
			edge1.PrevInAEL = edge2;
			edge1.NextInAEL = nextInAEL;
		}
		else if (edge2.NextInAEL == edge1)
		{
			TEdge nextInAEL2 = edge1.NextInAEL;
			if (nextInAEL2 != null)
			{
				nextInAEL2.PrevInAEL = edge2;
			}
			TEdge prevInAEL2 = edge2.PrevInAEL;
			if (prevInAEL2 != null)
			{
				prevInAEL2.NextInAEL = edge1;
			}
			edge1.PrevInAEL = prevInAEL2;
			edge1.NextInAEL = edge2;
			edge2.PrevInAEL = edge1;
			edge2.NextInAEL = nextInAEL2;
		}
		else
		{
			TEdge nextInAEL3 = edge1.NextInAEL;
			TEdge prevInAEL3 = edge1.PrevInAEL;
			edge1.NextInAEL = edge2.NextInAEL;
			if (edge1.NextInAEL != null)
			{
				edge1.NextInAEL.PrevInAEL = edge1;
			}
			edge1.PrevInAEL = edge2.PrevInAEL;
			if (edge1.PrevInAEL != null)
			{
				edge1.PrevInAEL.NextInAEL = edge1;
			}
			edge2.NextInAEL = nextInAEL3;
			if (edge2.NextInAEL != null)
			{
				edge2.NextInAEL.PrevInAEL = edge2;
			}
			edge2.PrevInAEL = prevInAEL3;
			if (edge2.PrevInAEL != null)
			{
				edge2.PrevInAEL.NextInAEL = edge2;
			}
		}
		if (edge1.PrevInAEL == null)
		{
			m_ActiveEdges = edge1;
		}
		else if (edge2.PrevInAEL == null)
		{
			m_ActiveEdges = edge2;
		}
	}

	private void SwapPositionsInSEL(TEdge edge1, TEdge edge2)
	{
		if ((edge1.NextInSEL == null && edge1.PrevInSEL == null) || (edge2.NextInSEL == null && edge2.PrevInSEL == null))
		{
			return;
		}
		if (edge1.NextInSEL == edge2)
		{
			TEdge nextInSEL = edge2.NextInSEL;
			if (nextInSEL != null)
			{
				nextInSEL.PrevInSEL = edge1;
			}
			TEdge prevInSEL = edge1.PrevInSEL;
			if (prevInSEL != null)
			{
				prevInSEL.NextInSEL = edge2;
			}
			edge2.PrevInSEL = prevInSEL;
			edge2.NextInSEL = edge1;
			edge1.PrevInSEL = edge2;
			edge1.NextInSEL = nextInSEL;
		}
		else if (edge2.NextInSEL == edge1)
		{
			TEdge nextInSEL2 = edge1.NextInSEL;
			if (nextInSEL2 != null)
			{
				nextInSEL2.PrevInSEL = edge2;
			}
			TEdge prevInSEL2 = edge2.PrevInSEL;
			if (prevInSEL2 != null)
			{
				prevInSEL2.NextInSEL = edge1;
			}
			edge1.PrevInSEL = prevInSEL2;
			edge1.NextInSEL = edge2;
			edge2.PrevInSEL = edge1;
			edge2.NextInSEL = nextInSEL2;
		}
		else
		{
			TEdge nextInSEL3 = edge1.NextInSEL;
			TEdge prevInSEL3 = edge1.PrevInSEL;
			edge1.NextInSEL = edge2.NextInSEL;
			if (edge1.NextInSEL != null)
			{
				edge1.NextInSEL.PrevInSEL = edge1;
			}
			edge1.PrevInSEL = edge2.PrevInSEL;
			if (edge1.PrevInSEL != null)
			{
				edge1.PrevInSEL.NextInSEL = edge1;
			}
			edge2.NextInSEL = nextInSEL3;
			if (edge2.NextInSEL != null)
			{
				edge2.NextInSEL.PrevInSEL = edge2;
			}
			edge2.PrevInSEL = prevInSEL3;
			if (edge2.PrevInSEL != null)
			{
				edge2.PrevInSEL.NextInSEL = edge2;
			}
		}
		if (edge1.PrevInSEL == null)
		{
			m_SortedEdges = edge1;
		}
		else if (edge2.PrevInSEL == null)
		{
			m_SortedEdges = edge2;
		}
	}

	private void AddLocalMaxPoly(TEdge e1, TEdge e2, IntPoint pt)
	{
		AddOutPt(e1, pt);
		if (e1.OutIdx == e2.OutIdx)
		{
			e1.OutIdx = -1;
			e2.OutIdx = -1;
		}
		else if (e1.OutIdx < e2.OutIdx)
		{
			AppendPolygon(e1, e2);
		}
		else
		{
			AppendPolygon(e2, e1);
		}
	}

	private OutPt AddLocalMinPoly(TEdge e1, TEdge e2, IntPoint pt)
	{
		OutPt outPt;
		TEdge tEdge;
		TEdge tEdge2;
		if (ClipperBase.IsHorizontal(e2) || e1.Dx > e2.Dx)
		{
			outPt = AddOutPt(e1, pt);
			e2.OutIdx = e1.OutIdx;
			e1.Side = EdgeSide.esLeft;
			e2.Side = EdgeSide.esRight;
			tEdge = e1;
			tEdge2 = ((tEdge.PrevInAEL != e2) ? tEdge.PrevInAEL : e2.PrevInAEL);
		}
		else
		{
			outPt = AddOutPt(e2, pt);
			e1.OutIdx = e2.OutIdx;
			e1.Side = EdgeSide.esRight;
			e2.Side = EdgeSide.esLeft;
			tEdge = e2;
			tEdge2 = ((tEdge.PrevInAEL != e1) ? tEdge.PrevInAEL : e1.PrevInAEL);
		}
		if (tEdge2 != null && tEdge2.OutIdx >= 0 && TopX(tEdge2, pt.Y) == TopX(tEdge, pt.Y) && ClipperBase.SlopesEqual(tEdge, tEdge2, m_UseFullRange) && tEdge.WindDelta != 0 && tEdge2.WindDelta != 0)
		{
			OutPt op = AddOutPt(tEdge2, pt);
			AddJoin(outPt, op, tEdge.Top);
		}
		return outPt;
	}

	private OutRec CreateOutRec()
	{
		OutRec outRec = new OutRec();
		outRec.Idx = -1;
		outRec.IsHole = false;
		outRec.IsOpen = false;
		outRec.FirstLeft = null;
		outRec.Pts = null;
		outRec.BottomPt = null;
		outRec.PolyNode = null;
		m_PolyOuts.Add(outRec);
		outRec.Idx = m_PolyOuts.Count - 1;
		return outRec;
	}

	private OutPt AddOutPt(TEdge e, IntPoint pt)
	{
		bool flag = e.Side == EdgeSide.esLeft;
		if (e.OutIdx < 0)
		{
			OutRec outRec = CreateOutRec();
			outRec.IsOpen = e.WindDelta == 0;
			OutPt outPt = (outRec.Pts = new OutPt());
			outPt.Idx = outRec.Idx;
			outPt.Pt = pt;
			outPt.Next = outPt;
			outPt.Prev = outPt;
			if (!outRec.IsOpen)
			{
				SetHoleState(e, outRec);
			}
			e.OutIdx = outRec.Idx;
			return outPt;
		}
		OutRec outRec2 = m_PolyOuts[e.OutIdx];
		OutPt pts = outRec2.Pts;
		if (flag && pt == pts.Pt)
		{
			return pts;
		}
		if (!flag && pt == pts.Prev.Pt)
		{
			return pts.Prev;
		}
		OutPt outPt2 = new OutPt();
		outPt2.Idx = outRec2.Idx;
		outPt2.Pt = pt;
		outPt2.Next = pts;
		outPt2.Prev = pts.Prev;
		outPt2.Prev.Next = outPt2;
		pts.Prev = outPt2;
		if (flag)
		{
			outRec2.Pts = outPt2;
		}
		return outPt2;
	}

	internal void SwapPoints(ref IntPoint pt1, ref IntPoint pt2)
	{
		IntPoint intPoint = new IntPoint(pt1);
		pt1 = pt2;
		pt2 = intPoint;
	}

	private bool HorzSegmentsOverlap(IntPoint Pt1a, IntPoint Pt1b, IntPoint Pt2a, IntPoint Pt2b)
	{
		if (Pt1a.X > Pt2a.X == Pt1a.X < Pt2b.X)
		{
			return true;
		}
		if (Pt1b.X > Pt2a.X == Pt1b.X < Pt2b.X)
		{
			return true;
		}
		if (Pt2a.X > Pt1a.X == Pt2a.X < Pt1b.X)
		{
			return true;
		}
		if (Pt2b.X > Pt1a.X == Pt2b.X < Pt1b.X)
		{
			return true;
		}
		if (Pt1a.X == Pt2a.X && Pt1b.X == Pt2b.X)
		{
			return true;
		}
		if (Pt1a.X == Pt2b.X && Pt1b.X == Pt2a.X)
		{
			return true;
		}
		return false;
	}

	private OutPt InsertPolyPtBetween(OutPt p1, OutPt p2, IntPoint pt)
	{
		OutPt outPt = new OutPt();
		outPt.Pt = pt;
		if (p2 == p1.Next)
		{
			p1.Next = outPt;
			p2.Prev = outPt;
			outPt.Next = p2;
			outPt.Prev = p1;
		}
		else
		{
			p2.Next = outPt;
			p1.Prev = outPt;
			outPt.Next = p1;
			outPt.Prev = p2;
		}
		return outPt;
	}

	private void SetHoleState(TEdge e, OutRec outRec)
	{
		bool flag = false;
		for (TEdge prevInAEL = e.PrevInAEL; prevInAEL != null; prevInAEL = prevInAEL.PrevInAEL)
		{
			if (prevInAEL.OutIdx >= 0)
			{
				flag = !flag;
				if (outRec.FirstLeft == null)
				{
					outRec.FirstLeft = m_PolyOuts[prevInAEL.OutIdx];
				}
			}
		}
		if (flag)
		{
			outRec.IsHole = true;
		}
	}

	private double GetDx(IntPoint pt1, IntPoint pt2)
	{
		if (pt1.Y == pt2.Y)
		{
			return -3.4E+38;
		}
		return (double)(pt2.X - pt1.X) / (double)(pt2.Y - pt1.Y);
	}

	private bool FirstIsBottomPt(OutPt btmPt1, OutPt btmPt2)
	{
		OutPt prev = btmPt1.Prev;
		while (prev.Pt == btmPt1.Pt && prev != btmPt1)
		{
			prev = prev.Prev;
		}
		double num = Math.Abs(GetDx(btmPt1.Pt, prev.Pt));
		prev = btmPt1.Next;
		while (prev.Pt == btmPt1.Pt && prev != btmPt1)
		{
			prev = prev.Next;
		}
		double num2 = Math.Abs(GetDx(btmPt1.Pt, prev.Pt));
		prev = btmPt2.Prev;
		while (prev.Pt == btmPt2.Pt && prev != btmPt2)
		{
			prev = prev.Prev;
		}
		double num3 = Math.Abs(GetDx(btmPt2.Pt, prev.Pt));
		prev = btmPt2.Next;
		while (prev.Pt == btmPt2.Pt && prev != btmPt2)
		{
			prev = prev.Next;
		}
		double num4 = Math.Abs(GetDx(btmPt2.Pt, prev.Pt));
		return (num >= num3 && num >= num4) || (num2 >= num3 && num2 >= num4);
	}

	private OutPt GetBottomPt(OutPt pp)
	{
		OutPt outPt = null;
		OutPt next;
		for (next = pp.Next; next != pp; next = next.Next)
		{
			if (next.Pt.Y > pp.Pt.Y)
			{
				pp = next;
				outPt = null;
			}
			else if (next.Pt.Y == pp.Pt.Y && next.Pt.X <= pp.Pt.X)
			{
				if (next.Pt.X < pp.Pt.X)
				{
					outPt = null;
					pp = next;
				}
				else if (next.Next != pp && next.Prev != pp)
				{
					outPt = next;
				}
			}
		}
		if (outPt != null)
		{
			while (outPt != next)
			{
				if (!FirstIsBottomPt(next, outPt))
				{
					pp = outPt;
				}
				outPt = outPt.Next;
				while (outPt.Pt != pp.Pt)
				{
					outPt = outPt.Next;
				}
			}
		}
		return pp;
	}

	private OutRec GetLowermostRec(OutRec outRec1, OutRec outRec2)
	{
		if (outRec1.BottomPt == null)
		{
			outRec1.BottomPt = GetBottomPt(outRec1.Pts);
		}
		if (outRec2.BottomPt == null)
		{
			outRec2.BottomPt = GetBottomPt(outRec2.Pts);
		}
		OutPt bottomPt = outRec1.BottomPt;
		OutPt bottomPt2 = outRec2.BottomPt;
		if (bottomPt.Pt.Y > bottomPt2.Pt.Y)
		{
			return outRec1;
		}
		if (bottomPt.Pt.Y < bottomPt2.Pt.Y)
		{
			return outRec2;
		}
		if (bottomPt.Pt.X < bottomPt2.Pt.X)
		{
			return outRec1;
		}
		if (bottomPt.Pt.X > bottomPt2.Pt.X)
		{
			return outRec2;
		}
		if (bottomPt.Next == bottomPt)
		{
			return outRec2;
		}
		if (bottomPt2.Next == bottomPt2)
		{
			return outRec1;
		}
		if (FirstIsBottomPt(bottomPt, bottomPt2))
		{
			return outRec1;
		}
		return outRec2;
	}

	private bool Param1RightOfParam2(OutRec outRec1, OutRec outRec2)
	{
		do
		{
			outRec1 = outRec1.FirstLeft;
			if (outRec1 == outRec2)
			{
				return true;
			}
		}
		while (outRec1 != null);
		return false;
	}

	private OutRec GetOutRec(int idx)
	{
		OutRec outRec;
		for (outRec = m_PolyOuts[idx]; outRec != m_PolyOuts[outRec.Idx]; outRec = m_PolyOuts[outRec.Idx])
		{
		}
		return outRec;
	}

	private void AppendPolygon(TEdge e1, TEdge e2)
	{
		OutRec outRec = m_PolyOuts[e1.OutIdx];
		OutRec outRec2 = m_PolyOuts[e2.OutIdx];
		OutRec outRec3 = (Param1RightOfParam2(outRec, outRec2) ? outRec2 : ((!Param1RightOfParam2(outRec2, outRec)) ? GetLowermostRec(outRec, outRec2) : outRec));
		OutPt pts = outRec.Pts;
		OutPt prev = pts.Prev;
		OutPt pts2 = outRec2.Pts;
		OutPt prev2 = pts2.Prev;
		EdgeSide side;
		if (e1.Side == EdgeSide.esLeft)
		{
			if (e2.Side == EdgeSide.esLeft)
			{
				ReversePolyPtLinks(pts2);
				pts2.Next = pts;
				pts.Prev = pts2;
				prev.Next = prev2;
				prev2.Prev = prev;
				outRec.Pts = prev2;
			}
			else
			{
				prev2.Next = pts;
				pts.Prev = prev2;
				pts2.Prev = prev;
				prev.Next = pts2;
				outRec.Pts = pts2;
			}
			side = EdgeSide.esLeft;
		}
		else
		{
			if (e2.Side == EdgeSide.esRight)
			{
				ReversePolyPtLinks(pts2);
				prev.Next = prev2;
				prev2.Prev = prev;
				pts2.Next = pts;
				pts.Prev = pts2;
			}
			else
			{
				prev.Next = pts2;
				pts2.Prev = prev;
				pts.Prev = prev2;
				prev2.Next = pts;
			}
			side = EdgeSide.esRight;
		}
		outRec.BottomPt = null;
		if (outRec3 == outRec2)
		{
			if (outRec2.FirstLeft != outRec)
			{
				outRec.FirstLeft = outRec2.FirstLeft;
			}
			outRec.IsHole = outRec2.IsHole;
		}
		outRec2.Pts = null;
		outRec2.BottomPt = null;
		outRec2.FirstLeft = outRec;
		int outIdx = e1.OutIdx;
		int outIdx2 = e2.OutIdx;
		e1.OutIdx = -1;
		e2.OutIdx = -1;
		for (TEdge tEdge = m_ActiveEdges; tEdge != null; tEdge = tEdge.NextInAEL)
		{
			if (tEdge.OutIdx == outIdx2)
			{
				tEdge.OutIdx = outIdx;
				tEdge.Side = side;
				break;
			}
		}
		outRec2.Idx = outRec.Idx;
	}

	private void ReversePolyPtLinks(OutPt pp)
	{
		if (pp != null)
		{
			OutPt outPt = pp;
			do
			{
				OutPt next = outPt.Next;
				outPt.Next = outPt.Prev;
				outPt.Prev = next;
				outPt = next;
			}
			while (outPt != pp);
		}
	}

	private static void SwapSides(TEdge edge1, TEdge edge2)
	{
		EdgeSide side = edge1.Side;
		edge1.Side = edge2.Side;
		edge2.Side = side;
	}

	private static void SwapPolyIndexes(TEdge edge1, TEdge edge2)
	{
		int outIdx = edge1.OutIdx;
		edge1.OutIdx = edge2.OutIdx;
		edge2.OutIdx = outIdx;
	}

	private void IntersectEdges(TEdge e1, TEdge e2, IntPoint pt, bool protect = false)
	{
		bool flag = !protect && e1.NextInLML == null && e1.Top.X == pt.X && e1.Top.Y == pt.Y;
		bool flag2 = !protect && e2.NextInLML == null && e2.Top.X == pt.X && e2.Top.Y == pt.Y;
		bool flag3 = e1.OutIdx >= 0;
		bool flag4 = e2.OutIdx >= 0;
		if (e1.PolyTyp == e2.PolyTyp)
		{
			if (IsEvenOddFillType(e1))
			{
				int windCnt = e1.WindCnt;
				e1.WindCnt = e2.WindCnt;
				e2.WindCnt = windCnt;
			}
			else
			{
				if (e1.WindCnt + e2.WindDelta == 0)
				{
					e1.WindCnt = -e1.WindCnt;
				}
				else
				{
					e1.WindCnt += e2.WindDelta;
				}
				if (e2.WindCnt - e1.WindDelta == 0)
				{
					e2.WindCnt = -e2.WindCnt;
				}
				else
				{
					e2.WindCnt -= e1.WindDelta;
				}
			}
		}
		else
		{
			if (!IsEvenOddFillType(e2))
			{
				e1.WindCnt2 += e2.WindDelta;
			}
			else
			{
				e1.WindCnt2 = ((e1.WindCnt2 == 0) ? 1 : 0);
			}
			if (!IsEvenOddFillType(e1))
			{
				e2.WindCnt2 -= e1.WindDelta;
			}
			else
			{
				e2.WindCnt2 = ((e2.WindCnt2 == 0) ? 1 : 0);
			}
		}
		PolyFillType polyFillType;
		PolyFillType polyFillType2;
		if (e1.PolyTyp == PolyType.ptSubject)
		{
			polyFillType = m_SubjFillType;
			polyFillType2 = m_ClipFillType;
		}
		else
		{
			polyFillType = m_ClipFillType;
			polyFillType2 = m_SubjFillType;
		}
		PolyFillType polyFillType3;
		PolyFillType polyFillType4;
		if (e2.PolyTyp == PolyType.ptSubject)
		{
			polyFillType3 = m_SubjFillType;
			polyFillType4 = m_ClipFillType;
		}
		else
		{
			polyFillType3 = m_ClipFillType;
			polyFillType4 = m_SubjFillType;
		}
		int num = polyFillType switch
		{
			PolyFillType.pftPositive => e1.WindCnt, 
			PolyFillType.pftNegative => -e1.WindCnt, 
			_ => Math.Abs(e1.WindCnt), 
		};
		int num2 = polyFillType3 switch
		{
			PolyFillType.pftPositive => e2.WindCnt, 
			PolyFillType.pftNegative => -e2.WindCnt, 
			_ => Math.Abs(e2.WindCnt), 
		};
		if (flag3 && flag4)
		{
			if (flag || flag2 || (num != 0 && num != 1) || (num2 != 0 && num2 != 1) || (e1.PolyTyp != e2.PolyTyp && m_ClipType != ClipType.ctXor))
			{
				AddLocalMaxPoly(e1, e2, pt);
			}
			else
			{
				AddOutPt(e1, pt);
				AddOutPt(e2, pt);
				SwapSides(e1, e2);
				SwapPolyIndexes(e1, e2);
			}
		}
		else if (flag3)
		{
			if (num2 == 0 || num2 == 1)
			{
				AddOutPt(e1, pt);
				SwapSides(e1, e2);
				SwapPolyIndexes(e1, e2);
			}
		}
		else if (flag4)
		{
			if (num == 0 || num == 1)
			{
				AddOutPt(e2, pt);
				SwapSides(e1, e2);
				SwapPolyIndexes(e1, e2);
			}
		}
		else if ((num == 0 || num == 1) && (num2 == 0 || num2 == 1) && !flag && !flag2)
		{
			long num3 = polyFillType2 switch
			{
				PolyFillType.pftPositive => e1.WindCnt2, 
				PolyFillType.pftNegative => -e1.WindCnt2, 
				_ => Math.Abs(e1.WindCnt2), 
			};
			long num4 = polyFillType4 switch
			{
				PolyFillType.pftPositive => e2.WindCnt2, 
				PolyFillType.pftNegative => -e2.WindCnt2, 
				_ => Math.Abs(e2.WindCnt2), 
			};
			if (e1.PolyTyp != e2.PolyTyp)
			{
				AddLocalMinPoly(e1, e2, pt);
			}
			else if (num == 1 && num2 == 1)
			{
				switch (m_ClipType)
				{
				case ClipType.ctIntersection:
					if (num3 > 0 && num4 > 0)
					{
						AddLocalMinPoly(e1, e2, pt);
					}
					break;
				case ClipType.ctUnion:
					if (num3 <= 0 && num4 <= 0)
					{
						AddLocalMinPoly(e1, e2, pt);
					}
					break;
				case ClipType.ctDifference:
					if ((e1.PolyTyp == PolyType.ptClip && num3 > 0 && num4 > 0) || (e1.PolyTyp == PolyType.ptSubject && num3 <= 0 && num4 <= 0))
					{
						AddLocalMinPoly(e1, e2, pt);
					}
					break;
				case ClipType.ctXor:
					AddLocalMinPoly(e1, e2, pt);
					break;
				}
			}
			else
			{
				SwapSides(e1, e2);
			}
		}
		if (flag != flag2 && ((flag && e1.OutIdx >= 0) || (flag2 && e2.OutIdx >= 0)))
		{
			SwapSides(e1, e2);
			SwapPolyIndexes(e1, e2);
		}
		if (flag)
		{
			DeleteFromAEL(e1);
		}
		if (flag2)
		{
			DeleteFromAEL(e2);
		}
	}

	private void DeleteFromAEL(TEdge e)
	{
		TEdge prevInAEL = e.PrevInAEL;
		TEdge nextInAEL = e.NextInAEL;
		if (prevInAEL != null || nextInAEL != null || e == m_ActiveEdges)
		{
			if (prevInAEL != null)
			{
				prevInAEL.NextInAEL = nextInAEL;
			}
			else
			{
				m_ActiveEdges = nextInAEL;
			}
			if (nextInAEL != null)
			{
				nextInAEL.PrevInAEL = prevInAEL;
			}
			e.NextInAEL = null;
			e.PrevInAEL = null;
		}
	}

	private void DeleteFromSEL(TEdge e)
	{
		TEdge prevInSEL = e.PrevInSEL;
		TEdge nextInSEL = e.NextInSEL;
		if (prevInSEL != null || nextInSEL != null || e == m_SortedEdges)
		{
			if (prevInSEL != null)
			{
				prevInSEL.NextInSEL = nextInSEL;
			}
			else
			{
				m_SortedEdges = nextInSEL;
			}
			if (nextInSEL != null)
			{
				nextInSEL.PrevInSEL = prevInSEL;
			}
			e.NextInSEL = null;
			e.PrevInSEL = null;
		}
	}

	private void UpdateEdgeIntoAEL(ref TEdge e)
	{
		if (e.NextInLML == null)
		{
			throw new ClipperException("UpdateEdgeIntoAEL: invalid call");
		}
		TEdge prevInAEL = e.PrevInAEL;
		TEdge nextInAEL = e.NextInAEL;
		e.NextInLML.OutIdx = e.OutIdx;
		if (prevInAEL != null)
		{
			prevInAEL.NextInAEL = e.NextInLML;
		}
		else
		{
			m_ActiveEdges = e.NextInLML;
		}
		if (nextInAEL != null)
		{
			nextInAEL.PrevInAEL = e.NextInLML;
		}
		e.NextInLML.Side = e.Side;
		e.NextInLML.WindDelta = e.WindDelta;
		e.NextInLML.WindCnt = e.WindCnt;
		e.NextInLML.WindCnt2 = e.WindCnt2;
		e = e.NextInLML;
		e.Curr = e.Bot;
		e.PrevInAEL = prevInAEL;
		e.NextInAEL = nextInAEL;
		if (!ClipperBase.IsHorizontal(e))
		{
			InsertScanbeam(e.Top.Y);
		}
	}

	private void ProcessHorizontals(bool isTopOfScanbeam)
	{
		for (TEdge sortedEdges = m_SortedEdges; sortedEdges != null; sortedEdges = m_SortedEdges)
		{
			DeleteFromSEL(sortedEdges);
			ProcessHorizontal(sortedEdges, isTopOfScanbeam);
		}
	}

	private void GetHorzDirection(TEdge HorzEdge, out Direction Dir, out long Left, out long Right)
	{
		if (HorzEdge.Bot.X < HorzEdge.Top.X)
		{
			Left = HorzEdge.Bot.X;
			Right = HorzEdge.Top.X;
			Dir = Direction.dLeftToRight;
		}
		else
		{
			Left = HorzEdge.Top.X;
			Right = HorzEdge.Bot.X;
			Dir = Direction.dRightToLeft;
		}
	}

	private void PrepareHorzJoins(TEdge horzEdge, bool isTopOfScanbeam)
	{
		OutPt outPt = m_PolyOuts[horzEdge.OutIdx].Pts;
		if (horzEdge.Side != EdgeSide.esLeft)
		{
			outPt = outPt.Prev;
		}
		for (int i = 0; i < m_GhostJoins.Count; i++)
		{
			Join obj = m_GhostJoins[i];
			if (HorzSegmentsOverlap(obj.OutPt1.Pt, obj.OffPt, horzEdge.Bot, horzEdge.Top))
			{
				AddJoin(obj.OutPt1, outPt, obj.OffPt);
			}
		}
		if (isTopOfScanbeam)
		{
			if (outPt.Pt == horzEdge.Top)
			{
				AddGhostJoin(outPt, horzEdge.Bot);
			}
			else
			{
				AddGhostJoin(outPt, horzEdge.Top);
			}
		}
	}

	private void ProcessHorizontal(TEdge horzEdge, bool isTopOfScanbeam)
	{
		GetHorzDirection(horzEdge, out var Dir, out var Left, out var Right);
		TEdge tEdge = horzEdge;
		TEdge tEdge2 = null;
		while (tEdge.NextInLML != null && ClipperBase.IsHorizontal(tEdge.NextInLML))
		{
			tEdge = tEdge.NextInLML;
		}
		if (tEdge.NextInLML == null)
		{
			tEdge2 = GetMaximaPair(tEdge);
		}
		while (true)
		{
			bool flag = horzEdge == tEdge;
			TEdge tEdge3 = GetNextInAEL(horzEdge, Dir);
			while (tEdge3 != null && (tEdge3.Curr.X != horzEdge.Top.X || horzEdge.NextInLML == null || !(tEdge3.Dx < horzEdge.NextInLML.Dx)))
			{
				TEdge nextInAEL = GetNextInAEL(tEdge3, Dir);
				if ((Dir == Direction.dLeftToRight && tEdge3.Curr.X <= Right) || (Dir == Direction.dRightToLeft && tEdge3.Curr.X >= Left))
				{
					if (tEdge3 == tEdge2 && flag)
					{
						if (horzEdge.OutIdx >= 0 && horzEdge.WindDelta != 0)
						{
							PrepareHorzJoins(horzEdge, isTopOfScanbeam);
						}
						if (Dir == Direction.dLeftToRight)
						{
							IntersectEdges(horzEdge, tEdge3, tEdge3.Top);
						}
						else
						{
							IntersectEdges(tEdge3, horzEdge, tEdge3.Top);
						}
						if (tEdge2.OutIdx >= 0)
						{
							throw new ClipperException("ProcessHorizontal error");
						}
						return;
					}
					if (Dir != Direction.dLeftToRight)
					{
						IntersectEdges(pt: new IntPoint(tEdge3.Curr.X, horzEdge.Curr.Y), e1: tEdge3, e2: horzEdge, protect: true);
					}
					else
					{
						IntersectEdges(pt: new IntPoint(tEdge3.Curr.X, horzEdge.Curr.Y), e1: horzEdge, e2: tEdge3, protect: true);
					}
					SwapPositionsInAEL(horzEdge, tEdge3);
				}
				else if ((Dir == Direction.dLeftToRight && tEdge3.Curr.X >= Right) || (Dir == Direction.dRightToLeft && tEdge3.Curr.X <= Left))
				{
					break;
				}
				tEdge3 = nextInAEL;
			}
			if (horzEdge.OutIdx >= 0 && horzEdge.WindDelta != 0)
			{
				PrepareHorzJoins(horzEdge, isTopOfScanbeam);
			}
			if (horzEdge.NextInLML != null && ClipperBase.IsHorizontal(horzEdge.NextInLML))
			{
				UpdateEdgeIntoAEL(ref horzEdge);
				if (horzEdge.OutIdx >= 0)
				{
					AddOutPt(horzEdge, horzEdge.Bot);
				}
				GetHorzDirection(horzEdge, out Dir, out Left, out Right);
				continue;
			}
			break;
		}
		if (horzEdge.NextInLML != null)
		{
			if (horzEdge.OutIdx >= 0)
			{
				OutPt op = AddOutPt(horzEdge, horzEdge.Top);
				UpdateEdgeIntoAEL(ref horzEdge);
				if (horzEdge.WindDelta != 0)
				{
					TEdge prevInAEL = horzEdge.PrevInAEL;
					TEdge nextInAEL2 = horzEdge.NextInAEL;
					if (prevInAEL != null && prevInAEL.Curr.X == horzEdge.Bot.X && prevInAEL.Curr.Y == horzEdge.Bot.Y && prevInAEL.WindDelta != 0 && prevInAEL.OutIdx >= 0 && prevInAEL.Curr.Y > prevInAEL.Top.Y && ClipperBase.SlopesEqual(horzEdge, prevInAEL, m_UseFullRange))
					{
						OutPt op2 = AddOutPt(prevInAEL, horzEdge.Bot);
						AddJoin(op, op2, horzEdge.Top);
					}
					else if (nextInAEL2 != null && nextInAEL2.Curr.X == horzEdge.Bot.X && nextInAEL2.Curr.Y == horzEdge.Bot.Y && nextInAEL2.WindDelta != 0 && nextInAEL2.OutIdx >= 0 && nextInAEL2.Curr.Y > nextInAEL2.Top.Y && ClipperBase.SlopesEqual(horzEdge, nextInAEL2, m_UseFullRange))
					{
						OutPt op3 = AddOutPt(nextInAEL2, horzEdge.Bot);
						AddJoin(op, op3, horzEdge.Top);
					}
				}
			}
			else
			{
				UpdateEdgeIntoAEL(ref horzEdge);
			}
		}
		else if (tEdge2 != null)
		{
			if (tEdge2.OutIdx >= 0)
			{
				if (Dir == Direction.dLeftToRight)
				{
					IntersectEdges(horzEdge, tEdge2, horzEdge.Top);
				}
				else
				{
					IntersectEdges(tEdge2, horzEdge, horzEdge.Top);
				}
				if (tEdge2.OutIdx >= 0)
				{
					throw new ClipperException("ProcessHorizontal error");
				}
			}
			else
			{
				DeleteFromAEL(horzEdge);
				DeleteFromAEL(tEdge2);
			}
		}
		else
		{
			if (horzEdge.OutIdx >= 0)
			{
				AddOutPt(horzEdge, horzEdge.Top);
			}
			DeleteFromAEL(horzEdge);
		}
	}

	private TEdge GetNextInAEL(TEdge e, Direction Direction)
	{
		return (Direction != Direction.dLeftToRight) ? e.PrevInAEL : e.NextInAEL;
	}

	private bool IsMinima(TEdge e)
	{
		return e != null && e.Prev.NextInLML != e && e.Next.NextInLML != e;
	}

	private bool IsMaxima(TEdge e, double Y)
	{
		return e != null && (double)e.Top.Y == Y && e.NextInLML == null;
	}

	private bool IsIntermediate(TEdge e, double Y)
	{
		return (double)e.Top.Y == Y && e.NextInLML != null;
	}

	private TEdge GetMaximaPair(TEdge e)
	{
		TEdge tEdge = null;
		if (e.Next.Top == e.Top && e.Next.NextInLML == null)
		{
			tEdge = e.Next;
		}
		else if (e.Prev.Top == e.Top && e.Prev.NextInLML == null)
		{
			tEdge = e.Prev;
		}
		if (tEdge != null && (tEdge.OutIdx == -2 || (tEdge.NextInAEL == tEdge.PrevInAEL && !ClipperBase.IsHorizontal(tEdge))))
		{
			return null;
		}
		return tEdge;
	}

	private bool ProcessIntersections(long botY, long topY)
	{
		if (m_ActiveEdges == null)
		{
			return true;
		}
		try
		{
			BuildIntersectList(botY, topY);
			if (m_IntersectNodes == null)
			{
				return true;
			}
			if (m_IntersectNodes.Next != null && !FixupIntersectionOrder())
			{
				return false;
			}
			ProcessIntersectList();
		}
		catch
		{
			m_SortedEdges = null;
			DisposeIntersectNodes();
			throw new ClipperException("ProcessIntersections error");
		}
		m_SortedEdges = null;
		return true;
	}

	private void BuildIntersectList(long botY, long topY)
	{
		if (m_ActiveEdges == null)
		{
			return;
		}
		for (TEdge tEdge = (m_SortedEdges = m_ActiveEdges); tEdge != null; tEdge = tEdge.NextInAEL)
		{
			tEdge.PrevInSEL = tEdge.PrevInAEL;
			tEdge.NextInSEL = tEdge.NextInAEL;
			tEdge.Curr.X = TopX(tEdge, topY);
		}
		bool flag = true;
		while (flag && m_SortedEdges != null)
		{
			flag = false;
			TEdge tEdge = m_SortedEdges;
			while (tEdge.NextInSEL != null)
			{
				TEdge nextInSEL = tEdge.NextInSEL;
				if (tEdge.Curr.X > nextInSEL.Curr.X)
				{
					if (!IntersectPoint(tEdge, nextInSEL, out var ip) && tEdge.Curr.X > nextInSEL.Curr.X + 1)
					{
						throw new ClipperException("Intersection error");
					}
					if (ip.Y > botY)
					{
						ip.Y = botY;
						if (Math.Abs(tEdge.Dx) > Math.Abs(nextInSEL.Dx))
						{
							ip.X = TopX(nextInSEL, botY);
						}
						else
						{
							ip.X = TopX(tEdge, botY);
						}
					}
					InsertIntersectNode(tEdge, nextInSEL, ip);
					SwapPositionsInSEL(tEdge, nextInSEL);
					flag = true;
				}
				else
				{
					tEdge = nextInSEL;
				}
			}
			if (tEdge.PrevInSEL != null)
			{
				tEdge.PrevInSEL.NextInSEL = null;
				continue;
			}
			break;
		}
		m_SortedEdges = null;
	}

	private bool EdgesAdjacent(IntersectNode inode)
	{
		return inode.Edge1.NextInSEL == inode.Edge2 || inode.Edge1.PrevInSEL == inode.Edge2;
	}

	private bool FixupIntersectionOrder()
	{
		IntersectNode intersectNode = m_IntersectNodes;
		CopyAELToSEL();
		while (intersectNode != null)
		{
			if (!EdgesAdjacent(intersectNode))
			{
				IntersectNode next = intersectNode.Next;
				while (next != null && !EdgesAdjacent(next))
				{
					next = next.Next;
				}
				if (next == null)
				{
					return false;
				}
				SwapIntersectNodes(intersectNode, next);
			}
			SwapPositionsInSEL(intersectNode.Edge1, intersectNode.Edge2);
			intersectNode = intersectNode.Next;
		}
		return true;
	}

	private void ProcessIntersectList()
	{
		while (m_IntersectNodes != null)
		{
			IntersectNode next = m_IntersectNodes.Next;
			IntersectEdges(m_IntersectNodes.Edge1, m_IntersectNodes.Edge2, m_IntersectNodes.Pt, protect: true);
			SwapPositionsInAEL(m_IntersectNodes.Edge1, m_IntersectNodes.Edge2);
			m_IntersectNodes = null;
			m_IntersectNodes = next;
		}
	}

	internal static long Round(double value)
	{
		return (!(value < 0.0)) ? ((long)(value + 0.5)) : ((long)(value - 0.5));
	}

	private static long TopX(TEdge edge, long currentY)
	{
		if (currentY == edge.Top.Y)
		{
			return edge.Top.X;
		}
		return edge.Bot.X + Round(edge.Dx * (double)(currentY - edge.Bot.Y));
	}

	private void InsertIntersectNode(TEdge e1, TEdge e2, IntPoint pt)
	{
		IntersectNode intersectNode = new IntersectNode();
		intersectNode.Edge1 = e1;
		intersectNode.Edge2 = e2;
		intersectNode.Pt = pt;
		intersectNode.Next = null;
		if (m_IntersectNodes == null)
		{
			m_IntersectNodes = intersectNode;
			return;
		}
		if (intersectNode.Pt.Y > m_IntersectNodes.Pt.Y)
		{
			intersectNode.Next = m_IntersectNodes;
			m_IntersectNodes = intersectNode;
			return;
		}
		IntersectNode intersectNode2 = m_IntersectNodes;
		while (intersectNode2.Next != null && intersectNode.Pt.Y < intersectNode2.Next.Pt.Y)
		{
			intersectNode2 = intersectNode2.Next;
		}
		intersectNode.Next = intersectNode2.Next;
		intersectNode2.Next = intersectNode;
	}

	private void SwapIntersectNodes(IntersectNode int1, IntersectNode int2)
	{
		TEdge edge = int1.Edge1;
		TEdge edge2 = int1.Edge2;
		IntPoint pt = new IntPoint(int1.Pt);
		int1.Edge1 = int2.Edge1;
		int1.Edge2 = int2.Edge2;
		int1.Pt = int2.Pt;
		int2.Edge1 = edge;
		int2.Edge2 = edge2;
		int2.Pt = pt;
	}

	private bool IntersectPoint(TEdge edge1, TEdge edge2, out IntPoint ip)
	{
		ip = default(IntPoint);
		if (ClipperBase.SlopesEqual(edge1, edge2, m_UseFullRange) || edge1.Dx == edge2.Dx)
		{
			if (edge2.Bot.Y > edge1.Bot.Y)
			{
				ip.Y = edge2.Bot.Y;
			}
			else
			{
				ip.Y = edge1.Bot.Y;
			}
			return false;
		}
		if (edge1.Delta.X == 0)
		{
			ip.X = edge1.Bot.X;
			if (ClipperBase.IsHorizontal(edge2))
			{
				ip.Y = edge2.Bot.Y;
			}
			else
			{
				double num = (double)edge2.Bot.Y - (double)edge2.Bot.X / edge2.Dx;
				ip.Y = Round((double)ip.X / edge2.Dx + num);
			}
		}
		else if (edge2.Delta.X == 0)
		{
			ip.X = edge2.Bot.X;
			if (ClipperBase.IsHorizontal(edge1))
			{
				ip.Y = edge1.Bot.Y;
			}
			else
			{
				double num2 = (double)edge1.Bot.Y - (double)edge1.Bot.X / edge1.Dx;
				ip.Y = Round((double)ip.X / edge1.Dx + num2);
			}
		}
		else
		{
			double num2 = (double)edge1.Bot.X - (double)edge1.Bot.Y * edge1.Dx;
			double num = (double)edge2.Bot.X - (double)edge2.Bot.Y * edge2.Dx;
			double num3 = (num - num2) / (edge1.Dx - edge2.Dx);
			ip.Y = Round(num3);
			if (Math.Abs(edge1.Dx) < Math.Abs(edge2.Dx))
			{
				ip.X = Round(edge1.Dx * num3 + num2);
			}
			else
			{
				ip.X = Round(edge2.Dx * num3 + num);
			}
		}
		if (ip.Y < edge1.Top.Y || ip.Y < edge2.Top.Y)
		{
			if (edge1.Top.Y > edge2.Top.Y)
			{
				ip.Y = edge1.Top.Y;
				ip.X = TopX(edge2, edge1.Top.Y);
				return ip.X < edge1.Top.X;
			}
			ip.Y = edge2.Top.Y;
			ip.X = TopX(edge1, edge2.Top.Y);
			return ip.X > edge2.Top.X;
		}
		return true;
	}

	private void DisposeIntersectNodes()
	{
		while (m_IntersectNodes != null)
		{
			IntersectNode next = m_IntersectNodes.Next;
			m_IntersectNodes = null;
			m_IntersectNodes = next;
		}
	}

	private void ProcessEdgesAtTopOfScanbeam(long topY)
	{
		TEdge e = m_ActiveEdges;
		while (e != null)
		{
			bool flag = IsMaxima(e, topY);
			if (flag)
			{
				TEdge maximaPair = GetMaximaPair(e);
				flag = maximaPair == null || !ClipperBase.IsHorizontal(maximaPair);
			}
			if (flag)
			{
				TEdge prevInAEL = e.PrevInAEL;
				DoMaxima(e);
				e = ((prevInAEL != null) ? prevInAEL.NextInAEL : m_ActiveEdges);
				continue;
			}
			if (IsIntermediate(e, topY) && ClipperBase.IsHorizontal(e.NextInLML))
			{
				UpdateEdgeIntoAEL(ref e);
				if (e.OutIdx >= 0)
				{
					AddOutPt(e, e.Bot);
				}
				AddEdgeToSEL(e);
			}
			else
			{
				e.Curr.X = TopX(e, topY);
				e.Curr.Y = topY;
			}
			if (StrictlySimple)
			{
				TEdge prevInAEL2 = e.PrevInAEL;
				if (e.OutIdx >= 0 && e.WindDelta != 0 && prevInAEL2 != null && prevInAEL2.OutIdx >= 0 && prevInAEL2.Curr.X == e.Curr.X && prevInAEL2.WindDelta != 0)
				{
					OutPt op = AddOutPt(prevInAEL2, e.Curr);
					OutPt op2 = AddOutPt(e, e.Curr);
					AddJoin(op, op2, e.Curr);
				}
			}
			e = e.NextInAEL;
		}
		ProcessHorizontals(isTopOfScanbeam: true);
		for (e = m_ActiveEdges; e != null; e = e.NextInAEL)
		{
			if (IsIntermediate(e, topY))
			{
				OutPt outPt = null;
				if (e.OutIdx >= 0)
				{
					outPt = AddOutPt(e, e.Top);
				}
				UpdateEdgeIntoAEL(ref e);
				TEdge prevInAEL3 = e.PrevInAEL;
				TEdge nextInAEL = e.NextInAEL;
				if (prevInAEL3 != null && prevInAEL3.Curr.X == e.Bot.X && prevInAEL3.Curr.Y == e.Bot.Y && outPt != null && prevInAEL3.OutIdx >= 0 && prevInAEL3.Curr.Y > prevInAEL3.Top.Y && ClipperBase.SlopesEqual(e, prevInAEL3, m_UseFullRange) && e.WindDelta != 0 && prevInAEL3.WindDelta != 0)
				{
					OutPt op3 = AddOutPt(prevInAEL3, e.Bot);
					AddJoin(outPt, op3, e.Top);
				}
				else if (nextInAEL != null && nextInAEL.Curr.X == e.Bot.X && nextInAEL.Curr.Y == e.Bot.Y && outPt != null && nextInAEL.OutIdx >= 0 && nextInAEL.Curr.Y > nextInAEL.Top.Y && ClipperBase.SlopesEqual(e, nextInAEL, m_UseFullRange) && e.WindDelta != 0 && nextInAEL.WindDelta != 0)
				{
					OutPt op4 = AddOutPt(nextInAEL, e.Bot);
					AddJoin(outPt, op4, e.Top);
				}
			}
		}
	}

	private void DoMaxima(TEdge e)
	{
		TEdge maximaPair = GetMaximaPair(e);
		if (maximaPair == null)
		{
			if (e.OutIdx >= 0)
			{
				AddOutPt(e, e.Top);
			}
			DeleteFromAEL(e);
			return;
		}
		TEdge nextInAEL = e.NextInAEL;
		while (nextInAEL != null && nextInAEL != maximaPair)
		{
			IntersectEdges(e, nextInAEL, e.Top, protect: true);
			SwapPositionsInAEL(e, nextInAEL);
			nextInAEL = e.NextInAEL;
		}
		if (e.OutIdx == -1 && maximaPair.OutIdx == -1)
		{
			DeleteFromAEL(e);
			DeleteFromAEL(maximaPair);
			return;
		}
		if (e.OutIdx >= 0 && maximaPair.OutIdx >= 0)
		{
			IntersectEdges(e, maximaPair, e.Top);
			return;
		}
		throw new ClipperException("DoMaxima error");
	}

	public static void ReversePaths(List<List<IntPoint>> polys)
	{
		polys.ForEach(delegate(List<IntPoint> poly)
		{
			poly.Reverse();
		});
	}

	public static bool Orientation(List<IntPoint> poly)
	{
		return Area(poly) >= 0.0;
	}

	private int PointCount(OutPt pts)
	{
		if (pts == null)
		{
			return 0;
		}
		int num = 0;
		OutPt outPt = pts;
		do
		{
			num++;
			outPt = outPt.Next;
		}
		while (outPt != pts);
		return num;
	}

	private void BuildResult(List<List<IntPoint>> polyg)
	{
		polyg.Clear();
		polyg.Capacity = m_PolyOuts.Count;
		for (int i = 0; i < m_PolyOuts.Count; i++)
		{
			OutRec outRec = m_PolyOuts[i];
			if (outRec.Pts == null)
			{
				continue;
			}
			OutPt outPt = outRec.Pts;
			int num = PointCount(outPt);
			if (num >= 2)
			{
				List<IntPoint> list = new List<IntPoint>(num);
				for (int j = 0; j < num; j++)
				{
					list.Add(outPt.Pt);
					outPt = outPt.Prev;
				}
				polyg.Add(list);
			}
		}
	}

	private void BuildResult2(PolyTree polytree)
	{
		polytree.Clear();
		polytree.m_AllPolys.Capacity = m_PolyOuts.Count;
		for (int i = 0; i < m_PolyOuts.Count; i++)
		{
			OutRec outRec = m_PolyOuts[i];
			int num = PointCount(outRec.Pts);
			if ((!outRec.IsOpen || num >= 2) && (outRec.IsOpen || num >= 3))
			{
				FixHoleLinkage(outRec);
				PolyNode polyNode = new PolyNode();
				polytree.m_AllPolys.Add(polyNode);
				outRec.PolyNode = polyNode;
				polyNode.m_polygon.Capacity = num;
				OutPt prev = outRec.Pts.Prev;
				for (int j = 0; j < num; j++)
				{
					polyNode.m_polygon.Add(prev.Pt);
					prev = prev.Prev;
				}
			}
		}
		polytree.m_Childs.Capacity = m_PolyOuts.Count;
		for (int k = 0; k < m_PolyOuts.Count; k++)
		{
			OutRec outRec2 = m_PolyOuts[k];
			if (outRec2.PolyNode != null)
			{
				if (outRec2.IsOpen)
				{
					outRec2.PolyNode.IsOpen = true;
					polytree.AddChild(outRec2.PolyNode);
				}
				else if (outRec2.FirstLeft != null)
				{
					outRec2.FirstLeft.PolyNode.AddChild(outRec2.PolyNode);
				}
				else
				{
					polytree.AddChild(outRec2.PolyNode);
				}
			}
		}
	}

	private void FixupOutPolygon(OutRec outRec)
	{
		OutPt outPt = null;
		outRec.BottomPt = null;
		OutPt outPt2 = outRec.Pts;
		while (true)
		{
			if (outPt2.Prev == outPt2 || outPt2.Prev == outPt2.Next)
			{
				DisposeOutPts(outPt2);
				outRec.Pts = null;
				return;
			}
			if (outPt2.Pt == outPt2.Next.Pt || outPt2.Pt == outPt2.Prev.Pt || (ClipperBase.SlopesEqual(outPt2.Prev.Pt, outPt2.Pt, outPt2.Next.Pt, m_UseFullRange) && (!base.PreserveCollinear || !Pt2IsBetweenPt1AndPt3(outPt2.Prev.Pt, outPt2.Pt, outPt2.Next.Pt))))
			{
				outPt = null;
				OutPt outPt3 = outPt2;
				outPt2.Prev.Next = outPt2.Next;
				outPt2.Next.Prev = outPt2.Prev;
				outPt2 = outPt2.Prev;
				outPt3 = null;
				continue;
			}
			if (outPt2 == outPt)
			{
				break;
			}
			if (outPt == null)
			{
				outPt = outPt2;
			}
			outPt2 = outPt2.Next;
		}
		outRec.Pts = outPt2;
	}

	private OutPt DupOutPt(OutPt outPt, bool InsertAfter)
	{
		OutPt outPt2 = new OutPt();
		outPt2.Pt = outPt.Pt;
		outPt2.Idx = outPt.Idx;
		if (InsertAfter)
		{
			outPt2.Next = outPt.Next;
			outPt2.Prev = outPt;
			outPt.Next.Prev = outPt2;
			outPt.Next = outPt2;
		}
		else
		{
			outPt2.Prev = outPt.Prev;
			outPt2.Next = outPt;
			outPt.Prev.Next = outPt2;
			outPt.Prev = outPt2;
		}
		return outPt2;
	}

	private bool GetOverlap(long a1, long a2, long b1, long b2, out long Left, out long Right)
	{
		if (a1 < a2)
		{
			if (b1 < b2)
			{
				Left = Math.Max(a1, b1);
				Right = Math.Min(a2, b2);
			}
			else
			{
				Left = Math.Max(a1, b2);
				Right = Math.Min(a2, b1);
			}
		}
		else if (b1 < b2)
		{
			Left = Math.Max(a2, b1);
			Right = Math.Min(a1, b2);
		}
		else
		{
			Left = Math.Max(a2, b2);
			Right = Math.Min(a1, b1);
		}
		return Left < Right;
	}

	private bool JoinHorz(OutPt op1, OutPt op1b, OutPt op2, OutPt op2b, IntPoint Pt, bool DiscardLeft)
	{
		Direction direction = ((op1.Pt.X <= op1b.Pt.X) ? Direction.dLeftToRight : Direction.dRightToLeft);
		Direction direction2 = ((op2.Pt.X <= op2b.Pt.X) ? Direction.dLeftToRight : Direction.dRightToLeft);
		if (direction == direction2)
		{
			return false;
		}
		if (direction == Direction.dLeftToRight)
		{
			while (op1.Next.Pt.X <= Pt.X && op1.Next.Pt.X >= op1.Pt.X && op1.Next.Pt.Y == Pt.Y)
			{
				op1 = op1.Next;
			}
			if (DiscardLeft && op1.Pt.X != Pt.X)
			{
				op1 = op1.Next;
			}
			op1b = DupOutPt(op1, !DiscardLeft);
			if (op1b.Pt != Pt)
			{
				op1 = op1b;
				op1.Pt = Pt;
				op1b = DupOutPt(op1, !DiscardLeft);
			}
		}
		else
		{
			while (op1.Next.Pt.X >= Pt.X && op1.Next.Pt.X <= op1.Pt.X && op1.Next.Pt.Y == Pt.Y)
			{
				op1 = op1.Next;
			}
			if (!DiscardLeft && op1.Pt.X != Pt.X)
			{
				op1 = op1.Next;
			}
			op1b = DupOutPt(op1, DiscardLeft);
			if (op1b.Pt != Pt)
			{
				op1 = op1b;
				op1.Pt = Pt;
				op1b = DupOutPt(op1, DiscardLeft);
			}
		}
		if (direction2 == Direction.dLeftToRight)
		{
			while (op2.Next.Pt.X <= Pt.X && op2.Next.Pt.X >= op2.Pt.X && op2.Next.Pt.Y == Pt.Y)
			{
				op2 = op2.Next;
			}
			if (DiscardLeft && op2.Pt.X != Pt.X)
			{
				op2 = op2.Next;
			}
			op2b = DupOutPt(op2, !DiscardLeft);
			if (op2b.Pt != Pt)
			{
				op2 = op2b;
				op2.Pt = Pt;
				op2b = DupOutPt(op2, !DiscardLeft);
			}
		}
		else
		{
			while (op2.Next.Pt.X >= Pt.X && op2.Next.Pt.X <= op2.Pt.X && op2.Next.Pt.Y == Pt.Y)
			{
				op2 = op2.Next;
			}
			if (!DiscardLeft && op2.Pt.X != Pt.X)
			{
				op2 = op2.Next;
			}
			op2b = DupOutPt(op2, DiscardLeft);
			if (op2b.Pt != Pt)
			{
				op2 = op2b;
				op2.Pt = Pt;
				op2b = DupOutPt(op2, DiscardLeft);
			}
		}
		if (direction == Direction.dLeftToRight == DiscardLeft)
		{
			op1.Prev = op2;
			op2.Next = op1;
			op1b.Next = op2b;
			op2b.Prev = op1b;
		}
		else
		{
			op1.Next = op2;
			op2.Prev = op1;
			op1b.Prev = op2b;
			op2b.Next = op1b;
		}
		return true;
	}

	private bool JoinPoints(Join j, out OutPt p1, out OutPt p2)
	{
		OutRec outRec = GetOutRec(j.OutPt1.Idx);
		OutRec outRec2 = GetOutRec(j.OutPt2.Idx);
		OutPt outPt = j.OutPt1;
		OutPt outPt2 = j.OutPt2;
		p1 = null;
		p2 = null;
		bool flag = j.OutPt1.Pt.Y == j.OffPt.Y;
		OutPt next;
		OutPt next2;
		if (flag && j.OffPt == j.OutPt1.Pt && j.OffPt == j.OutPt2.Pt)
		{
			next = j.OutPt1.Next;
			while (next != outPt && next.Pt == j.OffPt)
			{
				next = next.Next;
			}
			bool flag2 = next.Pt.Y > j.OffPt.Y;
			next2 = j.OutPt2.Next;
			while (next2 != outPt2 && next2.Pt == j.OffPt)
			{
				next2 = next2.Next;
			}
			bool flag3 = next2.Pt.Y > j.OffPt.Y;
			if (flag2 == flag3)
			{
				return false;
			}
			if (flag2)
			{
				next = DupOutPt(outPt, InsertAfter: false);
				next2 = DupOutPt(outPt2, InsertAfter: true);
				outPt.Prev = outPt2;
				outPt2.Next = outPt;
				next.Next = next2;
				next2.Prev = next;
				p1 = outPt;
				p2 = next;
				return true;
			}
			next = DupOutPt(outPt, InsertAfter: true);
			next2 = DupOutPt(outPt2, InsertAfter: false);
			outPt.Next = outPt2;
			outPt2.Prev = outPt;
			next.Prev = next2;
			next2.Next = next;
			p1 = outPt;
			p2 = next;
			return true;
		}
		if (flag)
		{
			next = outPt;
			while (outPt.Prev.Pt.Y == outPt.Pt.Y && outPt.Prev != next && outPt.Prev != outPt2)
			{
				outPt = outPt.Prev;
			}
			while (next.Next.Pt.Y == next.Pt.Y && next.Next != outPt && next.Next != outPt2)
			{
				next = next.Next;
			}
			if (next.Next == outPt || next.Next == outPt2)
			{
				return false;
			}
			next2 = outPt2;
			while (outPt2.Prev.Pt.Y == outPt2.Pt.Y && outPt2.Prev != next2 && outPt2.Prev != next)
			{
				outPt2 = outPt2.Prev;
			}
			while (next2.Next.Pt.Y == next2.Pt.Y && next2.Next != outPt2 && next2.Next != outPt)
			{
				next2 = next2.Next;
			}
			if (next2.Next == outPt2 || next2.Next == outPt)
			{
				return false;
			}
			if (!GetOverlap(outPt.Pt.X, next.Pt.X, outPt2.Pt.X, next2.Pt.X, out var Left, out var Right))
			{
				return false;
			}
			IntPoint pt;
			bool discardLeft;
			if (outPt.Pt.X >= Left && outPt.Pt.X <= Right)
			{
				pt = outPt.Pt;
				discardLeft = outPt.Pt.X > next.Pt.X;
			}
			else if (outPt2.Pt.X >= Left && outPt2.Pt.X <= Right)
			{
				pt = outPt2.Pt;
				discardLeft = outPt2.Pt.X > next2.Pt.X;
			}
			else if (next.Pt.X >= Left && next.Pt.X <= Right)
			{
				pt = next.Pt;
				discardLeft = next.Pt.X > outPt.Pt.X;
			}
			else
			{
				pt = next2.Pt;
				discardLeft = next2.Pt.X > outPt2.Pt.X;
			}
			p1 = outPt;
			p2 = outPt2;
			return JoinHorz(outPt, next, outPt2, next2, pt, discardLeft);
		}
		next = outPt.Next;
		while (next.Pt == outPt.Pt && next != outPt)
		{
			next = next.Next;
		}
		bool flag4 = next.Pt.Y > outPt.Pt.Y || !ClipperBase.SlopesEqual(outPt.Pt, next.Pt, j.OffPt, m_UseFullRange);
		if (flag4)
		{
			next = outPt.Prev;
			while (next.Pt == outPt.Pt && next != outPt)
			{
				next = next.Prev;
			}
			if (next.Pt.Y > outPt.Pt.Y || !ClipperBase.SlopesEqual(outPt.Pt, next.Pt, j.OffPt, m_UseFullRange))
			{
				return false;
			}
		}
		next2 = outPt2.Next;
		while (next2.Pt == outPt2.Pt && next2 != outPt2)
		{
			next2 = next2.Next;
		}
		bool flag5 = next2.Pt.Y > outPt2.Pt.Y || !ClipperBase.SlopesEqual(outPt2.Pt, next2.Pt, j.OffPt, m_UseFullRange);
		if (flag5)
		{
			next2 = outPt2.Prev;
			while (next2.Pt == outPt2.Pt && next2 != outPt2)
			{
				next2 = next2.Prev;
			}
			if (next2.Pt.Y > outPt2.Pt.Y || !ClipperBase.SlopesEqual(outPt2.Pt, next2.Pt, j.OffPt, m_UseFullRange))
			{
				return false;
			}
		}
		if (next == outPt || next2 == outPt2 || next == next2 || (outRec == outRec2 && flag4 == flag5))
		{
			return false;
		}
		if (flag4)
		{
			next = DupOutPt(outPt, InsertAfter: false);
			next2 = DupOutPt(outPt2, InsertAfter: true);
			outPt.Prev = outPt2;
			outPt2.Next = outPt;
			next.Next = next2;
			next2.Prev = next;
			p1 = outPt;
			p2 = next;
			return true;
		}
		next = DupOutPt(outPt, InsertAfter: true);
		next2 = DupOutPt(outPt2, InsertAfter: false);
		outPt.Next = outPt2;
		outPt2.Prev = outPt;
		next.Prev = next2;
		next2.Next = next;
		p1 = outPt;
		p2 = next;
		return true;
	}

	private bool Poly2ContainsPoly1(OutPt outPt1, OutPt outPt2, bool UseFullRange)
	{
		OutPt outPt3 = outPt1;
		if (PointOnPolygon(outPt3.Pt, outPt2, UseFullRange))
		{
			outPt3 = outPt3.Next;
			while (outPt3 != outPt1 && PointOnPolygon(outPt3.Pt, outPt2, UseFullRange))
			{
				outPt3 = outPt3.Next;
			}
			if (outPt3 == outPt1)
			{
				return true;
			}
		}
		return PointInPolygon(outPt3.Pt, outPt2, UseFullRange);
	}

	private void FixupFirstLefts1(OutRec OldOutRec, OutRec NewOutRec)
	{
		for (int i = 0; i < m_PolyOuts.Count; i++)
		{
			OutRec outRec = m_PolyOuts[i];
			if (outRec.Pts != null && outRec.FirstLeft == OldOutRec && Poly2ContainsPoly1(outRec.Pts, NewOutRec.Pts, m_UseFullRange))
			{
				outRec.FirstLeft = NewOutRec;
			}
		}
	}

	private void FixupFirstLefts2(OutRec OldOutRec, OutRec NewOutRec)
	{
		foreach (OutRec polyOut in m_PolyOuts)
		{
			if (polyOut.FirstLeft == OldOutRec)
			{
				polyOut.FirstLeft = NewOutRec;
			}
		}
	}

	private void JoinCommonEdges()
	{
		for (int i = 0; i < m_Joins.Count; i++)
		{
			Join obj = m_Joins[i];
			OutRec outRec = GetOutRec(obj.OutPt1.Idx);
			OutRec outRec2 = GetOutRec(obj.OutPt2.Idx);
			if (outRec.Pts == null || outRec2.Pts == null)
			{
				continue;
			}
			OutRec outRec3 = ((outRec == outRec2) ? outRec : (Param1RightOfParam2(outRec, outRec2) ? outRec2 : ((!Param1RightOfParam2(outRec2, outRec)) ? GetLowermostRec(outRec, outRec2) : outRec)));
			if (!JoinPoints(obj, out var p, out var p2))
			{
				continue;
			}
			if (outRec == outRec2)
			{
				outRec.Pts = p;
				outRec.BottomPt = null;
				outRec2 = CreateOutRec();
				outRec2.Pts = p2;
				UpdateOutPtIdxs(outRec2);
				if (Poly2ContainsPoly1(outRec2.Pts, outRec.Pts, m_UseFullRange))
				{
					outRec2.IsHole = !outRec.IsHole;
					outRec2.FirstLeft = outRec;
					if (m_UsingPolyTree)
					{
						FixupFirstLefts2(outRec2, outRec);
					}
					if ((outRec2.IsHole ^ ReverseSolution) == Area(outRec2) > 0.0)
					{
						ReversePolyPtLinks(outRec2.Pts);
					}
				}
				else if (Poly2ContainsPoly1(outRec.Pts, outRec2.Pts, m_UseFullRange))
				{
					outRec2.IsHole = outRec.IsHole;
					outRec.IsHole = !outRec2.IsHole;
					outRec2.FirstLeft = outRec.FirstLeft;
					outRec.FirstLeft = outRec2;
					if (m_UsingPolyTree)
					{
						FixupFirstLefts2(outRec, outRec2);
					}
					if ((outRec.IsHole ^ ReverseSolution) == Area(outRec) > 0.0)
					{
						ReversePolyPtLinks(outRec.Pts);
					}
				}
				else
				{
					outRec2.IsHole = outRec.IsHole;
					outRec2.FirstLeft = outRec.FirstLeft;
					if (m_UsingPolyTree)
					{
						FixupFirstLefts1(outRec, outRec2);
					}
				}
			}
			else
			{
				outRec2.Pts = null;
				outRec2.BottomPt = null;
				outRec2.Idx = outRec.Idx;
				outRec.IsHole = outRec3.IsHole;
				if (outRec3 == outRec2)
				{
					outRec.FirstLeft = outRec2.FirstLeft;
				}
				outRec2.FirstLeft = outRec;
				if (m_UsingPolyTree)
				{
					FixupFirstLefts2(outRec2, outRec);
				}
			}
		}
	}

	private void UpdateOutPtIdxs(OutRec outrec)
	{
		OutPt outPt = outrec.Pts;
		do
		{
			outPt.Idx = outrec.Idx;
			outPt = outPt.Prev;
		}
		while (outPt != outrec.Pts);
	}

	private void DoSimplePolygons()
	{
		int num = 0;
		while (num < m_PolyOuts.Count)
		{
			OutRec outRec = m_PolyOuts[num++];
			OutPt outPt = outRec.Pts;
			if (outPt == null)
			{
				continue;
			}
			do
			{
				for (OutPt outPt2 = outPt.Next; outPt2 != outRec.Pts; outPt2 = outPt2.Next)
				{
					if (outPt.Pt == outPt2.Pt && outPt2.Next != outPt && outPt2.Prev != outPt)
					{
						OutPt prev = outPt.Prev;
						(outPt.Prev = outPt2.Prev).Next = outPt;
						outPt2.Prev = prev;
						prev.Next = outPt2;
						outRec.Pts = outPt;
						OutRec outRec2 = CreateOutRec();
						outRec2.Pts = outPt2;
						UpdateOutPtIdxs(outRec2);
						if (Poly2ContainsPoly1(outRec2.Pts, outRec.Pts, m_UseFullRange))
						{
							outRec2.IsHole = !outRec.IsHole;
							outRec2.FirstLeft = outRec;
						}
						else if (Poly2ContainsPoly1(outRec.Pts, outRec2.Pts, m_UseFullRange))
						{
							outRec2.IsHole = outRec.IsHole;
							outRec.IsHole = !outRec2.IsHole;
							outRec2.FirstLeft = outRec.FirstLeft;
							outRec.FirstLeft = outRec2;
						}
						else
						{
							outRec2.IsHole = outRec.IsHole;
							outRec2.FirstLeft = outRec.FirstLeft;
						}
						outPt2 = outPt;
					}
				}
				outPt = outPt.Next;
			}
			while (outPt != outRec.Pts);
		}
	}

	public static double Area(List<IntPoint> poly)
	{
		int num = poly.Count - 1;
		if (num < 2)
		{
			return 0.0;
		}
		double num2 = ((double)poly[num].X + (double)poly[0].X) * ((double)poly[0].Y - (double)poly[num].Y);
		for (int i = 1; i <= num; i++)
		{
			num2 += ((double)poly[i - 1].X + (double)poly[i].X) * ((double)poly[i].Y - (double)poly[i - 1].Y);
		}
		return num2 / 2.0;
	}

	private double Area(OutRec outRec)
	{
		OutPt outPt = outRec.Pts;
		if (outPt == null)
		{
			return 0.0;
		}
		double num = 0.0;
		do
		{
			num += (double)(outPt.Pt.X + outPt.Prev.Pt.X) * (double)(outPt.Prev.Pt.Y - outPt.Pt.Y);
			outPt = outPt.Next;
		}
		while (outPt != outRec.Pts);
		return num / 2.0;
	}

	internal static DoublePoint GetUnitNormal(IntPoint pt1, IntPoint pt2)
	{
		double num = pt2.X - pt1.X;
		double num2 = pt2.Y - pt1.Y;
		if (num == 0.0 && num2 == 0.0)
		{
			return default(DoublePoint);
		}
		double num3 = 1.0 / Math.Sqrt(num * num + num2 * num2);
		num *= num3;
		num2 *= num3;
		return new DoublePoint(num2, 0.0 - num);
	}

	internal static bool UpdateBotPt(IntPoint pt, ref IntPoint botPt)
	{
		if (pt.Y > botPt.Y || (pt.Y == botPt.Y && pt.X < botPt.X))
		{
			botPt = pt;
			return true;
		}
		return false;
	}

	internal static bool StripDupsAndGetBotPt(List<IntPoint> in_path, List<IntPoint> out_path, bool closed, out IntPoint botPt)
	{
		botPt = new IntPoint(0L, 0L);
		int num = in_path.Count;
		if (closed)
		{
			while (num > 0 && in_path[0] == in_path[num - 1])
			{
				num--;
			}
		}
		if (num == 0)
		{
			return false;
		}
		out_path.Capacity = num;
		int num2 = 0;
		out_path.Add(in_path[0]);
		botPt = in_path[0];
		for (int i = 1; i < num; i++)
		{
			if (in_path[i] != out_path[num2])
			{
				out_path.Add(in_path[i]);
				num2++;
				if (out_path[num2].Y > botPt.Y || (out_path[num2].Y == botPt.Y && out_path[num2].X < botPt.X))
				{
					botPt = out_path[num2];
				}
			}
		}
		num2++;
		if (num2 < 2 || (closed && num2 == 2))
		{
			num2 = 0;
		}
		while (out_path.Count > num2)
		{
			out_path.RemoveAt(num2);
		}
		return num2 > 0;
	}

	public static List<List<IntPoint>> OffsetPaths(List<List<IntPoint>> polys, double delta, JoinType jointype, EndType endtype, double MiterLimit)
	{
		List<List<IntPoint>> list = new List<List<IntPoint>>(polys.Count);
		IntPoint intPoint = default(IntPoint);
		int num = -1;
		for (int i = 0; i < polys.Count; i++)
		{
			list.Add(new List<IntPoint>());
			if (StripDupsAndGetBotPt(polys[i], list[i], endtype == EndType.etClosed, out var botPt) && (num < 0 || botPt.Y > intPoint.Y || (botPt.Y == intPoint.Y && botPt.X < intPoint.X)))
			{
				intPoint = botPt;
				num = i;
			}
		}
		if (endtype == EndType.etClosed && num >= 0 && !Orientation(list[num]))
		{
			ReversePaths(list);
		}
		new PolyOffsetBuilder(list, out var solution, delta, jointype, endtype, MiterLimit);
		return solution;
	}

	public static List<List<IntPoint>> OffsetPolygons(List<List<IntPoint>> poly, double delta, JoinType jointype, double MiterLimit, bool AutoFix)
	{
		return OffsetPaths(poly, delta, jointype, EndType.etClosed, MiterLimit);
	}

	public static List<List<IntPoint>> OffsetPolygons(List<List<IntPoint>> poly, double delta, JoinType jointype, double MiterLimit)
	{
		return OffsetPaths(poly, delta, jointype, EndType.etClosed, MiterLimit);
	}

	public static List<List<IntPoint>> OffsetPolygons(List<List<IntPoint>> polys, double delta, JoinType jointype)
	{
		return OffsetPaths(polys, delta, jointype, EndType.etClosed, 0.0);
	}

	public static List<List<IntPoint>> OffsetPolygons(List<List<IntPoint>> polys, double delta)
	{
		return OffsetPolygons(polys, delta, JoinType.jtSquare, 0.0, AutoFix: true);
	}

	public static void ReversePolygons(List<List<IntPoint>> polys)
	{
		polys.ForEach(delegate(List<IntPoint> poly)
		{
			poly.Reverse();
		});
	}

	public static void PolyTreeToPolygons(PolyTree polytree, List<List<IntPoint>> polys)
	{
		polys.Clear();
		polys.Capacity = polytree.Total;
		AddPolyNodeToPaths(polytree, NodeType.ntAny, polys);
	}

	public static List<List<IntPoint>> SimplifyPolygon(List<IntPoint> poly, PolyFillType fillType = PolyFillType.pftEvenOdd)
	{
		List<List<IntPoint>> list = new List<List<IntPoint>>();
		Clipper clipper = new Clipper();
		clipper.StrictlySimple = true;
		clipper.AddPath(poly, PolyType.ptSubject, Closed: true);
		clipper.Execute(ClipType.ctUnion, list, fillType, fillType);
		return list;
	}

	public static List<List<IntPoint>> SimplifyPolygons(List<List<IntPoint>> polys, PolyFillType fillType = PolyFillType.pftEvenOdd)
	{
		List<List<IntPoint>> list = new List<List<IntPoint>>();
		Clipper clipper = new Clipper();
		clipper.StrictlySimple = true;
		clipper.AddPaths(polys, PolyType.ptSubject, closed: true);
		clipper.Execute(ClipType.ctUnion, list, fillType, fillType);
		return list;
	}

	private static double DistanceSqrd(IntPoint pt1, IntPoint pt2)
	{
		double num = (double)pt1.X - (double)pt2.X;
		double num2 = (double)pt1.Y - (double)pt2.Y;
		return num * num + num2 * num2;
	}

	private static DoublePoint ClosestPointOnLine(IntPoint pt, IntPoint linePt1, IntPoint linePt2)
	{
		double num = (double)linePt2.X - (double)linePt1.X;
		double num2 = (double)linePt2.Y - (double)linePt1.Y;
		if (num == 0.0 && num2 == 0.0)
		{
			return new DoublePoint(linePt1.X, linePt1.Y);
		}
		double num3 = ((double)(pt.X - linePt1.X) * num + (double)(pt.Y - linePt1.Y) * num2) / (num * num + num2 * num2);
		return new DoublePoint((1.0 - num3) * (double)linePt1.X + num3 * (double)linePt2.X, (1.0 - num3) * (double)linePt1.Y + num3 * (double)linePt2.Y);
	}

	private static bool SlopesNearCollinear(IntPoint pt1, IntPoint pt2, IntPoint pt3, double distSqrd)
	{
		if (DistanceSqrd(pt1, pt2) > DistanceSqrd(pt1, pt3))
		{
			return false;
		}
		DoublePoint doublePoint = ClosestPointOnLine(pt2, pt1, pt3);
		double num = (double)pt2.X - doublePoint.X;
		double num2 = (double)pt2.Y - doublePoint.Y;
		return num * num + num2 * num2 < distSqrd;
	}

	private static bool PointsAreClose(IntPoint pt1, IntPoint pt2, double distSqrd)
	{
		double num = (double)pt1.X - (double)pt2.X;
		double num2 = (double)pt1.Y - (double)pt2.Y;
		return num * num + num2 * num2 <= distSqrd;
	}

	public static List<IntPoint> CleanPolygon(List<IntPoint> path, double distance = 1.415)
	{
		double distSqrd = distance * distance;
		int num = path.Count - 1;
		List<IntPoint> list = new List<IntPoint>(num + 1);
		while (num > 0 && PointsAreClose(path[num], path[0], distSqrd))
		{
			num--;
		}
		if (num < 2)
		{
			return list;
		}
		IntPoint intPoint = path[num];
		int i = 0;
		while (true)
		{
			if (i < num && PointsAreClose(intPoint, path[i], distSqrd))
			{
				i += 2;
				continue;
			}
			int num2 = i;
			for (; i < num && (PointsAreClose(path[i], path[i + 1], distSqrd) || SlopesNearCollinear(intPoint, path[i], path[i + 1], distSqrd)); i++)
			{
			}
			if (i >= num)
			{
				break;
			}
			if (i == num2)
			{
				intPoint = path[i++];
				list.Add(intPoint);
			}
		}
		if (i <= num)
		{
			list.Add(path[i]);
		}
		i = list.Count;
		if (i > 2 && SlopesNearCollinear(list[i - 2], list[i - 1], list[0], distSqrd))
		{
			list.RemoveAt(i - 1);
		}
		if (list.Count < 3)
		{
			list.Clear();
		}
		return list;
	}

	internal static List<List<IntPoint>> Minkowki(List<IntPoint> poly, List<IntPoint> path, bool IsSum, bool IsClosed)
	{
		int num = (IsClosed ? 1 : 0);
		int count = poly.Count;
		int count2 = path.Count;
		List<List<IntPoint>> list = new List<List<IntPoint>>(count2);
		if (IsSum)
		{
			for (int i = 0; i < count2; i++)
			{
				List<IntPoint> list2 = new List<IntPoint>(count);
				foreach (IntPoint item in poly)
				{
					list2.Add(new IntPoint(path[i].X + item.X, path[i].Y + item.Y));
				}
				list.Add(list2);
			}
		}
		else
		{
			for (int j = 0; j < count2; j++)
			{
				List<IntPoint> list3 = new List<IntPoint>(count);
				foreach (IntPoint item2 in poly)
				{
					list3.Add(new IntPoint(path[j].X - item2.X, path[j].Y - item2.Y));
				}
				list.Add(list3);
			}
		}
		List<List<IntPoint>> list4 = new List<List<IntPoint>>((count2 + num) * (count + 1));
		for (int k = 0; k <= count2 - 2 + num; k++)
		{
			for (int l = 0; l <= count - 1; l++)
			{
				List<IntPoint> list5 = new List<IntPoint>(4);
				list5.Add(list[k % count2][l % count]);
				list5.Add(list[(k + 1) % count2][l % count]);
				list5.Add(list[(k + 1) % count2][(l + 1) % count]);
				list5.Add(list[k % count2][(l + 1) % count]);
				if (!Orientation(list5))
				{
					list5.Reverse();
				}
				list4.Add(list5);
			}
		}
		Clipper clipper = new Clipper();
		clipper.AddPaths(list4, PolyType.ptSubject, closed: true);
		clipper.Execute(ClipType.ctUnion, list, PolyFillType.pftNonZero, PolyFillType.pftNonZero);
		return list;
	}

	public static List<List<IntPoint>> MinkowkiSum(List<IntPoint> poly, List<IntPoint> path, bool IsClosed)
	{
		return Minkowki(poly, path, IsSum: true, IsClosed);
	}

	public static List<List<IntPoint>> MinkowkiDiff(List<IntPoint> poly, List<IntPoint> path, bool IsClosed)
	{
		return Minkowki(poly, path, IsSum: false, IsClosed);
	}

	public static List<List<IntPoint>> CleanPolygons(List<List<IntPoint>> polys, double distance = 1.415)
	{
		List<List<IntPoint>> list = new List<List<IntPoint>>(polys.Count);
		for (int i = 0; i < polys.Count; i++)
		{
			list.Add(CleanPolygon(polys[i], distance));
		}
		return list;
	}

	public static List<List<IntPoint>> PolyTreeToPaths(PolyTree polytree)
	{
		List<List<IntPoint>> list = new List<List<IntPoint>>();
		list.Capacity = polytree.Total;
		AddPolyNodeToPaths(polytree, NodeType.ntAny, list);
		return list;
	}

	internal static void AddPolyNodeToPaths(PolyNode polynode, NodeType nt, List<List<IntPoint>> paths)
	{
		bool flag = true;
		switch (nt)
		{
		case NodeType.ntOpen:
			return;
		case NodeType.ntClosed:
			flag = !polynode.IsOpen;
			break;
		}
		if (polynode.Contour.Count > 0 && flag)
		{
			paths.Add(polynode.Contour);
		}
		foreach (PolyNode child in polynode.Childs)
		{
			AddPolyNodeToPaths(child, nt, paths);
		}
	}

	public static List<List<IntPoint>> OpenPathsFromPolyTree(PolyTree polytree)
	{
		List<List<IntPoint>> list = new List<List<IntPoint>>();
		list.Capacity = polytree.ChildCount;
		for (int i = 0; i < polytree.ChildCount; i++)
		{
			if (polytree.Childs[i].IsOpen)
			{
				list.Add(polytree.Childs[i].Contour);
			}
		}
		return list;
	}

	public static List<List<IntPoint>> ClosedPathsFromPolyTree(PolyTree polytree)
	{
		List<List<IntPoint>> list = new List<List<IntPoint>>();
		list.Capacity = polytree.Total;
		AddPolyNodeToPaths(polytree, NodeType.ntClosed, list);
		return list;
	}
}
internal class ClipperException : Exception
{
	public ClipperException(string description)
		: base(description)
	{
	}
}
