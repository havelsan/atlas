
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
    /// NABIZ - Yo�un Bak�m �zlem Veri Seti
    /// </summary>
    public  partial class ENABIZSend502 : BaseScheduledTask
    {
        public override void TaskScript()
        {
            string logTxt = "ENABIZSend502 Has Started : " + Common.RecTime();
            try
            {

        
                SendToENabiz s = new SendToENabiz();
                s.ENABIZSend502(null);
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