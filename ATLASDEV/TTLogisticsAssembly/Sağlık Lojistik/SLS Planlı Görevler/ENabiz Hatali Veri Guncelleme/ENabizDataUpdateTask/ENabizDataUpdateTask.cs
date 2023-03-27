
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
    public  partial class ENabizDataUpdateTask : BaseScheduledTask
    {
        #region Methods
        public override void TaskScript()
        {
            string msg = string.Empty;
            int expirationDay = 2;

            if (StartedDay.HasValue)
                expirationDay = StartedDay.Value;

            expirationDay = expirationDay * -1;

            DateTime now = new DateTime(Common.RecTime().Year, Common.RecTime().Month, Common.RecTime().Day, 0, 0, 0);
            DateTime endDate = now;
            DateTime startDate = now.AddDays(expirationDay);


            TTObjectContext context = new TTObjectContext(false);
            BindingList<SendToENabiz.GetSentToENabizMaterial_Class> sendToEnabizs = SendToENabiz.GetSentToENabizMaterial(endDate, startDate);
            foreach (SendToENabiz.GetSentToENabizMaterial_Class sendToENabiz in sendToEnabizs)
            {
                bool update = false;
                ENabizMaterial eNabizMaterial = (ENabizMaterial)context.GetObject(sendToENabiz.InternalObjectID.Value, sendToENabiz.InternalObjectDefName);
                if (eNabizMaterial.CurrentStateDefID != ENabizMaterial.States.Cancelled)
                {
                    if (eNabizMaterial.RequestDate < eNabizMaterial.SubActionMaterial.SubEpisode.OpeningDate)
                    {
                        eNabizMaterial.RequestDate = eNabizMaterial.SubActionMaterial.SubEpisode.OpeningDate.Value.AddMinutes(1);
                        eNabizMaterial.ApplicationDate = eNabizMaterial.SubActionMaterial.SubEpisode.OpeningDate.Value.AddMinutes(2);
                        update = true;
                    }

                    if (eNabizMaterial.RequestDate > eNabizMaterial.ApplicationDate)
                    {
                        eNabizMaterial.ApplicationDate = eNabizMaterial.RequestDate.Value.AddMinutes(1);
                        update = true;
                    }

                    if (eNabizMaterial.ApplicationDate < Common.RecTime() && update == false)
                        update = true;

                    if (update && sendToENabiz.Status != SendToENabizEnum.ToBeSent)
                    {
                        SendToENabiz updateSendToENabiz = (SendToENabiz)context.GetObject((Guid)(sendToENabiz.ObjectID), typeof(SendToENabiz).Name);
                        updateSendToENabiz.Status = SendToENabizEnum.ToBeSent;
                    }
                }
            }
            context.Save();
            context.Dispose();
            msg ="E Nabýz Planlý Görevi Tamamlandý.";
            AddLog(msg);
        }
        public override void AddLog(string log)
        {
            base.AddLog(log);
        }

        #endregion Methods
    }
}