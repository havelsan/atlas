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
    /// Radyoloji Tetkik
    /// </summary>
    public partial class RadiologyTest : SubactionProcedureFlowable, IAppointmentDef, ITreatmentMaterialCollection, INumaratorAppointment
    {
        public partial class RadiologyTestAppointmentInfoQuery_Class : TTReportNqlObject
        {
        }

        public partial class RadiologyTestResultReport_Class : TTReportNqlObject
        {
        }

        public partial class RadiologyTestPatientInfoReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetCancelledRadiologyTest_Class : TTReportNqlObject
        {
        }

        public partial class RadiologyTestByObjectIDQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetRadiologyTestByEpisode_Class : TTReportNqlObject
        {
        }

        public partial class GetRadiologyTestBySubEpisode_Class : TTReportNqlObject
        {
        }

        public partial class GetByRadTestWorklistDateReport_Class : TTReportNqlObject
        {
            #region GetByRadTestWorklistDateReport_Methods
            public string RefNo
            {
                get
                {
                    if (Foreign == true)
                        return "(*) " + Convert.ToString(ForeignUniqueRefNo);
                    else
                        return Convert.ToString(UniqueRefNo);
                }
            }
            #endregion GetByRadTestWorklistDateReport_Methods
        }

        public partial class GetRadiologyTestStatisticsByFilter_Class : TTReportNqlObject
        {
        }

        public partial class GetByRadTestFilterExpressionReport_Class : TTReportNqlObject
        {
            #region GetByRadTestFilterExpressionReport_Methods
            public string RefNo
            {
                get
                {
                    if (Foreign == true)
                        return "(*) " + Convert.ToString(ForeignUniqueRefNo);
                    else
                        return Convert.ToString(UniqueRefNo);
                }
            }
            #endregion GetByRadTestFilterExpressionReport_Methods
        }

        public partial class VEM_RADYOLOJI_SONUC_Class : TTReportNqlObject
        {
        }

        #region INumaratorAppointment Members

        public AppointmentTypeEnum GetNumaratorAppointmentType()
        {
            return NumaratorAppointmentType;
        }

        public Resource GetNumaratorAppointmentMasterResource()
        {
            return NumaratorAppointmentMasterResource;
        }

        public Resource GetNumaratorAppointmentResource()
        {
            return NumaratorAppointmentResource;
        }
        #endregion

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "TESTTOOTHNUMBER":
                    {
                        ToothNumberEnum? value = (ToothNumberEnum?)(int?)newValue;
                        #region TESTTOOTHNUMBER_SetScript
                        if (value.HasValue)
                        {
                            DentalPosition = Common.SetDentalPosition((int)value);
                        }
                        #endregion TESTTOOTHNUMBER_SetScript
                    }

                    break;
                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;
            }
        }

        protected override void PostInsert()
        {
            #region PostInsert
            base.PostInsert();

            // Veri aktarimindan geliyorsa account isi yapmamali
            if (IsOldAction != true)
            {
                AccountOperation();

                foreach (AccountTransaction AccTrx in AccountTransactions)
                {
                    if (AccTrx.CurrentStateDefID != AccountTransaction.States.Cancelled && ToothNumber != null)
                    {
                        if (AccTrx.Description.IndexOf(" (Diş No: ") == -1) // Yeni ekleme
                            AccTrx.Description = AccTrx.Description + " (Diş No: " + ToothNumber + ")";
                        else
                        {
                            // ToothNumber değişmişse AccTrx i de güncelleme
                            if (AccTrx.Description.IndexOf(" (Diş No: " + ToothNumber + ")") == -1)
                                AccTrx.Description = AccTrx.Description.Substring(0, AccTrx.Description.IndexOf(" (Diş No: ")) + " (Diş No: " + ToothNumber + ")";
                        }
                    }
                }

                if (ToothNumber != null)
                    ExtraDescription = "(Diş No: " + ToothNumber + ")";
                else
                    ExtraDescription = null;

                //Dıs Laboratuvarda yapilacak olan radyoloji testleri icin ucretlendirme yapilacak
                //if (this.ResObservationUnit.IsExternalObservationUnit == true)
                //    this.AccountOperation(AccountOperationTimeEnum.PREPOST);

                // Ücretli Hasta ise ücretlendirme işlemini yapar
                //this.AccountOperationIfPaidPatient();
                // Ücretli Hasta ise ve vakada sağlık kurulu işlemi varsa ücreti(AccountTransaction) iptal durumuna alır
                CancelPatientAccTrxsIfHealthCommittee();





            }

            //if(!this.RadiologyRequestNo.Value.HasValue)
            //    this.RadiologyRequestNo.GetNextValue();
            #endregion PostInsert
        }

        protected override void PostUpdate()
        {
            #region PostUpdate
            base.PostUpdate();
            if (Report != null)
            {
                var rep = Common.CUCase(Common.GetTextOfRTFString(Report.ToString()), false, false);
                if (rep.Length > 4000)
                {
                    ReportTxt = rep.Substring(0, 4000);
                }
                else
                {
                    ReportTxt = rep;
                }
            }

            foreach (AccountTransaction AccTrx in AccountTransactions)
            {
                if (AccTrx.CurrentStateDefID != AccountTransaction.States.Cancelled && ToothNumber != null)
                {
                    if (AccTrx.Description.IndexOf(" (Diş No: ") == -1) // Yeni ekleme
                        AccTrx.Description = AccTrx.Description + " (Diş No: " + ToothNumber + ")";
                    else
                    {
                        // ToothNumber değişmişse AccTrx i de güncelleme
                        if (AccTrx.Description.IndexOf(" (Diş No: " + ToothNumber + ")") == -1)
                            AccTrx.Description = AccTrx.Description.Substring(0, AccTrx.Description.IndexOf(" (Diş No: ")) + " (Diş No: " + ToothNumber + ")";
                    }
                }
            }

            if (ToothNumber != null)
                ExtraDescription = "(Diş No: " + ToothNumber + ")";
            else
                ExtraDescription = null;
            CancelPatientAccTrxsIfHealthCommittee();
            #endregion PostUpdate
        }

        protected void PostTransition_Approve2ResultEntry()
        {
            // From State : Approve   To State : ResultEntry
            #region PostTransition_Approve2ResultEntry
            if (ApprovedBy != null)
                ProcedureDoctor = ApprovedBy;
            #endregion PostTransition_Approve2ResultEntry
        }

        protected void PreTransition_Approve2Reported()
        {
            // From State : Approve   To State : Completed
            #region PreTransition_Approve2Reported
            CheckIfReportIsRequiredForMedulaInpatient();
            #endregion PreTransition_Approve2Reported
        }

        protected void PostTransition_Approve2Reported()
        {
            // From State : Approve   To State : Completed
            #region PostTransition_Approve2Reported
            CompleteSMSForRadiologyTest();
            ReportDate = Common.RecTime();
            PerformedDate = ReportDate;
            AutoCompleteParentObject(RadiologyTest.States.Completed, Radiology.States.Completed);

            //ENabız 409 paketi icin sendtoenabız tablosuna kayıt olusturuluyor. 
            if (IsOldAction != true && ((RadiologyTest)this).ExternalServiceRequests.Count <= 0)
            {
                new SendToENabiz(ObjectContext, SubEpisode, ObjectID, ObjectDef.Name, "102", Common.RecTime());
                new SendToENabiz(ObjectContext, SubEpisode, ObjectID, ObjectDef.Name, "409", Common.RecTime());
            }

            SendSmsForRadiologyTestReported();
            #endregion PostTransition_Approve2Reported
        }

        protected void UndoTransition_Approve2Reported(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Approve   To State : Completed
            #region UndoTransition_Approve2Reported
            //this.Radiology.CurrentStateDefID = Radiology.States.Procedure;
            AutoUndoParentObjectLastTranstion();
            #endregion UndoTransition_Approve2Reported
        }

        protected void PostTransition_Approve2Procedure()
        {
            // From State : Approve   To State : Procedure
            #region PostTransition_Approve2Procedure
            IsProcedureRepeated = true;
            #endregion PostTransition_Approve2Procedure
        }

        protected void PostTransition_Appointment2AdmissionAppointment()
        {
            // From State : Appointment   To State : AdmissionAppointment
            #region PostTransition_Appointment2AdmissionAppointment
            //this.CancelMyAccountTransactions();
            #endregion PostTransition_Appointment2AdmissionAppointment
        }

        protected void UndoTransition_Appointment2AdmissionAppointment(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Appointment   To State : AdmissionAppointment
            #region UndoTransition_Appointment2AdmissionAppointment
            throw new TTException(SystemMessage.GetMessage(935));
            #endregion UndoTransition_Appointment2AdmissionAppointment
        }

        protected void PreTransition_ResultEntry2Reported()
        {
            // From State : ResultEntry   To State : Completed
            #region reTransition_ResultEntry2Reported
            CheckIfReportIsRequiredForMedulaInpatient();
            #endregion reTransition_ResultEntry2Reported
        }

        protected void PostTransition_ResultEntry2Reported()
        {
            // From State : ResultEntry   To State : Completed
            #region PostTransition_ResultEntry2Reported
            CompleteSMSForRadiologyTest();
            string sysparam = TTObjectClasses.SystemParameter.GetParameterValue("HL7ENGINEALIVE", null);
            if (sysparam == "TRUE")
            {
                List<Guid> appIDs = new List<Guid>();
                appIDs.Add(ObjectID);
                try
                {
                    //TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.MediumPriority, "InternalTCPClient", "HL7Remoting", "SendHospitalMessageToEngine", null, appIDs, "ORU", "PACS");
                }
                catch
                {
                    IsMessageInPACS = false;
                    throw;
                }
            }

            ReportDate = Common.RecTime();
            PerformedDate = ReportDate;
            AutoCompleteParentObject(RadiologyTest.States.Completed, Radiology.States.Completed);

            //ENabız 409 paketi icin sendtoenabız tablosuna kayıt olusturuluyor. 
            if (IsOldAction != true && ((RadiologyTest)this).ExternalServiceRequests.Count <= 0)
            {
                new SendToENabiz(ObjectContext, SubEpisode, ObjectID, ObjectDef.Name, "102", Common.RecTime());
                new SendToENabiz(ObjectContext, SubEpisode, ObjectID, ObjectDef.Name, "409", Common.RecTime());
            }

            SendSmsForRadiologyTestReported();
            #endregion PostTransition_ResultEntry2Reported
        }

        protected void UndoTransition_ResultEntry2Reported(TTObjectStateTransitionDef transitionDef)
        {
            // From State : ResultEntry   To State : Reported
            #region UndoTransition_ResultEntry2Reported
            AutoUndoParentObjectLastTranstion();
            #endregion UndoTransition_ResultEntry2Reported
        }

        protected void PreTransition_Procedure2Approve()
        {
            // From State : Procedure   To State : Approve
            #region PreTransition_Procedure2Approve
            if (OlapDate == null)
                OlapDate = DateTime.Now;
            #endregion PreTransition_Procedure2Approve
        }

        protected void PostTransition_Procedure2Approve()
        {
            // From State : Procedure   To State : Approve
            #region PostTransition_Procedure2Approve
            if (TestDate == null)
                TestDate = Common.RecTime();
            if (ApprovedBy != null)
                ProcedureDoctor = ApprovedBy;
            #endregion PostTransition_Procedure2Approve
        }

        protected void PreTransition_Procedure2ResultEntry()
        {
            // From State : Procedure   To State : ResultEntry
            #region PreTransition_Procedure2ResultEntry
            if (OlapDate == null)
                OlapDate = DateTime.Now;
            if (ApprovedBy != null)
                ProcedureDoctor = ApprovedBy;
            #endregion PreTransition_Procedure2ResultEntry
        }

        protected void PostTransition_Procedure2ResultEntry()
        {
            // From State : Procedure   To State : ResultEntry
            #region PostTransition_Procedure2ResultEntry
            if (TestDate == null)
                TestDate = Common.RecTime();
            if (ApprovedBy != null)
                ProcedureDoctor = ApprovedBy;
            #endregion PostTransition_Procedure2ResultEntry
        }

        protected void PreTransition_Procedure2Completed()
        {
            // From State : Procedure   To State : Completed
            #region PreTransition_Procedure2Completed
            if (OlapDate == null)
                OlapDate = DateTime.Now;
            #endregion PreTransition_Procedure2Completed
        }

        protected void PostTransition_Procedure2Completed()
        {
            // From State : Procedure   To State : Completed
            #region PostTransition_Procedure2Completed
            if (TestDate == null)
                TestDate = Common.RecTime();

            PerformedDate = Common.RecTime();
            AutoCompleteParentObject(RadiologyTest.States.Completed, Radiology.States.Completed);

            //ENabız 108 paketi icin sendtoenabız tablosuna kayıt olusturuluyor. 
            if (IsOldAction != true && ((RadiologyTest)this).ExternalServiceRequests.Count <= 0)
            {
                new SendToENabiz(ObjectContext, SubEpisode, ObjectID, ObjectDef.Name, "102", Common.RecTime());

                //AccessionNo değeri olan testler için 108 paketi oluşturulacak sadece.  
                if (!string.IsNullOrEmpty(AccessionNo?.ToString()))
                    new SendToENabiz(ObjectContext, SubEpisode, ObjectID, ObjectDef.Name, "108", Common.RecTime());
            }

            #endregion PostTransition_Procedure2Completed
        }

        protected void PostTransition_Procedure2Reject()
        {
            // From State : Procedure   To State : Reject
            #region PostTransition_Procedure2Reject
            string sysparam = TTObjectClasses.SystemParameter.GetParameterValue("HL7ENGINEALIVE", null);
            if (sysparam == "TRUE")
            {
                List<Guid> appIDs = new List<Guid>();
                appIDs.Add(ObjectID);
                try
                {
                    //TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.MediumPriority, "InternalTCPClient", "HL7Remoting", "SendHospitalMessageToEngine", null, appIDs, "O01CA", "PACS");
                }
                catch
                {
                    IsMessageInPACS = false;
                    throw;
                }
            }

            CancelSMSForRadiologyTest();
            Cancel();
            #endregion PostTransition_Procedure2Reject
        }

        protected void PostTransition_Procedure2Cancelled()
        {
            // From State : Procedure   To State : Cancelled
            #region PostTransition_Procedure2Cancelled
            CancelSMSForRadiologyTest();
            if (CurrentStateDefID != RadiologyTest.States.Cancelled)
                Cancel();

            //Iptal edildiginde PACS a iptal mesaji gonderiliyor.
            string sysparam = TTObjectClasses.SystemParameter.GetParameterValue("HL7ENGINEALIVE", null);
            if (sysparam == "TRUE")
            {
                List<Guid> appIDs = new List<Guid>();
                appIDs.Add(ObjectID);
                try
                {
                    //TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.MediumPriority, "InternalTCPClient", "HL7Remoting", "SendHospitalMessageToEngine", null, appIDs, "O01CA", "PACS");
                }
                catch
                {
                    IsMessageInPACS = false;
                    throw;
                }
            }

            AutoCompleteParentObject(RadiologyTest.States.Cancelled, Radiology.States.Reject);
            #endregion PostTransition_Procedure2Cancelled
        }

        protected void PostTransition_Procedure2AdmissionAppointment()
        {
            // From State : Procedure   To State : AdmissionAppointment
            #region PostTransition_Procedure2AdmissionAppointment
            //this.CancelMyAccountTransactions();
            #endregion PostTransition_Procedure2AdmissionAppointment
        }

        protected void UndoTransition_Procedure2AdmissionAppointment(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Procedure   To State : AdmissionAppointment
            #region UndoTransition_Procedure2AdmissionAppointment
            throw new TTException(SystemMessage.GetMessage(935));
            #endregion UndoTransition_Procedure2AdmissionAppointment
        }

        protected void UndoTransition_RequestAcception2Appointment(TTObjectStateTransitionDef transitionDef)
        {
            // From State : RequestAcception   To State : Appointment
            #region UndoTransition_RequestAcception2Appointment
            CancelMyNewAppoinments();
            #endregion UndoTransition_RequestAcception2Appointment
        }

        protected void PostTransition_RequestAcception2Cancelled()
        {
            // From State : RequestAcception   To State : Cancelled
            #region PostTransition_RequestAcception2Cancelled
            if (CurrentStateDefID != RadiologyTest.States.Cancelled)
                Cancel();
            CancelSMSForRadiologyTest();
            bool hasUnCancelledTest = false;
            foreach (RadiologyTest test in Radiology.RadiologyTests)
            {
                if (test.CurrentStateDefID != RadiologyTest.States.Cancelled)
                {
                    hasUnCancelledTest = true;
                    break;
                }
            }

            if (!hasUnCancelledTest)
                Radiology.CurrentStateDefID = Radiology.States.Reject;
            #endregion PostTransition_RequestAcception2Cancelled
        }

        protected void PostTransition_RequestAcception2Reject()
        {
            // From State : RequestAcception   To State : Reject
            #region PostTransition_RequestAcception2Reject
            Cancel();
            CancelSMSForRadiologyTest();
            #endregion PostTransition_RequestAcception2Reject
        }

        protected void PostTransition_Completed2Reported()
        {
            // From State : Approve   To State : Completed
            #region PostTransition_Completed2Reported
            CompleteSMSForRadiologyTest();
            ReportDate = Common.RecTime();
            PerformedDate = ReportDate;
            AutoCompleteParentObject(RadiologyTest.States.Completed, Radiology.States.Completed);

            //ENabız 409 paketi icin sendtoenabız tablosuna kayıt olusturuluyor. 
            if (IsOldAction != true && ((RadiologyTest)this).ExternalServiceRequests.Count <= 0)
            {
                new SendToENabiz(ObjectContext, SubEpisode, ObjectID, ObjectDef.Name, "102", Common.RecTime());
                new SendToENabiz(ObjectContext, SubEpisode, ObjectID, ObjectDef.Name, "409", Common.RecTime());
            }
            SendSmsForRadiologyTestReported();
            #endregion PostTransition_Completed2Reported
        }
        protected void PostTransition_RequestAcception2Procedure()
        {

            if (IsOldAction != true)
            {
                SendMRBTSMS();
            }

        }

        protected void PreTransition_RequestAcception2Procedure()
        {
            CheckInvoice();
        }
        protected void PreTransition_RequestAcception2ResultEntry()
        {
            CheckInvoice();
        }
        protected void CheckInvoice()
        {
            if (this.SubEpisode.IsInvoicedCompletely)
                throw new TTException("Hastanın faturası kesilmiştir. İşleme devam edemezsiniz.");
        }


        protected void PostTransition_Appointment2Procedure()
        {


            if (IsOldAction != true)
            {

                SendMRBTSMS();



            }

        }

        protected void PostTransition_Completed2Cancelled()
        {
            if (CurrentStateDefID != RadiologyTest.States.Cancelled)
                Cancel();
            CancelSMSForRadiologyTest();
            bool hasUnCancelledTest = false;
            foreach (RadiologyTest test in Radiology.RadiologyTests)
            {
                if (test.CurrentStateDefID != RadiologyTest.States.Cancelled)
                {
                    hasUnCancelledTest = true;
                    break;
                }
            }

            if (!hasUnCancelledTest)
                Radiology.CurrentStateDefID = Radiology.States.Reject;
            //Iptal edildiginde PACS a iptal mesaji gonderiliyor.
            string sysparam = TTObjectClasses.SystemParameter.GetParameterValue("HL7ENGINEALIVE", null);
            if (sysparam == "TRUE")
            {
                List<Guid> appIDs = new List<Guid>();
                appIDs.Add(ObjectID);
                try
                {
                    //TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.MediumPriority, "InternalTCPClient", "HL7Remoting", "SendHospitalMessageToEngine", null, appIDs, "O01CA", "PACS");
                }
                catch
                {
                    IsMessageInPACS = false;
                    throw;
                }
            }
        }

        protected void PostTransition_RequestAcception2Appointment()
        {
            SendSmsForRadiologyAppointment();
        }
        //protected void PostTransition_Procedure2RequestAcception()
        //{
        //    #region PostTransition_Procedure2RequestAcception
        //    //Ücretli hasta ise acctrx i iptal edilmeyecekç Cunku bu grubun acctrx ı Istem yapildigi anda charge oluyor ve odemesini yaptiktan sonra Islemde asamasina aliniyor.
        //    //Ucretli hasta grubu disindakiler icin acctrx iptal edilecek.

        //    SubEpisodeProtocol subEpisodeProtocol = this.SubEpisode.OpenSubEpisodeProtocol;
        //    if (subEpisodeProtocol == null)
        //        throw new TTException(SystemMessage.GetMessage(663));
        //    if (subEpisodeProtocol.Protocol != null && subEpisodeProtocol.Protocol.Type != ProtocolTypeEnum.Paid)
        //        this.CancelMyAccountTransactions();

        //    #endregion PostTransition_Procedure2RequestAcception
        //}

        #region Methods
        #region ITreatmentMaterialCollection Members
        public BaseTreatmentMaterial.ChildBaseTreatmentMaterialCollection GetTreatmentMaterials()
        {
            return TreatmentMaterials;
        }
        #endregion
        public List<AppointmentCarrier> AppointmentCarrierList
        {
            get
            {
                List<AppointmentCarrier> _appointmentList = new List<AppointmentCarrier>();
                TTObjectContext context = new TTObjectContext(false);
                AppointmentDefinition appDef = null;
                IList appDefList = AppointmentDefinition.GetAppointmentDefinitionByName(context, AppointmentDefinitionEnum.RadiologyTest);
                if (appDefList.Count > 0)
                {
                    appDef = (AppointmentDefinition)appDefList[0];
                    foreach (AppointmentCarrier appCarrier in appDef.AppointmentCarriers)
                    {
                        _appointmentList.Add(appCarrier);
                    }
                }

                if (_appointmentList.Count == 0)
                {
                    AppointmentCarrier carrier = new AppointmentCarrier(context);
                    carrier.MasterResource = "ResClinic";
                    carrier.SubResource = "ResEquipment";
                    carrier.RelationParentName = "Clinic";
                    carrier.AppointmentDefinition = appDef;
                    _appointmentList.Add(carrier);
                }

                ClearAppointmentCarrierDynamicFields(_appointmentList);
                return _appointmentList;
            }
        }

        #region IAppointmentDef Members
        public List<AppointmentCarrier> GetAppointmentCarrierList()
        {
            return AppointmentCarrierList;
        }
        #endregion

        public void SetNecessaryProperties()
        {
            //     ActionDate = Common.RecTime();
            //     Cancelled = false;
            //     Active = true;
            //   ID = 123;
        }

        public AppointmentTypeEnum NumaratorAppointmentType
        {
            get
            {
                return AppointmentTypeEnum.Examination;
            }
        }

        public Resource NumaratorAppointmentMasterResource
        {
            get
            {
                return MasterResource;
            } // İşlemin yapıuldığı Poliklinik aynı zamanada randevu verilecek üst kaynakdır
        }

        public Resource NumaratorAppointmentResource
        {
            get
            {
                if (ProcedureDoctor == null)
                {
                    TTObjectContext roContext = new TTObjectContext(true);
                    BindingList<TTObjectClasses.Appointment.GetMinNumaratorAppointmentResource_Class> minAppResource = Appointment.GetMinNumaratorAppointmentResource(roContext, MasterResource.ObjectID, Common.RecTime().Date, Common.RecTime().Date.AddDays(1));
                    if (minAppResource.Count > 0)
                    {
                        foreach (TTObjectClasses.Appointment.GetMinNumaratorAppointmentResource_Class minNumApp in minAppResource)
                        {
                            Resource resource = (Resource)roContext.GetObject(minNumApp.Resource.Value, typeof(Resource));
                            if (resource is ResUser)
                            {
                                ProcedureDoctor = (ResUser)resource;
                                break;
                            }
                        }
                    }

                    if (ProcedureDoctor == null)
                    {
                        IList<ResUser> userList = (IList<ResUser>)ResUser.GetByUserResourceAndUserType(roContext, UserTypeEnum.Doctor, MasterResource.ObjectID.ToString());
                        foreach (ResUser resUser in userList)
                        {
                            ProcedureDoctor = (ResUser)resUser;
                            break;
                        }
                    }
                }

                return ProcedureDoctor;
            }
            // işlemi yapan doktor aynı zamanda randevu verilecek kişidir
        }

        public void CallOnConstruct()
        {
            OnConstruct();
        }

        ///Request Accepetion ----------> Procedure
        public void ToProcedure(RadiologyTest Rad)
        {
            Department = Rad.Department;
            Equipment = Rad.Equipment;
            Description = Rad.Description;
            CurrentStateDefID = RadiologyTest.States.Procedure;
            TestDate = Common.RecTime();
            ObjectContext.Save();
        }

        /// Procedure -----------> ResultEntry
        public void ToResultEntry(RadiologyTest Rad)
        {
            Description = Rad.Description;
            TechnicianNote = Rad.TechnicianNote;
            Report = Rad.Report;
            CurrentStateDefID = RadiologyTest.States.ResultEntry;
            TestDate = Common.RecTime();
            ObjectContext.Save();
        }

        /// ResultEntry ------------> Approve
        public void ToApprove(RadiologyTest Rad)
        {
            Report = Rad.Report;
            Description = Rad.Description;
            CurrentStateDefID = RadiologyTest.States.Approve;
            TestDate = Common.RecTime();
            ObjectContext.Save();
        }

        /// <summary>
        /// ResultEntry ------------> Completed
        /// </summary>
        /// <param name = "Descriptionx"></param>
        /// <param name = "Reportx"></param>
        public void ToCompleted(string Descriptionx, string Reportx)
        {
            Report = Reportx;
            Description = Descriptionx;
            CurrentStateDefID = RadiologyTest.States.Completed;
            TestDate = Common.RecTime();
            ObjectContext.Save();
        }

        public void AutoUndoParentObjectLastTranstion()
        {
            if (Radiology.CurrentStateDefID != Radiology.States.Completed)
                return;
            ((ITTObject)Radiology).UndoLastTransition();
        }

        public void AutoCompleteParentObject(Guid childObjectStateDefID, Guid parentObjectStateDefID)
        {
            bool hasTestInPrevState = false;
            foreach (RadiologyTest tetkik in Radiology.RadiologyTests)
            {
                if (this != tetkik && tetkik.CurrentStateDefID != childObjectStateDefID)
                {
                    hasTestInPrevState = true;
                }
            }

            if (!hasTestInPrevState)
                Radiology.CurrentStateDefID = parentObjectStateDefID;
        }

        public override SubActionProcedure PrepareSubActionProcedureForRemoteMethod(bool withNewObjectID)
        {
            RadiologyTest radiologyTest = (RadiologyTest)base.PrepareSubActionProcedureForRemoteMethod(withNewObjectID);
            if (withNewObjectID)
            {
                TTSequence.allowSetSequenceValue = true;
                //TODO:  Remotecall için AccessionNo ne olmalı düşünülmeli
                //radiologyTest.AccessionNo.SetSequenceValue(0);
                radiologyTest.Equipment = null;
                radiologyTest.FromResource = null;
                radiologyTest.MasterResource = null;
                TTSequence.allowSetSequenceValue = true;
                radiologyTest.ID.SetSequenceValue(0);
            }

            return radiologyTest;
        }

        public string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes = System.Text.Encoding.GetEncoding("iso-8859-9").GetBytes(toEncode);
            string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }


        [TTStorageManager.Attributes.TTRequiredRoles(TTRoleNames.Radyoloji_Test_Islemde, TTRoleNames.Radyoloji_Test_R)]
        public static void SendRadiologyTestToPACS(RadiologyTest radiologyTest)
        {
            //TODO: PACS a tekrar gonderılecek
            TTObjectContext objectContext = new TTObjectContext(false);
            RadiologyTest radTest = (RadiologyTest)objectContext.GetObject(radiologyTest.ObjectID, "RADIOLOGYTEST");


            Guid siteIDGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
            string sysparam = TTObjectClasses.SystemParameter.GetParameterValue("HL7ENGINEALIVE", null);
            if (sysparam == "TRUE")
            {
                try
                {
                    Patient.SendPatientToPACS(radTest.EpisodeAction.Episode.Patient);
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M25378", "Çekim yapılacak hasta bilgisi PACS'a gönderilemedi!"), ex);
                }

                List<Guid> appIDs = new List<Guid>();
                appIDs.Add(radTest.ObjectID);
                if (radTest.IsMessageInPACS == true)
                {
                    try
                    {
                        //TTMessage message = TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.HighPriority, "InternalTCPClient", "HL7Remoting", "SendHospitalMessageToEngine", null, appIDs, "O01XO", "PACS");
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
                        //TTMessage message = TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.HighPriority, "InternalTCPClient", "HL7Remoting", "SendHospitalMessageToEngine", null, appIDs, "O01", "PACS");
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
            //}
        }

        public override string GetDVODrTescilNo(string branchCode)
        {
            if (!string.IsNullOrWhiteSpace(ApprovedBy?.DiplomaRegisterNo))
                return ApprovedBy.DiplomaRegisterNo;

            if (!string.IsNullOrWhiteSpace(ProcedureDoctor?.DiplomaRegisterNo))
                return ProcedureDoctor.DiplomaRegisterNo;

            if (!string.IsNullOrWhiteSpace(ReportedBy?.DiplomaRegisterNo))
                return ReportedBy.DiplomaRegisterNo;

            return Common.GetDoctorRegisterNoByBranchCode(branchCode);
        }

        public override ResUser GetDVOIstemYapanDr()
        {
            if (Radiology != null && Radiology.RequestDoctor != null)
                return Radiology.RequestDoctor;

            return base.GetDVOIstemYapanDr();
        }

        public override string GetDVOBirim()
        {
            return birim;
        }

        //public override string GetDVOAyniFarkliKesi()
        //{
        //    return AyniFarkliKesi?.ayniFarkliKesiKodu;
        //}

        public override string GetDVOEuroscore()
        {
            return ((int)MedulaEuroScoreEnum.Empty).ToString();
        }

        //public override string GetDVOSagSol()
        //{
        //    if (ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.ameliyatveGirisimBilgileri)
        //        return SagSol?.sagSolKodu;

        //    return SagSol?.getSagSol_LR();
        //}

        public override string GetDVOAccession()
        {
            if (ProcedureObject is RadiologyTestDefinition)
            {
                //if (((RadiologyTestDefinition)ProcedureObject).AccessionModalityRequires == true)
                //{
                if (!String.IsNullOrEmpty(AccessionNo))
                {
                    string accessionNo = AccessionNo.ToString();
                    //TODO: AccessionNo sequence min 6 digit olarak başlatılacak. başına 0 ekleme olayı kaldırıldı.
                    //AddZerosForAccessionNo(ref accessionNo);
                    return accessionNo;
                }
                else
                    return "9998"; // accesion number üretemeyen görüntüler için 9998 veya 9999 gönderin yazıyor kılavuzda
                //}
            }

            return null;
        }

        public override string GetDVOModality()
        {
            if (ProcedureObject is RadiologyTestDefinition)
            {
                RadiologyTestDefinition radiologyTestDefinition = ProcedureObject as RadiologyTestDefinition;
                //if (radiologyTestDefinition.AccessionModalityRequires == true)
                //{
                if (radiologyTestDefinition.IsMR)
                    return "M";

                if (radiologyTestDefinition.IsBT)
                    return "B";
                //}
            }

            return null;
        }

        public override string GetDVOAciklama(AccountTransaction accTrx)
        {
            if (ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.tetkikveRadyolojiBilgileri)
            {
                Guid btProcedure = new Guid("100b4e9a-2089-4d69-a88b-370306c42d43"); // BT
                Guid mrProcedure = new Guid("6edf2225-4b77-47a2-9686-61f8c441084e"); // MR

                if (Report != null) // Rapor varsa 'Açıklama' olarak gönderilecek
                {
                    string reportText = Report.ToString();
                    try { reportText = Common.HTMLToText(reportText); } catch { }

                    int aciklamaLimit = 199; // MR ve BT dışındakiler için açıklama alanının limiti 199

                    if (ProcedureObject.ProcedureTree != null && (ProcedureObject.ProcedureTree.ObjectID == mrProcedure || ProcedureObject.ProcedureTree.ObjectID == btProcedure))
                        aciklamaLimit = 2999; // MR ve BT için açıklama alanının limiti 2999

                    if (reportText.Length > aciklamaLimit)
                        return reportText.Substring(0, aciklamaLimit);
                    else
                        return reportText;
                }
                else if (IsExternal())
                    return "D.SEVK:" + ProcedureObject.Code;

                if (Episode.PatientStatus != PatientStatusEnum.Outpatient)
                    return TTUtils.CultureService.GetText("M26744", "Rapor bilgisi sisteme kaydedilmiştir.");

            }
            else if (ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.ameliyatveGirisimBilgileri)
            {
                if (Report != null) // Rapor varsa 'Açıklama' olarak gönderilecek
                {
                    string reportText = Common.GetTextOfRTFString(Report.ToString());
                    if (!string.IsNullOrEmpty(reportText))
                    {
                        if (reportText.Length > 254) // Açıklama max 254 karakter olabilir
                            return reportText.Substring(0, 254);

                        return reportText;
                    }
                }
            }
            else if (Report != null)
                return Common.GetTextOfRTFString(Report.ToString());

            return null;
        }

        public override string GetDVOAnomali()
        {
            if (Anomali.HasValue)
                return Anomali.Value.Equals(true) ? "E" : "H";

            if (Radiology.Anomali.HasValue)
                return Radiology.Anomali.Value.Equals(true) ? "E" : "H";

            return "H";
        }

        public override int? GetDVODisTaahhutNo()
        {
            if (DisTaahhutNo.HasValue)
                return DisTaahhutNo.Value;

            if (Radiology.DisTaahhutNo.HasValue)
                return Radiology.DisTaahhutNo.Value;

            return null;
        }

        public override void GetDVOSetCeneBilgisi(HizmetKayitIslemleri.disBilgisiDVO disBilgisiDVO)
        {
            List<int> listEriskin = new List<int>();
            List<int> listSut = new List<int>();
            List<int> listAnomali = new List<int>();
            List<int> listCene = new List<int>();

            if (TestToothNumber != null)
            {
                if (Convert.ToInt32(TestToothNumber) >= 11 && Convert.ToInt32(TestToothNumber) <= 48)
                    listEriskin.Add(Convert.ToInt32(TestToothNumber));
                else if (Convert.ToInt32(TestToothNumber) >= 51 && Convert.ToInt32(TestToothNumber) <= 85)
                    listSut.Add(Convert.ToInt32(TestToothNumber));
                else if (Convert.ToInt32(TestToothNumber) >= 91 && Convert.ToInt32(TestToothNumber) <= 94)
                    listAnomali.Add(Convert.ToInt32(TestToothNumber));
                else if (Convert.ToInt32(TestToothNumber) >= 1 && Convert.ToInt32(TestToothNumber) <= 7)
                    listCene.Add(Convert.ToInt32(TestToothNumber));
            }
            else if (Radiology.ToothNumber != null)
            {
                if (Convert.ToInt32(Radiology.ToothNumber) >= 11 && Convert.ToInt32(Radiology.ToothNumber) <= 48)
                    listEriskin.Add(Convert.ToInt32(Radiology.ToothNumber));
                else if (Convert.ToInt32(Radiology.ToothNumber) >= 51 && Convert.ToInt32(Radiology.ToothNumber) <= 85)
                    listSut.Add(Convert.ToInt32(Radiology.ToothNumber));
                else if (Convert.ToInt32(Radiology.ToothNumber) >= 91 && Convert.ToInt32(Radiology.ToothNumber) <= 94)
                    listAnomali.Add(Convert.ToInt32(Radiology.ToothNumber));
                else if (Convert.ToInt32(Radiology.ToothNumber) >= 1 && Convert.ToInt32(Radiology.ToothNumber) <= 7)
                    listCene.Add(Convert.ToInt32(Radiology.ToothNumber));
            }

            setEriskinDisler(listEriskin.ToArray(), disBilgisiDVO);
            setSutDisler(listSut.ToArray(), disBilgisiDVO);
            setAnomaliDisler(listAnomali.ToArray(), disBilgisiDVO);
            setCeneDisler(listCene.ToArray(), disBilgisiDVO);
        }

        public void setEriskinDisler(int[] str, HizmetKayitIslemleri.disBilgisiDVO disBilgisiDVO)
        {
            String[] eDis = new String[32];
            disBilgisiDVO.sagUstCene = "";
            disBilgisiDVO.solUstCene = "";
            disBilgisiDVO.solAltCene = "";
            disBilgisiDVO.sagAltCene = "";
            for (int i = 0; i < eDis.Length; i++)
                eDis[i] = "_";
            for (int j = 0; j < str.Length; j++)
            {
                for (int k = 11, l = 0; k <= eDis.Length + 16 && l < eDis.Length; k++, l++)
                {
                    if (k == 18 || k == 28 || k == 38 || k == 48)
                    {
                        if (str[j] == k)
                        {
                            eDis[l] = "E";
                            break;
                        }

                        k = k + 2;
                    }
                    else
                    {
                        if (str[j] == k)
                        {
                            eDis[l] = "E";
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < eDis.Length; i++)
            {
                if (i >= 0 && i < 8)
                    disBilgisiDVO.sagUstCene = disBilgisiDVO.sagUstCene + eDis[i];
                if (i >= 8 && i < 16)
                    disBilgisiDVO.solUstCene = disBilgisiDVO.solUstCene + eDis[i];
                if (i >= 16 && i < 24)
                    disBilgisiDVO.solAltCene = disBilgisiDVO.solAltCene + eDis[i];
                if (i >= 24 && i < 32)
                    disBilgisiDVO.sagAltCene = disBilgisiDVO.sagAltCene + eDis[i];
            }
        }

        public void setSutDisler(int[] str, HizmetKayitIslemleri.disBilgisiDVO disBilgisiDVO)
        {
            String[] sDis = new String[20];
            disBilgisiDVO.sagSutUstCene = "";
            disBilgisiDVO.solSutUstCene = "";
            disBilgisiDVO.solSutAltCene = "";
            disBilgisiDVO.sagSutAltCene = "";
            for (int i = 0; i < sDis.Length; i++)
                sDis[i] = "_";
            for (int j = 0; j < str.Length; j++)
            {
                for (int k = 51, l = 0; k <= sDis.Length + 65 && l < sDis.Length; k++, l++)
                {
                    if (k == 55 || k == 65 || k == 75 || k == 85)
                    {
                        if (str[j] == k)
                        {
                            sDis[l] = "E";
                            break;
                        }

                        k = k + 5;
                    }
                    else
                    {
                        if (str[j] == k)
                        {
                            sDis[l] = "E";
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < sDis.Length; i++)
            {
                if (i >= 0 && i < 5)
                    disBilgisiDVO.sagSutUstCene = disBilgisiDVO.sagSutUstCene + sDis[i];
                if (i >= 5 && i < 10)
                    disBilgisiDVO.solSutUstCene = disBilgisiDVO.solSutUstCene + sDis[i];
                if (i >= 10 && i < 15)
                    disBilgisiDVO.solSutAltCene = disBilgisiDVO.solSutAltCene + sDis[i];
                if (i >= 15 && i < 20)
                    disBilgisiDVO.sagSutAltCene = disBilgisiDVO.sagSutAltCene + sDis[i];
            }
        }

        public void setAnomaliDisler(int[] str, HizmetKayitIslemleri.disBilgisiDVO disBilgisiDVO)
        {
            String[] aDis = new String[4];
            disBilgisiDVO.sagUstCeneAnomaliDis = ""; //91
            disBilgisiDVO.solUstCeneAnomaliDis = ""; //92
            disBilgisiDVO.sagAltCeneAnomaliDis = ""; //93
            disBilgisiDVO.solAltCeneAnomaliDis = ""; //94
            for (int i = 0; i < aDis.Length; i++)
                aDis[i] = "_";
            for (int j = 0; j < str.Length; j++)
                for (int k = 91, l = 0; k <= aDis.Length + 90 && l < aDis.Length; k++, l++)
                {
                    if (str[j] == k)
                    {
                        aDis[l] = "E";
                        break;
                    }
                }

            disBilgisiDVO.sagUstCeneAnomaliDis = aDis[0];
            disBilgisiDVO.solUstCeneAnomaliDis = aDis[1];
            disBilgisiDVO.sagAltCeneAnomaliDis = aDis[2];
            disBilgisiDVO.solAltCeneAnomaliDis = aDis[3];
        }

        public void setCeneDisler(int[] str, HizmetKayitIslemleri.disBilgisiDVO disBilgisiDVO)
        {
            for (int j = 0; j < str.Length; j++)
            {
                if (str[j] == 1)
                { //Tüm Çene
                    disBilgisiDVO.sagUstCeneAnomaliDis = "E";
                    disBilgisiDVO.solUstCeneAnomaliDis = "E";
                    disBilgisiDVO.sagAltCeneAnomaliDis = "E";
                    disBilgisiDVO.solAltCeneAnomaliDis = "E";
                    disBilgisiDVO.sagSutUstCene = "EEEEE";
                    disBilgisiDVO.solSutUstCene = "EEEEE";
                    disBilgisiDVO.solSutAltCene = "EEEEE";
                    disBilgisiDVO.sagSutAltCene = "EEEEE";
                    disBilgisiDVO.sagUstCene = "EEEEEEEE";
                    disBilgisiDVO.solUstCene = "EEEEEEEE";
                    disBilgisiDVO.solAltCene = "EEEEEEEE";
                    disBilgisiDVO.sagAltCene = "EEEEEEEE";
                }

                if (str[j] == 2)
                { //Üst Çene
                    disBilgisiDVO.sagUstCeneAnomaliDis = "E";
                    disBilgisiDVO.solUstCeneAnomaliDis = "E";
                    disBilgisiDVO.sagAltCeneAnomaliDis = "_";
                    disBilgisiDVO.solAltCeneAnomaliDis = "_";
                    disBilgisiDVO.sagSutUstCene = "EEEEE";
                    disBilgisiDVO.solSutUstCene = "EEEEE";
                    disBilgisiDVO.solSutAltCene = "_____";
                    disBilgisiDVO.sagSutAltCene = "_____";
                    disBilgisiDVO.sagUstCene = "EEEEEEEE";
                    disBilgisiDVO.solUstCene = "EEEEEEEE";
                    disBilgisiDVO.solAltCene = "________";
                    disBilgisiDVO.sagAltCene = "________";
                }

                if (str[j] == 3)
                { //Alt Çene
                    disBilgisiDVO.sagUstCeneAnomaliDis = "_";
                    disBilgisiDVO.solUstCeneAnomaliDis = "_";
                    disBilgisiDVO.sagAltCeneAnomaliDis = "E";
                    disBilgisiDVO.solAltCeneAnomaliDis = "E";
                    disBilgisiDVO.sagSutUstCene = "_____";
                    disBilgisiDVO.solSutUstCene = "_____";
                    disBilgisiDVO.solSutAltCene = "EEEEE";
                    disBilgisiDVO.sagSutAltCene = "EEEEE";
                    disBilgisiDVO.sagUstCene = "________";
                    disBilgisiDVO.solUstCene = "________";
                    disBilgisiDVO.solAltCene = "EEEEEEEE";
                    disBilgisiDVO.sagAltCene = "EEEEEEEE";
                }

                if (str[j] == 4)
                { //Sağ Üst Çene
                    disBilgisiDVO.sagUstCeneAnomaliDis = "E";
                    disBilgisiDVO.solUstCeneAnomaliDis = "_";
                    disBilgisiDVO.sagAltCeneAnomaliDis = "_";
                    disBilgisiDVO.solAltCeneAnomaliDis = "_";
                    disBilgisiDVO.sagSutUstCene = "EEEEE";
                    disBilgisiDVO.solSutUstCene = "_____";
                    disBilgisiDVO.solSutAltCene = "_____";
                    disBilgisiDVO.sagSutAltCene = "_____";
                    disBilgisiDVO.sagUstCene = "EEEEEEEE";
                    disBilgisiDVO.solUstCene = "________";
                    disBilgisiDVO.solAltCene = "________";
                    disBilgisiDVO.sagAltCene = "________";
                }

                if (str[j] == 5)
                { //Sol Üst Çene
                    disBilgisiDVO.sagUstCeneAnomaliDis = "_";
                    disBilgisiDVO.solUstCeneAnomaliDis = "E";
                    disBilgisiDVO.sagAltCeneAnomaliDis = "_";
                    disBilgisiDVO.solAltCeneAnomaliDis = "_";
                    disBilgisiDVO.sagSutUstCene = "_____";
                    disBilgisiDVO.solSutUstCene = "EEEEE";
                    disBilgisiDVO.solSutAltCene = "_____";
                    disBilgisiDVO.sagSutAltCene = "_____";
                    disBilgisiDVO.sagUstCene = "________";
                    disBilgisiDVO.solUstCene = "EEEEEEEE";
                    disBilgisiDVO.solAltCene = "________";
                    disBilgisiDVO.sagAltCene = "________";
                }

                if (str[j] == 6)
                { //Sağ Alt Çene
                    disBilgisiDVO.sagUstCeneAnomaliDis = "_";
                    disBilgisiDVO.solUstCeneAnomaliDis = "_";
                    disBilgisiDVO.sagAltCeneAnomaliDis = "E";
                    disBilgisiDVO.solAltCeneAnomaliDis = "_";
                    disBilgisiDVO.sagSutUstCene = "_____";
                    disBilgisiDVO.solSutUstCene = "_____";
                    disBilgisiDVO.solSutAltCene = "_____";
                    disBilgisiDVO.sagSutAltCene = "EEEEE";
                    disBilgisiDVO.sagUstCene = "________";
                    disBilgisiDVO.solUstCene = "________";
                    disBilgisiDVO.solAltCene = "________";
                    disBilgisiDVO.sagAltCene = "EEEEEEEE";
                }

                if (str[j] == 7)
                { //Sol Alt Çene
                    disBilgisiDVO.sagUstCeneAnomaliDis = "_";
                    disBilgisiDVO.solUstCeneAnomaliDis = "_";
                    disBilgisiDVO.sagAltCeneAnomaliDis = "_";
                    disBilgisiDVO.solAltCeneAnomaliDis = "E";
                    disBilgisiDVO.sagSutUstCene = "_____";
                    disBilgisiDVO.solSutUstCene = "_____";
                    disBilgisiDVO.solSutAltCene = "EEEEE";
                    disBilgisiDVO.sagSutAltCene = "_____";
                    disBilgisiDVO.sagUstCene = "________";
                    disBilgisiDVO.solUstCene = "________";
                    disBilgisiDVO.solAltCene = "EEEEEEEE";
                    disBilgisiDVO.sagAltCene = "________";
                }
            }
        }

        public override SubEpisodeStatusEnum GetSubEpisodePatientStatus()
        {
            return SubEpisodeStatusEnum.Daily;
        }
        // ICreateSubEpisode Methodları
        // Yeni SubEpisode oluşturulmasına karar veren metod
        public override bool IsNewSubEpisodeNeeded()
        {
            if (base.IsNewSubEpisodeNeeded() == false)
                return false;
            // TODO: IsGunubirlikTakip property si kullanılacak mı ? Kullanılacaksa buraya da eklenmeli. (MDZ)
            if (Episode.PatientStatus == PatientStatusEnum.Outpatient && SubEpisode.IsSGK == true && ProcedureObject.DailyMedulaProvisionNecessity == true)
                return Episode.Patient.SuitableToCreateNewDailySubEpisode(GetSubEpisodeSpeciality());
            return false;
        }

        public virtual bool Sent101Package()
        {
            return false;
        }

        // SEP in değiştirilmesi gereken propertyleri varsa bu metodda set edilmeli
        public override void FillLocalSEPProperties(ref SubEpisodeProtocol sep)
        {
            // Aşağıdaki 2 alan formda kalacak mı ? Bilinmediği için kapatıldı şimdilik (MDZ)
            //Tedavi Tipi (Zorunlu)
            //if (this.MedulaProvision != null && this.MedulaProvision.TedaviTipi != null && this.MedulaProvision.TedaviTipi.tedaviTipiKodu != null)
            //    provizyonGirisDVO.tedaviTipi = this.MedulaProvision.TedaviTipi.tedaviTipiKodu;
            //Takip Tipi (Zorunlu)
            //if (this.MedulaProvision != null && this.MedulaProvision.TakipTipi != null && this.MedulaProvision.TakipTipi.takipTipiKodu != null)
            //    provizyonGirisDVO.takipTipi = this.MedulaProvision.TakipTipi.takipTipiKodu;
            //SubEpisodeProtocol parentSEP = this.Episode.GetFirstSEP();
            //if (parentSEP != null)
            //    subEpisodeProtocol.ParentSEP = parentSEP;
            if (IsGunubirlikTakip == true) // Bu kontrol önceden de olduğu için kaldırılmadı, gereksiz ise kaldırılacak (MDZ)
            {
                if (sep.ParentSEP != null && sep.ParentSEP.MedulaProvizyonTarihi.Value.DayOfYear < Common.RecTime().DayOfYear)
                    sep.ParentSEP = null;
            }
        }

        public DiagnosisCopyEnum GetDiagnosisCopyEnum()
        {
            return DiagnosisCopyEnum.CopyFromLastSubEpisode;
        }

        public void CheckIfReportIsRequiredForMedulaInpatient()
        {
            if (SubEpisode.IsSGK && Episode.PatientStatus != PatientStatusEnum.Outpatient && IsOldAction != true)
            {
                if (Report == null || string.IsNullOrEmpty(Common.GetTextOfRTFString(Report.ToString()).Trim()))
                {
                    throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26875", "SGK'lı yatan hastalarda rapor yazılması zorunludur!"));
                }
            }
        }

        protected override List<EpisodeAction.OldActionPropertyObject> OldActionPropertyList()
        {
            List<EpisodeAction.OldActionPropertyObject> propertyList = base.OldActionPropertyList();
            if (propertyList == null)
                propertyList = new List<EpisodeAction.OldActionPropertyObject>();
            if (Report != null)
            {
                bool found = false;
                foreach (EpisodeAction.OldActionPropertyObject po in propertyList)
                {
                    if (po.PropertyCaption == TTUtils.CultureService.GetText("M26741", "Rapor"))
                    {
                        found = true;
                        po.PropertyValue = Common.ReturnObjectAsString(Report);
                        break;
                    }
                }

                if (!found)
                    propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M26741", "Rapor"), Common.ReturnObjectAsString(Report)));
            }

            return propertyList;
        }

        public override void Cancel()
        {
            base.Cancel();
            MakingDirectPurchaseMaterialsUnUsed();
        }

        public void MakingDirectPurchaseMaterialsUnUsed()
        {
            foreach (SurgeryDirectPurchaseGrid sdg in RadiologyTest_SurgeryDirectPurchaseGrids)
            {
                if (sdg.DPADetailFirmPriceOffer != null && sdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail != null)
                    sdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.HasUsed = false;
            }
        }

        //Çekim yapıldığı tarih cihazdan farklı gelebildiği için PerformedDate i set etme kodu kapatıldı.
        //RadiologyTest objesi Completed (Çekim Yapıldı) ya da Reported (Raporlandı) aşamalarına geçtiği zaman PerformedDate değeri set ediliyor.
        /* public override void SetPerformedDate() // İşlemin onaylandığı tarih set edecek şekilde override edilmeli
         {
             if (this.ReportDate != null)
                 this.PerformedDate = this.ReportDate;
             else if (this.TestDate != null)
                 this.PerformedDate = this.TestDate;
         }
         */

        #endregion Methods
        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(RadiologyTest).Name)
                return;
            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
            if (fromState == RadiologyTest.States.Approve && toState == RadiologyTest.States.Reported)
                PreTransition_Approve2Reported();
            else if (fromState == RadiologyTest.States.ResultEntry && toState == RadiologyTest.States.Reported)
                PreTransition_ResultEntry2Reported();
            else if (fromState == RadiologyTest.States.Procedure && toState == RadiologyTest.States.Approve)
                PreTransition_Procedure2Approve();
            else if (fromState == RadiologyTest.States.Procedure && toState == RadiologyTest.States.ResultEntry)
                PreTransition_Procedure2ResultEntry();
            else if (fromState == RadiologyTest.States.Procedure && toState == RadiologyTest.States.Completed)
                PreTransition_Procedure2Completed();
            else if (fromState == RadiologyTest.States.RequestAcception && toState == RadiologyTest.States.Procedure)
                PreTransition_RequestAcception2Procedure();
            else if (fromState == RadiologyTest.States.RequestAcception && toState == RadiologyTest.States.ResultEntry)
                PreTransition_RequestAcception2ResultEntry();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(RadiologyTest).Name)
                return;
            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
            if (fromState == RadiologyTest.States.Approve && toState == RadiologyTest.States.ResultEntry)
                PostTransition_Approve2ResultEntry();
            else if (fromState == RadiologyTest.States.Approve && toState == RadiologyTest.States.Reported)
                PostTransition_Approve2Reported();
            else if (fromState == RadiologyTest.States.Approve && toState == RadiologyTest.States.Procedure)
                PostTransition_Approve2Procedure();
            else if (fromState == RadiologyTest.States.Appointment && toState == RadiologyTest.States.AdmissionAppointment)
                PostTransition_Appointment2AdmissionAppointment();
            else if (fromState == RadiologyTest.States.ResultEntry && toState == RadiologyTest.States.Reported)
                PostTransition_ResultEntry2Reported();
            else if (fromState == RadiologyTest.States.Procedure && toState == RadiologyTest.States.Approve)
                PostTransition_Procedure2Approve();
            else if (fromState == RadiologyTest.States.Procedure && toState == RadiologyTest.States.ResultEntry)
                PostTransition_Procedure2ResultEntry();
            else if (fromState == RadiologyTest.States.Procedure && toState == RadiologyTest.States.Completed)
                PostTransition_Procedure2Completed();
            else if (fromState == RadiologyTest.States.Procedure && toState == RadiologyTest.States.Reject)
                PostTransition_Procedure2Reject();
            else if (fromState == RadiologyTest.States.Procedure && toState == RadiologyTest.States.Cancelled)
                PostTransition_Procedure2Cancelled();
            else if (fromState == RadiologyTest.States.Procedure && toState == RadiologyTest.States.AdmissionAppointment)
                PostTransition_Procedure2AdmissionAppointment();
            else if (fromState == RadiologyTest.States.RequestAcception && toState == RadiologyTest.States.Cancelled)
                PostTransition_RequestAcception2Cancelled();
            else if (fromState == RadiologyTest.States.RequestAcception && toState == RadiologyTest.States.Reject)
                PostTransition_RequestAcception2Reject();
            else if (fromState == RadiologyTest.States.Completed && toState == RadiologyTest.States.Cancelled)
                PostTransition_Completed2Cancelled();
            else if (fromState == RadiologyTest.States.Completed && toState == RadiologyTest.States.Reported)
                PostTransition_Completed2Reported();
            else if (fromState == RadiologyTest.States.RequestAcception && toState == RadiologyTest.States.Appointment)
                PostTransition_RequestAcception2Appointment();
            else if (fromState == RadiologyTest.States.Appointment && toState == RadiologyTest.States.Procedure)
                PostTransition_Appointment2Procedure();
            else if (fromState == RadiologyTest.States.RequestAcception && toState == RadiologyTest.States.Procedure)
                PostTransition_RequestAcception2Procedure();



            //if (toState == States.Completed || toState == States.Reported)
            //{
            //    this.SetPerformedDate();
            //    this.SendToENabizForSubactionProcedure(true);
            //}
            //if (toState == States.Procedure)
            //    this.SubEpisode.ArrangeMeOrCreateNewSubEpisode(this, false); // SubEpisode ve SubEpisodeProtocol oluşturup meduladan takip alan metod
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(RadiologyTest).Name)
                return;
            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
            if (fromState == RadiologyTest.States.Approve && toState == RadiologyTest.States.Reported)
                UndoTransition_Approve2Reported(transDef);
            else if (fromState == RadiologyTest.States.Appointment && toState == RadiologyTest.States.AdmissionAppointment)
                UndoTransition_Appointment2AdmissionAppointment(transDef);
            else if (fromState == RadiologyTest.States.ResultEntry && toState == RadiologyTest.States.Reported)
                UndoTransition_ResultEntry2Reported(transDef);
            else if (fromState == RadiologyTest.States.Procedure && toState == RadiologyTest.States.AdmissionAppointment)
                UndoTransition_Procedure2AdmissionAppointment(transDef);
            else if (fromState == RadiologyTest.States.RequestAcception && toState == RadiologyTest.States.Appointment)
                UndoTransition_RequestAcception2Appointment(transDef);
        }

        public override bool SendToENabiz(bool isNewInserted)
        {
            if (IsOldAction == true)
                return false;
            if (CurrentStateDefID == RadiologyTest.States.Completed || CurrentStateDefID == RadiologyTest.States.Reported)
                return true;

            return false;

        }

        // AccessionNo lar 7 karakterden kısaysa Teletıp'a başına "0" eklenerek gönderiliyormuş. 
        // Hizmet Kayıtta da aynı numara gönderilsin diye başına "0" eklenip 7 karaktere tamamlanır.
        public static void AddZerosForAccessionNo(ref string accessionNo)
        {
            if (accessionNo.Length < 6)
            {
                for (int j = accessionNo.Length; j <= 6; j++)
                {
                    accessionNo = "0" + accessionNo;
                }
            }
        }

        //TODO: başka task için daha sonra açılacak
        //override public bool IsParentRelationReadonly(TTObjectRelationDef relDef)
        //{
        //    if (relDef.ParentObjectDef.IsOfType(typeof(ProcedureDefinition).Name.ToUpperInvariant())) //ProcedureObject
        //        //İstek kabul aşamasında RadiologyTest in ProcedureObject inin değişmesine izin veriliyor. Değişen işlemin AccountTrx i İstek Kabul postsave de iptal ediliyor.
        //        if (this.CurrentStateDefID.ToString() == RadiologyTest.States.RequestAcception.ToString()) 
        //            return false;
        //        else
        //            return IsAccountOperationDone();
        //    else
        //        return false;
        //}


        public static void CheckRadiologyWorkListStartTime(int checkCount)
        {
            //Radyoloji Is listesinde o gun tanimli saatte henuz İşlemde asamasina alinmis radyoloji test islemi yoksa, ilgili kullanicilara SMS gonderirir.
            string lastTime = "";
            if (checkCount == 1)
                lastTime = TTObjectClasses.SystemParameter.GetParameterValue("RADIOLOGYWORKLISTFIRSTCHECKTIME", "08:45");
            else if (checkCount == 2)
                lastTime = TTObjectClasses.SystemParameter.GetParameterValue("RADIOLOGYWORKLISTSECONDCHECKTIME", "09:00");

            DateTime startDate = Convert.ToDateTime(DateTime.Now.ToString("dd.MM.yyyy") + " " + "00:00:00");
            DateTime endDate = Convert.ToDateTime(DateTime.Now.ToString("dd.MM.yyyy") + " " + lastTime + ":00");

            BindingList<RadiologyTest.GetCountRadiologyTestByReqAcceptionStateByDate_Class> radiologyTests = RadiologyTest.GetCountRadiologyTestByReqAcceptionStateByDate(startDate, endDate);

            if (radiologyTests.Count > 0)
            {
                if (Convert.ToInt16(radiologyTests[0].Radiologytestcount) == 0)
                {
                    //SendUser Message
                    UserMessage userMessage = new UserMessage();
                    string messageText = "Bugün saat " + lastTime + " itibariyle Radyoloji Birimi tetkik kabul işlemleri başlamamıştır. Bilgilerinize.";
                    if (!string.IsNullOrEmpty(messageText))
                    {
                        TTObjectContext context = new TTObjectContext(false);
                        ResUser smsPerson;
                        string sysParameterName = "";
                        if (checkCount == 1)
                            sysParameterName = "RADIOLOGYWORKLISTFIRSTCHECKUSER";
                        else if (checkCount == 2)
                            sysParameterName = "RADIOLOGYWORKLISTSECONDCHECKUSER";


                        string[] smsPersonList = TTObjectClasses.SystemParameter.GetParameterValue(sysParameterName, "").Split(',');
                        List<Guid> smsPersonGuidList = new List<Guid>();
                        foreach (var item in smsPersonList.Where(x => !string.IsNullOrEmpty(x)))
                        {
                            smsPersonGuidList.Add(new Guid(item));
                        }

                        string filter = Common.CreateFilterExpressionOfGuidList("", "OBJECTID", smsPersonGuidList);
                        BindingList<ResUser> smsUserList = context.QueryObjects<ResUser>(filter);
                        userMessage.SendSMSPerson(smsUserList.ToList(), messageText, SMSTypeEnum.RadiologyDelaySMS);

                        //if (smsPersonList != null)
                        //{
                        //    for (int i = 0; i < smsPersonList.Length; i++)
                        //    {
                        //        if (smsPersonList[i] != null && smsPersonList[i] != "")
                        //        {
                        //            try
                        //            {
                        //                smsPerson = (ResUser)context.GetObject(new Guid(smsPersonList[i]), "RESUSER");
                        //                userMessage.SendSMSPerson(smsPerson, messageText);
                        //            }
                        //            catch { }
                        //        }
                        //    }
                        //}
                    }
                }
            }

        }

        protected void SendSmsForRadiologyTestReported()//Rapor onaylandığında hastalara sms atar
        {
            string smsRadiologyActive = TTObjectClasses.SystemParameter.GetParameterValue("SMSRADIOLOGYACTIVE", "FALSE");

            if (smsRadiologyActive == "TRUE")
            {
                try
                {
                    UserMessage userMessage = new UserMessage();
                    string messageText = this.ProcedureObject.Name + " sonucunuz çıkmıştır. Alo 182 den ya da www.mhrs.gov.tr adresinden muayene " +
                            "olduğunuz polikliniğe randevu alarak muayene zamanınızı belirleyebilirsiniz.Bu mesajın " +
                            "size ait olmadığını düşünüyorsanız lütfen dikkate almayınız.Sağlıklı günler dileğiyle.";
                    List<Patient> patients = new List<Patient> { Episode.Patient };
                    userMessage.SendSMSPatient(patients, messageText, SMSTypeEnum.RadTestReportSMSForPatient);
                }
                catch
                {

                }
            }
        }

        protected void SendSmsForRadiologyAppointment()//Randevu verildiğinde testin ön bilgi alanı dolu ise sms gönderilir
        {
            string smsRadiologyActive = TTObjectClasses.SystemParameter.GetParameterValue("SMSRADIOLOGYACTIVE", "FALSE");

            if (smsRadiologyActive == "TRUE" && this.RadiologyTestDefinition.PreInformation != null && this.RadiologyTestDefinition.PreInformation != String.Empty)
            {
                try
                {
                    UserMessage userMessage = new UserMessage();
                    string messageText = this.RadiologyTestDefinition.PreInformation.ToString();

                    BindingList<Appointment> appointments = GetMyNewAppointments(this.ObjectID);
                    foreach (Appointment app in appointments)
                    {
                        if (app.BreakAppointment == true)
                            messageText += " Zaman: Saatsiz Randevu ";
                        else if (app.AppDate != null && app.StartTime != null && app.EndTime != null)
                            messageText += " Zaman:" + (Convert.ToDateTime(app.AppDate)).ToString("dd.MM.yyyy") + " " + Convert.ToDateTime(app.StartTime).ToShortTimeString() + "-" + Convert.ToDateTime(app.EndTime).ToShortTimeString();
                    }
                    List<Patient> patients = new List<Patient> { Episode.Patient };
                    userMessage.SendSMSPatient(patients, messageText, SMSTypeEnum.RadAppointmentSMSForPatient);
                }
                catch
                {

                }
            }
        }

        public override Resource GetDefaultAppointmentMasterResource()
        {
            return this.Department;
        }
        public override Resource GetDefaultAppointmentResource()
        {
            return this.Equipment;
        }

        protected void CompleteSMSForRadiologyTest() //İşlem tamamlandığında flag set edilecek ve bir daha mesaj gönderilmeyecek
        {
            try
            {
                //SMS 
                string smsRadiologyActive = TTObjectClasses.SystemParameter.GetParameterValue("SMSRADIOLOGYACTIVE", "FALSE");

                if (smsRadiologyActive == "TRUE")
                {
                    BindingList<SubactionProcedureSMSInfo> smsInfo = SubactionProcedureSMSInfo.GetSubactionProcedureSmsInfo(ObjectContext, this.ObjectID);
                    if (smsInfo.Count > 0)
                    {
                        smsInfo.FirstOrDefault().CompletedFlag = true;
                    }

                }
            }
            catch
            {

            }
        }

        protected void CancelSMSForRadiologyTest() //İşlem iptal edildiğinde flag set edilecek ve bir daha mesaj gönderilmeyecek
        {
            try
            {
                //SMS 
                string smsRadiologyActive = TTObjectClasses.SystemParameter.GetParameterValue("SMSRADIOLOGYACTIVE", "FALSE");

                if (smsRadiologyActive == "TRUE")
                {
                    BindingList<SubactionProcedureSMSInfo> smsInfo = SubactionProcedureSMSInfo.GetSubactionProcedureSmsInfo(ObjectContext, this.ObjectID);
                    if (smsInfo.Count > 0)
                    {
                        smsInfo.FirstOrDefault().IsActiveFlag = false;
                    }


                }
            }
            catch { }
        }

        protected void SendMRBTSMS()
        {
            try
            {
                string smsRadiologyActive = TTObjectClasses.SystemParameter.GetParameterValue("SMSRADIOLOGYACTIVE", "FALSE");

                if (smsRadiologyActive == "TRUE")
                {

                    var radTestDefinition = this.ProcedureObject as RadiologyTestDefinition;
                    var radTestType = radTestDefinition.TestType as RadiologyTestTypeDefinition;
                    if (radTestType != null && (radTestType.Name == "MR" || radTestType.Name == "BT"))
                    {
                        SubactionProcedureSMSInfo smsInfo = new SubactionProcedureSMSInfo(ObjectContext);
                        smsInfo.SubactionProcedureID = this.ObjectID;
                        smsInfo.InternalObjectDefNAme = this.ObjectDef.Name;
                        smsInfo.ProcedureDate = Common.RecTime();
                        smsInfo.CompletedFlag = false; //Tamamlandığında true olacak
                        smsInfo.IsActiveFlag = true; //Yaratılan radiologytest iptal edilirse false olacak
                        smsInfo.SMSNumberForChief = 0;
                        smsInfo.SMSNumberForDoctor = 0;
                        smsInfo.SMSNumberForResponsible = 0;
                        smsInfo.DoctorUserID = null; //mesaj gönderildiğinde doldurulacak
                        smsInfo.ChiefUserID = null;
                        smsInfo.ResponsibleUserID = null;
                    }


                }
            }
            catch { }
        }

    }
}