
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
    /// Hata Almýþ Nabýz Satýrlarýný Tekrar Kuyruða Ekler
    /// </summary>
    public  partial class SendNabizWithResponceCode : BaseScheduledTask
    {
        public override void TaskScript()
        {
            string logTxt = "SendNabizWithResponceCode Has Started : " + Common.RecTime();
            try
            {
                SendToENabiz s = new SendToENabiz();
                s.SendENabizPackagesWithResponseCode();
                logTxt += " - Has Finished Succesfully : " + Common.RecTime();
            }
            catch (Exception ex)
            {
                logTxt += " - ERROR: " + ex.ToString() + ": " + Common.RecTime();
                AddLog(logTxt);
            }
        }
    }
}