
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
    /// PTS Giriş İşlemi Tamamlama
    /// </summary>
    public  partial class PTSActionCompletedTask : BaseScheduledTask
    {
#region Methods
        public override void TaskScript()
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            string message = string.Empty;

            int exp = (int)ExpirationDay * -1 ;
            DateTime date = Common.RecTime().AddDays(exp);
            IList ptsActions = PTSAction.GetInputDocumentStateAction(objectContext,date, PTSAction.States.CreateInputDocument);
            foreach (PTSAction pts in ptsActions)
            {
                pts.CurrentStateDefID = PTSAction.States.Completed;
                if (message == string.Empty)
                    message = pts.StockActionID.ToString();
                else
                    message = message + "," + pts.StockActionID.ToString();
            }
            
            if(message != string.Empty)
            {
                message = message + " işlem numaralı PTS Giriş işlemi(leri) tamamlanmıştır.";
                AddLog(message);
                objectContext.Save();
            }
            objectContext.Dispose();
        }
        
        public override void AddLog(string log)
        {
            base.AddLog(log);
        }
        
#endregion Methods

    }
}