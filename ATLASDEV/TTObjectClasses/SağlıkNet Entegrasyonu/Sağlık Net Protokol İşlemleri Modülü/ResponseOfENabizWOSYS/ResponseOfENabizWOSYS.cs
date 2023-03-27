
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    /// <summary>
    /// Günde yada ayda bir kere çalışan systakip numarasından bağımsız paketlerin loglarının tutulduğu tablo
    /// </summary>
    public  partial class ResponseOfENabizWOSYS : TTObject
    {
        public ResponseOfENabizWOSYS(TTObjectContext objectContext, string packageCode, SendToENabizEnum status,string responseCode, string responseMessage):this(objectContext)
        {
            PackageCode = packageCode;
            Status = status;
            SendDate = DateTime.Now;
            ResponseCode = responseCode;
            ResponseMessage = responseMessage;

        }
    }
}