

/** include
*/
#include "Execute_1.h"
#include "Execute_2.h"
#include "ShareData.h"
#include "WorkThread.h"
#include "ViewThread.h"


/** main
*/
namespace Simple{void Main();}
int main()
{
	Simple::Main();
}


/** Simple
*/
namespace Simple
{
	/** Main
	*/
	void Main()
	{
		std::shared_ptr<ShareData> t_sharedata(new ShareData());

		for(int ii=0;ii<4;ii++){
			t_sharedata->value = 0LL;
			std::atomic_thread_fence(std::memory_order_release);

			std::shared_ptr<WorkThread> t_workthread(new WorkThread(std::shared_ptr<Execute_1>(new Execute_1(t_sharedata,1))));
			t_workthread.reset();
		}

		for(int ii=0;ii<4;ii++){
			t_sharedata->value = 0LL;
			std::atomic_thread_fence(std::memory_order_release);

			std::shared_ptr<WorkThread> t_workthread(new WorkThread(std::shared_ptr<Execute_2>(new Execute_2(t_sharedata,2))));
			t_workthread.reset();
		}
		
		{
			std::shared_ptr<ViewThread> t_viewthread(new ViewThread(t_sharedata));

			for(int ii=0;ii<4;ii++){
				t_sharedata->value = 0LL;
				std::atomic_thread_fence(std::memory_order_release);

				std::shared_ptr<WorkThread> t_workthread(new WorkThread(std::shared_ptr<Execute_2>(new Execute_2(t_sharedata,3))));
				t_workthread.reset();
			}

			std::printf("%lld\n",t_viewthread->viewvalue);

			t_viewthread.reset();
		}

		{
			char t_char[128] = {0};
			std::cout << "input" << t_char;
			std::cin >> t_char;
			std::cout << "end" << t_char;
		}
	}
}

