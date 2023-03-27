
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
    /// Laboratuvar İstek Formu
    /// </summary>
    public partial class LaboratoryRequestRequestForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            ttBinaryScanInfo.Click += new TTControlEventDelegate(ttBinaryScanInfo_Click);
            btnCreateTemplate.Click += new TTControlEventDelegate(btnCreateTemplate_Click);
            btnEditTemplate.Click += new TTControlEventDelegate(btnEditTemplate_Click);
            btnSelectTemplate.Click += new TTControlEventDelegate(btnSelectTemplate_Click);
            PreDiagnosis.TextChanged += new TTControlEventDelegate(PreDiagnosis_TextChanged);
            ttTripleTestInfo.Click += new TTControlEventDelegate(ttTripleTestInfo_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttBinaryScanInfo.Click -= new TTControlEventDelegate(ttBinaryScanInfo_Click);
            btnCreateTemplate.Click -= new TTControlEventDelegate(btnCreateTemplate_Click);
            btnEditTemplate.Click -= new TTControlEventDelegate(btnEditTemplate_Click);
            btnSelectTemplate.Click -= new TTControlEventDelegate(btnSelectTemplate_Click);
            PreDiagnosis.TextChanged -= new TTControlEventDelegate(PreDiagnosis_TextChanged);
            ttTripleTestInfo.Click -= new TTControlEventDelegate(ttTripleTestInfo_Click);
            base.UnBindControlEvents();
        }

        private void ttBinaryScanInfo_Click()
        {
            #region LaboratoryRequestRequestForm_ttBinaryScanInfo_Click
            //TODO:ShowEdit!
            //if (this._LaboratoryRequest.LaboratoryBinaryScanInfo != null)
            //{
            //    LaboratoryBinaryScanForm binaryScanForm = new LaboratoryBinaryScanForm(this._LaboratoryRequest,this._LaboratoryRequest.LaboratoryBinaryScanInfo);
            //    binaryScanForm.ShowDialog();
            //}
            //else
            //{
            //    LaboratoryBinaryScanForm binaryScanForm = new LaboratoryBinaryScanForm(this._LaboratoryRequest);
            //    binaryScanForm.ShowDialog();
            //}
            var a = 1;
            #endregion LaboratoryRequestRequestForm_ttBinaryScanInfo_Click
        }

        private void btnCreateTemplate_Click()
        {
            #region LaboratoryRequestRequestForm_btnCreateTemplate_Click
            //Tetkik İstem tarafından yonetılecek!
            //if (this._LaboratoryRequest.LaboratoryRequestTemplate == null)
            //         {
            //             try
            //             {
            //                 string description = InputForm.GetText("Şablon Açıklaması");
            //                 if (!string.IsNullOrEmpty(description))
            //                 {
            //                     TTObjectContext objectContext = new TTObjectContext(false);

            //                     LaboratoryAcceptTemplateDefinition template = new LaboratoryAcceptTemplateDefinition(objectContext);
            //                     foreach (TabPage page in this.tabTetkik.TabPages)
            //                     {
            //                         foreach (Control control in page.Controls)
            //                         {
            //                             if (control is TTListView)
            //                             {
            //                                 TTListView lv = (TTListView)control;
            //                                 template.ResUser = Common.CurrentResource;
            //                                 template.Name = description;

            //                                 foreach (TTListViewItem lvItem in lv.CheckedItems)
            //                                 {
            //                                     if (lvItem.Tag is Guid)
            //                                     {
            //                                         LaboratoryTestDefinition labReqTestDef = (LaboratoryTestDefinition)objectContext.GetObject(new Guid(lvItem.Tag.ToString()), "LaboratoryTestDefinition");
            //                                         LaboratoryAcceptTemplateDetail templateDetail = new LaboratoryAcceptTemplateDetail(objectContext);
            //                                         templateDetail.LaboratoryTestDefinition = labReqTestDef;
            //                                         LaboratoryRequestFormTabDefinition tabDef = page.Tag as LaboratoryRequestFormTabDefinition;
            //                                         if (tabDef != null)
            //                                             templateDetail.LaboratoryRequestFormTab = tabDef;
            //                                         if (this._LaboratoryRequest.MasterResource is ResLaboratoryDepartment)
            //                                         {
            //                                             templateDetail.LaboratoryUnit = (ResLaboratoryDepartment)this._LaboratoryRequest.MasterResource;
            //                                             template.Department = (ResLaboratoryDepartment)(this._LaboratoryRequest.MasterResource);
            //                                         }
            //                                         template.LaboratoryAcceptTemplateDetails.Add(templateDetail);
            //                                     }
            //                                 }
            //                             }
            //                         }
            //                     }
            //                     objectContext.Save();
            //                 }
            //             }
            //             catch (Exception ex)
            //             {
            //                 InfoBox.Show(ex);
            //             }
            //         }
            var a = 1;
#endregion LaboratoryRequestRequestForm_btnCreateTemplate_Click
        }

        private void btnEditTemplate_Click()
        {
            #region LaboratoryRequestRequestForm_btnEditTemplate_Click
            //TODO:ShowEdit!
            //TTObjectContext objectContext = new TTObjectContext(false);
            //IList templates = objectContext.QueryObjects("LABORATORYACCEPTTEMPLATEDEFINITION","RESUSER=" + ConnectionManager.GuidToString(Common.CurrentResource.ObjectID));
            //MultiSelectForm pForm = new MultiSelectForm();
            //foreach (LaboratoryAcceptTemplateDefinition template in templates)
            //    if (template.ResUser != null && template.ResUser.ObjectID == Common.CurrentResource.ObjectID)
            //        pForm.AddMSItem(template.Name, template.ObjectID.ToString(), template);

            //string sKey = pForm.GetMSItem(this, "Laboratuvar şablonu seçiniz.", false, false, false, false, true, false);


            //if (!String.IsNullOrEmpty(sKey))
            //{
            //    LaboratoryAcceptTemplateDefinition selectedTemplate = (LaboratoryAcceptTemplateDefinition)pForm.MSSelectedItemObject;
            //    TTDefinitionForm frm = TTDefinitionForm.GetEditForm(TTObjectDefManager.Instance.ListDefs["LaboratoryAcceptTemplateListForDefinitionForm"]);
            //    frm.ShowEdit(this.FindForm(), TTObjectDefManager.Instance.ListDefs["LaboratoryAcceptTemplateListForDefinitionForm"], selectedTemplate);
            //}
            var a = 1;
            #endregion LaboratoryRequestRequestForm_btnEditTemplate_Click
        }

        private void btnSelectTemplate_Click()
        {
            #region LaboratoryRequestRequestForm_btnSelectTemplate_Click
            //Tetkik İstem tarafından yonetılecek!
            //TTObjectContext objectContext = new TTObjectContext(true);
            //IList templates = objectContext.QueryObjects("LABORATORYACCEPTTEMPLATEDEFINITION","RESUSER=" + ConnectionManager.GuidToString(Common.CurrentResource.ObjectID));
            //         MultiSelectForm pForm = new MultiSelectForm();
            //         foreach (LaboratoryAcceptTemplateDefinition template in templates)
            //         {
            //             if (template.ResUser != null && template.ResUser.ObjectID == Common.CurrentResource.ObjectID)
            //             {
            //                 ResLaboratoryDepartment department = template.Department as ResLaboratoryDepartment;
            //                 if (department != null && department.ObjectID == this._LaboratoryRequest.MasterResource.ObjectID)
            //                     pForm.AddMSItem(template.Name, template.ObjectID.ToString(), template);
            //             }
            //         }
            //         string sKey = pForm.GetMSItem(this, "Laboratuvar şablonu seçiniz.", false, false, false, false, true, false);
            //         if (!String.IsNullOrEmpty(sKey))
            //         {
            //             LaboratoryAcceptTemplateDefinition selectedTemplate = (LaboratoryAcceptTemplateDefinition)pForm.MSSelectedItemObject;

            //             foreach (LaboratoryAcceptTemplateDetail detail in selectedTemplate.LaboratoryAcceptTemplateDetails)
            //             {
            //                 foreach (TabPage page in this.tabTetkik.TabPages)
            //                 {
            //                     bool testIsInThisTab = false;
            //                     foreach (LaboratoryTabNamesGrid grid in detail.LaboratoryTestDefinition.TabNames)
            //                     {
            //                         if (grid.RequestFormTab.Name == page.Name)
            //                         {
            //                             testIsInThisTab = true;
            //                             ((TTTabControl)this.tabTetkik).SelectTab(page);
            //                         }
            //                     }
            //                     if (testIsInThisTab)
            //                     {
            //                         foreach (Control control in page.Controls)
            //                         {
            //                             if (control is TTListView)
            //                             {
            //                                 TTListView lv = (TTListView)control;
            //                                 foreach (TTListViewItem otherTest in lv.Items)
            //                                 {
            //                                     LaboratoryTestDefinition labReqTestDef = (LaboratoryTestDefinition)objectContext.GetObject(new Guid(otherTest.Tag.ToString()), "LaboratoryTestDefinition");
            //                                     if (!otherTest.Checked && (detail.LaboratoryTestDefinition.ObjectID == labReqTestDef.ObjectID))
            //                                     {
            //                                         otherTest.Checked = true;
            //                                         break;
            //                                     }
            //                                 }
            //                             }
            //                         }
            //                     }
            //                 }
            //             }
            //         }
            var a = 1;
            #endregion LaboratoryRequestRequestForm_btnSelectTemplate_Click
        }

        private void PreDiagnosis_TextChanged()
        {
            #region LaboratoryRequestRequestForm_PreDiagnosis_TextChanged
            //string text = PreDiagnosis.Text;
            //         ttStringLength.Text = text.Length.ToString()+ " karakter.";
            var a = 1;
#endregion LaboratoryRequestRequestForm_PreDiagnosis_TextChanged
        }

        private void ttTripleTestInfo_Click()
        {
            #region LaboratoryRequestRequestForm_ttTripleTestInfo_Click
            //TODO:ShowEdit!
            //if (this._LaboratoryRequest.LaboratoryTripleTestInfo != null)
            //{
            //    LaboratoryTripleTestForm tripleTestForm = new LaboratoryTripleTestForm(this._LaboratoryRequest,this._LaboratoryRequest.LaboratoryTripleTestInfo);
            //    tripleTestForm.ShowDialog();
            //}
            //else
            //{
            //    LaboratoryTripleTestForm tripleTestForm = new LaboratoryTripleTestForm(this._LaboratoryRequest);
            //    tripleTestForm.ShowDialog();
            //}
            var a = 1;
            #endregion LaboratoryRequestRequestForm_ttTripleTestInfo_Click
        }

        protected override void PreScript()
        {
            #region LaboratoryRequestRequestForm_PreScript
            //Tetkik İstem tarafından yonetılecek!
            //this.DropStateButton(LaboratoryRequest.States.Procedure);

            //        base.PreScript();

            //        //TODO:pnlButtons!
            //        //for (int i = 0; i < (this.pnlButtons.Controls.Count); i++)
            //        //{
            //        //    if (this.pnlButtons.Controls[i].Name.ToString() == "cmdOK")
            //        //    {
            //        //        this.pnlButtons.Controls[i].Visible = false;
            //        //    }
            //        //}

            //        this._LaboratoryRequest.PatientAge = this._LaboratoryRequest.Episode.Patient.AgeByYearByMonthByDay();
            //        this._LaboratoryRequest.PatientSex = this._LaboratoryRequest.Episode.Patient.Sex;
            //        this._LaboratoryRequest.RequestDoctor = Common.CurrentResource;
            var a = 1;
            #endregion LaboratoryRequestRequestForm_PreScript

        }

        protected override void ClientSidePreScript()
        {
            #region LaboratoryRequestRequestForm_ClientSidePreScript
            //Tetkik İstem tarafından yonetılecek!
            //base.ClientSidePreScript();
            //        TabForInformations.HideTabPage(TabPageFutureRequest);
            //        this.GenerateLaboratoryTabs();
            var a = 1;
            #endregion LaboratoryRequestRequestForm_ClientSidePreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
            #region LaboratoryRequestRequestForm_PostScript
            //Tetkik İstem tarafından yonetılecek!
            //    this.SetCheckedItemsAsRequestedProcedures();            

            //              try
            //            {
            //                if (Episode.IsMedulaEpisode(_LaboratoryRequest.Episode))
            //                {
            //                    string errorMessage = string.Empty;
            //                    foreach (LaboratoryProcedure lp in _LaboratoryRequest.LaboratoryProcedures)
            //                    {
            //                        if (((LaboratoryTestDefinition)lp.ProcedureObject).RequiresDiabetesForm != null && ((LaboratoryTestDefinition)lp.ProcedureObject).RequiresDiabetesForm == true)
            //                        {
            //                            Guid siteID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", null).ToString());
            //                            TakipFormuIslemleri.takipFormuOkuGirisDVO takipFormuOkuGirisDVO = new TakipFormuIslemleri.takipFormuOkuGirisDVO();
            //                            takipFormuOkuGirisDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
            //                            if (_LaboratoryRequest.Episode.Patient != null && _LaboratoryRequest.Episode.Patient.UniqueRefNo != null)
            //                                takipFormuOkuGirisDVO.tcKimlikNo = _LaboratoryRequest.Episode.Patient.UniqueRefNo.ToString();

            //                            TakipFormuIslemleri.takipFormuOkuCevapDVO takipFormuOkuCevapDVO = TakipFormuIslemleri.WebMethods.takipFormuOku(siteID, takipFormuOkuGirisDVO);
            //                            if (takipFormuOkuCevapDVO != null)
            //                            {
            //                                if (string.IsNullOrEmpty(takipFormuOkuCevapDVO.sonucKodu) == false)
            //                                {
            //                                    if (takipFormuOkuCevapDVO.sonucKodu.Equals("0000"))
            //                                    {
            //                                        if (takipFormuOkuCevapDVO.diabetTakipFormlari != null && takipFormuOkuCevapDVO.diabetTakipFormlari.Length <= 0)
            //                                            errorMessage = "Hastaya Ait Diabet Takip Formu bulunamadı";
            //                                        //else if (takipFormuOkuCevapDVO.diabetTakipFormlari != null && takipFormuOkuCevapDVO.diabetTakipFormlari.Length > 0)
            //                                        //{
            //                                        //    InfoBox.S how("Hastaya Ait Diabet Takip Formlarının okunması işlemi başarılı şekilde yapıldı.", MessageIconEnum.InformationMessage);
            //                                        //}
            //                                    }
            //                                    else
            //                                    {
            //                                        if (string.IsNullOrEmpty(takipFormuOkuCevapDVO.sonucMesaji) == false)
            //                                            errorMessage = "Meduladan gelen mesaj : " + takipFormuOkuCevapDVO.sonucMesaji;
            //                                        else
            //                                            errorMessage = "Hastaya Ait Diabet Takip Formlarının Meduladan okunması işleminde hata var.";
            //                                    }
            //                                }
            //                                else
            //                                {
            //                                    if (string.IsNullOrEmpty(takipFormuOkuCevapDVO.sonucMesaji) == false)
            //                                        errorMessage = "Meduladan gelen mesaj : " + takipFormuOkuCevapDVO.sonucMesaji;
            //                                    else
            //                                        errorMessage = "Hastaya Ait Diabet Takip Formlarının Meduladan okunması sırasında hata oluştu! Sonuç Kodu ve Sonuç Mesajı alanı boş!";
            //                                }
            //                            }
            //                            else
            //                                errorMessage = "Hastaya Ait Diabet Takip Formları Meduladan okunamadı!";
            //                        }

            //                        if (!string.IsNullOrEmpty(errorMessage))
            //                            throw new TTUtils.TTException("Medula '" + lp.ProcedureObject.Name + "' adlı tetkik için Diyabet takip formu istemektedir. Hastaya ait diyabet takip formu sorgulaması sırasında hata oluştu!\r\n" + errorMessage);
            //                    }






            //                    //                    foreach (LaboratoryRequestFormTabDefinition tabDef in liste)
            //                    //                    {
            //                    //                        TTObjectContext thisContext = this._LaboratoryRequest.ObjectContext;
            //                    //                        BindingList<LaboratoryTabNamesGrid.GetByTabs_Class> grids = LaboratoryTabNamesGrid.GetByTabs(thisContext, tabDef.ObjectID.ToString());
            //                    //                        foreach (LaboratoryTabNamesGrid.GetByTabs_Class tabGrid in grids)
            //                    //                        {
            //                    //                            tabGrid.
            //                    //                        }
            //                    //                    }


            //                    //                TabPage page = (TabPage)tabTetkik.SelectedTab;
            //                    //                foreach (Control control in page.Controls)
            //                    //                {
            //                    //                    if (control is ListView)
            //                    //                    {
            //                    //                        ListView lv = (ListView)control;
            //                    //                        foreach (ListViewItem lvItem in lv.SelectedItems)
            //                    //                        {
            //                    //                            if (lvItem.Tag is Guid?)
            //                    //                            {
            //                    //                                Guid objId = (Guid)lvItem.Tag;
            ////
            //                    //                                LaboratoryTestDefinition testDef = (LaboratoryTestDefinition)thisContext.GetObject(objId, "LaboratoryTestDefinition");
            ////
            //                    //                                foreach(BranchGrid branchGrid in testDef.BranchGrid )
            //                    //                                {
            //                    //                                    if (_LaboratoryRequest.Episode.MainSpeciality.Code != branchGrid.Specialities.Code)
            //                    //                                        throw new TTUtils.TTException(" ds");
            //                    //                                }
            //                    //                            }
            //                    //                        }
            //                    //                    }
            //                    //                }



            //                }
            //            }
            //            catch(Exception ex)
            //            {
            //                throw new TTUtils.TTException(ex.Message);
            //            }
            var a = 1;
            #endregion LaboratoryRequestRequestForm_PostScript

        }

        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
            #region LaboratoryRequestRequestForm_ClientSidePostScript
            //Tetkik İstem tarafından yonetılecek!
            //base.ClientSidePostScript(transDef);
            //         string preDiagnosisText = PreDiagnosis.Text;
            //        if(preDiagnosisText.Length > 2000)
            //        {
            //            throw new Exception("Kısa Anamnez ve Klinik Bulgular alanına en fazla 2000 karakter uzunluğunda metin girilmesine izin verilmektedir!");
            //        }            


            //        StringBuilder sb = new StringBuilder();
            //        foreach (ExtendedLabRequestInfo labRequestInfo in tempTestDefList)
            //        {
            //            sb.Append(labRequestInfo.LabTestDef.Name);
            //            sb.Append(" / ");
            //        }

            //        //Tekrarlayan tetkik isteklerin kontrolü burada gerçekleşir...
            //        //List<ProcedureDefinition> duplicateControlList = new List<ProcedureDefinition>();//Aynı testin döngü içerisinde tekrar tekrar kontrol edilmesinin önüne geçer...
            //        if (_LaboratoryRequest.Episode.PatientStatus == PatientStatusEnum.Outpatient)//Kontrol sadece ayaktan hastalar için çalışır.
            //        {
            //            foreach (EpisodeAction episodeAction in _EpisodeAction.Episode.EpisodeActions)
            //            {
            //                if (episodeAction is LaboratoryRequest)
            //                {
            //                    if (tempTestDefList.Count > 0)
            //                    {
            //                        foreach (ExtendedLabRequestInfo labRequestInfo in tempTestDefList)
            //                        {

            //                            foreach (LaboratoryProcedure labProc in ((LaboratoryRequest)episodeAction).LaboratoryProcedures)
            //                            {
            //                                //uyarı burada verilecek...
            //                                //if (labRequestInfo.LabTestDef.ObjectID == labProc.ProcedureObject.ObjectID && duplicateControlList.Contains(labProc.ProcedureObject) == false)
            //                                if (labRequestInfo.LabTestDef.ObjectID == labProc.ProcedureObject.ObjectID)
            //                                {
            //                                    bool proceed = false;

            //                                    //                                        string warningResult = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Devam etmek istediğinizden emin misiniz?"
            //                                    //                                            , "Hastanın vakasında daha önceden istenmiş " + labProc.ProcedureObject.Code.ToString() + " " + labProc.ProcedureObject.Name.ToString() + " tetkik isteği mevcuttur!" + "\n  Laboratuvar İşlem Numarası: " + labProc.EpisodeAction.ID.Value.ToString(), 1);
            //                                    //                                        if (warningResult == "H")
            //                                    //                                        {
            //                                    //                                            duplicateControlList = null;
            //                                    //                                            throw new TTUtils.TTException("Tetkik istekten vazgeçildi.");
            //                                    //                                        }
            //                                    //                                        else
            //                                    //                                        {
            //                                    //                                            duplicateControlList.Add(labProc.ProcedureObject);
            //                                    //                                        }

            //                                    //TODO:ShowEdit!
            //                                    //LabPreviousResultNotificationForm labPreviousResultNotificationForm = new LabPreviousResultNotificationForm(labProc, ref proceed);
            //                                    //labPreviousResultNotificationForm.ShowDialog();
            //                                    //proceed = (bool)labPreviousResultNotificationForm.Tag;

            //                                    //if(!proceed)
            //                                    //{
            //                                    //    throw new TTUtils.TTException("Tetkik istekten vazgeçildi.");
            //                                    //}
            //                                }

            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //        }




            //        //duplicateControlList = null;
            //        //Tetkik branş kontrolü burada gerçekleşir...
            //        ControlLaboratoryTestBrans(_LaboratoryRequest, tempTestDefList);



            //        string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Aşağıdaki tetkikleri istediğinize emin misiniz?", sb.ToString(), 1);
            //        if (result == "H")
            //            throw new TTUtils.TTException("Tetkik ekleyiniz.");
            var a = 1;
            #endregion LaboratoryRequestRequestForm_ClientSidePostScript

        }

        #region LaboratoryRequestRequestForm_Methods
        public class ExtendedLabRequestInfo
        {
            public LaboratoryTestDefinition LabTestDef;
            public LaboratoryRequestFormTabDefinition LabTabDef;
        }

        public List<LaboratoryProcedure> tempTestList = new List<LaboratoryProcedure>();
        //public List<LaboratoryTestDefinition> tempTestDefList = new List<LaboratoryTestDefinition>();
        
        public TTGrid grid = new TTGrid();
        private Font labSelectedItemFont = new Font("Tahoma", 8);
        private Color labItemBackColor = Color.FromArgb(191, 219, 255);

        /// <summary>
        /// Seçilmiş olan panel'deki testleri istek olarak oluşturur.
        /// </summary>
        /// <param name="labReqTestDef"></param>
        /// <param name="labProcedure"></param>
        public void CreateTestsFromSelectedPanel( LaboratoryTestDefinition labReqTestDef, LaboratoryProcedure labProcedure)
        {
            //Tetkik İstem tarafından yonetılecek!
            //foreach (LaboratoryGridPanelTestDefinition panelTestDef in labReqTestDef.PanelTests)
            //{
            //    LaboratorySubProcedure subProcedure = new LaboratorySubProcedure(_LaboratoryRequest.ObjectContext);
            //    LaboratoryTestDefinition labSubReqTestDef = (LaboratoryTestDefinition)panelTestDef.LaboratoryTest;
            //    subProcedure.ProcedureObject = labSubReqTestDef;
            //    subProcedure.MasterResource = _LaboratoryRequest.MasterResource; //labReqTestDef.Departments[0].Department; //tanımdaki ilk bölümü alır
            //    subProcedure.FromResource = _LaboratoryRequest.FromResource;
            //    subProcedure.EpisodeAction = _EpisodeAction;
            //    subProcedure.Eligible = false; // Fatura'ya düşmez.
            //    labProcedure.LaboratorySubProcedures.Add(subProcedure);
            //}
            var a = 1;
        }

        /// <summary>
        /// Renklendirme yapar.
        /// </summary>
        /// <param name="isAlternatingItem"></param>
        /// <returns></returns>
        private System.Drawing.Color SetItemColor(bool isAlternatingItem)
        {
            if (isAlternatingItem)
                return Color.FromArgb(255, 160, 160, 160);  //System.Drawing.SystemColors.ControlDark; 
            else
                return Color.FromArgb(255, 227, 227, 227);  //System.Drawing.SystemColors.ControlLight;
        }
        

        /// <summary>
        /// İşaretli test kaldırılırken diğer testlerin bağımlıları arasında olup olmadığını kontrol eder.
        /// </summary>
        private string _message;
        private bool _goOn = true; //Check requestin sürekli çalışmasını engellemek için kullanılan dış kontrol değişkendir.
        

        /*
        private void LaboratoryListView_RestrictedTestItemCheckController(ListView lv,TTObjectContext thisContext,LaboratoryTestDefinition testDef,ItemCheckEventArgs e)
        {
            _message = "";
            _goOn = false;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                foreach(LaboratoryGridRestrictedTestDefiniton testRestricted in testDef.RestrictedTests)
                {
                    foreach(ListViewItem otherTestItem in lv.CheckedItems)
                    {
                        LaboratoryTestDefinition otherTest = (LaboratoryTestDefinition)thisContext.GetObject(new Guid(otherTestItem.Tag.ToString()), "LaboratoryTestDefinition");
                         if(testRestricted.LaboratoryTest == otherTest)
                         {
                            e.NewValue = CheckState.Unchecked;
                            otherTestItem.Checked = false;
                            string[] parameters = new string[] { testDef.Name, otherTest.Name };
                            _message += SystemMessage.GetMessage(120, parameters);
                         }
                         else if(otherTest.IsPanel == true && otherTest.RestrictedTests.Contains(testRestricted))
                         {
                            e.NewValue = CheckState.Unchecked;
                            otherTestItem.Checked = false;
                            string[] parameters = new string[] { testDef.Name, testRestricted.LaboratoryTest.Name };
                            _message += SystemMessage.GetMessage(123, parameters);
                         }
                    }
                }
                _goOn = true;
                InfoBox.Show(_message);
            }
            catch(Exception ex)
            {
                InfoBox.Show(ex.ToString());
            }
            finally
            {
                    Cursor.Current = Cursors.Default;
            }
        }
         */
        /// <summary>
        /// İsteği işaretleme esnasında çeşitli kontrollerden geçirir. Uygunluklarına göre işaretler veya kaldırır.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        /*
        private void CheckRequestOnItemCheck(object sender, ItemCheckEventArgs e)
        {
            if(_goOn == false) return;
            if(e.NewValue == CheckState.Unchecked)
                return;
            TTObjectContext thisContext = this._LaboratoryRequest.ObjectContext;
            LaboratoryTestDefinition testDef = null;
            ListView lv = sender as ListView;
            ListViewItem selectedTest = (ListViewItem)lv.Items[e.Index];
            
            if(selectedTest.Tag is Guid?)
            {
                Guid objId = (Guid)selectedTest.Tag;
                testDef = (LaboratoryTestDefinition)thisContext.GetObject(objId,"LaboratoryTestDefinition");
            }
            
            if(testDef.IsPassiveNow == true){
                e.NewValue = CheckState.Unchecked;
                TTVisual.InfoBox.Show(testDef.Name + " testi " + testDef.ReasonForPassive + " sebebiyle çalışılmamaktadır.");
                return;
            }
            
            if(testDef.IsDurationControl == true){
                if(!isTimeLimited(testDef)){
                    e.NewValue = CheckState.Unchecked;
                    return;
                }
            }
            
            if(testDef.IsSexControl == true && testDef.SexControl != this._EpisodeAction.Episode.Patient.Sex){
                e.NewValue = CheckState.Unchecked;
                if (testDef.SexControl == SexEnum.Male ){
                    string ex = "Bu test sadece erkek hastalar için istenebilir.";
                    TTVisual.InfoBox.Show(ex);
                    return;
                }
                else if (testDef.SexControl == SexEnum.Female){
                    string ex = "Bu test sadece kadın hastalar için istenebilir.";
                    TTVisual.InfoBox.Show(ex);
                    return;
                }
                else{
                    return;
                }
            }
            
            if(testDef.IsSat == true)
            {
                if(this._EpisodeAction.Episode.Patient.Sex == SexEnum.Female && this._LaboratoryRequest.LastMensturationDate == null)
                {
                    e.NewValue = CheckState.Unchecked;
                    string ex = "Bu test S.A.T. girmeden istenemez.";
                    TTVisual.InfoBox.Show(ex);
                    return;
                }
            }
            
            if(testDef.IsRestrictedTest == true){
                foreach(LaboratoryGridRestrictedTestDefiniton testRestricted in testDef.RestrictedTests){
                    foreach(ListViewItem otherTestItem in lv.CheckedItems){
                        LaboratoryTestDefinition otherTest = (LaboratoryTestDefinition)thisContext.GetObject(new Guid(otherTestItem.Tag.ToString()), "LaboratoryTestDefinition");
                        if(testRestricted.LaboratoryTest == otherTest){
                            e.NewValue = CheckState.Unchecked;
                            string ex = testDef.Name + "  ile  " + otherTest.Name + " birlikte istenemez..";
                            TTVisual.InfoBox.Show(ex);
                            return;
                        }else if(otherTest.IsPanel == true && otherTest.RestrictedTests.Contains(testRestricted)){
                            e.NewValue = CheckState.Unchecked;
                            string ex = testDef.Name + "  ile  " + testRestricted.LaboratoryTest.Name + " birlikte istenemez. İstek işareti kaldırıldı.";
                            TTVisual.InfoBox.Show(ex);
                            return;
                        }
                    }
                }
            }
            
            if(testDef.IsBoundedTest == true){
                
                LaboratoryListView_ItemCheckController(lv,thisContext,testDef);
            }
        }
         */


        private bool isTimeLimited(LaboratoryTestDefinition testDef)
        {
            //Tetkik İstem tarafından yonetılecek!
            //long limitAsDay = -1;
            //limitAsDay = testDef.DurationValue == null || testDef.DurationValue == 0 ? -1 : Convert.ToInt64(testDef.DurationValue.Value);

            //if (limitAsDay == -1)
            //    return true;

            //string patientID = this._LaboratoryRequest.Episode.Patient.ObjectID.ToString();
            //DateTime startDate = this._LaboratoryRequest.ActionDate.Value;
            //startDate = startDate.AddDays(ToNegative(limitAsDay));
            //DateTime endDate = this._LaboratoryRequest.ActionDate.Value;
            //string testID = testDef.ObjectID.ToString();
            //TTObjectContext thisContext = this._LaboratoryRequest.ObjectContext;
            ////IList sameTestRequestList = LaboratoryProcedure.GetLabTestByPatientByTestByDate(thisContext, patientID, testID, startDate, endDate);
            //BindingList<LaboratoryProcedure.GetLabProcByPatientByTestByDate_Class> sameTestRequestList = LaboratoryProcedure.GetLabProcByPatientByTestByDate(thisContext, patientID, testID, startDate, endDate, "");

            //if (sameTestRequestList.Count == 0)
            //    return true;


            //TODO:ShowEdit!
            //string formHeaderText = "Laboratuvar Tetkik Süre Kontrol Bildirimi";
            //string notificationText = "Seçilen tetkik daha önceden hastaya istenmiş.";
            //Guid theGuid = sameTestRequestList[0].ObjectID.HasValue ? sameTestRequestList[0].ObjectID.Value : Guid.Empty;
            //LabPreviousResultNotificationForm notificationForm = new LabPreviousResultNotificationForm(theGuid, formHeaderText, notificationText);
            //notificationForm.ShowDialog();

            /*
            string procedureDate = "";
            foreach (LaboratoryProcedure.GetLabProcByPatientByTestByDate_Class priorTest in sameTestRequestList)
            {
                procedureDate = priorTest.ProcedureDate.ToString();
                break;
            }
            //LaboratoryProcedure test = (LaboratoryProcedure)sameTestRequestList[0];
            //if(test.CurrentStateDefID == LaboratoryProcedure.States.Cancelled || test.CurrentStateDefID == LaboratoryProcedure.States.SampleReject)
            //    return true;
            //string ex = testDef.Name + " testi " + test.WorkListDate.ToString() + " tarihinde zaten istenmiş.";

            string[] parameters = new string[] { testDef.Name, procedureDate };
            String message = SystemMessage.GetMessage(125, parameters);
            TTVisual.InfoBox.Show(message);
             */
            return false;
        }

        public long ToNegative(long Number)
        {
            return Math.Abs(Number) * -1;
        }

        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            switch (e.KeyCode)
            {
                case Keys.F2:
                    OpenTestInfoForm(this, EventArgs.Empty);
                    break;
            }
        }
        /// <summary>
        /// Testlerin tanım ekranındaki görüntülerine ve oradaki bilgilere ulaşmasını sağlar. Tanım formunu açar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenTestInfoForm(object sender, EventArgs e)
        {
            //TODO:ShowEdit!
            //if (sender is LaboratoryRequestRequestForm)
            //{
            //    LaboratoryRequestRequestForm labForm = (LaboratoryRequestRequestForm)sender;
            //    TabPage page = (TabPage)labForm.tabTetkik.SelectedTab;
            //    foreach (Control control in page.Controls)
            //    {
            //        if (control is TTListView)
            //        {
            //            TTListView lv = (TTListView)control;
            //            foreach (TTListViewItem lvItem in lv.SelectedItems)
            //            {
            //                if (lvItem.Tag is Guid?)
            //                {
            //                    Guid objId = (Guid)lvItem.Tag;
            //                    TTObjectContext thisContext = this._LaboratoryRequest.ObjectContext;
            //                    LaboratoryTestDefinition testDef = (LaboratoryTestDefinition)thisContext.GetObject(objId, "LaboratoryTestDefinition");
            //                    TTDefinitionForm frm = TTDefinitionForm.GetEditForm(TTObjectDefManager.Instance.ListDefs["LaboratoryTestDefinitionList"]);
            //                    frm.ShowReadOnly(this.FindForm(), TTObjectDefManager.Instance.ListDefs["LaboratoryTestDefinitionList"], testDef,string.Empty);
            //                }
            //            }
            //        }
            //    }
            //}
            var a = 1;
        }

        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            //Tetkik İstem tarafından yonetılecek!

            //base.AfterContextSavedScript(transDef);
            //if (this._LaboratoryRequest.LaboratoryProcedures.Count == 0)
            //{
            //    String message = SystemMessage.GetMessage(198);
            //    throw new TTUtils.TTException(message);
            //}

            ////TODO:Cursor!
            ////Cursor current = Cursor.Current;
            ////Cursor.Current = Cursors.WaitCursor;
            //try
            //{
            //    string sysparam = TTObjectClasses.SystemParameter.GetParameterValue("LABINTEGRATED", null);
            //    if (sysparam == "TRUE")
            //    {
            //        //if (transDef != null && transDef.ToStateDefID == LaboratoryRequest.States.Procedure)
            //        if (transDef != null && transDef.ToStateDefID == LaboratoryRequest.States.RequestAcception)
            //        {
            //            Guid messageID = LaboratoryRequest.SendToLabASync(this._LaboratoryRequest); //Entegrasyon için.
            //            if (messageID != new Guid("{00000000-0000-0000-0000-000000000000}"))
            //            {
            //                TTObjectContext context = new TTObjectContext(false);
            //                LaboratoryRequest request = (LaboratoryRequest)context.GetObject(this._LaboratoryRequest.ObjectID, "LaboratoryRequest");
            //                request.MessageID = messageID.ToString();
            //                request.IsRequestSent = true;
            //                context.Save();
            //            }
            //        }
            //    }
            //}
            //catch
            //{
            //    try
            //    {
            //        string sysparam = TTObjectClasses.SystemParameter.GetParameterValue("LABINTEGRATED", null);
            //        if (sysparam == "TRUE")
            //        {
            //            //if (transDef != null && transDef.ToStateDefID == LaboratoryRequest.States.Procedure)
            //            if (transDef != null && transDef.ToStateDefID == LaboratoryRequest.States.RequestAcception)
            //            {
            //                Guid messageID = LaboratoryRequest.SendToLabASync(this._LaboratoryRequest); //Entegrasyon için.
            //                if (messageID != new Guid("{00000000-0000-0000-0000-000000000000}"))
            //                {
            //                    TTObjectContext context = new TTObjectContext(false);
            //                    LaboratoryRequest request = (LaboratoryRequest)context.GetObject(this._LaboratoryRequest.ObjectID, "LaboratoryRequest");
            //                    request.MessageID = messageID.ToString();
            //                    request.IsRequestSent = true;
            //                    context.Save();
            //                }
            //            }
            //        }
            //    }
            //    catch
            //    {
            //        throw;
            //    }
            //}
            //finally
            //{
            //    if(this._LaboratoryRequest.LaboratoryBinaryScanInfo != null)
            //    {
            //        Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            //        TTReportTool.PropertyCache<object> pc = new TTReportTool.PropertyCache<object>();
            //        pc.Add("VALUE", this._LaboratoryRequest.ObjectID.ToString());
            //        parameters.Add("TTOBJECTID", pc);
            //        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_LaboratoryBinaryScanInfoReport), true, 1, parameters);
            //    }

            //    if(this._LaboratoryRequest.LaboratoryTripleTestInfo != null)
            //    {
            //        Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            //        TTReportTool.PropertyCache<object> pc = new TTReportTool.PropertyCache<object>();
            //        pc.Add("VALUE", this._LaboratoryRequest.ObjectID.ToString());
            //        parameters.Add("TTOBJECTID", pc);
            //        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_LaboratoryTripleTestInfoReport), true, 1, parameters);
            //    }

            //    foreach(LaboratoryProcedure procedure in this._LaboratoryRequest.LaboratoryProcedures)
            //    {
            //        if (((LaboratoryTestDefinition)procedure.ProcedureObject).RequiresUreaBreathTestReport != null)
            //        {
            //            if (((LaboratoryTestDefinition)procedure.ProcedureObject).RequiresUreaBreathTestReport == true)
            //            {
            //                Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            //                TTReportTool.PropertyCache<object> pc = new TTReportTool.PropertyCache<object>();
            //                pc.Add("VALUE", this._LaboratoryRequest.ObjectID.ToString());
            //                parameters.Add("TTOBJECTID", pc);
            //                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_UreaBreathTestPatientInstructionReport), true, 1, parameters);
            //            }
            //        }
            //    }

            //TODO:Cursor!
            //Cursor.Current = current;

            var a = 1;
        
    }

        protected override void IfNullSelectMasterResource()
        {
            //Tetkik İstem tarafından yonetılecek!

            //if (this._EpisodeAction.MasterResource == null)
            //{
            //    if (Common.CurrentResource != null)
            //    {
            //        if (this._EpisodeAction.Episode != null)
            //        {
            //            Episode episode = this._EpisodeAction.Episode;
            //            // this._EpisodeAction.SetMasterResource(episode, false);

            //            if (this._EpisodeAction.MasterResource == null)
            //            {

            //                //ResSection masterResource = this.GetSelectedAcionDefualtMasterResource(this._EpisodeAction.ObjectContext, this._EpisodeAction.ActionType, "İşlemin Yapılacağı Birimi Seçiniz");
            //                //
            //                ResSection masterResource = null;

            //                List<ResSection> actionDMRList = EpisodeAction.AcionDefualtMasterResources(this._EpisodeAction.ObjectContext, this._EpisodeAction.ActionType, this._EpisodeAction);
            //                if (actionDMRList.Count > 0)
            //                {
            //                    MultiSelectForm mSItem = new MultiSelectForm();
            //                    foreach (ResSection resSection in actionDMRList)
            //                    {
            //                        if (!mSItem.IsItemExists(resSection.ObjectID.ToString()))
            //                        {
            //                            ResLaboratoryDepartment resLabDept = resSection as ResLaboratoryDepartment;
            //                            if (resLabDept != null)
            //                            {
            //                                //Muayene ekranından açılınca this._EpisodeAction.MenuDefinition null geldiğinden liste boş kalıyor ve birim seçilmedi
            //                                //hatası veriyordu. Kapatıldı, neden yazıldığıda anlaşılamadı MC
            //                                //                                            if (resLabDept.MenuDefinition != null && this._EpisodeAction.MenuDefinition != null)
            //                                //                                            {
            //                                //                                                if (resLabDept.MenuDefinition.ObjectID == this._EpisodeAction.MenuDefinition.ObjectID)
            //                                //                                                {
            //                                mSItem.AddMSItem(resSection.Name, resSection.ObjectID.ToString(), resSection);
            //                                //                                                }
            //                                //                                            }
            //                            }
            //                        }
            //                    }

            //                    string key = mSItem.GetMSItem(null, "İşlemin Yapılacağı Birimi Seçiniz", true, true, false, false, true, false);
            //                    if (!string.IsNullOrEmpty(key))
            //                    {
            //                        masterResource = (ResSection)mSItem.MSSelectedItemObject;
            //                    }
            //                    else
            //                    {
            //                        throw new TTUtils.TTException(SystemMessage.GetMessage(150));
            //                        //throw new Exception("İşlemin yapılacağı birim seçilmeden işleme devam edemezsiniz.");
            //                    }
            //                }

            //                //
            //                if (masterResource != null)
            //                {
            //                    this._EpisodeAction.MasterResource = masterResource;
            //                    return;
            //                }

            //            }

            //            if (this._EpisodeAction.FromResource != null)
            //            {
            //                ArrayList limitedMasterResourceTypeList = EpisodeAction.LimitedMasterResourceTypes(this._EpisodeAction);
            //                if (limitedMasterResourceTypeList.Count < 1 || limitedMasterResourceTypeList.Contains(this._EpisodeAction.FromResource.ObjectDef.Name))
            //                {
            //                    this._EpisodeAction.MasterResource = this._EpisodeAction.FromResource;
            //                    return;
            //                }
            //                else
            //                {
            //                    string[] hataParamList = new string[] { this._EpisodeAction.FromResource.Name };
            //                    throw new TTUtils.TTException(SystemMessage.GetMessage(149, hataParamList));
            //                    //throw new Exception("Bağlı olduğunuz " + this._EpisodeAction.FromResource + " birimi bu işlem için uygun değildir");
            //                }
            //            }
            //            else
            //            {
            //                throw new TTUtils.TTException(SystemMessage.GetMessage(145));
            //                // throw new Exception("Bağlı olduğunuz birimler, bu vakada  bu işlem yapmak için uygun değildir.");
            //            }
            //        }
            //        else
            //        {
            //            throw new TTUtils.TTException(SystemMessage.GetMessage(147));
            //            //throw new Exception("İşlemin bağlı olduğu vaka bulunamadı.İşleme devam edilemez.");
            //        }
            //    }
            //    else
            //    {
            //        throw new TTUtils.TTException(SystemMessage.GetMessage(148));
            //        //throw new Exception("Sistem kullanıcısı bulunamadı.İşleme devam edilemez.");
            //    }
            //}

            var a = 1;
        }
        static void SpeedingSave(LaboratoryRequest laboratoryRequest, Guid objId,LaboratoryTestDefinition labReqTestDef)
        {
            // Kaydetmeyi hızlandırmak için
            int i = labReqTestDef.Departments.Count;
            foreach (LaboratoryGridMaterialDefinition defMaterialGrid in labReqTestDef.Materials)
            {
                Material m = defMaterialGrid.Material;
            }
            if (labReqTestDef.IsPanel == true)
            {
                foreach (LaboratoryGridPanelTestDefinition panelTestDef in labReqTestDef.PanelTests)
                {
                    LaboratoryTestDefinition labSubReqTestDef = (LaboratoryTestDefinition)panelTestDef.LaboratoryTest;
                }
            }
            // Hızlandırma kodu sonu
        }
        
        
        
        /// <summary>
        /// İşaretlenmiş testlerin Laboratuvar isteği olarak eklenmesini sağlar.
        /// </summary>
        private void SetCheckedItemsAsRequestedProcedures()
        {
            //Tetkik İstem tarafından yonetılecek!
            ///*
            //foreach(LaboratoryProcedure proc in this._LaboratoryRequest.LaboratoryProcedures)
            //{
            //    proc.Materials.Clear();
            //    //foreach(LaboratoryProcedureResult result in proc.LaboratoryProcedureResults)
            //    //{
            //    //    result.RequestProcedures.Clear();
            //    //}
            //    //proc.LaboratoryProcedureResults.DeleteChildren(); //.DeleteChildren();
            //    proc.LaboratorySubProcedures.DeleteChildren();
            //    proc.AccountTransactions.Clear();
            //    proc.ChildSubActionProcedure.Clear();
            //    proc.PackageTransfer.Clear();
            //    proc.PackageTransferProtocolSubActionPackages.Clear();
            //    proc.PackageTransferProtocolSubActionProcedures.Clear();
            //    proc.PriceUpdatingProcedure.Clear();
            //    proc.PriceUpdatingProcedure.Clear();
            //    proc.SubActionMaterial.Clear();
            //    proc.TransferFromPackSubActProcs.Clear();
            //    proc.TreatmentMaterials.Clear();
            //    proc.UsedMaterials.Clear();
            //}

            //this._LaboratoryRequest.LaboratoryProcedures.DeleteChildren();
            // */

            //foreach (ExtendedLabRequestInfo labReqInfo in tempTestDefList)
            //{
            //    LaboratoryTestDefinition labTestDef = (LaboratoryTestDefinition)labReqInfo.LabTestDef;
            //    if (labTestDef.Departments.Count == 0)
            //        throw new Exception("Laboratuvar Tetkik Tanım Formunda ilgili Bölüm bilgisi bulunamadı! Bölüm ekleyiniz!");
            //    LaboratoryProcedure newLabProcedure = new LaboratoryProcedure(_LaboratoryRequest.ObjectContext);
            //    newLabProcedure.ProcedureObject = labTestDef;
            //    newLabProcedure.MasterResource = _LaboratoryRequest.MasterResource; //labTestDef.Departments[0].Department; //tanımdaki ilk bölümü alır
            //    newLabProcedure.FromResource = _LaboratoryRequest.FromResource;
            //    newLabProcedure.EpisodeAction = _EpisodeAction;
            //    newLabProcedure.Amount = labTestDef.PriceCoefficient == null ? 1 : labTestDef.PriceCoefficient;
            //    newLabProcedure.RequestedTab = labReqInfo.LabTabDef;

            //    foreach (LaboratoryGridMaterialDefinition defMaterialGrid in labTestDef.Materials)
            //    {
            //        LaboratoryMaterial labMaterial = new LaboratoryMaterial(_LaboratoryRequest.ObjectContext);
            //        labMaterial.Amount = 1;
            //        labMaterial.Material = defMaterialGrid.Material;
            //        labMaterial.EpisodeAction = _EpisodeAction;
            //        newLabProcedure.Materials.Add(labMaterial);
            //    }

            //    if (labTestDef.IsPanel == true)
            //        CreateTestsFromSelectedPanel( labTestDef, newLabProcedure);

            //    if (!_LaboratoryRequest.LaboratoryProcedures.Contains(newLabProcedure))
            //        _LaboratoryRequest.LaboratoryProcedures.Add(newLabProcedure);
            //}
            ///*
            //foreach(Guid testID in tempTestGuidList)
            //{
            //    LaboratoryProcedure newLabProcedure = new LaboratoryProcedure(thisContext);
            //    LaboratoryTestDefinition labTestDef = (LaboratoryTestDefinition)thisContext.GetObject(testID,typeof(LaboratoryTestDefinition));
            //    if(labTestDef.Departments.Count == 0)
            //        throw new Exception("Laboratuvar Tetkik Tanım Formunda ilgili Bölüm bilgisi bulunamadı! Bölüm ekleyiniz!");
            //    newLabProcedure.ProcedureObject = labTestDef;
            //    newLabProcedure.MasterResource = this._LaboratoryRequest.MasterResource; //labTestDef.Departments[0].Department; //tanımdaki ilk bölümü alır
            //    newLabProcedure.FromResource = this._LaboratoryRequest.FromResource;
            //    newLabProcedure.EpisodeAction = this._EpisodeAction;
            //    newLabProcedure.Amount = labTestDef.PriceCoefficient == null ? 1 : labTestDef.PriceCoefficient;

            //    foreach(LaboratoryGridMaterialDefinition defMaterialGrid in labTestDef.Materials)
            //    {
            //        LaboratoryMaterial labMaterial = new LaboratoryMaterial(thisContext);
            //        labMaterial.Amount = 1;
            //        labMaterial.Material = defMaterialGrid.Material;
            //        labMaterial.EpisodeAction = this._EpisodeAction;
            //        newLabProcedure.Materials.Add(labMaterial);
            //    }

            //    if(labTestDef.IsPanel == true)
            //        CreateTestsFromSelectedPanel(labTestDef,newLabProcedure);

            //    if(!this._LaboratoryRequest.LaboratoryProcedures.Contains(newLabProcedure))
            //        this._LaboratoryRequest.LaboratoryProcedures.Add(newLabProcedure);
            //}
            // */
            //foreach (TabPage page in tabTetkik.TabPages)
            //{
            //    if (page.Name == "AllTests")
            //    {
            //        foreach (Control control in page.Controls)
            //        {
            //            if (control is TTGrid)
            //            {
            //                TTGrid grd = (TTGrid)control;
            //                foreach (DataGridViewRow row in grd.Rows)
            //                {
            //                    if (row.Cells[0].Value != null)
            //                    {
            //                        string objId = row.Cells[0].Value.ToString();

            //                        LaboratoryTestDefinition labReqTestDef = (LaboratoryTestDefinition)_LaboratoryRequest.ObjectContext.GetObject(new Guid(objId), "LaboratoryTestDefinition");
            //                        if (labReqTestDef.Departments.Count == 0)
            //                            throw new Exception("Laboratuvar Tetkik Tanım Formunda ilgili Bölüm bilgisi bulunamadı! Bölüm ekleyiniz!");
            //                        LaboratoryProcedure labProcedure = new LaboratoryProcedure(_LaboratoryRequest.ObjectContext);
            //                        labProcedure.ProcedureObject = labReqTestDef;
            //                        labProcedure.MasterResource = _LaboratoryRequest.MasterResource; //labReqTestDef.Departments[0].Department; //tanımdaki ilk bölümü alır
            //                        labProcedure.FromResource = _LaboratoryRequest.FromResource;
            //                        labProcedure.EpisodeAction = _EpisodeAction;
            //                        labProcedure.Amount = labReqTestDef.PriceCoefficient == null ? 1 : labReqTestDef.PriceCoefficient;

            //                        foreach (LaboratoryGridMaterialDefinition defMaterialGrid in labReqTestDef.Materials)
            //                        {
            //                            LaboratoryMaterial labMaterial = new LaboratoryMaterial(_LaboratoryRequest.ObjectContext);
            //                            labMaterial.Amount = 1;
            //                            labMaterial.Material = defMaterialGrid.Material;
            //                            labMaterial.EpisodeAction = _EpisodeAction;
            //                            labProcedure.Materials.Add(labMaterial);
            //                        }

            //                        //CheckRequest(labReqTestDef,lvItem);

            //                        if (labReqTestDef.IsPanel == true)
            //                            CreateTestsFromSelectedPanel(labReqTestDef, labProcedure);

            //                        if (!_LaboratoryRequest.LaboratoryProcedures.Contains(labProcedure))
            //                            _LaboratoryRequest.LaboratoryProcedures.Add(labProcedure);
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}   
            var a = 1;        
        }


        static void ControlLaboratoryTestBrans(LaboratoryRequest laboratoryRequest, List<ExtendedLabRequestInfo> tempTestDefList)
        {
            //duplicateControlList = null;
            //Tetkik branş kontrolü burada gerçekleşir...


            //TODO: Asagidaki kontrol PBS modulundeki BranchGrid objesinden yapiliyor. PBS kaldirildigi icin testin brans kontrolu icin farkli bir tasarim yapilarak kontrol edilmeli. 
            /*if(laboratoryRequest.Episode.PatientStatus != PatientStatusEnum.Inpatient) //Yatan hastada branş kontrolünün çalışmaması istendi.
            {
                
                bool requestOK = false;
                foreach (ExtendedLabRequestInfo labProc in tempTestDefList)
                {
                    requestOK = false;
                    
                    if(((LaboratoryTestDefinition)labProc.LabTestDef).BranchGrid != null && ((LaboratoryTestDefinition)labProc.LabTestDef).BranchGrid.Count > 0)
                    {
                        foreach (BranchGrid branchGrid in ((LaboratoryTestDefinition)labProc.LabTestDef).BranchGrid)
                        {
                            if (laboratoryRequest.Episode.MainSpeciality.Code == branchGrid.Specialities.Code)
                            {
                                requestOK = true;
                                break;
                            }
                            
                        }
                    }
                    else
                    {
                        requestOK = true;
                    }
                    
                    if(!requestOK)
                    {
                        string notification = "";
                        foreach (BranchGrid branchTemp in ((LaboratoryTestDefinition)labProc.LabTestDef).BranchGrid)
                        {
                            notification += branchTemp.Specialities.Name + "\r\n";
                        }
                        throw new TTUtils.TTException("Hasta vakasının uzmanlık dalı: '" + laboratoryRequest.Episode.MainSpeciality.Name+"'\r\n"
                                                      +"\r\n'"+labProc.LabTestDef.Name + "' tetkik isteğinde yetkili uzmanlık dalları:\r\n"
                                                      + notification +"\r\n\n"
                                                      +"Listelenen yetkili uzmanlık bölümlerinden uygun olan seçenek için 'Konsültasyon' işlem isteği başlatınız.\r\n"
                                                      + "Yeni Süreç >> Prosedürler >> Konsültasyon/Dış Tetkik İstek >> Diğer Birim(ler)den Konsültasyon\r\n"
                                                      +"işlem adımlarını takip ederek 'Konsültasyon' isteği başlatabilirsiniz.");
                    }
                    
                }
            }
            */
            var a = 1;
        }
        
        #endregion LaboratoryRequestRequestForm_Methods

        #region LaboratoryRequestRequestForm_ClientSideMethods
        public List<ExtendedLabRequestInfo> tempTestDefList = new List<ExtendedLabRequestInfo>();
        public List<Guid> tempTestGuidList = new List<Guid>();
          /// <summary>
        /// ListView içerisindeki işaretlenmiş olanlarını geçici bir listede tutar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCheckedItemToTempList(object sender, ItemCheckEventArgs e)
        {
            //Tetkik İstem tarafından yonetılecek!

            //LaboratoryTestDefinition labReqTestDef = null;
            //TTListView lv = sender as TTListView;
            //ITTListViewItem selectedTest = lv.Items[e.Index];
            //Guid objId = (Guid)selectedTest.Tag;
            //TTObjectContext thisContext = this._LaboratoryRequest.ObjectContext;
            //labReqTestDef = (LaboratoryTestDefinition)thisContext.GetObject(objId, "LaboratoryTestDefinition");
            //SpeedingSave(this._LaboratoryRequest, objId, labReqTestDef);

            //ExtendedLabRequestInfo labRequestInfo = new ExtendedLabRequestInfo();
            //labRequestInfo.LabTestDef = labReqTestDef;
            //TabPage tabPage = lv.Parent as TabPage;
            //if (tabPage != null)
            //    labRequestInfo.LabTabDef = (LaboratoryRequestFormTabDefinition)tabPage.Tag;

            //if (e.NewValue == CheckState.Unchecked)
            //{
            //    bool canRemoveCheck = false;
            //    canRemoveCheck = LaboratoryListView_BoundedTestItemRemoveController(tempTestDefList, this._LaboratoryRequest.ObjectContext, labReqTestDef);
            //    if (canRemoveCheck == false)
            //    {
            //        e.NewValue = CheckState.Checked;
            //    }
            //    else
            //    {
            //        if (tempTestGuidList.Contains(labReqTestDef.ObjectID))
            //            tempTestGuidList.Remove(labReqTestDef.ObjectID);
            //        //if(tempTestDefList.Contains(labRequestInfo))
            //        //    tempTestDefList.Remove(labRequestInfo);
            //        ExtendedLabRequestInfo testToBeRemoved = null;
            //        foreach (ExtendedLabRequestInfo info in tempTestDefList)
            //        {
            //            if (info.LabTestDef == labRequestInfo.LabTestDef && info.LabTabDef == labRequestInfo.LabTabDef)
            //                testToBeRemoved = info;
            //        }
            //        if (testToBeRemoved != null)
            //            tempTestDefList.Remove(testToBeRemoved);
            //        //selectedTest.BackColor = SystemColors.Window;
            //        return;
            //    }
            //}
            //else
            //{

            //    CheckRequest(labReqTestDef, lv, selectedTest, e);

            //    /*
            //        if(labReqTestDef.IsPanel == true)
            //            CreateTestsFromSelectedPanel(labReqTestDef,labProcedure);
            //     */

            //    if (!tempTestGuidList.Contains(labReqTestDef.ObjectID) && e.NewValue == CheckState.Checked)
            //    {
            //        tempTestGuidList.Add(labReqTestDef.ObjectID);
            //        //selectedTest.BackColor = labItemBackColor;
            //        //selectedTest.Font = labSelectedItemFont;
            //    }
            //    if (!tempTestDefList.Contains(labRequestInfo) && e.NewValue == CheckState.Checked)
            //    {
            //        tempTestDefList.Add(labRequestInfo);
            //        //selectedTest.BackColor = labItemBackColor;
            //        //selectedTest.Font = labSelectedItemFont;
            //    }
            //}

            //İkili Tarama ve Triple Test Formları
            //TODO:ShowEdit!
            //if (this._LaboratoryRequest.LaboratoryBinaryScanInfo == null)
            //{
            //    if(labReqTestDef.RequiresBinaryScanForm == true)
            //    {
            //        LaboratoryBinaryScanForm binaryScanForm = new LaboratoryBinaryScanForm(this._LaboratoryRequest);
            //        binaryScanForm.ShowDialog();
            //    }
            //}
            //else
            //{
            //    if(labReqTestDef.RequiresBinaryScanForm == true)
            //    {
            //        LaboratoryBinaryScanForm binaryScanForm = new LaboratoryBinaryScanForm(this._LaboratoryRequest,this._LaboratoryRequest.LaboratoryBinaryScanInfo);
            //        binaryScanForm.ShowDialog();
            //    }
            //}

            //if(this._LaboratoryRequest.LaboratoryTripleTestInfo == null)
            //{
            //    if(labReqTestDef.RequiresTripleTestForm == true)
            //    {
            //        LaboratoryTripleTestForm tripleTestForm = new LaboratoryTripleTestForm(this._LaboratoryRequest);
            //        tripleTestForm.ShowDialog();
            //    }
            //}
            //else
            //{
            //    if(labReqTestDef.RequiresTripleTestForm == true)
            //    {
            //        LaboratoryTripleTestForm tripleTestForm = new LaboratoryTripleTestForm(this._LaboratoryRequest,this._LaboratoryRequest.LaboratoryTripleTestInfo);
            //        tripleTestForm.ShowDialog();
            //    }
            //}


            var a = 1;

        }
  
       /// <summary>
        /// Tanımlardan alarak Laboratuvar Testleri kısmının düzenli olarak (ilgili sekmeler halinde) oluşturulmasını sağlar.
        /// </summary>
        public void GenerateLaboratoryTabs()
        {
            //Tetkik İstem tarafından yonetılecek!
            //bool isAlternatingItem = false;
            //TTObjectContext thisContext = this._LaboratoryRequest.ObjectContext;

            //BindingList<LaboratoryRequestFormTabDefinition> liste = LaboratoryRequestFormTabDefinition.GetLabTabs(thisContext, " AND (LABORATORYDEPARTMENT = '" + this._LaboratoryRequest.MasterResource.ObjectID.ToString() + "' OR LABORATORYDEPARTMENT IS NULL) ORDER BY TABORDER");

            //if (liste.Count > 0)
            //{
            //    foreach (LaboratoryRequestFormTabDefinition tabDef in liste)
            //    {
            //        TTTabPage tabPage = new TTTabPage();
            //        tabPage.Name = tabDef.Name;
            //        tabPage.Text = tabDef.Name;
            //        tabPage.Tag = tabDef;

            //        TTListView listView = new TTListView();
            //        TTListViewColumn listViewColumn = new TTListViewColumn();
            //        listViewColumn.Text = "Testler";
            //        listViewColumn.Width = -1;
            //        listView.Columns.Add(listViewColumn);

            //        listView.Name = "ListView";
            //        listView.View = View.List;
            //        listView.CheckBoxes = true;
            //        listView.FullRowSelect = true;
            //        //listView.Dock = DockStyle.Fill;
            //        //listView.BorderStyle = BorderStyle.None;
            //        //listView.BackColor = System.Drawing.Color.FromArgb(191, 219, 255);
            //        //listView.ItemCheck += new ItemCheckEventHandler(CheckRequestOnItemCheck);
            //        listView.ItemCheck += new ItemCheckEventHandler(this.AddCheckedItemToTempList);


            //        BindingList<LaboratoryTabNamesGrid.GetByTabs_Class> grids = LaboratoryTabNamesGrid.GetByTabs(thisContext, tabDef.ObjectID.ToString());
            //        foreach (LaboratoryTabNamesGrid.GetByTabs_Class tabGrid in grids)
            //        {

            //            isAlternatingItem = !isAlternatingItem;
            //            TTListViewItem item2 = new TTListViewItem();
            //            item2.Name = tabGrid.Testname;
            //            item2.Text = tabGrid.Testname + " " + tabGrid.TabDescription;
            //            //item2.Font = new Font("Tahoma", 8);
            //            item2.Tag = tabGrid.Testdefid;
            //            if (tabGrid.IsPassiveNow == true)
            //            {
            //                item2.ForeColor = Color.FromArgb(255, 109, 109, 109);  //System.Drawing.SystemColors.GrayText;
            //            }
            //            else
            //            {
            //                if (this._LaboratoryRequest.LaboratoryProcedures.Count > 0) //already has LaboratoryProcedures
            //                {
            //                    foreach (LaboratoryProcedure labProc in this._LaboratoryRequest.LaboratoryProcedures)
            //                    {
            //                        if (tabGrid.Testdefid == ((LaboratoryTestDefinition)labProc.ProcedureObject).ObjectID)
            //                        {
            //                            item2.Checked = true;

            //                        }
            //                    }
            //                }
            //            }
            //            if (tabGrid.IsSubTest != true)
            //                listView.Items.Add(item2);
            //        }
            //        tabPage.Controls.Add(listView);
            //        tabTetkik.TabPages.Add(tabPage);
            //    }
            //}
            //Bütün Tetkikler Tabı
            /*
            TTTabPage tabPageAll = new TTTabPage();
            tabPageAll.Name = "AllTests";
            tabPageAll.Text = "Tüm Tetkikler";
            grid.DataMember = "LaboratoryTests";
            
            TTListBoxColumn testColumn = new TTListBoxColumn();
            testColumn.Name = "ProcedureObject";
            testColumn.HeaderText = "Tetkik";
            testColumn.DataMember = "PROCEDUREOBJECT";
            
            testColumn.ListDefName = "LaboratoryNotSubTestListDefinition";
            testColumn.Width = 300;
            
            grid.Columns.Add(testColumn);
            grid.Dock = DockStyle.Fill;
            
            tabPageAll.Controls.Add(grid);
            tabTetkik.TabPages.Add(tabPageAll);
             */
            var a = 1;
        }

        private bool LaboratoryListView_BoundedTestItemRemoveController(List<ExtendedLabRequestInfo> tempTestDefList, TTObjectContext thisContext, LaboratoryTestDefinition testDef)
        {
            //Tetkik İstem tarafından yonetılecek!
            //foreach (ExtendedLabRequestInfo labInfo in tempTestDefList)
            //{
            //    if (labInfo.LabTestDef.IsBoundedTest == true)
            //    {
            //        foreach (LaboratoryGridBoundedTestDefinition testBounded in labInfo.LabTestDef.BoundedTests)
            //        {
            //            if (testDef.ObjectID == testBounded.LaboratoryTest.ObjectID)
            //            {
            //                InfoBox.Show(testDef.Name.ToString() + " testi, " + testBounded.LaboratoryTest.Name.ToString() + " testi ile birlikte istenmelidir.");
            //                return false;
            //            }
            //        }
            //    }
            //}
            return true;
        }
         
           /// <summary>
        /// İsteği çeşitli kontrollerden geçirir. Uygunluklarına göre işaretler veya kaldırır.
        /// </summary>
        /// <param name="testDef"></param>
        /// <param name="testItem"></param>
        private void CheckRequest(LaboratoryTestDefinition testDef, ITTListView lv, ITTListViewItem testItem, ItemCheckEventArgs e)
        {
            //Tetkik İstem tarafından yonetılecek!
            //if (e.NewValue == CheckState.Unchecked)
            //{
            //    return;
            //}
            //if (_goOn == false) return;

            //TTObjectContext thisContext = this._LaboratoryRequest.ObjectContext;
            ////ListView lv = testItem.ListView;

            //if (testDef.IsPassiveNow == true)
            //{
            //    TTVisual.InfoBox.Show(testDef.Name + " testi " + testDef.ReasonForPassive + " sebebiyle çalışılmamaktadır.");
            //    e.NewValue = CheckState.Unchecked;
            //    return;
            //}

            //if (testDef.IsDurationControl == true && this._LaboratoryRequest.Episode.PatientStatus == PatientStatusEnum.Outpatient)
            //{
            //    if (!isTimeLimited(testDef))
            //    {
            //        e.NewValue = CheckState.Unchecked;
            //        return;
            //    }
            //}


            //if (testDef.IsSexControl == true && testDef.SexControl != this._EpisodeAction.Episode.Patient.Sex && this._EpisodeAction.Episode.Patient.Sex != SexEnum.Unidentified)
            //{
            //    e.NewValue = CheckState.Unchecked;

            //    if (testDef.SexControl == SexEnum.Male)
            //    {
            //        string ex = "Bu test sadece erkek hastalar için istenebilir.";
            //        TTVisual.InfoBox.Show(ex);
            //    }

            //    if (testDef.SexControl == SexEnum.Female)
            //    {
            //        string ex = "Bu test sadece kadın hastalar için istenebilir.";
            //        TTVisual.InfoBox.Show(ex);
            //    }
            //}

            //if (testDef.IsSat == true)
            //{
            //    if (this._EpisodeAction.Episode.Patient.Sex == SexEnum.Female && this._LaboratoryRequest.LastMensturationDate == null)
            //    {
            //        e.NewValue = CheckState.Unchecked;
            //        String message = SystemMessage.GetMessage(106);
            //        TTVisual.InfoBox.Show(message);
            //    }
            //}

            //if (testDef.IsRestrictedTest == true)
            //{
            //    foreach (LaboratoryGridRestrictedTestDefiniton testRestricted in testDef.RestrictedTests)
            //    {
            //        foreach (TTListViewItem otherTestItem in ((ListView)lv).CheckedItems) 
            //        {
            //            LaboratoryTestDefinition otherTest = (LaboratoryTestDefinition)thisContext.GetObject(new Guid(otherTestItem.Tag.ToString()), "LaboratoryTestDefinition");
            //            if (testRestricted.LaboratoryTest == otherTest)
            //            {
            //                e.NewValue = CheckState.Unchecked;
            //                testItem.Checked = false;
            //                string[] parameters = new string[] { testDef.Name, otherTest.Name };
            //                String message = SystemMessage.GetMessage(120, parameters);
            //                TTVisual.InfoBox.Show(message);
            //            }
            //            else if (otherTest.IsPanel == true && otherTest.RestrictedTests.Contains(testRestricted))
            //            {
            //                e.NewValue = CheckState.Unchecked;
            //                testItem.Checked = false;
            //                string[] parameters = new string[] { testDef.Name, testRestricted.LaboratoryTest.Name };
            //                String message = SystemMessage.GetMessage(123, parameters);
            //                TTVisual.InfoBox.Show(message);
            //            }
            //        }
            //    }
            //}

            //if (testDef.IsBoundedTest == true)
            //{
            //    LaboratoryListView_BoundedTestItemCheckController(lv, thisContext, testDef);
            //}
            var a = 1;
        }

        /// <summary>
        /// Bounded testleri kontrol eder ve gerekli şartları sağlayan testlere işaret ekler.
        /// </summary>
        private void LaboratoryListView_BoundedTestItemCheckController(ITTListView lv, TTObjectContext thisContext, LaboratoryTestDefinition testDef)
        {
            //Tetkik İstem tarafından yonetılecek!

            //_message = "";
            //_goOn = false;

            ////TODO:Cursor!
            ////Cursor.Current = Cursors.WaitCursor;

            //try
            //{
            //    foreach (LaboratoryGridBoundedTestDefinition testBounded in testDef.BoundedTests)
            //    {
            //        foreach (TTListViewItem otherTest in lv.Items)
            //        {
            //            LaboratoryTestDefinition otherTestDef = (LaboratoryTestDefinition)thisContext.GetObject(new Guid(otherTest.Tag.ToString()), "LaboratoryTestDefinition");
            //            if (!otherTest.Checked && (testBounded.LaboratoryTest.ObjectID == otherTestDef.ObjectID))
            //            {
            //                _message += testDef.Name.ToString() + " testi, " + testBounded.LaboratoryTest.Name.ToString() + " testi ile birlikte istenmelidir. İstek olarak işaretlendi. \r\n";
            //                otherTest.Checked = true;
            //                break;
            //            }
            //        }
            //    }
            //    _goOn = true;
            //    InfoBox.Show(_message);
            //}
            //catch (Exception ex)
            //{
            //    InfoBox.Show(ex.ToString());
            //}
            //finally
            //{
            //    //TODO:Cursor!
            //    //Cursor.Current = Cursors.Default;
            //}
            var a = 1;
        }

        #endregion LaboratoryRequestRequestForm_ClientSideMethods
    }
}