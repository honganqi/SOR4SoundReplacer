using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOR4SoundReplacer
{
    public class Library
    {
        public class BNK
        {
            public string fileName { get; set; }
            public List<Chunk> chunkList { get; set; }
            public List<string> chunkIndex { get; set; }
        }

        public class Chunk
        {
            public string dwTag { get; set; }
            public uint dwChunkSize { get; set; }
            public uint dwBankGeneratorVersion { get; set; }
            public uint dwSoundBankID { get; set; }
            public uint dwLanguageID { get; set; }
            public ushort bUnused { get; set; }
            public ushort bDeviceAllocated { get; set; }
            public uint dwProjectID { get; set; }
            public byte[] padding { get; set; }
            public List<MediaHeader> pLoadedMedia { get; set; }
            public byte[] pData { get; set; }
            public byte[] hircdata { get; set; }
        }

        public class MediaHeader
        {
            public int id { get; set; }
            public int uOffset { get; set; }
            public int uSize { get; set; }
        }

        public class WEM
        {
            public int id { get; set; }
            public byte[] data { get; set; }
        }


        public int GetPadding(int currentPos, int alignment)
        {
            int padding = Modulo(currentPos * -1, alignment);
            return padding;
        }

        private void RemoveByteSection(ref byte[] byteArray, int offset, int size)
        {
            List<byte> original = new List<byte>(byteArray);
            if (offset + size > byteArray.Length)
            {
                size = byteArray.Length - offset;
            }
            original.RemoveRange(offset, size);
            byteArray = original.ToArray();
        }

        private void InsertByteSection(ref byte[] byteArray, int offset, byte[] input)
        {
            int newWEMPadding = GetPadding(input.Length, 16);
            int paddedWEM = input.Length + newWEMPadding;

            List<byte> original = new List<byte>(byteArray);
            List<byte> inputarray = new List<byte>(input);
            inputarray.AddRange(Enumerable.Repeat<Byte>(0x0, newWEMPadding));
            original.InsertRange(offset, inputarray);
            Console.WriteLine("newbytes size: " + original.ToArray().Length);
            Console.WriteLine("new array with padding: " + inputarray.ToArray().Length);
            byteArray = original.ToArray();
            Console.WriteLine("newbytes size: " + byteArray.Length);
        }

        public byte[] ReplaceBytes(byte[] originalBytes, int offset, int sizeToRemove, byte[] bytesToInsert)
        {
            byte[] newBytes = null;
            if (offset >= 0)
            {
                int sizeOfBytesToInsertWithPadding = bytesToInsert.Length + GetPadding(bytesToInsert.Length, 16);
                byte[] bytesToInsertWithPadding = new byte[sizeOfBytesToInsertWithPadding];
                Buffer.BlockCopy(bytesToInsert, 0, bytesToInsertWithPadding, 0, bytesToInsert.Length);
                //Console.WriteLine("------");
                //Console.WriteLine(bytesToInsert.Length);
                //Console.WriteLine("New array with padding: " + bytesToInsertWithPadding.ToArray().Length);
                if (offset + sizeToRemove > originalBytes.Length)
                {
                    sizeToRemove = originalBytes.Length - offset;
                }
                newBytes = new byte[originalBytes.Length - sizeToRemove + sizeOfBytesToInsertWithPadding];
                //Console.WriteLine("original size: " + originalBytes.Length);
                //Console.WriteLine("size to remove: " + sizeToRemove);
                //Console.WriteLine("newbytes size: " + newBytes.Length);
                //Console.WriteLine("new array with padding: " + sizeOfBytesToInsertWithPadding);
                //Console.WriteLine(newBytes.Length);
                // copy all bytes before the insert/replace point (offset)
                Buffer.BlockCopy(originalBytes, 0, newBytes, 0, offset);
                // copy the new bytes starting at the offset of the new byte array
                Buffer.BlockCopy(bytesToInsertWithPadding, 0, newBytes, offset, bytesToInsertWithPadding.Length);
                // copy the remainder of the original bytes (starting at the offset + sizeOfBytesToReplace) into the new byte array
                Buffer.BlockCopy(
                    originalBytes,
                    offset + sizeToRemove,
                    newBytes,
                    offset + bytesToInsertWithPadding.Length,
                    originalBytes.Length - (offset + sizeToRemove));
            }
            return newBytes;
        }

        public Dictionary<int, int> CreateIndexDict(List<Library.MediaHeader> pLoadedMedia, string id_key)
        {
            Dictionary<int, int> index_dict = new Dictionary<int, int>();
            foreach (var dict in pLoadedMedia.Select((Index, Value) => new { Value, Index }))
            {
                index_dict[dict.Index.id] = dict.Value;
            }
            return index_dict;
        }


        private int Modulo(int a, int b)
        {
            return (((a % b) + b) % b);
        }

        public int CountMedia(Library.BNK bnk, string outputPath)
        {
            if (bnk.chunkIndex.Contains("DIDX") && bnk.chunkIndex.Contains("DATA"))
            {
                int chunkMediaIndex = bnk.chunkIndex.IndexOf("DIDX");
                int chunkDataIndex = bnk.chunkIndex.IndexOf("DATA");
                List<Library.WEM> newWemList = MainWindow.ReadNewWEMs(bnk.chunkList[chunkMediaIndex].pLoadedMedia, outputPath); //Passes list of wems in bnk
                return newWemList.Count();
            }
            return 0;
        }


    }
}
