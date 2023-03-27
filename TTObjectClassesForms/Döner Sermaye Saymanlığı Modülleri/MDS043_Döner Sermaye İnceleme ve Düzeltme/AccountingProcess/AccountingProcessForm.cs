
//using System;
//using System.Xml;
//using System.Data;
//using System.Text;
//using System.Drawing;
//using System.Reflection;
//using System.Collections;
//using System.Linq;
//using System.ComponentModel;
//using System.Collections.Generic;
//using System.Runtime.Serialization;
//using System.Collections.ObjectModel;
//using System.Runtime.InteropServices;

//using TTUtils;
//using TTObjectClasses;
//using TTDataDictionary;
//using TTCoreDefinitions;
//using TTConnectionManager;
//using TTInstanceManagement;
//using TTDefinitionManagement;
//using TTStorageManager.Security;

//using SmartCardWrapper;

//using TTStorageManager;
//using System.Runtime.Versioning;
//using System.Windows.Forms;
//using TTVisual;
//namespace TTFormClasses
//{
//    /// <summary>
//    /// Döner Sermaye İnceleme ve Düzeltme
//    /// </summary>
//    public partial class AccountingProcessForm : TTForm
//    {
//        override protected void BindControlEvents()
//        {
//            CreateOrUpadateSubEpisode.Click += new TTControlEventDelegate(CreateOrUpadateSubEpisode_Click);
//            NEWPRICINGLISTMULTIPLIER.SelectedIndexChanged += new TTControlEventDelegate(NEWPRICINGLISTMULTIPLIER_SelectedIndexChanged);
//            NEWSTATUS.SelectedIndexChanged += new TTControlEventDelegate(NEWSTATUS_SelectedIndexChanged);
//            NEWSUBEPISODE.SelectedObjectChanged += new TTControlEventDelegate(NEWSUBEPISODE_SelectedObjectChanged);
//            NEWSHARE.SelectedIndexChanged += new TTControlEventDelegate(NEWSHARE_SelectedIndexChanged);
//            NEWDATE.ValueChanged += new TTControlEventDelegate(NEWDATE_ValueChanged);
//            OLDSUBEPISODE.SelectedObjectChanged += new TTControlEventDelegate(OLDSUBEPISODE_SelectedObjectChanged);
//            GRIDProcedures.CellValueChanged += new TTGridCellEventDelegate(GRIDProcedures_CellValueChanged);
//            GRIDPackages.CellValueChanged += new TTGridCellEventDelegate(GRIDPackages_CellValueChanged);
//            SubEpisodesGrid.CellValueChanged += new TTGridCellEventDelegate(SubEpisodesGrid_CellValueChanged);
//            SubEpisodesGrid.CellContentClick += new TTGridCellEventDelegate(SubEpisodesGrid_CellContentClick);
//            MedulaProvisionsGrid.CellContentClick += new TTGridCellEventDelegate(MedulaProvisionsGrid_CellContentClick);
//            GetActionsBtn.Click += new TTControlEventDelegate(GetActionsBtn_Click);
//            GridEpisodeProtocols.CellContentClick += new TTGridCellEventDelegate(GridEpisodeProtocols_CellContentClick);
//            base.BindControlEvents();
//        }

//        override protected void UnBindControlEvents()
//        {
//            CreateOrUpadateSubEpisode.Click -= new TTControlEventDelegate(CreateOrUpadateSubEpisode_Click);
//            NEWPRICINGLISTMULTIPLIER.SelectedIndexChanged -= new TTControlEventDelegate(NEWPRICINGLISTMULTIPLIER_SelectedIndexChanged);
//            NEWSTATUS.SelectedIndexChanged -= new TTControlEventDelegate(NEWSTATUS_SelectedIndexChanged);
//            NEWSUBEPISODE.SelectedObjectChanged -= new TTControlEventDelegate(NEWSUBEPISODE_SelectedObjectChanged);
//            NEWSHARE.SelectedIndexChanged -= new TTControlEventDelegate(NEWSHARE_SelectedIndexChanged);
//            NEWDATE.ValueChanged -= new TTControlEventDelegate(NEWDATE_ValueChanged);
//            OLDSUBEPISODE.SelectedObjectChanged -= new TTControlEventDelegate(OLDSUBEPISODE_SelectedObjectChanged);
//            GRIDProcedures.CellValueChanged -= new TTGridCellEventDelegate(GRIDProcedures_CellValueChanged);
//            GRIDPackages.CellValueChanged -= new TTGridCellEventDelegate(GRIDPackages_CellValueChanged);
//            SubEpisodesGrid.CellValueChanged -= new TTGridCellEventDelegate(SubEpisodesGrid_CellValueChanged);
//            SubEpisodesGrid.CellContentClick -= new TTGridCellEventDelegate(SubEpisodesGrid_CellContentClick);
//            MedulaProvisionsGrid.CellContentClick -= new TTGridCellEventDelegate(MedulaProvisionsGrid_CellContentClick);
//            GetActionsBtn.Click -= new TTControlEventDelegate(GetActionsBtn_Click);
//            GridEpisodeProtocols.CellContentClick -= new TTGridCellEventDelegate(GridEpisodeProtocols_CellContentClick);
//            base.UnBindControlEvents();
//        }

//        private void CreateOrUpadateSubEpisode_Click()
//        {
//#region AccountingProcessForm_CreateOrUpadateSubEpisode_Click
//   TTObjectContext objectContext =new TTObjectContext(false);
//            Episode episode =this._AccountingProcess.Episode;
//            BindingList<EpisodeAction> eaList = EpisodeAction.GetByEpisodeOrderByRequestDate(objectContext,episode.ObjectID);
//            bool firstEA = true;
//            foreach (EpisodeAction ea in eaList)
//            {
//                if(!(firstEA == true))
//                {
//                    ea.IgnoreEpisodeStateOnUpdate = true;
//                    if(ea.CurrentStateDef.Status != StateStatusEnum.Cancelled )
//                    {
//                        if(ea.IsAttributeExists(typeof(CreateSubEpisodeAttribute)) || firstEA) // eğer kendisi  yeni sub episode açacaksa
//                        {
//                            // CreateSubEpisodeAttribute
//                            Boolean createSubEpisode = true;
//                            // hasta kabul düzeltmede starterEpisode boş gelir yeni subepisode açılmaz
//                            if (ea != null )
//                            {
//                                if(ea.CurrentStateDef.Status == StateStatusEnum.Cancelled) // Cancel Objelerde Property Set edilebildiğinde silisin
//                                    createSubEpisode = false;
//                                if (ea.SubEpisode != null && ea.SubEpisode.CurrentStateDefID != SubEpisode.States.Cancelled)
//                                {
//                                    if (ea is InPatientTreatmentClinicApplication)// Aynı episodedaki diğer SubEpisodları kapatır.
//                                    {
//                                        SubEpisode LastOpenSub=null;
                                        
//                                        foreach (SubEpisode subOldEpisode in ea.Episode.SubEpisodes)
//                                        {
//                                            if(ea.SubEpisode== null || ea.SubEpisode.ObjectID != subOldEpisode.ObjectID)
//                                            {
//                                                if (subOldEpisode.OpeningDate < ea.RequestDate && subOldEpisode.CurrentStateDefID == SubEpisode.States.Opened)
//                                                {
//                                                    subOldEpisode.CurrentStateDefID = SubEpisode.States.Closed;
//                                                    if(subOldEpisode.ClosingDate == null)
//                                                        subOldEpisode.ClosingDate = ea.RequestDate;
//                                                    LastOpenSub = subOldEpisode;
//                                                }
                                                
//                                            }
//                                        }
//                                        if(ea.SubEpisode.OldSubEpisode == null)
//                                            ea.SubEpisode.OldSubEpisode= LastOpenSub;
//                                    }
//                                    createSubEpisode = false;// işlem geri alındı ve ilerletiliyorsa ve daha önce SubEpisodeu atandıysa tekrar atnamamsı için
//                                }
                                
//                                if (createSubEpisode)
//                                {
//                                    // Set edilme sıraları önemli
//                                    SubEpisode subEpisode = new SubEpisode(objectContext);
//                                    subEpisode.OldSubEpisode = ea.GetMyProperOpenedSubEpisode();// Cancel durumları için eğer varsa bir önceki Subepisodeu set eder o yüzden subEpisodun Episodu set edilmedien önce set edilmeli
//                                    SubEpisode LastOpenSub=null;
//                                    if (ea is InPatientTreatmentClinicApplication)// Aynı episodedaki diğer SubEpisodları kapatır.
//                                    {
                                        
//                                        foreach (SubEpisode subOldEpisode in ea.Episode.SubEpisodes)
//                                        {
//                                            if(ea.SubEpisode== null || ea.SubEpisode.ObjectID != subOldEpisode.ObjectID)
//                                            {
//                                                if (subOldEpisode.OpeningDate < ea.RequestDate && subOldEpisode.CurrentStateDefID == SubEpisode.States.Opened)
//                                                {
//                                                    subOldEpisode.CurrentStateDefID = SubEpisode.States.Closed;
//                                                    if(subOldEpisode.ClosingDate == null)
//                                                        subOldEpisode.ClosingDate = ea.RequestDate;
//                                                    LastOpenSub = subOldEpisode;
//                                                }
//                                            }
//                                        }
//                                    }
//                                    subEpisode.Episode = ea.Episode;
//                                    subEpisode.OpeningDate = ea.RequestDate;
//                                    if (ea is InPatientTreatmentClinicApplication)// Taburcu olduysa kendi kendini kapanır.
//                                        subEpisode.ClosingDate = ((InPatientTreatmentClinicApplication)ea).ClinicDischargeDate;
//                                    else
//                                        subEpisode.ClosingDate = null;
//                                    subEpisode.CurrentStateDefID = SubEpisode.States.Opened;
//                                    subEpisode.PatientStatus = (firstEA==true && ea.SubEpisode.PatientAdmission.AdmissionType != AdmissionTypeEnum.Daily) ? SubEpisodeStatusEnum.Outpatient : ea.SubEpisodePatientStatus;
//                                    subEpisode.ResSection = ea.SubEpisodeResSection;
//                                    subEpisode.Speciality = ea.SubEpisodeSpeciality;
//                                    subEpisode.GetAndSetNextProtocolNo();
//                                    subEpisode.Episode = ea.Episode;
//                                    subEpisode.StarterEpisodeAction = ea;
                                    
                                    
//                                    foreach(EpisodeAction lea in ea.LinkedActions)// Kabulde başlatılan tüm  işlemleri için yada Başlatan episode actıonın alt alt işlemlerinin Subepisodeunu set eder
//                                    {
//                                        lea.IgnoreEpisodeStateOnUpdate = true;
//                                        if(lea.CurrentStateDef.Status != StateStatusEnum.Cancelled) // Cancel Objelerde Property Set edilebildiğinde silisin
//                                            lea.SubEpisode = subEpisode;
//                                    }
//                                    if (ea is InPatientTreatmentClinicApplication)// Aynı episodedaki diğer SubEpisodları kapatır.
//                                    {
                                        
//                                        if (((InPatientTreatmentClinicApplication)ea).BaseInpatientAdmission != null && ((InPatientTreatmentClinicApplication)ea).BaseInpatientAdmission is InpatientAdmission)
//                                        {
//                                            ((InPatientTreatmentClinicApplication)ea).BaseInpatientAdmission.IgnoreEpisodeStateOnUpdate=true;
//                                            if(((InPatientTreatmentClinicApplication)ea).BaseInpatientAdmission.CurrentStateDef.Status != StateStatusEnum.Cancelled) // Cancel Objelerde Property Set edilebildiğinde silisin
//                                                ((InPatientTreatmentClinicApplication)ea).BaseInpatientAdmission.SubEpisode = subEpisode;
                                            
//                                        }
//                                    }
//                                    if(ea != null)// başlatan işlemin subactionlarının SubEpisode'unu set  eder
//                                    {
//                                        ea.SubEpisode = subEpisode;
//                                    }
//                                    if (ea is InPatientTreatmentClinicApplication)// Aynı episodedaki diğer SubEpisodları kapatır.
//                                    {
//                                        if(ea.SubEpisode.OldSubEpisode == null)
//                                            ea.SubEpisode.OldSubEpisode= LastOpenSub;
//                                    }
//                                }
//                            }
//                            firstEA = false;
//                            //CreateSubEpisodeAttribute
//                        }
//                        else if(ea.SubEpisode == null)
//                        {
//                            if(ea.MasterAction != null && ea.MasterAction is EpisodeAction && ((EpisodeAction)ea.MasterAction).SubEpisode != null )
//                                ea.SubEpisode=((EpisodeAction)ea.MasterAction).SubEpisode;// eğer master actıonı varsa direk onun Subepisodunu alır
//                            else
//                                ea.SetMyProperOpenedSubEpisode(episode,false);// Episode değiştirme yapılınca yeni episodedaki subepisodu alması için false yapıldı
//                        }
//                    }
//                }
//            }
//            objectContext.Save();
//            InfoBox.Show("Alt Vaka Ekleme / Düzeltme işlemi tamamlandı");
//#endregion AccountingProcessForm_CreateOrUpadateSubEpisode_Click
//        }

//        private void NEWPRICINGLISTMULTIPLIER_SelectedIndexChanged()
//        {
//#region AccountingProcessForm_NEWPRICINGLISTMULTIPLIER_SelectedIndexChanged
//   foreach (AccountingProcessProcedure accProc in _AccountingProcess.AccountingProcessProcedures)
//            {
//                if(_AccountingProcess.NewPricingListMultiplier != null)
//                {
//                    accProc.PricingListMultiplier = _AccountingProcess.NewPricingListMultiplier;
//                    accProc.NewUnitPrice = Math.Round((double)(accProc.OldUnitPrice * accProc.PricingListMultiplier.Multiplier),2);
//                }
//            }

//            foreach (AccountingProcessPackage accPack in _AccountingProcess.AccountingProcessPackages)
//            {
//                if(_AccountingProcess.NewPricingListMultiplier != null)
//                {
//                    accPack.PricingListMultiplier = _AccountingProcess.NewPricingListMultiplier;
//                    accPack.NewUnitPrice = Math.Round((double)(accPack.OldUnitPrice * accPack.PricingListMultiplier.Multiplier),2);
//                }
//            }
//#endregion AccountingProcessForm_NEWPRICINGLISTMULTIPLIER_SelectedIndexChanged
//        }

//        private void NEWSTATUS_SelectedIndexChanged()
//        {
//#region AccountingProcessForm_NEWSTATUS_SelectedIndexChanged
//   foreach (AccountingProcessProcedure accProc in _AccountingProcess.AccountingProcessProcedures)
//            {
//                accProc.NewStatus = _AccountingProcess.NewStatus;
//            }
//            foreach (AccountingProcessMaterial accMat in _AccountingProcess.AccountingProcessMaterials)
//            {
//                accMat.NewStatus = _AccountingProcess.NewStatus;
//            }
//            foreach (AccountingProcessPackage accPack in _AccountingProcess.AccountingProcessPackages)
//            {
//                accPack.NewStatus = _AccountingProcess.NewStatus;
//            }
//#endregion AccountingProcessForm_NEWSTATUS_SelectedIndexChanged
//        }

//        private void NEWSUBEPISODE_SelectedObjectChanged()
//        {
//#region AccountingProcessForm_NEWSUBEPISODE_SelectedObjectChanged
//   if(this.OLDSUBEPISODE.SelectedObject != null){
//                SubEpisode se = (SubEpisode)_ttObject.ObjectContext.GetObject(this.OLDSUBEPISODE.SelectedObject.ObjectID,"SubEpisode");
//                foreach (AccountingProcessProcedure accProc in _AccountingProcess.AccountingProcessProcedures)
//                {
//                    accProc.NewSubEpisode = null;
//                    if(accProc.AccountTransaction.SubEpisodeProtocol.SubEpisode == se)
//                        accProc.NewSubEpisode = _AccountingProcess.NewSubEpisode;
//                }
//                foreach (AccountingProcessMaterial accMat in _AccountingProcess.AccountingProcessMaterials)
//                {
//                    accMat.NewSubEpisode = null;
//                    if(accMat.AccountTransaction.SubEpisodeProtocol.SubEpisode == se)
//                        accMat.NewSubEpisode = _AccountingProcess.NewSubEpisode;
//                }
//                foreach (AccountingProcessPackage accPack in _AccountingProcess.AccountingProcessPackages)
//                {
//                    accPack.NewSubEpisode = null;
//                    if(accPack.AccountTransaction.SubEpisodeProtocol.SubEpisode == se)
//                        accPack.NewSubEpisode = _AccountingProcess.NewSubEpisode;
//                }
//            }
//            else
//            {
//                foreach (AccountingProcessProcedure accProc in _AccountingProcess.AccountingProcessProcedures)
//                {
                    
//                    accProc.NewSubEpisode = _AccountingProcess.NewSubEpisode;
//                }
//                foreach (AccountingProcessMaterial accMat in _AccountingProcess.AccountingProcessMaterials)
//                {
                    
//                    accMat.NewSubEpisode = _AccountingProcess.NewSubEpisode;
//                }
//                foreach (AccountingProcessPackage accPack in _AccountingProcess.AccountingProcessPackages)
//                {
                    
//                    accPack.NewSubEpisode = _AccountingProcess.NewSubEpisode;
//                }
//            }
//#endregion AccountingProcessForm_NEWSUBEPISODE_SelectedObjectChanged
//        }

//        private void NEWSHARE_SelectedIndexChanged()
//        {
//#region AccountingProcessForm_NEWSHARE_SelectedIndexChanged
//   foreach (AccountingProcessProcedure accProc in _AccountingProcess.AccountingProcessProcedures)
//            {
//                accProc.NewShare = _AccountingProcess.NewShare;
//            }
//            foreach (AccountingProcessMaterial accMat in _AccountingProcess.AccountingProcessMaterials)
//            {
//                accMat.NewShare = _AccountingProcess.NewShare;
//            }
//            foreach (AccountingProcessPackage accPack in _AccountingProcess.AccountingProcessPackages)
//            {
//                accPack.NewShare = _AccountingProcess.NewShare;
//            }
//#endregion AccountingProcessForm_NEWSHARE_SelectedIndexChanged
//        }

//        private void NEWDATE_ValueChanged()
//        {
//#region AccountingProcessForm_NEWDATE_ValueChanged
//   foreach (AccountingProcessProcedure accProc in _AccountingProcess.AccountingProcessProcedures)
//            {
//                accProc.NewDate = _AccountingProcess.NewDate;
//            }
//            foreach (AccountingProcessMaterial accMat in _AccountingProcess.AccountingProcessMaterials)
//            {
//                accMat.NewDate = _AccountingProcess.NewDate;
//            }
//            foreach (AccountingProcessPackage accPack in _AccountingProcess.AccountingProcessPackages)
//            {
//                accPack.NewDate = _AccountingProcess.NewDate;
//            }
//#endregion AccountingProcessForm_NEWDATE_ValueChanged
//        }

//        private void OLDSUBEPISODE_SelectedObjectChanged()
//        {
//#region AccountingProcessForm_OLDSUBEPISODE_SelectedObjectChanged
//   if(this.NEWSUBEPISODE.SelectedObject != null && this.OLDSUBEPISODE.SelectedObject != null){
//                SubEpisode se = (SubEpisode)_ttObject.ObjectContext.GetObject(this.OLDSUBEPISODE.SelectedObject.ObjectID,"SubEpisode");
//                foreach (AccountingProcessProcedure accProc in _AccountingProcess.AccountingProcessProcedures)
//                {
//                    accProc.NewSubEpisode = null;
//                    if(accProc.AccountTransaction.SubEpisodeProtocol.SubEpisode == se)
//                        accProc.NewSubEpisode = _AccountingProcess.NewSubEpisode;
//                }
//                foreach (AccountingProcessMaterial accMat in _AccountingProcess.AccountingProcessMaterials)
//                {
//                    accMat.NewSubEpisode = null;
//                    if(accMat.AccountTransaction.SubEpisodeProtocol.SubEpisode == se)
//                        accMat.NewSubEpisode = _AccountingProcess.NewSubEpisode;
//                }
//                foreach (AccountingProcessPackage accPack in _AccountingProcess.AccountingProcessPackages)
//                {
//                    accPack.NewSubEpisode = null;
//                    if(accPack.AccountTransaction.SubEpisodeProtocol.SubEpisode == se)
//                        accPack.NewSubEpisode = _AccountingProcess.NewSubEpisode;
//                }
//            }
//#endregion AccountingProcessForm_OLDSUBEPISODE_SelectedObjectChanged
//        }

//        private void GRIDProcedures_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
//        {
//#region AccountingProcessForm_GRIDProcedures_CellValueChanged
//   if (GRIDProcedures.CurrentCell.OwningColumn.Name == PPRICINGLISTMULTIPLIER.Name && rowIndex != -1)
//            {
//                AccountingProcessProcedure accProcedure = (AccountingProcessProcedure)GRIDProcedures.CurrentCell.OwningRow.TTObject;
//                if(accProcedure.PricingListMultiplier != null)
//                    accProcedure.NewUnitPrice = Math.Round((double)(accProcedure.OldUnitPrice * accProcedure.PricingListMultiplier.Multiplier),2);
//            }
//#endregion AccountingProcessForm_GRIDProcedures_CellValueChanged
//        }

//        private void GRIDPackages_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
//        {
//#region AccountingProcessForm_GRIDPackages_CellValueChanged
//   if (GRIDPackages.CurrentCell.OwningColumn.Name == PACKAGEPRICINGLISTMULTIPLIER.Name && rowIndex != -1)
//            {
//                AccountingProcessPackage accPackage = (AccountingProcessPackage)GRIDPackages.CurrentCell.OwningRow.TTObject;
//                if(accPackage.PricingListMultiplier != null)
//                    accPackage.NewUnitPrice = Math.Round((double)(accPackage.OldUnitPrice * accPackage.PricingListMultiplier.Multiplier),2);
//            }
//#endregion AccountingProcessForm_GRIDPackages_CellValueChanged
//        }

//        private void SubEpisodesGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
//        {
//#region AccountingProcessForm_SubEpisodesGrid_CellValueChanged
//   ITTGridRow currentRow = SubEpisodesGrid.Rows[rowIndex];
//            if (currentRow != null)
//            {
//                SubEpisode currentSubEpisode = currentRow.TTObject as SubEpisode;
//                // Yeni eklenmiş AltVaka ise bazı property leri set edilir
//                if (currentSubEpisode != null && ((ITTObject)currentSubEpisode).IsNew && currentSubEpisode.CurrentStateDefID == null)
//                {
//                    currentSubEpisode.CurrentStateDefID = SubEpisode.States.Opened;
                    
//                    if(currentSubEpisode.StarterEpisodeAction == null)
//                        currentSubEpisode.StarterEpisodeAction = this._AccountingProcess;
                    
//                    SubEpisode lastSubEpisode = this._AccountingProcess.Episode.GetMyLastSubEpisode();
//                    if(lastSubEpisode != null)
//                    {
//                        if(currentSubEpisode.OldSubEpisode == null)
//                            currentSubEpisode.OldSubEpisode = lastSubEpisode;
                        
//                        if(currentSubEpisode.ProtocolNo == null && lastSubEpisode.ProtocolNo != null)
//                            currentSubEpisode.ProtocolNo = lastSubEpisode.ProtocolNo + 1;
//                    }
//                }
//            }
//#endregion AccountingProcessForm_SubEpisodesGrid_CellValueChanged
//        }

//        private void SubEpisodesGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
//        {
//#region AccountingProcessForm_SubEpisodesGrid_CellContentClick
//   if(_AccountingProcess.CurrentStateDefID == AccountingProcess.States.New)
//            {
//                if (rowIndex != -1 && this.SubEpisodesGrid.Columns[columnIndex].Name == "CreateMedulaProvision")
//                {
//                    // SubEpisode için MedulaProvision oluşturulur
//                    SubEpisode se = (SubEpisode)((ITTGridRow)this.SubEpisodesGrid.Rows[rowIndex]).TTObject;
//                    if (se != null)
//                    {
//                        if(Episode.IsMedulaEpisode(_AccountingProcess.Episode))
//                        {
//                            /*
//                            if(se.MyMedulaProvision() == null)
//                            {
//                                MedulaProvision medulaProvision = new MedulaProvision(this._AccountingProcess.ObjectContext);
//                                medulaProvision.CurrentStateDefID = MedulaProvision.States.New;
//                                medulaProvision.SubEpisode = se;
//                                medulaProvision.Episode = this._AccountingProcess.Episode;
//                                medulaProvision.Status = MedulaSubEpisodeStatusEnum.ProvisionNoNotExists;
//                                medulaProvision.GetAndSetNextOrderNo();
                                
//                                if(se.PatientStatus != null)
//                                {
//                                    if(se.PatientStatus == SubEpisodeStatusEnum.Outpatient) // Ayaktan
//                                        medulaProvision.TedaviTuru = TedaviTuru.GetTedaviTuru("A");
//                                    else if(se.PatientStatus == SubEpisodeStatusEnum.Daily) // Günübirlik
//                                        medulaProvision.TedaviTuru = TedaviTuru.GetTedaviTuru("G");
//                                    else
//                                        medulaProvision.TedaviTuru = TedaviTuru.GetTedaviTuru("Y"); // Yatan
//                                }
                                
//                                if(se.Speciality != null)
//                                    medulaProvision.Brans = SpecialityDefinition.GetBrans(se.Speciality.Code);
                                
//                                this.SubEpisodesGrid.Rows[rowIndex].Cells["MPOrderNo"].Value = medulaProvision.OrderNo == null ? string.Empty : medulaProvision.OrderNo.ToString();
//                                this.SubEpisodesGrid.Rows[rowIndex].Cells["MPBrans"].Value = medulaProvision.Brans == null ? string.Empty : medulaProvision.Brans.Code + " : " + medulaProvision.Brans.Name;
//                                this.SubEpisodesGrid.Rows[rowIndex].Cells["MPTedaviTuru"].Value = medulaProvision.TedaviTuru == null ? string.Empty : medulaProvision.TedaviTuru.tedaviTuruKodu + " : " + medulaProvision.TedaviTuru.tedaviTuruAdi;
//                                this.SubEpisodesGrid.Rows[rowIndex].Cells["MPStatus"].Value = medulaProvision.Status == null ? string.Empty : Common.GetDisplayTextOfDataTypeEnum(medulaProvision.Status.Value);
//                                this.SubEpisodesGrid.Rows[rowIndex].Cells["MPState"].Value = medulaProvision.CurrentStateDef == null ? string.Empty : medulaProvision.CurrentStateDef.DisplayText;
                                
//                                TTVisual.InfoBox.Show("Takip oluşturuldu.",MessageIconEnum.InformationMessage);
//                            }
//                            else
//                                TTVisual.InfoBox.Show("Altvakanın takibi zaten oluşmuş durumdadır.",MessageIconEnum.WarningMessage);
//                                */
//                        }
//                        else
//                            TTVisual.InfoBox.Show("Hasta grubu takip oluşturmaya uygun değildir.",MessageIconEnum.WarningMessage);
//                    }
//                }
//            }
//#endregion AccountingProcessForm_SubEpisodesGrid_CellContentClick
//        }

//        private void MedulaProvisionsGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
//        {
//#region AccountingProcessForm_MedulaProvisionsGrid_CellContentClick
//   if(_AccountingProcess.CurrentStateDefID == AccountingProcess.States.New)
//            {
//                if (rowIndex != -1 && this.MedulaProvisionsGrid.Columns[columnIndex].Name == "CreateSubEpisode")
//                {
//                    /*
//                    // MedulaProvision için SubEpisode oluşturulur
//                    MedulaProvision mp = (MedulaProvision)((ITTGridRow)this.MedulaProvisionsGrid.Rows[rowIndex]).TTObject;
//                    if (mp != null)
//                    {
//                        if(Episode.IsMedulaEpisode(_AccountingProcess.Episode))
//                        {
//                            if(mp.SubEpisode == null)
//                            {
//                                SubEpisode subEpisode = new SubEpisode(this._AccountingProcess.ObjectContext);
//                                subEpisode.CurrentStateDefID = SubEpisode.States.Opened;
//                                subEpisode.Episode = this._AccountingProcess.Episode;
//                                subEpisode.OpeningDate = mp.ProvisionDate;
//                                subEpisode.GetAndSetNextProtocolNo();
//                                subEpisode.StarterEpisodeAction = this._AccountingProcess;
//                                mp.SubEpisode = subEpisode;
                                
//                                if(mp.TedaviTuru != null)
//                                {
//                                    if(mp.TedaviTuru.tedaviTuruKodu == "A") // Ayaktan
//                                        subEpisode.PatientStatus = SubEpisodeStatusEnum.Outpatient;
//                                    else if(mp.TedaviTuru.tedaviTuruKodu == "G") // Günübirlik
//                                        subEpisode.PatientStatus = SubEpisodeStatusEnum.Daily;
//                                    else // Yatan
//                                        subEpisode.PatientStatus = SubEpisodeStatusEnum.Inpatient;
//                                }
                                
//                                if(mp.Brans != null)
//                                {
//                                    IBindingList specialityList = SpecialityDefinition.GetSpecialityByCode(this._AccountingProcess.ObjectContext, mp.Brans.Code);
//                                    if (specialityList.Count > 0)
//                                        subEpisode.Speciality = (SpecialityDefinition)specialityList[0];
                                    
//                                    IBindingList resSectionList;
//                                    if(mp.TedaviTuru != null && mp.TedaviTuru.tedaviTuruKodu == "Y")
//                                        resSectionList = ResClinic.GetClinicByMedulaBrans(this._AccountingProcess.ObjectContext, mp.Brans.ObjectID.ToString());
//                                    else
//                                        resSectionList = ResPoliclinic.GetPoliclinicByMedulaBrans(this._AccountingProcess.ObjectContext, mp.Brans.ObjectID.ToString());
                                    
//                                    if(resSectionList.Count > 0)
//                                        subEpisode.ResSection = (ResSection)resSectionList[0];
//                                }
                                
//                                if(subEpisode.ResSection == null) // Boş kalmaması için
//                                    subEpisode.ResSection = this._AccountingProcess.MasterResource;

//                                for (int row = 0; row < this.SubEpisodesGrid.Rows.Count; row++)
//                                {
//                                    if (((ITTGridRow)this.SubEpisodesGrid.Rows[row]).TTObject.ObjectID == subEpisode.ObjectID)
//                                    {
//                                        this.SubEpisodesGrid.Rows[row].Cells["MPOrderNo"].Value = mp.OrderNo == null ? string.Empty : mp.OrderNo.ToString();
//                                        this.SubEpisodesGrid.Rows[row].Cells["MPProvisionNo"].Value = mp.ProvisionNo == null ? string.Empty : mp.ProvisionNo;
//                                        this.SubEpisodesGrid.Rows[row].Cells["MPRelatedProvisionNo"].Value = mp.RelatedProvisionNo == null ? string.Empty : mp.RelatedProvisionNo;
//                                        this.SubEpisodesGrid.Rows[row].Cells["MPProvisionDate"].Value = mp.ProvisionDate;
//                                        this.SubEpisodesGrid.Rows[row].Cells["MPBrans"].Value = mp.Brans == null ? string.Empty : mp.Brans.Code + " : " + mp.Brans.Name;
//                                        this.SubEpisodesGrid.Rows[row].Cells["MPTedaviTuru"].Value = mp.TedaviTuru == null ? string.Empty : mp.TedaviTuru.tedaviTuruKodu + " : " + mp.TedaviTuru.tedaviTuruAdi;
//                                        this.SubEpisodesGrid.Rows[row].Cells["MPStatus"].Value = mp.Status == null ? string.Empty : Common.GetDisplayTextOfDataTypeEnum(mp.Status.Value);
//                                        this.SubEpisodesGrid.Rows[row].Cells["MPState"].Value = mp.CurrentStateDef == null ? string.Empty : mp.CurrentStateDef.DisplayText;
//                                        break;
//                                    }
//                                }
                            
//                                TTVisual.InfoBox.Show("Alt vaka oluşturuldu.",MessageIconEnum.InformationMessage);
//                            }
//                            else
//                                TTVisual.InfoBox.Show("Takibin alt vakası zaten oluşmuş durumdadır.",MessageIconEnum.WarningMessage);
//                        }
//                        else
//                            TTVisual.InfoBox.Show("Hasta grubu alt vaka oluşturmaya uygun değildir.",MessageIconEnum.WarningMessage);
//                    }
//                    */
//                }
//            }
//#endregion AccountingProcessForm_MedulaProvisionsGrid_CellContentClick
//        }

//        private void GetActionsBtn_Click()
//        {
//#region AccountingProcessForm_GetActionsBtn_Click
//   IList eaList = null;
//            _AccountingProcess.AccountingProcessActions.DeleteChildren();
            
//            if(((TTTextBox)ActionIds).Text.Trim() != "")
//            {
//                //IList actionIdList = null;
//                List<string> actionIdList = new List<string>();
//                char[] splitter = { ',' };
//                foreach (string actionId in ((TTTextBox)ActionIds).Text.Split(splitter))
//                    actionIdList.Add(actionId.Trim());
                
//                eaList = EpisodeAction.GetByEpisodeAndId(_AccountingProcess.ObjectContext, _AccountingProcess.Episode.ObjectID.ToString(), actionIdList.ToArray());
//                foreach (EpisodeAction ea in eaList)
//                {
//                    AccountingProcessAction accAction = new AccountingProcessAction(_AccountingProcess.ObjectContext);
//                    accAction.EpisodeAction = ea;
//                    accAction.Name = ea.ObjectDef.DisplayText;
                    
//                    if(ea.SubEpisode != null)
//                    {
//                        accAction.OldSubEpisode = ea.SubEpisode.ProtocolNo.Value.ToString();
                        
//                        if(ea.SubEpisode.ResSection != null)
//                            accAction.OldSubEpisode += " " + ea.SubEpisode.ResSection.Name;
//                    }
                    
//                    _AccountingProcess.AccountingProcessActions.Add(accAction);
                    
//                    ((TTListBoxColumn)GridEpisodeActions.Rows[GridEpisodeActions.Rows.Count - 1].Cells["EANEWSUBEPISODE"].OwningColumn).ListFilterExpression = "EPISODE.OBJECTID = '" + _AccountingProcess.Episode.ObjectID.ToString() + "'";
//                }
//            }
//#endregion AccountingProcessForm_GetActionsBtn_Click
//        }

//        private void GridEpisodeProtocols_CellContentClick(Int32 rowIndex, Int32 columnIndex)
//        {
//#region AccountingProcessForm_GridEpisodeProtocols_CellContentClick
//   if(_AccountingProcess.CurrentStateDefID != AccountingProcess.States.Completed)
//            {
//                if (columnIndex == 4 && rowIndex != -1)
//                {
//                    Episode myEpisode = _AccountingProcess.Episode;
//                    EpisodeProtocol myEpisodeProtocol = null;  //(EpisodeProtocol) myEpisode.EpisodeProtocols.Select("OBJECTID = '" + GridEpisodeProtocols.Rows[rowIndex].Cells["EPOBJECTID"].Value.ToString() + "'")[0];
                    
//                    // Hızlandırma için değiştirilen kod
//                    string injectionForProcedure = string.Empty;
//                    string injectionForMaterial = string.Empty;
//                    string injectionForSubactionProcedure = string.Empty;
//                    string injectionForSubactionMaterial = string.Empty;
//                    IList procedureTrxList = null;
//                    IList packageTrxList = null;
//                    IList materialTrxList = null;
                    
//                    if(_AccountingProcess.STARTDATE != null)
//                    {
//                        injectionForProcedure += " AND THIS.TRANSACTIONDATE >= " + Globals.CreateNQLToDateParameter(Convert.ToDateTime(Convert.ToDateTime(_AccountingProcess.STARTDATE).ToString("yyyy-MM-dd HH:mm:ss")));
//                        injectionForMaterial += " AND THIS.TRANSACTIONDATE >= " + Globals.CreateNQLToDateParameter(Convert.ToDateTime(Convert.ToDateTime(_AccountingProcess.STARTDATE).ToString("yyyy-MM-dd HH:mm:ss")));
//                    }
                    
//                    if(_AccountingProcess.ENDDATE != null)
//                    {
//                        injectionForProcedure += " AND THIS.TRANSACTIONDATE <= " + Globals.CreateNQLToDateParameter(Convert.ToDateTime(Convert.ToDateTime(_AccountingProcess.ENDDATE).ToString("yyyy-MM-dd HH:mm:ss")));
//                        injectionForMaterial += " AND THIS.TRANSACTIONDATE <= " + Globals.CreateNQLToDateParameter(Convert.ToDateTime(Convert.ToDateTime(_AccountingProcess.ENDDATE).ToString("yyyy-MM-dd HH:mm:ss")));
//                    }
                    
//                    if(_AccountingProcess.Procedure != null)
//                    {
//                        injectionForProcedure += " AND THIS.SUBACTIONPROCEDURE.PROCEDUREOBJECT = '" + _AccountingProcess.Procedure.ObjectID.ToString() + "' ";
//                        injectionForSubactionProcedure += " AND THIS.PROCEDUREOBJECT = '" + _AccountingProcess.Procedure.ObjectID.ToString() + "' ";
//                    }
//                    if(_AccountingProcess.Material != null)
//                    {
//                        injectionForMaterial += " AND THIS.SUBACTIONMATERIAL.MATERIAL = '" + _AccountingProcess.Material.ObjectID.ToString() + "' ";
//                        injectionForSubactionMaterial += " AND THIS.MATERIAL = '" + _AccountingProcess.Material.ObjectID.ToString() + "' ";
//                    }
                    
//                    if(_AccountingProcess.STATUS != null)
//                    {
//                        if (_AccountingProcess.STATUS == AccountTrnsNewCancelToBeNewStateEnum.New)
//                        {
//                            injectionForProcedure += " AND THIS.CURRENTSTATE = '" + AccountTransaction.States.New.ToString() + "' ";
//                            injectionForMaterial += " AND THIS.CURRENTSTATE = '" + AccountTransaction.States.New.ToString() + "' ";
//                        }
//                        else if (_AccountingProcess.STATUS == AccountTrnsNewCancelToBeNewStateEnum.Cancelled)
//                        {
//                            injectionForProcedure += " AND THIS.CURRENTSTATE = '" + AccountTransaction.States.Cancelled.ToString() + "' ";
//                            injectionForMaterial += " AND THIS.CURRENTSTATE = '" + AccountTransaction.States.Cancelled.ToString() + "' ";
//                        }
//                        else if (_AccountingProcess.STATUS == AccountTrnsNewCancelToBeNewStateEnum.ToBeNew)
//                        {
//                            injectionForProcedure += " AND THIS.CURRENTSTATE = '" + AccountTransaction.States.ToBeNew.ToString() + "'";
//                            injectionForMaterial += "AND THIS.CURRENTSTATE = '" + AccountTransaction.States.ToBeNew.ToString() + "'";
//                        }

//                    }
                    
//                    // TODO:SEP myEpisodeProtocol.ObjectID kısmı mySEP.ObjectID olarak değiştirilmeli kullanılacaksa
//                    procedureTrxList = AccountTransaction.GetNewAndCancelledProcedureTrxsBySEP(_AccountingProcess.ObjectContext, myEpisodeProtocol.ObjectID, injectionForProcedure);
//                    packageTrxList = AccountTransaction.GetNewAndCancelledPackageTrxsBySEP(_AccountingProcess.ObjectContext, myEpisodeProtocol.ObjectID, injectionForProcedure);
//                    materialTrxList = AccountTransaction.GetNewAndCancelledMaterialTrxsBySEP(_AccountingProcess.ObjectContext, myEpisodeProtocol.ObjectID, injectionForMaterial);
                    
//                    // Episode daki Tüm SP ve SM ler değil, seçilen anlaşmanın AccTrx lerinin SP ve SM leri getirilir sadece context gereksiz
//                    // dolmasın diye
//                    //SubActionProcedure.GetByEpisode(_AccountingProcess.ObjectContext, _AccountingProcess.Episode.ObjectID.ToString());
//                    //SubActionMaterial.GetByEpisode(_AccountingProcess.ObjectContext, _AccountingProcess.Episode.ObjectID.ToString());
                    
//                    // TODO:SEP myEpisodeProtocol.ObjectID kısmı mySEP.ObjectID olarak değiştirilmeli kullanılacaksa
//                    SubActionProcedure.GetByEpisodeAndSEP(_AccountingProcess.ObjectContext, _AccountingProcess.Episode.ObjectID, myEpisodeProtocol.ObjectID, injectionForSubactionProcedure);
//                    SubActionMaterial.GetByEpisodeAndSEP(_AccountingProcess.ObjectContext, _AccountingProcess.Episode.ObjectID, myEpisodeProtocol.ObjectID, injectionForSubactionMaterial);
//                    EpisodeAction.GetEpisodeActionsByEpisode(_AccountingProcess.ObjectContext, _AccountingProcess.Episode.ObjectID.ToString());
                    
//                    // Hızlandırma için buraya taşındı, sorgulardan sonra çalışması için
//                    _AccountingProcess.AccountingProcessProcedures.DeleteChildren();
//                    _AccountingProcess.AccountingProcessMaterials.DeleteChildren();
//                    _AccountingProcess.AccountingProcessPackages.DeleteChildren();
                    
//                    _AccountingProcess.NewSubEpisode = null;
//                    _AccountingProcess.NewShare = null;
//                    _AccountingProcess.NewDate = null;
//                    _AccountingProcess.NewStatus = null;
                    
//                    _AccountingProcess.EpisodeProtocol = myEpisodeProtocol;
                    
//                    // Hizmetler
//                    foreach (AccountTransaction accTrx in procedureTrxList)
//                    {
//                        // AccountTransaction ve SubActionProcedure İptal durumundaysa, AccountTransaction ın Yeni durumuna alınması Paket İçine aktarma gibi
//                        // SubActionProcedure ün property sini güncelleyen işlerde 'İptal Edilmiş Nesnenin Üst İlişkisi Güncellenemez' hatasına neden olduğu
//                        // için bu durumdaki AccountTransaction gride eklenmiyor.
//                        if(!(accTrx.CurrentStateDefID == AccountTransaction.States.Cancelled && accTrx.SubActionProcedure.CurrentStateDef.Status == StateStatusEnum.Cancelled))
//                        {
//                            AccountingProcessProcedure accProc = new AccountingProcessProcedure(_AccountingProcess.ObjectContext);
//                            accProc.Description = accTrx.Description;
//                            accProc.ExternalCode = accTrx.ExternalCode;
//                            accProc.OldDate = accTrx.TransactionDate;
//                            accProc.OldAmount = accTrx.Amount;
//                            accProc.OldUnitPrice = accTrx.UnitPrice;
//                            accProc.ActionId = accTrx.SubActionProcedure.EpisodeAction.ID.Value.ToString();
                            
//                            if (accTrx.CurrentStateDefID == AccountTransaction.States.New)
//                                accProc.OldStatus = AccountTransactionStateEnum.New;
//                            else if (accTrx.CurrentStateDefID == AccountTransaction.States.Cancelled)
//                                accProc.OldStatus = AccountTransactionStateEnum.Cancelled;
//                            else if (accTrx.CurrentStateDefID == AccountTransaction.States.ToBeNew)
//                                accProc.OldStatus = AccountTransactionStateEnum.ToBeNew; 
//                            if (accTrx.PackageDefinition != null)
//                                accProc.PackageInfo = accTrx.PackageDefinition.Name;
                            
//                            if(accTrx.AccountPayableReceivable != null)
//                            {
//                                if(accTrx.AccountPayableReceivable.PayerDefinition != null)
//                                    accProc.OldShare = "Kurum";
//                                else if(accTrx.AccountPayableReceivable.Patient != null)
//                                    accProc.OldShare = "Hasta";
//                            }
                            
//                            if(accTrx.SubEpisodeProtocol.SubEpisode != null)
//                            {
//                                accProc.OldSubEpisode = accTrx.SubEpisodeProtocol.SubEpisode.ProtocolNo.Value.ToString();
                                
//                                if(accTrx.SubEpisodeProtocol.SubEpisode.ResSection != null)
//                                    accProc.OldSubEpisode = accProc.OldSubEpisode + " " + accTrx.SubEpisodeProtocol.SubEpisode.ResSection.Name;
//                            }
                            
//                            accProc.AccountTransaction = accTrx;
//                            _AccountingProcess.AccountingProcessProcedures.Add(accProc);
                            
//                            ((TTListBoxColumn)GRIDProcedures.Rows[GRIDProcedures.Rows.Count - 1].Cells["PNEWSUBEPISODE"].OwningColumn).ListFilterExpression = "EPISODE.OBJECTID = '" + _AccountingProcess.Episode.ObjectID.ToString() + "'";
//                        }
//                    }
                    
//                    // Paketler
//                    foreach (AccountTransaction accTrx in packageTrxList)
//                    {
//                        // AccountTransaction ve SubActionProcedure İptal durumundaysa, AccountTransaction ın Yeni durumuna alınması Paket İçine aktarma gibi
//                        // SubActionProcedure ün property sini güncelleyen işlerde 'İptal Edilmiş Nesnenin Üst İlişkisi Güncellenemez' hatasına neden olduğu
//                        // için bu durumdaki AccountTransaction gride eklenmiyor.
//                        if(!(accTrx.CurrentStateDefID == AccountTransaction.States.Cancelled && accTrx.SubActionProcedure.CurrentStateDef.Status == StateStatusEnum.Cancelled))
//                        {
//                            AccountingProcessPackage accPack = new AccountingProcessPackage(_AccountingProcess.ObjectContext);
//                            accPack.Description = accTrx.Description;
//                            accPack.ExternalCode = accTrx.ExternalCode;
//                            accPack.OldDate = accTrx.TransactionDate;
//                            accPack.OldAmount = accTrx.Amount;
//                            accPack.OldUnitPrice = accTrx.UnitPrice;
//                            accPack.ActionId = accTrx.SubActionProcedure.EpisodeAction.ID.Value.ToString();
                            
//                            if (accTrx.CurrentStateDefID == AccountTransaction.States.New)
//                                accPack.OldStatus = AccountTransactionStateEnum.New;
//                            else if (accTrx.CurrentStateDefID == AccountTransaction.States.Cancelled)
//                                accPack.OldStatus = AccountTransactionStateEnum.Cancelled;
//                            else if (accTrx.CurrentStateDefID == AccountTransaction.States.ToBeNew)
//                                accPack.OldStatus = AccountTransactionStateEnum.ToBeNew;
                            
//                            if(accTrx.AccountPayableReceivable != null)
//                            {
//                                if(accTrx.AccountPayableReceivable.PayerDefinition != null)
//                                    accPack.OldShare = "Kurum";
//                                else if(accTrx.AccountPayableReceivable.Patient != null)
//                                    accPack.OldShare = "Hasta";
//                            }
                            
//                            if(accTrx.SubEpisodeProtocol.SubEpisode != null)
//                            {
//                                accPack.OldSubEpisode = accTrx.SubEpisodeProtocol.SubEpisode.ProtocolNo.Value.ToString();
                                
//                                if(accTrx.SubEpisodeProtocol.SubEpisode.ResSection != null)
//                                    accPack.OldSubEpisode = accPack.OldSubEpisode + " " + accTrx.SubEpisodeProtocol.SubEpisode.ResSection.Name;
//                            }
                            
//                            accPack.AccountTransaction = accTrx;
//                            _AccountingProcess.AccountingProcessPackages.Add(accPack);
                            
//                            ((TTListBoxColumn)GRIDPackages.Rows[GRIDPackages.Rows.Count - 1].Cells["PACKAGENEWSUBEPISODE"].OwningColumn).ListFilterExpression = "EPISODE.OBJECTID = '" + _AccountingProcess.Episode.ObjectID.ToString() + "'";
//                        }
//                    }
                    
//                    // Malzeme ve İlaçlar
//                    foreach (AccountTransaction accTrx in materialTrxList)
//                    {
//                        // AccountTransaction ve SubActionMaterial İptal durumundaysa, AccountTransaction ın Yeni durumuna alınması Paket İçine aktarma gibi
//                        // SubActionMaterial in property sini güncelleyen işlerde 'İptal Edilmiş Nesnenin Üst İlişkisi Güncellenemez' hatasına neden olduğu
//                        // için bu durumdaki AccountTransaction gride eklenmiyor.
//                        if(!(accTrx.CurrentStateDefID == AccountTransaction.States.Cancelled && accTrx.SubActionMaterial.CurrentStateDef.Status == StateStatusEnum.Cancelled))
//                        {
//                            AccountingProcessMaterial accMat = new AccountingProcessMaterial(_AccountingProcess.ObjectContext);
//                            accMat.Description = accTrx.Description;
//                            accMat.ExternalCode = accTrx.ExternalCode;
//                            accMat.OldDate = accTrx.TransactionDate;
//                            accMat.OldAmount = accTrx.Amount;
//                            accMat.OldUnitPrice = accTrx.UnitPrice;
                            
//                            if(accTrx.SubActionMaterial.EpisodeAction != null)
//                                accMat.ActionId=accTrx.SubActionMaterial.EpisodeAction.ID.Value.ToString();
                            
//                            if (accTrx.CurrentStateDefID == AccountTransaction.States.New)
//                                accMat.OldStatus = AccountTransactionStateEnum.New;
//                            else if (accTrx.CurrentStateDefID == AccountTransaction.States.Cancelled)
//                                accMat.OldStatus = AccountTransactionStateEnum.Cancelled;
//                            else if (accTrx.CurrentStateDefID == AccountTransaction.States.ToBeNew)
//                                accMat.OldStatus = AccountTransactionStateEnum.ToBeNew;
                            
//                            if (accTrx.PackageDefinition != null)
//                                accMat.PackageInfo = accTrx.PackageDefinition.Name;
                            
//                            if(accTrx.AccountPayableReceivable != null)
//                            {
//                                if(accTrx.AccountPayableReceivable.PayerDefinition != null)
//                                    accMat.OldShare = "Kurum";
//                                else if(accTrx.AccountPayableReceivable.Patient != null)
//                                    accMat.OldShare = "Hasta";
//                            }
                            
//                            if(accTrx.SubEpisodeProtocol.SubEpisode != null)
//                            {
//                                accMat.OldSubEpisode = accTrx.SubEpisodeProtocol.SubEpisode.ProtocolNo.Value.ToString();
                                
//                                if(accTrx.SubEpisodeProtocol.SubEpisode.ResSection != null)
//                                    accMat.OldSubEpisode = accMat.OldSubEpisode + " " + accTrx.SubEpisodeProtocol.SubEpisode.ResSection.Name;
//                            }
                            
//                            accMat.AccountTransaction = accTrx;
//                            _AccountingProcess.AccountingProcessMaterials.Add(accMat);
                            
//                            ((TTListBoxColumn)GRIDMaterials.Rows[GRIDMaterials.Rows.Count - 1].Cells["MNEWSUBEPISODE"].OwningColumn).ListFilterExpression = "EPISODE.OBJECTID = '" + _AccountingProcess.Episode.ObjectID.ToString() + "'";
//                        }
//                    }
                    
//                    //****************************** Hızlandırmadan önceki kod ******************************
//                    /*
//                    bool addToGrid;
                    
//                    foreach (AccountTransaction accTrx in myEpisodeProtocol.GetNewAndCancelledTransactions())
//                    {
//                        addToGrid = true;
                        
//                        if(_AccountingProcess.STARTDATE != null)
//                        {
//                            if(DateTime.Compare(Convert.ToDateTime(Convert.ToDateTime(_AccountingProcess.STARTDATE).ToString("yyyy-MM-dd HH:mm:ss")), Convert.ToDateTime(Convert.ToDateTime(accTrx.TransactionDate).ToString("yyyy-MM-dd HH:mm:ss"))) > 0)
//                                addToGrid = false;
//                        }
                        
//                        if(_AccountingProcess.ENDDATE != null)
//                        {
//                            if(DateTime.Compare(Convert.ToDateTime(Convert.ToDateTime(accTrx.TransactionDate).ToString("yyyy-MM-dd HH:mm:ss"))  , Convert.ToDateTime(Convert.ToDateTime(_AccountingProcess.ENDDATE).ToString("yyyy-MM-dd HH:mm:ss"))) > 0)
//                                addToGrid = false;
//                        }
                        
//                        if(addToGrid)
//                        {
//                            if(accTrx.SubActionProcedure != null)
//                            {
//                                if(_AccountingProcess.Procedure != null)
//                                {
//                                    if(accTrx.SubActionProcedure.ProcedureObject.ObjectID != _AccountingProcess.Procedure.ObjectID)
//                                        addToGrid = false;
//                                }
                                
//                                // AccountTransaction ve SubActionProcedure İptal durumundaysa, AccountTransaction ın Yeni durumuna alınması Paket İçine aktarma gibi
//                                // SubActionProcedure ün property sini güncelleyen işlerde 'İptal Edilmiş Nesnenin Üst İlişkisi Güncellenemez' hatasına neden olduğu
//                                // için bu durumdaki AccountTransaction gride eklenmiyor.
//                                if(accTrx.CurrentStateDefID == AccountTransaction.States.Cancelled && accTrx.SubActionProcedure.CurrentStateDef.Status == StateStatusEnum.Cancelled)
//                                    addToGrid = false;
                                
//                                if (addToGrid)
//                                {
//                                    if (accTrx.SubActionProcedure.PackageDefinition != null)
//                                    {
//                                        AccountingProcessPackage accPack = new AccountingProcessPackage(_AccountingProcess.ObjectContext);
//                                        accPack.Description = accTrx.Description;
//                                        accPack.ExternalCode = accTrx.ExternalCode;
//                                        accPack.OldDate = accTrx.TransactionDate;
//                                        accPack.OldAmount = accTrx.Amount;
//                                        accPack.OldUnitPrice = accTrx.UnitPrice;
//                                        accPack.ActionId=accTrx.SubActionProcedure.EpisodeAction.ID.Value.ToString();
                                        
//                                        if (accTrx.CurrentStateDefID == AccountTransaction.States.New)
//                                            accPack.OldStatus = AccountTransactionStateEnum.New;
//                                        else if (accTrx.CurrentStateDefID == AccountTransaction.States.Cancelled)
//                                            accPack.OldStatus = AccountTransactionStateEnum.Cancelled;
                                        
//                                        if(accTrx.AccountPayableReceivable != null)
//                                        {
//                                            if(accTrx.AccountPayableReceivable.PayerDefinition != null)
//                                                accPack.OldShare = "Kurum";
//                                            else if(accTrx.AccountPayableReceivable.Patient != null)
//                                                accPack.OldShare = "Hasta";
//                                        }
                                        
//                                        if(accTrx.SubEpisode != null)
//                                        {
//                                            accPack.OldSubEpisode = accTrx.SubEpisode.ProtocolNo.Value.ToString();
                                            
//                                            if(accTrx.SubEpisode.ResSection != null)
//                                                accPack.OldSubEpisode = accPack.OldSubEpisode + " " + accTrx.SubEpisode.ResSection.Name;
//                                        }
                                        
//                                        accPack.AccountTransaction = accTrx;
//                                        _AccountingProcess.AccountingProcessPackages.Add(accPack);
                                        
//                                        ((TTListBoxColumn)GRIDPackages.Rows[GRIDPackages.Rows.Count - 1].Cells["PACKAGENEWSUBEPISODE"].OwningColumn).ListFilterExpression = "EPISODE.OBJECTID = '" + _AccountingProcess.Episode.ObjectID.ToString() + "'";
//                                    }
//                                    else
//                                    {
//                                        AccountingProcessProcedure accProc = new AccountingProcessProcedure(_AccountingProcess.ObjectContext);
//                                        accProc.Description = accTrx.Description;
//                                        accProc.ExternalCode = accTrx.ExternalCode;
//                                        accProc.OldDate = accTrx.TransactionDate;
//                                        accProc.OldAmount = accTrx.Amount;
//                                        accProc.OldUnitPrice = accTrx.UnitPrice;
//                                        accProc.ActionId=accTrx.SubActionProcedure.EpisodeAction.ID.Value.ToString();
                                        
//                                        if (accTrx.CurrentStateDefID == AccountTransaction.States.New)
//                                            accProc.OldStatus = AccountTransactionStateEnum.New;
//                                        else if (accTrx.CurrentStateDefID == AccountTransaction.States.Cancelled)
//                                            accProc.OldStatus = AccountTransactionStateEnum.Cancelled;
                                        
//                                        if (accTrx.PackageDefinition != null)
//                                            accProc.PackageInfo = accTrx.PackageDefinition.Name;
                                        
//                                        if(accTrx.AccountPayableReceivable != null)
//                                        {
//                                            if(accTrx.AccountPayableReceivable.PayerDefinition != null)
//                                                accProc.OldShare = "Kurum";
//                                            else if(accTrx.AccountPayableReceivable.Patient != null)
//                                                accProc.OldShare = "Hasta";
//                                        }
                                        
//                                        if(accTrx.SubEpisode != null)
//                                        {
//                                            accProc.OldSubEpisode = accTrx.SubEpisode.ProtocolNo.Value.ToString();
                                            
//                                            if(accTrx.SubEpisode.ResSection != null)
//                                                accProc.OldSubEpisode = accProc.OldSubEpisode + " " + accTrx.SubEpisode.ResSection.Name;
//                                        }
                                        
//                                        accProc.AccountTransaction = accTrx;
//                                        _AccountingProcess.AccountingProcessProcedures.Add(accProc);
                                        
//                                        ((TTListBoxColumn)GRIDProcedures.Rows[GRIDProcedures.Rows.Count - 1].Cells["PNEWSUBEPISODE"].OwningColumn).ListFilterExpression = "EPISODE.OBJECTID = '" + _AccountingProcess.Episode.ObjectID.ToString() + "'";
//                                    }
//                                }
//                            }
//                            else if(accTrx.SubActionMaterial != null)
//                            {
//                                if(_AccountingProcess.Material != null)
//                                {
//                                    if(accTrx.SubActionMaterial.Material.ObjectID != _AccountingProcess.Material.ObjectID)
//                                        addToGrid = false;
//                                }
                                
//                                // AccountTransaction ve SubActionMaterial İptal durumundaysa, AccountTransaction ın Yeni durumuna alınması Paket İçine aktarma gibi
//                                // SubActionMaterial in property sini güncelleyen işlerde 'İptal Edilmiş Nesnenin Üst İlişkisi Güncellenemez' hatasına neden olduğu
//                                // için bu durumdaki AccountTransaction gride eklenmiyor.
//                                if(accTrx.CurrentStateDefID == AccountTransaction.States.Cancelled && accTrx.SubActionMaterial.CurrentStateDef.Status == StateStatusEnum.Cancelled)
//                                    addToGrid = false;
                                
//                                if(addToGrid)
//                                {
//                                    AccountingProcessMaterial accMat = new AccountingProcessMaterial(_AccountingProcess.ObjectContext);
//                                    accMat.Description = accTrx.Description;
//                                    accMat.ExternalCode = accTrx.ExternalCode;
//                                    accMat.OldDate = accTrx.TransactionDate;
//                                    accMat.OldAmount = accTrx.Amount;
//                                    accMat.OldUnitPrice = accTrx.UnitPrice;
                                    
//                                    if(accTrx.SubActionMaterial.EpisodeAction != null)
//                                        accMat.ActionId=accTrx.SubActionMaterial.EpisodeAction.ID.Value.ToString();
                                    
//                                    if (accTrx.CurrentStateDefID == AccountTransaction.States.New)
//                                        accMat.OldStatus = AccountTransactionStateEnum.New;
//                                    else if (accTrx.CurrentStateDefID == AccountTransaction.States.Cancelled)
//                                        accMat.OldStatus = AccountTransactionStateEnum.Cancelled;
                                    
//                                    if (accTrx.PackageDefinition != null)
//                                        accMat.PackageInfo = accTrx.PackageDefinition.Name;
                                    
//                                    if(accTrx.AccountPayableReceivable != null)
//                                    {
//                                        if(accTrx.AccountPayableReceivable.PayerDefinition != null)
//                                            accMat.OldShare = "Kurum";
//                                        else if(accTrx.AccountPayableReceivable.Patient != null)
//                                            accMat.OldShare = "Hasta";
//                                    }
                                    
//                                    if(accTrx.SubEpisode != null)
//                                    {
//                                        accMat.OldSubEpisode = accTrx.SubEpisode.ProtocolNo.Value.ToString();
                                        
//                                        if(accTrx.SubEpisode.ResSection != null)
//                                            accMat.OldSubEpisode = accMat.OldSubEpisode + " " + accTrx.SubEpisode.ResSection.Name;
//                                    }
                                    
//                                    accMat.AccountTransaction = accTrx;
//                                    _AccountingProcess.AccountingProcessMaterials.Add(accMat);
                                    
//                                    ((TTListBoxColumn)GRIDMaterials.Rows[GRIDMaterials.Rows.Count - 1].Cells["MNEWSUBEPISODE"].OwningColumn).ListFilterExpression = "EPISODE.OBJECTID = '" + _AccountingProcess.Episode.ObjectID.ToString() + "'";
//                                }
//                            }
//                        }
//                    }
//                     */
//                }
//            }
//#endregion AccountingProcessForm_GridEpisodeProtocols_CellContentClick
//        }

//        protected override void PreScript()
//        {
//#region AccountingProcessForm_PreScript
//    base.PreScript();
//            if (_AccountingProcess.CurrentStateDefID == AccountingProcess.States.New)
//            {
//                this.cmdOK.Visible = false;

//                IList EPList = null; // EpisodeProtocol.GetByEpisode(_AccountingProcess.ObjectContext, _AccountingProcess.Episode.ObjectID.ToString());
//                _AccountingProcess.AccountingProcessProtocols.Clear();
                
//                foreach (EpisodeProtocol ep in EPList)
//                {
//                    AccountingProcessProtocol prtDetail = new AccountingProcessProtocol(_AccountingProcess.ObjectContext);
//                    prtDetail.PAYERNAME = ep.Payer.Name;
//                    prtDetail.PROTOCOLNAME= ep.Protocol.Name;
//                    prtDetail.PROTOCOLSTATUS = ep.CurrentStateDef.DisplayText;
//                    prtDetail.EPOBJECTID = ep.ObjectID.ToString();
//                    prtDetail.OPENINGDATE = ep.OpeningDate;
//                    _AccountingProcess.AccountingProcessProtocols.Add(prtDetail);
//                }
                
//                // SuperUser anlaşmanın açılış tarihini değiştirebilsin
//                if (Common.CurrentUser.IsSuperUser)
//                    GridEpisodeProtocols.Columns["OPENINGDATE"].ReadOnly = false;
                
//                this.NEWSUBEPISODE.ListFilterExpression = "EPISODE.OBJECTID = '" +  _AccountingProcess.Episode.ObjectID.ToString() + "'";
//                ((ITTListBoxColumn)((ITTGridColumn)this.MedulaProvisionsGrid.Columns["MAltVaka"])).ListFilterExpression = "EPISODE.OBJECTID = '" +  _AccountingProcess.Episode.ObjectID.ToString() + "'";
//                this.OLDSUBEPISODE.ListFilterExpression = "EPISODE.OBJECTID = '" +  _AccountingProcess.Episode.ObjectID.ToString() + "'";
                
//                /**************** MEDULADAN ÖNCE AÇIKTI AŞAĞIDAKİ KISIM KAPATILDI **********************
//                bool readOnly = false;
//                foreach (ITTGridRow row in this.SubEpisodesGrid.Rows)
//                {
//                    readOnly = false;
                    
//                    // Toplu Faturalandı
//                    IList PIList = PayerInvoice.GetCollectedInvoicedByPISubEpisode(_AccountingProcess.ObjectContext, row.TTObject.ObjectID.ToString());
//                    if(PIList.Count > 0)
//                    {
//                        foreach (ITTGridCell cell in row.Cells)
//                            cell.ReadOnly=true;
                        
//                        readOnly = true;
//                    }
//                }
                
//                // SubEpisode mantığına göre çalışanlarda, diş hekimliği faturası Episode bazında kesildiği
//                // için Diş Faturasında da AltVakların pasif yapılması gerekiyor
//                if(TTObjectClasses.SystemParameter.GetParameterValue("INVOICEBYSUBEPISODE", "FALSE") == "TRUE")
//                {
//                    IList PIList = PayerInvoice.GetCollectedInvoicedByEpisodeAndPG(_AccountingProcess.ObjectContext, _AccountingProcess.Episode.ObjectID.ToString(), CollectedInvoiceProcedureGroupEnum.Tooth);
//                    if(PIList.Count > 0)
//                    {
//                        foreach (ITTGridRow row in this.SubEpisodesGrid.Rows)
//                        {
//                            foreach (ITTGridCell cell in row.Cells)
//                                cell.ReadOnly=true;
//                        }
                        
//                    }
//                }
//                 */
//            }
//            else
//                this.GetActionsBtn.Visible = false;
            
//            // Tüm state lerde doldurulmalı
//            /*
//            foreach (ITTGridRow row in this.SubEpisodesGrid.Rows)
//            {
//                SubEpisode se = (SubEpisode)row.TTObject;
//                if (se != null)
//                {
//                    MedulaProvision mp = se.MyMedulaProvision();
//                    if(mp != null)
//                    {
//                        row.Cells["MPOrderNo"].Value = mp.OrderNo == null ? string.Empty : mp.OrderNo.ToString();
//                        row.Cells["MPProvisionNo"].Value = mp.ProvisionNo == null ? string.Empty : mp.ProvisionNo;
//                        row.Cells["MPRelatedProvisionNo"].Value = mp.RelatedProvisionNo == null ? string.Empty : mp.RelatedProvisionNo;
//                        row.Cells["MPProvisionDate"].Value = mp.ProvisionDate;
//                        row.Cells["MPBrans"].Value = mp.Brans == null ? string.Empty : mp.Brans.Code + " : " + mp.Brans.Name;
//                        //row.Cells["MPProvizyonTipi"].Value = mp.ProvizyonTipi == null ? string.Empty : mp.ProvizyonTipi.provizyonTipiKodu + " : " + mp.ProvizyonTipi.provizyonTipiAdi;
//                        //row.Cells["MPSigortaliTuru"].Value = mp.SigortaliTuru == null ? string.Empty : mp.SigortaliTuru.sigortaliTuruKodu + " : " + mp.SigortaliTuru.sigortaliTuruAdi;
//                        //row.Cells["MPTakipTipi"].Value = mp.TakipTipi == null ? string.Empty : mp.TakipTipi.takipTipiKodu + " : " + mp.TakipTipi.takipTipiAdi;
//                        //row.Cells["MPTedaviTipi"].Value = mp.TedaviTipi == null ? string.Empty : mp.TedaviTipi.tedaviTipiKodu + " : " + mp.TedaviTipi.tedaviTipiAdi;
//                        row.Cells["MPTedaviTuru"].Value = mp.TedaviTuru == null ? string.Empty : mp.TedaviTuru.tedaviTuruKodu + " : " + mp.TedaviTuru.tedaviTuruAdi;
//                        //row.Cells["MPDevredilenKurum"].Value = mp.DevredilenKurum == null ? string.Empty : mp.DevredilenKurum.devredilenKurumKodu + " : " + mp.DevredilenKurum.devredilenKurumAdi;
//                        row.Cells["MPStatus"].Value = mp.Status == null ? string.Empty : Common.GetDisplayTextOfDataTypeEnum(mp.Status.Value);
//                        row.Cells["MPState"].Value = mp.CurrentStateDef == null ? string.Empty : mp.CurrentStateDef.DisplayText;
//                    }
//                }
//            }
//            */
//#endregion AccountingProcessForm_PreScript

//            }
            
//        protected override void PostScript(TTObjectStateTransitionDef transDef)
//        {
//#region AccountingProcessForm_PostScript
//    base.PostScript(transDef);
//#endregion AccountingProcessForm_PostScript

//            }
//                }
//}