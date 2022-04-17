

/** ReadFromOtherThread
*/
namespace ReadFromOtherThread
{
	/** Main_MonoBehaviour
	*/
	public class Main_MonoBehaviour : UnityEngine.MonoBehaviour
	{
		/** Start
		*/
		private void Start()
		{
			//log
			Log t_log = new Log();

			//sharedata
			ShareData t_sharedata = new ShareData(){
				value = 0,
			};

			//mode 1
			for(int ii=0;ii<4;ii++){
				t_sharedata.value = 0;
				System.Threading.Thread.MemoryBarrier();

				WorkThread t_workthread = new WorkThread(new Execute_1(1,t_sharedata,t_log),0x0C);
				t_workthread.Dispose();
			}

			//mode2
			for(int ii=0;ii<4;ii++){
				t_sharedata.value = 0;
				System.Threading.Thread.MemoryBarrier();

				WorkThread t_workthread = new WorkThread(new Execute_2(2,t_sharedata,t_log),0x0C);
				t_workthread.Dispose();
			}
		
			//mode3
			{
				ViewThread t_viewthread = new ViewThread(t_sharedata,t_log,0x03);

				for(int ii=0;ii<4;ii++){
					t_sharedata.value = 0;
					System.Threading.Thread.MemoryBarrier();

					WorkThread t_workthread = new WorkThread(new Execute_2(3,t_sharedata,t_log),0x0C);
					t_workthread.Dispose();
				}

				lock(t_log){
					t_log.stringbuffer.Append(string.Format("{0}",t_viewthread.viewvalue));
				}

				t_viewthread.Dispose();
			}

			{
				UnityEngine.UI.Text t_text = UnityEngine.GameObject.Find("Text").GetComponent<UnityEngine.UI.Text>();
				t_text.text = t_log.stringbuffer.ToString();
			}
		}
	}
}

