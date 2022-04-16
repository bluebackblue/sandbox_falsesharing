

/** ReadFromOtherThread
*/
namespace ReadFromOtherThread
{
	/** Execute_1
	*/
	public sealed class Execute_1 : WorkThread_Execute_Base
	{
		/** index
		*/
		public int index;

		/** sharedata
		*/
		public ShareData sharedata;

		/** log
		*/
		public Log log;

		/** constructor
		*/
		public Execute_1(int a_index,ShareData a_sharedata,Log a_log)
		{
			//index
			this.index = a_index;

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
				System.UInt64 t_value = this.sharedata.value;

				for(int xx=0;xx<ShareData.LOOP_MAX;xx++){
					for(int yy=0;yy<ShareData.LOOP_MAX;yy++){
						t_value += (System.UInt64)(xx + yy);
					}
				}

				this.sharedata.value = t_value;
			}

			lock(this.log){
				this.log.stringbuffer.Append(string.Format("mode = {0} : time = {1}\n",this.index,System.DateTime.UtcNow.Ticks - t_ticks));
			}
		}
	}
}

