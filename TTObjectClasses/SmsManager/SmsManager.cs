using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtlasSmsManager
{
    public class SmsManager
    {
        public static ISmsApi _smsApi;
        public static ISmsApi Instance
        {
            get
            {
                if(_smsApi == null)
                {
                    var smsApi = TTObjectClasses.SystemParameter.GetParameterValue("SMSAPI", "");
                    if (smsApi == "TTMesajApi")
                    {
                        _smsApi = new TTMesajApi();
                    }
                    else if(smsApi == "IletiMerkeziApi")
                    {
                        _smsApi = new IletiMerkeziApi();
                    }
                    else if (smsApi == "EkoMesajApi")
                    {
                        _smsApi = new EkoMesajApi();
                    }
                    else if (smsApi == "AsistApi")
                    {
                        _smsApi = new AsistApi();
                    }
                }
                return _smsApi;
            }
        }
    }
}
