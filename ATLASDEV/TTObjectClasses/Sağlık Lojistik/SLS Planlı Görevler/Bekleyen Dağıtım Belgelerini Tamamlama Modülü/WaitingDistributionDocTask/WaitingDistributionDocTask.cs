
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
    /// Bekleyen Dağıtım Belgelerini Tamamlama
    /// </summary>
    public  partial class WaitingDistributionDocTask : BaseScheduledTask
    {
        #region Methods
        public override void TaskScript()
        {
            Guid storeID = Guid.Empty;
            int expirationDay = 2;

            if (ExpirationDay.HasValue)
                expirationDay = ExpirationDay.Value;

            expirationDay = expirationDay * -1;

            DateTime now = new DateTime(Common.RecTime().Year, Common.RecTime().Month, Common.RecTime().Day, 0, 0, 0);
            DateTime endDate = new DateTime(Common.RecTime().Year, Common.RecTime().Month,Common.RecTime().Day, 23, 59, 59);
            DateTime startDate = now.AddDays(expirationDay);


            BindingList<DistributionDocument.GetWaitingDistributionDocument_Class> waitingDistributionDocuments = DistributionDocument.GetWaitingDistributionDocument(startDate,endDate);
            if (waitingDistributionDocuments.Count > 0)
            {
                string msg = string.Empty;
                foreach(DistributionDocument.GetWaitingDistributionDocument_Class waitingDistributionDocument in waitingDistributionDocuments)
                {
                    TTObjectContext context = new TTObjectContext(false);
                    DistributionDocument distributionDocument = (DistributionDocument)context.GetObject(waitingDistributionDocument.ObjectID.Value, typeof(DistributionDocument));
                    if (distributionDocument.AccountingTerm != null && distributionDocument.AccountingTerm.Status == AccountingTermStatusEnum.Open)
                    {
                        distributionDocument.CurrentStateDefID = DistributionDocument.States.Completed;
                        distributionDocument.Description += " Otomatik Tamamlandı.";

                        try
                        {
                            context.Save();
                            msg = msg + "\r\n" + distributionDocument.StockActionID.ToString() + " işlem numaralı belge tamamlandı.";
                        }
                        catch (Exception ex)
                        {
                            msg = msg + "\r\n" + distributionDocument.StockActionID.ToString() + " işlem numaralı belge tamamlanamadı. HATA: " + ex.Message;
                        }
                    }
                    context.Dispose();
                }
                AddLog(msg);
            }
        }
        public override void AddLog(string log)
        {
            base.AddLog(log);
        }

        #endregion Methods
    }
}