
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
    public  partial class CancelOldUnCompletedEAs : BaseScheduledTask
    {
#region Methods
        public override void TaskScript()
        {
           TTObjectContext context = new TTObjectContext(false);
            try
            {
                IList resSectionList=ResSection.GetIfHasActionCancelledTime(context);
                foreach (ResSection r in resSectionList)
                {
                    double limit = (-1 * Convert.ToDouble(r.ActionCancelledTime == null ? 0 : r.ActionCancelledTime));
                    if (limit != 0)
                    {
                        DateTime LimitDay = Convert.ToDateTime(Common.RecTime()).AddDays(limit);
                        IList list = EpisodeAction.GetUnCompletedEAByActiondate(context, LimitDay, r.ObjectDef.ID.ToString());
                        foreach (EpisodeAction ea in list)
                        {

                            ((ITTObject)ea).Cancel();
                            
                        }
                    }
                }
                context.Save();
            }
            catch (Exception ex)
            {
                AddLog(ex.Message);
                context.Dispose();
            }
        }
        
#endregion Methods

    }
}