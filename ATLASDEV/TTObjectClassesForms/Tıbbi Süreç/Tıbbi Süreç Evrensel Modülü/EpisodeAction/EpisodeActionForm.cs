
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
    public partial class EpisodeActionForm : ActionForm
    {
        protected override void PreScript()
        {
            #region EpisodeActionForm_PreScript
            base.PreScript();
            #endregion EpisodeActionForm_PreScript

        }

        //        protected override void ClientSidePreScript()
        //        {
        //#region EpisodeActionForm_ClientSidePreScript
        //    base.ClientSidePreScript();
        //            this.ShowPatientPrivacyInformation(this._EpisodeAction.Episode.Patient);
        //            this.ShowImportantMedicalInformation(this._EpisodeAction);
        //            PrepareFormTitle();

        //            //            if(this._EpisodeAction.CurrentStateDef==null || this._EpisodeAction.CurrentStateDef.IsEntry==true)
        //            //            {
        //            //                this._EpisodeAction.BeforeSetEpisode(this._EpisodeAction.Episode);
        //            //            }
        //            //IfNulların metodları hep bu sıra ile çalışmalı
        //            this.IfNullSelectFromResource();
        //            this.IfNullSelectMasterResource();
        //            this.IfNullSelectProcedureSpeciality();

        //            this.IfDiagnosisIsRequired();
        //            EpisodeAction.CheckPaid(this._EpisodeAction);

        //            DropReportsOfSecurePatient();
        //#endregion EpisodeActionForm_ClientSidePreScript

        //        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
            #region EpisodeActionForm_PostScript
            base.PostScript(transDef);

            // RunSUTRules();
            #endregion EpisodeActionForm_PostScript

        }

        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
            #region EpisodeActionForm_ClientSidePostScript
            base.ClientSidePostScript(transDef);
            if (!ValidateSutRules(this))
            {
                throw new TTUtils.TTException("Sut kuralları doğrulaması başarısız oldu");//ApplicationException
            }
            #endregion EpisodeActionForm_ClientSidePostScript

        }

        #region EpisodeActionForm_Methods
        private void RunSUTRules()
        {
            if (TTObjectClasses.SystemParameter.IsMedulaIntegration)
            {
                List<RuleBase.RuleResult> results = new List<RuleBase.RuleResult>();
                if (_EpisodeAction.SubactionProcedures.Count > 0)
                {
                    foreach (SubActionProcedure subActionProcedure in _EpisodeAction.SubactionProcedures)
                    {
                        if (((ITTObject)subActionProcedure).IsNew)
                        {
                            DateTime actionDate;
                            if (subActionProcedure.ActionDate.HasValue)
                                actionDate = subActionProcedure.ActionDate.Value;
                            else
                                actionDate = TTObjectDefManager.ServerTime;
                            results.AddRange(subActionProcedure.ProcedureObject.RunRules(actionDate, (ISUTInstance)subActionProcedure));
                        }
                    }
                }

                if (_EpisodeAction is EpisodeActionWithDiagnosis && ((EpisodeActionWithDiagnosis)_EpisodeAction).Diagnosis.Count > 0)
                {
                    foreach (DiagnosisGrid diagnosisGrid in ((EpisodeActionWithDiagnosis)_EpisodeAction).Diagnosis)
                    {

                        if (((ITTObject)diagnosisGrid).IsNew)
                        {
                            DateTime actionDate;
                            if (diagnosisGrid.DiagnoseDate.HasValue)
                                actionDate = diagnosisGrid.DiagnoseDate.Value;
                            else
                                actionDate = TTObjectDefManager.ServerTime;
                            results.AddRange(diagnosisGrid.Diagnose.RunRules(actionDate, (ISUTInstance)diagnosisGrid));
                        }
                    }
                }

                if (results.Count > 0)
                    ShowResults(results);
            }
        }

        private void ShowResults(List<RuleBase.RuleResult> results)
        {
            List<RuleBase.RuleResult> warningRuleResults = new List<RuleBase.RuleResult>();
            List<RuleBase.RuleResult> errorRuleResults = new List<RuleBase.RuleResult>();
            foreach (RuleBase.RuleResult ruleResult in results)
            {
                if (ruleResult.IsWarningOnly)
                    warningRuleResults.Add(ruleResult);
                else
                    errorRuleResults.Add(ruleResult);
            }

            if (warningRuleResults.Count > 0)
            {
                string result = string.Empty;
                int i = 1;
                foreach (RuleBase.RuleResult ruleResult in warningRuleResults)
                {
                    result += ruleResult.RuleDescription;
                    if (i != results.Count)
                        result += "\r\n";
                    i++;
                }
                InfoBox.Alert("Bilgilendirme Mesajıdır.\r\n\r\n" + result, MessageIconEnum.InformationMessage);
            }

            if (errorRuleResults.Count > 0)
            {
                string result = string.Empty;
                int i = 1;
                foreach (RuleBase.RuleResult ruleResult in errorRuleResults)
                {
                    result += ruleResult.RuleDescription;
                    if (i != results.Count)
                        result += "\r\n";
                    i++;
                }
                string[] hataParamList = new string[] { result };
                throw new TTUtils.TTException(SystemMessage.GetMessageV3(143, hataParamList));
                //throw new TTException("Aşağıdaki sebeplerden dolayı girilmesi uygun olmayan durum oluştuğundan işleme devam edemezsiniz.\r\n\r\n" + result);
            }
        }


        protected virtual void PrepareFormTitle()
        {
            if (this._EpisodeAction.Episode == null)
            {
                throw new TTUtils.TTException(SystemMessage.GetMessage(144));
                //throw new Exception("Alınan bir hatadan dolayı işlemin vakası belirlenememiştir.İşleme devam edilemez");
            }
            //TODO FormTitle!
            //if (this._EpisodeAction.Episode.Patient != null)
            //    this.Text += " - " + this._EpisodeAction.Episode.Patient.FullName.ToUpper();
        }




        protected virtual void IfDiagnosisIsRequired()
        {
            EpisodeAction.DiagnosisIsRequired(this._EpisodeAction);
        }



        //NOT TODO  yeni yapıda Authorize user seçimine ihtiyaç kalmadı
        //public void DrawSetAuthorizedUserButton(string buttonTitle)
        //{
        //    this.AddManualStepButton(buttonTitle, new EventHandler(btnSetAuthorizedUser_Click));
        //    //            const int STATE_BUTTON_SPACE = 3;
        //    //            const int STATE_BUTTON_MAXWIDTH = 150;
        //    //            int i = this.pnlButtons.Controls.Count-1;
        //    //            int x = this.pnlButtons.Controls[i].Location.X + this.pnlButtons.Controls[i].Size.Width+STATE_BUTTON_SPACE;
        //    //            Graphics g = Graphics.FromHwnd(Handle);
        //    //            btnSetAuthorizedUser = new Button();
        //    //            btnSetAuthorizedUser.Text = buttonTitle;
        //    //            SizeF szText = g.MeasureString(buttonTitle, btnSetAuthorizedUser.Font, STATE_BUTTON_MAXWIDTH);
        //    //            btnSetAuthorizedUser.Size = new Size((int) (szText.Width*1.5), cmdOK.Height);
        //    //            btnSetAuthorizedUser.Location = new Point(x,cmdOK.Top);
        //    //            btnSetAuthorizedUser.Click += new EventHandler(btnSetAuthorizedUser_Click);
        //    //            pnlButtons.Controls.Add(btnSetAuthorizedUser);
        //}

        //void btnSetAuthorizedUser_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (this._EpisodeAction.CurrentStateDef.AllAttributes.ContainsKey("AddAuthorizedUserButton"))
        //        {
        //            //UserType parametresi numeric olmalı olmazsa çatlar
        //            int i = Convert.ToInt32(this._EpisodeAction.CurrentStateDef.AllAttributes["AddAuthorizedUserButton"].Parameters["UserType"].Value.ToString());
        //            UserTypeEnum userTypeEnum = Common.GetUserTypeEnumByValue(i);

        //            this.SetAuthorizedUserBySelecting(this._EpisodeAction.MasterResource, userTypeEnum, false);
        //            if (this._EpisodeAction.CurrentStateDef.AllAttributes["AddAuthorizedUserButton"].Parameters["ToStateDefID"] != null)
        //            {
        //                if (this._EpisodeAction.CurrentStateDef.AllAttributes["AddAuthorizedUserButton"].Parameters["ToStateDefID"].Value != null)
        //                {
        //                    Guid stateDefID = new Guid(this._EpisodeAction.CurrentStateDef.AllAttributes["AddAuthorizedUserButton"].Parameters["ToStateDefID"].Value.ToString());
        //                    TTObjectStateTransitionDef transDef = (TTObjectStateTransitionDef)this._EpisodeAction.CurrentStateDef.FindOutoingTransitionDefFromStateDefID(stateDefID);
        //                    if (DoContextUpdate(transDef))
        //                        this.DialogResult = DialogResult.OK;

        //                }
        //            }
        //        }
        //    }
        //    catch (Exception Ex)
        //    {
        //        InfoBox.Alert(Ex);
        //    }
        //}

        //protected override void OnShown(EventArgs e)
        //{
        //    base.OnShown(e);

        //    if (this._EpisodeAction.CurrentStateDef != null && this._EpisodeAction.CurrentStateDef.AllAttributes.ContainsKey("AddAuthorizedUserButton"))
        //    {
        //        //UserType parametresi numeric olmalı olmazsa çatlar
        //        int i = Convert.ToInt32(this._EpisodeAction.CurrentStateDef.AllAttributes["AddAuthorizedUserButton"].Parameters["UserType"].Value.ToString());
        //        TTDataDictionary.EnumValueDef userTypeEnumValueDef = Common.GetUserTypeEnumValueDefByValue(i);
        //        this.DrawSetAuthorizedUserButton(userTypeEnumValueDef.DisplayText + " Seç");
        //    }

        //}
    


        /// <summary>
        /// BaseTreatmentMaterial tipinde bir colu olan formda verilen TreatmentMaterialGridine ait Material kolonunun ListFilterını set eder.
        /// </summary>
        /// <param name="treatmentMaterialDef"></param>
        /// <param name="treatmentMaterialMaterialColumn"></param>

        public void SetTreatmentMaterialListFilter(TTObjectDef treatmentMaterialDef, ITTGridColumn treatmentMaterialMaterialColumn)
        {
            ((ITTListBoxColumn)treatmentMaterialMaterialColumn).ListFilterExpression = this._EpisodeAction.GetTreatmentMaterialListFilter(treatmentMaterialDef);
        }


        public Store GetStore(TTObjectDef treatmentMaterialDef)
        {
           return  this._EpisodeAction.GetStore(treatmentMaterialDef);

        }

        public virtual void SetProcedureDoctorAsCurrentResource()
        {
            if (this._EpisodeAction.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
            {
                if (this._EpisodeAction.ProcedureDoctor == null && Common.CurrentResource.TakesPerformanceScore == true)
                {
                    this._EpisodeAction.ProcedureDoctor = Common.CurrentResource;
                }

            }
        }


        public void SetFormReadOnly()
        {
            foreach (ITTControlBase control in this.pnlControls.Controls)
            {
                if (!(control is ITTTabControl))
                {
                    control.Enabled = false;
                }
            }
        }

        protected virtual void ShowAction_ObjectUpdated(TTObject ttObject, ref bool contextSaved)
        {
            ttObject.ObjectContext.Save();
            contextSaved = true;
        }

        protected void PrapareFormToShow(TTForm frm)
        {
            //TODO Template!
            //frm.ObjectUpdated += new ObjectUpdatedDelegate(ShowAction_ObjectUpdated);
            //frm.GetTemplates = this.GetTemplates;
            //frm.SaveTemplate = this.SaveTemplate;
            //frm.TemplateSelected = this.TemplateSelected;
        }

        public void DropReportsOfSecurePatient()
        {
            if (Common.CurrentResource.IsPatientSecureAndHasNoRightOfUser((IEpisodeActionPermission)this._EpisodeAction))
            {
                foreach (TTObjectStateReportDef stateReport in this._EpisodeAction.CurrentStateDef.ReportDefs)// tüm StateReport'lar Drop edilir
                {
                    this.DropCurrentStateReport(stateReport.ReportDefID);
                }
            }
        }

        // her Yere yeni exe gittiğinde açılsın vib personelin raporlarını kimse bastıramasın diye
        protected virtual bool CheckObjectReportToPrint(TTObjectReportDef objectReportDef)
        {
            if (Common.CurrentResource.IsPatientSecureAndHasNoRightOfUser((IEpisodeActionPermission)this._EpisodeAction))
            {
                return false;
            }
            return true;
        }

        public  void SetDirectPurchaseListFilter(ITTGridColumn directPurchaseDetailColumn)
        {
            ((ITTListBoxColumn)directPurchaseDetailColumn).ListFilterExpression = this._EpisodeAction.GetDirectPurchaseListFilter();
        }

        public void CompleteMyExaminationQueueItems()
        {
            IList<ExaminationQueueItem> itemList = ExaminationQueueItem.GetByEpisodeAction(this._EpisodeAction.ObjectContext, this._EpisodeAction.ObjectID);
            if (itemList.Count > 0)
            {
                foreach (ExaminationQueueItem item in itemList)
                {
                    if (item.CurrentStateDefID != ExaminationQueueItem.States.Completed && item.CurrentStateDefID != ExaminationQueueItem.States.Cancelled)
                    {
                        item.CurrentStateDefID = ExaminationQueueItem.States.Completed;
                        if (item.EpisodeAction.ProcedureDoctor != null)
                            item.CompletedBy = item.EpisodeAction.ProcedureDoctor;
                    }
                }
            }
        }

        public void CheckDiagnosisOzelDurums()
        {
            if (this._EpisodeAction is IDiagnosisOzelDurum)
            {
                IDiagnosisOzelDurum diagnosisOzelDurumEA = (IDiagnosisOzelDurum)this._EpisodeAction;
                DiagnosisDefinition selectedDiagnosisDef = null;
                List<OzelDurum> neededOzelDurumList = new List<OzelDurum>();
                bool hasError = false;
                if (SubEpisode.IsSGKSubEpisode(this._EpisodeAction.SubEpisode))
                {
                    foreach (DiagnosisGrid diagnosis in diagnosisOzelDurumEA.GetDiagnosis())
                    {
                        foreach (DiagnosisDefOzelDurum ozelDurumGrid in diagnosis.Diagnose.DiagnosisDefOzelDurumlar)
                        {
                            selectedDiagnosisDef = diagnosis.Diagnose;
                            neededOzelDurumList.Add(ozelDurumGrid.OzelDurum);
                        }

                        if (neededOzelDurumList.Count == 0)
                            continue;
                        else
                        {
                            if (diagnosisOzelDurumEA.GetOzelDurum() == null)
                                hasError = true;
                            else if (neededOzelDurumList.Contains(diagnosisOzelDurumEA.GetOzelDurum()) == false)
                                hasError = true;
                        }

                        if (hasError)
                            break;
                    }


                    string neededOzelDurums = string.Empty;
                    if (hasError)
                    {
                        foreach (OzelDurum ozelDurum in neededOzelDurumList)
                            neededOzelDurums += "\r\n" + ozelDurum.ozelDurumKodu + " - " + ozelDurum.ozelDurumAdi;

                        throw new TTUtils.TTException("'" + selectedDiagnosisDef.Code + "-" + selectedDiagnosisDef.Name + "' tanısı girildiğinde aşağıdaki medula özel durumlarından birisinin seçilmesi zorunludur!" + neededOzelDurums);
                    }
                }
            }
        }

        public void ApplyProcedure(StoneBreakUpProcedure stoneBreakUpProcedure)
        {
            if (stoneBreakUpProcedure.ProcedureDate == null)// ertelemelerde ilk hesaplanan değer geçerli olur
            {
                //  SetProcedureObject(Common.RecTime());
                stoneBreakUpProcedure.ProcedureDate = Common.RecTime();
            }
        }


        //EpisodeAction'a taşındı
        //public void CheckForDiagnosys()
        //{
        //    if (this._EpisodeAction.Episode.Diagnosis.Count == 0)
        //        throw new TTUtils.TTException("Bu işlem epizotunda hiçbir tanı bulunmayan hastalara başlatılamaz!");
        //}

        #endregion EpisodeActionForm_Methods




        #region EpisodeActionForm_ClientSideMethods
        protected virtual void IfNullSelectFromResource()
        {
            if (this._EpisodeAction.FromResource == null)
            {
                if (Common.CurrentResource != null)
                {
                    if (this._EpisodeAction.Episode != null)
                    {
                        Episode episode = this._EpisodeAction.Episode;
                        // this._EpisodeAction.SetFromResource(episode);

                        if (this._EpisodeAction.FromResource == null)
                        {
                            if (EpisodeAction.GetAvailableUserResourcesByAllocation(episode, this._EpisodeAction).Count < 1)
                            {
                                throw new TTUtils.TTException(SystemMessage.GetMessage(145));
                                //throw new Exception("Bağlı olduğunuz birimler, bu vakada  bu işlem yapmak için uygun değildir.");
                            }
                            else
                            {

                                MultiSelectForm MSItem = new MultiSelectForm();
                                foreach (ResSection resSection in EpisodeAction.GetAvailableUserResourcesByAllocation(episode, this._EpisodeAction))
                                {
                                    if (!MSItem.IsItemExists(resSection.ObjectID.ToString()))
                                        MSItem.AddMSItem(resSection.Name, resSection.ObjectID.ToString(), resSection);
                                }
                                String key = MSItem.GetMSItem(this, "Havale Eden Birim Seçiniz", false, true, false, false, false, true);
                                if (!string.IsNullOrEmpty(key))
                                    this._EpisodeAction.FromResource = (ResSection)MSItem.MSSelectedItemObject;
                                else
                                    throw new TTUtils.TTException(SystemMessage.GetMessage(146));
                                // throw new Exception("Havale eden birim seçilmeden işleme devam edemezsiniz.");
                            }
                        }
                    }
                    else
                    {
                        throw new TTUtils.TTException(SystemMessage.GetMessage(147));
                        //throw new Exception("İşlemin bağlı olduğu vaka bulunamadı.İşleme devam edilemez.");
                    }
                }
                else
                {
                    throw new TTUtils.TTException(SystemMessage.GetMessage(148));
                    //throw new Exception("Sistem kullanıcısı bulunamadı.İşleme devam edilemez.");
                }
            }
        }
        protected virtual void IfNullSelectMasterResource()
        {
            if (this._EpisodeAction.MasterResource == null)
            {
                if (Common.CurrentResource != null)
                {
                    if (this._EpisodeAction.Episode != null)
                    {
                        Episode episode = this._EpisodeAction.Episode;
                        // this._EpisodeAction.SetMasterResource(episode, false);

                        if (this._EpisodeAction.MasterResource == null)
                        {

                            ResSection masterResource = this.GetSelectedAcionDefualtMasterResource(this._EpisodeAction.ObjectContext, this._EpisodeAction.ActionType, "İşlemin Yapılacağı Birimi Seçiniz");
                            if (masterResource != null)
                            {
                                this._EpisodeAction.MasterResource = masterResource;
                                return;
                            }

                        }

                        if (this._EpisodeAction.FromResource != null)
                        {
                            ArrayList limitedMasterResourceTypeList = EpisodeAction.LimitedMasterResourceTypes(this._EpisodeAction);
                            if (limitedMasterResourceTypeList.Count < 1 || limitedMasterResourceTypeList.Contains(this._EpisodeAction.FromResource.ObjectDef.Name))
                            {
                                this._EpisodeAction.MasterResource = this._EpisodeAction.FromResource;
                                return;
                            }
                            else
                            {
                                string[] hataParamList = new string[] { this._EpisodeAction.FromResource.Name };
                                throw new TTUtils.TTException(SystemMessage.GetMessageV3(149, hataParamList));
                                //throw new Exception("Bağlı olduğunuz " + this._EpisodeAction.FromResource + " birimi bu işlem için uygun değildir");
                            }
                        }
                        else
                        {
                            throw new TTUtils.TTException(SystemMessage.GetMessage(145));
                            // throw new Exception("Bağlı olduğunuz birimler, bu vakada  bu işlem yapmak için uygun değildir.");
                        }
                    }
                    else
                    {
                        throw new TTUtils.TTException(SystemMessage.GetMessage(147));
                        //throw new Exception("İşlemin bağlı olduğu vaka bulunamadı.İşleme devam edilemez.");
                    }
                }
                else
                {
                    throw new TTUtils.TTException(SystemMessage.GetMessage(148));
                    //throw new Exception("Sistem kullanıcısı bulunamadı.İşleme devam edilemez.");
                }
            }
        }

        public virtual void IfNullSelectProcedureSpeciality()
        {
            if (Common.IsAttributeExists(typeof(NotRequiredProcedureSpecialityAttribute), (TTObject)this._EpisodeAction) == false)
            {
                if (this._EpisodeAction.ProcedureSpeciality == null)
                {
                    if (this._EpisodeAction.Episode != null)
                    {
                        ResSection resource = null;
                        string title = "";
                        if (this._EpisodeAction.SetProcedureSpecialtyBy().ToUpper() == "MASTERRESOURCE")
                        {
                            resource = this._EpisodeAction.MasterResource;
                            title = "İşlemin Yapılacağı Uzmanlık Dalını";
                        }
                        else if (this._EpisodeAction.SetProcedureSpecialtyBy().ToUpper() == "FROMRESOURCE")
                        {
                            resource = this._EpisodeAction.FromResource;
                            title = "İsteğin Yapıldığı Uzmanlık Dalını";
                        }

                        if (resource != null)
                        {
                            if (resource.ResourceSpecialities.Count == 1)
                            {
                                this._EpisodeAction.ProcedureSpeciality = resource.ResourceSpecialities[0].Speciality;
                            }
                            else if (resource.ResourceSpecialities.Count > 1)
                            {
                                MultiSelectForm MSItem = new MultiSelectForm();
                                bool getTime = false;
                                while (getTime == false)
                                {
                                    foreach (ResourceSpecialityGrid specialityGrid in resource.ResourceSpecialities)
                                    {
                                        //if(!MSItem.Contains (specialityGrid.Speciality.Name))
                                        if (!MSItem.IsItemExists(specialityGrid.Speciality.ObjectID.ToString()))
                                            MSItem.AddMSItem(specialityGrid.Speciality.Name, specialityGrid.Speciality.ObjectID.ToString(), specialityGrid.Speciality);

                                    }
                                    title = title + " seçiniz";
                                    String key = MSItem.GetMSItem(this, title, false, true, false, false, false, true);
                                    if (!string.IsNullOrEmpty(key))
                                    {
                                        this._EpisodeAction.ProcedureSpeciality = (SpecialityDefinition)MSItem.MSSelectedItemObject;   // selectedspecialityList.Values[0];
                                        getTime = true;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        throw new TTUtils.TTException(SystemMessage.GetMessage(147));
                        //throw new Exception("İşlemin bağlı olduğu vaka bulunamadı.İşleme devam edilemez.");
                    }
                }
            }
        }



        public void ShowImportantMedicalInformation(EpisodeAction ea)
        {
            if (!(ea is ImportantMedicalInformation))
            {
                if (ea.Episode.Patient.ImportantMedicalInformation != null)
                {
                    if (ea.Episode.Patient.ImportantMedicalInformation.WarnAllMedicalPersonnel == true)
                    {
                        ImportantMedicalInformation importantMedicalInformation = ea.Episode.Patient.ImportantMedicalInformation;
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
        }



        public ResSection GetSelectedAcionDefualtMasterResource(TTObjectContext context, ActionTypeEnum actionType, string msItemTitle)
        {
            List<ResSection> actionDMRList = EpisodeAction.AcionDefualtMasterResources(context, actionType, this._EpisodeAction);
            if (actionDMRList.Count > 0)
            {
                MultiSelectForm mSItem = new MultiSelectForm();
                foreach (ResSection resSection in actionDMRList)
                {
                    if (!mSItem.IsItemExists(resSection.ObjectID.ToString()))
                        mSItem.AddMSItem(resSection.Name.ToString(), resSection.ObjectID.ToString(), resSection);
                }

                string key = mSItem.GetMSItem(null, msItemTitle, true, true, false, false, true, true);
                if (!string.IsNullOrEmpty(key))
                {
                    return (ResSection)mSItem.MSSelectedItemObject;
                }
                else
                {
                    throw new TTUtils.TTException(SystemMessage.GetMessage(150));
                    //throw new Exception("İşlemin yapılacağı birim seçilmeden işleme devam edemezsiniz.");
                }

            }
            return null;

        }

        public void StartPatientAdmissionCorrection()
        {

        }

        public void SetPreDiagnosisAsSecDiagnosis(EpisodeActionWithDiagnosis episodeActionWithDiagnosis)
        {
            string diagnoseName = String.Empty;
            bool secdiagnosisYok = true;
            List<DiagnosisGrid> prediagnosisGridList = new List<DiagnosisGrid>();
            if (episodeActionWithDiagnosis.Diagnosis.Count <= 0)
            {
                foreach (DiagnosisGrid diagnose in episodeActionWithDiagnosis.Diagnosis)
                {
                    if (diagnose.DiagnosisType == DiagnosisTypeEnum.Seconder)
                    {
                        secdiagnosisYok = false;
                        break;
                    }
                    else
                    {
                        prediagnosisGridList.Add(diagnose);
                        diagnoseName += diagnose.Diagnose.Code + " " + diagnose.Diagnose.Name + "\r\n";
                    }

                }
                if (secdiagnosisYok && !String.IsNullOrEmpty(diagnoseName))
                {
                    string[] hataParamList = new string[] { diagnoseName };
                    String massage = SystemMessage.GetMessageV3(152, hataParamList);
                    // if (ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Tanı Girişi", "Hiç kesin tanı girmediniz.\r\nGirdiğiniz ön tanıların kesinleştirilmesini ister misiniz? \r\nGirilen Ön Tanılar:\r\n" + diagnoseName) == "E")
                    if (ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Tanı Girişi", massage) == "E")
                    {
                        foreach (DiagnosisGrid preDiagnose in prediagnosisGridList)
                        {
                            DiagnosisGrid secDiagnose = new DiagnosisGrid(episodeActionWithDiagnosis.ObjectContext);
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
                    else
                    {
                        throw new TTUtils.TTException(SystemMessage.GetMessage(153));
                        //throw new Exception("Tanı giriniz.");
                    }
                }
            }
        }


        public bool? GetPatientApprovalForm()
        {
            //            rtfForm.GetTemplates = this.GetTemplates;
            //            rtfForm.SaveTemplate = this.SaveTemplate;
            //            rtfForm.TemplateSelected = this.TemplateSelected;
            //return rtfForm.PrintWithTemplateGroupName("Onam Formu","PatientApprovalForm");
            //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
            //PatientApprovalForm frm = new PatientApprovalForm();
            //DialogResult dialogResult = frm.ShowEdit(this.FindForm(), _EpisodeAction, true);
            //if (dialogResult != DialogResult.OK)
            //{
            //    throw new TTUtils.TTException(SystemMessage.GetMessage(80));
            //    //throw new Exception("İşlemden Vazgeçildi");
            //    //return false;
            //}
            return true;
        }

        public bool? GetPatientApprovalForm(Boolean allowToCancel)
        {
            //            rtfForm.GetTemplates = this.GetTemplates;
            //            rtfForm.SaveTemplate = this.SaveTemplate;
            //            rtfForm.TemplateSelected = this.TemplateSelected;
            //return rtfForm.PrintWithTemplateGroupName("Onam Formu","PatientApprovalForm");
            //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
            //PatientApprovalForm frm = new PatientApprovalForm();
            //DialogResult dialogResult = frm.ShowEdit(this.FindForm(), _EpisodeAction, true);
            //if (dialogResult != DialogResult.OK)
            //{
            //    if (!allowToCancel)
            //    {
            //        throw new TTUtils.TTException(SystemMessage.GetMessage(80));
            //        //throw new Exception("İşlemden Vazgeçildi");
            //    }
            //    return false;
            //}
            return true;
        }
        public bool? GetIfPatientApprovalFormIsGiven(bool? isGiven)
        {
            if (isGiven != true)
            {
                //string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Form Seç,&Verildi,&Verilmedi", "S,V,Vd", "Uyarı", "Aydınlatılmış Onam Formu verildi mi?", "Aydınlatılmış Onam Formu hastaya verilmeden ise işleme devam edilemez.");
                string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Form Seç,&Verildi,&Verilmedi", "S,V,Vd", "Uyarı", "Aydınlatılmış Onam Formu verildi mi?", SystemMessage.GetMessage(154));
                if (result == "V")
                    return true;
                else if (result == "Vd")
                {
                    throw new TTUtils.TTException(SystemMessage.GetMessage(154));
                    //throw new Exception("Hastaya Aydınlatılmış Onam Formu verilmeden ise işleme devam edilemez. ");
                }
                else
                {
                    return GetPatientApprovalForm();
                }
            }
            return isGiven;
        }





        /// <summary>
        /// Yeni MTS başlatır.
        /// </summary>
        public void CreateNewTreatmentDischarge()
        {
            //SaveContextForNewDiagnose();
            TreatmentDischarge treatmentDischarge;
            TreatmentDischarge tempTreatmentDischarge;
            //Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
            //TTObjectContext objectContext = new TTObjectContext(false);
            //Guid savePointGuid = objectContext.BeginSavePoint();
            Guid savePointGuid = this._EpisodeAction.ObjectContext.BeginSavePoint();
            try
            {
                if (this._EpisodeAction is InPatientTreatmentClinicApplication )
                {
                    tempTreatmentDischarge = ((InPatientTreatmentClinicApplication)this._EpisodeAction).TreatmentDischarge;
                    if (tempTreatmentDischarge == null)
                        treatmentDischarge = new TreatmentDischarge(this._EpisodeAction);
                    //else
                    //    treatmentDischarge = (TreatmentDischarge)this._EpisodeAction.ObjectContext.GetObject(tempTreatmentDischarge.ObjectID, "TreatmentDischarge");
                }
                else
                    return;
                //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
                //TTForm frm = TTForm.GetEditForm(treatmentDischarge);
                //PrapareFormToShow(frm);
                //if (frm.ShowEdit(this.FindForm(), treatmentDischarge) == DialogResult.OK)
                //    this._EpisodeAction.ObjectContext.Save();
                //else
                //    this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
                //objectContext.Save();
            }
            catch (Exception ex)
            {
                this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
                //objectContext.RollbackSavePoint(savePointGuid);
                InfoBox.Show(ex);
            }
            finally
            {
                //objectContext.Dispose();
            }
        }


        /// <summary>
        /// Tamamlanmış MTS kaydeder.
        /// </summary>
        //public void CreateCompletedTreatmentDischarge(Guid stateDefID, Dictionary<string, object> objList)
        //{
        //    TTObjectContext context = _EpisodeAction.ObjectContext;
        //    TreatmentDischarge td = new TreatmentDischarge(_EpisodeAction);

        //    foreach (KeyValuePair<string, object> kp in objList)
        //    {
        //        switch (kp.Key)
        //        {
        //            case "Conclusion":
        //                td.Conclusion = (string)kp.Value;
        //                break;
        //            case "DischargeType":
        //                td.DischargeType = (DischargeTypeEnum)kp.Value;
        //                break;

        //            case "HospitalSendingTo":
        //                td.HospitalSendingTo = (ResSection)kp.Value;
        //                break;
        //            case "DispatchedSpeciality":
        //                td.DispatchedSpeciality = (SpecialityDefinition)kp.Value;
        //                break;
        //        }
        //    }

        //    if (_EpisodeAction.ProcedureDoctor != null)
        //        td.ProcedureDoctor = _EpisodeAction.ProcedureDoctor;

        //    td.CurrentStateDefID = TreatmentDischarge.States.New;
        //    td.Update();

        //    td.CurrentStateDefID = stateDefID;
        //    context.Save();

        //    Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
        //    TTReportTool.PropertyCache<object> newParameterItem = new TTReportTool.PropertyCache<object>();
        //    newParameterItem.Add("Value", td.ObjectID.ToString(), "T", "TTOBJECTID");
        //    parameters.Add("TTOBJECTID", newParameterItem);

        //    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_TreatmentDischargeReport), true, 1, parameters);
        //}


        /// <summary>
        /// Yeni Anestezi Konsultasyon isteği başlatır.
        /// </summary>
        public void CreateNewAnesthesiaConsultation()
        {
            //SaveContextForNewDiagnose();
            TTObjectClasses.AnesthesiaConsultation consultation;
            //Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
            //TTObjectContext objectContext = new TTObjectContext(false);
            Guid savePointGuid = this._EpisodeAction.ObjectContext.BeginSavePoint();
            try
            {
                consultation = new TTObjectClasses.AnesthesiaConsultation(this._EpisodeAction.ObjectContext, this._EpisodeAction);
                //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
                //TTForm frm = TTForm.GetEditForm(consultation);
                //this.PrapareFormToShow(frm);
                //if (frm.ShowEdit(this.FindForm(), consultation) == DialogResult.OK)
                //    this._EpisodeAction.ObjectContext.Save();
                //else
                //    this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
            }
            catch (Exception ex)
            {
                this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
                InfoBox.Show(ex);
            }
            finally
            {
                //objectContext.Dispose();
            }
        }

        /// <summary>
        /// Yeni Konsultasyon isteği başlatır.
        /// </summary>
        public void CreateNewConsultationRequest()
        {
            //            MultiSelectForm pForm = new MultiSelectForm();
            //            pForm.AddMSItem("Normal Konsültasyon", "ConsultationRequest");
            //            pForm.AddMSItem("Diş Konsültasyonu", "DentalConsultationRequest");
            //            string consultationType = pForm.GetMSItem(this, "Konsültasyon Tipini Seçiniz");
            //            pForm.ClearMSItems();
            //            if(consultationType == "ConsultationRequest")
            CreateNewNormalConsultationRequest();
            //            else if (consultationType == "DentalConsultationRequest")
            //                CreateNewDentalConsultationRequest();
            //            else
            //            {
            //                InfoBox.Show("Konsültasyon isteğinden vazgeçildi.");
            //                return;
            //            }
            var a = 1;
        }

        /// <summary>
        /// Yeni Konsultasyon isteği başlatır.
        /// </summary>
        public void CreateNewNormalConsultationRequest()
        {
            //SaveContextForNewDiagnose();
            Consultation consultationRequest;
            //Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
            //TTObjectContext objectContext = new TTObjectContext(false);
            Guid savePointGuid = this._EpisodeAction.ObjectContext.BeginSavePoint();
            try
            {
                consultationRequest = new Consultation(this._EpisodeAction.ObjectContext, this._EpisodeAction);
                //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
                //TTForm frm = TTForm.GetEditForm(consultationRequest);
                //this.PrapareFormToShow(frm);
                //if (frm.ShowEdit(this.FindForm(), consultationRequest) == DialogResult.OK)
                //    this._EpisodeAction.ObjectContext.Save();
                //else
                //    this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
            }
            catch (Exception ex)
            {
                this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
                InfoBox.Show(ex);
            }
            finally
            {
                //objectContext.Dispose();
            }
        }

        /// <summary>
        /// Yeni Diş Konsultasyon isteği başlatır.
        /// </summary>
        public void CreateNewDentalConsultationRequest()
        {
            ////SaveContextForNewDiagnose();
            //DentalConsultationRequest dentalConsultationRequest;
            ////Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
            ////TTObjectContext objectContext = new TTObjectContext(false);
            //Guid savePointGuid = this._EpisodeAction.ObjectContext.BeginSavePoint();
            //try
            //{
            //    dentalConsultationRequest = new DentalConsultationRequest(this._EpisodeAction.ObjectContext, this._EpisodeAction);
            //    //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
            //    //TTForm frm = TTForm.GetEditForm(dentalConsultationRequest);
            //    //this.PrapareFormToShow(frm);
            //    //if (frm.ShowEdit(this.FindForm(), dentalConsultationRequest) == DialogResult.OK)
            //    //    this._EpisodeAction.ObjectContext.Save();
            //    //else
            //    //    this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
            //}
            //catch (Exception ex)
            //{
            //    this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
            //    InfoBox.Show(ex);
            //}
            var a = 1;
        }

        /// <summary>
        /// Yeni Fizyotrapi isteği başlatır.
        /// </summary>
        public void CreateNewPhysiotherapyRequest()
        {
            //SaveContextForNewDiagnose();
            PhysiotherapyRequest physiotherapyRequest;
            //Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
            //TTObjectContext objectContext = new TTObjectContext(false);
            Guid savePointGuid = this._EpisodeAction.ObjectContext.BeginSavePoint();
            try
            {
                physiotherapyRequest = new PhysiotherapyRequest(this._EpisodeAction.ObjectContext, this._EpisodeAction);
                //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
                //TTForm frm = TTForm.GetEditForm(physiotherapyRequest);
                //this.PrapareFormToShow(frm);
                //if (frm.ShowEdit(this.FindForm(), physiotherapyRequest) == DialogResult.OK)
                //    this._EpisodeAction.ObjectContext.Save();
                //else
                //    this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
            }
            catch (Exception ex)
            {
                this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
                InfoBox.Show(ex);
            }
            finally
            {
                // objectContext.Dispose();
            }
        }

        /// <summary>
        /// Yeni Planlı Tıbbi İşlem isteği başlatır.
        /// </summary>
        public void CreateNewPlannedMedicalActionRequest()
        {
            //SaveContextForNewDiagnose();
            PlannedMedicalActionRequest plannedMedicalActionRequest;
            //Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
            //TTObjectContext objectContext = new TTObjectContext(false);
            Guid savePointGuid = this._EpisodeAction.ObjectContext.BeginSavePoint();
            try
            {
                plannedMedicalActionRequest = new PlannedMedicalActionRequest(this._EpisodeAction.ObjectContext, this._EpisodeAction);
                //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
                //TTForm frm = TTForm.GetEditForm(plannedMedicalActionRequest);
                //this.PrapareFormToShow(frm);
                //if (frm.ShowEdit(this.FindForm(), plannedMedicalActionRequest) == DialogResult.OK)
                //    this._EpisodeAction.ObjectContext.Save();
                //else
                //    this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
            }
            catch (Exception ex)
            {
                this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
                InfoBox.Show(ex);
            }
            finally
            {
                //objectContext.Dispose();
            }
        }

        /// <summary>
        /// Yeni Hasta Yatış isteği başlatır.
        /// </summary>
        public void CreateNewInpatientAdmission()
        {

            // Acil serviste muayeneleri YEŞİL ALAN olarak işaretlenen hastaların kliniklere yatışına Medulada ödeme kapsamında olmadığı için  izin verilmemektedir.

            if (this._EpisodeAction != null)
            {
                if (this._EpisodeAction.Episode != null)
                {
                    foreach (EmergencyIntervention ei in this._EpisodeAction.Episode.EmergencyInterventions)
                    {
                        foreach (InPatientPhysicianApplication ippa in ei.InPatientPhysicianApplications)
                        {
                            //if (ippa.IsGreenAreaExamination != null)
                            {
                                if (ippa.IsGreenAreaExamination == true)
                                    throw new Exception("Yeşil alan muayenelerinde hasta yatış işlemi başlatılamaz!");

                            }
                            /*
                            if (ei.TriajCode != null && ei.TriajCode.Value != null)
                            {
                                if (ei.TriajCode.Value.Equals(TriajCode.Triaj4) == true)
                                    throw new Exception("Acil serviste muayeneleri YEŞİL ALAN olan hastaların kliniklere yatışına izin verilmemektedir.");
                                else if (ei.TriajCode.Value.Equals(TriajCode.Triaj4) == true)
                                    throw new Exception("Acil serviste muayeneleri YEŞİL ALAN olan hastaların kliniklere yatışına izin verilmemektedir.");
                            }*/
                        }
                        foreach (PatientExamination pe in ei.PatientExaminations)
                        {
                            if (pe.IsGreenAreaExamination == true)
                                throw new Exception("Yeşil alan muayenelerinde hasta yatış işlemi başlatılamaz!");

                        }
                    }
                }
            }

            //SaveContextForNewDiagnose();
            InpatientAdmission inpatientAdmission;
            //Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
            //TTObjectContext objectContext = new TTObjectContext(false);
            Guid savePointGuid = this._EpisodeAction.ObjectContext.BeginSavePoint();
            try
            {
                inpatientAdmission = new InpatientAdmission(this._EpisodeAction.ObjectContext, this._EpisodeAction);
                //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
                //TTForm frm = TTForm.GetEditForm(inpatientAdmission);
                //this.PrapareFormToShow(frm);
                //if (frm.ShowEdit(this.FindForm(), inpatientAdmission) == DialogResult.OK)
                //    this._EpisodeAction.ObjectContext.Save();
                //else
                //    this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
            }
            catch (Exception ex)
            {
                this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
                InfoBox.Show(ex);
            }
            finally
            {
                //objectContext.Dispose();
            }
        }

   
        public void SaveContextForNewDiagnose()
        {
            //            if (this._EpisodeAction.Episode.Diagnosis.Count > 0)
            //            {
            //                TTObjectContext context = new TTObjectContext(true);
            //                Episode episode = (Episode)context.GetObject(this._EpisodeAction.Episode.ObjectID, typeof(Episode));
            //                if (episode.Diagnosis.Count < this._EpisodeAction.Episode.Diagnosis.Count)
            //                {
            //                    //string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "İşlemi kaydetmek istediğinize emin misiniz?", "Girilen tanılar henüz kaydedilmemiştir.İstek yapmak için işlemi kaydedip devam etmek istediğinize emin misiniz?", 1);
            ////                    string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "İşlemi kaydetmek istediğinize emin misiniz?", SystemMessage.GetMessage(173), 1);
            ////                    if (result == "E")
            this._EpisodeAction.ObjectContext.Save();
            //                }
            //            }
            var a = 1;
        }
        public ProcedureRequestTemplateDefinition SelectTemplate(TTObjectContext objectContext, string ProcedureRequestTemplateType, bool ToUpdate)
        {
            IList templates;
            if (ToUpdate == false || Common.CurrentUser.IsSuperUser)
            {
                templates = objectContext.QueryObjects(ProcedureRequestTemplateType.ToUpperInvariant(), " RESUSER = '" + Common.CurrentResource.ObjectID.ToString() + "' OR RESUSER IS NULL ");
            }
            else// Super user harici kişiler yanlız kendi templatelerini Update edebilirler.
            {
                templates = objectContext.QueryObjects(ProcedureRequestTemplateType.ToUpperInvariant(), " RESUSER = '" + Common.CurrentResource.ObjectID.ToString() + "'");
            }

            MultiSelectForm pForm = new MultiSelectForm();
            foreach (ProcedureRequestTemplateDefinition template in templates)
            {
                pForm.AddMSItem(template.Name, template.ObjectID.ToString(), template);
            }

            string sKey = pForm.GetMSItem(this, this._EpisodeAction.ObjectDef.DisplayText + " şablonu seçiniz.", false, false, false, false, true, false);
            if (!String.IsNullOrEmpty(sKey))
            {
                return (ProcedureRequestTemplateDefinition)pForm.MSSelectedItemObject;
            }
            return null;
        }

        public void ShowTempleteForm(ProcedureRequestTemplateDefinition selectedTemplate, string templateDefinitionList)
        {
            TTDefinitionForm frm;
            string filter = "";
            if (!Common.CurrentUser.IsSuperUser)
            {
                filter = " RESUSER = '" + Common.CurrentResource.ObjectID.ToString() + "'";
            }
            //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
            //frm = TTDefinitionForm.GetEditForm(TTObjectDefManager.Instance.ListDefs[templateDefinitionList], filter);
            //frm.ShowEdit(this.FindForm(), TTObjectDefManager.Instance.ListDefs[templateDefinitionList], selectedTemplate, filter);
            var a = 1;
        }

        //Reçete
        public virtual void CreateNewOutPatientPrescriptionn()
        {
            //SaveContextForNewDiagnose();
            if (this._EpisodeAction.Episode.PatientStatus == PatientStatusEnum.Outpatient)
            {
                OutPatientPrescription outPatientPrescription;
                //Yeni context te oluşturulduğunda Episode da Concurency Violation hatası alıyordu. EpisodeAction ın kendi context inde create edilmesi sağlandı.
                //TTObjectContext objectContext = new TTObjectContext(false);
                Guid savePointGuid = this._EpisodeAction.ObjectContext.BeginSavePoint();
                try
                {
                    outPatientPrescription = new OutPatientPrescription(this._EpisodeAction.ObjectContext, this._EpisodeAction);
                    //TODO: ShowEdit yerine başka çözüm bulununca düzeltilecek. Şimdilik kapatıldı.
                    //TTForm frm = TTForm.GetEditForm(outPatientPrescription);
                    //this.PrapareFormToShow(frm);
                    //if (frm.ShowEdit(this.FindForm(), outPatientPrescription) == DialogResult.OK)
                    //    this._EpisodeAction.ObjectContext.Save();
                    //else
                    //    this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
                }
                catch (Exception ex)
                {
                    this._EpisodeAction.ObjectContext.RollbackSavePoint(savePointGuid);
                    InfoBox.Show(ex);
                }
                finally
                {
                    //objectContext.Dispose();
                }
            }
            else
            {
                InfoBox.Show("Ayaktan Hasta Reçetesi sadece ayaktan hastaya başlatılır.");
                return;
            }
        }

        protected virtual void CreateQueueItem(TTObjectStateTransitionDef transDef)
        {
            if (this._EpisodeAction.MasterResource is ResPoliclinic && ((ResPoliclinic)this._EpisodeAction.MasterResource).PatientCallSystemInUse == true)
            {
                if (transDef != null && Common.IsTransitionAttributeExists(typeof(CreateQueueItemAttribute), transDef))
                {
                    ExaminationQueueDefinition queueDef = null;
                    queueDef = this.SelectQueue(this._EpisodeAction.ObjectContext, this._EpisodeAction.MasterResource, false);

                    if (queueDef == null)
                        throw new Exception(SystemMessage.GetMessage(1015));
                    else
                    {
                        ResUser queueUser = this.SelectQueueUser(this._EpisodeAction.ObjectContext, queueDef, false);
                        if (queueUser != null)
                        {
                            this.SetAuthorizedUserByQueueUser(queueUser, (EpisodeAction)this._EpisodeAction);
                            if (this._EpisodeAction.AuthorizedUsers.Count > 0)
                            {
                                AuthorizedUser authorizedUser = this._EpisodeAction.AuthorizedUsers[this._EpisodeAction.AuthorizedUsers.Count - 1];
                                this._EpisodeAction.ProcedureDoctor = authorizedUser.User;
                            }
                        }
                        else
                        {
                            string uKey = ShowBox.Show(ShowBoxTypeEnum.Message, "Evet,Hayır", "E,H", "Uyarı", "Doktor Atama", "Doktor atama yapmadan devam etmek istediğinize emin misiniz?", 2);
                            if (String.IsNullOrEmpty(uKey) == true || uKey == "H")
                                throw new Exception(SystemMessage.GetMessage(80));
                        }

                        bool isEmergency = false;
                        if (this._EpisodeAction.FromResource != null)
                        {
                            foreach (ResourceSpecialityGrid spg in this._EpisodeAction.FromResource.ResourceSpecialities)
                            {
                                if (spg.Speciality != null)
                                    if (spg.Speciality.Code == TTObjectClasses.SystemParameter.GetParameterValue("EMERGENCYSPECIALITYDEFINITIONCODE", "4400").ToString()) //Acil Tıp
                                        isEmergency = true;
                            }
                        }
                        ExaminationQueueItem queueItem = null;
                        queueItem = this._EpisodeAction.CreateExaminationQueueItem(this._EpisodeAction.SubEpisode.PatientAdmission, queueDef,false);
                        if (queueItem == null)
                            throw new Exception(SystemMessage.GetMessageV2(1016, queueDef.Name.ToString()));
                        else
                            InfoBox.Show(this._EpisodeAction.Episode.Patient.RefNo + " " + this._EpisodeAction.Episode.Patient.FullName + " hastası," + queueDef.Name + " sırasına eklendi. Sıradaki Toplam Hasta Sayısı : " + queueDef.CurrentItemsCount.ToString(), MessageIconEnum.InformationMessage);
                    }
                }
            }
        }

        //public void ShowPatientPrivacyInformation(Patient patient)
        //{
        //    if(patient.IsPatientPrivacy == true)
        //    {
        //        //Gönderilen hasta için bir daha gösterme check i işaretlendiyse uyarı ekranı gelmesin diye
        //        if(!Common.CurrentResource.PrivacyPatientNotShownList.Contains(patient.ObjectID))
        //        {
        //            WarningMessageForm frm = new WarningMessageForm();
        //            frm.CurrentPatient = patient;
        //            frm.WarningMessage = patient.FullName + " hastası "+ patient.PrivacyEndDate.Value.Date.ToString() +" tarihine kadar gizli hastadır.\r\n\r\nGizlilik Sebebi :\r\n" + patient.PrivacyReason ;
        //            InfoBox.Show("frm.ShowDialog(this);");
        //        }
        //    }
        //}

        public bool ValidateSutRules(object owner)
        {
            TTUtils.Entities.RuleValidateResultDto validateResult = this._EpisodeAction.CheckSutRules(false);
            // SUT kural doğrulama sonucu hiç bir mesaj dönmedi
            if (validateResult == null || !EnumerableHelper.Any(validateResult.Messages))
                return true;

            TTFormClasses.SutRuleCheckResultsForm form = new TTFormClasses.SutRuleCheckResultsForm();
            form.BlockRequest = false;
            //form.RuleViolateMessages = validateResult.Messages;
            form.BlockRequest = validateResult.BlockRequest;

            DialogResult result = DialogResult.Ignore;
            InfoBox.Show("DialogResult result = form.ShowDialog((IWin32Window)owner);");

            bool returnValue = false;
            // Doktor devam seçeneğini kullanıyor
            if (result == DialogResult.Ignore)
            {
                //_EpisodeAction.SetSutRulesIgnored(validateResult.Messages);
                returnValue = true;
            }

            string resultXml = SerializationHelper.XmlSerializeObject(validateResult.Messages);

            string resultText = resultXml;

            if (resultText.Length > 4000)
            {
                resultText = resultText.Substring(0, 4000);
            }

            TTObjectContext context = new TTObjectContext(false);
            SUTRuleCheckResult sutCheckResult = new SUTRuleCheckResult(context);
            sutCheckResult.ProcessDate = DateTime.Now;
            sutCheckResult.ResUser = TTUser.CurrentUser.UserObject as ResUser;
            sutCheckResult.Results = resultText;
            sutCheckResult.Status = SUTRuleCheckResultStatus.Rejected;
            sutCheckResult.Episode = this._EpisodeAction.Episode;
            sutCheckResult.CheckResults = resultXml;

            if (result == DialogResult.Ignore)
            {
                sutCheckResult.Status = SUTRuleCheckResultStatus.Ignored;
            }
            context.Save();

            // SUT kural doğrulama başarısız oldu işleme devam edilmeyecek
            return returnValue;
        }

        public void AddReturnDescriptionInput(OrthesisProsthesisRequest orthesisProsthesisRequest)
        {
            if (this._EpisodeAction is OrthesisProsthesisRequest)
            {
                StringEntryForm pReturnForm = new StringEntryForm();
                DialogResult res = pReturnForm.ShowStringDialog(this, "İade Açıklamasını Giriniz");
                if (res == DialogResult.OK)
                {
                    OrthesisProsthesis_ReturnDescriptionsGrid theGrid = null;
                    theGrid = new OrthesisProsthesis_ReturnDescriptionsGrid(this._EpisodeAction.ObjectContext);
                    theGrid.Description = pReturnForm.StringContent;
                    theGrid.EntryDate = Common.RecTime();
                    theGrid.UserName = Common.CurrentResource == null ? "" : Common.CurrentResource.Name;

                    orthesisProsthesisRequest.ReturnDescriptions.Add(theGrid);
                }
            }
        }

        public void DirectPurchaseMaterialByPatient()
        {
            MultiSelectForm msItem = new MultiSelectForm();


            //Servera tek seferde gidip gelsin diye kullanılacak dic
            Dictionary<Guid, DPADetailFirmPriceOffer> dPADetailFirmPriceOfferDic = new Dictionary<Guid, DPADetailFirmPriceOffer>();

            IList<DPADetailFirmPriceOffer> dPADetailFirmPriceOffers = (IList<DPADetailFirmPriceOffer>)TTObjectClasses.DPADetailFirmPriceOffer.GetUnsedAndApproved22FMaterialByPatient(this._EpisodeAction.ObjectContext, this._EpisodeAction.Episode.Patient.ObjectID);
            foreach (DPADetailFirmPriceOffer dPADetailFirmPriceOffer in dPADetailFirmPriceOffers)
            {
                if (dPADetailFirmPriceOffer.DirectPurchaseActionDetail.SUTCode != null && string.IsNullOrEmpty(dPADetailFirmPriceOffer.DirectPurchaseActionDetail.SUTCode.SUTCode) == false && string.IsNullOrEmpty(dPADetailFirmPriceOffer.DirectPurchaseActionDetail.SUTName) == false)
                    msItem.AddMSItem(dPADetailFirmPriceOffer.DirectPurchaseActionDetail.SUTCode.SUTCode + " " + dPADetailFirmPriceOffer.DirectPurchaseActionDetail.SUTName, dPADetailFirmPriceOffer.ObjectID.ToString());
                else if (string.IsNullOrEmpty(dPADetailFirmPriceOffer.DirectPurchaseActionDetail.SUTName) == false)
                    msItem.AddMSItem(dPADetailFirmPriceOffer.DirectPurchaseActionDetail.SUTName, dPADetailFirmPriceOffer.ObjectID.ToString());
                else if (dPADetailFirmPriceOffer.DirectPurchaseActionDetail.DPA22FCodelessMaterial != null)
                    msItem.AddMSItem(dPADetailFirmPriceOffer.DirectPurchaseActionDetail.DPA22FCodelessMaterial.MaterialName, dPADetailFirmPriceOffer.ObjectID.ToString());
                dPADetailFirmPriceOfferDic.Add(new Guid(dPADetailFirmPriceOffer.ObjectID.ToString()), dPADetailFirmPriceOffer);

            }
            string key = msItem.GetMSItem(null, "Hastanın 22F Malzemesi Bulunmakta, Kullanmak İstediklerinizi Seçiniz", false, false, true);
            if (!string.IsNullOrEmpty(key))
            {
                List<DPADetailFirmPriceOffer> selectedDPADetailFirmPriceOffer = new List<DPADetailFirmPriceOffer>();
                foreach (string sp in msItem.MSSelectedItems.Keys)
                {
                    DPADetailFirmPriceOffer dpa = null;
                    dPADetailFirmPriceOfferDic.TryGetValue(new Guid(sp), out dpa);
                    if (dpa != null)
                    {

                        if (dpa.OfferedUBB != null)
                        {
                            SurgeryDirectPurchaseGrid sdp = new SurgeryDirectPurchaseGrid(this._EpisodeAction.ObjectContext);
                            sdp.DPADetailFirmPriceOffer = dpa;
                            this._EpisodeAction.TreatmentMaterials.Add(sdp);
                        }
                        else
                        {
                            CodelessMaterialDirectPurchaseGrid cdp = new CodelessMaterialDirectPurchaseGrid(this._EpisodeAction.ObjectContext);
                            cdp.DPADetailFirmPriceOffer = dpa;
                            this._EpisodeAction.TreatmentMaterials.Add(cdp);
                        }

                    }
                }
            }
        }

        public bool IsMedulaProvisionNecessaryProcedureExists()
        {
            foreach (SubActionProcedure sp in this._EpisodeAction.SubactionProcedures)
            {
                if (sp.ProcedureObject != null && sp.ProcedureObject.DailyMedulaProvisionNecessity == true)
                    return true;
            }
            return false;
        }
        public bool RequiresAdvance()
        {
            var subEpisode = this._EpisodeAction.SubEpisode;
            if (subEpisode != null && SubEpisode.GetOpenSubEpisodeProtocol(subEpisode) != null && SubEpisode.GetOpenSubEpisodeProtocol(subEpisode).Protocol.RequiresAdvance == true)
            {
                foreach (Advance advance in this._EpisodeAction.Episode.Advances)
                {
                    if (advance.IsCancelled == false)
                        return false;
                }
                return true;
            }
            return false;
        }



        public void CreateSubActionMatPricingDet()
        {
            this._EpisodeAction.CreateSubActionMatPricingDet();
        }


        public void MakingDirectPurchaseHasUsed()
        {
            this._EpisodeAction.MakingDirectPurchaseHasUsed();
        }




        #endregion EpisodeActionForm_ClientSideMethods
    }
}