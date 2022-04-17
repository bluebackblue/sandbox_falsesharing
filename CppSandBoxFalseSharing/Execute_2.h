

/** pragma once
*/
#pragma once
#if(1)


/** include
*/
#include <iostream>
#include <time.h>
#include <atomic>


/** include
*/
#include "ShareData.h"
#include "WorkThread_Execute_Base.h"


/** Simple
*/
namespace Simple
{
	/** Execute_2
	*/
	class Execute_2 final
		:
		public WorkThread_Execute_Base
	{
	private:

		/** sharedata
		*/
		std::shared_ptr<ShareData> sharedata;

		/** index
		*/
		int index;

		/** [Simple.WorkThread_Execute_Base]スレッドから呼び出される。
		*/
		virtual void ThreadMain();

	public:

		/** constructor
		*/
		Execute_2(const std::shared_ptr<ShareData>& a_sharedata,int a_index);

	};
}


#endif

