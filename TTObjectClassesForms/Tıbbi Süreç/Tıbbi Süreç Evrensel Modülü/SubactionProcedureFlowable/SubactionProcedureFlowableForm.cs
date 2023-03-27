
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
    public partial class SubactionProcedureFlowableForm : TTForm
    {
        protected override void PreScript()
        {
#region SubactionProcedureFlowableForm_PreScript
    base.PreScript();
        this.PrepareFormTitle();
        this.IfDiagnosisIsRequired();
        SubactionProcedureFlowable.CheckPaid(_SubactionProcedureFlowable);
        DropReportsOfSecurePatient();
#endregion SubactionProcedureFlowableForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region SubactionProcedureFlowableForm_ClientSidePreScript
    base.ClientSidePreScript();
        this.IfNullSelectProcedureSpeciality();
        this.ShowPatientPrivacyInformation(_SubactionProcedureFlowable.Episode.Patient);
        this.ShowImportantMedicalInformation(_SubactionProcedureFlowable);
#endregion SubactionProcedureFlowableForm_ClientSidePreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region SubactionProcedureFlowableForm_PostScript
    base.PostScript(transDef);
        if (transDef != null)
        {
            if (transDef.AllAttributes.ContainsKey("ReasonOfRejectAttribute"))
            {
                    StringEntryForm frm = new StringEntryForm();
                    this._SubactionProcedureFlowable.ReasonOfReject = frm.ShowAndGetStringForm("Red Sebebi");
            }
            if (transDef.ToStateDef.Status == StateStatusEnum.Cancelled)
            {
                    StringEntryForm frm = new StringEntryForm();
                    this._SubactionProcedureFlowable.ReasonOfCancel = frm.ShowAndGetStringForm("İşlem İptal Sebebi");
            }
        }
#endregion SubactionProcedureFlowableForm_PostScript

            }
            
#region SubactionProcedureFlowableForm_Methods


    protected virtual void IfDiagnosisIsRequired()
    {
        this._SubactionProcedureFlowable.DiagnosisIsRequired();
    }

    // private Button btnSetAuthorizedUser;
    public void DrawSetAuthorizedUserButton(string buttonTitle)
    {
        this.AddManualStepButton(buttonTitle, new EventHandler(btnSetAuthorizedUser_Click));
        //            const int STATE_BUTTON_SPACE = 3;
        //            const int STATE_BUTTON_MAXWIDTH = 150;
        //            int i = this.pnlButtons.Controls.Count-1;
        //            int x = this.pnlButtons.Controls[i].Location.X + this.pnlButtons.Controls[i].Size.Width+STATE_BUTTON_SPACE;
        //            Graphics g = Graphics.FromHwnd(Handle);
        //            btnSetAuthorizedUser = new Button();
        //            btnSetAuthorizedUser.Text = buttonTitle;
        //            SizeF szText = g.MeasureString(buttonTitle, btnSetAuthorizedUser.Font, STATE_BUTTON_MAXWIDTH);
        //            btnSetAuthorizedUser.Size = new Size((int) (szText.Width*1.5), cmdOK.Height);
        //            btnSetAuthorizedUser.Location = new Point(x,cmdOK.Top);
        //            btnSetAuthorizedUser.Click += new EventHandler(btnSetAuthorizedUser_Click);
        //            pnlButtons.Controls.Add(btnSetAuthorizedUser);
    }

    void btnSetAuthorizedUser_Click(object sender, EventArgs e)
    {
        try
        {
            if (this._SubactionProcedureFlowable.CurrentStateDef.AllAttributes.ContainsKey("AddAuthorizedUserButton"))
            {
                //UserType parametresi numeric olmalı olmazsa çatlar
                int i = Convert.ToInt32(this._SubactionProcedureFlowable.CurrentStateDef.AllAttributes["AddAuthorizedUserButton"].Parameters["UserType"].Value.ToString());
                UserTypeEnum userTypeEnum = Common.GetUserTypeEnumByValue(i);

                this.SetAuthorizedUserBySelecting(this._SubactionProcedureFlowable.MasterResource, userTypeEnum, false);
                if (this._SubactionProcedureFlowable.CurrentStateDef.AllAttributes["AddAuthorizedUserButton"].Parameters["ToStateDefID"] != null)
                {
                    if (this._SubactionProcedureFlowable.CurrentStateDef.AllAttributes["AddAuthorizedUserButton"].Parameters["ToStateDefID"].Value != null)
                    {
                        Guid stateDefID = new Guid(this._SubactionProcedureFlowable.CurrentStateDef.AllAttributes["AddAuthorizedUserButton"].Parameters["ToStateDefID"].Value.ToString());
                        TTObjectStateTransitionDef transDef = (TTObjectStateTransitionDef)this._SubactionProcedureFlowable.CurrentStateDef.FindOutoingTransitionDefFromStateDefID(stateDefID);
                        if (DoContextUpdate(transDef))
                            this.DialogResult = DialogResult.OK;

                    }
                }
            }
        }
        catch (Exception Ex)
        {
            InfoBox.Alert(Ex);
        }

    }

    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);
        if (this._SubactionProcedureFlowable.CurrentStateDef.AllAttributes.ContainsKey("AddAuthorizedUserButton"))
        {
            //UserType parametresi numeric olmalı olmazsa çatlar
            int i = Convert.ToInt32(this._SubactionProcedureFlowable.CurrentStateDef.AllAttributes["AddAuthorizedUserButton"].Parameters["UserType"].Value.ToString());
            TTDataDictionary.EnumValueDef userTypeEnumValueDef = Common.GetUserTypeEnumValueDefByValue(i);
            this.DrawSetAuthorizedUserButton(userTypeEnumValueDef.DisplayText + " Ata");
        }
    }

    /// <summary>
    /// BaseTreatmentMaterial tipinde bir colu olan formda verilen TreatmentMaterialGridine ait Material kolonunun ListFilterını set eder.
    /// </summary>
    /// <param name="treatmentMaterialDef"></param>
    /// <param name="treatmentMaterialMaterialColumn"></param>
    public virtual void SetTreatmentMaterialListFilter(TTObjectDef treatmentMaterialDef, ITTGridColumn treatmentMaterialMaterialColumn)
    {
        // set edilen depoya göre Malzeme listesinin filtrelenmesi
        string filterString = string.Empty;
        //            string filterString = " THIS.OBJECTDEFNAME IN ('CONSUMABLEMATERIALDEFINITION') ";
        //            if (treatmentMaterialDef.AllAttributes.ContainsKey(typeof(TreatmentMaterialsInculdeDrugDefinitionAttribute).Name.ToString()))
        //            {
        //                filterString = "THIS.OBJECTDEFNAME IN ('CONSUMABLEMATERIALDEFINITION','DRUGDEFINITION') ";
        //            }

        if (!(TTObjectClasses.SystemParameter.GetParameterValue("WORKWITHOUTSTOCK", "FALSE") == "TRUE"))// Böyle Çalışmasının sebebi True haricince ne yazılırsa yazılsın aşağıdaki kodun çalışmasının istenmesi
        {
            Store store = this.GetStore(treatmentMaterialDef);
            if (store == null)
                filterString = "OBJECTID is null";
            else
                filterString = " STOCKS.INHELD>0 AND STOCKS.STORE = '" + store.ObjectID.ToString() + "'";
        }

        ((ITTListBoxColumn)treatmentMaterialMaterialColumn).ListFilterExpression = filterString;

    }

    /// <summary>
    /// Kullanıcının uzmanlık dalına göre tanı listelerine filtre konulup konulmayacağını belirler.
    /// </summary>
    /// <param name="treatmentMaterialDef"></param>
    /// <param name="treatmentMaterialMaterialColumn"></param>
    public virtual void SetDiagnosisListFilter(params ITTGridColumn[] diagnosisColumns)
    {
        UserOption uo = Common.CurrentResource.GetUserOption(UserOptionType.ICDFilter);
        if (uo != null && uo.Value != null && uo.Value.ToString() == "OPEN")
        {
            ArrayList specialityList = new ArrayList();
            string filterString = "";
            string parentGroupIDs = "";
            foreach (UserResource uRes in Common.CurrentResource.UserResources)
            {
                foreach (ResourceSpecialityGrid specGrid in uRes.Resource.ResourceSpecialities)
                {
                    if (specialityList.Contains(specGrid.Speciality) == false)
                        specialityList.Add(specGrid.Speciality);
                }
            }

            foreach (SpecialityDefinition speciality in specialityList)
            {
                IList matchingList = DiagnoseSpecialityMatching.GetBySpeciality(this._SubactionProcedureFlowable.ObjectContext, speciality.ObjectID.ToString());
                foreach (DiagnoseSpecialityMatching dsm in matchingList)
                {
                    foreach (DiagnosisGridForMatching dgm in dsm.Diagnosis)
                    {
                        parentGroupIDs += "'" + dgm.DiagnosisDefinition.ObjectID + "',";
                    }
                }
            }

            if (parentGroupIDs != "")
            {
                filterString = " (OBJECTID IN (" + parentGroupIDs.Substring(0, parentGroupIDs.Length - 1) + "))";
                //filterString += " OR PARENTGROUP IN (" + parentGroupIDs.Substring(0,parentGroupIDs.Length-1) + "))";
            }
            else
                filterString = " 1=0";

            foreach (ITTGridColumn diagnosisColumn in diagnosisColumns)
            {
                ((ITTListBoxColumn)diagnosisColumn).ListFilterExpression = filterString;
            }
        }
    }

    public Store GetStore(TTObjectDef treatmentMaterialDef)
    {
        if (treatmentMaterialDef.AllAttributes.ContainsKey(typeof(StoreUsageAttribute).Name.ToString()) == false)
        {
            return this._SubactionProcedureFlowable.MasterResource.Store;
        }
        else
        {
            string storeUsageEnum = treatmentMaterialDef.Attributes["STOREUSAGEATTRIBUTE"].Parameters["StoreUsage"].Value.ToString();
            switch (storeUsageEnum)
            {
                case "0":
                    return null;
                case "1":
                    return this._SubactionProcedureFlowable.MasterResource.Store;
                    //break;
                case "2":
                    return this._SubactionProcedureFlowable.FromResource.Store;
                   //break;
                case "3":
                    return this._SubactionProcedureFlowable.SecondaryMasterResource.Store;
                   // break;
                case "4":
                    return Common.CurrentResource.Store;
                   // break;
                case "5":
                    return SubactionProcedureFlowable.GetSpecialResourceForStore(this._SubactionProcedureFlowable).Store;
                    default:
                    return this._SubactionProcedureFlowable.MasterResource.Store;
                  //  break;
            }
        }

    }




        public void SetProcedureDoctorAsCurrentResource()
    {
            if (this._SubactionProcedureFlowable.ProcedureDoctor == null && Common.CurrentResource.TakesPerformanceScore == true)
            {
                this._SubactionProcedureFlowable.ProcedureDoctor = Common.CurrentResource;
            }

            //this._SubactionProcedureFlowable.SetProcedureDoctorAsCurrentResource();
        }



    protected virtual void PrepareFormTitle()
    {
        Episode episode = this._SubactionProcedureFlowable.EpisodeAction.Episode;
        if (episode == null)
        {
            throw new TTUtils.TTException(SystemMessage.GetMessage(144));
            //throw new Exception("Alınan bir hatadan dolayı işlemin vakası belirlenememiştir.İşleme devam edilemez");
        }
        if (episode.Patient != null)
            this.Text += " - " + episode.Patient.FullName.ToUpper();
    }


    protected void PrapareFormToShow(TTForm frm)
    {
        frm.ObjectUpdated += new ObjectUpdatedDelegate(ShowAction_ObjectUpdated);
        frm.GetTemplates = this.GetTemplates;
        frm.SaveTemplate = this.SaveTemplate;
        frm.TemplateSelected = this.TemplateSelected;
    }

    protected virtual void ShowAction_ObjectUpdated(TTObject ttObject, ref bool contextSaved)
    {
        ttObject.ObjectContext.Save();
        contextSaved = true;
    }

    public void SaveContextForNewDiagnose()
    {
        this._SubactionProcedureFlowable.ObjectContext.Save();
    }

    public void DropReportsOfSecurePatient()
    {
        if (Common.CurrentResource.IsPatientSecureAndHasNoRightOfUser((IEpisodeActionPermission)this._SubactionProcedureFlowable))
        {
            foreach (TTObjectStateReportDef stateReport in this._SubactionProcedureFlowable.CurrentStateDef.ReportDefs)// tüm StateReport'lar Drop edilir
            {
                this.DropCurrentStateReport(stateReport.ReportDefID);
            }
        }
    }


    // her Yere yeni exe gittiğinde açılsın vib personelin raporlarını kimse bastıramasın diye
    protected virtual bool CheckObjectReportToPrint(TTObjectReportDef objectReportDef)
    {
        if (Common.CurrentResource.IsPatientSecureAndHasNoRightOfUser((IEpisodeActionPermission)this._SubactionProcedureFlowable))
        {
            return false;
        }
        return true;
    }

    

        
#endregion SubactionProcedureFlowableForm_Methods

#region SubactionProcedureFlowableForm_ClientSideMethods
        protected virtual void IfNullSelectProcedureSpeciality()
    {
        if (Common.IsAttributeExists(typeof(NotRequiredProcedureSpecialityAttribute), (TTObject)this._SubactionProcedureFlowable) == false)
        {
            if (this._SubactionProcedureFlowable.ProcedureSpeciality == null)
            {
                if (this._SubactionProcedureFlowable.Episode != null)
                {
                    ResSection resource = null;
                    string title = "";
                    if (this._SubactionProcedureFlowable.SetProcedureSpecialtyBy() == "MASTERRESOURCE")
                    {
                        resource = this._SubactionProcedureFlowable.MasterResource;
                        title = "İşlemin Yapılacağı Uzmanlık Dalını";
                    }
                    else if (this._SubactionProcedureFlowable.SetProcedureSpecialtyBy() == "FROMRESOURCE")
                    {
                        resource = this._SubactionProcedureFlowable.FromResource;
                        title = "İsteğin Yapıldığı Uzmanlık Dalını";
                    }

                    if (resource != null)
                    {
                        if (resource.ResourceSpecialities.Count == 1)
                        {
                            this._SubactionProcedureFlowable.ProcedureSpeciality = resource.ResourceSpecialities[0].Speciality;
                        }
                        else if (resource.ResourceSpecialities.Count > 1)
                        {
                            MultiSelectForm MSItem = new MultiSelectForm();
                            foreach (ResourceSpecialityGrid specialityGrid in resource.ResourceSpecialities)
                            {
                                if (!MSItem.IsItemExists(specialityGrid.Speciality.ObjectID.ToString()))
                                {
                                    MSItem.AddMSItem(specialityGrid.Speciality.Name, specialityGrid.Speciality.ObjectID.ToString(), specialityGrid.Speciality);
                                }

                            }

                            bool getTime = false;
                            while (getTime == false)
                            {
                                title = title + " seçiniz";
                                String key = MSItem.GetMSItem(this, title, false, true, false, false, false, true);
                                if (!string.IsNullOrEmpty(key)) {
                                    this._SubactionProcedureFlowable.ProcedureSpeciality = (SpecialityDefinition)MSItem.MSSelectedItemObject;   // selectedspecialityList.Values[0];
                                    getTime = true;
                                }
                            }
                        }
                    }
                }
                else
                {
                    throw new Exception(SystemMessage.GetMessage(147));
                }
            }
        }
    }

    public void ShowImportantMedicalInformation(SubactionProcedureFlowable spf)
    {
        Episode episode = null;
        if (spf.Episode != null)
        {
            episode = spf.Episode;
        }
        else if (spf.EpisodeAction != null)
        {
            episode = spf.EpisodeAction.Episode;
        }
        if (episode.Patient.ImportantMedicalInformation != null)
        {
            if (episode.Patient.ImportantMedicalInformation.WarnAllMedicalPersonnel == true)
            {
                ImportantMedicalInformation importantMedicalInformation = episode.Patient.ImportantMedicalInformation;
                TTForm frm = TTForm.GetEditForm(importantMedicalInformation);
                if (frm == null)
                {
                        InfoBox.Show("Önemli Tıbbi bilgilere form tanımı yapılmadığından işlem açılamamaktadır");
                }
                else
                {

                    frm.ShowReadOnly(this.FindForm(), importantMedicalInformation);
                }
            }
        }

    }





    public Appointment SelectAppointment(TTObjectContext context, Patient patient, Boolean multiSelect)
    {
        DateTime recDate = Common.RecTime().Date;
        IList<Appointment> patientAppList = Appointment.GetPatientAppointmentsByDate(context, patient.ObjectID, recDate, recDate.AddDays(1));
        MultiSelectForm pMSForm = new MultiSelectForm();
        foreach (Appointment app in patientAppList)
        {
            if (app.Resource != null)
            {
                if (app.MasterResource != null)
                    pMSForm.AddMSItem(app.MasterResource.Name + " - " + app.Resource.Name, app.ObjectID.ToString(), app);
                else
                    pMSForm.AddMSItem(app.Resource.Name, app.ObjectID.ToString(), app);
            }
            else
                pMSForm.AddMSItem(app.MasterResource.Name, app.ObjectID.ToString(), app);
        }
        string sKey;
        if (TTObjectClasses.SystemParameter.GetParameterValue("ForceToSelectAppointment", "FALSE").ToUpper() == "TRUE")
            sKey = pMSForm.GetMSItem(this, "Hastanın aşağıdaki kaynaklarda bugün randevusu var. Hasta, randevusuna geldiyse lütfen seçiniz.", false, true, multiSelect, false, true, true);
        else
            sKey = pMSForm.GetMSItem(this, "Hastanın aşağıdaki kaynaklarda bugün randevusu var. Hasta, randevusuna geldiyse lütfen seçiniz.", false, true, multiSelect);
        if (string.IsNullOrEmpty(sKey))
        {
            return null;
        }
        else
        {
            return (Appointment)pMSForm.MSSelectedItemObject;
        }
    }

    public void SetAuthorizedUserByQueueUser(ResUser queueUser, SubactionProcedureFlowable firedAction)
    {
        if (queueUser != null)
        {
            AuthorizedUser authorizedUser = new AuthorizedUser(firedAction.ObjectContext);
            authorizedUser.User = (ResUser)queueUser;
            firedAction.AuthorizedUsers.Add(authorizedUser);
        }
    }

    public void SetAuthorizedUserBySelecting(ResSection userResource, UserTypeEnum userType, Boolean multiSelect)
    {
        ResUser resUser = SelectUser(this._SubactionProcedureFlowable.ObjectContext, userResource, userType, multiSelect);
        if (resUser == null)
        {
            throw new Exception(SystemMessage.GetMessage(1038));
        }
        else
        {
            AuthorizedUser authorizedUser = new AuthorizedUser(this._SubactionProcedureFlowable.ObjectContext);
            authorizedUser.User = (ResUser)resUser;
            this._SubactionProcedureFlowable.AuthorizedUsers.Add(authorizedUser);
        }
    }

    public void SetPreDiagnosisAsSecDiagnosis(SubactionProcedureWithDiagnosis subactionProcedureWithDiagnosis)
    {
        string diagnoseName = String.Empty;
        var secDiagnosisNotExists = true;
        foreach (DiagnosisGrid preDiagnose in subactionProcedureWithDiagnosis.Diagnosis)
        {
            if (preDiagnose.DiagnosisType == DiagnosisTypeEnum.Primer)
                diagnoseName += preDiagnose.Diagnose.Code + " " + preDiagnose.Diagnose.Name + "\r\n";
            else
            {
                secDiagnosisNotExists = false;
                break;
            }

        }
        if (secDiagnosisNotExists)
        {
            if (!String.IsNullOrEmpty(diagnoseName))
            {
                if (ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Tanı Girişi", "Hiç kesin tanı girmediniz.\r\nGirdiğiniz ön tanıların kesinleştirilmesini ister misiniz? \r\nGirilen Ön Tanılar:\r\n" + diagnoseName) == "E")
                {
                    foreach (DiagnosisGrid preDiagnose in subactionProcedureWithDiagnosis.Diagnosis)
                    {
                        if (preDiagnose.DiagnosisType == DiagnosisTypeEnum.Primer)
                        {
                            DiagnosisGrid secDiagnose = new DiagnosisGrid(subactionProcedureWithDiagnosis.ObjectContext);
                            secDiagnose.AddToHistory = preDiagnose.AddToHistory;
                            secDiagnose.Diagnose = preDiagnose.Diagnose;
                            secDiagnose.DiagnoseDate = Common.RecTime();
                            secDiagnose.Episode = preDiagnose.Episode;
                            secDiagnose.EntryActionType = preDiagnose.EntryActionType;
                            secDiagnose.EpisodeAction = preDiagnose.EpisodeAction;
                            secDiagnose.FreeDiagnosis = preDiagnose.FreeDiagnosis;
                            secDiagnose.ImportantMedicalInformation = preDiagnose.ImportantMedicalInformation;
                            secDiagnose.IsMainDiagnose = preDiagnose.IsMainDiagnose;
                            secDiagnose.SubactionProcedure = preDiagnose.SubactionProcedure;
                            secDiagnose.DiagnosisType = DiagnosisTypeEnum.Seconder;
                        }
                    }
                }
                else
                {
                    throw new Exception(SystemMessage.GetMessage(153));
                }
            }
        }
    }

        
        public ResUser SelectUser(TTObjectContext context,ResSection userResource, UserTypeEnum userType, Boolean multiSelect)
        {
            IList<ResUser> userList = (IList<ResUser>)ResUser.GetByUserResourceAndUserType(context,userType,userResource.ObjectID.ToString());
            MultiSelectForm pMSForm = new MultiSelectForm();
            foreach(ResUser user in userList)
                pMSForm.AddMSItem(user.Name, user.ObjectID.ToString(), user);
            
            string sKey = pMSForm.GetMSItem(this, userResource.Name.ToString() + "kaynağında işlemi gerçekleştirecek kullanıcıyı seçiniz", false, true, multiSelect);
            if (string.IsNullOrEmpty(sKey))
            {
                return null;
            }
            else
            {
                return (ResUser)pMSForm.MSSelectedItemObject;
            }
        }
        
        public ExaminationQueueDefinition SelectQueue(TTObjectContext context,ResSection resource, Boolean multiSelect)
        {
            IList<ExaminationQueueDefinition> appQueueDefinitionList = (IList<ExaminationQueueDefinition>)ExaminationQueueDefinition.GetQueueByResource(context,resource.ObjectID.ToString());
            MultiSelectForm pMSForm = new MultiSelectForm();
            foreach(ExaminationQueueDefinition appQueueDefinition in appQueueDefinitionList)
                pMSForm.AddMSItem(appQueueDefinition.Name, appQueueDefinition.ObjectID.ToString(), appQueueDefinition);
            
            string sKey;
            if(TTObjectClasses.SystemParameter.GetParameterValue("ForceToSelectQueue", "TRUE").ToUpper() == "TRUE")
                sKey = pMSForm.GetMSItem(this, resource.Name.ToString() + " kaynağında hastanın çağırılacağı kuyruğu seçiniz.", false, true, multiSelect,false,true,true);
            else
                sKey = pMSForm.GetMSItem(this, resource.Name.ToString() + " kaynağında hastanın çağırılacağı kuyruğu seçiniz.", false, true, multiSelect);
            if (string.IsNullOrEmpty(sKey))
            {
                return null;
            }
            else
            {
                return (ExaminationQueueDefinition)pMSForm.MSSelectedItemObject;
            }
        }
        
        public ResUser SelectQueueUser(TTObjectContext context,ExaminationQueueDefinition queueDef, Boolean multiSelect)
        {
            if(queueDef != null)
            {
                bool selectDoctor = true;
                if(queueDef.NotAllowToSelectDoctor.HasValue == true && queueDef.NotAllowToSelectDoctor.Value == true)
                    selectDoctor = false;
                if(selectDoctor)
                {
                    IList<Resource> resources = queueDef.GetWorkingResources(context);
                    MultiSelectForm pMSForm = new MultiSelectForm();
                    foreach(Resource resource in resources)
                    {
                        if(resource is ResUser)
                        {
                            pMSForm.AddMSItem(resource.Name, resource.ObjectID.ToString(), resource);
                        }
                    }
                    string sKey;
                    if(TTObjectClasses.SystemParameter.GetParameterValue("ForceToSelectUser", "FALSE").ToUpper() == "TRUE")
                        sKey = pMSForm.GetMSItem(this, queueDef.Name.ToString() + " kuyruğunda hastanın atanacağı doktoru seçiniz.", false, true, multiSelect,false,true,true);
                    else
                        sKey = pMSForm.GetMSItem(this, queueDef.Name.ToString() + " kuyruğunda hastanın atanacağı doktoru seçiniz.", false, true, multiSelect);
                    if (string.IsNullOrEmpty(sKey))
                    {
                        return null;
                    }
                    else
                    {
                        return (ResUser)pMSForm.MSSelectedItemObject;
                    }
                }
            }
            return null;
        }
        
        protected virtual void CreateQueueItem(TTObjectStateTransitionDef transDef)
        {
            if(this._SubactionProcedureFlowable.MasterResource is ResPoliclinic && ((ResPoliclinic)this._SubactionProcedureFlowable.MasterResource).PatientCallSystemInUse == true)
            {
                if(transDef != null && Common.IsTransitionAttributeExists(typeof(CreateQueueItemAttribute),transDef))
                {
                    ExaminationQueueDefinition queueDef = null;
                    queueDef = this.SelectQueue(this._SubactionProcedureFlowable.ObjectContext,this._SubactionProcedureFlowable.MasterResource,false);
                    
                    if(queueDef == null)
                        throw new Exception(SystemMessage.GetMessage(1015));
                    else
                    {
                        ResUser queueUser = this.SelectQueueUser(this._SubactionProcedureFlowable.ObjectContext,queueDef,false);
                        if(queueUser != null)
                        {
                            this.SetAuthorizedUserByQueueUser(queueUser,(SubactionProcedureFlowable)this._SubactionProcedureFlowable);
                            if(this._SubactionProcedureFlowable.AuthorizedUsers.Count > 0)
                            {
                                AuthorizedUser authorizedUser = this._SubactionProcedureFlowable.AuthorizedUsers[this._SubactionProcedureFlowable.AuthorizedUsers.Count-1];
                                this._SubactionProcedureFlowable.ProcedureDoctor=authorizedUser.User;
                            }
                        }
                        else
                        {
                            string uKey = ShowBox.Show(ShowBoxTypeEnum.Message,"Evet,Hayır","E,H","Uyarı","Doktor Atama","Doktor atama yapmadan devam etmek istediğinize emin misiniz?",2);
                            if(String.IsNullOrEmpty(uKey) == true || uKey == "H")
                                throw new Exception(SystemMessage.GetMessage(80));
                        }
                        
                        bool isEmergency = false;
                        if(this._SubactionProcedureFlowable.FromResource != null)
                        {
                            foreach(ResourceSpecialityGrid spg in this._SubactionProcedureFlowable.FromResource.ResourceSpecialities)
                            {
                                if(spg.Speciality != null)
                                    if(spg.Speciality.Code == TTObjectClasses.SystemParameter.GetParameterValue("EMERGENCYSPECIALITYDEFINITIONCODE","4400").ToString()) //Acil Tıp
                                    isEmergency = true;
                            }
                        }
                        ExaminationQueueItem queueItem = null;
                        queueItem = this._SubactionProcedureFlowable.CreateExaminationQueueItem(this._SubactionProcedureFlowable.SubEpisode.PatientAdmission,queueDef,isEmergency);
                        if(queueItem == null)
                            throw new Exception(SystemMessage.GetMessageV3(1016, new string[] { queueDef.Name.ToString()}));
                        else
                            InfoBox.Show(this._SubactionProcedureFlowable.Episode.Patient.RefNo + " " + this._SubactionProcedureFlowable.Episode.Patient.FullName + " hastası," + queueDef.Name + " sırasına eklendi. Sıradaki Toplam Hasta Sayısı : " + queueDef.CurrentItemsCount.ToString(),MessageIconEnum.InformationMessage);
                    }
                }
            }
        }
        
        public void CreateNewTreatmentDischarge()
        {
            ////SaveContextForNewDiagnose();
            //TreatmentDischarge treatmentDischarge;
            //TreatmentDischarge tempTreatmentDischarge;
            ////Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
            ////TTObjectContext objectContext = new TTObjectContext(false);
            //Guid savePointGuid = this._SubactionProcedureFlowable.ObjectContext.BeginSavePoint();
            //try
            //{
            //    if (this._SubactionProcedureFlowable is BaseDentalSubactionProcedure)
            //    {
            //        tempTreatmentDischarge = this._SubactionProcedureFlowable.MyTreatmentDischarge();
            //        if (tempTreatmentDischarge == null)
            //            treatmentDischarge = new TreatmentDischarge(this._SubactionProcedureFlowable.ObjectContext, this._SubactionProcedureFlowable);
            //        else
            //            treatmentDischarge = (TreatmentDischarge)this._SubactionProcedureFlowable.ObjectContext.GetObject(tempTreatmentDischarge.ObjectID, "TreatmentDischarge");
            //    }
            //    else
            //        return;

            //    TTForm frm = TTForm.GetEditForm(treatmentDischarge);
            //    PrapareFormToShow(frm);
            //    if (frm.ShowEdit(this.FindForm(), treatmentDischarge) == DialogResult.OK)
            //        this._SubactionProcedureFlowable.ObjectContext.Save();
            //    else
            //        this._SubactionProcedureFlowable.ObjectContext.RollbackSavePoint(savePointGuid);
            //}
            //catch (Exception ex)
            //{
            //    this._SubactionProcedureFlowable.ObjectContext.RollbackSavePoint(savePointGuid);
            //    InfoBox.Show(ex);
            //}
            //finally
            //{
            //    //objectContext.Dispose();
            //}
        }
        
        public void ShowPatientPrivacyInformation(Patient patient)
        {
            if(patient.IsPatientPrivacy == true)
            {
                //Gönderilen hasta için bir daha gösterme check i işaretlendiyse uyarı ekranı gelmesin diye
                if(!Common.CurrentResource.PrivacyPatientNotShownList.Contains(patient.ObjectID))
                {
                    WarningMessageForm frm = new WarningMessageForm();
                    frm.CurrentPatient = patient;
                    frm.WarningMessage = patient.FullName + " hastası "+ patient.PrivacyEndDate.Value.Date.ToString() +" tarihine kadar gizli hastadır.\r\n\r\nGizlilik Sebebi :\r\n" + patient.PrivacyReason ;
                    InfoBox.Show("frm.ShowDialog(this);");
                }
            }
        }
        
        public void RunCellContentClick(Int32 rowIndex, Pathology pathologyTest, TTVisual.ITTGrid gridProtocolNumbers)
        {
            if (gridProtocolNumbers.CurrentCell == null)
                return;
            
            switch (gridProtocolNumbers.CurrentCell.OwningColumn.Name)
            {
                case "AddSpecial":
                    TTVisual.ITTGridRow row = gridProtocolNumbers.Rows.Add();
                    {
                        PathologySpecialProcedure procedure = (PathologySpecialProcedure)((TTVisual.ITTGridRow)gridProtocolNumbers.Rows[rowIndex]).TTObject;
                        PathologySpecialProcedureDefinition def = (PathologySpecialProcedureDefinition)procedure.ProcedureObject;
                        row.Cells["SubMatPrtNoSuffixNo"].Value = pathologyTest.SubMatPrtNoSuffixNo;
                        row.Cells["SubMatPrtNoString"].Value = pathologyTest.MatPrtNoString + "-" + (pathologyTest.SubMatPrtNoSuffixNo).ToString(); // + "-" + def.Qref;
                    }
                    break;
                case "Print":
                    break;
                default:
                    break;
            }
        }
        
        public void RunMatPrtNoIncrement(Pathology pathologyTest, TTVisual.ITTGrid gridProtocolNumbers)
        {
            TTVisual.ITTGridRow row = gridProtocolNumbers.Rows.Add();
            
            if(pathologyTest.SubMatPrtNoSuffixNo == null)
                pathologyTest.SubMatPrtNoSuffixNo = 1;
            else
                pathologyTest.SubMatPrtNoSuffixNo++;
            
            row.Cells["SubMatPrtNoSuffixNo"].Value = pathologyTest.SubMatPrtNoSuffixNo;
            row.Cells[0].Value = pathologyTest.MatPrtNoString + "-" +  (row.Cells["SubMatPrtNoSuffixNo"].Value).ToString();
        }
        
        public void RunGridProtocolNumbersCellValueChanged(Int32 rowIndex, Pathology pathologyTest, TTVisual.ITTGrid gridProtocolNumbers)
        {
            switch (gridProtocolNumbers.CurrentCell.OwningColumn.Name)
            {
                case "SpecialProcedureDefinition":
                    //ITTGridRow row = this.GridProtocolNumbers.Rows.Add();
                    {
                        PathologySpecialProcedure procedure = (PathologySpecialProcedure)((TTVisual.ITTGridRow)gridProtocolNumbers.Rows[rowIndex]).TTObject;
                        PathologySpecialProcedureDefinition def = (PathologySpecialProcedureDefinition)procedure.ProcedureObject;
                        gridProtocolNumbers.Rows[rowIndex].Cells[0].Value = pathologyTest.MatPrtNoString + "-" + (gridProtocolNumbers.Rows[rowIndex].Cells["SubMatPrtNoSuffixNo"].Value).ToString() + "-" + def.Qref;
                    }
                    break;

                default:
                    break;
            }
        }


        public string GetFullAppointmentDescription(SubActionProcedure subactionProcedure)
        {
            StringBuilder builder = new StringBuilder();
            foreach (Appointment app in SubActionProcedure.GetMyNewAppointments(subactionProcedure.ObjectID))
            {
                builder.Append("Açıklama : " + app.Notes + "\r\n");
                if (app.BreakAppointment == true)
                    builder.Append("Zaman  : Saatsiz Randevu \r\n");
                else
                    builder.Append("Zaman  : " + app.AppDate.Value.ToLongDateString() + " " + app.StartTime.Value.ToShortTimeString() + " - " + app.EndTime.Value.ToShortTimeString() + "\r\n");
                if (app.Resource.ObjectDef.Description == null)
                {
                    builder.Append(app.Resource.ObjectDef.Name.ToString() + " : " + app.Resource.Name + "\r\n");
                }
                else
                {
                    builder.Append(app.Resource.ObjectDef.Description.ToString() + " : " + app.Resource.Name + "\r\n");
                }
                builder.Append(app.ObjectDef.Description + " : " + (app.MasterResource != null ? app.MasterResource.Name : "") + "\r\n");
                builder.Append("Durum  : " + app.CurrentStateDef.ToString() + "\r\n");

                TimeSpan dtDiff = app.AppDate.Value.Subtract(DateTime.Now.Date);
                if (dtDiff.TotalDays > -1)// Randevu aynı günde yada ilerdeyse
                {
                    if (dtDiff.TotalDays == 0)//aynı gündeyse
                    {
                        dtDiff = app.StartTime.Value.TimeOfDay.Subtract(DateTime.Now.TimeOfDay);
                        if (dtDiff.TotalMinutes > -1)// aynı günde ilerde ise
                        {
                            if (dtDiff.TotalMinutes < 60)
                                builder.Append("Zamanlama : Randevu " + Math.Round(dtDiff.TotalMinutes) + " dakika sonra.\r\n");
                            else
                                builder.Append("Zamanlama : Randevu " + Math.Round(dtDiff.TotalHours) + " saat sonra.\r\n");
                        }
                        else
                        {
                            //double nDuration = app.EndTime.Value.Subtract(app.StartTime.Value).TotalHours;
                            //if(nDuration < Math.Abs(dtDiff.TotalHours))
                            if (app.EndTime.Value.TimeOfDay.Subtract(DateTime.Now.TimeOfDay).TotalMinutes > 0)
                                builder.Append("Zamanlama : süresi geçiyor\r\n");
                            else
                                builder.Append("Zamanlama : süresi geçmiş\r\n");
                        }
                    }
                    else
                        builder.Append("Zamanlama : Randevu " + Math.Round(dtDiff.TotalDays) + " gün sonra.\r\n");
                }
                else
                {
                    builder.Append("Zamanlama : süresi geçmiş\r\n");
                }
                builder.Append("Referans No :" + (app.AppointmentID == null ? "" : (app.AppointmentID.Value == null ? "" : app.AppointmentID.Value.ToString())));
                builder.Append("\r\n");
                builder.Append("\r\n");
            }
            return builder.ToString();
        }

        public string GetFullCompletedAppointmentDescription(SubActionProcedure subactionProcedure)
        {
            StringBuilder builder = new StringBuilder();
            foreach (Appointment app in SubActionProcedure.GetMyCompletedAppointments(subactionProcedure.ObjectID))
            {
                builder.Append("Açıklama : " + app.Notes + "\r\n");
                if (app.BreakAppointment == true)
                    builder.Append("Zaman  : Saatsiz Randevu \r\n");
                else
                    builder.Append("Zaman  : " + app.AppDate.Value.ToLongDateString() + " " + app.StartTime.Value.ToShortTimeString() + " - " + app.EndTime.Value.ToShortTimeString() + "\r\n");
                if (app.Resource.ObjectDef.Description == null)
                {
                    builder.Append(app.Resource.ObjectDef.Name + " :" + app.Resource.Name + "\r\n");
                }
                else
                {
                    builder.Append(app.Resource.ObjectDef.Description + " :" + app.Resource.Name + "\r\n");
                }
                builder.Append(app.ObjectDef.Description + " :" + (app.MasterResource != null ? app.MasterResource.Name : "") + "\r\n");
                builder.Append("Durum  :" + app.CurrentStateDef.ToString() + "\r\n");
                builder.Append("Referans No :" + (app.AppointmentID == null ? "" : (app.AppointmentID.Value == null ? "" : app.AppointmentID.Value.ToString())));
                builder.Append("\r\n");
                builder.Append("\r\n");
            }

            foreach (Appointment app in SubActionProcedure.GetMyCancelledAppointments(subactionProcedure.ObjectID))
            {
                builder.Append("Açıklama : " + app.Notes + "\r\n");
                if (app.BreakAppointment == true)
                    builder.Append("Zaman  : Saatsiz Randevu \r\n");
                else
                    builder.Append("Zaman  : " + app.AppDate.Value.ToLongDateString() + " " + app.StartTime.Value.ToShortTimeString() + " - " + app.EndTime.Value.ToShortTimeString() + "\r\n");
                if (app.Resource.ObjectDef.Description == null)
                {
                    builder.Append(app.Resource.ObjectDef.Name + " :" + app.Resource.Name + "\r\n");
                }
                else
                {
                    builder.Append(app.Resource.ObjectDef.Description + " :" + app.Resource.Name + "\r\n");
                }
                builder.Append(app.ObjectDef.Description + " :" + (app.MasterResource != null ? app.MasterResource.Name : "") + "\r\n");
                builder.Append("Durum  :" + app.CurrentStateDef.ToString() + "\r\n");
                builder.Append("Referans No :" + (app.AppointmentID == null ? "" : (app.AppointmentID.Value == null ? "" : app.AppointmentID.Value.ToString())) + "\r\n");
                builder.Append("İptal Sebebi :" + subactionProcedure.ReasonOfCancel);
                builder.Append("\r\n");
                builder.Append("\r\n");
            }
            return builder.ToString();
        }



        #endregion SubactionProcedureFlowableForm_ClientSideMethods
    }
}