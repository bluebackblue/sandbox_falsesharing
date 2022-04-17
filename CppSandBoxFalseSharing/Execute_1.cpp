

/** include
*/
#include "Execute_1.h"
#if(1)


/** Simple
*/
namespace Simple
{
	/** constructor
	*/
	Execute_1::Execute_1(const std::shared_ptr<ShareData>& a_sharedata,int a_index)
	{
		//sharedata
		this->sharedata = a_sharedata;

		//index
		this->index = a_index;
	}

	/** [Simple.WorkThread_Execute_Base]スレッドから呼び出される。
	*/
	void Execute_1::ThreadMain()
	{
		clock_t t_clock = clock();
		{
			int64_t t_value = this->sharedata->value;

			for(int xx=0;xx<ShareData::LOOP_MAX;xx++){
				for(int yy=0;yy<ShareData::LOOP_MAX;yy++){
					t_value += xx + yy;
				}
			}

			this->sharedata->value = t_value;
		}
		std::printf("%d : time = %d\n",this->index,clock() - t_clock);
	}
}


#endif

