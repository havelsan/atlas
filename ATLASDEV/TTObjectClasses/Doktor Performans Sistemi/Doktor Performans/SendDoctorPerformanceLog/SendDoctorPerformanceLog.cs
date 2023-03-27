
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
    /// Doktor Performans Log
    /// </summary>
    public partial class SendDoctorPerformanceLog : TTObject
    {
        public void CreateNewSendDoctorPerformanceLog(TTObjectContext objectContext, SendToDoctorPerformance sendToDoctorPerformance, DPDetailedErrorTypes logType, string Log, string methodName = null)
        {
            SendDoctorPerformanceLog performanceLog = new SendDoctorPerformanceLog(objectContext);
            performanceLog.LogDate = DateTime.Now;
            performanceLog.SendToDoctorPerformance = sendToDoctorPerformance;
            performanceLog.Log = Log;
            performanceLog.MethodName = methodName;
            performanceLog.LogType = logType;
        }
    }
}