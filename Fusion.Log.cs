using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using JetBrains.Annotations;
using Microsoft.CodeAnalysis;
using UnityEngine;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETStandard,Version=v2.1", FrameworkDisplayName = ".NET Standard 2.1")]
[assembly: AssemblyCompany("Exit Games GmbH")]
[assembly: AssemblyConfiguration("Unity Release")]
[assembly: AssemblyCopyright("? Exit Games GmbH")]
[assembly: AssemblyFileVersion("2.0.6.1034")]
[assembly: AssemblyInformationalVersion("2.0.6.1034+94e2793d")]
[assembly: AssemblyProduct("Fusion.Log")]
[assembly: AssemblyTitle("Fusion.Log (Unity Release)")]
[assembly: InternalsVisibleTo("Fusion.Common")]
[assembly: InternalsVisibleTo("Fusion.Common.Tests")]
[assembly: InternalsVisibleTo("Fusion.Sockets")]
[assembly: InternalsVisibleTo("Fusion.Sockets.Tests")]
[assembly: InternalsVisibleTo("Fusion.Realtime")]
[assembly: InternalsVisibleTo("Fusion.Runtime")]
[assembly: InternalsVisibleTo("Fusion.Plugin")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("2.0.6.0")]
[module: UnverifiableCode]
[module: RefSafetyRules(11)]
namespace Microsoft.CodeAnalysis
{
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	internal sealed class EmbeddedAttribute : Attribute
	{
	}
}
namespace System.Runtime.CompilerServices
{
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	internal sealed class IsUnmanagedAttribute : Attribute
	{
	}
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	[AttributeUsage(AttributeTargets.Module, AllowMultiple = false, Inherited = false)]
	internal sealed class RefSafetyRulesAttribute : Attribute
	{
		public readonly int Version;

		public RefSafetyRulesAttribute(int P_0)
		{
			Version = P_0;
		}
	}
}
namespace Fusion
{
	public abstract class FusionEditorLog
	{
		private static string s_prefixColor;

		[Conditional("FUSION_EDITOR_TRACE")]
		public static void TraceConfig(string msg)
		{
			UnityEngine.Debug.Log("<color" + s_prefixColor + ">[FusionEditor/Config]</color> " + msg);
		}

		[Conditional("UNITY_EDITOR")]
		public static void WarnConfig(string msg)
		{
			UnityEngine.Debug.LogWarning("<color" + s_prefixColor + ">[FusionEditor/Config]</color> " + msg);
		}

		[Conditional("UNITY_EDITOR")]
		public static void LogConfig(string msg)
		{
			UnityEngine.Debug.Log("<color" + s_prefixColor + ">[FusionEditor/Config]</color> " + msg);
		}

		[Conditional("UNITY_EDITOR")]
		public static void ErrorConfig(string msg)
		{
			UnityEngine.Debug.LogError("<color" + s_prefixColor + ">[FusionEditor/Config]</color> " + msg);
		}

		[Conditional("FUSION_EDITOR_TRACE")]
		public static void TraceInstaller(string msg)
		{
			UnityEngine.Debug.Log("<color" + s_prefixColor + ">[FusionEditor/Installer]</color> " + msg);
		}

		[Conditional("UNITY_EDITOR")]
		public static void WarnInstaller(string msg)
		{
			UnityEngine.Debug.LogWarning("<color" + s_prefixColor + ">[FusionEditor/Installer]</color> " + msg);
		}

		[Conditional("UNITY_EDITOR")]
		public static void LogInstaller(string msg)
		{
			UnityEngine.Debug.Log("<color" + s_prefixColor + ">[FusionEditor/Installer]</color> " + msg);
		}

		[Conditional("UNITY_EDITOR")]
		public static void ErrorInstaller(string msg)
		{
			UnityEngine.Debug.LogError("<color" + s_prefixColor + ">[FusionEditor/Installer]</color> " + msg);
		}

		public static void SetPrefixColor(Color color)
		{
			SetPrefixColor((Color32)color);
		}

		public static void SetPrefixColor(Color32 c)
		{
			s_prefixColor = "=" + Color32ToHex(c);
		}

		private static string Color32ToHex(Color32 color)
		{
			return $"#{(color.r << 16) | (color.g << 8) | color.b:X6}";
		}

		public static void Initialize(bool isDarkMode)
		{
			if (isDarkMode)
			{
				SetPrefixColor(FusionUnityLoggerBase.DefaultDarkPrefixColor);
			}
			else
			{
				SetPrefixColor(FusionUnityLoggerBase.DefaultLightPrefixColor);
			}
		}

		[Conditional("UNITY_ASSERTIONS")]
		[AssertionMethod]
		[ContractAnnotation("condition: false => halt")]
		public static void Assert(bool condition, string message)
		{
		}

		[Conditional("UNITY_ASSERTIONS")]
		[AssertionMethod]
		[ContractAnnotation("condition: false => halt")]
		public static void Assert(bool condition)
		{
		}

		[Conditional("FUSION_EDITOR_TRACE_IMPORT")]
		public static void TraceImport(string assetPath, string msg)
		{
			UnityEngine.Debug.Log("<color" + s_prefixColor + ">[FusionEditor/Import]</color> " + assetPath + ": " + msg);
		}

		[Conditional("UNITY_EDITOR")]
		public static void WarnImport(string assetPath, string msg)
		{
			UnityEngine.Debug.LogWarning("<color" + s_prefixColor + ">[FusionEditor/Import]</color> " + assetPath + ": " + msg);
		}

		[Conditional("UNITY_EDITOR")]
		public static void LogImport(string assetPath, string msg)
		{
			UnityEngine.Debug.Log("<color" + s_prefixColor + ">[FusionEditor/Import]</color> " + assetPath + ": " + msg);
		}

		[Conditional("UNITY_EDITOR")]
		public static void ErrorImport(string assetPath, string msg)
		{
			UnityEngine.Debug.LogError("<color" + s_prefixColor + ">[FusionEditor/Import]</color> " + assetPath + ": " + msg);
		}

		[Conditional("FUSION_EDITOR_TRACE_IMPORT")]
		public static void TraceImport(string msg, UnityEngine.Object asset)
		{
			UnityEngine.Debug.Log("<color" + s_prefixColor + ">[FusionEditor/Import]</color>: " + msg, asset);
		}

		[Conditional("UNITY_EDITOR")]
		public static void WarnImport(string msg, UnityEngine.Object asset)
		{
			UnityEngine.Debug.LogWarning("<color" + s_prefixColor + ">[FusionEditor/Import]</color>: " + msg, asset);
		}

		[Conditional("UNITY_EDITOR")]
		public static void LogImport(string msg, UnityEngine.Object asset)
		{
			UnityEngine.Debug.Log("<color" + s_prefixColor + ">[FusionEditor/Import]</color>: " + msg, asset);
		}

		[Conditional("UNITY_EDITOR")]
		public static void ErrorImport(string msg, UnityEngine.Object asset)
		{
			UnityEngine.Debug.LogError("<color" + s_prefixColor + ">[FusionEditor/Import]</color>: " + msg, asset);
		}

		[Conditional("UNITY_EDITOR")]
		public static void Warn(string msg, UnityEngine.Object obj)
		{
			UnityEngine.Debug.LogWarning("<color" + s_prefixColor + ">[FusionEditor]</color>: " + msg, obj);
		}

		[Conditional("UNITY_EDITOR")]
		public static void Log(string msg, UnityEngine.Object obj)
		{
			UnityEngine.Debug.Log("<color" + s_prefixColor + ">[FusionEditor]</color>: " + msg, obj);
		}

		[Conditional("UNITY_EDITOR")]
		public static void Error(string msg, UnityEngine.Object obj)
		{
			UnityEngine.Debug.LogError("<color" + s_prefixColor + ">[FusionEditor]</color>: " + msg, obj);
		}

		[Conditional("UNITY_EDITOR")]
		public static void Exception(string message, Exception ex)
		{
			UnityEngine.Debug.LogWarning("<color" + s_prefixColor + ">[FusionEditor]</color>: " + message + " <i>See next error log entry for details.</i>");
			ExceptionDispatchInfo edi = ExceptionDispatchInfo.Capture(ex);
			Thread thread = new Thread((ThreadStart)delegate
			{
				edi.Throw();
			});
			thread.Start();
			thread.Join();
		}

		[Conditional("UNITY_EDITOR")]
		public static void Exception(Exception ex)
		{
			UnityEngine.Debug.LogWarning($"<color{s_prefixColor}>[FusionEditor]</color>: {ex.GetType()} <i>See next error log entry for details.</i>");
			ExceptionDispatchInfo edi = ExceptionDispatchInfo.Capture(ex);
			Thread thread = new Thread((ThreadStart)delegate
			{
				edi.Throw();
			});
			thread.Start();
			thread.Join();
		}

		[Conditional("FUSION_EDITOR_TRACE")]
		public static void Trace(string msg)
		{
			UnityEngine.Debug.Log("<color" + s_prefixColor + ">[FusionEditor]</color> " + msg);
		}

		[Conditional("UNITY_EDITOR")]
		public static void Warn(string msg)
		{
			UnityEngine.Debug.LogWarning("<color" + s_prefixColor + ">[FusionEditor]</color> " + msg);
		}

		[Conditional("UNITY_EDITOR")]
		public static void Log(string msg)
		{
			UnityEngine.Debug.Log("<color" + s_prefixColor + ">[FusionEditor]</color> " + msg);
		}

		[Conditional("UNITY_EDITOR")]
		public static void Error(string msg)
		{
			UnityEngine.Debug.LogError("<color" + s_prefixColor + ">[FusionEditor]</color> " + msg);
		}

		[Conditional("FUSION_EDITOR_TRACE_IMPORT")]
		public static void TraceImport(string msg)
		{
			UnityEngine.Debug.Log("<color" + s_prefixColor + ">[FusionEditor/Import]</color> " + msg);
		}

		[Conditional("UNITY_EDITOR")]
		public static void WarnImport(string msg)
		{
			UnityEngine.Debug.LogWarning("<color" + s_prefixColor + ">[FusionEditor/Import]</color> " + msg);
		}

		[Conditional("UNITY_EDITOR")]
		public static void LogImport(string msg)
		{
			UnityEngine.Debug.Log("<color" + s_prefixColor + ">[FusionEditor/Import]</color> " + msg);
		}

		[Conditional("UNITY_EDITOR")]
		public static void ErrorImport(string msg)
		{
			UnityEngine.Debug.LogError("<color" + s_prefixColor + ">[FusionEditor/Import]</color> " + msg);
		}

		[Conditional("FUSION_EDITOR_TRACE_INSPECTOR")]
		public static void TraceInspector(string msg)
		{
			UnityEngine.Debug.Log("<color" + s_prefixColor + ">[FusionEditor/Inspector]</color> " + msg);
		}

		[Conditional("UNITY_EDITOR")]
		public static void WarnInspector(string msg)
		{
			UnityEngine.Debug.LogWarning("<color" + s_prefixColor + ">[FusionEditor/Inspector]</color> " + msg);
		}

		[Conditional("UNITY_EDITOR")]
		public static void LogInspector(string msg)
		{
			UnityEngine.Debug.Log("<color" + s_prefixColor + ">[FusionEditor/Inspector]</color> " + msg);
		}

		[Conditional("UNITY_EDITOR")]
		public static void ErrorInspector(string msg)
		{
			UnityEngine.Debug.LogError("<color" + s_prefixColor + ">[FusionEditor/Inspector]</color> " + msg);
		}

		[Conditional("FUSION_EDITOR_TRACE_TEST")]
		public static void TraceTest(string msg)
		{
			UnityEngine.Debug.Log("<color" + s_prefixColor + ">[FusionEditor/Test]</color> " + msg);
		}

		[Conditional("FUSION_EDITOR_TRACE_MPPM")]
		public static void TraceMppm(string msg)
		{
			UnityEngine.Debug.Log("<color" + s_prefixColor + ">[FusionEditor/Mppm]</color> " + msg);
		}
	}
	public class AssertException : Exception
	{
		public AssertException()
		{
		}

		public AssertException(string msg)
			: base(msg)
		{
		}
	}
	public static class Assert
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[Conditional("DEBUG")]
		[DoesNotReturn]
		public static void Fail()
		{
			throw new AssertException();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[Conditional("DEBUG")]
		[DoesNotReturn]
		public static void Fail(string error)
		{
			throw new AssertException(error);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[Conditional("DEBUG")]
		[DoesNotReturn]
		[StringFormatMethod("format")]
		public static void Fail(string format, params object[] args)
		{
			throw new AssertException(string.Format(format, args));
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[Conditional("DEBUG")]
		[AssertionMethod]
		[ContractAnnotation("condition:null=>halt")]
		public static void Check(object condition)
		{
			if (condition == null)
			{
				throw new AssertException();
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[Conditional("DEBUG")]
		[AssertionMethod]
		[ContractAnnotation("condition:null=>halt")]
		public unsafe static void Check(void* condition)
		{
			if (condition == null)
			{
				throw new AssertException();
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[Conditional("DEBUG")]
		[AssertionMethod]
		[ContractAnnotation("condition:false=>halt")]
		public static void Check([DoesNotReturnIf(false)] bool condition)
		{
			if (!condition)
			{
				throw new AssertException();
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[Conditional("DEBUG")]
		[AssertionMethod]
		[ContractAnnotation("condition:false=>halt")]
		public static void Check([DoesNotReturnIf(false)] bool condition, string error)
		{
			if (!condition)
			{
				throw new AssertException(error);
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[Conditional("DEBUG")]
		[AssertionMethod]
		[ContractAnnotation("condition:false=>halt")]
		[StringFormatMethod("format")]
		public static void Check<T0>([DoesNotReturnIf(false)] bool condition, string format, T0 arg0)
		{
			if (!condition)
			{
				throw new AssertException(string.Format(format, arg0));
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[Conditional("DEBUG")]
		[AssertionMethod]
		[ContractAnnotation("condition:false=>halt")]
		[StringFormatMethod("format")]
		public static void Check<T0, T1>([DoesNotReturnIf(false)] bool condition, string format, T0 arg0, T1 arg1)
		{
			if (!condition)
			{
				throw new AssertException(string.Format(format, arg0, arg1));
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[Conditional("DEBUG")]
		[AssertionMethod]
		[ContractAnnotation("condition:false=>halt")]
		[StringFormatMethod("format")]
		public static void Check<T0, T1, T2>([DoesNotReturnIf(false)] bool condition, string format, T0 arg0, T1 arg1, T2 arg2)
		{
			if (!condition)
			{
				throw new AssertException(string.Format(format, arg0, arg1, arg2));
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[Conditional("DEBUG")]
		[AssertionMethod]
		[ContractAnnotation("condition:false=>halt")]
		[StringFormatMethod("format")]
		public static void Check<T0, T1, T2, T3>([DoesNotReturnIf(false)] bool condition, string format, T0 arg0, T1 arg1, T2 arg2, T3 arg3)
		{
			if (!condition)
			{
				throw new AssertException(string.Format(format, arg0, arg1, arg2, arg3));
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[Conditional("DEBUG")]
		[AssertionMethod]
		[ContractAnnotation("condition:false=>halt")]
		public static void Check<T0>([DoesNotReturnIf(false)] bool condition, T0 arg0)
		{
			if (!condition)
			{
				throw new AssertException($"{arg0}");
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[Conditional("DEBUG")]
		[AssertionMethod]
		[ContractAnnotation("condition:false=>halt")]
		public static void Check<T0, T1>([DoesNotReturnIf(false)] bool condition, T0 arg0, T1 arg1)
		{
			if (!condition)
			{
				throw new AssertException($"arg0:{arg0} arg1:{arg1}");
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[Conditional("DEBUG")]
		[AssertionMethod]
		[ContractAnnotation("condition:false=>halt")]
		public static void Check<T0, T1, T2>([DoesNotReturnIf(false)] bool condition, T0 arg0, T1 arg1, T2 arg2)
		{
			if (!condition)
			{
				throw new AssertException($"arg0:{arg0} arg1:{arg1} arg2:{arg2}");
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[Conditional("DEBUG")]
		[AssertionMethod]
		[ContractAnnotation("condition:false=>halt")]
		public static void Check<T0, T1, T2, T3>([DoesNotReturnIf(false)] bool condition, T0 arg0, T1 arg1, T2 arg2, T3 arg3)
		{
			if (!condition)
			{
				throw new AssertException($"arg0:{arg0} arg1:{arg1} arg2:{arg2} arg3:{arg3}");
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[Conditional("DEBUG")]
		[AssertionMethod]
		[ContractAnnotation("condition:false=>halt")]
		public static void Check<T0, T1, T2, T3, T4>([DoesNotReturnIf(false)] bool condition, T0 arg0, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
		{
			if (!condition)
			{
				throw new AssertException($"arg0:{arg0} arg1:{arg1} arg2:{arg2} arg3:{arg3} arg4:{arg4}");
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[Obsolete("Use overload with a message instead")]
		[DoesNotReturn]
		public static void AlwaysFail()
		{
			throw new AssertException();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DoesNotReturn]
		public static void AlwaysFail(string error)
		{
			throw new AssertException(error);
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DoesNotReturn]
		public static void AlwaysFail(object error)
		{
			throw new AssertException(error?.ToString());
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[DoesNotReturn]
		public static void AlwaysFail<T>(T error) where T : struct
		{
			throw new AssertException(error.ToString());
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[Obsolete("Use overload with a message instead")]
		[ContractAnnotation("condition:false=>halt")]
		[AssertionMethod]
		public static void Always([DoesNotReturnIf(false)] bool condition)
		{
			if (!condition)
			{
				throw new AssertException();
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[ContractAnnotation("condition:false=>halt")]
		[AssertionMethod]
		public static void Always([DoesNotReturnIf(false)] bool condition, string error)
		{
			if (!condition)
			{
				throw new AssertException(error);
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[ContractAnnotation("condition:false=>halt")]
		[AssertionMethod]
		[StringFormatMethod("format")]
		public static void Always<T0>([DoesNotReturnIf(false)] bool condition, string format, T0 arg0)
		{
			if (!condition)
			{
				throw new AssertException(string.Format(format, arg0));
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[ContractAnnotation("condition:false=>halt")]
		[AssertionMethod]
		[StringFormatMethod("format")]
		public static void Always<T0, T1>([DoesNotReturnIf(false)] bool condition, string format, T0 arg0, T1 arg1)
		{
			if (!condition)
			{
				throw new AssertException(string.Format(format, arg0, arg1));
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[ContractAnnotation("condition:false=>halt")]
		[AssertionMethod]
		[StringFormatMethod("format")]
		public static void Always<T0, T1, T2>([DoesNotReturnIf(false)] bool condition, string format, T0 arg0, T1 arg1, T2 arg2)
		{
			if (!condition)
			{
				throw new AssertException(string.Format(format, arg0, arg1, arg2));
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[ContractAnnotation("condition:false=>halt")]
		[AssertionMethod]
		[StringFormatMethod("format")]
		public static void Always<T0, T1, T2, T3>([DoesNotReturnIf(false)] bool condition, string format, T0 arg0, T1 arg1, T2 arg2, T3 arg3)
		{
			if (!condition)
			{
				throw new AssertException(string.Format(format, arg0, arg1, arg2, arg3));
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[ContractAnnotation("condition:false=>halt")]
		[AssertionMethod]
		public static void Always<T0>([DoesNotReturnIf(false)] bool condition, T0 arg0)
		{
			if (!condition)
			{
				throw new AssertException($"arg0:{arg0}");
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[ContractAnnotation("condition:false=>halt")]
		[AssertionMethod]
		public static void Always<T0, T1>([DoesNotReturnIf(false)] bool condition, T0 arg0, T1 arg1)
		{
			if (!condition)
			{
				throw new AssertException($"arg0:{arg0} arg1:{arg1}");
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[ContractAnnotation("condition:false=>halt")]
		[AssertionMethod]
		public static void Always<T0, T1, T2>([DoesNotReturnIf(false)] bool condition, T0 arg0, T1 arg1, T2 arg2)
		{
			if (!condition)
			{
				throw new AssertException($"arg0:{arg0} arg1:{arg1} arg2:{arg2}");
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[ContractAnnotation("condition:false=>halt")]
		[AssertionMethod]
		public static void Always<T0, T1, T2, T3>([DoesNotReturnIf(false)] bool condition, T0 arg0, T1 arg1, T2 arg2, T3 arg3)
		{
			if (!condition)
			{
				throw new AssertException($"arg0:{arg0} arg1:{arg1} arg2:{arg2} arg3:{arg3}");
			}
		}
	}
	public class ConsoleLogStream : TextWriterLogStream
	{
		private readonly ConsoleColor _color;

		public ConsoleLogStream(ConsoleColor color, string prefix = null)
			: base(Console.Out, disposeWriter: false, prefix)
		{
			_color = color;
		}

		public override void Log(ILogSource source, string message)
		{
			if (Console.ForegroundColor == _color)
			{
				base.Log(source, message);
				return;
			}
			Console.ForegroundColor = _color;
			try
			{
				base.Log(source, message);
			}
			finally
			{
				Console.ForegroundColor = ConsoleColor.Gray;
			}
		}

		public override void Log(ILogSource source, string message, Exception error)
		{
			if (Console.ForegroundColor == ConsoleColor.Red)
			{
				base.Log(source, message, error);
				return;
			}
			Console.ForegroundColor = _color;
			try
			{
				base.Log(source, message, error);
			}
			finally
			{
				Console.ForegroundColor = ConsoleColor.Gray;
			}
		}
	}
	public sealed class DebugLogStream : IDisposable
	{
		public readonly LogStream InfoStream;

		public readonly LogStream WarnStream;

		public readonly LogStream ErrorStream;

		public DebugLogStream(LogStream innerStream, LogStream warnStream, LogStream errorStream)
		{
			InfoStream = innerStream ?? throw new ArgumentNullException("innerStream");
			WarnStream = warnStream ?? throw new ArgumentNullException("warnStream");
			ErrorStream = errorStream ?? throw new ArgumentNullException("errorStream");
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("DEBUG")]
		public void Log(ILogSource source, string message)
		{
			InfoStream.Log(source, message);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("DEBUG")]
		public void Log(string message)
		{
			InfoStream.Log(message);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("DEBUG")]
		public void Info(ILogSource source, string message)
		{
			InfoStream.Log(source, message);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("DEBUG")]
		public void Info(string message)
		{
			InfoStream.Log(message);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("DEBUG")]
		public void Error(ILogSource source, string message)
		{
			ErrorStream.Log(source, message);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("DEBUG")]
		public void Error(string message)
		{
			ErrorStream.Log(message);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("DEBUG")]
		public void Error(Exception message)
		{
			ErrorStream.Log(message);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("DEBUG")]
		public void Exception(Exception message)
		{
			ErrorStream.Log(message);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("DEBUG")]
		public void Warn(ILogSource source, string message)
		{
			WarnStream.Log(source, message);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("DEBUG")]
		public void Warn(string message)
		{
			WarnStream.Log(message);
		}

		public void Dispose()
		{
			InfoStream.Dispose();
			WarnStream.Dispose();
			ErrorStream.Dispose();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("DEBUG")]
		internal void Log(object message)
		{
		}
	}
	public interface ILogSource
	{
		UnityEngine.Object GetUnityObject()
		{
			return this as UnityEngine.Object;
		}
	}
	public static class InternalLogStreams
	{
		[CanBeNull]
		public static DebugLogStream LogDebug;

		[CanBeNull]
		public static LogStream LogInfo;

		[CanBeNull]
		public static LogStream LogWarn;

		[CanBeNull]
		public static LogStream LogError;

		[CanBeNull]
		public static LogStream LogException;

		[CanBeNull]
		public static TraceLogStream LogTrace;

		[CanBeNull]
		internal static TraceLogStream LogTraceStun;

		[CanBeNull]
		internal static TraceLogStream LogTraceObject;

		[CanBeNull]
		internal static TraceLogStream LogTraceNetwork;

		[CanBeNull]
		internal static TraceLogStream LogTracePrefab;

		[CanBeNull]
		internal static TraceLogStream LogTraceSceneInfo;

		[CanBeNull]
		internal static TraceLogStream LogTraceSceneManager;

		[CanBeNull]
		internal static TraceLogStream LogTraceSimulationMessage;

		[CanBeNull]
		internal static TraceLogStream LogTraceHostMigration;

		[CanBeNull]
		internal static TraceLogStream LogTraceEncryption;

		[CanBeNull]
		internal static TraceLogStream LogTraceDummyTraffic;

		[CanBeNull]
		internal static TraceLogStream LogTraceRealtime;

		[CanBeNull]
		internal static TraceLogStream LogTraceMemoryTrack;

		[CanBeNull]
		internal static TraceLogStream LogTraceSnapshots;

		[CanBeNull]
		internal static TraceLogStream LogTraceTime;
	}
	public static class Log
	{
		public delegate LogStream CreateLogStreamDelegate(LogLevel level, LogFlags flags, TraceChannels channel);

		private readonly ref struct Factory(LogSettings settings, CreateLogStreamDelegate streamFactory)
		{
			public readonly CreateLogStreamDelegate StreamFactory = streamFactory;

			public readonly LogSettings Settings = settings;

			public void Init(ref DebugLogStream stream, TraceChannels channel)
			{
				DisposeAndNullify(ref stream);
				if (StreamFactory != null && LogLevel.Debug >= Settings.Level)
				{
					LogStream logStream = StreamFactory(LogLevel.Info, LogFlags.Debug, channel);
					LogStream logStream2 = StreamFactory(LogLevel.Warn, LogFlags.Debug, channel);
					LogStream logStream3 = StreamFactory(LogLevel.Error, LogFlags.Debug, channel);
					if (logStream == null && logStream2 == null && logStream3 == null)
					{
						stream = null;
					}
					else
					{
						stream = new DebugLogStream(logStream, logStream2, logStream3);
					}
				}
				else
				{
					stream = null;
				}
			}

			public void Init(ref TraceLogStream stream, TraceChannels channel)
			{
				DisposeAndNullify(ref stream);
				if (StreamFactory != null && Settings.TraceChannels.HasFlag(channel))
				{
					LogStream logStream = StreamFactory(LogLevel.Info, LogFlags.Trace, channel);
					LogStream logStream2 = StreamFactory(LogLevel.Warn, LogFlags.Trace, channel);
					LogStream logStream3 = StreamFactory(LogLevel.Error, LogFlags.Trace, channel);
					if (logStream == null && logStream2 == null && logStream3 == null)
					{
						stream = null;
					}
					else
					{
						stream = new TraceLogStream(logStream, logStream2, logStream3);
					}
				}
				else
				{
					stream = null;
				}
			}

			public void Init(ref LogStream stream, LogLevel logLevel)
			{
				DisposeAndNullify(ref stream);
				if (StreamFactory != null && logLevel >= Settings.Level)
				{
					stream = StreamFactory(logLevel, (LogFlags)0, (TraceChannels)0);
				}
				else
				{
					stream = null;
				}
			}
		}

		private class DelegateMessageStream : LogStream
		{
			private readonly Action<string> _logAction;

			private readonly Action<Exception> _exceptionAction;

			private readonly string _prefix;

			public DelegateMessageStream(Action<string> action, Action<Exception> exceptionAction, string prefix = null)
			{
				_logAction = action ?? throw new ArgumentNullException("action");
				_exceptionAction = exceptionAction ?? throw new ArgumentNullException("exceptionAction");
				_prefix = prefix;
			}

			public override void Log(ILogSource source, string message)
			{
				Log(message);
			}

			public override void Log(string message)
			{
				if (!string.IsNullOrEmpty(_prefix))
				{
					_logAction(_prefix + " " + message);
				}
				else
				{
					_logAction(message);
				}
			}

			public override void Log(ILogSource source, string message, Exception error)
			{
				_exceptionAction(error);
			}

			public override void Log(string message, Exception error)
			{
				_exceptionAction(error);
			}

			public override void Log(Exception error)
			{
				_exceptionAction(error);
			}
		}

		public static bool IsInitialized { get; private set; }

		public static LogSettings Settings { get; private set; }

		[Obsolete("Use IsInitialized instead")]
		public static bool Initialized => IsInitialized;

		public static void Dispose()
		{
			InitInternal(new Factory(default(LogSettings), null));
			IsInitialized = false;
		}

		public static void Initialize(LogLevel logLevel, CreateLogStreamDelegate streamFactory, TraceChannels traceChannels = (TraceChannels)0)
		{
			InitInternal(new Factory(new LogSettings(logLevel, traceChannels), streamFactory));
		}

		public static void Initialize(LogSettings settings, CreateLogStreamDelegate streamFactory)
		{
			InitInternal(new Factory(settings, streamFactory));
		}

		public static void InitializeForConsole(LogSettings settings)
		{
			Factory factory = new Factory(settings, (LogLevel type, LogFlags flags, TraceChannels chanel) => new ConsoleLogStream(flags.HasFlag(LogFlags.Debug) ? ConsoleColor.DarkGray : ConsoleColor.Gray, flags.HasFlag(LogFlags.Debug) ? "[DEBUG] " : ""));
			InitInternal(in factory);
		}

		private static void DisposeAndNullify<T>(ref T obj) where T : class, IDisposable
		{
			obj?.Dispose();
			obj = null;
		}

		private static void InitPartial(in Factory factory)
		{
			factory.Init(ref InternalLogStreams.LogTrace, TraceChannels.Global);
			factory.Init(ref InternalLogStreams.LogTraceStun, TraceChannels.Stun);
			factory.Init(ref InternalLogStreams.LogTraceObject, TraceChannels.Object);
			factory.Init(ref InternalLogStreams.LogTraceNetwork, TraceChannels.Network);
			factory.Init(ref InternalLogStreams.LogTracePrefab, TraceChannels.Prefab);
			factory.Init(ref InternalLogStreams.LogTraceSceneInfo, TraceChannels.SceneInfo);
			factory.Init(ref InternalLogStreams.LogTraceSceneManager, TraceChannels.SceneManager);
			factory.Init(ref InternalLogStreams.LogTraceSimulationMessage, TraceChannels.SimulationMessage);
			factory.Init(ref InternalLogStreams.LogTraceHostMigration, TraceChannels.HostMigration);
			factory.Init(ref InternalLogStreams.LogTraceEncryption, TraceChannels.Encryption);
			factory.Init(ref InternalLogStreams.LogTraceDummyTraffic, TraceChannels.DummyTraffic);
			factory.Init(ref InternalLogStreams.LogTraceRealtime, TraceChannels.Realtime);
			factory.Init(ref InternalLogStreams.LogTraceMemoryTrack, TraceChannels.MemoryTrack);
			factory.Init(ref InternalLogStreams.LogTraceSnapshots, TraceChannels.Snapshots);
			factory.Init(ref InternalLogStreams.LogTraceTime, TraceChannels.Time);
		}

		private static void InitInternal(in Factory factory)
		{
			factory.Init(ref InternalLogStreams.LogDebug, TraceChannels.Global);
			factory.Init(ref InternalLogStreams.LogInfo, LogLevel.Info);
			factory.Init(ref InternalLogStreams.LogWarn, LogLevel.Warn);
			factory.Init(ref InternalLogStreams.LogError, LogLevel.Error);
			factory.Init(ref InternalLogStreams.LogException, LogLevel.Error);
			InitPartial(in factory);
			Settings = factory.Settings;
			IsInitialized = true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("FUSION_LOGLEVEL_TRACE")]
		[Conditional("FUSION_LOGLEVEL_DEBUG")]
		public static void Debug(string message)
		{
			InternalLogStreams.LogDebug?.InfoStream.Log(message);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("FUSION_LOGLEVEL_TRACE")]
		[Conditional("FUSION_LOGLEVEL_DEBUG")]
		public static void DebugWarn(string message)
		{
			InternalLogStreams.LogDebug?.WarnStream.Log(message);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("FUSION_LOGLEVEL_TRACE")]
		[Conditional("FUSION_LOGLEVEL_DEBUG")]
		public static void DebugError(string message)
		{
			InternalLogStreams.LogDebug?.ErrorStream.Log(message);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("FUSION_LOGLEVEL_TRACE")]
		[Conditional("FUSION_LOGLEVEL_DEBUG")]
		[Conditional("FUSION_LOGLEVEL_INFO")]
		public static void Info(string message)
		{
			InternalLogStreams.LogInfo?.Log(message);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("FUSION_LOGLEVEL_TRACE")]
		[Conditional("FUSION_LOGLEVEL_DEBUG")]
		[Conditional("FUSION_LOGLEVEL_INFO")]
		public static void Info(ILogSource logSource, string message)
		{
			InternalLogStreams.LogInfo?.Log(logSource, message);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("FUSION_LOGLEVEL_TRACE")]
		[Conditional("FUSION_LOGLEVEL_DEBUG")]
		[Conditional("FUSION_LOGLEVEL_INFO")]
		[Conditional("FUSION_LOGLEVEL_WARN")]
		public static void Warn(string message)
		{
			InternalLogStreams.LogWarn?.Log(message);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("FUSION_LOGLEVEL_TRACE")]
		[Conditional("FUSION_LOGLEVEL_DEBUG")]
		[Conditional("FUSION_LOGLEVEL_INFO")]
		[Conditional("FUSION_LOGLEVEL_WARN")]
		public static void Warn(ILogSource logSource, string message)
		{
			InternalLogStreams.LogWarn?.Log(logSource, message);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("FUSION_LOGLEVEL_TRACE")]
		[Conditional("FUSION_LOGLEVEL_DEBUG")]
		[Conditional("FUSION_LOGLEVEL_INFO")]
		[Conditional("FUSION_LOGLEVEL_WARN")]
		[Conditional("FUSION_LOGLEVEL_ERROR")]
		public static void Error(string message)
		{
			InternalLogStreams.LogError?.Log(message);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("FUSION_LOGLEVEL_TRACE")]
		[Conditional("FUSION_LOGLEVEL_DEBUG")]
		[Conditional("FUSION_LOGLEVEL_INFO")]
		[Conditional("FUSION_LOGLEVEL_WARN")]
		[Conditional("FUSION_LOGLEVEL_ERROR")]
		public static void Error(ILogSource logSource, string message)
		{
			InternalLogStreams.LogError?.Log(logSource, message);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("FUSION_LOGLEVEL_TRACE")]
		[Conditional("FUSION_LOGLEVEL_DEBUG")]
		[Conditional("FUSION_LOGLEVEL_INFO")]
		[Conditional("FUSION_LOGLEVEL_WARN")]
		[Conditional("FUSION_LOGLEVEL_ERROR")]
		public static void Exception(Exception ex)
		{
			InternalLogStreams.LogException?.Log(ex);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("FUSION_LOGLEVEL_TRACE")]
		[Conditional("FUSION_LOGLEVEL_DEBUG")]
		[Conditional("FUSION_LOGLEVEL_INFO")]
		[Conditional("FUSION_LOGLEVEL_WARN")]
		[Conditional("FUSION_LOGLEVEL_ERROR")]
		public static void Exception(string message, Exception ex)
		{
			InternalLogStreams.LogException?.Log(message, ex);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("FUSION_LOGLEVEL_TRACE")]
		[Conditional("FUSION_LOGLEVEL_DEBUG")]
		[Conditional("FUSION_LOGLEVEL_INFO")]
		[Conditional("FUSION_LOGLEVEL_WARN")]
		[Conditional("FUSION_LOGLEVEL_ERROR")]
		public static void Exception(ILogSource source, string message, Exception ex)
		{
			InternalLogStreams.LogException?.Log(source, message, ex);
		}

		[Obsolete("Use InitializeForConsole instead")]
		public static void InitForConsole()
		{
			InitForConsole(LogType.Info);
		}

		[Obsolete("Use InitializeForConsole instead")]
		public static void InitForConsole(LogType logType)
		{
			LogLevel level = logType switch
			{
				LogType.Error => LogLevel.Error, 
				LogType.Warn => LogLevel.Warn, 
				LogType.Debug => LogLevel.Info, 
				LogType.Trace => LogLevel.Info, 
				LogType.Info => LogLevel.Info, 
				_ => throw new ArgumentOutOfRangeException("logType", logType, null), 
			};
			switch (logType)
			{
			case LogType.Debug:
			{
				bool flag = true;
				break;
			}
			case LogType.Trace:
			{
				bool flag = true;
				break;
			}
			default:
			{
				bool flag = false;
				break;
			}
			}
			InitializeForConsole(new LogSettings
			{
				Level = level,
				TraceChannels = (TraceChannels)0
			});
		}

		[Obsolete("Use Initialize instead")]
		public static void Init(Action<string> info, Action<string> warn, Action<string> error, Action<Exception> exn)
		{
			LogLevel level = LogLevel.Error;
			if (warn != null)
			{
				level = LogLevel.Warn;
				if (info != null)
				{
					level = LogLevel.Info;
				}
			}
			Initialize(new LogSettings
			{
				Level = level,
				TraceChannels = (TraceChannels)0
			}, (LogLevel type, LogFlags flags, TraceChannels name) => type switch
			{
				LogLevel.Info => new DelegateMessageStream(info, exn), 
				LogLevel.Warn => new DelegateMessageStream(warn, exn), 
				LogLevel.Error => new DelegateMessageStream(error, exn), 
				_ => throw new ArgumentOutOfRangeException("type", type, null), 
			});
		}

		[Conditional("TRACE")]
		[Obsolete("Use string overloads instead")]
		public static void Trace(object msg)
		{
		}

		[Conditional("TRACE")]
		[Obsolete("Use string overloads instead")]
		public static void TraceWarn(object msg)
		{
		}

		[Conditional("TRACE")]
		[Obsolete("Use string overloads instead")]
		public static void TraceError(object msg)
		{
		}

		[Conditional("TRACE")]
		[Obsolete("Use string overloads instead")]
		public static void Trace<T>(T source, object msg) where T : ILogSource
		{
		}

		[Conditional("TRACE")]
		[Obsolete("Use string overloads instead")]
		public static void TraceWarn<T>(T source, object msg) where T : ILogSource
		{
		}

		[Conditional("TRACE")]
		[Obsolete("Use string overloads instead")]
		public static void TraceError<T>(T source, object msg) where T : ILogSource
		{
		}

		[Conditional("DEBUG")]
		[Obsolete("Use string overloads instead")]
		public static void Debug(object msg)
		{
		}

		[Conditional("DEBUG")]
		[Obsolete("Use string overloads instead")]
		public static void DebugWarn(object msg)
		{
		}

		[Conditional("DEBUG")]
		[Obsolete("Use string overloads instead")]
		public static void DebugError(object msg)
		{
		}

		[Conditional("DEBUG")]
		[Obsolete("Use string overloads instead")]
		public static void Debug<T>(T source, object msg) where T : ILogSource
		{
		}

		[Conditional("DEBUG")]
		[Obsolete("Use string overloads instead")]
		public static void DebugWarn<T>(T source, object msg) where T : ILogSource
		{
		}

		[Conditional("DEBUG")]
		[Obsolete("Use string overloads instead")]
		public static void DebugError<T>(T source, object msg) where T : ILogSource
		{
		}

		[Obsolete("Use overloads with strings instead")]
		public static void Info(object msg)
		{
		}

		[Obsolete("Use overloads with strings instead")]
		internal static void Info(ILogSource source, object msg)
		{
		}

		[Obsolete("Use overloads with strings instead")]
		public static void Warn(object msg)
		{
		}

		[Obsolete("Use overloads with strings instead")]
		internal static void Warn(ILogSource source, object msg)
		{
		}

		[Obsolete("Use overloads with strings instead")]
		public static void Error(object msg)
		{
		}

		[Obsolete("Use overloads with strings instead")]
		internal static void Error(ILogSource source, object msg)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("FUSION_TRACE_GLOBAL")]
		public static void Trace(string msg)
		{
			InternalLogStreams.LogTrace?.InfoStream.Log(msg);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("FUSION_TRACE_GLOBAL")]
		public static void TraceWarn(string msg)
		{
			InternalLogStreams.LogTrace?.WarnStream.Log(msg);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("FUSION_TRACE_GLOBAL")]
		public static void TraceError(string msg)
		{
			InternalLogStreams.LogTrace?.ErrorStream.Log(msg);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("FUSION_TRACE_GLOBAL")]
		public static void Trace<T>(T source, string msg) where T : ILogSource
		{
			InternalLogStreams.LogTrace?.InfoStream.Log(source, msg);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("FUSION_TRACE_GLOBAL")]
		public static void TraceWarn<T>(T source, string msg) where T : ILogSource
		{
			InternalLogStreams.LogTrace?.WarnStream.Log(source, msg);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("FUSION_TRACE_GLOBAL")]
		public static void TraceError<T>(T source, string msg) where T : ILogSource
		{
			InternalLogStreams.LogTrace?.ErrorStream.Log(source, msg);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("FUSION_TRACE_SCENEMANAGER")]
		public static void TraceSceneManager(string msg)
		{
			InternalLogStreams.LogTraceSceneManager?.InfoStream.Log(msg);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("FUSION_TRACE_SCENEMANAGER")]
		public static void TraceSceneManagerWarn(string msg)
		{
			InternalLogStreams.LogTraceSceneManager?.WarnStream.Log(msg);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("FUSION_TRACE_SCENEMANAGER")]
		public static void TraceSceneManagerError(string msg)
		{
			InternalLogStreams.LogTraceSceneManager?.ErrorStream.Log(msg);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("FUSION_TRACE_SCENEMANAGER")]
		public static void TraceSceneManager<T>(T source, string msg) where T : ILogSource
		{
			InternalLogStreams.LogTraceSceneManager?.InfoStream.Log(source, msg);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("FUSION_TRACE_SCENEMANAGER")]
		public static void TraceSceneManagerWarn<T>(T source, string msg) where T : ILogSource
		{
			InternalLogStreams.LogTraceSceneManager?.WarnStream.Log(source, msg);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("FUSION_TRACE_SCENEMANAGER")]
		public static void TraceSceneManagerError<T>(T source, string msg) where T : ILogSource
		{
			InternalLogStreams.LogTraceSceneManager?.ErrorStream.Log(source, msg);
		}
	}
	[Obsolete("Use LogLevel instead")]
	public enum LogType : byte
	{
		Error,
		Warn,
		Info,
		Debug,
		Trace
	}
	[Flags]
	public enum LogFlags
	{
		Debug = 1,
		Trace = 2
	}
	public enum LogLevel
	{
		Debug,
		Info,
		Warn,
		Error,
		None
	}
	[Serializable]
	public struct LogSettings(LogLevel level, TraceChannels traceChannels)
	{
		public LogLevel Level = level;

		public TraceChannels TraceChannels = traceChannels;
	}
	public abstract class LogStream : IDisposable
	{
		public virtual void Log(ILogSource source, string message)
		{
			Log(message);
		}

		public abstract void Log(string message);

		public virtual void Log(ILogSource source, string message, Exception error)
		{
			Log(error);
		}

		public virtual void Log(ILogSource source, Exception error)
		{
			Log(error);
		}

		public virtual void Log(string message, Exception error)
		{
			Log(error);
		}

		public abstract void Log(Exception error);

		public virtual void Dispose()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("DEBUG")]
		internal void Log(object message)
		{
			Log($"{message}");
		}

		[CanBeNull]
		public LogStream Once(ref bool flag)
		{
			if (!flag)
			{
				flag = true;
				return this;
			}
			return null;
		}
	}
	public abstract class FusionUnityLoggerBase : IDisposable
	{
		protected internal readonly struct LogContext(string message, string prefix, ILogSource source, LogFlags flags)
		{
			public readonly string Message = message;

			public readonly ILogSource Source = source;

			public readonly string Prefix = prefix;

			public readonly LogFlags Flags = flags;
		}

		private readonly Thread _mainThread;

		private readonly StringBuilder _mainThreadBuilder = new StringBuilder();

		private readonly ThreadLocal<StringBuilder> _threadedStringBuilder = new ThreadLocal<StringBuilder>(() => new StringBuilder());

		public bool AddHashCodePrefix;

		public string GlobalPrefix = "Fusion";

		public string GlobalPrefixColor;

		public Color32 MaxRandomColor;

		public Color32 MinRandomColor;

		public string NameUnavailableInWorkerThreadLabel = "";

		public string NameUnavailableObjectDestroyedLabel = "(destroyed)";

		public bool UseColorTags;

		public bool UseGlobalPrefix;

		public string DebugPrefix = "[DEBUG] ";

		public string TracePrefix = "[TRACE] ";

		private bool IsInMainThread => _mainThread == Thread.CurrentThread;

		public static Color DefaultLightPrefixColor => new Color32(20, 64, 120, byte.MaxValue);

		public static Color DefaultDarkPrefixColor => new Color32(115, 172, 229, byte.MaxValue);

		public FusionUnityLoggerBase(Thread mainThread = null, bool isDarkMode = false)
		{
			_mainThread = mainThread ?? Thread.CurrentThread;
			MinRandomColor = (isDarkMode ? new Color32(158, 158, 158, byte.MaxValue) : new Color32(30, 30, 30, byte.MaxValue));
			MaxRandomColor = (isDarkMode ? new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue) : new Color32(90, 90, 90, byte.MaxValue));
			UseColorTags = true;
			UseGlobalPrefix = true;
			GlobalPrefixColor = Color32ToRGBString(isDarkMode ? DefaultDarkPrefixColor : DefaultLightPrefixColor);
		}

		public void Dispose()
		{
			_threadedStringBuilder.Dispose();
		}

		public LogStream CreateLogStream(LogLevel logLevel, LogFlags flags, TraceChannels channel)
		{
			return new UnityLogStream(this, logLevel, channel, flags);
		}

		protected internal virtual (string, UnityEngine.Object) CreateMessage(in LogContext context)
		{
			bool isMainThread;
			StringBuilder threadSafeStringBuilder = GetThreadSafeStringBuilder(out isMainThread);
			UnityEngine.Object obj = context.Source?.GetUnityObject();
			try
			{
				AppendPrefix(threadSafeStringBuilder, context.Flags, context.Prefix);
				if (obj != null)
				{
					int length = threadSafeStringBuilder.Length;
					AppendNameThreadSafe(threadSafeStringBuilder, obj);
					if (threadSafeStringBuilder.Length > length)
					{
						threadSafeStringBuilder.Append(": ");
					}
				}
				threadSafeStringBuilder.Append(context.Message);
				return (threadSafeStringBuilder.ToString(), isMainThread ? obj : null);
			}
			finally
			{
				threadSafeStringBuilder.Clear();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected StringBuilder GetThreadSafeStringBuilder(out bool isMainThread)
		{
			isMainThread = IsInMainThread;
			if (!IsInMainThread)
			{
				return _threadedStringBuilder.Value;
			}
			return _mainThreadBuilder;
		}

		protected void AppendPrefix(StringBuilder sb, LogFlags flags, string prefix)
		{
			if (UseGlobalPrefix)
			{
				if (UseColorTags)
				{
					sb.Append("<color=");
					sb.Append(GlobalPrefixColor);
					sb.Append(">");
				}
				sb.Append("[");
				sb.Append(GlobalPrefix);
				if (!string.IsNullOrEmpty(prefix))
				{
					sb.Append("/");
					sb.Append(prefix);
				}
				sb.Append("]");
				if (UseColorTags)
				{
					sb.Append("</color>");
				}
				sb.Append(" ");
			}
			else if (!string.IsNullOrEmpty(prefix))
			{
				sb.Append(prefix);
				sb.Append(": ");
			}
			if ((flags & LogFlags.Debug) == LogFlags.Debug)
			{
				sb.Append(DebugPrefix);
			}
			if ((flags & LogFlags.Trace) == LogFlags.Trace)
			{
				sb.Append(TracePrefix);
			}
		}

		public void AppendNameThreadSafe(StringBuilder builder, UnityEngine.Object obj)
		{
			if ((object)obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			string text = ((obj == null) ? NameUnavailableObjectDestroyedLabel : (IsInMainThread ? obj.name : NameUnavailableInWorkerThreadLabel));
			if (UseColorTags)
			{
				builder.AppendFormat("<color=#{0:X6}>", GetColorFromHash(text));
			}
			if (AddHashCodePrefix)
			{
				builder.AppendFormat("{0:X8}", obj.GetHashCode());
			}
			if (text != null && text.Length > 0)
			{
				if (AddHashCodePrefix)
				{
					builder.Append(" ");
				}
				builder.Append(text);
			}
			if (UseColorTags)
			{
				builder.Append("</color>");
			}
		}

		private int GetColorFromHash(string name)
		{
			int num = 0;
			for (int i = 0; i < name.Length; i++)
			{
				num = num * 31 + name[i];
			}
			return GetRandomColor(num, MinRandomColor, MaxRandomColor);
		}

		private static int GetRandomColor(int seed, Color32 min, Color32 max)
		{
			ulong x = (ulong)seed;
			ulong num = NextSplitMix(ref x);
			uint num2 = (uint)(max.r - min.r + 1);
			uint num3 = (uint)(max.g - min.g + 1);
			uint num4 = (uint)(max.b - min.b + 1);
			uint num5 = (uint)(num % num2);
			ulong num6 = num / num2;
			uint num7 = (uint)(num6 % num3);
			uint num8 = (uint)(num6 / num3 % num4);
			return (int)((num5 << 16) | (num7 << 8) | num8);
			static ulong NextSplitMix(ref ulong reference)
			{
				ulong num9 = (reference += 11400714819323198485uL);
				long num10 = (long)(num9 ^ (num9 >> 30)) * -4658895280553007687L;
				long num11 = (num10 ^ (num10 >>> 27)) * -7723592293110705685L;
				return (ulong)(num11 ^ (num11 >>> 31));
			}
		}

		private static int Color32ToRGB24(Color32 c)
		{
			return (c.r << 16) | (c.g << 8) | c.b;
		}

		private static string Color32ToRGBString(Color32 c)
		{
			return $"#{Color32ToRGB24(c):X6}";
		}
	}
	public class TextWriterLogStream : LogStream
	{
		private StringBuilder _builder = new StringBuilder();

		private TextWriter _writer;

		private bool _disposeWriter;

		private string _prefix;

		public TextWriterLogStream(TextWriter writer, bool disposeWriter, string prefix = null)
		{
			_writer = writer ?? throw new ArgumentNullException("writer");
			_disposeWriter = disposeWriter;
			_prefix = prefix;
		}

		public override void Log(ILogSource source, string message)
		{
			Log(message);
		}

		public override void Log(string message)
		{
			try
			{
				if (!string.IsNullOrEmpty(_prefix))
				{
					_builder.Append(_prefix);
					_builder.Append(" ");
				}
				_builder.Append(message);
				_writer.WriteLine(_builder.ToString());
			}
			finally
			{
				_builder.Clear();
			}
		}

		public override void Log(ILogSource source, string message, Exception error)
		{
			Log(message, error);
		}

		public override void Log(string message, Exception error)
		{
			try
			{
				if (!string.IsNullOrEmpty(_prefix))
				{
					_builder.Append(_prefix);
					_builder.Append(" ");
				}
				if (!string.IsNullOrEmpty(message))
				{
					_builder.Append(message);
					_builder.Append(" ");
				}
				_builder.Append(error.Message);
				_writer.WriteLine(_builder.ToString());
				_writer.WriteLine(error.StackTrace);
			}
			finally
			{
				_builder.Clear();
			}
		}

		public override void Log(Exception error)
		{
			Log((string)null, error);
		}

		public override void Dispose()
		{
			if (_disposeWriter && _writer != null)
			{
				TextWriter writer = _writer;
				_writer = null;
				writer.Dispose();
			}
		}
	}
	public sealed class TraceLogStream : IDisposable
	{
		public readonly LogStream InfoStream;

		public readonly LogStream WarnStream;

		public readonly LogStream ErrorStream;

		public TraceLogStream(LogStream innerStream, LogStream warnStream, LogStream errorStream)
		{
			InfoStream = innerStream ?? throw new ArgumentNullException("innerStream");
			WarnStream = warnStream ?? throw new ArgumentNullException("warnStream");
			ErrorStream = errorStream ?? throw new ArgumentNullException("errorStream");
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("TRACE")]
		public void Log(ILogSource source, string message)
		{
			InfoStream.Log(source, message);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("TRACE")]
		public void Log(string message)
		{
			InfoStream.Log(message);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("TRACE")]
		public void Info(ILogSource source, string message)
		{
			InfoStream.Log(source, message);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("TRACE")]
		public void Info(string message)
		{
			InfoStream.Log(message);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("TRACE")]
		public void Error(ILogSource source, string message)
		{
			ErrorStream.Log(source, message);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("TRACE")]
		public void Error(string message)
		{
			ErrorStream.Log(message);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("TRACE")]
		public void Error(Exception message)
		{
			ErrorStream.Log(message);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("TRACE")]
		public void Exception(Exception message)
		{
			ErrorStream.Log(message);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("TRACE")]
		public void Warn(ILogSource source, string message)
		{
			WarnStream.Log(source, message);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("TRACE")]
		public void Warn(string message)
		{
			WarnStream.Log(message);
		}

		public void Dispose()
		{
			InfoStream.Dispose();
			WarnStream.Dispose();
			ErrorStream.Dispose();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Conditional("DEBUG")]
		internal void Log(object message)
		{
		}
	}
	internal sealed class UnityLogStream : LogStream
	{
		private readonly FusionUnityLoggerBase _logger;

		private readonly LogLevel _logLevel;

		private readonly string _prefix;

		private readonly LogFlags _flags;

		public UnityLogStream(FusionUnityLoggerBase logger, LogLevel logLevel, TraceChannels channel, LogFlags flags)
		{
			_prefix = ((channel == (TraceChannels)0 || channel == TraceChannels.Global) ? "" : channel.ToString());
			_logLevel = logLevel;
			_logger = logger;
			_flags = flags;
		}

		public override void Log(ILogSource source, string message)
		{
			var (text, context) = _logger.CreateMessage(new FusionUnityLoggerBase.LogContext(message, _prefix, source, _flags));
			if (text != null)
			{
				switch (_logLevel)
				{
				case LogLevel.Error:
					UnityEngine.Debug.LogError(text, context);
					break;
				case LogLevel.Warn:
					UnityEngine.Debug.LogWarning(text, context);
					break;
				default:
					UnityEngine.Debug.Log(text, context);
					break;
				}
			}
		}

		public override void Log(string message)
		{
			var (text, context) = _logger.CreateMessage(new FusionUnityLoggerBase.LogContext(message, _prefix, null, _flags));
			if (text != null)
			{
				switch (_logLevel)
				{
				case LogLevel.Error:
					UnityEngine.Debug.LogError(text, context);
					break;
				case LogLevel.Warn:
					UnityEngine.Debug.LogWarning(text, context);
					break;
				default:
					UnityEngine.Debug.Log(text, context);
					break;
				}
			}
		}

		public override void Log(ILogSource source, string message, Exception error)
		{
			var (text, obj) = _logger.CreateMessage(new FusionUnityLoggerBase.LogContext((message ?? error.GetType().FullName) + " <i>See next error log entry for details.</i>", null, source, (LogFlags)0));
			if (text == null)
			{
				return;
			}
			UnityEngine.Debug.LogWarning(text, obj);
			if (Application.isEditor)
			{
				ExceptionDispatchInfo edi = ExceptionDispatchInfo.Capture(error);
				Thread thread = new Thread((ThreadStart)delegate
				{
					edi.Throw();
				});
				thread.Start();
				thread.Join();
			}
			else if ((bool)obj)
			{
				UnityEngine.Debug.LogException(error, obj);
			}
			else
			{
				UnityEngine.Debug.LogException(error);
			}
		}

		public override void Log(string message, Exception error)
		{
			var (text, obj) = _logger.CreateMessage(new FusionUnityLoggerBase.LogContext((message ?? error.GetType().FullName) + " <i>See next error log entry for details.</i>", null, null, (LogFlags)0));
			if (text == null)
			{
				return;
			}
			UnityEngine.Debug.LogWarning(text, obj);
			if (Application.isEditor)
			{
				ExceptionDispatchInfo edi = ExceptionDispatchInfo.Capture(error);
				Thread thread = new Thread((ThreadStart)delegate
				{
					edi.Throw();
				});
				thread.Start();
				thread.Join();
			}
			else if ((bool)obj)
			{
				UnityEngine.Debug.LogException(error, obj);
			}
			else
			{
				UnityEngine.Debug.LogException(error);
			}
		}

		public override void Log(ILogSource source, Exception error)
		{
			var (text, obj) = _logger.CreateMessage(new FusionUnityLoggerBase.LogContext(error.GetType().FullName + " <i>See next error log entry for details.</i>", null, source, (LogFlags)0));
			if (text == null)
			{
				return;
			}
			UnityEngine.Debug.LogWarning(text, obj);
			if (Application.isEditor)
			{
				ExceptionDispatchInfo edi = ExceptionDispatchInfo.Capture(error);
				Thread thread = new Thread((ThreadStart)delegate
				{
					edi.Throw();
				});
				thread.Start();
				thread.Join();
			}
			else if ((bool)obj)
			{
				UnityEngine.Debug.LogException(error, obj);
			}
			else
			{
				UnityEngine.Debug.LogException(error);
			}
		}

		public override void Log(Exception error)
		{
			var (text, obj) = _logger.CreateMessage(new FusionUnityLoggerBase.LogContext(error.GetType().FullName + " <i>See next error log entry for details.</i>", null, null, (LogFlags)0));
			if (text == null)
			{
				return;
			}
			UnityEngine.Debug.LogWarning(text, obj);
			if (Application.isEditor)
			{
				ExceptionDispatchInfo edi = ExceptionDispatchInfo.Capture(error);
				Thread thread = new Thread((ThreadStart)delegate
				{
					edi.Throw();
				});
				thread.Start();
				thread.Join();
			}
			else if ((bool)obj)
			{
				UnityEngine.Debug.LogException(error, obj);
			}
			else
			{
				UnityEngine.Debug.LogException(error);
			}
		}
	}
	public interface ILogDumpable
	{
		void Dump(StringBuilder builder);
	}
	[Obsolete]
	public class ConsoleLogger : TextWriterLogger
	{
		public ConsoleLogger()
			: base(Console.Out, disposeWriter: false)
		{
		}

		public override void Log(LogType logType, object message, in LogContext logContext)
		{
			switch (logType)
			{
			case LogType.Info:
			case LogType.Debug:
			case LogType.Trace:
				Console.ForegroundColor = ConsoleColor.Gray;
				break;
			case LogType.Warn:
				Console.ForegroundColor = ConsoleColor.Yellow;
				break;
			case LogType.Error:
				Console.ForegroundColor = ConsoleColor.Red;
				break;
			}
			try
			{
				base.Log(logType, message, in logContext);
			}
			finally
			{
				Console.ForegroundColor = ConsoleColor.Gray;
			}
		}

		public override void LogException(Exception ex, in LogContext logContext)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			try
			{
				base.LogException(ex, in logContext);
			}
			finally
			{
				Console.ForegroundColor = ConsoleColor.Gray;
			}
		}
	}
	[Obsolete]
	public interface ILogger
	{
		void Log(LogType logType, object message, in LogContext logContext);

		void LogException(Exception ex, in LogContext logContext);
	}
	[Obsolete]
	public interface ILogSourceProxy
	{
		ILogSource LogSource { get; }
	}
	[Obsolete]
	public readonly struct LogContext(string prefix, object source)
	{
		public readonly string Prefix = prefix;

		public readonly object Source = source;
	}
	[Obsolete]
	public class TextWriterLogger : ILogger, IDisposable
	{
		private StringBuilder _builder = new StringBuilder();

		private TextWriter _writer;

		private bool _disposeWriter;

		public TextWriterLogger(TextWriter writer, bool disposeWriter)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			_writer = writer;
			_disposeWriter = disposeWriter;
		}

		public virtual void Dispose()
		{
			if (_disposeWriter && _writer != null)
			{
				TextWriter writer = _writer;
				_writer = null;
				writer.Dispose();
			}
		}

		public virtual void Log(LogType logType, object message, in LogContext logContext)
		{
			try
			{
				switch (logType)
				{
				case LogType.Debug:
					_builder.Append("[DEBUG] ");
					break;
				case LogType.Trace:
					_builder.Append("[TRACE] ");
					break;
				}
				if (!string.IsNullOrEmpty(logContext.Prefix))
				{
					_builder.Append(logContext.Prefix);
					_builder.Append(": ");
				}
				_builder.Append(message);
				_writer.WriteLine(_builder.ToString());
			}
			finally
			{
				_builder.Clear();
			}
		}

		public virtual void LogException(Exception ex, in LogContext logContext)
		{
			try
			{
				_builder.Append(logContext.Prefix);
				_builder.Append(ex.Message);
				_writer.WriteLine(_builder.ToString());
				_writer.WriteLine(ex.StackTrace);
			}
			finally
			{
				_builder.Clear();
			}
		}
	}
	[Flags]
	public enum TraceChannels
	{
		Global = 1,
		Stun = 2,
		Object = 4,
		Network = 8,
		Prefab = 0x10,
		SceneInfo = 0x20,
		SceneManager = 0x40,
		SimulationMessage = 0x80,
		HostMigration = 0x100,
		Encryption = 0x200,
		DummyTraffic = 0x400,
		Realtime = 0x800,
		MemoryTrack = 0x1000,
		Snapshots = 0x2000,
		Time = 0x4000
	}
	public static class LogUtils
	{
		public unsafe readonly struct DumpDeferredPtr<T>(T* ptr) where T : unmanaged, ILogDumpable
		{
			public unsafe override string ToString()
			{
				if (ptr != null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					ptr->Dump(stringBuilder);
					return stringBuilder.ToString();
				}
				return "null";
			}
		}

		public readonly struct DumpDeferredStruct<T>(T obj) where T : unmanaged, ILogDumpable
		{
			public override string ToString()
			{
				StringBuilder stringBuilder = new StringBuilder();
				obj.Dump(stringBuilder);
				return stringBuilder.ToString();
			}
		}

		public readonly struct DumpDeferredClass(ILogDumpable obj)
		{
			public readonly ILogDumpable Obj = obj;

			public override string ToString()
			{
				if (Obj != null)
				{
					StringBuilder stringBuilder = new StringBuilder();
					Obj.Dump(stringBuilder);
					return stringBuilder.ToString();
				}
				return "null";
			}
		}

		public unsafe static DumpDeferredPtr<T> GetDump<T>(T* ptr) where T : unmanaged, ILogDumpable
		{
			return new DumpDeferredPtr<T>(ptr);
		}

		public static DumpDeferredClass GetDump<T>(T obj) where T : class, ILogDumpable
		{
			return new DumpDeferredClass(obj);
		}
	}
}
