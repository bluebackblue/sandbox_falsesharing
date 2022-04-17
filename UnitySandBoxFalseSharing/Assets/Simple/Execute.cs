

/** Simple
*/
namespace Simple
{
	/** Execute
	*/
	public sealed class Execute<PADDING> : WorkThread_Execute_Base
		where PADDING : struct
	{
		/** スレッド数。
		*/
		public const int THREAD_MAX = 8;

		/** ループ数。
		*/
		public const int LOOP_MAX = 100000000;

		/** ShareDataType
		*/
		public class ShareDataType
		{
			public int data1;

			public PADDING pad1;

			public int data2;
			
			public PADDING pad2;

			public int data3;
			
			public PADDING pad3;
			
			public int data4;

			public PADDING pad4;
			
			public int data5;

			public PADDING pad5;
			
			public int data6;

			public PADDING pad6;
			
			public int data7;

			public PADDING pad7;
			
			public int data8;
		}

		/** index
		*/
		public int index;

		/** sharedata
		*/
		public ShareDataType sharedata;

		/** log
		*/
		public Log log;

		/** constructor
		*/
		public Execute(int a_index,ShareDataType a_sharedata,Log a_log)
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
			int t_index = this.index;
			
			long t_ticks = System.DateTime.UtcNow.Ticks;

			switch(t_index){
			case 0:
				{
					for(int ii=0;ii<LOOP_MAX;ii++){
						this.sharedata.data1 = t_index;
						System.Threading.Thread.MemoryBarrier();
					}
				}break;
			case 1:
				{
					for(int ii=0;ii<LOOP_MAX;ii++){
						this.sharedata.data2 = t_index;
						System.Threading.Thread.MemoryBarrier();
					}
				}break;
			case 2:
				{
					for(int ii=0;ii<LOOP_MAX;ii++){
						this.sharedata.data3 = t_index;
						System.Threading.Thread.MemoryBarrier();
					}
				}break;
			case 3:
				{
					for(int ii=0;ii<LOOP_MAX;ii++){
						this.sharedata.data4 = t_index;
						System.Threading.Thread.MemoryBarrier();
					}
				}break;
			case 4:
				{
					for(int ii=0;ii<LOOP_MAX;ii++){
						this.sharedata.data5 = t_index;
						System.Threading.Thread.MemoryBarrier();
					}
				}break;
			case 5:
				{
					for(int ii=0;ii<LOOP_MAX;ii++){
						this.sharedata.data6 = t_index;
						System.Threading.Thread.MemoryBarrier();
					}
				}break;
			case 6:
				{
					for(int ii=0;ii<LOOP_MAX;ii++){
						this.sharedata.data7 = t_index;
						System.Threading.Thread.MemoryBarrier();
					}
				}break;
			case 7:
				{
					for(int ii=0;ii<LOOP_MAX;ii++){
						this.sharedata.data8 = t_index;
						System.Threading.Thread.MemoryBarrier();
					}
				}break;
			default:
				{
				}break;
			}

			lock(this.log){
				if((this.index == 0)||(this.index == 7)){
					this.log.stringbuffer.Append(string.Format("index = {0} : time = {1}\n",this.index,System.DateTime.UtcNow.Ticks - t_ticks));
				}
			}
		}
	}
}

