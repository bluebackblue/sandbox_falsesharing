

/** include
*/
#include "Execute_2.h"
#if(1)


/** Simple
*/
namespace Simple
{
	/** constructor
	*/
	Execute_2::Execute_2(const std::shared_ptr<ShareData>& a_sharedata,int a_index)
	{
		//sharedata
		this->sharedata = a_sharedata;

		//index
		this->index = a_index;
	}

	/** [Simple.WorkThread_Execute_Base]スレッドから呼び出される。
	*/
	void Execute_2::ThreadMain()
	{
		clock_t t_clock = clock();
		{
			int64_t* t_value = &(this->sharedata->value);

			for(int xx=0;xx<ShareData::LOOP_MAX;xx++){
				for(int yy=0;yy<ShareData::LOOP_MAX;yy++){
					*t_value += xx + yy;
				}
				std::atomic_thread_fence(std::memory_order_release);
			}
		}
		std::printf("%d : time = %d\n",this->index,clock() - t_clock);
	}
}


#endif

