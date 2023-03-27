
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
    /// Diş Tedavi Prosedür
    /// </summary>
    public partial class DentalTreatmentProcedure : BaseDentalTreatment, IAppointmentDef, IWorkListEpisodeAction, ITreatmentMaterialCollection
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "TOOTHNUMBER":
                    {
                        ToothNumberEnum? value = (ToothNumberEnum?)(int?)newValue;
                        #region TOOTHNUMBER_SetScript
                        if (value.HasValue)
                        {
                            DentalPosition = Common.SetDentalPosition((int)value);
                        }
                        #endregion TOOTHNUMBER_SetScript
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

            foreach (AccountTransaction AccTrx in AccountTransactions)
            {
                if (AccTrx.CurrentStateDefID != AccountTransaction.States.Cancelled && ToothNumber != null)
                {
                    if (AccTrx.Description.IndexOf(" (Diş No: ") == -1) // Yeni ekleme
                        AccTrx.Description = AccTrx.Description + " (Diş No: " + Common.GetEnumValueDefOfEnumValue(ToothNumber.Value).DisplayText + ")";
                    else
                    {
                        // ToothNumber değişmişse AccTrx i de güncelleme
                        if (AccTrx.Description.IndexOf(" (Diş No: " + Common.GetEnumValueDefOfEnumValue(ToothNumber.Value).DisplayText + ")") == -1)
                            AccTrx.Description = AccTrx.Description.Substring(0, AccTrx.Description.IndexOf(" (Diş No: ")) + " (Diş No: " + Common.GetEnumValueDefOfEnumValue(ToothNumber.Value).DisplayText + ")";
                    }
                }
            }

            if (ToothNumber != null)
                ExtraDescription = "(Diş No: " + Common.GetEnumValueDefOfEnumValue(ToothNumber.Value).DisplayText + ")";
            else
                ExtraDescription = null;

            #endregion PostInsert
        }

        protected override void PostUpdate()
        {
            #region PostUpdate

            //YAPILACAKLAR//ObjectContext .RefreshObject yapıldığında  obj refresh edilmeli ki Request üzerinden açılırsa da refresh görsün.

            base.PostUpdate();

            foreach (AccountTransaction AccTrx in AccountTransactions)
            {
                if (AccTrx.CurrentStateDefID != AccountTransaction.States.Cancelled && ToothNumber != null)
                {
                    if (AccTrx.Description.IndexOf(" (Diş No: ") == -1) // Yeni ekleme
                        AccTrx.Description = AccTrx.Description + " (Diş No: " + Common.GetEnumValueDefOfEnumValue(ToothNumber.Value).DisplayText + ")";
                    else
                    {
                        // ToothNumber değişmişse AccTrx i de güncelleme
                        if (AccTrx.Description.IndexOf(" (Diş No: " + Common.GetEnumValueDefOfEnumValue(ToothNumber.Value).DisplayText + ")") == -1)
                            AccTrx.Description = AccTrx.Description.Substring(0, AccTrx.Description.IndexOf(" (Diş No: ")) + " (Diş No: " + Common.GetEnumValueDefOfEnumValue(ToothNumber.Value).DisplayText + ")";
                    }
                }
            }

            if (ToothNumber != null)
                ExtraDescription = "(Diş No: " + Common.GetEnumValueDefOfEnumValue(ToothNumber.Value).DisplayText + ")";
            else
                ExtraDescription = null;

            #endregion PostUpdate
        }

        protected void PostTransition_Appointment2TreatmentProcedure()
        {
            // From State : Appointment   To State : TreatmentProcedure
            #region PostTransition_Appointment2TreatmentProcedure

            CheckAndCompleteMyNewAppoinments();
            #endregion PostTransition_Appointment2TreatmentProcedure
        }

        protected void PostTransition_Appointment2Cancelled()
        {
            // From State : Appointment   To State : Cancelled
            #region PostTransition_Appointment2Cancelled
            Cancel();
            CheckAndCompleteMyNewAppoinments();
            #endregion PostTransition_Appointment2Cancelled
        }

        protected void UndoTransition_Appointment2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Appointment   To State : Cancelled
            #region UndoTransition_Appointment2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_Appointment2Cancelled
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PostTransition_Completed2Cancelled
            Cancel();
            #endregion PostTransition_Completed2Cancelled
        }

        protected void UndoTransition_Completed2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Completed   To State : Cancelled
            #region UndoTransition_Completed2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_Completed2Cancelled
        }

        protected void UndoTransition_TreatmentProcedure2Appointment(TTObjectStateTransitionDef transitionDef)
        {
            // From State : TreatmentProcedure   To State : Appointment
            #region UndoTransition_TreatmentProcedure2Appointment
            NoBackStateBack();
            #endregion UndoTransition_TreatmentProcedure2Appointment
        }

        protected void UndoTransition_TreatmentProcedure2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : TreatmentProcedure   To State : Completed
            #region UndoTransition_TreatmentProcedure2Completed

            double limit = CheckIfDayLimitExceeded();
            if (limit != 0)
                throw new Exception(SystemMessage.GetMessageV3(1143, new string[] { limit.ToString() }));
            if (DentalTreatmentRequest.CurrentStateDefID == DentalTreatmentRequest.States.Completed)
                ((ITTObject)DentalTreatmentRequest).UndoLastTransition();
            #endregion UndoTransition_TreatmentProcedure2Completed
        }

        protected void PostTransition_TreatmentProcedure2Cancelled()
        {
            // From State : TreatmentProcedure   To State : Cancelled
            #region PostTransition_TreatmentProcedure2Cancelled
            Cancel();
            #endregion PostTransition_TreatmentProcedure2Cancelled
        }

        protected void UndoTransition_TreatmentProcedure2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : TreatmentProcedure   To State : Cancelled
            #region UndoTransition_TreatmentProcedure2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_TreatmentProcedure2Cancelled
        }

        protected void PostTransition_TreatmentProcedure2Rejected()
        {
            // From State : TreatmentProcedure   To State : Rejected
            #region PostTransition_TreatmentProcedure2Rejected

            CancelMyAccountTransactions();
            #endregion PostTransition_TreatmentProcedure2Rejected
        }

        protected void UndoTransition_TreatmentProcedure2Rejected(TTObjectStateTransitionDef transitionDef)
        {
            // From State : TreatmentProcedure   To State : Rejected
            #region UndoTransition_TreatmentProcedure2Rejected

            if (DentalTreatmentRequest.CurrentStateDefID == DentalTreatmentRequest.States.Completed)
                ((ITTObject)DentalTreatmentRequest).UndoLastTransition();

            #endregion UndoTransition_TreatmentProcedure2Rejected
        }

        protected void UndoTransition_ApprovalTechnicanProcedure2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : ApprovalTechnicanProcedure   To State : Completed
            #region UndoTransition_ApprovalTechnicanProcedure2Completed


            double limit = CheckIfDayLimitExceeded();
            if (limit != 0)
                throw new Exception(SystemMessage.GetMessageV3(1143, new string[] { limit.ToString() }));
            if (DentalTreatmentRequest.CurrentStateDefID == DentalTreatmentRequest.States.Completed)
                ((ITTObject)DentalTreatmentRequest).UndoLastTransition();
            #endregion UndoTransition_ApprovalTechnicanProcedure2Completed
        }

        protected void PostTransition_ApprovalTechnicanProcedure2Cancelled()
        {
            // From State : ApprovalTechnicanProcedure   To State : Cancelled
            #region PostTransition_ApprovalTechnicanProcedure2Cancelled
            Cancel();
            #endregion PostTransition_ApprovalTechnicanProcedure2Cancelled
        }

        protected void UndoTransition_ApprovalTechnicanProcedure2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : ApprovalTechnicanProcedure   To State : Cancelled
            #region UndoTransition_ApprovalTechnicanProcedure2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_ApprovalTechnicanProcedure2Cancelled
        }

        protected void UndoTransition_TechnicianProcedure2Appointment(TTObjectStateTransitionDef transitionDef)
        {
            // From State : TechnicianProcedure   To State : Appointment
            #region UndoTransition_TechnicianProcedure2Appointment

            NoBackStateBack();
            #endregion UndoTransition_TechnicianProcedure2Appointment
        }

        protected void PostTransition_TechnicianProcedure2Cancelled()
        {
            // From State : TechnicianProcedure   To State : Cancelled
            #region PostTransition_TechnicianProcedure2Cancelled
            Cancel();
            #endregion PostTransition_TechnicianProcedure2Cancelled
        }

        protected void UndoTransition_TechnicianProcedure2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : TechnicianProcedure   To State : Cancelled
            #region UndoTransition_TechnicianProcedure2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_TechnicianProcedure2Cancelled
        }

        protected void PostTransition_Rejected2Cancelled()
        {
            // From State : Rejected   To State : Cancelled
            #region PostTransition_Rejected2Cancelled
            Cancel();
            #endregion PostTransition_Rejected2Cancelled
        }

        protected void UndoTransition_Rejected2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Rejected   To State : Cancelled
            #region UndoTransition_Rejected2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_Rejected2Cancelled
        }

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
                IList appDefList = AppointmentDefinition.GetAppointmentDefinitionByName(context, AppointmentDefinitionEnum.DentalTreatmentProcedure);
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
                    carrier.MasterResource = "ResPoliclinic";
                    carrier.SubResource = "ResUser";
                    carrier.RelationParentName = "";

                    _appointmentList.Add(carrier);
                }
                ClearAppointmentCarrierDynamicFields(_appointmentList);
                foreach (AppointmentCarrier appointmentCarrier in _appointmentList)
                {
                    if (ProcedureSpeciality != null)
                    {
                        string resources = "";
                        foreach (ResourceSpecialityGrid rSpeciality in ProcedureSpeciality.ResourceSpecialities)
                        {
                            if (resources == "")
                            {
                                resources = "'" + rSpeciality.Resource.ObjectID.ToString() + "'";
                            }
                            else
                            {
                                resources = resources + ",'" + rSpeciality.Resource.ObjectID.ToString() + "'";
                            }
                        }
                        appointmentCarrier.MasterResourceFilter = " OBJECTID IN (" + resources + ")";
                    }
                    else
                    {
                        appointmentCarrier.MasterResourceFilter = "";
                    }
                    break;
                }
                return _appointmentList;

            }
        }

        #region IAppointmentDef Members
        public List<AppointmentCarrier> GetAppointmentCarrierList()
        {
            return AppointmentCarrierList;
        }
        #endregion

        public DentalTreatmentProcedure(TTObjectContext objectContext, DentalTreatmentRequestSuggestedTreatment dentalTreatmentRequestSuggestedTreatment) : this(objectContext)
        {
            CurrentStateDefID = DentalTreatmentProcedure.States.TreatmentProcedure;
            //YAPILACAKLAR// Appointment Yapıldığında Appointment zamanı atanacak//YAPILDI..yilmaz
            ActionDate = Common.RecTime();
            //this.Cancelled = false;
            //YAPILACAKLAR// ID set edililecek
            //this.ID = 44546;
            //this.ID.GetNextValue();
            SuggestedTreatment = dentalTreatmentRequestSuggestedTreatment;
            MasterResource = dentalTreatmentRequestSuggestedTreatment.Department;
            FromResource = dentalTreatmentRequestSuggestedTreatment.DentalTreatmentRequest.FromResource;
            Emergency = dentalTreatmentRequestSuggestedTreatment.Emergency;
            DentalRequestType = dentalTreatmentRequestSuggestedTreatment.DentalRequestType;
            ProcedureObject = dentalTreatmentRequestSuggestedTreatment.SuggestedTreatmentProcedure;
            ToothNumber = dentalTreatmentRequestSuggestedTreatment.ToothNumber;
            DentalPosition = dentalTreatmentRequestSuggestedTreatment.DentalPosition;
            ProcedureDepartment = dentalTreatmentRequestSuggestedTreatment.Department;
            Episode = dentalTreatmentRequestSuggestedTreatment.DentalTreatmentRequest.Episode;
        }
        public void IfLastCompletedProcedureCompleteRequest()
        {
            //Post form yada object post scriptlerinde kullanılmalı
            if (CurrentStateDef.Status == StateStatusEnum.CompletedSuccessfully || CurrentStateDef.Status == StateStatusEnum.CompletedUnsuccessfully || CurrentStateDef.Status == StateStatusEnum.Cancelled)
            {
                bool found = false;
                if (DentalTreatmentRequest != null)
                {
                    foreach (DentalTreatmentProcedure siblingProcedure in DentalTreatmentRequest.DentalTreatments)
                    {
                        if (siblingProcedure != this && siblingProcedure.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                        {
                            found = true;
                        }
                    }

                    if (found == false)
                    {
                        //YAPILACAKLAR// Advancestep olduğunda this.DentalProsthesisRequest complete stepine geçirilecek//YAPILDI..yilmaz
                        DentalTreatmentRequest.CurrentStateDefID = DentalTreatmentRequest.States.Completed;
                    }
                }
            }
        }

        public override string GetDVOAnomali()
        {
            return Anomali == true ? "E" : "H";
        }

        //public override string GetDVOAyniFarkliKesi()
        //{
        //    return AyniFarkliKesi?.ayniFarkliKesiKodu;
        //}

        public override int? GetDVODisTaahhutNo()
        {
            return DisTaahhutNo;
        }

        public override void GetDVOSetCeneBilgisi(HizmetKayitIslemleri.disBilgisiDVO disBilgisiDVO)
        {
            List<int> listEriskin = new List<int>();
            List<int> listSut = new List<int>();
            List<int> listAnomali = new List<int>();
            List<int> listCene = new List<int>();
            
            foreach (BaseDentalSubactionProcedureDiagnosisGrid dp in Diagnosis) // Ön tanılar
            {
                if (Convert.ToInt32(dp.ToothNumber.Value) >= 11 && Convert.ToInt32(dp.ToothNumber.Value) <= 48)
                    listEriskin.Add(Convert.ToInt32(dp.ToothNumber.Value));
                else if (Convert.ToInt32(dp.ToothNumber.Value) >= 51 && Convert.ToInt32(dp.ToothNumber.Value) <= 85)
                    listSut.Add(Convert.ToInt32(dp.ToothNumber.Value));
                else if (Convert.ToInt32(dp.ToothNumber.Value) >= 91 && Convert.ToInt32(dp.ToothNumber.Value) <= 94)
                    listAnomali.Add(Convert.ToInt32(dp.ToothNumber.Value));
                else if (Convert.ToInt32(dp.ToothNumber.Value) >= 1 && Convert.ToInt32(dp.ToothNumber.Value) <= 7)
                    listCene.Add(Convert.ToInt32(dp.ToothNumber.Value));
            }

            if (ToothNumber != null)
            {
                if (Convert.ToInt32(ToothNumber.Value) >= 11 && Convert.ToInt32(ToothNumber.Value) <= 48)
                    listEriskin.Add(Convert.ToInt32(ToothNumber.Value));
                else if (Convert.ToInt32(ToothNumber.Value) >= 51 && Convert.ToInt32(ToothNumber.Value) <= 85)
                    listSut.Add(Convert.ToInt32(ToothNumber.Value));
                else if (Convert.ToInt32(ToothNumber.Value) >= 91 && Convert.ToInt32(ToothNumber.Value) <= 94)
                    listAnomali.Add(Convert.ToInt32(ToothNumber.Value));
                else if (Convert.ToInt32(ToothNumber.Value) >= 1 && Convert.ToInt32(ToothNumber.Value) <= 7)
                    listCene.Add(Convert.ToInt32(ToothNumber.Value));
            }

            setEriskinDisler(listEriskin.ToArray(), disBilgisiDVO);
            setSutDisler(listSut.ToArray(), disBilgisiDVO);
            setAnomaliDisler(listAnomali.ToArray(), disBilgisiDVO);
            setCeneDisler(listCene.ToArray(), disBilgisiDVO);
        }

        //Tuğba:  Erişkin dişlerin string scheması oluşturulur.
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

        //Tuğba:  Süt dişlerin string scheması oluşturulur.
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

        //Tuğba:  Anomalili dişlerin string scheması oluşturulur.
        public void setAnomaliDisler(int[] str, HizmetKayitIslemleri.disBilgisiDVO disBilgisiDVO)
        {
            String[] aDis = new String[4];

            disBilgisiDVO.sagUstCeneAnomaliDis = "";//91
            disBilgisiDVO.solUstCeneAnomaliDis = "";//92
            disBilgisiDVO.sagAltCeneAnomaliDis = "";//93
            disBilgisiDVO.solAltCeneAnomaliDis = "";//94


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



        //Tuğba: Tüm,sağ,sol,üst,alt çene string scheması oluşturulur.
        public void setCeneDisler(int[] str, HizmetKayitIslemleri.disBilgisiDVO disBilgisiDVO)
        {


            for (int j = 0; j < str.Length; j++)
            {

                if (str[j] == 1)
                {  //Tüm Çene
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
                {  //Ãœst Çene
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
                {  //Alt Çene
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
                {  //Sağ Ãœst Çene
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
                {  //Sol Ãœst Çene
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
                {  //Sağ Alt Çene
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
                {  //Sol Alt Çene
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

        #endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DentalTreatmentProcedure).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DentalTreatmentProcedure.States.Appointment && toState == DentalTreatmentProcedure.States.TreatmentProcedure)
                PostTransition_Appointment2TreatmentProcedure();
            else if (fromState == DentalTreatmentProcedure.States.Appointment && toState == DentalTreatmentProcedure.States.Cancelled)
                PostTransition_Appointment2Cancelled();
            else if (fromState == DentalTreatmentProcedure.States.Completed && toState == DentalTreatmentProcedure.States.Cancelled)
                PostTransition_Completed2Cancelled();
            else if (fromState == DentalTreatmentProcedure.States.TreatmentProcedure && toState == DentalTreatmentProcedure.States.Cancelled)
                PostTransition_TreatmentProcedure2Cancelled();
            else if (fromState == DentalTreatmentProcedure.States.TreatmentProcedure && toState == DentalTreatmentProcedure.States.Rejected)
                PostTransition_TreatmentProcedure2Rejected();
            else if (fromState == DentalTreatmentProcedure.States.ApprovalTechnicanProcedure && toState == DentalTreatmentProcedure.States.Cancelled)
                PostTransition_ApprovalTechnicanProcedure2Cancelled();
            else if (fromState == DentalTreatmentProcedure.States.TechnicianProcedure && toState == DentalTreatmentProcedure.States.Cancelled)
                PostTransition_TechnicianProcedure2Cancelled();
            else if (fromState == DentalTreatmentProcedure.States.Rejected && toState == DentalTreatmentProcedure.States.Cancelled)
                PostTransition_Rejected2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DentalTreatmentProcedure).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DentalTreatmentProcedure.States.Appointment && toState == DentalTreatmentProcedure.States.Cancelled)
                UndoTransition_Appointment2Cancelled(transDef);
            else if (fromState == DentalTreatmentProcedure.States.Completed && toState == DentalTreatmentProcedure.States.Cancelled)
                UndoTransition_Completed2Cancelled(transDef);
            else if (fromState == DentalTreatmentProcedure.States.TreatmentProcedure && toState == DentalTreatmentProcedure.States.Appointment)
                UndoTransition_TreatmentProcedure2Appointment(transDef);
            else if (fromState == DentalTreatmentProcedure.States.TreatmentProcedure && toState == DentalTreatmentProcedure.States.Completed)
                UndoTransition_TreatmentProcedure2Completed(transDef);
            else if (fromState == DentalTreatmentProcedure.States.TreatmentProcedure && toState == DentalTreatmentProcedure.States.Cancelled)
                UndoTransition_TreatmentProcedure2Cancelled(transDef);
            else if (fromState == DentalTreatmentProcedure.States.TreatmentProcedure && toState == DentalTreatmentProcedure.States.Rejected)
                UndoTransition_TreatmentProcedure2Rejected(transDef);
            else if (fromState == DentalTreatmentProcedure.States.ApprovalTechnicanProcedure && toState == DentalTreatmentProcedure.States.Completed)
                UndoTransition_ApprovalTechnicanProcedure2Completed(transDef);
            else if (fromState == DentalTreatmentProcedure.States.ApprovalTechnicanProcedure && toState == DentalTreatmentProcedure.States.Cancelled)
                UndoTransition_ApprovalTechnicanProcedure2Cancelled(transDef);
            else if (fromState == DentalTreatmentProcedure.States.TechnicianProcedure && toState == DentalTreatmentProcedure.States.Appointment)
                UndoTransition_TechnicianProcedure2Appointment(transDef);
            else if (fromState == DentalTreatmentProcedure.States.TechnicianProcedure && toState == DentalTreatmentProcedure.States.Cancelled)
                UndoTransition_TechnicianProcedure2Cancelled(transDef);
            else if (fromState == DentalTreatmentProcedure.States.Rejected && toState == DentalTreatmentProcedure.States.Cancelled)
                UndoTransition_Rejected2Cancelled(transDef);
        }

    }
}