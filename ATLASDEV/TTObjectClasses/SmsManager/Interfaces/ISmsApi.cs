using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtlasSmsManager
{
    public interface ISmsApi
    {
        bool SendSms(AtlasSMS sms);

        
    }
}
