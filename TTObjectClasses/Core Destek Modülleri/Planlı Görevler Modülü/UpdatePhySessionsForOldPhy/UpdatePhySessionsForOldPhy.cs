
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
    /// Eski FTR işlemleri için SessionInfo Ekleme
    /// </summary>
    public partial class UpdatePhySessionsForOldPhy : BaseScheduledTask
    {
        public override void TaskScript()
        {
            TTObjectContext roObjectContext = new TTObjectContext(true);

            BindingList<PhysiotherapyRequest> physiotherapyRequestList = PhysiotherapyRequest.GetPhysiotherapyRequestList(roObjectContext);
            List<Guid> errorList = new List<Guid>();
            foreach (var physiotherapyRequest in physiotherapyRequestList)
            {
                TTObjectContext objectContext = new TTObjectContext(false);
                PhysiotherapyRequest request = objectContext.GetObject(physiotherapyRequest.ObjectID, typeof(PhysiotherapyRequest)) as PhysiotherapyRequest;

                try
                {
                    if (request.PhysiotherapyOrderDetails.Where(c => c.PhysiotherapySession != null && c.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled).Count() > 0)
                    {
                        foreach (var item in request.PhysiotherapyOrderDetails.Where(c => c.PhysiotherapySession != null && c.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled))
                        {
                            //var olan sessionlar silinecek! Yerine yenileri eklenecek
                            ((ITTObject)item).Delete();
                        }
                        objectContext.Save();
                    }

                    var orderDetailList = request.PhysiotherapyOrderDetails.Where(m => m.CurrentStateDefID != PhysiotherapyOrderDetail.States.Cancelled).OrderBy(x => x.PlannedDate).GroupBy(c => c.PlannedDate.Value.Date);
                    foreach (var groupedItem in orderDetailList)
                    {
                        PhysiotherapySessionInfo _sessionInfo = new PhysiotherapySessionInfo(objectContext);
                        _sessionInfo.PlannedDate = groupedItem.FirstOrDefault().PlannedDate;
                        _sessionInfo.PhysiotherapyRequest = request;
                        foreach (var orderDetail in groupedItem)
                        {
                            orderDetail.PhysiotherapySession = _sessionInfo;
                        }
                    }

                    objectContext.Save();

                }
                catch (Exception)
                {
                    errorList.Add(request.ObjectID);

                }


                objectContext.Dispose();
            }

            string errorListId = "";
            foreach (var item in errorList)
            {
                errorListId += item + " , ";
            }

            AddLog(errorListId + " Id işlemler için seans tamamlama işleminde hata alındı.  " + Common.RecTime().ToString());
            AddLog("Fizyoterapi eski işlemler için seans tanımlama metodu başarılı tamamlandı. " + Common.RecTime().ToString());
        }
    }
}