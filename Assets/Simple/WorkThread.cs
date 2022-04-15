

/** Simple
*/
namespace Simple
{
	/** WorkThread
	*/
	public sealed class WorkThread
	{
		/** raw
		*/
		public System.Threading.Thread raw;

		/** theradid
		*/
		public int theradid;

		/** 処理時間計測。
		*/
		public System.Diagnostics.Stopwatch stopwatch;

		/** execute
		*/
		public WorkThread_Execute_Base execute;

		/** constructor
		*/
		public WorkThread()
		{
			//raw
			this.raw = null;

			//theradid
			this.theradid = 0;

			//stopwatch
			this.stopwatch = new System.Diagnostics.Stopwatch();

			//execute
			this.execute = null;
		}

		/** Initialize
		*/
		public void Initialize(WorkThread_Execute_Base a_execute)
		{
			//execute
			this.execute = a_execute;

			//stopwatch
			this.stopwatch.Reset();

			//raw
			this.raw = new System.Threading.Thread(Inner_ThreadMain);
		}

		/** スレッド開始。
		*/
		public void Start()
		{
			this.raw.Start(this);
		}

		/** スレッド終了。
		*/
		public void End()
		{
			this.raw.Join();
			this.raw = null;
		}

		/** Inner_ThreadMain
		*/
		private static void Inner_ThreadMain(object a_param)
		{
			WorkThread t_this = (WorkThread)a_param;

			//theradid
			#pragma warning disable 0618
			t_this.theradid = System.AppDomain.GetCurrentThreadId();
			#pragma warning restore

			//計測開始。
			t_this.stopwatch.Start();

			//実行。
			t_this.execute.ThreadMain();

			//計測終了。
			t_this.stopwatch.Stop();
		}
	}
}

