

/** include
*/
#include "ViewThread.h"
#if(1)


/** Simple
*/
namespace Simple
{
	/** VIEWTIMING
	*/
	const int ViewThread::VIEWTIMING = 1000;

	/** constructor
	*/
	ViewThread::ViewThread(const std::shared_ptr<ShareData>& a_sharedata)
	{
        //sharedata
		this->sharedata = a_sharedata;

		//cancel
		this->cancel = false;

		//viewvalue
		this->viewvalue = 0LL;

		//raw
		this->raw.reset(new std::thread(Inner_ThreadMain,this));
	}

	/** destructor
	*/
	ViewThread::~ViewThread()
	{
		this->cancel = true;
		std::atomic_thread_fence(std::memory_order_release);
		this->raw->join();
		this->raw.reset();
	}

	/** Inner_ThreadMain
	*/
	void ViewThread::Inner_ThreadMain(void* a_param)
	{
		ViewThread* t_this = (ViewThread*)a_param;

		int64_t* t_value = &(t_this->sharedata->value);

		clock_t t_clock = clock();

		while(true){
			std::this_thread::sleep_for(std::chrono::nanoseconds(0));

			t_this->viewvalue = *t_value;

			long t_ticks_new = clock();
			if(t_ticks_new - t_clock > VIEWTIMING){
				t_clock = t_ticks_new;

				std::printf("view = %lld\n",t_this->viewvalue);
			}

			//cancel
			bool t_cancel = t_this->cancel;
			std::atomic_thread_fence(std::memory_order_acquire);
			if(t_cancel == true){
				break;
			}
		}
	}
}


#endif

