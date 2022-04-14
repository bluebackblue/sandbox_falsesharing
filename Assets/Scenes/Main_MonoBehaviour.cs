

/** Main_MonoBehaviour
*/
public class Main_MonoBehaviour : UnityEngine.MonoBehaviour
{
	/** count
	*/
	public static long s_count = 0;

	/** Pad
	*/
	public struct Pad
	{
		public long l1;
		public long l2;
		public long l3;
		public long l4;
		public long l5;
		public long l6;
		public long l7;
		public long l8;
		public long l9;
		public long l10;
		public long l11;
		public long l12;
		public long l13;
		public long l14;
		public long l15;
		public long l16;
	}

	/** キャッシュにやさしい。
	*/
	public class Data_True
	{
		public volatile int a;

		public Pad pad11;
		public Pad pad12;

		public volatile int b;

		public Pad pad21;
		public Pad pad22;

		public volatile int c;
		
		public Pad pad31;
		public Pad pad32;

		public volatile int d;

		public Pad pad41;
		public Pad pad42;
	}

	/** キャッシュにやさしくない。
	*/
	public class Data_False
	{
		public volatile int a;
		public volatile int b;
		public volatile int c;
		public volatile int d;
	}

	/** キャッシュにやさしい。
	*/
	public static Data_True s_data_true = null;

	/** キャッシュにやさしくない。
	*/
	public static Data_False s_data_false = null;

	/** Slot
	*/
	private sealed class Slot
	{
		/** raw
		*/
		public System.Threading.Thread raw;

		/** constructor
		*/
		public Slot()
		{
			this.raw = null;
		}

		/** キャッシュにやさしい。
		*/
		public void Start_True(int a_index)
		{
			//Increment
			System.Threading.Interlocked.Increment(ref s_count);

			//raw
			this.raw = new System.Threading.Thread(ThreadMain_True);
			this.raw.Start(a_index);
		}

		/** キャッシュにやさしくない。
		*/
		public void Start_False(int a_index)
		{
			//Increment
			System.Threading.Interlocked.Increment(ref s_count);

			//raw
			this.raw = new System.Threading.Thread(ThreadMain_False);
			this.raw.Start(a_index);
		}

		/** End
		*/
		public void End()
		{
			this.raw.Join();
			this.raw = null;
		}

		/** ThreadMain_True
		*/
		public static void ThreadMain_True(object a_index)
		{
			int t_index = (int)a_index;

			for(int ii=0;ii<1000000;ii++){
				switch(t_index){
				case 0:
					{
						System.Threading.Interlocked.Increment(ref s_data_true.a);
					}break;
				case 1:
					{
						System.Threading.Interlocked.Increment(ref s_data_true.b);
					}break;
				case 2:
					{
						System.Threading.Interlocked.Increment(ref s_data_true.c);
					}break;
				case 3:
					{
						System.Threading.Interlocked.Increment(ref s_data_true.d);
					}break;
				default:
					{
					}break;
				}
			}

			System.Threading.Interlocked.Decrement(ref s_count);
		}

		/** ThreadMain_False
		*/
		public static void ThreadMain_False(object a_index)
		{
			int t_index = (int)a_index;

			for(int ii=0;ii<1000000;ii++){
				switch(t_index){
				case 0:
					{
						System.Threading.Interlocked.Increment(ref s_data_false.a);
					}break;
				case 1:
					{
						System.Threading.Interlocked.Increment(ref s_data_false.b);
					}break;
				case 2:
					{
						System.Threading.Interlocked.Increment(ref s_data_false.c);
					}break;
				case 3:
					{
						System.Threading.Interlocked.Increment(ref s_data_false.d);
					}break;
				default:
					{
					}break;
				}
			}

			System.Threading.Interlocked.Decrement(ref s_count);
		}

	}

	/** list
	*/
	private Slot[] list;

	/** Start
	*/
    private void Start()
    {
		s_count = 0;

		s_data_true = new Data_True()
		{
			a = 0,
			b = 0,
			c = 0,
			d = 0,
		};

		s_data_false = new Data_False()
		{
			a = 0,
			b = 0,
			c = 0,
			d = 0,
		};

		System.Diagnostics.Stopwatch t_stopwatch = new System.Diagnostics.Stopwatch();

		this.list = new Slot[4];
		for(int ii=0;ii<this.list.Length;ii++){
			this.list[ii] = new Slot();
		}
		
		for(int xx=0;xx<10;xx++){
			t_stopwatch.Start();
			{
				for(int ii=0;ii<this.list.Length;ii++){
					this.list[ii].Start_True(ii);
				}

				while(true){
					if(System.Threading.Interlocked.Read(ref s_count) == 0){
						break;
					}
				}
			}
			t_stopwatch.Stop();
			UnityEngine.Debug.Log(string.Format("true : tick = {0}",t_stopwatch.ElapsedTicks));
			t_stopwatch.Reset();
		}

		for(int xx=0;xx<10;xx++){
			t_stopwatch.Start();
			{
				for(int ii=0;ii<this.list.Length;ii++){
					this.list[ii].Start_False(ii);
				}

				while(true){
					if(System.Threading.Interlocked.Read(ref s_count) == 0){
						break;
					}
				}
			}
			t_stopwatch.Stop();
			UnityEngine.Debug.Log(string.Format("false : tick = {0}",t_stopwatch.ElapsedTicks));
			t_stopwatch.Reset();
		}

	}
}

