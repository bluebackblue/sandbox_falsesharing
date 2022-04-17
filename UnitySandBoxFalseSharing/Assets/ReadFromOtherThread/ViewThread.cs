

/** ReadFromOtherThread
*/
namespace ReadFromOtherThread
{
	/** ViewThread
	*/
	public sealed class ViewThread : System.IDisposable
	{
		/** VIEWTICKS
		*/
		private const int VIEWTICKS = 5000000;

		/** sharedata
		*/
		private ShareData sharedata;

		/** log
		*/
		private Log log;

		/** cancel
		*/
		private bool cancel;

		/** raw
		*/
		private System.Threading.Thread raw;

		/** viewvalue
		*/
		public System.UInt64 viewvalue;

		/** coremask
		*/
		public System.UInt64 coremask;

		/** constructor
		*/
		public ViewThread(ShareData a_sharedata,Log a_log,System.UInt64 a_coremask)
		{
			//sharedata
			this.sharedata = a_sharedata;

			//log
			this.log = a_log;

			//cancel
			this.cancel = false;

			//viewvalue
			this.viewvalue = 0;

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
			this.cancel = true;
			System.Threading.Thread.MemoryBarrier();
			this.raw.Join();
			this.raw = null;
		}

		/** Inner_ThreadMain
		*/
		private static void Inner_ThreadMain(object a_param)
		{
			ViewThread t_this = (ViewThread)a_param;

			#if((UNITY_STANDALONE_WIN)||(UNITY_EDITOR_WIN))
			Win_Kernel32.SetThreadAffinityMask(Win_Kernel32.GetCurrentThread(),(int)t_this.coremask);
			#endif

			ref System.UInt64 t_value = ref t_this.sharedata.value;

			long t_ticks = System.DateTime.UtcNow.Ticks;

			while(true){
				System.Threading.Thread.Sleep(0);

				t_this.viewvalue = t_value;

				long t_ticks_new = System.DateTime.UtcNow.Ticks;
				if(t_ticks_new - t_ticks > VIEWTICKS){
					t_ticks = t_ticks_new;
					lock(t_this.log){
						t_this.log.stringbuffer.Append(string.Format("view = {0}\n",t_this.viewvalue));
					}
				}

				//cancel
				bool t_cancel = t_this.cancel;
				System.Threading.Thread.MemoryBarrier();
				if(t_cancel == true){
					break;
				}
			}
		}
	}
}

