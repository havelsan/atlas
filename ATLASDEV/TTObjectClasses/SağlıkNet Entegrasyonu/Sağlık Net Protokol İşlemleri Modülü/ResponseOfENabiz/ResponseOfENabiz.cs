
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
    public  partial class ResponseOfENabiz : TTObject
    {
        public partial class GetListOfError_Class : TTReportNqlObject 
        {
        }

        public partial class GetCountOfResponseData_Class : TTReportNqlObject 
        {
        }

#region Methods
        public ResponseOfENabiz(TTObjectContext objectContext, SendToENabiz sendToENabiz,string responseCode,string responseMessage):this(objectContext)
        {
            SendToENabiz = sendToENabiz;
            SendDate = DateTime.Now ;
            ResponseCode = responseCode;
            ResponseMessage = responseMessage;
 
        }
        
#endregion Methods

    }
}