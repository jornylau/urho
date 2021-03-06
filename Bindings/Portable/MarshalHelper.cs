﻿using System;
using System.Runtime.InteropServices;

namespace Urho
{
	public static class MarshalHelper
	{
		public static unsafe float ReadSingle(this IntPtr ptr, int offset)
		{
			if (sizeof (IntPtr) == sizeof (int))
			{
				var value32 = Marshal.ReadInt32(ptr, offset);
				return *(float*)&value32;
			}
			var value64 = Marshal.ReadInt64(ptr, offset);
			return (float)*(double*) &value64;
		}

		public static float[] ToFloatsArray(this IntPtr ptr, int size)
		{
			float[] result = new float[size];
			Marshal.Copy(ptr, result, 0, size);
			return result;
		}

		public static byte[] ToBytesArray(this IntPtr ptr, int size)
		{
			byte[] result = new byte[size];
			Marshal.Copy(ptr, result, 0, size);
			return result;
		}

		public static int[] ToIntsArray(this IntPtr ptr, int size)
		{
			int[] result = new int[size];
			Marshal.Copy(ptr, result, 0, size);
			return result;
		}

		public static T[] ToStructsArray<T>(this IntPtr ptr, int size) where T : struct 
		{
			T[] result = new T[size];
			var typeSize = Marshal.SizeOf(typeof (T));
			for (int i = 0; i < size; i++)
			{
				var currentPtr = Marshal.ReadIntPtr(ptr, typeSize*i);
				result[i] = (T)Marshal.PtrToStructure(currentPtr, typeof (T));
			}
			return result;
		}
	}
}
