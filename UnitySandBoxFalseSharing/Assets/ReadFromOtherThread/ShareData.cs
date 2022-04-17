

/** ReadFromOtherThread
*/
namespace ReadFromOtherThread
{
	/** ShareData
	*/
	public class ShareData
	{
		/** LOOP_MAX
		*/
		#if(UNITY_EDITOR)
		public const int LOOP_MAX = 20000;
		#else
		public const int LOOP_MAX = 80000;
		#endif

		/** value
		*/
		public System.UInt64 value;
	}
}


