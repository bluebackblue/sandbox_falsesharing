

/** pragma once
*/
#pragma once
#if(1)


/** include
*/
#include <iostream>
#include <thread>
#include <time.h>
#include <memory>
#include <atomic>


/** include
*/
#include "ShareData.h"


/** Simple
*/
namespace Simple
{
	/** ViewThread
	*/
	class ViewThread final
	{
	private:

		/** VIEWTIMING
		*/
		static const int VIEWTIMING;

		/** sharedata
		*/
		std::shared_ptr<ShareData> sharedata;

		/** cancel
		*/
		bool cancel;

		/** raw
		*/
		std::shared_ptr<std::thread> raw;

	public:

		/** viewvalue
		*/
		int64_t viewvalue;

		/** constructor
		*/
		ViewThread(const std::shared_ptr<ShareData>& a_sharedata);

		/** destructor
		*/
		virtual ~ViewThread();

	private:

		/** Inner_ThreadMain
		*/
		static void Inner_ThreadMain(void* a_param);

	};
}


#endif

