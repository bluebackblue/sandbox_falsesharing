

/** Simple
*/
namespace Simple
{
	/** Main_MonoBehaviour
	*/
	public class Main_MonoBehaviour : UnityEngine.MonoBehaviour
	{
		/** Padding0
		*/
		public struct Padding0
		{
		}

		/** Padding28

			size : 4 * 7

		*/
		public struct Padding28
		{
			public int p1;
			public int p2;
			public int p3;
			public int p4;
			public int p5;
			public int p6;
			public int p7;
		}

		/** Padding60

			size : 4 * 15

		*/
		public struct Padding60
		{
			public int p1;
			public int p2;
			public int p3;
			public int p4;
			public int p5;
			public int p6;
			public int p7;
			public int p8;
			public int p9;
			public int p10;
			public int p11;
			public int p12;
			public int p13;
			public int p14;
			public int p15;
		}

		/** Padding124

			size : 4 * 31

		*/
		public struct Padding124
		{
			public int p1;
			public int p2;
			public int p3;
			public int p4;
			public int p5;
			public int p6;
			public int p7;
			public int p8;
			public int p9;
			public int p10;
			public int p11;
			public int p12;
			public int p13;
			public int p14;
			public int p15;
			public int p16;
			public int p17;
			public int p18;
			public int p19;
			public int p20;
			public int p21;
			public int p22;
			public int p23;
			public int p24;
			public int p25;
			public int p26;
			public int p27;
			public int p28;
			public int p29;
			public int p30;
			public int p31;
		}

		/** Start
		*/
		private void Start()
		{
			Log t_log = new Log();

			t_log.stringbuffer.Append("----- padding 0 ----- \n");

			WorkThread[] t_workthread_list = new WorkThread[Execute<int>.THREAD_MAX];

			//パディング０バイト。
			{
				Execute<Padding0>.ShareDataType t_sharedata = new Execute<Padding0>.ShareDataType();

				for(int ii=0;ii<t_workthread_list.Length;ii++){
					t_workthread_list[ii] = new WorkThread(new Execute<Padding0>(ii,t_sharedata,t_log));
				}

				for(int ii=0;ii<t_workthread_list.Length;ii++){
					t_workthread_list[ii].Dispose();
				}
			}

			t_log.stringbuffer.Append("----- padding 28 ----- \n");

			//パディング２８バイト。
			{
				Execute<Padding28>.ShareDataType t_sharedata = new Execute<Padding28>.ShareDataType();

				for(int ii=0;ii<t_workthread_list.Length;ii++){
					t_workthread_list[ii] = new WorkThread(new Execute<Padding28>(ii,t_sharedata,t_log));
				}

				for(int ii=0;ii<t_workthread_list.Length;ii++){
					t_workthread_list[ii].Dispose();
				}
			}

			t_log.stringbuffer.Append("----- padding 60 ----- \n");

			//パディング６０バイト。
			{
				Execute<Padding60>.ShareDataType t_sharedata = new Execute<Padding60>.ShareDataType();

				for(int ii=0;ii<t_workthread_list.Length;ii++){
					t_workthread_list[ii] = new WorkThread(new Execute<Padding60>(ii,t_sharedata,t_log));
				}

				for(int ii=0;ii<t_workthread_list.Length;ii++){
					t_workthread_list[ii].Dispose();
				}
			}

			t_log.stringbuffer.Append("----- padding 124 ----- \n");

			//パディング１２４バイト。
			{
				Execute<Padding124>.ShareDataType t_sharedata = new Execute<Padding124>.ShareDataType();

				for(int ii=0;ii<t_workthread_list.Length;ii++){
					t_workthread_list[ii] = new WorkThread(new Execute<Padding124>(ii,t_sharedata,t_log));
				}

				for(int ii=0;ii<t_workthread_list.Length;ii++){
					t_workthread_list[ii].Dispose();
				}
			}

			{
				UnityEngine.UI.Text t_text = UnityEngine.GameObject.Find("Text").GetComponent<UnityEngine.UI.Text>();
				t_text.text = t_log.stringbuffer.ToString();
			}
		}
	}
}

