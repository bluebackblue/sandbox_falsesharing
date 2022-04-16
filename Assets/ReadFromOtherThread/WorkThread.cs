

/** ReadFromOtherThread
*/
namespace ReadFromOtherThread
{
	/** WorkThread
	*/
	public sealed class WorkThread : System.IDisposable
	{
		/** execute
		*/
		public WorkThread_Execute_Base execute;

		/** raw
		*/
		public System.Threading.Thread raw;

		/** constructor
		*/
		public WorkThread(WorkThread_Execute_Base a_execute)
		{
			//execute
			this.execute = a_execute;

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
			t_this.execute.ThreadMain();
		}
	}
}

