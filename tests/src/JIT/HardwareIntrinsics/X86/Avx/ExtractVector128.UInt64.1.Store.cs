// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

/******************************************************************************
 * This file is auto-generated from a template file by the GenerateTests.csx  *
 * script in tests\src\JIT\HardwareIntrinsics\X86\Shared. In order to make    *
 * changes, please update the corresponding template and run according to the *
 * directions listed in the file.                                             *
 ******************************************************************************/

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace JIT.HardwareIntrinsics.X86
{
    public static partial class Program
    {
        private static void ExtractVector128UInt641Store()
        {
            var test = new SimpleUnaryOpTest__ExtractVector128UInt641Store();

            if (test.IsSupported)
            {
                // Validates basic functionality works, using Unsafe.Read
                test.RunBasicScenario_UnsafeRead();

                if (Avx.IsSupported)
                {
                    // Validates basic functionality works, using Load
                    test.RunBasicScenario_Load();

                    // Validates basic functionality works, using LoadAligned
                    test.RunBasicScenario_LoadAligned();
                }

                // Validates calling via reflection works, using Unsafe.Read
                test.RunReflectionScenario_UnsafeRead();

                if (Avx.IsSupported)
                {
                    // Validates calling via reflection works, using Load
                    test.RunReflectionScenario_Load();

                    // Validates calling via reflection works, using LoadAligned
                    test.RunReflectionScenario_LoadAligned();
                }

                // Validates passing a static member works
                test.RunClsVarScenario();

                // Validates passing a local works, using Unsafe.Read
                test.RunLclVarScenario_UnsafeRead();

                if (Avx.IsSupported)
                {
                    // Validates passing a local works, using Load
                    test.RunLclVarScenario_Load();

                    // Validates passing a local works, using LoadAligned
                    test.RunLclVarScenario_LoadAligned();
                }

                // Validates passing the field of a local works
                test.RunLclFldScenario();

                // Validates passing an instance member works
                test.RunFldScenario();
            }
            else
            {
                // Validates we throw on unsupported hardware
                test.RunUnsupportedScenario();
            }

            if (!test.Succeeded)
            {
                throw new Exception("One or more scenarios did not complete as expected.");
            }
        }
    }

    public sealed unsafe class SimpleUnaryOpTest__ExtractVector128UInt641Store
    {
        private static readonly int LargestVectorSize = 32;

        private static readonly int Op1ElementCount = Unsafe.SizeOf<Vector256<UInt64>>() / sizeof(UInt64);
        private static readonly int RetElementCount = Unsafe.SizeOf<Vector128<UInt64>>() / sizeof(UInt64);

        private static UInt64[] _data = new UInt64[Op1ElementCount];

        private static Vector256<UInt64> _clsVar;

        private Vector256<UInt64> _fld;

        private SimpleUnaryOpTest__DataTable<UInt64, UInt64> _dataTable;

        static SimpleUnaryOpTest__ExtractVector128UInt641Store()
        {
            var random = new Random();

            for (var i = 0; i < Op1ElementCount; i++) { _data[i] = (ulong)(random.Next(0, int.MaxValue)); }
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<Vector256<UInt64>, byte>(ref _clsVar), ref Unsafe.As<UInt64, byte>(ref _data[0]), (uint)Unsafe.SizeOf<Vector256<UInt64>>());
        }

        public SimpleUnaryOpTest__ExtractVector128UInt641Store()
        {
            Succeeded = true;

            var random = new Random();

            for (var i = 0; i < Op1ElementCount; i++) { _data[i] = (ulong)(random.Next(0, int.MaxValue)); }
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<Vector256<UInt64>, byte>(ref _fld), ref Unsafe.As<UInt64, byte>(ref _data[0]), (uint)Unsafe.SizeOf<Vector256<UInt64>>());

            for (var i = 0; i < Op1ElementCount; i++) { _data[i] = (ulong)(random.Next(0, int.MaxValue)); }
            _dataTable = new SimpleUnaryOpTest__DataTable<UInt64, UInt64>(_data, new UInt64[RetElementCount], LargestVectorSize);
        }

        public bool IsSupported => Avx.IsSupported;

        public bool Succeeded { get; set; }

        public void RunBasicScenario_UnsafeRead()
        {
            Avx.ExtractVector128(
                (UInt64*)_dataTable.outArrayPtr,
                Unsafe.Read<Vector256<UInt64>>(_dataTable.inArrayPtr),
                1
            );

            ValidateResult(_dataTable.inArrayPtr, _dataTable.outArrayPtr);
        }

        public void RunBasicScenario_Load()
        {
            Avx.ExtractVector128(
                (UInt64*)_dataTable.outArrayPtr,
                Avx.LoadVector256((UInt64*)(_dataTable.inArrayPtr)),
                1
            );

            ValidateResult(_dataTable.inArrayPtr, _dataTable.outArrayPtr);
        }

        public void RunBasicScenario_LoadAligned()
        {
            Avx.ExtractVector128(
                (UInt64*)_dataTable.outArrayPtr,
                Avx.LoadAlignedVector256((UInt64*)(_dataTable.inArrayPtr)),
                1
            );

            ValidateResult(_dataTable.inArrayPtr, _dataTable.outArrayPtr);
        }

        public void RunReflectionScenario_UnsafeRead()
        {
            typeof(Avx).GetMethod(nameof(Avx.ExtractVector128), new Type[] { typeof(UInt64*), typeof(Vector256<UInt64>), typeof(byte) })
                                     .Invoke(null, new object[] {
                                        Pointer.Box(_dataTable.outArrayPtr, typeof(UInt64*)),
                                        Unsafe.Read<Vector256<UInt64>>(_dataTable.inArrayPtr),
                                        (byte)1
                                     });

            ValidateResult(_dataTable.inArrayPtr, _dataTable.outArrayPtr);
        }

        public void RunReflectionScenario_Load()
        {
            typeof(Avx).GetMethod(nameof(Avx.ExtractVector128), new Type[] { typeof(UInt64*), typeof(Vector256<UInt64>), typeof(byte) })
                                     .Invoke(null, new object[] {
                                        Pointer.Box(_dataTable.outArrayPtr, typeof(UInt64*)),
                                        Avx.LoadVector256((UInt64*)(_dataTable.inArrayPtr)),
                                        (byte)1
                                     });

            ValidateResult(_dataTable.inArrayPtr, _dataTable.outArrayPtr);
        }

        public void RunReflectionScenario_LoadAligned()
        {
            typeof(Avx).GetMethod(nameof(Avx.ExtractVector128), new Type[] {  typeof(UInt64*), typeof(Vector256<UInt64>), typeof(byte) })
                                     .Invoke(null, new object[] {
                                        Pointer.Box(_dataTable.outArrayPtr, typeof(UInt64*)),
                                        Avx.LoadAlignedVector256((UInt64*)(_dataTable.inArrayPtr)),
                                        (byte)1
                                     });

            ValidateResult(_dataTable.inArrayPtr, _dataTable.outArrayPtr);
        }

        public void RunClsVarScenario()
        {
            Avx.ExtractVector128(
                (UInt64*)_dataTable.outArrayPtr,
                _clsVar,
                1
            );
        }

        public void RunLclVarScenario_UnsafeRead()
        {
            var firstOp = Unsafe.Read<Vector256<UInt64>>(_dataTable.inArrayPtr);
            Avx.ExtractVector128((UInt64*)_dataTable.outArrayPtr, firstOp, 1);
        }

        public void RunLclVarScenario_Load()
        {
            var firstOp = Avx.LoadVector256((UInt64*)(_dataTable.inArrayPtr));
            Avx.ExtractVector128((UInt64*)_dataTable.outArrayPtr, firstOp, 1);
        }

        public void RunLclVarScenario_LoadAligned()
        {
            var firstOp = Avx.LoadAlignedVector256((UInt64*)(_dataTable.inArrayPtr));
            Avx.ExtractVector128((UInt64*)_dataTable.outArrayPtr, firstOp, 1);
        }

        public void RunLclFldScenario()
        {
            var test = new SimpleUnaryOpTest__ExtractVector128UInt641Store();
            Avx.ExtractVector128((UInt64*)_dataTable.outArrayPtr, test._fld, 1);
        }

        public void RunFldScenario()
        {
            Avx.ExtractVector128((UInt64*)_dataTable.outArrayPtr, _fld, 1);
        }

        public void RunUnsupportedScenario()
        {
            Succeeded = false;

            try
            {
                RunBasicScenario_UnsafeRead();
            }
            catch (PlatformNotSupportedException)
            {
                Succeeded = true;
            }
        }

        private void ValidateResult(Vector256<UInt64> firstOp, void* result, [CallerMemberName] string method = "")
        {
            UInt64[] inArray = new UInt64[Op1ElementCount];
            UInt64[] outArray = new UInt64[RetElementCount];

            Unsafe.WriteUnaligned(ref Unsafe.As<UInt64, byte>(ref inArray[0]), firstOp);
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<UInt64, byte>(ref outArray[0]), ref Unsafe.AsRef<byte>(result), (uint)Unsafe.SizeOf<Vector128<UInt64>>());

            ValidateResult(inArray, outArray, method);
        }

        private void ValidateResult(void* firstOp, void* result, [CallerMemberName] string method = "")
        {
            UInt64[] inArray = new UInt64[Op1ElementCount];
            UInt64[] outArray = new UInt64[RetElementCount];

            Unsafe.CopyBlockUnaligned(ref Unsafe.As<UInt64, byte>(ref inArray[0]), ref Unsafe.AsRef<byte>(firstOp), (uint)Unsafe.SizeOf<Vector256<UInt64>>());
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<UInt64, byte>(ref outArray[0]), ref Unsafe.AsRef<byte>(result), (uint)Unsafe.SizeOf<Vector128<UInt64>>());

            ValidateResult(inArray, outArray, method);
        }

        private void ValidateResult(UInt64[] firstOp, UInt64[] result, [CallerMemberName] string method = "")
        {
            if (result[0] != firstOp[2])
            {
                Succeeded = false;
            }
            else
            {
                for (var i = 1; i < RetElementCount; i++)
                {
                    if ((result[i] != firstOp[i + 2]))
                    {
                        Succeeded = false;
                        break;
                    }
                }
            }

            if (!Succeeded)
            {
                Console.WriteLine($"{nameof(Avx)}.{nameof(Avx.ExtractVector128)}<UInt64>(Vector256<UInt64><9>): {method} failed:");
                Console.WriteLine($"  firstOp: ({string.Join(", ", firstOp)})");
                Console.WriteLine($"   result: ({string.Join(", ", result)})");
                Console.WriteLine();
            }
        }
    }
}
