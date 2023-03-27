
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
    /// Radyoloji Tetkik İnceleme Formu
    /// </summary>
    public partial class RadiologyTestRequestAcceptionForm : RadiologyTestBaseForm
    {
        override protected void BindControlEvents()
        {
            GunuBirlikTakip.CheckedChanged += new TTControlEventDelegate(GunuBirlikTakip_CheckedChanged);
            cmdPrintRequestNo.Click += new TTControlEventDelegate(cmdPrintRequestNo_Click);
            ttbuttonToothSchema.Click += new TTControlEventDelegate(ttbuttonToothSchema_Click);
            ttPrintRequestBarcode.Click += new TTControlEventDelegate(ttPrintRequestBarcode_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            GunuBirlikTakip.CheckedChanged -= new TTControlEventDelegate(GunuBirlikTakip_CheckedChanged);
            cmdPrintRequestNo.Click -= new TTControlEventDelegate(cmdPrintRequestNo_Click);
            ttbuttonToothSchema.Click -= new TTControlEventDelegate(ttbuttonToothSchema_Click);
            ttPrintRequestBarcode.Click -= new TTControlEventDelegate(ttPrintRequestBarcode_Click);
            base.UnBindControlEvents();
        }

        private void GunuBirlikTakip_CheckedChanged()
        {
#region RadiologyTestRequestAcceptionForm_GunuBirlikTakip_CheckedChanged
   if(this.GunuBirlikTakip.Value == true){
              //  this._Manipulation.CreateSubEpisode = true;
                this.TabSubaction.ShowTabPage(MedulaTakipBilgileriTabPage);
                this.tedaviTipi.Required = true;
                this.takipTipi.Required = true;
            }else{
               // this._Manipulation.CreateSubEpisode = false;
                this.TabSubaction.HideTabPage(MedulaTakipBilgileriTabPage);
                this.tedaviTipi.Required = false;
                this.takipTipi.Required = false;
              //  this.bransKodu.Required = false;
            }
#endregion RadiologyTestRequestAcceptionForm_GunuBirlikTakip_CheckedChanged
        }

        private void cmdPrintRequestNo_Click()
        {
            /*
            #region RadiologyTestRequestAcceptionForm_cmdPrintRequestNo_Click
            RadiologyTest.PrintRadiologyRequestBarcode(this._RadiologyTest);
#endregion RadiologyTestRequestAcceptionForm_cmdPrintRequestNo_Click */
        }

        private void ttbuttonToothSchema_Click()
        {
            #region RadiologyTestRequestAcceptionForm_ttbuttonToothSchema_Click
            //TODO:ShowEdit!
            //RadiologyTestDentalToothSchema radiologyTestDentalForm = new RadiologyTestDentalToothSchema();
            //if (radiologyTestDentalForm != null)
            //    radiologyTestDentalForm.ShowEdit(this.FindForm(),_RadiologyTest,true);
            var a = 1;
            #endregion RadiologyTestRequestAcceptionForm_ttbuttonToothSchema_Click
        }

        private void ttPrintRequestBarcode_Click()
        {
#region RadiologyTestRequestAcceptionForm_ttPrintRequestBarcode_Click
   Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
            cache.Add("VALUE", this._RadiologyTest.ObjectID);
            parameters.Add("TTOBJECTID", cache);
            
         
            if(this.ttBarcodePreviewCheck.Value == true)
            {
                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_RadiologyRequestBarcode), true, 1, parameters);
            }
            else
            {
                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_RadiologyRequestBarcode), false, 1, parameters);
            }
#endregion RadiologyTestRequestAcceptionForm_ttPrintRequestBarcode_Click
        }

        protected override void PreScript()
        {
#region RadiologyTestRequestAcceptionForm_PreScript
  
            this.DropStateButton(RadiologyTest.States.Completed);

            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["RadiologyMaterial"], (ITTGridColumn)this.Materials.Columns["Material"]);

            EpisodeAction thisAction = this._RadiologyTest.EpisodeAction;
            Radiology radiology = this._RadiologyTest.Radiology;
            ResUser requestUser = null;
            Guid radTestDefGuid = ((RadiologyTestDefinition)this._RadiologyTest.ProcedureObject).ObjectID;

            if (!this._RadiologyTest.RadiologyRequestNo.Value.HasValue)
                this._RadiologyTest.RadiologyRequestNo.GetNextValue();
            
            if (radiology.ProcedureDoctor == null)
            {
                if (radiology.MasterAction is HealthCommittee) //Sağlık kurulundan istenmiş
                {
                    foreach (TTObjectState objectState in radiology.GetStateHistory())
                    {
                        if (objectState.StateDefID == Radiology.States.Request)
                        {
                            requestUser = (ResUser)objectState.User.UserObject;
                            radiology.ProcedureDoctor = requestUser;
                            radiology.RequestDoctor = requestUser;
                            foreach (RadiologyTest radTest in radiology.RadiologyTests)
                            {
                                if (radTest.ProcedureDoctor == null)
                                    radTest.ProcedureDoctor = requestUser;
                            }
                        }
                    }
                }
            }

            if (this._RadiologyTest.Department == null)
            {
                IList radTestDepartmentList = RadiologyGridDepartmentDefinition.GetRadGridDepartments(this._RadiologyTest.ObjectContext, " WHERE RADIOLOGYTEST = '" + radTestDefGuid.ToString() + "'");
                if (radTestDepartmentList.Count > 0)
                    this._RadiologyTest.Department = ((RadiologyGridDepartmentDefinition)radTestDepartmentList[0]).Department;
            }

            if (this._RadiologyTest.Equipment == null)
            {
                IList radTestEquipmentList = RadiologyGridEquipmentDefinition.GetRadGridEquipments(this._RadiologyTest.ObjectContext, " WHERE RADIOLOGYTEST = '" + radTestDefGuid.ToString() + "'");
                if (radTestEquipmentList.Count > 0)
                    this._RadiologyTest.Equipment = ((RadiologyGridEquipmentDefinition)radTestEquipmentList[0]).Equipment;
            }

            BindingList<Appointment> myNotApprovedAppointments = new BindingList<Appointment>();
            myNotApprovedAppointments = MyNotApprovedAppointments(this._RadiologyTest.ObjectID);

            if (myNotApprovedAppointments.Count > 0)
            {
                if (myNotApprovedAppointments[0].Resource is ResRadiologyEquipment)
                {
                    this._RadiologyTest.Equipment = (ResRadiologyEquipment)myNotApprovedAppointments[0].Resource;
                    this.DropStateButton(RadiologyTest.States.Appointment);
                }
            }

            //Asagıdakı blok clıentsıde prescrıpte tasındı
            /*
            if (this._RadiologyTest.Radiology.SourceObjectID != null) //XXXXXXler Arası Sevkden yaratıldı ise
            {
                if (thisAction.Episode.CreaterSite != null)
                {
                    if (thisAction.SubEpisode.PatientAdmissionCorrections.Count == 0)
                    {
                        PatientAdmissionCorrection patientAdmissionCorrection = new PatientAdmissionCorrection(thisAction.ObjectContext);
                        patientAdmissionCorrection.CurrentStateDefID = PatientAdmissionCorrection.States.Request;
                        patientAdmissionCorrection.SetMandatoryEpisodeActionProperties(thisAction, thisAction.MasterResource, thisAction.MasterResource, true);
                        patientAdmissionCorrection.Update();

                        PatientAdmissionCorrectionRequestForm frm = (PatientAdmissionCorrectionRequestForm)TTForm.GetEditForm(patientAdmissionCorrection);
                        if (frm != null)
                        {
                            if (frm.ShowEdit(this.FindForm(), patientAdmissionCorrection) == DialogResult.Cancel)
                                throw new Exception(SystemMessage.GetMessage(151));
                        }
                    }
                }
            }

            
            // Medula Takip işlemi için medula Provision nesnesi initialize ediliyor.
            if (!(this._RadiologyTest.Episode.PatientStatus == PatientStatusEnum.Outpatient && this._RadiologyTest.Episode.IsMedulaEpisode() == true && this._RadiologyTest.ProcedureObject != null && this._RadiologyTest.ProcedureObject.MedulaProvisionNecessity == true))
            {
                this.TabSubaction.HideTabPage(MedulaTakipBilgileriTabPage);
                this.tedaviTipi.Required = false;
                this.takipTipi.Required = false;
                //this.bransKodu.Required = false;
                this.GunuBirlikTakip.Visible = false;
                this.GunuBirlikTakip.Required = false;
                
            }
            
            this.cmdOK.Visible = false;
            */
            
            base.PreScript();
            //this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["RadiologyMaterial"], (ITTGridColumn)this.Materials.Columns["Material"]);
#endregion RadiologyTestRequestAcceptionForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region RadiologyTestRequestAcceptionForm_ClientSidePreScript
    base.ClientSidePreScript();
            
            EpisodeAction thisAction = this._RadiologyTest.EpisodeAction;
            if (this._RadiologyTest.Radiology.SourceObjectID != null) //XXXXXXler Arası Sevkden yaratıldı ise
            {
               //
            }

            
            // Medula Takip işlemi için medula Provision nesnesi initialize ediliyor.
            if (!(this._RadiologyTest.Episode.PatientStatus == PatientStatusEnum.Outpatient && SubEpisode.IsSGKSubEpisode(_RadiologyTest.SubEpisode) == true && this._RadiologyTest.ProcedureObject != null && this._RadiologyTest.ProcedureObject.DailyMedulaProvisionNecessity == true))
            {
                this.TabSubaction.HideTabPage(MedulaTakipBilgileriTabPage);
                this.tedaviTipi.Required = false;
                this.takipTipi.Required = false;
                //this.bransKodu.Required = false;
                this.GunuBirlikTakip.Visible = false;
                this.GunuBirlikTakip.Required = false;
                
            }
            
            //this.cmdOK.Visible = false;
#endregion RadiologyTestRequestAcceptionForm_ClientSidePreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region RadiologyTestRequestAcceptionForm_PostScript
    base.PostScript(transDef);

            if (transDef != null)
            {
                if (transDef.ToStateDefID == RadiologyTest.States.Reject || transDef.ToStateDefID == RadiologyTest.States.Cancelled)
                    return;               
            }

            if (String.IsNullOrEmpty(this._RadiologyTest.AccessionNo))
            {
                Guid AccessionNumber = new Guid("a40495b0-9265-432c-9467-f2b14f3b020c");
                this._RadiologyTest.AccessionNo = TTSequence.GetNextSequenceValueFromDatabase(TTObjectDefManager.Instance.DataTypes[AccessionNumber], null, null).ToString();
            }

            foreach (Appointment app in MyNotApprovedAppointments(this._RadiologyTest.ObjectID)) //Complete My Not Approved Appointments
            {
                if (app.CurrentStateDefID == Appointment.States.New || app.CurrentStateDefID == Appointment.States.NotApproved)
                    app.CurrentStateDefID = Appointment.States.Completed;
            }
#endregion RadiologyTestRequestAcceptionForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region RadiologyTestRequestAcceptionForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            
            if (transDef != null)
            {
                if (transDef.FromStateDefID == RadiologyTest.States.RequestAcception &&  transDef.ToStateDefID  == RadiologyTest.States.Reject)
                    this.DisplayRadiologyRejectReason();
            }
#endregion RadiologyTestRequestAcceptionForm_ClientSidePostScript

        }

#region RadiologyTestRequestAcceptionForm_ClientSideMethods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            if (transDef != null)
            {
                if (transDef.ToStateDefID == RadiologyTest.States.Procedure)
                {
                    string sysparam = TTObjectClasses.SystemParameter.GetParameterValue("HL7ENGINEALIVE", null);
                    if (sysparam == "TRUE")
                    {
                        base.AfterContextSavedScript(transDef);
                        List<Guid> appIDs = new List<Guid>();
                        appIDs.Add(this._RadiologyTest.ObjectID);

                        TTObjectContext objectContext = new TTObjectContext(false);
                        RadiologyTest radTest = (RadiologyTest)objectContext.GetObject(this._RadiologyTest.ObjectID, "RADIOLOGYTEST");

                        if (radTest.IsMessageInPACS == true)
                        {
                            try
                            {
                                //TTMessage message = TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.HighPriority, "InternalTcpClient", "HL7Remoting", "SendHospitalMessageToEngine", null, appIDs, "O01XO", "PACS");
                                //radTest.IsMessageInPACS = true;
                            }
                            catch
                            {
                                radTest.IsMessageInPACS = false;
                                throw;
                            }
                            finally
                            {
                                objectContext.Save();
                            }
                        }
                        else
                        {
                            try
                            {
                                //TTMessage message = TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.HighPriority, "InternalTcpClient", "HL7Remoting", "SendHospitalMessageToEngine", null, appIDs, "O01", "PACS");
                                //radTest.IsMessageInPACS = true;
                                //radTest.Radiology.RequestDoctor.SendUserToPACS();
                            }
                            catch
                            {
                                radTest.IsMessageInPACS = false;
                                throw;
                            }
                            finally
                            {
                                objectContext.Save();
                            }
                        }
                    }
                    

                  
                    //SITEID ye gore kontrol vardi, kaldirildi. istenirse baska bir sistem parametresine bagli calistirilabilir.
                        if (transDef != null)
                        {
                            if (transDef.ToStateDefID == RadiologyTest.States.Procedure || transDef.ToStateDefID == RadiologyTest.States.Appointment)
                            {
                                Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();

                                TTReportTool.PropertyCache<object> testObjectID = new TTReportTool.PropertyCache<object>();
                                testObjectID.Add("VALUE", this._RadiologyTest.ObjectID.ToString());

                                TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
                                objectID.Add("VALUE", this._RadiologyTest.Radiology.ObjectID.ToString());

                                parameters.Add("TTOBJECTID", objectID);
                                parameters.Add("TESTOBJECTID", testObjectID);
                                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_RadiologyRequestDescription), true, 1, parameters);
                            }
                        }
                }
                else if (transDef.ToStateDefID == RadiologyTest.States.Appointment)
                {
                    TTObjectContext objectContext = new TTObjectContext(false);
                    RadiologyTest radTest = (RadiologyTest)objectContext.GetObject(this._RadiologyTest.ObjectID, "RADIOLOGYTEST");

                    if (radTest != null)
                    {
                        //foreach (Appointment app in _RadiologyTest.MyNewAppointments)
                        //{
                        //    if (Convert.ToDateTime(_RadiologyTest.Episode.OpeningDate).AddDays(10) < app.AppDate)
                        //    {
                        //        radTest.CurrentStateDefID = RadiologyTest.States.AdmissionAppointment;
                        //        objectContext.Save();
                        //    }
                        //    else
                        //    {
                        string injectionStr = "WHERE INITIALOBJECTID = '" + radTest.ObjectID + "'";
                        IList appList = Appointment.GetByInjection(objectContext, injectionStr);
                        if (appList.Count > 0)
                        {
                            radTest.CurrentStateDefID = RadiologyTest.States.AdmissionAppointment;
                            objectContext.Save();
                        }
                    }
                    //}
                    //}
                }
            }
            base.AfterContextSavedScript(transDef);
        }

        public virtual BindingList<Appointment> MyNotApprovedAppointments(Guid objectID)
        {
            TTObjectContext objContext = new TTObjectContext(true);

            BindingList<Appointment> retList = (BindingList<Appointment>)objContext.QueryObjects<Appointment>("SUBACTIONPROCEDURE = " + ConnectionManager.GuidToString(objectID) + " AND CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(Appointment.States.NotApproved), "APPDATE");
                foreach (Appointment app in objContext.LocalQuery("APPOINTMENT", "SUBACTIONPROCEDURE = " + ConnectionManager.GuidToString(objectID) + " AND CURRENTSTATEDEFID = " + ConnectionManager.GuidToString(Appointment.States.NotApproved), "APPDATE"))
                    if (retList.Contains(app) == false)
                        retList.Add(app);
                return retList;
            
        }

        #endregion RadiologyTestRequestAcceptionForm_ClientSideMethods


    }
}