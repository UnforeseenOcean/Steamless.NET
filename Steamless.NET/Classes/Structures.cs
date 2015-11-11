﻿/**
 * Steamless Steam DRM Remover
 * (c) 2015 atom0s [atom0s@live.com]
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see http://www.gnu.org/licenses/
 */

namespace Steamless.NET.Classes
{
    using System;
    using System.Runtime.InteropServices;

    public static class Structures
    {
        /// <summary>
        /// IMAGE_DOS_HEADER Structure
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct ImageDosHeader
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public char[] e_magic;

            public ushort e_cblp;
            public ushort e_cp;
            public ushort e_crlc;
            public ushort e_cparhdr;
            public ushort e_minalloc;
            public ushort e_maxalloc;
            public ushort e_ss;
            public ushort e_sp;
            public ushort e_csum;
            public ushort e_ip;
            public ushort e_cs;
            public ushort e_lfarlc;
            public ushort e_ovno;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public ushort[] e_res1;

            public ushort e_oemid;
            public ushort e_oeminfo;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public ushort[] e_res2;

            public int e_lfanew;

            /// <summary>
            /// Gets if this structure is valid for a PE file.
            /// </summary>
            public bool IsValid
            {
                get { return new string(this.e_magic) == "MZ"; }
            }
        }

        /// <summary>
        /// IMAGE_NT_HEADERS Structure
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        public struct ImageNtHeaders64
        {
            [FieldOffset(0)]
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public char[] Signature;

            [FieldOffset(4)]
            public ImageFileHeader FileHeader;

            [FieldOffset(24)]
            public ImageOptionalHeader64 OptionalHeader;

            /// <summary>
            /// Gets if this structure is valid for a PE file.
            /// </summary>
            public bool IsValid
            {
                get { return new string(this.Signature).Trim('\0') == "PE"; }
            }
        }

        /// <summary>
        /// IMAGE_FILE_HEADER Structure
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct ImageFileHeader
        {
            public ushort Machine;
            public ushort NumberOfSections;
            public uint TimeDateStamp;
            public uint PointerToSymbolTable;
            public uint NumberOfSymbols;
            public ushort SizeOfOptionalHeader;
            public ushort Characteristics;
        }

        /// <summary>
        /// Machine Type Enumeration
        /// </summary>
        public enum MachineType : ushort
        {
            Native = 0,
            I386 = 0x014C,
            Itanium = 0x0200,
            X64 = 0x8664
        }

        /// <summary>
        /// Magic Type Enumeration
        /// </summary>
        public enum MagicType : ushort
        {
            ImageNtOptionalHdr32Magic = 0x10B,
            ImageNtOptionalHdr64Magic = 0x20B
        }

        /// <summary>
        /// Sub System Type Enumeration
        /// </summary>
        public enum SubSystemType : ushort
        {
            ImageSubsystemUnknown = 0,
            ImageSubsystemNative = 1,
            ImageSubsystemWindowsGui = 2,
            ImageSubsystemWindowsCui = 3,
            ImageSubsystemPosixCui = 7,
            ImageSubsystemWindowsCeGui = 9,
            ImageSubsystemEfiApplication = 10,
            ImageSubsystemEfiBootServiceDriver = 11,
            ImageSubsystemEfiRuntimeDriver = 12,
            ImageSubsystemEfiRom = 13,
            ImageSubsystemXbox = 14

        }

        /// <summary>
        /// Dll Characteristics Type Enumeration
        /// </summary>
        public enum DllCharacteristicsType : ushort
        {
            Reserved0 = 0x0001,
            Reserved1 = 0x0002,
            Reserved2 = 0x0004,
            Reserved3 = 0x0008,
            ImageDllCharacteristicsDynamicBase = 0x0040,
            ImageDllCharacteristicsForceIntegrity = 0x0080,
            ImageDllCharacteristicsNxCompat = 0x0100,
            ImageDllcharacteristicsNoIsolation = 0x0200,
            ImageDllcharacteristicsNoSeh = 0x0400,
            ImageDllcharacteristicsNoBind = 0x0800,
            Reserved4 = 0x1000,
            ImageDllcharacteristicsWdmDriver = 0x2000,
            ImageDllcharacteristicsTerminalServerAware = 0x8000
        }

        /// <summary>
        /// IMAGE_OPTIONAL_HEADER32 Structure
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public struct ImageOptionalHeader64
        {
            public ushort Magic;
            public byte MajorLinkerVersion;
            public byte MinorLinkerVersion;
            public uint SizeOfCode;
            public uint SizeOfInitializedData;
            public uint SizeOfUninitializedData;
            public uint AddressOfEntryPoint;
            public uint BaseOfCode;
            public ulong ImageBase;
            public uint SectionAlignment;
            public uint FileAlignment;
            public ushort MajorOperatingSystemVersion;
            public ushort MinorOperatingSystemVersion;
            public ushort MajorImageVersion;
            public ushort MinorImageVersion;
            public ushort MajorSubsystemVersion;
            public ushort MinorSubsystemVersion;
            public uint Win32VersionValue;
            public uint SizeOfImage;
            public uint SizeOfHeaders;
            public uint CheckSum;
            public ushort Subsystem;
            public ushort DllCharacteristics;
            public ulong SizeOfStackReserve;
            public ulong SizeOfStackCommit;
            public ulong SizeOfHeapReserve;
            public ulong SizeOfHeapCommit;
            public uint LoaderFlags;
            public uint NumberOfRvaAndSizes;

            public ImageDataDirectory ExportTable;
            public ImageDataDirectory ImportTable;
            public ImageDataDirectory ResourceTable;
            public ImageDataDirectory ExceptionTable;
            public ImageDataDirectory CertificateTable;
            public ImageDataDirectory BaseRelocationTable;
            public ImageDataDirectory Debug;
            public ImageDataDirectory Architecture;
            public ImageDataDirectory GlobalPtr;
            public ImageDataDirectory TLSTable;
            public ImageDataDirectory LoadConfigTable;
            public ImageDataDirectory BoundImport;
            public ImageDataDirectory IAT;
            public ImageDataDirectory DelayImportDescriptor;
            public ImageDataDirectory CLRRuntimeHeader;
            public ImageDataDirectory Reserved;
        }

        /// <summary>
        /// IMAGE_DATA_DIRECTORY Structure
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct ImageDataDirectory
        {
            public uint VirtualAddress;
            public uint Size;
        }

        /// <summary>
        /// IMAGE_SECTION_HEADER Structure
        /// </summary>
        [StructLayout(LayoutKind.Explicit)]
        public struct ImageSectionHeader
        {
            [FieldOffset(0)]
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public char[] Name;

            [FieldOffset(8)]
            public uint VirtualSize;

            [FieldOffset(12)]
            public uint VirtualAddress;

            [FieldOffset(16)]
            public uint SizeOfRawData;

            [FieldOffset(20)]
            public uint PointerToRawData;

            [FieldOffset(24)]
            public uint PointerToRelocations;

            [FieldOffset(28)]
            public uint PointerToLinenumbers;

            [FieldOffset(32)]
            public ushort NumberOfRelocations;

            [FieldOffset(34)]
            public ushort NumberOfLinenumbers;

            [FieldOffset(36)]
            public DataSectionFlags Characteristics;

            /// <summary>
            /// Gets the section name of this current section object.
            /// </summary>
            public string SectionName
            {
                get { return new string(this.Name).Trim('\0'); }
            }
        }

        /// <summary>
        /// Data Section Flags Enumeration
        /// </summary>
        [Flags]
        public enum DataSectionFlags : uint
        {
            /// <summary>
            /// Reserved for future use.
            /// </summary>
            TypeReg = 0x00000000,

            /// <summary>
            /// Reserved for future use.
            /// </summary>
            TypeDsect = 0x00000001,

            /// <summary>
            /// Reserved for future use.
            /// </summary>
            TypeNoLoad = 0x00000002,

            /// <summary>
            /// Reserved for future use.
            /// </summary>
            TypeGroup = 0x00000004,

            /// <summary>
            /// The section should not be padded to the next boundary. This flag is obsolete and is replaced by IMAGE_SCN_ALIGN_1BYTES. This is valid only for object files.
            /// </summary>
            TypeNoPadded = 0x00000008,

            /// <summary>
            /// Reserved for future use.
            /// </summary>
            TypeCopy = 0x00000010,

            /// <summary>
            /// The section contains executable code.
            /// </summary>
            ContentCode = 0x00000020,

            /// <summary>
            /// The section contains initialized data.
            /// </summary>
            ContentInitializedData = 0x00000040,

            /// <summary>
            /// The section contains uninitialized data.
            /// </summary>
            ContentUninitializedData = 0x00000080,

            /// <summary>
            /// Reserved for future use.
            /// </summary>
            LinkOther = 0x00000100,

            /// <summary>
            /// The section contains comments or other information. The .drectve section has this type. This is valid for object files only.
            /// </summary>
            LinkInfo = 0x00000200,

            /// <summary>
            /// Reserved for future use.
            /// </summary>
            TypeOver = 0x00000400,

            /// <summary>
            /// The section will not become part of the image. This is valid only for object files.
            /// </summary>
            LinkRemove = 0x00000800,

            /// <summary>
            /// The section contains COMDAT data. For more information, see section 5.5.6, COMDAT Sections (Object Only). This is valid only for object files.
            /// </summary>
            LinkComDat = 0x00001000,

            /// <summary>
            /// Reset speculative exceptions handling bits in the TLB entries for this section.
            /// </summary>
            NoDeferSpecExceptions = 0x00004000,

            /// <summary>
            /// The section contains data referenced through the global pointer (GP).
            /// </summary>
            RelativeGp = 0x00008000,

            /// <summary>
            /// Reserved for future use.
            /// </summary>
            MemPurgeable = 0x00020000,

            /// <summary>
            /// Reserved for future use.
            /// </summary>
            Memory16Bit = 0x00020000,

            /// <summary>
            /// Reserved for future use.
            /// </summary>
            MemoryLocked = 0x00040000,

            /// <summary>
            /// Reserved for future use.
            /// </summary>
            MemoryPreload = 0x00080000,

            /// <summary>
            /// Align data on a 1-byte boundary. Valid only for object files.
            /// </summary>
            Align1Bytes = 0x00100000,

            /// <summary>
            /// Align data on a 2-byte boundary. Valid only for object files.
            /// </summary>
            Align2Bytes = 0x00200000,

            /// <summary>
            /// Align data on a 4-byte boundary. Valid only for object files.
            /// </summary>
            Align4Bytes = 0x00300000,

            /// <summary>
            /// Align data on an 8-byte boundary. Valid only for object files.
            /// </summary>
            Align8Bytes = 0x00400000,

            /// <summary>
            /// Align data on a 16-byte boundary. Valid only for object files.
            /// </summary>
            Align16Bytes = 0x00500000,

            /// <summary>
            /// Align data on a 32-byte boundary. Valid only for object files.
            /// </summary>
            Align32Bytes = 0x00600000,

            /// <summary>
            /// Align data on a 64-byte boundary. Valid only for object files.
            /// </summary>
            Align64Bytes = 0x00700000,

            /// <summary>
            /// Align data on a 128-byte boundary. Valid only for object files.
            /// </summary>
            Align128Bytes = 0x00800000,

            /// <summary>
            /// Align data on a 256-byte boundary. Valid only for object files.
            /// </summary>
            Align256Bytes = 0x00900000,

            /// <summary>
            /// Align data on a 512-byte boundary. Valid only for object files.
            /// </summary>
            Align512Bytes = 0x00A00000,

            /// <summary>
            /// Align data on a 1024-byte boundary. Valid only for object files.
            /// </summary>
            Align1024Bytes = 0x00B00000,

            /// <summary>
            /// Align data on a 2048-byte boundary. Valid only for object files.
            /// </summary>
            Align2048Bytes = 0x00C00000,

            /// <summary>
            /// Align data on a 4096-byte boundary. Valid only for object files.
            /// </summary>
            Align4096Bytes = 0x00D00000,

            /// <summary>
            /// Align data on an 8192-byte boundary. Valid only for object files.
            /// </summary>
            Align8192Bytes = 0x00E00000,

            /// <summary>
            /// The section contains extended relocations.
            /// </summary>
            LinkExtendedRelocationOverflow = 0x01000000,

            /// <summary>
            /// The section can be discarded as needed.
            /// </summary>
            MemoryDiscardable = 0x02000000,

            /// <summary>
            /// The section cannot be cached.
            /// </summary>
            MemoryNotCached = 0x04000000,

            /// <summary>
            /// The section is not pageable.
            /// </summary>
            MemoryNotPaged = 0x08000000,

            /// <summary>
            /// The section can be shared in memory.
            /// </summary>
            MemoryShared = 0x10000000,

            /// <summary>
            /// The section can be executed as code.
            /// </summary>
            MemoryExecute = 0x20000000,

            /// <summary>
            /// The section can be read.
            /// </summary>
            MemoryRead = 0x40000000,

            /// <summary>
            /// The section can be written to.
            /// </summary>
            MemoryWrite = 0x80000000
        }
    }
}