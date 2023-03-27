
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
    public  partial class ENABIZ_GunlukIslemler : BaseScheduledTask
    {
        public override void TaskScript()
        {
            try
            {
                AddLog("ENABIZ_GunlukIslemler has started");
                SendToENabiz s = new SendToENabiz();
                DateTime startDate = Common.RecTime().AddDays(-1);
                startDate.AddHours(-startDate.Hour);
                startDate.AddMinutes(-startDate.Minute);
                DateTime endDate = startDate.AddDays(1);
                s.ENabizSend_GunlukIslemler(startDate,endDate);
                AddLog("ENABIZ_GunlukIslemler has finished succesfully");
            }
            catch (Exception ex)
            {
                AddLog("ERROR: " + ex.ToString());
            }
        }
    }
}