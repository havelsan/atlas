
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
    /// Diş Protez Prosedür
    /// </summary>
    public partial class DentalProsthesisProcedure : BaseDentalProsthesis, IWorkListEpisodeAction, ITreatmentMaterialCollection
    {
        public partial class DentalProthesisPrintOutSQL_Class : TTReportNqlObject
        {
        }

        public partial class DentalProthesisProcedureNQL_Class : TTReportNqlObject
        {
        }

        public partial class VEM_DISPROTEZ_Class : TTReportNqlObject
        {
        }

        public partial class VEM_DISPROTEZ_DETAY_Class : TTReportNqlObject
        {
        }

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

        protected void UndoTransition_OuterLabResultApproval2OuterLabCompleted(TTObjectStateTransitionDef transitionDef)
        {
            // From State : OuterLabResultApproval   To State : OuterLabCompleted
            #region UndoTransition_OuterLabResultApproval2OuterLabCompleted
            if (DentalProsthesisRequest.CurrentStateDefID == DentalProsthesisRequest.States.Completed)
                ((ITTObject)DentalProsthesisRequest).UndoLastTransition();
            #endregion UndoTransition_OuterLabResultApproval2OuterLabCompleted
        }

        protected void PostTransition_OuterLabResultApproval2Cancelled()
        {
            // From State : OuterLabResultApproval   To State : Cancelled
            #region PostTransition_OuterLabResultApproval2Cancelled
            Cancel();
            #endregion PostTransition_OuterLabResultApproval2Cancelled
        }

        protected void UndoTransition_OuterLabResultApproval2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : OuterLabResultApproval   To State : Cancelled
            #region UndoTransition_OuterLabResultApproval2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_OuterLabResultApproval2Cancelled
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

        protected void PostTransition_OuterLabCompleted2Cancelled()
        {
            // From State : OuterLabCompleted   To State : Cancelled
            #region PostTransition_OuterLabCompleted2Cancelled
            Cancel();
            #endregion PostTransition_OuterLabCompleted2Cancelled
        }

        protected void UndoTransition_OuterLabCompleted2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : OuterLabCompleted   To State : Cancelled
            #region UndoTransition_OuterLabCompleted2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_OuterLabCompleted2Cancelled
        }

        protected void UndoTransition_ApprovalTechnicanProcedure2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : ApprovalTechnicanProcedure   To State : Completed
            #region UndoTransition_ApprovalTechnicanProcedure2Completed
            if (DentalProsthesisRequest.CurrentStateDefID == DentalProsthesisRequest.States.Completed)
                ((ITTObject)DentalProsthesisRequest).UndoLastTransition();
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

        protected void PostTransition_ProtesisProcedure2Rejected()
        {
            // From State : ProtesisProcedure   To State : Rejected
            #region PostTransition_ProtesisProcedure2Rejected

            CancelMyAccountTransactions();
            #endregion PostTransition_ProtesisProcedure2Rejected
        }

        protected void UndoTransition_ProtesisProcedure2Rejected(TTObjectStateTransitionDef transitionDef)
        {
            // From State : ProtesisProcedure   To State : Rejected
            #region UndoTransition_ProtesisProcedure2Rejected

            if (DentalProsthesisRequest.CurrentStateDefID == DentalProsthesisRequest.States.Completed)
                ((ITTObject)DentalProsthesisRequest).UndoLastTransition();

            #endregion UndoTransition_ProtesisProcedure2Rejected
        }

        protected void PostTransition_ProtesisProcedure2Cancelled()
        {
            // From State : ProtesisProcedure   To State : Cancelled
            #region PostTransition_ProtesisProcedure2Cancelled
            Cancel();
            #endregion PostTransition_ProtesisProcedure2Cancelled
        }

        protected void UndoTransition_ProtesisProcedure2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : ProtesisProcedure   To State : Cancelled
            #region UndoTransition_ProtesisProcedure2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_ProtesisProcedure2Cancelled
        }

        protected void PostTransition_OuterLabResultEntry2Cancelled()
        {
            // From State : OuterLabResultEntry   To State : Cancelled
            #region PostTransition_OuterLabResultEntry2Cancelled
            Cancel();
            #endregion PostTransition_OuterLabResultEntry2Cancelled
        }

        protected void UndoTransition_OuterLabResultEntry2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : OuterLabResultEntry   To State : Cancelled
            #region UndoTransition_OuterLabResultEntry2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_OuterLabResultEntry2Cancelled
        }

        protected void PostTransition_OuterLabRequestApproval2Cancelled()
        {
            // From State : OuterLabRequestApproval   To State : Cancelled
            #region PostTransition_OuterLabRequestApproval2Cancelled
            Cancel();
            #endregion PostTransition_OuterLabRequestApproval2Cancelled
        }

        protected void UndoTransition_OuterLabRequestApproval2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : OuterLabRequestApproval   To State : Cancelled
            #region UndoTransition_OuterLabRequestApproval2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_OuterLabRequestApproval2Cancelled
        }

        protected void UndoTransition_ResultApproval2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : ResultApproval   To State : Completed
            #region UndoTransition_ResultApproval2Completed
            if (DentalProsthesisRequest.CurrentStateDefID == DentalProsthesisRequest.States.Completed)
                ((ITTObject)DentalProsthesisRequest).UndoLastTransition();
            #endregion UndoTransition_ResultApproval2Completed
        }

        protected void PostTransition_ResultApproval2Cancelled()
        {
            // From State : ResultApproval   To State : Cancelled
            #region PostTransition_ResultApproval2Cancelled
            Cancel();
            #endregion PostTransition_ResultApproval2Cancelled
        }

        protected void UndoTransition_ResultApproval2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : ResultApproval   To State : Cancelled
            #region UndoTransition_ResultApproval2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_ResultApproval2Cancelled
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

        #region Methods
        #region ITreatmentMaterialCollection Members
        public BaseTreatmentMaterial.ChildBaseTreatmentMaterialCollection GetTreatmentMaterials()
        {
            return TreatmentMaterials;
        }
        #endregion
        public DentalProsthesisProcedure(TTObjectContext objectContext, DentalProsthesisRequestSuggestedProsthesis dentalProsthesisRequestSuggestedProsthesis) : this(objectContext)
        {
            CurrentStateDefID = DentalProsthesisProcedure.States.ProtesisProcedure;
            //YAPILACAKLAR// Appointment Yapıldığında Appointment zamanı atılacak//yapıldı..yilmaz
            ActionDate = Common.RecTime();
            SuggestedProsthesis = dentalProsthesisRequestSuggestedProsthesis;
            MasterResource = dentalProsthesisRequestSuggestedProsthesis.Department;
            FromResource = dentalProsthesisRequestSuggestedProsthesis.DentalProthesisRequest.FromResource;
            Emergency = dentalProsthesisRequestSuggestedProsthesis.Emergency;
            ProcedureObject = dentalProsthesisRequestSuggestedProsthesis.SuggestedProsthesisProcedure;
            ToothNumber = dentalProsthesisRequestSuggestedProsthesis.ToothNumber;
            DentalPosition = dentalProsthesisRequestSuggestedProsthesis.DentalPosition;
            ProcedureDepartment = dentalProsthesisRequestSuggestedProsthesis.Department;
            Episode = dentalProsthesisRequestSuggestedProsthesis.DentalProthesisRequest.Episode;
            SecondaryMasterResource = dentalProsthesisRequestSuggestedProsthesis.Department;//Teknisyen Tedavi Birimi için protez işlemini yapan birim atılıyor
        }

        public void IfLastCompletedProcedureCompleteRequest()
        {
            //Post form yada object post scriptlerinde kullanılmalı
            if (CurrentStateDef.Status == StateStatusEnum.CompletedSuccessfully || CurrentStateDef.Status == StateStatusEnum.CompletedUnsuccessfully || CurrentStateDef.Status == StateStatusEnum.Cancelled)
            {
                bool found = false;
                if (DentalProsthesisRequest != null)
                {
                    foreach (DentalProsthesisProcedure siblingProcedure in DentalProsthesisRequest.DentalProsthesis)
                    {
                        if (siblingProcedure != this && siblingProcedure.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                        {
                            found = true;
                        }
                    }

                    if (found == false)
                    {
                        //YAPILACAKLAR//Advancestep olduğunda this.DentalProsthesisRequest complete stepine geçirilecek//YAPILDI..yilmaz
                        DentalProsthesisRequest.CurrentStateDefID = DentalProsthesisRequest.States.Completed;
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

            foreach (BaseDentalSubactionProcedureDiagnosisGrid dp in Diagnosis)
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

            //DentalProsthesis
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

        public override void SetPerformedDate()
        {
            if (CreationDate.HasValue)
            {
                PerformedDate = CreationDate.Value.AddMinutes(1);
            }
        }

        #endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DentalProsthesisProcedure).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DentalProsthesisProcedure.States.OuterLabResultApproval && toState == DentalProsthesisProcedure.States.Cancelled)
                PostTransition_OuterLabResultApproval2Cancelled();
            else if (fromState == DentalProsthesisProcedure.States.Completed && toState == DentalProsthesisProcedure.States.Cancelled)
                PostTransition_Completed2Cancelled();
            else if (fromState == DentalProsthesisProcedure.States.Rejected && toState == DentalProsthesisProcedure.States.Cancelled)
                PostTransition_Rejected2Cancelled();
            else if (fromState == DentalProsthesisProcedure.States.OuterLabCompleted && toState == DentalProsthesisProcedure.States.Cancelled)
                PostTransition_OuterLabCompleted2Cancelled();
            else if (fromState == DentalProsthesisProcedure.States.ApprovalTechnicanProcedure && toState == DentalProsthesisProcedure.States.Cancelled)
                PostTransition_ApprovalTechnicanProcedure2Cancelled();
            else if (fromState == DentalProsthesisProcedure.States.ProtesisProcedure && toState == DentalProsthesisProcedure.States.Rejected)
                PostTransition_ProtesisProcedure2Rejected();
            else if (fromState == DentalProsthesisProcedure.States.ProtesisProcedure && toState == DentalProsthesisProcedure.States.Cancelled)
                PostTransition_ProtesisProcedure2Cancelled();
            else if (fromState == DentalProsthesisProcedure.States.OuterLabResultEntry && toState == DentalProsthesisProcedure.States.Cancelled)
                PostTransition_OuterLabResultEntry2Cancelled();
            else if (fromState == DentalProsthesisProcedure.States.OuterLabRequestApproval && toState == DentalProsthesisProcedure.States.Cancelled)
                PostTransition_OuterLabRequestApproval2Cancelled();
            else if (fromState == DentalProsthesisProcedure.States.ResultApproval && toState == DentalProsthesisProcedure.States.Cancelled)
                PostTransition_ResultApproval2Cancelled();
            else if (fromState == DentalProsthesisProcedure.States.TechnicianProcedure && toState == DentalProsthesisProcedure.States.Cancelled)
                PostTransition_TechnicianProcedure2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DentalProsthesisProcedure).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DentalProsthesisProcedure.States.OuterLabResultApproval && toState == DentalProsthesisProcedure.States.OuterLabCompleted)
                UndoTransition_OuterLabResultApproval2OuterLabCompleted(transDef);
            else if (fromState == DentalProsthesisProcedure.States.OuterLabResultApproval && toState == DentalProsthesisProcedure.States.Cancelled)
                UndoTransition_OuterLabResultApproval2Cancelled(transDef);
            else if (fromState == DentalProsthesisProcedure.States.Completed && toState == DentalProsthesisProcedure.States.Cancelled)
                UndoTransition_Completed2Cancelled(transDef);
            else if (fromState == DentalProsthesisProcedure.States.Rejected && toState == DentalProsthesisProcedure.States.Cancelled)
                UndoTransition_Rejected2Cancelled(transDef);
            else if (fromState == DentalProsthesisProcedure.States.OuterLabCompleted && toState == DentalProsthesisProcedure.States.Cancelled)
                UndoTransition_OuterLabCompleted2Cancelled(transDef);
            else if (fromState == DentalProsthesisProcedure.States.ApprovalTechnicanProcedure && toState == DentalProsthesisProcedure.States.Completed)
                UndoTransition_ApprovalTechnicanProcedure2Completed(transDef);
            else if (fromState == DentalProsthesisProcedure.States.ApprovalTechnicanProcedure && toState == DentalProsthesisProcedure.States.Cancelled)
                UndoTransition_ApprovalTechnicanProcedure2Cancelled(transDef);
            else if (fromState == DentalProsthesisProcedure.States.ProtesisProcedure && toState == DentalProsthesisProcedure.States.Rejected)
                UndoTransition_ProtesisProcedure2Rejected(transDef);
            else if (fromState == DentalProsthesisProcedure.States.ProtesisProcedure && toState == DentalProsthesisProcedure.States.Cancelled)
                UndoTransition_ProtesisProcedure2Cancelled(transDef);
            else if (fromState == DentalProsthesisProcedure.States.OuterLabResultEntry && toState == DentalProsthesisProcedure.States.Cancelled)
                UndoTransition_OuterLabResultEntry2Cancelled(transDef);
            else if (fromState == DentalProsthesisProcedure.States.OuterLabRequestApproval && toState == DentalProsthesisProcedure.States.Cancelled)
                UndoTransition_OuterLabRequestApproval2Cancelled(transDef);
            else if (fromState == DentalProsthesisProcedure.States.ResultApproval && toState == DentalProsthesisProcedure.States.Completed)
                UndoTransition_ResultApproval2Completed(transDef);
            else if (fromState == DentalProsthesisProcedure.States.ResultApproval && toState == DentalProsthesisProcedure.States.Cancelled)
                UndoTransition_ResultApproval2Cancelled(transDef);
            else if (fromState == DentalProsthesisProcedure.States.TechnicianProcedure && toState == DentalProsthesisProcedure.States.Cancelled)
                UndoTransition_TechnicianProcedure2Cancelled(transDef);
        }

    }
}