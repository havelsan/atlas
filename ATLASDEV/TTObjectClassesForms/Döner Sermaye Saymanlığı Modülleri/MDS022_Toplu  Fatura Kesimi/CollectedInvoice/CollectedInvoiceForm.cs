
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
//    /// Toplu Fatura
//    /// </summary>
//    public partial class CollectedInvoiceForm : TTForm
//    {
//        override protected void BindControlEvents()
//        {
//            PatientStatusEnum.SelectedIndexChanged += new TTControlEventDelegate(PatientStatusEnum_SelectedIndexChanged);
//            LISTBUTTON.Click += new TTControlEventDelegate(LISTBUTTON_Click);
//            GRIDPATIENTLIST.CellValueChanged += new TTGridCellEventDelegate(GRIDPATIENTLIST_CellValueChanged);
//            ONDOKUM.Click += new TTControlEventDelegate(ONDOKUM_Click);
//            UnSelectAllButton.Click += new TTControlEventDelegate(UnSelectAllButton_Click);
//            SelectAllButton.Click += new TTControlEventDelegate(SelectAllButton_Click);
//            GETREADY.Click += new TTControlEventDelegate(GETREADY_Click);
//            UnSelectResSectionsButton.Click += new TTControlEventDelegate(UnSelectResSectionsButton_Click);
//            base.BindControlEvents();
//        }

//        override protected void UnBindControlEvents()
//        {
//            PatientStatusEnum.SelectedIndexChanged -= new TTControlEventDelegate(PatientStatusEnum_SelectedIndexChanged);
//            LISTBUTTON.Click -= new TTControlEventDelegate(LISTBUTTON_Click);
//            GRIDPATIENTLIST.CellValueChanged -= new TTGridCellEventDelegate(GRIDPATIENTLIST_CellValueChanged);
//            ONDOKUM.Click -= new TTControlEventDelegate(ONDOKUM_Click);
//            UnSelectAllButton.Click -= new TTControlEventDelegate(UnSelectAllButton_Click);
//            SelectAllButton.Click -= new TTControlEventDelegate(SelectAllButton_Click);
//            GETREADY.Click -= new TTControlEventDelegate(GETREADY_Click);
//            UnSelectResSectionsButton.Click -= new TTControlEventDelegate(UnSelectResSectionsButton_Click);
//            base.UnBindControlEvents();
//        }

//        private void PatientStatusEnum_SelectedIndexChanged()
//        {
//#region CollectedInvoiceForm_PatientStatusEnum_SelectedIndexChanged
//   //Hasta Durumuna Göre Poliklinikler veya Klinikler gride doldurur ve griddeki liste filtrelenir

//            if (TTObjectClasses.SystemParameter.GetParameterValue("FILLRESSECTIONSTOCOLLECTEDINVOICE", "FALSE") == "TRUE")
//            {
//                _CollectedInvoice.CollectedInvoiceResourceLists.DeleteChildren();

//                IList resSectionList = ResSection.GetPoliclinicClinicDepartment(_CollectedInvoice.ObjectContext);
//                foreach (ResSection res in resSectionList)
//                {
//                    if ((_CollectedInvoice.PATIENTSTATUS == OutPatientInPatientEnum.OutPatient || _CollectedInvoice.PATIENTSTATUS == OutPatientInPatientEnum.Daily) && res is ResPoliclinic)
//                    {
//                        CollectedInvoiceResourceList collRes = new CollectedInvoiceResourceList(_CollectedInvoice.ObjectContext);
//                        collRes.ResSection = res;
//                        _CollectedInvoice.CollectedInvoiceResourceLists.Add(collRes);
//                    }
//                    else if (_CollectedInvoice.PATIENTSTATUS == OutPatientInPatientEnum.InPatient && res is ResClinic)
//                    {
//                        CollectedInvoiceResourceList collRes = new CollectedInvoiceResourceList(_CollectedInvoice.ObjectContext);
//                        collRes.ResSection = res;
//                        _CollectedInvoice.CollectedInvoiceResourceLists.Add(collRes);
//                    }
//                }

//                if (GRIDResourceList.Rows.Count > 0)
//                {
//                    if (_CollectedInvoice.PATIENTSTATUS == OutPatientInPatientEnum.OutPatient || _CollectedInvoice.PATIENTSTATUS == OutPatientInPatientEnum.Daily)
//                        ((TTListBoxColumn)GRIDResourceList.Rows[0].Cells["RESOURCENAME"].OwningColumn).ListFilterExpression = "OBJECTDEFNAME IN ('RESPOLICLINIC','RESDEPARTMENT') ";
//                    else if (_CollectedInvoice.PATIENTSTATUS == OutPatientInPatientEnum.InPatient)
//                        ((TTListBoxColumn)GRIDResourceList.Rows[0].Cells["RESOURCENAME"].OwningColumn).ListFilterExpression = "OBJECTDEFNAME IN ('RESCLINIC','RESDEPARTMENT') ";
//                }
//            }
//#endregion CollectedInvoiceForm_PatientStatusEnum_SelectedIndexChanged
//        }

//        private void LISTBUTTON_Click()
//        {
//#region CollectedInvoiceForm_LISTBUTTON_Click
//   /*
//            IList payerInvoiceList = null;
//            IList accTrxList = null;
//            double totalPrice = 0;
//            double lineTotalPrice = 0;
//            bool accTrxExists;
//            Episode episode = null;
//            List<string> specialityList = new List<string>();
//            List<string> policilinicClinicList = new List<string>();

//            List<Guid> resourceGuidList = new List<Guid>();
//            List<Guid> payerGuidList = new List<Guid>();

//            List<string> payerList = new List<string>();
//            List<int> pStatusList = new List<int>();
//            ResDepartment department = null;
//            bool invoiceBySubEpisode = false;

//            policilinicClinicList.Add(Guid.Empty.ToString());
//            resourceGuidList.Add(Guid.Empty);
//            specialityList.Add(Guid.Empty.ToString());
//            DateTime sDate = Convert.ToDateTime(_CollectedInvoice.STARTDATE.Value.ToString("yyyy-MM-dd 00:00:00"));
//            DateTime eDate = Convert.ToDateTime(_CollectedInvoice.ENDDATE.Value.ToString("yyyy-MM-dd 23:59:59"));

//            // Altvaka bazında çalışması için Sistem parametresi TRUE olmalı ve Diş Hekimliği Bilimleri Merkezi Faturası olmamalı
//            // çünkü XXXXXX da diş faturaları altvaka değil vaka bazında kesilecek
//            if (TTObjectClasses.SystemParameter.GetParameterValue("INVOICEBYSUBEPISODE", "FALSE") == "TRUE" && this._CollectedInvoice.TOOTHINVOICE == false)
//                invoiceBySubEpisode = true;

//            foreach (CollectedPatientList patientList in _CollectedInvoice.CollectedPatients)
//                patientList.AccountTransactions.Clear();

//            _CollectedInvoice.CollectedPatients.DeleteChildren();

//            // Bölümler listeye eklenir
//            foreach (CollectedInvoiceResourceList collRes in _CollectedInvoice.CollectedInvoiceResourceLists)
//            {
//                if (collRes.ResSection is ResDepartment)
//                {
//                    department = (ResDepartment)collRes.ResSection;
//                    // Bölüme direkt bağlı poliklinik ve klinikler listeye eklenir
//                    foreach (ResPoliclinic Pol in department.Policlinics)
//                    {
//                        if (invoiceBySubEpisode)
//                        {
//                            policilinicClinicList.Add(Pol.ObjectID.ToString());
//                            resourceGuidList.Add(Pol.ObjectID);
//                        }
//                        else
//                        {
//                            foreach (ResourceSpecialityGrid polSpeciality in Pol.ResourceSpecialities)
//                            {
//                                if (polSpeciality.Speciality != null)
//                                    specialityList.Add(polSpeciality.Speciality.ObjectID.ToString());
//                            }
//                        }
//                    }
//                    foreach (ResClinic Cln in department.Clinics)
//                    {
//                        if (invoiceBySubEpisode)
//                        {
//                            policilinicClinicList.Add(Cln.ObjectID.ToString());
//                            resourceGuidList.Add(Cln.ObjectID);
//                        }
//                        else
//                        {
//                            foreach (ResourceSpecialityGrid clnSpeciality in Cln.ResourceSpecialities)
//                            {
//                                if (clnSpeciality.Speciality != null)
//                                    specialityList.Add(clnSpeciality.Speciality.ObjectID.ToString());
//                            }
//                        }
//                    }

//                    // Bölümün alt bölümleri varsa herbir alt bölümün de poliklinik ve klinikleri listeye eklenmeli
//                    foreach (ResDepartment childDepartment in department.Departments)
//                    {
//                        foreach (ResPoliclinic Pol in childDepartment.Policlinics)
//                        {
//                            if (invoiceBySubEpisode)
//                            {
//                                policilinicClinicList.Add(Pol.ObjectID.ToString());
//                                resourceGuidList.Add(Pol.ObjectID);
//                            }
//                            else
//                            {
//                                foreach (ResourceSpecialityGrid polSpeciality in Pol.ResourceSpecialities)
//                                {
//                                    if (polSpeciality.Speciality != null)
//                                        specialityList.Add(polSpeciality.Speciality.ObjectID.ToString());
//                                }
//                            }
//                        }
//                        foreach (ResClinic Cln in childDepartment.Clinics)
//                        {
//                            if (invoiceBySubEpisode)
//                            {
//                                policilinicClinicList.Add(Cln.ObjectID.ToString());
//                                resourceGuidList.Add(Cln.ObjectID);
//                            }
//                            else
//                            {
//                                foreach (ResourceSpecialityGrid clnSpeciality in Cln.ResourceSpecialities)
//                                {
//                                    if (clnSpeciality.Speciality != null)
//                                        specialityList.Add(clnSpeciality.Speciality.ObjectID.ToString());
//                                }
//                            }
//                        }
//                    }
//                }
//                else
//                {
//                    if (invoiceBySubEpisode)
//                    {
//                        policilinicClinicList.Add(collRes.ResSection.ObjectID.ToString());
//                        resourceGuidList.Add(collRes.ResSection.ObjectID);
//                    }
//                    else
//                    {
//                        foreach (ResourceSpecialityGrid resSpeciality in collRes.ResSection.ResourceSpecialities)
//                        {
//                            if (resSpeciality.Speciality != null)
//                                specialityList.Add(resSpeciality.Speciality.ObjectID.ToString());
//                        }
//                    }
//                }
//            }

//            // Kurumlar listeye eklenir
//            foreach (CollectedInvoicePayerList collPayer in _CollectedInvoice.CollectedInvoicePayerLists)
//            {
//                payerList.Add(collPayer.Payer.ObjectID.ToString());
//                payerGuidList.Add(collPayer.Payer.ObjectID);
//            }

//            // Hasta Durumu listeye eklenir
//            if (_CollectedInvoice.PATIENTSTATUS == null)
//                throw new TTException("Hasta Durumunu seçiniz!");
//            else
//            {
//                if (_CollectedInvoice.PATIENTSTATUS == OutPatientInPatientEnum.OutPatient)
//                    pStatusList.Add(((int)TTObjectClasses.SubEpisodeStatusEnum.Outpatient));
//                else if (_CollectedInvoice.PATIENTSTATUS == OutPatientInPatientEnum.Daily)
//                    pStatusList.Add(((int)TTObjectClasses.SubEpisodeStatusEnum.Daily));
//                else if (_CollectedInvoice.PATIENTSTATUS == OutPatientInPatientEnum.InPatient)
//                {
//                    pStatusList.Add(((int)TTObjectClasses.SubEpisodeStatusEnum.Inpatient));
//                    pStatusList.Add(((int)TTObjectClasses.SubEpisodeStatusEnum.Discharge));
//                }
//            }

//            int procedureGroupFlag;
//            if (_CollectedInvoice.PROCEDUREGROUP != null)
//                procedureGroupFlag = 1;
//            else
//            {
//                procedureGroupFlag = 0;
//                _CollectedInvoice.PROCEDUREGROUP = CollectedInvoiceProcedureGroupEnum.Procedure;  // Sorgu hata vermesi diye set ediliyor
//            }

//            // SubEpisode mantığına göre listeleme
//            if (invoiceBySubEpisode)
//            {
//                SubEpisode subEpisode;
//                string subEpisodeObjectID;
//                int policlinicClinicFlag;

//                if (policilinicClinicList.Count > 1) // Empty Guid i biz eklediğimiz için > 1 şeklinde kontrol ediyoruz
//                    policlinicClinicFlag = 1;
//                else
//                    policlinicClinicFlag = 0;

//                if (_CollectedInvoice.LISTTYPE == false)
//                {
//                    lineTotalPrice = 0;
//                    subEpisode = null;
//                    subEpisodeObjectID = string.Empty;
//                    accTrxExists = false;

//                    // AutoScript Toplu Faturaya Hazır a getirecek ise (CollectedPatients a AccountTransaction lar eklenmez)
//                    if (TTObjectClasses.SystemParameter.GetParameterValue("READYTOCOLLECTEDINVOICEBYAUTOSCRIPT", "FALSE") == "TRUE")
//                    {
//                        // Tutar gelmeyecekse SubEpisode dan çekilebilir
//                        if (TTObjectClasses.SystemParameter.GetParameterValue("SHOWPRICEATCOLLECTEDINVOICELIST", "FALSE") == "FALSE")
//                        {
//                            BindingList<SubEpisode.GetSubEpisodeAccountTransaction_RQ_Class> subEpisodes = SubEpisode.GetSubEpisodeAccountTransaction_RQ(sDate, eDate, pStatusList.ToArray(), policlinicClinicFlag, resourceGuidList.ToArray(), payerGuidList.ToArray());
//                            List<Guid> episodeGuidList = new List<Guid>();
//                            List<Guid> subEpisodeGuidList = new List<Guid>();
//                            List<Guid> addedSubEpisodeGuidList = new List<Guid>();
//                            string episodeFilterExpression = null;
//                            string subEpisodeFilterExpression = null;
                            
//                            foreach (SubEpisode.GetSubEpisodeAccountTransaction_RQ_Class subEpisode_RQ in subEpisodes)
//                            {
//                                if(subEpisode_RQ.Episode.HasValue && episodeGuidList.Contains(subEpisode_RQ.Episode.Value) == false)
//                                    episodeGuidList.Add(subEpisode_RQ.Episode.Value);
//                                if(subEpisode_RQ.ObjectID.HasValue && subEpisodeGuidList.Contains(subEpisode_RQ.ObjectID.Value) == false)
//                                    subEpisodeGuidList.Add(subEpisode_RQ.ObjectID.Value);
//                            }
                            
//                            if(episodeGuidList.Count > 0)
//                            {
//                                episodeFilterExpression = Common.CreateFilterExpressionOfGuidList(episodeFilterExpression, episodeGuidList);
//                                _CollectedInvoice.ObjectContext.QueryObjects<Episode>(episodeFilterExpression);
//                            }
                            
//                            if(subEpisodeGuidList.Count > 0)
//                            {
//                                subEpisodeFilterExpression = Common.CreateFilterExpressionOfGuidList(subEpisodeFilterExpression, subEpisodeGuidList);
//                                _CollectedInvoice.ObjectContext.QueryObjects<SubEpisode>(subEpisodeFilterExpression);
//                            }
                            
//                            foreach (SubEpisode.GetSubEpisodeAccountTransaction_RQ_Class subEpisode_RQ in subEpisodes)
//                            {
//                                if (subEpisode_RQ.ObjectID.HasValue && addedSubEpisodeGuidList.Contains(subEpisode_RQ.ObjectID.Value) == false)
//                                {
//                                    CollectedPatientList collPatient = new CollectedPatientList(_CollectedInvoice.ObjectContext);
//                                    _CollectedInvoice.CollectedPatients.Add(collPatient);

//                                    collPatient.OpeningDate = subEpisode_RQ.OpeningDate;
//                                    collPatient.PayerName = subEpisode_RQ.Payername;
//                                    //collPatient.RetirementFundID = subEpisode_RQ.RetirementFundID;
//                                    collPatient.UniqueRefNo = subEpisode_RQ.UniqueRefNo;
//                                    collPatient.HospitalProtocolNo = subEpisode_RQ.HospitalProtocolNo;
//                                    collPatient.PatientName = subEpisode_RQ.Name;
//                                    collPatient.PatientSurname = subEpisode_RQ.Surname;
//                                    collPatient["EPISODE"] = subEpisode_RQ.Episode;
//                                    collPatient["SUBEPISODE"] = subEpisode_RQ.ObjectID;
//                                    collPatient["PAYER"] = subEpisode_RQ.Payer;
//                                    collPatient.Invoiced = true;
                                    
//                                    addedSubEpisodeGuidList.Add(subEpisode_RQ.ObjectID.Value);
//                                }
//                            }
//                        }
//                        else // Tutarın gelmesi isteniyorsa AccountTransaction dan çekilmeli
//                        {
//                            BindingList<AccountTransaction.GetTransactionsForCollectedInvoice_SE_RQ_Class> accTrxsList = AccountTransaction.GetTransactionsForCollectedInvoice_SE_RQ(_CollectedInvoice.ObjectContext, sDate, eDate, payerList.ToArray(), pStatusList.ToArray(), policilinicClinicList.ToArray(), policlinicClinicFlag);
//                            foreach(AccountTransaction.GetTransactionsForCollectedInvoice_SE_RQ_Class accTrx in accTrxsList)
//                            {
//                                accTrxExists = true;
//                                if (subEpisodeObjectID != accTrx.SubEpisode.ToString())
//                                {
//                                    if(subEpisodeObjectID != string.Empty)
//                                        _CollectedInvoice.CollectedPatients[_CollectedInvoice.CollectedPatients.Count-1].TotalPrice = lineTotalPrice;

//                                    CollectedPatientList collPatient = new CollectedPatientList(_CollectedInvoice.ObjectContext);
//                                    _CollectedInvoice.CollectedPatients.Add(collPatient);

//                                    collPatient.OpeningDate = accTrx.OpeningDate;
//                                    collPatient.PayerName = accTrx.Name;
//                                    //collPatient.RetirementFundID = accTrx.RetirementFundID;
//                                    collPatient.UniqueRefNo = accTrx.UniqueRefNo;
//                                    collPatient.HospitalProtocolNo = accTrx.HospitalProtocolNo;
//                                    collPatient.PatientName = accTrx.Name1;
//                                    collPatient.PatientSurname = accTrx.Surname;
//                                    collPatient["EPISODE"] = accTrx.Episode;
//                                    collPatient["SUBEPISODE"] = accTrx.SubEpisode;
//                                    collPatient["PAYER"] = accTrx.Payer;
//                                    collPatient.Invoiced = true;

//                                    lineTotalPrice = 0;
//                                    subEpisodeObjectID = accTrx.SubEpisode.ToString();
//                                }
//                                lineTotalPrice = lineTotalPrice + (double)(accTrx.UnitPrice * accTrx.Amount);
//                                totalPrice = totalPrice + (double)(accTrx.UnitPrice * accTrx.Amount);
//                            }
//                            if (accTrxExists == true && _CollectedInvoice.CollectedPatients.Count > 0)
//                                _CollectedInvoice.CollectedPatients[_CollectedInvoice.CollectedPatients.Count-1].TotalPrice = lineTotalPrice;
//                        }
//                    }
//                    else // Hemen Toplu Faturaya Hazır a getirilecek ise (CollectedPatients a AccountTransaction lar eklenir)
//                    {
//                        accTrxList = AccountTransaction.GetTransactionsForCollectedInvoice_SE(_CollectedInvoice.ObjectContext, sDate, eDate, payerList.ToArray(), pStatusList.ToArray(), policilinicClinicList.ToArray(), policlinicClinicFlag);
//                        foreach (AccountTransaction accTrx in accTrxList)
//                        {
//                            accTrxExists = true;
//                            if (subEpisode != accTrx.SubEpisode)
//                            {
//                                if (subEpisode != null)
//                                    _CollectedInvoice.CollectedPatients[_CollectedInvoice.CollectedPatients.Count - 1].TotalPrice = lineTotalPrice;

//                                CollectedPatientList collPatient = new CollectedPatientList(_CollectedInvoice.ObjectContext);
//                                _CollectedInvoice.CollectedPatients.Add(collPatient);

//                                collPatient.OpeningDate = accTrx.EpisodeProtocol.Episode.OpeningDate;
//                                collPatient.PayerName = accTrx.EpisodeProtocol.Payer.Name;
//                                //collPatient.RetirementFundID = accTrx.EpisodeProtocol.Episode.Patient.RetirementFundID;
//                                collPatient.UniqueRefNo = accTrx.EpisodeProtocol.Episode.Patient.UniqueRefNo;
//                                collPatient.HospitalProtocolNo = accTrx.EpisodeProtocol.Episode.HospitalProtocolNo.Value;
//                                collPatient.PatientName = accTrx.EpisodeProtocol.Episode.Patient.Name;
//                                collPatient.PatientSurname = accTrx.EpisodeProtocol.Episode.Patient.Surname;

//                                collPatient.Episode = accTrx.EpisodeProtocol.Episode;
//                                collPatient.SubEpisode = accTrx.SubEpisode;
//                                collPatient.Payer = accTrx.EpisodeProtocol.Payer;
//                                collPatient.Invoiced = true;
//                                lineTotalPrice = 0;
//                                subEpisode = accTrx.SubEpisode;
//                            }
//                            _CollectedInvoice.CollectedPatients[_CollectedInvoice.CollectedPatients.Count - 1].AccountTransactions.Add(accTrx);
//                            lineTotalPrice = lineTotalPrice + (double)(accTrx.UnitPrice * accTrx.Amount);
//                            totalPrice = totalPrice + (double)(accTrx.UnitPrice * accTrx.Amount);
//                        }
//                        if (accTrxExists == true && _CollectedInvoice.CollectedPatients.Count > 0)
//                            _CollectedInvoice.CollectedPatients[_CollectedInvoice.CollectedPatients.Count - 1].TotalPrice = lineTotalPrice;
//                    }
//                }
//                else if (_CollectedInvoice.LISTTYPE == true)
//                {
//                    PayerInvoice.GetReadyPayerInvoiceForCollInv_SE(_CollectedInvoice.ObjectContext, sDate, eDate, payerList.ToArray(), pStatusList.ToArray(), policilinicClinicList.ToArray(), policlinicClinicFlag, _CollectedInvoice.PROCEDUREGROUP.Value, procedureGroupFlag);

//                    BindingList<PayerInvoice.GetReadyPayerInvoiceForCollectedInvoice_SE_Class> payerInvList = PayerInvoice.GetReadyPayerInvoiceForCollectedInvoice_SE(_CollectedInvoice.ObjectContext, sDate, eDate, payerList.ToArray(), pStatusList.ToArray(), policilinicClinicList.ToArray(), policlinicClinicFlag, _CollectedInvoice.PROCEDUREGROUP.Value, procedureGroupFlag);
//                    foreach (PayerInvoice.GetReadyPayerInvoiceForCollectedInvoice_SE_Class payerInv in payerInvList)
//                    {
//                        CollectedPatientList collPatient = new CollectedPatientList(_CollectedInvoice.ObjectContext);

//                        collPatient.OpeningDate = payerInv.OpeningDate;
//                        collPatient.PayerName = payerInv.Name;
//                        //collPatient.RetirementFundID = payerInv.RetirementFundID;
//                        collPatient.UniqueRefNo = payerInv.UniqueRefNo;
//                        collPatient.HospitalProtocolNo = payerInv.HospitalProtocolNo;
//                        collPatient.PatientName = payerInv.Name1;
//                        collPatient.PatientSurname = payerInv.Surname;
//                        collPatient.TotalPrice = payerInv.TotalPrice;
//                        collPatient["PAYERINVOICE"] = payerInv.ObjectID;
//                        collPatient.Invoiced = true;

//                        totalPrice = totalPrice + (double)payerInv.TotalPrice;
//                        _CollectedInvoice.CollectedPatients.Add(collPatient);
//                    }
//                }
//            }
//            else  // Episode mantığına göre listeleme
//            {
//                int specialityFlag;
//                string episodeObjectID;

//                if (specialityList.Count > 1) // Empty Guid i biz eklediğimiz için > 1 şeklinde kontrol ediyoruz
//                    specialityFlag = 1;
//                else
//                    specialityFlag = 0;

//                // XXXXXX da diş faturası Episode bazlı kesilecek
//                if (TTObjectClasses.SystemParameter.GetParameterValue("INVOICEBYSUBEPISODE", "FALSE") == "TRUE" && this._CollectedInvoice.TOOTHINVOICE == true)
//                {
//                    if (_CollectedInvoice.LISTTYPE == false)
//                    {
//                        lineTotalPrice = 0;
//                        episode = null;
//                        accTrxExists = false;
//                        episodeObjectID = string.Empty;

//                        // AutoScript Toplu Faturaya Hazır a getirecek ise (CollectedPatients a AccountTransaction lar eklenmez)
//                        if (TTObjectClasses.SystemParameter.GetParameterValue("READYTOCOLLECTEDINVOICEBYAUTOSCRIPT", "FALSE") == "TRUE")
//                        {
//                            BindingList<AccountTransaction.GetTransactionsForCollectedInvoiceByRes_Tooth_RQ_Class> accTrxsList = AccountTransaction.GetTransactionsForCollectedInvoiceByRes_Tooth_RQ(_CollectedInvoice.ObjectContext, sDate, eDate, payerList.ToArray(), pStatusList.ToArray(), specialityList.ToArray(), specialityFlag);
//                            foreach (AccountTransaction.GetTransactionsForCollectedInvoiceByRes_Tooth_RQ_Class accTrx in accTrxsList)
//                            {
//                                accTrxExists = true;
//                                if (episodeObjectID != accTrx.Episode.ToString())
//                                {
//                                    if (episodeObjectID != string.Empty)
//                                        _CollectedInvoice.CollectedPatients[_CollectedInvoice.CollectedPatients.Count - 1].TotalPrice = lineTotalPrice;

//                                    CollectedPatientList collPatient = new CollectedPatientList(_CollectedInvoice.ObjectContext);
//                                    _CollectedInvoice.CollectedPatients.Add(collPatient);

//                                    collPatient.OpeningDate = accTrx.OpeningDate;
//                                    collPatient.PayerName = accTrx.Name;
//                                    //collPatient.RetirementFundID = accTrx.RetirementFundID;
//                                    collPatient.UniqueRefNo = accTrx.UniqueRefNo;
//                                    collPatient.HospitalProtocolNo = accTrx.HospitalProtocolNo;
//                                    collPatient.PatientName = accTrx.Name1;
//                                    collPatient.PatientSurname = accTrx.Surname;
//                                    collPatient["EPISODE"] = accTrx.Episode;
//                                    collPatient["PAYER"] = accTrx.Payer;
//                                    collPatient.Invoiced = true;

//                                    lineTotalPrice = 0;
//                                    episodeObjectID = accTrx.Episode.ToString();
//                                }
//                                lineTotalPrice = lineTotalPrice + (double)(accTrx.UnitPrice * accTrx.Amount);
//                                totalPrice = totalPrice + (double)(accTrx.UnitPrice * accTrx.Amount);
//                            }
//                            if (accTrxExists == true && _CollectedInvoice.CollectedPatients.Count > 0)
//                                _CollectedInvoice.CollectedPatients[_CollectedInvoice.CollectedPatients.Count - 1].TotalPrice = lineTotalPrice;
//                        }
//                        else // Hemen Toplu Faturaya Hazır a getirilecek ise (CollectedPatients a AccountTransaction lar eklenir)
//                        {
//                            accTrxList = AccountTransaction.GetTransactionsForCollectedInvoiceByResource_Tooth(_CollectedInvoice.ObjectContext, sDate, eDate, payerList.ToArray(), pStatusList.ToArray(), specialityList.ToArray(), specialityFlag);
//                            foreach (AccountTransaction accTrx in accTrxList)
//                            {
//                                accTrxExists = true;
//                                if (episode != accTrx.EpisodeProtocol.Episode)
//                                {
//                                    if (episode != null)
//                                        _CollectedInvoice.CollectedPatients[_CollectedInvoice.CollectedPatients.Count - 1].TotalPrice = lineTotalPrice;

//                                    CollectedPatientList collPatient = new CollectedPatientList(_CollectedInvoice.ObjectContext);
//                                    _CollectedInvoice.CollectedPatients.Add(collPatient);

//                                    collPatient.OpeningDate = accTrx.EpisodeProtocol.Episode.OpeningDate;
//                                    collPatient.PayerName = accTrx.EpisodeProtocol.Payer.Name;
//                                    //collPatient.RetirementFundID = accTrx.EpisodeProtocol.Episode.Patient.RetirementFundID;
//                                    collPatient.UniqueRefNo = accTrx.EpisodeProtocol.Episode.Patient.UniqueRefNo;
//                                    collPatient.HospitalProtocolNo = accTrx.EpisodeProtocol.Episode.HospitalProtocolNo.Value;
//                                    collPatient.PatientName = accTrx.EpisodeProtocol.Episode.Patient.Name;
//                                    collPatient.PatientSurname = accTrx.EpisodeProtocol.Episode.Patient.Surname;

//                                    collPatient.Episode = accTrx.EpisodeProtocol.Episode;
//                                    collPatient.Payer = accTrx.EpisodeProtocol.Payer;
//                                    collPatient.Invoiced = true;
//                                    lineTotalPrice = 0;
//                                    episode = accTrx.EpisodeProtocol.Episode;
//                                }
//                                _CollectedInvoice.CollectedPatients[_CollectedInvoice.CollectedPatients.Count - 1].AccountTransactions.Add(accTrx);
//                                lineTotalPrice = lineTotalPrice + (double)(accTrx.UnitPrice * accTrx.Amount);
//                                totalPrice = totalPrice + (double)(accTrx.UnitPrice * accTrx.Amount);
//                            }
//                            if (accTrxExists == true && _CollectedInvoice.CollectedPatients.Count > 0)
//                                _CollectedInvoice.CollectedPatients[_CollectedInvoice.CollectedPatients.Count - 1].TotalPrice = lineTotalPrice;
//                        }
//                    }
//                    else if (_CollectedInvoice.LISTTYPE == true) // Sadece Toplu Faturaya Hazır a getirilmiş ve Hizmet Grubu Diş olarak seçilmişler için çalışacak
//                    {
//                        if (_CollectedInvoice.PROCEDUREGROUP == CollectedInvoiceProcedureGroupEnum.Tooth)
//                        {
//                            BindingList<PayerInvoice.GetReadyPayerInvoiceForCollectedInvoice_Tooth_Class> payerInvList = PayerInvoice.GetReadyPayerInvoiceForCollectedInvoice_Tooth(_CollectedInvoice.ObjectContext, sDate, eDate, payerList.ToArray(), pStatusList.ToArray(), specialityList.ToArray(), specialityFlag, _CollectedInvoice.PROCEDUREGROUP.Value, procedureGroupFlag);
//                            foreach (PayerInvoice.GetReadyPayerInvoiceForCollectedInvoice_Tooth_Class payerInv in payerInvList)
//                            {
//                                CollectedPatientList collPatient = new CollectedPatientList(_CollectedInvoice.ObjectContext);

//                                collPatient.OpeningDate = payerInv.OpeningDate;
//                                collPatient.PayerName = payerInv.Name;
//                                //collPatient.RetirementFundID = payerInv.RetirementFundID;
//                                collPatient.UniqueRefNo = payerInv.UniqueRefNo;
//                                collPatient.HospitalProtocolNo = payerInv.HospitalProtocolNo;
//                                collPatient.PatientName = payerInv.Name1;
//                                collPatient.PatientSurname = payerInv.Surname;
//                                collPatient.TotalPrice = payerInv.TotalPrice;
//                                collPatient["PAYERINVOICE"] = payerInv.ObjectID;
//                                collPatient.Invoiced = true;

//                                totalPrice = totalPrice + (double)payerInv.TotalPrice;
//                                _CollectedInvoice.CollectedPatients.Add(collPatient);
//                            }
//                        }
//                    }
//                }
//                else  // Episode bazında kesilen diğer XXXXXXler
//                {
//                    if (_CollectedInvoice.LISTTYPE == false)
//                    {
//                        lineTotalPrice = 0;
//                        episode = null;
//                        accTrxExists = false;

//                        //accTrxList = AccountTransaction.GetTransactionsForCollectedInvoiceByResource(_CollectedInvoice.ObjectContext, sDate, eDate, payerList.ToArray(), pStatusList.ToArray(), specialityList.ToArray(), specialityFlag);
//                        if (_CollectedInvoice.PATIENTSTATUS == OutPatientInPatientEnum.OutPatient)
//                            accTrxList = AccountTransaction.GetTransactionsForCollInvByResource_OutPatient(_CollectedInvoice.ObjectContext, sDate, eDate, payerList.ToArray(), specialityList.ToArray(), specialityFlag);
//                        else if (_CollectedInvoice.PATIENTSTATUS == OutPatientInPatientEnum.InPatient)
//                            accTrxList = AccountTransaction.GetTransactionsForCollInvByResource_InPatient(_CollectedInvoice.ObjectContext, sDate, eDate, payerList.ToArray(), specialityList.ToArray(), specialityFlag);

//                        if (accTrxList != null)
//                        {
//                            foreach (AccountTransaction accTrx in accTrxList)
//                            {
//                                accTrxExists = true;
//                                if (episode != accTrx.EpisodeProtocol.Episode)
//                                {
//                                    if (episode != null)
//                                        _CollectedInvoice.CollectedPatients[_CollectedInvoice.CollectedPatients.Count - 1].TotalPrice = lineTotalPrice;

//                                    CollectedPatientList collPatient = new CollectedPatientList(_CollectedInvoice.ObjectContext);
//                                    _CollectedInvoice.CollectedPatients.Add(collPatient);

//                                    collPatient.OpeningDate = accTrx.EpisodeProtocol.Episode.OpeningDate;
//                                    collPatient.PayerName = accTrx.EpisodeProtocol.Payer.Name;
//                                    //collPatient.RetirementFundID = accTrx.EpisodeProtocol.Episode.Patient.RetirementFundID;
//                                    collPatient.UniqueRefNo = accTrx.EpisodeProtocol.Episode.Patient.UniqueRefNo;
//                                    collPatient.HospitalProtocolNo = accTrx.EpisodeProtocol.Episode.HospitalProtocolNo.Value;
//                                    collPatient.PatientName = accTrx.EpisodeProtocol.Episode.Patient.Name;
//                                    collPatient.PatientSurname = accTrx.EpisodeProtocol.Episode.Patient.Surname;

//                                    collPatient.Episode = accTrx.EpisodeProtocol.Episode;
//                                    collPatient.Payer = accTrx.EpisodeProtocol.Payer;
//                                    collPatient.Invoiced = true;
//                                    lineTotalPrice = 0;
//                                    episode = accTrx.EpisodeProtocol.Episode;
//                                }
//                                _CollectedInvoice.CollectedPatients[_CollectedInvoice.CollectedPatients.Count - 1].AccountTransactions.Add(accTrx);
//                                lineTotalPrice = lineTotalPrice + (double)(accTrx.UnitPrice * accTrx.Amount);
//                                totalPrice = totalPrice + (double)(accTrx.UnitPrice * accTrx.Amount);
//                            }
//                        }

//                        if (accTrxExists == true && _CollectedInvoice.CollectedPatients.Count > 0)
//                            _CollectedInvoice.CollectedPatients[_CollectedInvoice.CollectedPatients.Count - 1].TotalPrice = lineTotalPrice;
//                    }
//                    else if (_CollectedInvoice.LISTTYPE == true)
//                    {
//                        BindingList<PayerInvoice.GetReadyPayerInvoiceForCollectedInvoice_Class> payerInvList = PayerInvoice.GetReadyPayerInvoiceForCollectedInvoice(_CollectedInvoice.ObjectContext, sDate, eDate, payerList.ToArray(), pStatusList.ToArray(), specialityList.ToArray(), specialityFlag, _CollectedInvoice.PROCEDUREGROUP.Value, procedureGroupFlag);
//                        foreach (PayerInvoice.GetReadyPayerInvoiceForCollectedInvoice_Class payerInv in payerInvList)
//                        {
//                            CollectedPatientList collPatient = new CollectedPatientList(_CollectedInvoice.ObjectContext);

//                            collPatient.OpeningDate = payerInv.OpeningDate;
//                            collPatient.PayerName = payerInv.Name;
//                            //collPatient.RetirementFundID = payerInv.RetirementFundID;
//                            collPatient.UniqueRefNo = payerInv.UniqueRefNo;
//                            collPatient.HospitalProtocolNo = payerInv.HospitalProtocolNo;
//                            collPatient.PatientName = payerInv.Name1;
//                            collPatient.PatientSurname = payerInv.Surname;
//                            collPatient.TotalPrice = payerInv.TotalPrice;
//                            collPatient["EPISODE"] = payerInv.Episode;
//                            collPatient["PAYER"] = payerInv.Payer;
//                            collPatient["PAYERINVOICE"] = payerInv.ObjectID;
//                            collPatient.Invoiced = true;

//                            totalPrice = totalPrice + (double)payerInv.TotalPrice;
//                            _CollectedInvoice.CollectedPatients.Add(collPatient);
//                        }
//                    }
//                }
//            }

//            // Listeleme sorgusu çakmasın diye set edilen PROCEDUREGROUP tekrar null lanır
//            if (procedureGroupFlag == 0)
//                _CollectedInvoice.PROCEDUREGROUP = null;

//            _CollectedInvoice.TotalPrice = totalPrice;
//            */
//#endregion CollectedInvoiceForm_LISTBUTTON_Click
//        }

//        private void GRIDPATIENTLIST_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
//        {
//#region CollectedInvoiceForm_GRIDPATIENTLIST_CellValueChanged
//   if (columnIndex == 8 && rowIndex != -1)
//            {
//                if (GRIDPATIENTLIST.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "False")
//                    _CollectedInvoice.TotalPrice = _CollectedInvoice.TotalPrice - Convert.ToDouble(GRIDPATIENTLIST.Rows[rowIndex].Cells[7].Value);
//                else if (GRIDPATIENTLIST.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "True")
//                    _CollectedInvoice.TotalPrice = _CollectedInvoice.TotalPrice + Convert.ToDouble(GRIDPATIENTLIST.Rows[rowIndex].Cells[7].Value);
//            }
//#endregion CollectedInvoiceForm_GRIDPATIENTLIST_CellValueChanged
//        }

//        private void ONDOKUM_Click()
//        {
//#region CollectedInvoiceForm_ONDOKUM_Click
//   /*
//            Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();

//            TTReportTool.PropertyCache<object> documentNo = new TTReportTool.PropertyCache<object>();
//            if (_CollectedInvoice.CollectedInvoiceDocument.DocumentNo == null)
//                documentNo.Add("VALUE", " ");
//            else
//                documentNo.Add("VALUE", _CollectedInvoice.CollectedInvoiceDocument.DocumentNo);

//            // Kurumlar listeye eklenir
//            List<string> payerArray = new List<string>();
//            foreach (CollectedInvoicePayerList collPayer in _CollectedInvoice.CollectedInvoicePayerLists)
//            {
//                payerArray.Add(collPayer.Payer.ObjectID.ToString());
//            }
//            TTReportTool.PropertyCache<object> payers = new TTReportTool.PropertyCache<object>();
//            payers.Add("VALUE", payerArray);

//            List<string> specialityList = new List<string>();
//            //List<string> policlinicClinicList = new List<string>();
//            //policlinicClinicList.Add(Guid.Empty.ToString());
//            ResDepartment department = null;

//            // Bölümler listeye eklenir
//            foreach (CollectedInvoiceResourceList collRes in _CollectedInvoice.CollectedInvoiceResourceLists)
//            {
//                if (collRes.ResSection is ResDepartment)
//                {
//                    department = (ResDepartment)collRes.ResSection;
//                    // Bölüme direkt bağlı poliklinik ve klinikler listeye eklenir
//                    foreach (ResPoliclinic Pol in department.Policlinics)
//                    {
//                        //policlinicClinicList.Add(Pol.ObjectID.ToString());
//                        foreach (ResourceSpecialityGrid polSpeciality in Pol.ResourceSpecialities)
//                        {
//                            if (polSpeciality.Speciality != null)
//                                specialityList.Add(polSpeciality.Speciality.ObjectID.ToString());
//                        }
//                    }
//                    foreach (ResClinic Cln in department.Clinics)
//                    {
//                        //policlinicClinicList.Add(Cln.ObjectID.ToString());
//                        foreach (ResourceSpecialityGrid clnSpeciality in Cln.ResourceSpecialities)
//                        {
//                            if (clnSpeciality.Speciality != null)
//                                specialityList.Add(clnSpeciality.Speciality.ObjectID.ToString());
//                        }
//                    }

//                    // Bölümün alt bölümleri varsa herbir alt bölümün de poliklinik ve klinikleri listeye eklenmeli
//                    foreach (ResDepartment childDepartment in department.Departments)
//                    {
//                        foreach (ResPoliclinic Pol in childDepartment.Policlinics)
//                        {
//                            //policlinicClinicList.Add(Pol.ObjectID.ToString());
//                            foreach (ResourceSpecialityGrid polSpeciality in Pol.ResourceSpecialities)
//                            {
//                                if (polSpeciality.Speciality != null)
//                                    specialityList.Add(polSpeciality.Speciality.ObjectID.ToString());
//                            }
//                        }
//                        foreach (ResClinic Cln in childDepartment.Clinics)
//                        {
//                            //policlinicClinicList.Add(Cln.ObjectID.ToString());
//                            foreach (ResourceSpecialityGrid clnSpeciality in Cln.ResourceSpecialities)
//                            {
//                                if (clnSpeciality.Speciality != null)
//                                    specialityList.Add(clnSpeciality.Speciality.ObjectID.ToString());
//                            }
//                        }
//                    }
//                }
//                else
//                {
//                    //policlinicClinicList.Add(collRes.ResSection.ObjectID.ToString());
//                    foreach (ResourceSpecialityGrid resSpeciality in collRes.ResSection.ResourceSpecialities)
//                    {
//                        if (resSpeciality.Speciality != null)
//                            specialityList.Add(resSpeciality.Speciality.ObjectID.ToString());
//                    }
//                }
//            }

//            TTReportTool.PropertyCache<object> specialities = new TTReportTool.PropertyCache<object>();
//            specialities.Add("VALUE", specialityList);

//            // Faturalanacak olarak seçilmiş episode lar listeye eklenir
//            int counter = 0;
//            List<string> episodeList = new List<string>();
//            List<string> subEpisodeList = new List<string>();
//            List<string> payerInvoiceList = new List<string>();
//            foreach (CollectedPatientList patientList in this._CollectedInvoice.CollectedPatients)
//            {
//                if (patientList.Invoiced == true)
//                {
//                    if (_CollectedInvoice.LISTTYPE == true)
//                        payerInvoiceList.Add(patientList.PayerInvoice.ObjectID.ToString());
//                    else
//                    {
//                        episodeList.Add(patientList.Episode.ObjectID.ToString());
//                        if (patientList.SubEpisode != null)
//                            subEpisodeList.Add(patientList.SubEpisode.ObjectID.ToString());
//                    }
//                    counter++;
//                }
//            }

//            if (counter == 0)
//                InfoBox.Show("Faturalanacak hasta seçilmemiştir!", MessageIconEnum.WarningMessage);
//            else
//            {
//                parameters.Add("DOCUMENTNO", documentNo);

//                // SubEpisode mantığına göre öndöküm
//                if (TTObjectClasses.SystemParameter.GetParameterValue("INVOICEBYSUBEPISODE", "FALSE") == "TRUE")
//                {
//                    List<string> resourceFilterList = new List<string>();
//                    resourceFilterList.Add(Guid.Empty.ToString());
//                    TTReportTool.PropertyCache<object> resourceFilter = new TTReportTool.PropertyCache<object>();
//                    resourceFilter.Add("VALUE", resourceFilterList);

//                    parameters.Add("RESOURCEFILTER", resourceFilter);

//                    TTReportTool.PropertyCache<object> startDate = new TTReportTool.PropertyCache<object>();
//                    startDate.Add("VALUE", _CollectedInvoice.STARTDATE);
//                    parameters.Add("STARTDATE", startDate);

//                    TTReportTool.PropertyCache<object> endDate = new TTReportTool.PropertyCache<object>();
//                    endDate.Add("VALUE", _CollectedInvoice.ENDDATE);
//                    parameters.Add("ENDDATE", endDate);

//                    if (_CollectedInvoice.LISTTYPE == false)
//                    {
//                        if (this._CollectedInvoice.TOOTHINVOICE == true) // Diş Faturasının Öndökümü (Vaka bazında)
//                        {
//                            TTReportTool.PropertyCache<object> episodes = new TTReportTool.PropertyCache<object>();
//                            episodes.Add("VALUE", episodeList);
//                            parameters.Add("EPISODES", episodes);
//                            TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_CollectedInvoiceProcDetPrvReport_NoCheck_Tooth), true, 1, parameters);
//                        }
//                        else
//                        {
//                            TTReportTool.PropertyCache<object> subEpisodes = new TTReportTool.PropertyCache<object>();
//                            subEpisodes.Add("VALUE", subEpisodeList);
//                            parameters.Add("SUBEPISODES", subEpisodes);
//                            TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_CollectedInvoiceProcDetPrvReport_NoCheck_SE), true, 1, parameters);
//                        }
//                    }
//                    else if (_CollectedInvoice.LISTTYPE == true)
//                    {
//                        TTReportTool.PropertyCache<object> payerInvoices = new TTReportTool.PropertyCache<object>();
//                        payerInvoices.Add("VALUE", payerInvoiceList);
//                        parameters.Add("PAYERINVOICES", payerInvoices);

//                        if (this._CollectedInvoice.TOOTHINVOICE == true) // Diş Faturasının Öndökümü (Vaka bazında)
//                            TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_CollectedInvoiceProcDetPrvReport_Check_Tooth), true, 1, parameters);
//                        else // Altvakalı versiyonun öndökümü
//                            TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_CollectedInvoiceProcDetPrvReport_Check_SE), true, 1, parameters);
//                    }
//                }
//                else // Episode mantığına göre öndöküm
//                {
//                    TTReportTool.PropertyCache<object> episodes = new TTReportTool.PropertyCache<object>();
//                    episodes.Add("VALUE", episodeList);

//                    TTReportTool.PropertyCache<object> payerInvoices = new TTReportTool.PropertyCache<object>();
//                    payerInvoices.Add("VALUE", payerInvoiceList);

//                    List<string> specialityFilterList = new List<string>();
//                    specialityFilterList.Add(Guid.Empty.ToString());
//                    TTReportTool.PropertyCache<object> specialityFilter = new TTReportTool.PropertyCache<object>();
//                    specialityFilter.Add("VALUE", specialityFilterList);

//                    int pStatus;
//                    if (_CollectedInvoice.PATIENTSTATUS == OutPatientInPatientEnum.OutPatient)
//                        pStatus = 0;
//                    else if (_CollectedInvoice.PATIENTSTATUS == OutPatientInPatientEnum.InPatient)
//                        pStatus = 1;
//                    else
//                        pStatus = 2;

//                    TTReportTool.PropertyCache<object> patientStatus = new TTReportTool.PropertyCache<object>();
//                    patientStatus.Add("VALUE", pStatus);

//                    parameters.Add("PAYERS", payers);
//                    parameters.Add("RESOURCES", specialities);
//                    parameters.Add("RESOURCESFILTER", specialityFilter);
//                    parameters.Add("EPISODES", episodes);
//                    parameters.Add("PAYERINVOICES", payerInvoices);
//                    parameters.Add("PATIENTSTATUS", patientStatus);

//                    if (_CollectedInvoice.LISTTYPE == false)
//                    {
//                        if (specialityList.Count > 0)
//                            TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_CollectedInvoiceProcDetPrvReport_NoCheck_2), true, 1, parameters);
//                        else
//                            TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_CollectedInvoiceProcDetPrvReport_NoCheck_1), true, 1, parameters);
//                    }
//                    else if (_CollectedInvoice.LISTTYPE == true)
//                    {
//                        if (_CollectedInvoice.PROCEDUREGROUP == null)
//                        {
//                            if (specialityList.Count > 0)
//                                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_CollectedInvoiceProcDetPrvReport_Check_2), true, 1, parameters);
//                            else
//                                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_CollectedInvoiceProcDetPrvReport_Check_1), true, 1, parameters);
//                        }
//                        else
//                        {
//                            TTReportTool.PropertyCache<object> procedureGroup = new TTReportTool.PropertyCache<object>();
//                            procedureGroup.Add("VALUE", (int)_CollectedInvoice.PROCEDUREGROUP.Value);
//                            parameters.Add("PROCEDUREGROUP", procedureGroup);

//                            if (specialityList.Count > 0)
//                                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_CollectedInvoiceProcDetPrvReport_Check_4), true, 1, parameters);
//                            else
//                                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_CollectedInvoiceProcDetPrvReport_Check_3), true, 1, parameters);
//                        }
//                    }
//                }
//            }
//          */
//#endregion CollectedInvoiceForm_ONDOKUM_Click
//        }

//        private void UnSelectAllButton_Click()
//        {
//#region CollectedInvoiceForm_UnSelectAllButton_Click
//   if (this._CollectedInvoice.CurrentStateDefID == CollectedInvoice.States.New)
//            {
//                _CollectedInvoice.TotalPrice = 0;
//                foreach (CollectedPatientList patientList in this._CollectedInvoice.CollectedPatients)
//                {
//                    patientList.Invoiced = false;
//                }

//            }
//#endregion CollectedInvoiceForm_UnSelectAllButton_Click
//        }

//        private void SelectAllButton_Click()
//        {
//#region CollectedInvoiceForm_SelectAllButton_Click
//   if (this._CollectedInvoice.CurrentStateDefID == CollectedInvoice.States.New)
//            {
//                _CollectedInvoice.TotalPrice = 0;
//                foreach (CollectedPatientList patientList in this._CollectedInvoice.CollectedPatients)
//                {
//                    patientList.Invoiced = true;
//                    _CollectedInvoice.TotalPrice = _CollectedInvoice.TotalPrice + patientList.TotalPrice;
//                }

//            }
//#endregion CollectedInvoiceForm_SelectAllButton_Click
//        }

//        private void GETREADY_Click()
//        {
//#region CollectedInvoiceForm_GETREADY_Click
//   // AutoScript Toplu Faturaya Hazır a getirecek ise
//            if (TTObjectClasses.SystemParameter.GetParameterValue("READYTOCOLLECTEDINVOICEBYAUTOSCRIPT", "FALSE") == "TRUE")
//            {
//                if (TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "Seçilen vakaların hepsi Toplu Faturaya Hazır durumuna getirilmek için işaretlenecektir.\nDevam etmek istediğinize emin misiniz?") == "E")
//                {
//                    int count = 0;
//                    TTObjectContext objectContext = new TTObjectContext(false);

//                    ReadyToCollectedInvoice readyToCollInvoice = new ReadyToCollectedInvoice(objectContext);
//                    readyToCollInvoice.CurrentStateDefID = ReadyToCollectedInvoice.States.New;
//                    readyToCollInvoice.CashierLog = this._CollectedInvoice.CollectedInvoiceDocument.CashierLog;
//                    readyToCollInvoice.ProcedureGroup = this._CollectedInvoice.PROCEDUREGROUP;
//                    readyToCollInvoice.PATIENTSTATUS = this._CollectedInvoice.PATIENTSTATUS;
//                    readyToCollInvoice.STARTDATE = this._CollectedInvoice.STARTDATE;
//                    readyToCollInvoice.ENDDATE = this._CollectedInvoice.ENDDATE;
//                    readyToCollInvoice.WorkListDescription = this._CollectedInvoice.CollectedInvoiceDocument.CashierLog.ResUser.Name;

//                    if (!(TTObjectClasses.SystemParameter.GetParameterValue("INVOICEBYSUBEPISODE", "FALSE") == "TRUE" && this._CollectedInvoice.TOOTHINVOICE == false))
//                    {
//                        if (this._CollectedInvoice.PATIENTSTATUS == OutPatientInPatientEnum.OutPatient || this._CollectedInvoice.PATIENTSTATUS == OutPatientInPatientEnum.Daily)
//                            readyToCollInvoice.PayerInvoicePatientStatus = PayerInvoicePatientStatusEnum.OutPatient;
//                        else if (this._CollectedInvoice.PATIENTSTATUS == OutPatientInPatientEnum.InPatient)
//                            readyToCollInvoice.PayerInvoicePatientStatus = PayerInvoicePatientStatusEnum.InPatient;
//                    }

//                    foreach (CollectedPatientList patientList in this._CollectedInvoice.CollectedPatients)
//                    {
//                        if (patientList.Invoiced == true)
//                        {
//                            if (patientList.PayerInvoice == null)
//                            {
//                                ReadyToCollectedInvoiceDetail readyToCollInvDetail = new ReadyToCollectedInvoiceDetail(objectContext);
//                                readyToCollInvDetail.CurrentStateDefID = ReadyToCollectedInvoiceDetail.States.New;
//                                readyToCollInvDetail["EPISODE"] = patientList["EPISODE"];
//                                readyToCollInvDetail["SUBEPISODE"] = patientList["SUBEPISODE"];
//                                readyToCollInvDetail.TotalPrice = patientList.TotalPrice;
//                                readyToCollInvoice.ReadyToCollectedInvoiceDetails.Add(readyToCollInvDetail);
//                                count++;
//                            }
//                        }
//                    }

//                    if (count > 0)
//                    {
//                        objectContext.Save();
//                        InfoBox.Show(count + " adet Toplu Faturaya Hazır durumuna getirme için işaretleme işlemi yapıldı.", MessageIconEnum.InformationMessage);
//                    }
//                    else
//                        InfoBox.Show("Hiç hasta seçilmediği için Toplu Faturaya Hazır durumuna getirme için işaretleme işlemi yapılamadı.", MessageIconEnum.InformationMessage);

//                    objectContext.Dispose();

//                    this.Close();
//                }
//                else
//                    InfoBox.Show("Toplu Faturaya Hazır durumuna getirme için işaretleme işlemi iptal edildi.", MessageIconEnum.InformationMessage);
//            }
//            else // Hemen Toplu Faturaya Hazır a getirilecek
//            {
//                if (TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "Seçilen vakaların hepsi Toplu Faturaya Hazır durumuna getirilecektir (Kabul Sebebi 'Portör Muayenesi' veya 'Periyodik Muayene' olan yada 'hasta grubu XXXXXX Çalışan/Ailesi olup, Toplu Fatura Harici Tutulan Sağlık Kurulu işlemi bulunan' vakalar hariç).\nDevam etmek istediğinize emin misiniz?") == "E")
//                {
//                    int count = 0;
//                    string error = "";
//                    bool isActiveInpatient;
//                    HealthCommittee hc = null;

//                    foreach (CollectedPatientList patientList in this._CollectedInvoice.CollectedPatients)
//                    {
//                        if (patientList.Invoiced == true)
//                        {
//                            if (patientList.PayerInvoice == null)
//                            {
//                                // Kabul Sebebi Portör Muayenesi veya Periyodik Muayene değilse Toplu Faturaya Hazır a getirilir
//                                if (patientList.Episode != null && patientList.SubEpisode.PatientAdmission.AdmissionType != null)
//                                {
//                                    if (patientList.SubEpisode.PatientAdmission.AdmissionType != AdmissionTypeEnum.PortorExamination && patientList.SubEpisode.PatientAdmission.AdmissionType != AdmissionTypeEnum.PeriodicExamination)
//                                    {
//                                        isActiveInpatient = false;

//                                        // Aktif Yatış Kontrolü
//                                        foreach (InpatientAdmission trtClnc in patientList.Episode.InpatientAdmissions)
//                                        {
//                                            if (trtClnc.CurrentStateDefID == InpatientAdmission.States.ClinicProcedure)
//                                            {
//                                                isActiveInpatient = true;
//                                                break;
//                                            }
//                                        }

//                                        if (!isActiveInpatient)
//                                        {
//                                            // SUT 4.2.14'üncü maddeye istinaden eklenen kısım (Issue: 6595 , 7092)
//                                            // XXXXXX Çalışan ve aileleri için fatura edilmemesi gereken Sağlık Kurulu işlemi olan vakalar hazıra alınmaz
//                                            hc = patientList.Episode.GetNotCollectedInvoicableHealthCommittee();
//                                            if (hc == null)
//                                            {
//                                                TTObjectContext objectContext = new TTObjectContext(false);

//                                                try
//                                                {
//                                                    PayerInvoice payerInvoice = new PayerInvoice(objectContext);
//                                                    payerInvoice.CurrentStateDefID = PayerInvoice.States.New;
//                                                    payerInvoice.Episode = patientList.Episode;
//                                                    payerInvoice.Payer = patientList.Payer;

//                                                    if (patientList.SubEpisode != null)
//                                                        payerInvoice.PISubEpisode = patientList.SubEpisode;
//                                                    else
//                                                    {
//                                                        if (this._CollectedInvoice.PATIENTSTATUS == OutPatientInPatientEnum.OutPatient || this._CollectedInvoice.PATIENTSTATUS == OutPatientInPatientEnum.Daily)
//                                                            payerInvoice.PATIENTSTATUS = PayerInvoicePatientStatusEnum.OutPatient;
//                                                        else if (this._CollectedInvoice.PATIENTSTATUS == OutPatientInPatientEnum.InPatient)
//                                                            payerInvoice.PATIENTSTATUS = PayerInvoicePatientStatusEnum.InPatient;
//                                                    }

//                                                    payerInvoice.CashOfficeName = this._CollectedInvoice.CashOfficeName;
//                                                    payerInvoice.PROCEDUREGROUP = this._CollectedInvoice.PROCEDUREGROUP;
//                                                    payerInvoice.TotalDiscountEntry = 0;
//                                                    payerInvoice.TotalPrice = patientList.TotalPrice;
//                                                    payerInvoice.TotalDiscountPrice = 0;
//                                                    payerInvoice.GeneralTotalPrice = patientList.TotalPrice;

//                                                    payerInvoice.PayerInvoiceDocument = new PayerInvoiceDocument(objectContext);
//                                                    payerInvoice.PayerInvoiceDocument.CurrentStateDefID = PayerInvoiceDocument.States.New;
//                                                    payerInvoice.PayerInvoiceDocument.CashierLog = this._CollectedInvoice.CollectedInvoiceDocument.CashierLog;
//                                                    payerInvoice.PayerInvoiceDocument.DocumentDate = Common.RecTime();
//                                                    payerInvoice.PayerInvoiceDocument.Payer = patientList.Payer;
//                                                    payerInvoice.PayerInvoiceDocument.TotalDiscountPrice = 0;
//                                                    payerInvoice.PayerInvoiceDocument.TotalPrice = payerInvoice.TotalPrice;

//                                                    foreach (AccountTransaction accountTrx in patientList.AccountTransactions)
//                                                    {
//                                                        AccountTransaction accTrx = (AccountTransaction)objectContext.GetObject(accountTrx.ObjectID, accountTrx.ObjectDef.Name);

//                                                        if (payerInvoice.Protocol == null)
//                                                            //payerInvoice.Protocol = accTrx.EpisodeProtocol.Protocol;

//                                                        if (accTrx.SubActionProcedure != null)
//                                                        {
//                                                            if ((accTrx.SubActionProcedure.PackageDefinition != null))
//                                                            {
//                                                                PayerInvoicePackage invpack = new PayerInvoicePackage(objectContext);
//                                                                invpack.ActionDate = accTrx.TransactionDate.Value;
//                                                                invpack.PackageCode = accTrx.ExternalCode;
//                                                                invpack.PackageName = accTrx.Description;
//                                                                invpack.Amount = (int)accTrx.Amount;
//                                                                invpack.PackagePrice = accTrx.UnitPrice;
//                                                                invpack.TotalPrice = (double)((int)accTrx.Amount * accTrx.UnitPrice);
//                                                                invpack.Paid = true;
//                                                                invpack.PackageAccountTransaction.Add(accTrx);

//                                                                payerInvoice.PayerInvoicePackages.Add(invpack);
//                                                            }
//                                                            else
//                                                            {
//                                                                PayerInvoiceProcedure invproc = new PayerInvoiceProcedure(objectContext);
//                                                                invproc.ActionDate = accTrx.TransactionDate.Value;
//                                                                invproc.Description = accTrx.Description;
//                                                                invproc.ExternalCode = accTrx.ExternalCode;
//                                                                invproc.Amount = (int)accTrx.Amount;
//                                                                invproc.UnitPrice = accTrx.UnitPrice;
//                                                                invproc.TotalPrice = (double)((int)accTrx.Amount * accTrx.UnitPrice);
//                                                                invproc.Paid = true;
//                                                                invproc.AccountTransaction.Add(accTrx);

//                                                                payerInvoice.PayerInvoiceProcedures.Add(invproc);
//                                                            }
//                                                        }
//                                                        else if (accTrx.SubActionMaterial != null)
//                                                        {
//                                                            PayerInvoiceMaterial invmat = new PayerInvoiceMaterial(objectContext);
//                                                            invmat.ActionDate = (DateTime)accTrx.TransactionDate;
//                                                            invmat.Description = accTrx.Description;
//                                                            invmat.ExternalCode = accTrx.ExternalCode;
//                                                            invmat.Amount = accTrx.Amount;
//                                                            invmat.UnitPrice = accTrx.UnitPrice;
//                                                            invmat.TotalPrice = (double)(accTrx.Amount * accTrx.UnitPrice);
//                                                            invmat.Paid = true;
//                                                            invmat.AccountTransaction.Add(accTrx);

//                                                            payerInvoice.PayerInvoiceMaterials.Add(invmat);
//                                                        }
//                                                    }

//                                                    payerInvoice.Update();
//                                                    payerInvoice.CurrentStateDefID = PayerInvoice.States.ReadyToCollectedInvoice;

//                                                    objectContext.Save();
//                                                    count++;
//                                                }
//                                                catch (Exception ex)
//                                                {
//                                                    error += patientList.Episode.HospitalProtocolNo + ",";
//                                                }
//                                                finally
//                                                {
//                                                    objectContext.Dispose();
//                                                }
//                                            }
//                                            else
//                                                error += patientList.Episode.HospitalProtocolNo + ",";
//                                        }
//                                        else
//                                            error += patientList.Episode.HospitalProtocolNo + ",";
//                                    }
//                                    else
//                                        error += patientList.Episode.HospitalProtocolNo + ",";
//                                }
//                                else
//                                    error += patientList.Episode.HospitalProtocolNo + ",";
//                            }
//                        }
//                    }

//                    if (error == "")
//                        InfoBox.Show(count + " adet Toplu Faturaya Hazır durumuna getirme işlemi yapıldı.", MessageIconEnum.InformationMessage);
//                    else
//                        InfoBox.Show(count + " adet Toplu Faturaya Hazır durumuna getirme işlemi yapıldı. Fakat Toplu Faturaya Hazır durumuna getirilemeyen vakalar var. Protokol Numaraları : \r\n" + error, MessageIconEnum.InformationMessage);

//                    // Toplu Faturaya Hazır a getirme işleminden sonra bu sefer de Toplu Faturaya Hazırlar listelenmeye çalışılınca
//                    // Update Command hatası alındığı için form kapatılıyor
//                    this.Close();
//                }
//                else
//                    InfoBox.Show("Toplu Faturaya Hazır durumuna getirme işlemi iptal edildi.", MessageIconEnum.InformationMessage);
//            }
//#endregion CollectedInvoiceForm_GETREADY_Click
//        }

//        private void UnSelectResSectionsButton_Click()
//        {
//#region CollectedInvoiceForm_UnSelectResSectionsButton_Click
//   _CollectedInvoice.CollectedInvoiceResourceLists.DeleteChildren();
//#endregion CollectedInvoiceForm_UnSelectResSectionsButton_Click
//        }

//        protected override void PreScript()
//        {
//#region CollectedInvoiceForm_PreScript
//    if (_CollectedInvoice.CurrentStateDefID == CollectedInvoice.States.New)
//            {
//                this.LISTBUTTON.ReadOnly = false;
//                this.ONDOKUM.ReadOnly = false;

//                ResUser _myResUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;

//                CashierLog _myCashierLog = null;
//                if (_myResUser != null)
//                    _myCashierLog = (CashierLog)_myResUser.GetOpenCashCashierLog();

//                if (_myCashierLog == null)
//                    throw new TTUtils.TTException(SystemMessage.GetMessage(210));
//                else
//                {
//                    /*
//                    if (_myCashierLog.CashOffice.Type != CashOfficeTypeEnum.InvoicingService)
//                        throw new TTUtils.TTException(SystemMessage.GetMessage(210));
//                    else
//                    {
//                     */
//                    this.cmdOK.Visible = false;
//                    _CollectedInvoice.CashOfficeName = _myCashierLog.CashOffice.Name;
//                    if (_CollectedInvoice.CollectedInvoiceDocument == null)
//                    {
//                        _CollectedInvoice.CollectedInvoiceDocument = new CollectedInvoiceDocument(_CollectedInvoice.ObjectContext);
//                        _CollectedInvoice.CollectedInvoiceDocument.CashierLog = _myCashierLog;
//                        _CollectedInvoice.CollectedInvoiceDocument.DocumentDate = Common.RecTime();
//                        _CollectedInvoice.CollectedInvoiceDocument.TotalPrice = 0;
//                        _CollectedInvoice.CollectedInvoiceDocument.CurrentStateDefID = CollectedInvoiceDocument.States.New;
//                    }
//                    //}
//                }
//                _CollectedInvoice.STARTDATE = Common.RecTime();
//                _CollectedInvoice.ENDDATE = Common.RecTime();
//                _CollectedInvoice.LISTTYPE = false;
//                _CollectedInvoice.TOOTHINVOICE = false;
//                _CollectedInvoice.PATIENTSTATUS = OutPatientInPatientEnum.OutPatient;

//                if (TTObjectClasses.SystemParameter.GetParameterValue("INVOICEBYSUBEPISODE", "FALSE") == "TRUE")
//                    this.TOOTHINVOICE.Visible = true;
//                else
//                    this.TOOTHINVOICE.Visible = false;

//                //SGK tipindeki aktif kurumları gride doldurur
//                IList payerList = PayerDefinition.GetActiveSGKPayers(_CollectedInvoice.ObjectContext);
//                foreach (PayerDefinition payer in payerList)
//                {
//                    CollectedInvoicePayerList collPayer = new CollectedInvoicePayerList(_CollectedInvoice.ObjectContext);
//                    collPayer.Payer = payer;
//                    _CollectedInvoice.CollectedInvoicePayerLists.Add(collPayer);
//                }
                
//                if (TTObjectClasses.SystemParameter.GetParameterValue("ENABLECOLLECTEDINVOICEGETREADYBUTTON", "TRUE") == "FALSE")
//                    this.GETREADY.ReadOnly = true;
//                else
//                    this.GETREADY.ReadOnly = false;
                
//            }
//            else
//            {
//                /*
//                this.LISTBUTTON.ReadOnly = true;
//                this.ONDOKUM.ReadOnly = true;
//                this.SelectAllButton.ReadOnly = true;
//                this.UnSelectAllButton.ReadOnly = true;
//                this.GETREADY.ReadOnly = true;
//                this.UnSelectResSectionsButton.ReadOnly = true;

//                if (TTObjectClasses.SystemParameter.GetParameterValue("INVOICEBYSUBEPISODE", "FALSE") == "TRUE")
//                {
//                    if (this._CollectedInvoice.TOOTHINVOICE == true)
//                    {
//                        this.DropCurrentStateReport(typeof(TTReportClasses.I_CollectedInvoiceProcedureDetailReport));
//                        this.DropCurrentStateReport(typeof(TTReportClasses.I_CollectedInvoiceProcedureDetailReport_SE));
//                        this.DropCurrentStateReport(typeof(TTReportClasses.I_CollectedInvoiceProcedureDetailReport2));
//                        this.DropCurrentStateReport(typeof(TTReportClasses.I_CollectedInvoiceProcedureDetailReport_SE2));
//                        this.DropCurrentStateReport(typeof(TTReportClasses.I_CollectedInvoicePreReport));
//                        this.DropCurrentStateReport(typeof(TTReportClasses.I_CollectedInvoicePreReport_SE));
//                        this.DropCurrentStateReport(typeof(TTReportClasses.I_CollectedInvoiceListReport));
//                        this.DropCurrentStateReport(typeof(TTReportClasses.I_CollectedInvoiceListReport_SE));
//                        this.DropCurrentStateReport(typeof(TTReportClasses.I_CollectedInvoiceCoverPage));
//                        this.DropCurrentStateReport(typeof(TTReportClasses.I_CollectedInvoiceCoverPage_SE));
//                    }
//                    else
//                    {
//                        if (_CollectedInvoice.LISTTYPE == true)
//                        {
//                            this.DropCurrentStateReport(typeof(TTReportClasses.I_CollectedInvoiceProcedureDetailReport));
//                            this.DropCurrentStateReport(typeof(TTReportClasses.I_CollectedInvoiceProcedureDetailReport_SE));
//                        }
//                        else
//                        {
//                            this.DropCurrentStateReport(typeof(TTReportClasses.I_CollectedInvoiceProcedureDetailReport2));
//                            this.DropCurrentStateReport(typeof(TTReportClasses.I_CollectedInvoiceProcedureDetailReport_SE2));
//                        }
//                        this.DropCurrentStateReport(typeof(TTReportClasses.I_CollectedInvoiceCoverPage_Tooth));
//                        this.DropCurrentStateReport(typeof(TTReportClasses.I_CollectedInvoiceListReport_Tooth));
//                        this.DropCurrentStateReport(typeof(TTReportClasses.I_CollectedInvoicePreReport_Tooth));
//                        this.DropCurrentStateReport(typeof(TTReportClasses.I_CollectedInvoiceProcedureDetailReport_Tooth));
//                    }

//                    this.TOOTHINVOICE.Visible = true;
//                }
//                else
//                {
//                    this.DropCurrentStateReport(typeof(TTReportClasses.I_CollectedInvoicePreReport_SE));
//                    this.DropCurrentStateReport(typeof(TTReportClasses.I_CollectedInvoiceListReport_SE));
//                    this.DropCurrentStateReport(typeof(TTReportClasses.I_CollectedInvoiceCoverPage_SE));
//                    this.DropCurrentStateReport(typeof(TTReportClasses.I_CollectedInvoiceProcedureDetailReport_SE));
//                    this.DropCurrentStateReport(typeof(TTReportClasses.I_CollectedInvoiceProcedureDetailReport_SE2));
//                    this.DropCurrentStateReport(typeof(TTReportClasses.I_CollectedInvoiceCoverPage_Tooth));
//                    this.DropCurrentStateReport(typeof(TTReportClasses.I_CollectedInvoiceListReport_Tooth));
//                    this.DropCurrentStateReport(typeof(TTReportClasses.I_CollectedInvoicePreReport_Tooth));
//                    this.DropCurrentStateReport(typeof(TTReportClasses.I_CollectedInvoiceProcedureDetailReport_Tooth));

//                    if (_CollectedInvoice.LISTTYPE == true)
//                        this.DropCurrentStateReport(typeof(TTReportClasses.I_CollectedInvoiceProcedureDetailReport));
//                    else
//                        this.DropCurrentStateReport(typeof(TTReportClasses.I_CollectedInvoiceProcedureDetailReport2));

//                    this.TOOTHINVOICE.Visible = false;
//                }
//                */
//            }
//#endregion CollectedInvoiceForm_PreScript

//            }
            
//        protected override void PostScript(TTObjectStateTransitionDef transDef)
//        {
//#region CollectedInvoiceForm_PostScript
//    base.PostScript(transDef);
//#endregion CollectedInvoiceForm_PostScript

//            }
            
//        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
//        {
//#region CollectedInvoiceForm_ClientSidePostScript
//    base.ClientSidePostScript(transDef);

//            if (transDef != null && transDef.FromStateDefID == CollectedInvoice.States.New && transDef.ToStateDefID == CollectedInvoice.States.CollectedInvoiced)
//            {
//                if (_CollectedInvoice.CollectedInvoiceDocument.DocumentNo != null)
//                {
//                    IList CIDList = CollectedInvoiceDocument.CheckRepeatedDocumentNo(_CollectedInvoice.ObjectContext, _CollectedInvoice.CollectedInvoiceDocument.DocumentNo);
//                    if (CIDList.Count > 0)
//                    {
//                        foreach (CollectedInvoiceDocument ColInvDoc in CIDList)
//                        {
//                            string res = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "", "Bu fatura numarası " + ColInvDoc.DocumentDate.ToString() + "  tarihli " + ColInvDoc.AccountAction.ID.ToString() + " işlem nolu toplu faturada kullanılmıştır. Devam etmek istiyor musunuz?");
//                            if (res == "H")
//                                throw new Exception("Toplu Fatura İşleminden Vazgeçildi! ");
//                            break;
//                        }
//                    }
//                }
//            }
//#endregion CollectedInvoiceForm_ClientSidePostScript

//        }

//#region CollectedInvoiceForm_Methods
//        /*
//        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
//        {
//            base.AfterContextSavedScript(transDef);

//            if(transDef != null && transDef.ToStateDefID == CollectedInvoice.States.CollectedInvoiced)
//            {
//                Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                
//                TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
//                cache.Add("VALUE", _CollectedInvoice.ObjectID.ToString());
                
//                parameters.Add("TTOBJECTID",cache);
                
//                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_CollectedInvoiceReport), true, 1, parameters);
                
//                if(TTObjectClasses.SystemParameter.GetParameterValue("INVOICEBYSUBEPISODE", "FALSE") == "TRUE")
//                {
//                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_CollectedInvoicePreReport_SE), true, 1, parameters);
//                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_CollectedInvoiceListReport_SE), true, 1, parameters);
//                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_CollectedInvoiceCoverPage_SE), true, 1, parameters);
                    
//                    if(_CollectedInvoice.LISTTYPE == true)
//                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_CollectedInvoiceProcedureDetailReport_SE2), true, 1, parameters);
//                    else
//                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_CollectedInvoiceProcedureDetailReport_SE), true, 1, parameters);
//                }
//                else
//                {
//                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_CollectedInvoicePreReport), true, 1, parameters);
//                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_CollectedInvoiceListReport), true, 1, parameters);
//                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_CollectedInvoiceCoverPage), true, 1, parameters);
                    
//                    if(_CollectedInvoice.LISTTYPE == true)
//                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_CollectedInvoiceProcedureDetailReport2), true, 1, parameters);
//                    else
//                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_CollectedInvoiceProcedureDetailReport), true, 1, parameters);
//                }
//            }
//        }
//        */
        
//#endregion CollectedInvoiceForm_Methods
//    }
//}