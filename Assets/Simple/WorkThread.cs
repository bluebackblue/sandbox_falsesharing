

/** Simple
*/
namespace Simple
{
	/** WorkThread
	*/
	public sealed class WorkThread : System.IDisposable
	{
		/** execute
		*/
		public WorkThread_Execute_Base execute;

		/** coremask
		*/
		public System.UInt64 coremask;

		/** raw
		*/
		public System.Threading.Thread raw;

		/** constructor
		*/
		public WorkThread(WorkThread_Execute_Base a_execute,System.UInt64 a_coremask)
		{
			//execute
			this.execute = a_execute;

			//coremask
			this.coremask = a_coremask;

			//raw
			this.raw = new System.Threading.Thread(Inner_ThreadMain);
			this.raw.Start(this);
		}

		/** [System.IDisposable]Dispose
		*/
		public void Dispose()
		{
			this.raw.Join();
			this.raw = null;
		}

		/** Inner_ThreadMain
		*/
		private static void Inner_ThreadMain(object a_param)
		{
			WorkThread t_this = (WorkThread)a_param;

			#if((UNITY_STANDALONE_WIN)||(UNITY_EDITOR_WIN))
			Win_Kernel32.SetThreadAffinityMask(Win_Kernel32.GetCurrentThread(),(int)t_this.coremask);
			#endif

			t_this.execute.ThreadMain();
		}
	}
}

