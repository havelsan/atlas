
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
    /// New Form
    /// </summary>
    public partial class InPatientAdmissionBaseForm : EpisodeActionForm
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
#region InPatientAdmissionBaseForm_PreScript
    base.PreScript();
           
#endregion InPatientAdmissionBaseForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region InPatientAdmissionBaseForm_ClientSidePreScript
    base.ClientSidePreScript();
            SetNumberOfEmptyBedsByPhysicalStateClinic();
#endregion InPatientAdmissionBaseForm_ClientSidePreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region InPatientAdmissionBaseForm_PostScript
    base.PostScript(transDef);
         
            if (transDef != null)
            {
                if (transDef.ToStateDef.Status == StateStatusEnum.Cancelled)
                {
                    string givenMsg = Episode.GivenValuableMaterialsMsg(this._InpatientAdmission.Episode);
                    string takenMsg = Episode.TakenValuableMaterialsMsg(this._InpatientAdmission.Episode);
                    if (givenMsg != "" || takenMsg != "")
                    {
                        if (transDef.ToStateDef.Status == StateStatusEnum.Cancelled)
                            throw new Exception(SystemMessage.GetMessageV3(1175, new string[] { givenMsg.ToString(), takenMsg.ToString() }));
                    }
                }
            }
#endregion InPatientAdmissionBaseForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region InPatientAdmissionBaseForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
               //this.ToReturnToClinic(transDef);
#endregion InPatientAdmissionBaseForm_ClientSidePostScript

        }

#region InPatientAdmissionBaseForm_ClientSideMethods
        //public void ToReturnToClinic(TTObjectStateTransitionDef transDef)
        //{
        //    if (transDef != null)
        //    {
        //        if (transDef.ToStateDefID == InpatientAdmission.States.ReturnToClinic)
        //        {
        //            StringEntryForm frm = new StringEntryForm();
        //            this._InpatientAdmission.ReturnToClinicReason = this._InpatientAdmission.ReturnToClinicReason + "\r\n" + Common.RecTime().ToString() + " " + frm.ShowAndGetStringForm("Kliniğe İade Sebebi");

        //            MultiSelectForm mSItem = new MultiSelectForm();
        //            foreach (InPatientTreatmentClinicApplication iPTCA in this._InpatientAdmission.InPatientTreatmentClinicApplications)
        //            {
        //                mSItem.AddMSItem(iPTCA.MasterResource.ToString(), iPTCA.ObjectID.ToString(), iPTCA);
        //            }
        //            string key = mSItem.GetMSItem(this, "İade ediceğiniz Kliniği seçiniz", true, true, false, false, true, true);

        //            if (!string.IsNullOrEmpty(key))
        //            {
        //                //Seçilen Klinik işlemlerinin masterresourceü secmastera atanır ReturnToClinic stepi secmastera göre iş listesine düşer.
        //                this._InpatientAdmission.SecondaryMasterResource = ((InPatientTreatmentClinicApplication)mSItem.MSSelectedItemObject).MasterResource;
        //            }
        //            else
        //            {
        //                throw new Exception(SystemMessage.GetMessage(1176));
        //            }
        //        }
        //    }
        //}
        
       
        
        
        protected void SetNumberOfEmptyBedsByPhysicalStateClinic()
        {
            if (this.BaseNumberOfEmptyBeds.Visible == true)
            {
                if (this._InpatientAdmission.PhysicalStateClinic == null)
                {
                    this.BaseNumberOfEmptyBeds.Text = "";
                }
                else
                {
                    this.BaseNumberOfEmptyBeds.Text = Convert.ToString(Common.GetNumberOfEmptyBeds((Guid)this._InpatientAdmission.PhysicalStateClinic.ObjectID));
                }
            }

        }
        
#endregion InPatientAdmissionBaseForm_ClientSideMethods
    }
}