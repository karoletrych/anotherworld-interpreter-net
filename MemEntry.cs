
public static class MemEntryState {
    public const byte END_OF_MEMLIST = 0xff;
    public const byte NOT_NEEDED = 0x00;
    public const byte LOADED = 0x01;
    public const byte LOAD_ME = 0x02;
}

struct MemEntry {
	public byte state;         // 0x0
	public byte type;          // 0x1, Resource::ResType
	// TODO: ubyte *bufPtr;       // 0x2
	public ushort unk4;         // 0x4, unused
	public byte rankNum;       // 0x6
	public byte bankId;       // 0x7
	public uint bankOffset;      // 0x8 0xA
	public ushort unkC;         // 0xC, unused
	public ushort packedSize;   // 0xE
		                      // All ressources are packed (for a gain of 28% according to Chahi)
	public ushort unk10;        // 0x10, unused
	public ushort size; // 0x12
};
/*
     Note: state is not a boolean, it can have value 0, 1, 2 or 255, respectively meaning:
      0:NOT_NEEDED
      1:LOADED
      2:LOAD_ME
      255:END_OF_MEMLIST

    See MEMENTRY_STATE_* #defines above.
*/
