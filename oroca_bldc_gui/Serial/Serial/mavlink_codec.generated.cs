

/*
MAVLink protocol implementation (auto-generated by mavgen.py)

Note: this file has been auto-generated. DO NOT EDIT
*/

using System;
using System.Collections;
using System.Collections.Generic;
    
namespace MavLink
{
    public static class MavlinkSettings
    {
		public const string WireProtocolVersion = "1.0";
		public const byte ProtocolMarker = 0xfe;
		public const bool CrcExtra = true;
		public const bool IsLittleEndian = true;
    }
    
    public delegate MavlinkMessage MavlinkPacketDeserializeFunc(byte[] bytes, int offset);

    //returns the message ID, offset is advanced by the number of bytes used to serialize
    public delegate int MavlinkPacketSerializeFunc(byte[] bytes, ref int offset, object mavlinkPacket);
 
    public class MavPacketInfo
    {
        public MavlinkPacketDeserializeFunc Deserializer;
        public int [] OrderMap;
        public byte CrcExtra;

         public MavPacketInfo(MavlinkPacketDeserializeFunc deserializer, byte crcExtra)
         {
             this.Deserializer = deserializer;
             this.CrcExtra = crcExtra;
         }
    }
 
    public static class MavLinkSerializer
    {
        public static void SetDataIsLittleEndian(bool isLittle)
        {
            bitconverter.SetDataIsLittleEndian(isLittle);
        }
    
        private static readonly FrameworkBitConverter bitconverter = new FrameworkBitConverter(); 
    
        public static Dictionary<int, MavPacketInfo> Lookup = new Dictionary<int, MavPacketInfo>
        {
			{150, new MavPacketInfo(Deserialize_ACK, 192)},
			{151, new MavPacketInfo(Deserialize_READ_VERSION, 166)},
			{152, new MavPacketInfo(Deserialize_READ_BOARD_NAME, 140)},
			{153, new MavPacketInfo(Deserialize_READ_TAG, 126)},
			{220, new MavPacketInfo(Deserialize_SET_VELOCITY, 249)},
			{221, new MavPacketInfo(Deserialize_SET_MCCONF, 107)},
			{222, new MavPacketInfo(Deserialize_SET_APPCONF, 33)},
			{0, new MavPacketInfo(Deserialize_DEBUG_STRING, 50)},
		};

		internal static MavlinkMessage Deserialize_ACK(byte[] bytes, int offset)
		{
			return new Msg_ack
			{
				err_code = bitconverter.ToUInt16(bytes, offset + 0),
				msg_id = bytes[offset + 2],
				length = bytes[offset + 3],
				data =  ByteArrayUtil.ToUInt8(bytes, offset + 4, 16),
			};
		}

		internal static MavlinkMessage Deserialize_READ_VERSION(byte[] bytes, int offset)
		{
			return new Msg_read_version
			{
				resp = bytes[offset + 0],
				param =  ByteArrayUtil.ToUInt8(bytes, offset + 1, 8),
			};
		}

		internal static MavlinkMessage Deserialize_READ_BOARD_NAME(byte[] bytes, int offset)
		{
			return new Msg_read_board_name
			{
				resp = bytes[offset + 0],
				param =  ByteArrayUtil.ToUInt8(bytes, offset + 1, 8),
			};
		}

		internal static MavlinkMessage Deserialize_READ_TAG(byte[] bytes, int offset)
		{
			return new Msg_read_tag
			{
				resp = bytes[offset + 0],
				type = bytes[offset + 1],
				param =  ByteArrayUtil.ToUInt8(bytes, offset + 2, 8),
			};
		}

		internal static MavlinkMessage Deserialize_SET_VELOCITY(byte[] bytes, int offset)
		{
			return new Msg_set_velocity
			{
				ref_angular_velocity = bitconverter.ToUInt16(bytes, offset + 0),
				resp = bytes[offset + 2],
			};
		}

		internal static MavlinkMessage Deserialize_SET_MCCONF(byte[] bytes, int offset)
		{
			return new Msg_set_mcconf
			{
				uRSHUNT = bitconverter.ToUInt16(bytes, offset + 0),
				uPWMFREQUENCY = bitconverter.ToUInt16(bytes, offset + 2),
				uDKP = bitconverter.ToUInt16(bytes, offset + 4),
				uDKI = bitconverter.ToUInt16(bytes, offset + 6),
				uDKC = bitconverter.ToUInt16(bytes, offset + 8),
				uDOUTMAX = bitconverter.ToUInt16(bytes, offset + 10),
				uQKP = bitconverter.ToUInt16(bytes, offset + 12),
				uQKI = bitconverter.ToUInt16(bytes, offset + 14),
				uQKC = bitconverter.ToUInt16(bytes, offset + 16),
				uQOUTMAX = bitconverter.ToUInt16(bytes, offset + 18),
				uWKP = bitconverter.ToUInt16(bytes, offset + 20),
				uWKI = bitconverter.ToUInt16(bytes, offset + 22),
				uWKC = bitconverter.ToUInt16(bytes, offset + 24),
				uWOUTMAX = bitconverter.ToUInt16(bytes, offset + 26),
				uPLLKP = bitconverter.ToUInt16(bytes, offset + 28),
				uPLLKI = bitconverter.ToUInt16(bytes, offset + 30),
				uPLLKC = bitconverter.ToUInt16(bytes, offset + 32),
				uPLLOUTMAX = bitconverter.ToUInt16(bytes, offset + 34),
				resp = bytes[offset + 36],
				uVDD = bytes[offset + 37],
			};
		}

		internal static MavlinkMessage Deserialize_SET_APPCONF(byte[] bytes, int offset)
		{
			return new Msg_set_appconf
			{
				data =  ByteArrayUtil.ToUInt16(bytes, offset + 0, 128),
				resp = bytes[offset + 256],
			};
		}

		internal static MavlinkMessage Deserialize_DEBUG_STRING(byte[] bytes, int offset)
		{
			return new Msg_debug_string
			{
				dbg_str =  ByteArrayUtil.ToChar(bytes, offset + 0, 250),
			};
		}

		internal static int Serialize_ACK(this Msg_ack msg, byte[] bytes, ref int offset)
		{
			bitconverter.GetBytes(msg.err_code, bytes, offset + 0);
			bytes[offset + 2] = msg.msg_id;
			bytes[offset + 3] = msg.length;
			ByteArrayUtil.ToByteArray(msg.data, bytes, offset + 4, 16);
			offset += 20;
			return 150;
		}

		internal static int Serialize_READ_VERSION(this Msg_read_version msg, byte[] bytes, ref int offset)
		{
			bytes[offset + 0] = msg.resp;
			ByteArrayUtil.ToByteArray(msg.param, bytes, offset + 1, 8);
			offset += 9;
			return 151;
		}

		internal static int Serialize_READ_BOARD_NAME(this Msg_read_board_name msg, byte[] bytes, ref int offset)
		{
			bytes[offset + 0] = msg.resp;
			ByteArrayUtil.ToByteArray(msg.param, bytes, offset + 1, 8);
			offset += 9;
			return 152;
		}

		internal static int Serialize_READ_TAG(this Msg_read_tag msg, byte[] bytes, ref int offset)
		{
			bytes[offset + 0] = msg.resp;
			bytes[offset + 1] = msg.type;
			ByteArrayUtil.ToByteArray(msg.param, bytes, offset + 2, 8);
			offset += 10;
			return 153;
		}

		internal static int Serialize_SET_VELOCITY(this Msg_set_velocity msg, byte[] bytes, ref int offset)
		{
			bitconverter.GetBytes(msg.ref_angular_velocity, bytes, offset + 0);
			bytes[offset + 2] = msg.resp;
			offset += 3;
			return 220;
		}

		internal static int Serialize_SET_MCCONF(this Msg_set_mcconf msg, byte[] bytes, ref int offset)
		{
			bitconverter.GetBytes(msg.uRSHUNT, bytes, offset + 0);
			bitconverter.GetBytes(msg.uPWMFREQUENCY, bytes, offset + 2);
			bitconverter.GetBytes(msg.uDKP, bytes, offset + 4);
			bitconverter.GetBytes(msg.uDKI, bytes, offset + 6);
			bitconverter.GetBytes(msg.uDKC, bytes, offset + 8);
			bitconverter.GetBytes(msg.uDOUTMAX, bytes, offset + 10);
			bitconverter.GetBytes(msg.uQKP, bytes, offset + 12);
			bitconverter.GetBytes(msg.uQKI, bytes, offset + 14);
			bitconverter.GetBytes(msg.uQKC, bytes, offset + 16);
			bitconverter.GetBytes(msg.uQOUTMAX, bytes, offset + 18);
			bitconverter.GetBytes(msg.uWKP, bytes, offset + 20);
			bitconverter.GetBytes(msg.uWKI, bytes, offset + 22);
			bitconverter.GetBytes(msg.uWKC, bytes, offset + 24);
			bitconverter.GetBytes(msg.uWOUTMAX, bytes, offset + 26);
			bitconverter.GetBytes(msg.uPLLKP, bytes, offset + 28);
			bitconverter.GetBytes(msg.uPLLKI, bytes, offset + 30);
			bitconverter.GetBytes(msg.uPLLKC, bytes, offset + 32);
			bitconverter.GetBytes(msg.uPLLOUTMAX, bytes, offset + 34);
			bytes[offset + 36] = msg.resp;
			bytes[offset + 37] = msg.uVDD;
			offset += 38;
			return 221;
		}

		internal static int Serialize_SET_APPCONF(this Msg_set_appconf msg, byte[] bytes, ref int offset)
		{
			ByteArrayUtil.ToByteArray(msg.data, bytes, offset + 0, 128);
			bytes[offset + 256] = msg.resp;
			offset += 257;
			return 222;
		}

		internal static int Serialize_DEBUG_STRING(this Msg_debug_string msg, byte[] bytes, ref int offset)
		{
			ByteArrayUtil.ToByteArray(msg.dbg_str, bytes, offset + 0, 250);
			offset += 250;
			return 0;
		}
	}

}
