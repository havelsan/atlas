
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
    public partial class SubactionProcedureFlowable : SubActionProcedure, IEpisodeActionResources, IAccountOperation, IEpisodeActionPermission, IEpisodeAction
    {
        public partial class GetUncompletedSPFsByEpisode_Class : TTReportNqlObject
        {
        }

        public partial class GetBySPFWorklistDateReport_Class : TTReportNqlObject
        {
            #region GetByWorklistDateReport_Methods
            //            public string RefNo
            //{
            //    get
            //    {
            //        if (this.Foreign == true)
            //            return "(*) " + Convert.ToString(this.UniqueRefNo);
            //        else
            //            return Convert.ToString(this.UniqueRefNo);
            //    }
            //}
            // public DateTime? WorkListDateTime
            //{
            //    get
            //    {
            //        if (this.WorkListDate.HasValue && this.WorkListDate.Value.Equals(new DateTime(1800,1,1)))
            //            return this.ActionDate;
            //        else
            //            return this.WorkListDate;
            //    }
            //}


            #endregion GetByWorklistDateReport_Methods

        }

        public partial class GetBySPFFilterExpressionReport_Class : TTReportNqlObject
        {
            #region GetBySPFFilterExpressionReport_Methods

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
            public DateTime? WorkListDateTime
            {
                get
                {
                    if (WorkListDate.HasValue && WorkListDate.Value.Equals(new DateTime(1800, 1, 1)))
                        return ActionDate;
                    else
                        return WorkListDate;
                }
            }

            #endregion GetBySPFFilterExpressionReport_Methods

        }

        public partial class GetSubactionProceduresByObjectIDs_Class : TTReportNqlObject
        {
        }

        public partial class GetPatientFolderEpisodeSubactions_Class : TTReportNqlObject
        {
        }

        public partial class GetEndOfDayConsultationPoliclinicReport_Class : TTReportNqlObject
        {
        }

        public partial class VEM_TETKIK_ORNEK_Class : TTReportNqlObject
        {
        }

        public partial class VEM_TETKIK_SONUC_Class : TTReportNqlObject
        {
        }

        #region IEpisodeActionPermission Members

        public AuthorizedUser.ChildAuthorizedUserCollection GetAuthorizedUsers()
        {
            return AuthorizedUsers;
        }

        public ResUser GetProcedureDoctor()
        {
            return ProcedureDoctor;
        }

        public void GetProcedureDoctor(ResUser value)
        {
            ProcedureDoctor = value;
        }

        public TTObjectStateDef GetCurrentStateDef()
        {
            return CurrentStateDef;
        }

        public void SetCurrentStateDef(TTObjectStateDef value)
        {
            CurrentStateDef = value;
        }
        #endregion

        #region IEpisodeAction Members

        public Episode GetEpisode()
        {
            return Episode;
        }

        public void SetEpisode(Episode value)
        {
            Episode = value;
        }

        public ResSection GetFromResource()
        {
            return FromResource;
        }

        public void SetFromResource(ResSection value)
        {
            FromResource = value;
        }

        public ResSection GetMasterResource()
        {
            return MasterResource;
        }

        public void SetMasterResource(ResSection value)
        {
            MasterResource = value;
        }

        public ResSection GetSecondaryMasterResource()
        {
            return SecondaryMasterResource;
        }

        public void SetSecondaryMasterResource(ResSection value)
        {
            SecondaryMasterResource = value;
        }

        public SubEpisode GetSubEpisode()
        {
            return SubEpisode;
        }

        public void SetSubEpisode(SubEpisode value)
        {
            SubEpisode = value;
        }

        public PatientMedulaHastaKabul GetMedulaHastaKabul()
        {
            return MedulaHastaKabul;
        }

        public void SetMedulaHastaKabul(PatientMedulaHastaKabul value)
        {
            MedulaHastaKabul = value;
        }

        #endregion
        /// <summary>
        /// Açıklama
        /// </summary>
        public string DescriptionForWorkList
        {
            get
            {
                try
                {
                    #region DescriptionForWorkList_GetScript                    
                    if (ProcedureObject != null)
                        return ProcedureObject.Name;
                    else
                        return String.Empty;
                    #endregion DescriptionForWorkList_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "DescriptionForWorkList") + " : " + ex.Message, ex);
                }
            }
        }

        public bool? IsOrderDetailObject
        {
            get
            {
                try
                {
                    #region IsOrderDetailObject_GetScript                    
                    return (bool?)(OrderObject != null);
                    #endregion IsOrderDetailObject_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "IsOrderDetailObject") + " : " + ex.Message, ex);
                }
            }
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "MASTERRESOURCE":
                    {
                        ResSection value = (ResSection)newValue;
                        #region MASTERRESOURCE_SetParentScript
                        //PreInsert ve PreUpdate e taşındı.
                        //if (value != null)
                        //{
                        //    if (this.SetProcedureSpecialtyBy().ToUpper() == "MASTERRESOURCE")
                        //    {
                        //        if (value.ResourceSpecialities.Count == 1)
                        //        {
                        //            this.ProcedureSpeciality = value.ResourceSpecialities[0].Speciality;
                        //        }

                        //    }
                        //}
                        #endregion MASTERRESOURCE_SetParentScript
                    }
                    break;
                case "ORDEROBJECT":
                    {
                        PlannedAction value = (PlannedAction)newValue;
                        #region ORDEROBJECT_SetParentScript
                        // PhysiotherapyRequest in ProcedureDoctor'unu kendi ProcedureDoctor alanına set eder


                        if (value is PhysiotherapyOrder && this is PhysiotherapyOrderDetail)
                        {
                            //if ( ((PhysiotherapyOrder)value).PhysiotherapyRequest.ProcedureDoctor != null)
                            //    ((PhysiotherapyOrderDetail)this).ProcedureDoctor = ((PhysiotherapyOrder)value).PhysiotherapyRequest.ProcedureDoctor;

                            if (((PhysiotherapyOrder)value).ProcedureByUser != null)
                                ((PhysiotherapyOrderDetail)this).ProcedureByUser = ((PhysiotherapyOrder)value).ProcedureByUser;
                        }

                        if (value is DialysisOrder && this is DialysisOrderDetail)
                        {
                            //if ( ((DialysisOrder)value).DialysisRequest.ProcedureDoctor != null)
                            //    ((DialysisOrderDetail)this).ProcedureDoctor = ((DialysisOrder)value).DialysisRequest.ProcedureDoctor;

                            if (((DialysisOrder)value).ProcedureByUser != null)
                                ((DialysisOrderDetail)this).ProcedureByUser = ((DialysisOrder)value).ProcedureByUser;
                        }

                        if (value is HyperbaricOxygenTreatmentOrder && this is HyperbarikOxygenTreatmentOrderDetail)
                        {
                            //if ( ((HyperbaricOxygenTreatmentOrder)value).HyperOxygenTreatmentRequest.ProcedureDoctor != null)
                            //    ((HyperbarikOxygenTreatmentOrderDetail)this).ProcedureDoctor = ((HyperbaricOxygenTreatmentOrder)value).HyperOxygenTreatmentRequest.ProcedureDoctor;

                            if (((HyperbaricOxygenTreatmentOrder)value).ProcedureByUser != null)
                                ((HyperbarikOxygenTreatmentOrderDetail)this).ProcedureByUser = ((HyperbaricOxygenTreatmentOrder)value).ProcedureByUser;
                        }

                        if (value is PlannedMedicalActionOrder && this is PlannedMedicalActionOrderDetail)
                        {
                            //if ( ((PlannedMedicalActionOrder)value).PlannedMedicalActionRequest.ProcedureDoctor != null)
                            //    ((PlannedMedicalActionOrderDetail)this).ProcedureDoctor = ((PlannedMedicalActionOrder)value).PlannedMedicalActionRequest.ProcedureDoctor;

                            if (((PlannedMedicalActionOrder)value).ProcedureByUser != null)
                                ((PlannedMedicalActionOrderDetail)this).ProcedureByUser = ((PlannedMedicalActionOrder)value).ProcedureByUser;
                        }

                        //
                        #endregion ORDEROBJECT_SetParentScript
                    }
                    break;
                case "FROMRESOURCE":
                    {
                        ResSection value = (ResSection)newValue;
                        #region FROMRESOURCE_SetParentScript
                        //PreInsert ve PreUpdate e taşındı.
                        //if (value != null)
                        //{
                        //    if (this.SetProcedureSpecialtyBy().ToUpper() == "FROMRESOURCE")
                        //    {
                        //        if (value.ResourceSpecialities.Count == 1)
                        //        {
                        //            this.ProcedureSpeciality = value.ResourceSpecialities[0].Speciality;
                        //        }
                        //    }
                        //}
                        #endregion FROMRESOURCE_SetParentScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        protected override void PreInsert()
        {
            #region PreInsert

            base.PreInsert();
            SetProcedureSpeciality();
            if (MasterResource != null)
            {
                //Sequence bir Protocolno propertysi  olan tüm işlemlerin masterresourceu set edildiğinde bölüme ve yıla göre protokol numarası almasını sağlar
                System.Reflection.PropertyInfo propInfo = GetType().GetProperty("ProtocolNo");
                if (propInfo != null && propInfo.PropertyType == typeof(TTSequence))
                {
                    TTSequence protocolNo = propInfo.GetValue(this, null) as TTSequence;
                    if (protocolNo.Value == null)
                        protocolNo.GetNextValue(MasterResource.ObjectID.ToString(), Common.RecTime().Year);
                }
            }
            #endregion PreInsert
        }

        protected override void PostInsert()
        {
            #region PostInsert
            base.PostInsert();

            if (IsOldAction != true)
            {
                StockOutTreatmentMaterials();
                AccountOperation();
            }
            if (CreationDate == null)
                CreationDate = Common.RecTime();

            ActionDate = CreationDate;
            #endregion PostInsert
        }

        protected override void PreUpdate()
        {
            #region PreUpdate


            base.PreUpdate();
            SetProcedureSpeciality();
            if (CurrentStateDef.Status == StateStatusEnum.Uncompleted)
            {
                ActionDate = Common.RecTime();
            }
            #endregion PreUpdate
        }

        protected override void PostUpdate()
        {
            #region PostUpdate
            base.PostUpdate();
            if (IsOldAction != true)
            {
                StockOutTreatmentMaterials();
                AccountOperation();
                CloseCloseToOpenEpisode();// son işlemlse episodeu kapatsın
            }


            #endregion PostUpdate
        }

        #region Methods
        /// <summary>
        /// Class'a bağlanan SetProcedureSpecialtyByAttribute yoksa MASTERRESOURCE varda parametre değeri ne ise o döner.
        /// </summary>
        public string SetProcedureSpecialtyBy()
        {
            if (IsAttributeExists(typeof(SetProcedureSpecialtyByAttribute)) == false)
            {
                return "MASTERRESOURCE";
            }
            else
            {
                return ObjectDef.Attributes["SETPROCEDURESPECIALTYBYATTRIBUTE"].Parameters["By"].Value.ToString();
            }
        }

        public void SetProcedureSpeciality()
        {
            if (SetProcedureSpecialtyBy().ToUpper() == "MASTERRESOURCE" && MasterResource != null)
            {
                if (MasterResource.ResourceSpecialities != null && MasterResource.ResourceSpecialities.Count > 0)
                {
                    ProcedureSpeciality = MasterResource.ResourceSpecialities[0].Speciality;
                }
            }
            else if (SetProcedureSpecialtyBy().ToUpper() == "FROMRESOURCE" && FromResource != null)
            {
                if (FromResource.ResourceSpecialities != null && FromResource.ResourceSpecialities.Count > 0)
                {
                    ProcedureSpeciality = FromResource.ResourceSpecialities[0].Speciality;
                }
            }
        }

        /// <summary>
        /// Herhangi bir episodeactionda iken bir başka episodeaction fire edildiğinde, Fire edilen episodeAction classı içindeki zorunlu alanları set eder.
        /// </summary>
        /// <param name="episodeAction"></param>
        /// <param name="masterResource"></param>
        /// <param name="fromResource"></param>
        /// <param name="setmasterAction"></param>
        public static void SetMandatorySubactionProcedureFlowableProperties(EpisodeAction episodeAction, ResSection masterResource, ResSection fromResource, SubactionProcedureFlowable subactionProcedureFlowable)
        {
            subactionProcedureFlowable.ActionDate = Common.RecTime();
            subactionProcedureFlowable.MasterResource = masterResource;
            subactionProcedureFlowable.FromResource = fromResource;
            subactionProcedureFlowable.Episode = episodeAction.Episode;
        }

        public virtual List<SubActionProcedure> GetAccountableSubActionProcedures()
        {
           
                List<SubActionProcedure> myCol = new List<SubActionProcedure>();

                if (IsCancelled == false && Eligible == true && ProcedureObject.Chargable == true)
                    myCol.Add(this);

                foreach (SubActionProcedure sp in ChildSubActionProcedure)
                {
                    if (sp.IsCancelled == false && sp.Eligible == true && sp.ProcedureObject.Chargable == true)
                        myCol.Add(sp);
                }
                return myCol;
            
        }

        public virtual List<SubActionMaterial> GetAccountableSubActionMaterials()
        {
                List<SubActionMaterial> myCol = new List<SubActionMaterial>();
                foreach (BaseTreatmentMaterial tm in TreatmentMaterials)
                {
                    if (tm.IsCancelled == false && tm.Eligible == true && tm.Material.Chargable == true)
                        myCol.Add((SubActionMaterial)tm);
                }
                return myCol;
            
        }

        public override void Cancel()
        {
            base.Cancel();
            foreach (BaseTreatmentMaterial treatmentMaterial in TreatmentMaterials)
            {
                if (treatmentMaterial.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                {
                    foreach (BaseTreatmentMaterial baseTreatmentMaterial in TreatmentMaterials)
                    {
                        if (baseTreatmentMaterial.StockActionDetail != null)
                        {
                            if (baseTreatmentMaterial.StockActionDetail.StockAction is StockOut)
                            {
                                if (((StockOut)baseTreatmentMaterial.StockActionDetail.StockAction).CurrentStateDefID != StockOut.States.Cancelled)
                                {
                                    ((StockOut)baseTreatmentMaterial.StockActionDetail.StockAction).CurrentStateDefID = StockOut.States.Cancelled;
                                }
                            }
                        }
                    }
                    ((ITTObject)treatmentMaterial).Cancel();
                }
            }
        }

        public void StockOutTreatmentMaterials()
        {
            foreach (BaseTreatmentMaterial treatmentMaterial in TreatmentMaterials)
            {
                treatmentMaterial.StockOutByEpisodeActionAttribute();
            }
        }

        public void AccountOperation()
        {
            foreach (SubActionProcedure sp in GetAccountableSubActionProcedures())
                sp.AccountOperationAttribute();

            foreach (SubActionMaterial sm in GetAccountableSubActionMaterials())
                sm.AccountOperationAttribute();
        }

        /// <summary>
        /// SubactionProcedureFlowable ın current state inde CheckPaidStateAttribute varsa, işlem ücretinin (Hasta Payının) ödenip ödenmediği kontrolünü yapar
        /// </summary>
        public static void CheckPaid(SubactionProcedureFlowable subactionProcedureFlowable)
        {
            if (subactionProcedureFlowable.CurrentStateDef.Attributes.ContainsKey("CheckPaidStateAttribute"))
            {
                if (subactionProcedureFlowable.Paid() == false)
                    throw new TTException(SystemMessage.GetMessage(141));
            }
        }

        public bool Paid()
        {
            // Yatan hastada ödeme kontrolü yapılmaz
            if (Episode.PatientStatus == PatientStatusEnum.Inpatient)
                return true;

            if (Episode.Patient.APR.Count > 0)
            {
                foreach (SubActionProcedure sp in GetAccountableSubActionProcedures())
                {
                    if (sp.Paid() == false)
                        return false;
                }

                foreach (SubActionMaterial sm in GetAccountableSubActionMaterials())
                {
                    if (sm.Paid() == false)
                        return false;
                }

                if (Episode.IsUnpaidPackageSPExists())  // Episode da ödenmemiş hasta payı paket hizmet varsa false döndürülür
                    return false;
            }

            return true;
        }

        public static bool IsPaid(Guid subActProcFlowID)
        {
            TTObjectContext context = new TTObjectContext(true);
            SubactionProcedureFlowable subActionProcedureFlowable = (SubactionProcedureFlowable)context.GetObject(subActProcFlowID, "SUBACTIONPROCEDUREFLOWABLE");
            return subActionProcedureFlowable.Paid();
        }

        public static bool AllowedToCancel(Guid subActProcFlowID)
        {
            TTObjectContext context = new TTObjectContext(false);
            SubactionProcedureFlowable subActionProcedureFlowable = (SubactionProcedureFlowable)context.GetObject(subActProcFlowID, "SUBACTIONPROCEDUREFLOWABLE");
            // Kan Bankası ürünü Kan Bankası stoğuna iade olduğunda çağrılan bu metod sayesinde iade olan ürün için o hizmet iptal olur.
            if (subActionProcedureFlowable.IsAllowedToCancel() == true)
            {
                BloodBankBloodProducts product = subActionProcedureFlowable as BloodBankBloodProducts;
                if (product != null)
                {
                    foreach (BloodBankSubProduct subProduct in product.BloodBankSubProducts)
                    {
                        BloodBankTestDefinition testDef = subProduct.ProcedureObject as BloodBankTestDefinition;
                        if (testDef != null)
                        {
                            if (testDef.OnlyChargeWithProduct == true)
                                subProduct.Cancel();
                        }
                    }
                    product.CancelMyAccountTransactions();
                }
            }
            return subActionProcedureFlowable.IsAllowedToCancel();
        }

        public bool IsLastActionInEpisode()
        {
            foreach (EpisodeAction ea in Episode.EpisodeActions)
            {
                if (ea.CurrentStateDef.Status == StateStatusEnum.Uncompleted)//tamamlanmamış bir episodeaction varsa Episode ACIK TAMAM gelir
                    return false;
            }

            foreach (SubactionProcedureFlowable spf in Episode.SubactionProcedureFlowables)
            {
                if (spf.ObjectID != ObjectID)// bu işlem harici episodedaki işlemlere bakılır.
                {
                    if (spf.CurrentStateDefID != null)//subaction prosedurun statei olmaya bilir
                    {
                        if (spf.CurrentStateDef.Status == StateStatusEnum.Uncompleted)//tamamlanmamış bir SubactionProcedureFlowable varsa Episode ACIK TAMAM gelir
                            return false;
                    }
                }
            }
            return true;
        }
        public void CloseCloseToOpenEpisode()
        {
            if (Episode != null)
            {
                if (Episode.CurrentStateDefID == Episode.States.ClosedToNew)
                {
                    if (CurrentStateDefID != null)
                    {
                        if (CurrentStateDef.Status != StateStatusEnum.Uncompleted && IsLastActionInEpisode())
                            Episode.CloseEpisode();
                    }
                }
            }
        }

        //ICreateSubEpisode için 
        public override ResSection GetSubEpisodeResSection()
        {
                return (MasterResource == null && EpisodeAction != null) ? EpisodeAction.MasterResource : MasterResource;
        }


        protected virtual List<EpisodeAction.OldActionPropertyObject> OldActionPropertyList()
        {

            return null;
        }

        protected virtual List<List<List<EpisodeAction.OldActionPropertyObject>>> OldActionChildRelationList()
        {
            return null;
        }

        public virtual string OldActionReportHtml()
        {
            string report = "<html>";
            if (OldActionPropertyList() != null)
            {
                if (OldActionPropertyList().Count > 0)
                {
                    report = report + "<table border=1 width='100%'>";
                    foreach (EpisodeAction.OldActionPropertyObject property in OldActionPropertyList())
                    {
                        report = report + "<tr>" + Common.FormatAsOldActionTitle(property.PropertyCaption, null) + Common.FormatAsOldActionValue(property.PropertyValue, null);
                    }
                    report = report + "</table>";
                }
            }
            if (OldActionChildRelationList() != null)
            {
                foreach (List<List<EpisodeAction.OldActionPropertyObject>> grid in OldActionChildRelationList())// her bir grid için dönüyor
                {
                    if (grid != null)
                    {
                        if (grid.Count > 0)
                        {
                            report = report + "<table border width='100%'>";
                            report = report + "<tr>";
                            foreach (EpisodeAction.OldActionPropertyObject property in grid[0])// griddeki her bir bir obje propertysi için başlık satırı tek olacağı için gelen ilk objeninki alındı
                            {
                                report = report + Common.FormatAsOldActionTitleV2(property.PropertyCaption, null, true);
                            }
                            report = report + "</tr>";
                            foreach (List<EpisodeAction.OldActionPropertyObject> childRelationRow in grid)
                            {
                                if (childRelationRow.Count > 0)
                                {
                                    report = report + "<tr>";
                                    foreach (EpisodeAction.OldActionPropertyObject property in childRelationRow)// her bir obje propertysi değerleri yazılır
                                    {
                                        report = report + Common.FormatAsOldActionValue(property.PropertyValue, null);
                                    }
                                    report = report + "</tr>";
                                }
                            }
                            report = report + "</table>";
                        }
                    }
                }
            }
            report = report + "</html>";
            return report;
        }





        public virtual TreatmentDischarge MyTreatmentDischarge()
        {
            return null;
        }

        /// <summary>
        /// İşlemi Başlatmak için Ön Tanı veya Tanı Zorunlu Ama Boş ise Hata Verir.
        /// </summary>
        public void DiagnosisIsRequired(SubEpisode subepisode)
        {
            if (IsRequiredPreDiagnosis() && !(subepisode.IsDiagnosisExists()))
            {
                //                string[] hataParamList = new string[] { this._objectDef.ApplicationName };
                //                throw new TTUtils.TTException(SystemMessage.GetMessage(157, hataParamList));
                throw new Exception(SystemMessage.GetMessageV3(1128, new string[] { _objectDef.Description.ToString() }));
            }
        }

        public void DiagnosisIsRequired()
        {
            DiagnosisIsRequired(SubEpisode);
        }

        /// <summary>
        /// Class'a bağlanan RequiredPreDiagnosisAttribute varsa true yoksa false doner
        /// </summary>
        protected bool IsRequiredPreDiagnosis()
        {
            if (IsAttributeExists(typeof(RequiredPreDiagnosisAttribute)) == true)
                return true;
            return false;
        }

        /// <summary>
        /// Class'a bağlanan RequiredSecDiagnosisAttribute varsa true yoksa false doner
        /// </summary>
        protected bool IsRequiredSecDiagnosis()
        {
            if (IsAttributeExists(typeof(RequiredSecDiagnosisAttribute)) == true)
                return true;
            return false;
        }

        public void PreDiagnosisIsRequired()
        {
            if (IsRequiredPreDiagnosis() && !(SubEpisode.IsPreDiagnosisExists()))
            {
                throw new Exception(SystemMessage.GetMessageV3(157, new string[] { _objectDef.Description.ToString() }));
            }
        }

        public void SecDiagnosisIsRequired()
        {
            if (IsRequiredSecDiagnosis() && !(SubEpisode.IsSecDiagnosisExists()))
            {
                throw new Exception(SystemMessage.GetMessageV3(158, new string[] { _objectDef.Description.ToString() }));
            }
        }

        public static Resource GetSpecialResourceForStore(SubactionProcedureFlowable subactionProcedureFlowable)
        {
            return subactionProcedureFlowable.SpecialResourceForStore();
        }

        public virtual Resource SpecialResourceForStore()
        {
            return SecondaryMasterResource;
        }

        public bool HasActiveQueueItem()
        {
            if (QueueItems.Count == 0)
                return false;
            foreach (ExaminationQueueItem queueItem in QueueItems)
            {
                if (queueItem.QueueDate.Value.Date == Common.RecTime().Date)
                {
                    if (queueItem.CurrentStateDefID == ExaminationQueueItem.States.New || queueItem.CurrentStateDefID == ExaminationQueueItem.States.Called || queueItem.CurrentStateDefID == ExaminationQueueItem.States.Diverted)
                        return true;
                }
            }
            return false;
        }
        public ExaminationQueueItem CreateExaminationQueueItem(PatientAdmission patientAdmission, ExaminationQueueDefinition appQueueDef)
        {
            return CreateExaminationQueueItem(patientAdmission, appQueueDef, false);
        }

        public ExaminationQueueItem CreateExaminationQueueItem(PatientAdmission patientAdmission, ExaminationQueueDefinition appQueueDef, bool isEmergency)
        {
            Dictionary<int, string> PriorityPair;
            ExaminationQueueItem examinationQueueItem = null;
            if (this is INumaratorAppointment)
            {
                if (TTObjectClasses.SystemParameter.GetParameterValue("CloseExaminationQueueItem", "FALSE") != "TRUE")
                {
                    //if(this.MasterResource != null && this.MasterResource is ResPoliclinic)
                    //{
                    //if(((ResPoliclinic)this.MasterResource).PatientCallSystemInUse == true)
                    // {
                    if (Episode.Patient.HasActiveQueueItemInQueue(appQueueDef, ProcedureDoctor) == null)
                    {
                        //PriorityPair = this.EpisodeAction.GetMyPriority(appQueueDef, isEmergency, patientAdmission);
                        //KeyValuePair<int, string> kp = new KeyValuePair<int, string>();
                        //foreach (KeyValuePair<int, string> kpair in PriorityPair)
                        //{
                        //    kp = kpair;
                        //    break;
                        //}

                        examinationQueueItem = new ExaminationQueueItem(ObjectContext);
                        examinationQueueItem.EpisodeAction = EpisodeAction;
                        examinationQueueItem.SubactionProcedureFlowable = this;
                        examinationQueueItem.Appointment = null;
                        examinationQueueItem.CurrentStateDefID = TTObjectClasses.ExaminationQueueItem.States.New;
                        examinationQueueItem.Patient = Episode.Patient;
                        examinationQueueItem.Priority = (patientAdmission.PriorityStatus == null) ? 0 : patientAdmission.PriorityStatus.Order;
                        examinationQueueItem.PriorityReason = (patientAdmission.PriorityStatus == null) ? "" : patientAdmission.PriorityStatus.Name;
                        examinationQueueItem.QueueDate = Common.RecTime().Date;
                        examinationQueueItem.CallTime = Common.RecTime();
                        examinationQueueItem.ExaminationQueueDefinition = appQueueDef;
                        examinationQueueItem.DivertedTime = Common.RecTime();
                        examinationQueueItem.Doctor = ProcedureDoctor;
                        examinationQueueItem.CallCount = 0;
                    }
                }
                //}
                //}
            }
            return examinationQueueItem;
        }

        public void CompleteMyExaminationQueueItems()
        {
            IList<ExaminationQueueItem> itemList = ExaminationQueueItem.GetBySubactionProcedureFlowable(ObjectContext, ObjectID);
            if (itemList.Count > 0)
            {
                foreach (ExaminationQueueItem item in itemList)
                {
                    if (item.CurrentStateDefID != ExaminationQueueItem.States.Completed && item.CurrentStateDefID != ExaminationQueueItem.States.Cancelled)
                    {
                        item.CurrentStateDefID = ExaminationQueueItem.States.Completed;
                        if (item.SubactionProcedureFlowable.ProcedureDoctor != null)
                            item.CompletedBy = item.SubactionProcedureFlowable.ProcedureDoctor;
                    }
                }
            }
        }

        public void CancelMyExaminationQueueItems()
        {
            IList<ExaminationQueueItem> itemList = ExaminationQueueItem.GetBySubactionProcedureFlowable(ObjectContext, ObjectID);
            if (itemList.Count > 0)
            {
                foreach (ExaminationQueueItem item in itemList)
                {
                    if (item.CurrentStateDefID != ExaminationQueueItem.States.Completed && item.CurrentStateDefID != ExaminationQueueItem.States.Cancelled)
                        item.CurrentStateDefID = ExaminationQueueItem.States.Cancelled;
                }
            }
        }

        // Medula Hizmet Kayıt işleminde kullanılacak olan branş kodunu döndürür
        public string GetBranchCodeForMedula()
        {
            // Havale Edilen kaynağın uzmanlığı alınır
            if (MasterResource != null)
            {
                foreach (ResourceSpecialityGrid resSpeciality in MasterResource.ResourceSpecialities)
                {
                    if (resSpeciality.Speciality != null)
                        return resSpeciality.Speciality.Code;
                }
            }
            // Havale Edilen kaynağın uzmanlığı bulunamazsa, Havale Eden kaynağın uzmanlığı alınır
            if (FromResource != null)
            {
                foreach (ResourceSpecialityGrid resSpeciality in FromResource.ResourceSpecialities)
                {
                    if (resSpeciality.Speciality != null)
                        return resSpeciality.Speciality.Code;
                }
            }
            return null;
        }

        public override void AutoComplete()// Eğer Açık ise kapatır
        {
            // SubactıonProcedureler Eğer Otomatik Complete Edilecekse Bu methodu override etmeli 
        }

        public virtual void CheckRulesForNewEpisodeAction()
        {
        }

        public virtual void SetMyPropertiesByMasterAction(EpisodeAction masterEpisodeAction)
        {
            // Clientdan MasterEpisodeAction ile yeni Episodeacion başlatılırken set edilmesi gereken özellikler için 
            //FromResource,MasterAction,Episode alanları bu methodun çağırıldığı yerde zaten set ediliyor bunlar harici bir özellik masterActiondan alınması gerekiyorsa bu method overrideedilmeli
        }

        public override bool IsExternal()
        {
            if (MasterResource != null && MasterResource is ResObservationUnit && ((ResObservationUnit)MasterResource).IsExternalObservationUnit == true)
                return true;

            return base.IsExternal();
        }

        public virtual Resource GetDefaultAppointmentMasterResource()
        {
            return null;
        }
        public virtual Resource GetDefaultAppointmentResource()
        {
            return null;
        }

        #endregion Methods

    }
}