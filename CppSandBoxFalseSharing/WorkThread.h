

/** pragma once
*/
#pragma once
#if(1)


/** include
*/
#include <iostream>
#include <thread>
#include <time.h>


/** include
*/
#include "WorkThread_Execute_Base.h"


/** Simple
*/
namespace Simple
{
	/** WorkThread
	*/
	class WorkThread final
	{
	private:

		/** execute
		*/
		std::shared_ptr<WorkThread_Execute_Base> execute;

		/** raw
		*/
		std::shared_ptr<std::thread> raw;

	public:

		/** constructor
		*/
		WorkThread(const std::shared_ptr<WorkThread_Execute_Base>& a_execute);

		/** destructor
		*/
		virtual ~WorkThread();

	private:

		/** Inner_ThreadMain
		*/
		static void Inner_ThreadMain(void* a_param);

	};
}


#endif

