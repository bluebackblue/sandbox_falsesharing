

/** ReadFromOtherThread
*/
#if((UNITY_STANDALONE_WIN)||(UNITY_EDITOR_WIN))
namespace ReadFromOtherThread
{
	/** Win_Kernel32
	*/
	public static class Win_Kernel32
	{
		/** SetThreadAffinityMask
		*/
		[System.Runtime.InteropServices.DllImport("kernel32.dll")]
		public static extern int SetThreadAffinityMask(int hThread,int dwThreadAffinityMask);

		/** SetThreadAffinityMask
		*/
		[System.Runtime.InteropServices.DllImport("kernel32.dll")]
		public static extern int GetCurrentThread();
	}
}
#endif

