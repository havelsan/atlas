
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
    /// İlaç Üretim Testi modülü için kullanılan temel sınıftır
    /// </summary>
    public  partial class DrugProductionTest : StockAction
    {
        public partial class DrugTestReportNQL_Class : TTReportNqlObject 
        {
        }

        protected override void PreInsert()
        {
#region PreInsert
            


            base.PreInsert();

            if (DrugProductionProcedure == null)
                throw new TTUtils.TTCallAdminException();
            else
                Store = DrugProductionProcedure.Store;




#endregion PreInsert
        }

        protected void PostTransition_Request2QualityControl()
        {
            // From State : Request   To State : QualityControl
#region PostTransition_Request2QualityControl
            
            

            IList<TTUser> authorizedUsers = new List<TTUser>();
            foreach(TTUser user in TTUser.GetAllUsers())
            {
                foreach (TTRoleMemberBase userRole in user.AllRoles)
                {
                    if(userRole.RoleID.ToString() == "cf0a95a1-dcf8-4bea-be81-50eb80a603ee" && authorizedUsers.Contains(user) == false)
                    {
                        authorizedUsers.Add(user);
                        break;
                    }
                }
            }

            if (authorizedUsers.Count > 0)
            {
                IList<ResUser> resUser = new List<ResUser>();
                foreach (TTUser ttUser in authorizedUsers)
                {
                    if(resUser.Contains((ResUser)ttUser.UserObject) == false)
                        resUser.Add((ResUser)ttUser.UserObject);
                }
                UserMessage.SendMessageV2(ObjectContext, resUser, TTUtils.CultureService.GetText("M27133", "Uyarı"), TTUtils.CultureService.GetText("M27239", "Yeni kalite kontrol isteği"), false);
            }

#endregion PostTransition_Request2QualityControl
        }

#region Methods
        public bool FromMilitaryDrugProductionProcedure = false;

        override protected void OnConstruct()
        {
            base.OnConstruct();
            ITTObject ttObject = (ITTObject)this;
            if (ttObject.IsNew)
                AnalyseNo.GetNextValue();
        }

        public string Summary
        {
            get
            {
                string retValue = string.Empty;
                retValue = "İstek Tarihi : " + TransactionDate.Value.ToShortDateString();
                if (DrugProductionTestDetails.Count > 0)
                {
                    retValue += " İstenen Testler : ";
                    foreach (DrugProductionTestDetail dpt in DrugProductionTestDetails)
                        retValue += dpt.ProductAnalysisTestDefinition.Name + " - ";
                }
                return retValue;
            }
        }

        public string SetParentProductionProcedure(string serialNo)
        {
            IList procedure = MilitaryDrugProductionProcedure.GetProcedureBySerialNumber(ObjectContext, serialNo);
            switch (procedure.Count)
            {
                case 0:
                    return TTUtils.CultureService.GetText("M25339", "Bu seri numarasına sahip üretim işlemi bulunamadı");
                    //break;
                case 1:
                    MilitaryDrugProductionProcedure mdpp = (MilitaryDrugProductionProcedure)procedure[0];
                    if (mdpp.CurrentStateDefID == MilitaryDrugProductionProcedure.States.Cancelled)
                        return TTUtils.CultureService.GetText("M25345", "Bu üretim işlemi iptal edilmiştir.");
                    else if (mdpp.CurrentStateDefID == MilitaryDrugProductionProcedure.States.Completed)
                        return TTUtils.CultureService.GetText("M25346", "Bu üretim işlemi tamamlanmıştır.");
                    else if (mdpp.CurrentStateDefID == MilitaryDrugProductionProcedure.States.New)
                        return TTUtils.CultureService.GetText("M25344", "Bu üretim işlemi analiz yapılabilecek bir safhada değildir.");
                    else
                    {
                        DrugProductionProcedure = (MilitaryDrugProductionProcedure)procedure[0];
                        return null;
                    }
                   // break;
                default:
                    return TTUtils.CultureService.GetText("M25278", "Birden fazla sayıda üretim işlemi bulundu. Bilgi işlemi arayınız.");
                    //break;
            }
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DrugProductionTest).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DrugProductionTest.States.Request && toState == DrugProductionTest.States.QualityControl)
                PostTransition_Request2QualityControl();
        }

    }
}