

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
		public const int THREAD_MAX = 4;

		/** ループ数。
		*/
		public const int LOOP_MAX = 10000000;

		/** ShareDataType
		*/
		public class ShareDataType
		{
			public int a;

			public PADDING pad1;

			public int b;
			
			public PADDING pad2;

			public int c;
			
			public PADDING pad3;
			
			public int d;
		}

		/** index
		*/
		public int index;

		/** sharedata
		*/
		public ShareDataType sharedata;

		/** constructor
		*/
		public Execute(int a_index,ShareDataType a_sharedata)
		{
			//index
			this.index = a_index;

			//sharedata
			this.sharedata = a_sharedata;
		}

		/** [Simple.WorkThread_Execute_Base]スレッドから呼び出される。
		*/
		public void ThreadMain()
		{
			int t_index = this.index;

			for(int ii=0;ii<LOOP_MAX;ii++){
				switch(t_index){
				case 0:
					{
						this.sharedata.a = t_index;
					}break;
				case 1:
					{
						this.sharedata.b = t_index;
					}break;
				case 2:
					{
						this.sharedata.c = t_index;
					}break;
				case 3:
					{
						this.sharedata.d = t_index;
					}break;
				default:
					{
					}break;
				}

				System.Threading.Thread.MemoryBarrier();
			}
		}
	}
}

