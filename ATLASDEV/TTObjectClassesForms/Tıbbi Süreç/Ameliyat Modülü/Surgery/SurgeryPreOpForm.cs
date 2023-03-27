
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Ameliyat
    /// </summary>
    public partial class SurgeryPreOpForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region SurgeryPreOpForm_PreScript
    base.PreScript();
            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["SurgeryExpend"], (ITTGridColumn)this.GridSurgeryExpends.Columns["CAMaterial"]);
#endregion SurgeryPreOpForm_PreScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region SurgeryPreOpForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            if (transDef != null)
            {
                //if (transDef.FromStateDefID == Surgery.States.SurgeryPreOp)
                //    this._Surgery.IsPatientApprovalFormGiven = this.GetIfPatientApprovalFormIsGiven(this._Surgery.IsPatientApprovalFormGiven);
            }
#endregion SurgeryPreOpForm_ClientSidePostScript

        }

        #region SurgeryPreOpForm_Methods
        /*private void FireIntensiveCareAfterSurgery()
        {
            //Eskiden yeni süreçden başalyabiliyodu o zman bu koda bakılıyordu şimdi yeni süreçden Ameliyat sonrası derlem başlamıyor o yüzden commentlendi
            //            foreach (IntensiveCareAfterSurgery iCareAfterSurgery in this._Surgery.Episode.IntensiveCareAfterSurgeries)
            //            {
            //                if (!iCareAfterSurgery.IsCancelled && iCareAfterSurgery.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
            //                {
            //                    return ;
            //                }
            //            }

            
            
            // postop Ameliyatta yapılacağı için aşağıdaki kodlar commentlendi .Eğer Klinikde yapılacak olursa bu kodlar tekrar açılıp düzenlenmeli
            //            ResClinic masteResource=null;
            //            if (((ResSurgeryDepartment)this._Surgery.MasterResource).Department!=null)
            //            {
            //                IList intensiveCares = ResIntensiveCare.GetByDepartment(this._Surgery.ObjectContext,((ResSurgeryDepartment)this._Surgery.MasterResource).Department.ObjectID.ToString());
            //                if (intensiveCares.Count<1)
            //                {
            //                    IList clinics = ResClinic.GetByDepartment(this._Surgery.ObjectContext,((ResSurgeryDepartment)this._Surgery.MasterResource).Department.ObjectID.ToString());
            //                    if (clinics.Count>0)
            //                    {
            //                        masteResource=(ResClinic)clinics[0];
            //                    }
            //                }
            //                else
            //                {
            //                    masteResource=(ResClinic)intensiveCares[0];
            //                }
            //            }
            //            if (masteResource==null)
            //            {
            //                //YAPILACAKLAR//Msitemdan intensiveCareAfterSurgeryin başlatılacağı birim seçilmeli//YAPILDI..yilmaz
            //                IList<ResClinic> listTemp = (IList<ResClinic>)this._Surgery.ObjectContext.QueryObjects("ResClinic");
            //                SortedList<object, object> resources = new SortedList<object, object>();
            //                foreach(ResClinic clinic in listTemp)
            //                    resources.Add(clinic.Name, clinic);
            //                SortedList<object, object> selectedRes = Common.GetSelectedMSItemList(resources,false,"Birimler");
            //                if(selectedRes != null && selectedRes.Count != 0)
            //                    masteResource = (ResClinic)selectedRes.Values[0];
            //            }
            
            if(this._Surgery.IntensiveCareAfterSurgeries.Count<1)
            {
                ResSection masteResource=(ResSection)this._Surgery.MasterResource;
                IntensiveCareAfterSurgery  intensiveCareAfterSurgery = new IntensiveCareAfterSurgery(this._Surgery,(ResSection)masteResource);
            }
        }*/

        // TODo After ts
        // GridPreOpApplications  gridi Yerine  NursingOrderDetailWithoutOrderForm Kullanılmalı

        #endregion SurgeryPreOpForm_Methods
    }
}