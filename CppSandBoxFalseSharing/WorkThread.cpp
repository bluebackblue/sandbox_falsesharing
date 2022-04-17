


/** include
*/
#include "WorkThread.h"
#if(1)


/** Simple
*/
namespace Simple
{
	/** constructor
	*/
	WorkThread::WorkThread(const std::shared_ptr<WorkThread_Execute_Base>& a_execute)
	{
		//execute
		this->execute = a_execute;

		//raw
		this->raw.reset(new std::thread(Inner_ThreadMain,this));
	}

	/** destructor
	*/
	WorkThread::~WorkThread()
	{
		this->raw->join();
		this->raw.reset();
	}

	/** Inner_ThreadMain
	*/
	void WorkThread::Inner_ThreadMain(void* a_param)
	{
		WorkThread* t_this = (WorkThread*)a_param;
		t_this->execute->ThreadMain();
	}
}


#endif

