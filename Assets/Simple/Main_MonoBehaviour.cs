



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
			WorkThread[] t_workthead = new WorkThread[Execute<int>.THREAD_MAX];
			for(int ii=0;ii<t_workthead.Length;ii++){
				t_workthead[ii] = new WorkThread();
			}

			//パディング０バイト。
			{
				Execute<Padding0>.ShareDataType t_sharedata = new Execute<Padding0>.ShareDataType();
				
				for(int ii=0;ii<t_workthead.Length;ii++){
					t_workthead[ii].Initialize(new Execute<Padding0>(ii,t_sharedata));
				}
			
				for(int ii=0;ii<t_workthead.Length;ii++){
					t_workthead[ii].Start();
				}

				for(int ii=0;ii<t_workthead.Length;ii++){
					t_workthead[ii].End();
				}

				for(int ii=0;ii<t_workthead.Length;ii++){
					UnityEngine.Debug.Log(string.Format("padding = 0 : index = {0} : ticks = {1}",ii,t_workthead[ii].stopwatch.ElapsedTicks));
				}
			}

			UnityEngine.Debug.Log("-----------");

			//パディング２８バイト。
			{
				Execute<Padding28>.ShareDataType t_sharedata = new Execute<Padding28>.ShareDataType();

				for(int ii=0;ii<t_workthead.Length;ii++){
					t_workthead[ii].Initialize(new Execute<Padding28>(ii,t_sharedata));
				}
			
				for(int ii=0;ii<t_workthead.Length;ii++){
					t_workthead[ii].Start();
				}

				for(int ii=0;ii<t_workthead.Length;ii++){
					t_workthead[ii].End();
				}

				for(int ii=0;ii<t_workthead.Length;ii++){
					UnityEngine.Debug.Log(string.Format("padding = 28 : index = {0} : ticks = {1}",ii,t_workthead[ii].stopwatch.ElapsedTicks));
				}
			}

			UnityEngine.Debug.Log("-----------");

			//パディング６０バイト。
			{
				Execute<Padding60>.ShareDataType t_sharedata = new Execute<Padding60>.ShareDataType();

				for(int ii=0;ii<t_workthead.Length;ii++){
					t_workthead[ii].Initialize(new Execute<Padding60>(ii,t_sharedata));
				}
			
				for(int ii=0;ii<t_workthead.Length;ii++){
					t_workthead[ii].Start();
				}

				for(int ii=0;ii<t_workthead.Length;ii++){
					t_workthead[ii].End();
				}

				for(int ii=0;ii<t_workthead.Length;ii++){
					UnityEngine.Debug.Log(string.Format("padding = 60 : index = {0} : ticks = {1}",ii,t_workthead[ii].stopwatch.ElapsedTicks));
				}
			}

			UnityEngine.Debug.Log("-----------");

			//パディング１２４バイト。
			{
				Execute<Padding124>.ShareDataType t_sharedata = new Execute<Padding124>.ShareDataType();

				for(int ii=0;ii<t_workthead.Length;ii++){
					t_workthead[ii].Initialize(new Execute<Padding124>(ii,t_sharedata));
				}
			
				for(int ii=0;ii<t_workthead.Length;ii++){
					t_workthead[ii].Start();
				}

				for(int ii=0;ii<t_workthead.Length;ii++){
					t_workthead[ii].End();
				}

				for(int ii=0;ii<t_workthead.Length;ii++){
					UnityEngine.Debug.Log(string.Format("padding = 124 : index = {0} : ticks = {1}",ii,t_workthead[ii].stopwatch.ElapsedTicks));
				}
			}
		}
	}
}

