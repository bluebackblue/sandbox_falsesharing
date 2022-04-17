

/** ReadFromOtherThread
*/
namespace ReadFromOtherThread
{
	/** Execute_2
	*/
	public sealed class Execute_2 : WorkThread_Execute_Base
	{
		/** mode
		*/
		public int mode;

		/** sharedata
		*/
		public ShareData sharedata;

		/** log
		*/
		public Log log;

		/** constructor
		*/
		public Execute_2(int a_mode,ShareData a_sharedata,Log a_log)
		{
			//mode
			this.mode = a_mode;

			//sharedata
			this.sharedata = a_sharedata;

			//log
			this.log = a_log;
		}

		/** [Simple.WorkThread_Execute_Base]スレッドから呼び出される。
		*/
		public void ThreadMain()
		{
			long t_ticks = System.DateTime.UtcNow.Ticks;
			{
				ref System.UInt64 t_value = ref this.sharedata.value;

				for(int xx=0;xx<ShareData.LOOP_MAX;xx++){
					for(int yy=0;yy<ShareData.LOOP_MAX;yy++){
						t_value += (System.UInt64)(xx + yy);
					}
					System.Threading.Thread.MemoryBarrier();
				}
			}

			lock(this.log){
				this.log.stringbuffer.Append(string.Format("mode = {0} : time = {1}\n",this.mode,System.DateTime.UtcNow.Ticks - t_ticks));
			}
		}
	}
}

