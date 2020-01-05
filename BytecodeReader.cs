using System.Collections.Generic;
using System.IO;

namespace anotherworld_interpreter_net
{
    class BytecodeReader
    {
        const string MemListFileName = "memlist.bin";
        const string InputPath = "input";
        internal List<MemEntry> Read()
        {
            string filepath = Path.Join(InputPath, MemListFileName);
            if (!File.Exists(filepath))
            {
                throw new BytecodeReaderException($"Memlist file not found at {filepath}");
            }

            using (BinaryReader reader = new BinaryReader(File.OpenRead(filepath)))
            {
                var memEntries = new List<MemEntry>();

                var memEntry = new MemEntry();
                while (memEntry.state != MemEntryState.END_OF_MEMLIST)
                {
                    memEntry.state = reader.ReadByte();
                    memEntry.type = reader.ReadByte();

                    // skip the bufptr
                    reader.ReadUInt16BE();

                    memEntry.unk4 = reader.ReadUInt16BE();
                    memEntry.rankNum = reader.ReadByte();
                    memEntry.bankId = reader.ReadByte();
                    memEntry.bankOffset = reader.ReadUInt32BE();
                    memEntry.unkC = reader.ReadUInt16BE();
                    memEntry.packedSize = reader.ReadUInt16BE();
                    memEntry.unk10 = reader.ReadUInt16BE();
                    memEntry.size = reader.ReadUInt16BE();

                    memEntries.Add(memEntry);
                }

                return memEntries;

            }
        }
    }
}
