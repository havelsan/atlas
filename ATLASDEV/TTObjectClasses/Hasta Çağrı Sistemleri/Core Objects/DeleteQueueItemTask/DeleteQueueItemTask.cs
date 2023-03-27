
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
    public  partial class DeleteQueueItemTask : BaseScheduledTask
    {
#region Methods
        public override void TaskScript()
        {
            BindingList<ExaminationQueueItem> oldItems = ExaminationQueueItem.GetDeletableItems(ObjectContext, Common.RecTime().AddDays(-2));
            List<ExaminationQueueItem> deleteList = new List<ExaminationQueueItem>();
            foreach (ExaminationQueueItem item in oldItems)
                ((ITTObject)item).Delete();
            
//            foreach (ExaminationQueueItem item in deleteList)
//                ((ITTObject)item).Delete();
        }
        
#endregion Methods

    }
}