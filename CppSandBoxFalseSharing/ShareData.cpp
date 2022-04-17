

/** include
*/
#include "ShareData.h"
#if(1)


/** Simple
*/
namespace Simple
{
	/** LOOP_MAX
	*/
	#if(defined(_DEBUG))
	const int ShareData::LOOP_MAX = 100000;
	#else
	const int ShareData::LOOP_MAX = 300000;
	#endif
}

#endif

