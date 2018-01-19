/*
MAVLink protocol implementation (auto-generated by mavgen.py)

Generated from: oroca_bldc.xml

Note: this file has been auto-generated. DO NOT EDIT
*/

using System;

    
using System.Reflection;    
    
[assembly: AssemblyTitle("Mavlink Classes")]
[assembly: AssemblyDescription("Generated Message Classes for Mavlink. See http://qgroundcontrol.org/mavlink/start")]
[assembly: AssemblyProduct("Mavlink")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

    namespace MavLink
{

}

    
   
namespace MavLink
{

    public abstract class MavlinkMessage
    {
        public abstract int Serialize(byte[] bytes, ref int offset);
    }
	public class Msg_ack : MavlinkMessage
    {

		/// <summary>
		/// 
		/// </summary>
		public byte msg_id;

		/// <summary>
		/// 
		/// </summary>
		public UInt16 err_code;

		/// <summary>
		/// 
		/// </summary>
		public byte length;

		/// <summary>
		/// 
		/// </summary>
		public byte[] data; // Array size 16

        public override int Serialize(byte[] bytes, ref int offset)
            {
                return MavLinkSerializer.Serialize_ACK(this, bytes, ref offset);
            }        
	}

	public class Msg_read_version : MavlinkMessage
    {

		/// <summary>
		/// 0:No Resp, 1:Resp
		/// </summary>
		public byte resp;

		/// <summary>
		/// 
		/// </summary>
		public byte[] param; // Array size 8

        public override int Serialize(byte[] bytes, ref int offset)
            {
                return MavLinkSerializer.Serialize_READ_VERSION(this, bytes, ref offset);
            }        
	}

	public class Msg_read_board_name : MavlinkMessage
    {

		/// <summary>
		/// 0:No Resp, 1:Resp
		/// </summary>
		public byte resp;

		/// <summary>
		/// 
		/// </summary>
		public byte[] param; // Array size 8

        public override int Serialize(byte[] bytes, ref int offset)
            {
                return MavLinkSerializer.Serialize_READ_BOARD_NAME(this, bytes, ref offset);
            }        
	}

	public class Msg_read_tag : MavlinkMessage
    {

		/// <summary>
		/// 0:No Resp, 1:Resp
		/// </summary>
		public byte resp;

		/// <summary>
		/// 
		/// </summary>
		public byte type;

		/// <summary>
		/// 
		/// </summary>
		public byte[] param; // Array size 8

        public override int Serialize(byte[] bytes, ref int offset)
            {
                return MavLinkSerializer.Serialize_READ_TAG(this, bytes, ref offset);
            }        
	}

	public class Msg_set_velocity : MavlinkMessage
    {

		/// <summary>
		/// 0:No Resp, 1:Resp
		/// </summary>
		public byte resp;

		/// <summary>
		/// velocity value
		/// </summary>
		public UInt16 ref_angular_velocity;

        public override int Serialize(byte[] bytes, ref int offset)
            {
                return MavLinkSerializer.Serialize_SET_VELOCITY(this, bytes, ref offset);
            }        
	}


	/// <summary>
	/// debug String
	/// </summary>
	public class Msg_debug_string : MavlinkMessage
    {

		/// <summary>
		/// 0:No Resp, 1:Resp
		/// </summary>
		public byte resp;

		/// <summary>
		/// string
		/// </summary>
		public byte[] dbg_str; // Array size 250

        public override int Serialize(byte[] bytes, ref int offset)
            {
                return MavLinkSerializer.Serialize_DEBUG_STRING(this, bytes, ref offset);
            }        
	}

}

