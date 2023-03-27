
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
    public  partial class SendAllUpdatedTerMans : BaseScheduledTask
    {
#region Methods
        public override void TaskScript()
        {
            try
            {
                TaskScriptWithManuelDate(null);
            }
            catch (Exception ex)
            {
                AddLog(ex.Message);
            }
        }
       
        public void TaskScriptWithManuelDate(DateTime? startDate)
        {
            TaskScriptWithManuelDate(startDate, null);
        }
        
        public void TaskScriptWithManuelDate(DateTime? startDate, List<Sites> targetSites)
        {
            try
            {
                if(startDate == null)
                {
                    TTObjectContext context = new TTObjectContext(true);
                    IBindingList lastExecutions = SendAllUpdatedTerMans.GetExecutions(context);
                    if(lastExecutions.Count > 0)
                    {
                        SendAllUpdatedTerMans lastSend = (SendAllUpdatedTerMans)lastExecutions[0];
                        if(targetSites == null)
                            TerminologyManagerDef.RunSendTerminologyManagerDef(Convert.ToDateTime(lastSend.LastExecutionDate));
                        else
                            TerminologyManagerDef.RunSendTerminologyManagerDefV2(Convert.ToDateTime(lastSend.LastExecutionDate), targetSites);
                    }
                    else
                    {
                        if(targetSites == null)
                            TerminologyManagerDef.RunSendTerminologyManagerDef(Common.RecTime());
                        else
                            TerminologyManagerDef.RunSendTerminologyManagerDefV2(Common.RecTime(), targetSites);
                    }
                }
                else
                {
                    if(targetSites == null)
                        TerminologyManagerDef.RunSendTerminologyManagerDef(Convert.ToDateTime(startDate));
                    else
                        TerminologyManagerDef.RunSendTerminologyManagerDefV2(Convert.ToDateTime(startDate), targetSites);
                }
            }
            catch (Exception ex)
            {
                AddLog(ex.Message);
            }
        }
        
#endregion Methods

    }
}