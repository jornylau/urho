using System;
using System.Runtime.InteropServices;
using Urho.Audio;
using Urho.Navigation;
using Urho.Physics;
using Urho.Urho2D;
using Urho.Resources;
using Urho.Gui;
using Urho.Network;

namespace Urho {

	/// <summary>
	/// Helper functions to return elements from a VariantMap
	/// </summary>
	internal static class UrhoMap  {
		[DllImport (Consts.NativeImport, CallingConvention=CallingConvention.Cdecl)]
		extern static IntPtr urho_map_get_ptr (IntPtr handle, int stringHash);

		static public SoundSource get_SoundSource(IntPtr handle, int stringHash)
		{
			return Runtime.LookupObject<SoundSource>(urho_map_get_ptr(handle, stringHash));
		}

		static public Sound get_Sound(IntPtr handle, int stringHash)
		{
			return Runtime.LookupObject<Sound>(urho_map_get_ptr(handle, stringHash));
		}

		static public Animation get_Animation(IntPtr handle, int stringHash)
		{
			return Runtime.LookupObject<Animation>(urho_map_get_ptr(handle, stringHash));
		}

		static public ParticleEffect get_ParticleEffect(IntPtr handle, int stringHash)
		{
			return Runtime.LookupObject<ParticleEffect>(urho_map_get_ptr(handle, stringHash));
		}

		static public Camera get_Camera (IntPtr handle, int stringHash)
		{
			return Runtime.LookupObject<Camera>(urho_map_get_ptr(handle, stringHash));
		}
		
		static public Component get_Component (IntPtr handle, int stringHash)
		{
			return Runtime.LookupObject<Component>(urho_map_get_ptr(handle, stringHash));
		}
		
		static public Connection get_Connection (IntPtr handle, int stringHash)
		{
			return Runtime.LookupObject<Connection>(urho_map_get_ptr(handle, stringHash));
		}
		
		static public CrowdAgent get_CrowdAgent (IntPtr handle, int stringHash)
		{
			return Runtime.LookupObject<CrowdAgent>(urho_map_get_ptr(handle, stringHash));
		}
		
		static public IntPtr get_IntPtr (IntPtr handle, int stringHash)
		{
			return urho_map_get_ptr (handle, stringHash);
		}
		
		static public MouseMode get_MouseMode (IntPtr handle, int stringHash)
		{
			return (MouseMode) urho_map_get_int (handle, stringHash);
		}
		
		static public NavigationMesh get_NavigationMesh (IntPtr handle, int stringHash)
		{
			return Runtime.LookupObject<NavigationMesh>(urho_map_get_ptr(handle, stringHash));
		}
		
		static public Node get_Node (IntPtr handle, int stringHash)
		{
			return Runtime.LookupObject<Node>(urho_map_get_ptr(handle, stringHash));
		}
		
		static public UrhoObject get_Object (IntPtr handle, int stringHash)
		{
			return Runtime.LookupObject<UrhoObject>(urho_map_get_ptr(handle, stringHash));
		}
		
		static public Obstacle get_Obstacle (IntPtr handle, int stringHash)
		{
			return Runtime.LookupObject<Obstacle>(urho_map_get_ptr(handle, stringHash));
		}

		static public PhysicsWorld get_PhysicsWorld (IntPtr handle, int stringHash)
		{
			return Runtime.LookupObject<PhysicsWorld>(urho_map_get_ptr(handle, stringHash));
		}
		
		static public PhysicsWorld2D get_PhysicsWorld2D (IntPtr handle, int stringHash)
		{
			return Runtime.LookupObject<PhysicsWorld2D>(urho_map_get_ptr(handle, stringHash));
		}
		
		static public RenderSurface get_RenderSurface (IntPtr handle, int stringHash)
		{
			var ptr = urho_map_get_ptr(handle, stringHash);
			return ptr == IntPtr.Zero ? null : new RenderSurface(ptr);
		}
		
		static public Resource get_Resource  (IntPtr handle, int stringHash)
		{
			return Runtime.LookupObject<Resource>(urho_map_get_ptr(handle, stringHash));
		}
		
		static public RigidBody get_RigidBody (IntPtr handle, int stringHash)
		{
			return Runtime.LookupObject<RigidBody>(urho_map_get_ptr(handle, stringHash));
		}
		
		static public RigidBody2D get_RigidBody2D (IntPtr handle, int stringHash)
		{
			return Runtime.LookupObject<RigidBody2D>(urho_map_get_ptr(handle, stringHash));
		}
		
		static public Scene get_Scene (IntPtr handle, int stringHash)
		{
			return Runtime.LookupObject<Scene>(urho_map_get_ptr(handle, stringHash));
		}
		
		static public Serializable get_Serializable (IntPtr handle, int stringHash)
		{
			throw new Exception ("Not implemented, as we need to figure out serializable mapping");
		}

		[DllImport (Consts.NativeImport, CallingConvention=CallingConvention.Cdecl)]
		extern static IntPtr urho_map_get_buffer (IntPtr handle, int stringHash, out int size);
		static public CollisionData [] get_CollisionData (IntPtr handle, int stringHash)
		{
			int size;
			var buffer = urho_map_get_buffer (handle, stringHash, out size);
			return CollisionData.FromContactData (buffer, size);
		}

		static public byte[] get_Buffer(IntPtr handle, int stringHash)
		{
			int size;
			var buffer = urho_map_get_buffer(handle, stringHash, out size);
			var bytes = new byte[size];
			Marshal.Copy(buffer, bytes, 0, size);
			return bytes;
		}

		[DllImport (Consts.NativeImport, CallingConvention=CallingConvention.Cdecl)]
		extern static IntPtr urho_map_get_String (IntPtr handle, int stringHash);
		static public string get_String (IntPtr handle, int stringHash)
		{
			return Marshal.PtrToStringAnsi(urho_map_get_String (handle, stringHash));
		}
		
		[DllImport (Consts.NativeImport, CallingConvention=CallingConvention.Cdecl)]
		extern static int urho_map_get_StringHash (IntPtr handle, int stringHash);
		static public StringHash get_StringHash (IntPtr handle, int stringHash)
		{
			return new StringHash (urho_map_get_StringHash (handle, stringHash));
		}
		
		static public Texture get_Texture (IntPtr handle, int stringHash)
		{
			return Runtime.LookupObject<Texture>(urho_map_get_ptr(handle, stringHash));
		}
	
		[DllImport (Consts.NativeImport, CallingConvention=CallingConvention.Cdecl)]
		extern static Variant urho_map_get_Variant (IntPtr handle, int stringHash);
		static public Variant get_Variant (IntPtr handle, int stringHash)
		{
			return urho_map_get_Variant (handle, stringHash);
		}
		
		[DllImport (Consts.NativeImport, CallingConvention=CallingConvention.Cdecl)]
		extern static Vector3 urho_map_get_Vector3 (IntPtr handle, int stringHash);
		static public Vector3 get_Vector3 (IntPtr handle, int stringHash)
		{
			return urho_map_get_Vector3 (handle, stringHash);
		}
		
		static public View get_View (IntPtr handle, int stringHash)
		{
			var ptr = urho_map_get_ptr(handle, stringHash);
			return ptr == IntPtr.Zero ? null : new View(ptr);
		}
		
		static public UIElement get_UIElement (IntPtr handle, int stringHash)
		{
			return Runtime.LookupObject<UIElement>(urho_map_get_ptr(handle, stringHash));
		}

		static public WorkItem get_WorkItem (IntPtr handle, int stringHash)
		{
			return new WorkItem (urho_map_get_ptr (handle, stringHash));
		}
		
		[DllImport (Consts.NativeImport, CallingConvention=CallingConvention.Cdecl)]
		extern static bool urho_map_get_bool (IntPtr handle, int stringHash);
		static public bool get_bool (IntPtr handle, int stringHash)
		{
			return urho_map_get_bool (handle, stringHash);
		}
		
		[DllImport (Consts.NativeImport, CallingConvention=CallingConvention.Cdecl)]
		extern static float urho_map_get_float (IntPtr handle, int stringHash);
		static public float get_float (IntPtr handle, int stringHash)
		{
			return urho_map_get_float (handle, stringHash);
		}
		
		[DllImport (Consts.NativeImport, CallingConvention=CallingConvention.Cdecl)]
		extern static int urho_map_get_int (IntPtr handle, int stringHash);
		static public int get_int (IntPtr handle, int stringHash)
		{
			return urho_map_get_int (handle, stringHash);
		}
		
		[DllImport (Consts.NativeImport, CallingConvention=CallingConvention.Cdecl)]
		extern static uint urho_map_get_uint (IntPtr handle, int stringHash);
		static public uint get_uint (IntPtr handle, int stringHash)
		{
			return urho_map_get_uint (handle, stringHash);
		}
		
	}
}
