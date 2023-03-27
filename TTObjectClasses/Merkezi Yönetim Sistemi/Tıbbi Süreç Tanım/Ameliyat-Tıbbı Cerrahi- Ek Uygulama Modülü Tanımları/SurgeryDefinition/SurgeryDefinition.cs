
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
    /// Ameliyat-Tıbbı Cerrahi- Ek Uygulama Tanımlama
    /// </summary>
    public partial class SurgeryDefinition : ProcedureDefinition, IProcedureRequestDefinition
    {
        public partial class GetSurgeryDefinition_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetSurgeryDefinition_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetSurgeryDefinition_WithDate_Class : TTReportNqlObject
        {
        }

        #region Methods

        #region IProcedureRequestDefinition Members
        public String GetMyCategoryName()
        {
            return MyCategoryName;
        }

        public String GetMyFiredActionDefName()
        {
            return MyFiredActionDefName;
        }

        public bool GetIsProcedureFlowStarts()
        {
            return IsProcedureFlowStarts;
        }

        public Guid GetMyStartedStateDefID()
        {
            return MyStartedStateDefID;
        }
        #endregion
        public override SendDataTypesEnum? GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.SurgeryProcedureDefinitionInfo;
        }

        public override void SetProcedureType()
        {
            if (SurgeryProcedureType == SurgeyProcedureTypeEnum.OnlyAdditionalApplication || SurgeryProcedureType == SurgeyProcedureTypeEnum.ManipulationAdditionalApplication)
                ProcedureType = ProcedureDefGroupEnum.digerIslemBilgileri;//Ek uygulama
            else if (SurgeryProcedureType == SurgeyProcedureTypeEnum.OnlyManipulation || SurgeryProcedureType == SurgeyProcedureTypeEnum.OnlySurgery || SurgeryProcedureType == SurgeyProcedureTypeEnum.SurgeryAndManiplation )
                ProcedureType = ProcedureDefGroupEnum.ameliyatveGirisimBilgileri;//ameliyat
        }


        public Guid MyStartedStateDefID
        {
            get
            {
                return (Guid)Manipulation.States.RequestAcception;
            }
        }

        public string MyCategoryName
        {
            get
            {
                return null;
            }
        }

        public string MyFiredActionDefName
        {
            get
            {
                return "Manipulation";
            }
        }

        public bool IsProcedureFlowStarts
        {
            get
            {
                //SurgeryProcedureType i 3 veya 4 olanlar icin flow baslatilmayacak
                if (SurgeryProcedureType == SurgeyProcedureTypeEnum.OnlyAdditionalApplication || SurgeryProcedureType == SurgeyProcedureTypeEnum.ManipulationAdditionalApplication)
                    return false;
                else
                    return true;
            }
        }

        public EpisodeAction CreateMyEpisodeAction(EpisodeAction starterEA, ResSection masterRes, ResSection fromRes, bool setMasterAction, bool emergency, DateTime requestDate, Guid procedureUser, bool fromPatientAdmission)
        {
            ManipulationRequest manipulationRequest = (ManipulationRequest)ObjectContext.CreateObject("ManipulationRequest");
            manipulationRequest.CurrentStateDefID = ManipulationRequest.States.Request;
            manipulationRequest.ActionDate = requestDate;
            manipulationRequest.RequestDate = requestDate;
            manipulationRequest.WorkListDate = requestDate;
            manipulationRequest.MasterAction = (BaseAction)starterEA;
            manipulationRequest.SetMandatoryEpisodeActionProperties(starterEA, masterRes, fromRes, setMasterAction);
            manipulationRequest.Update();


            Manipulation manipulation = (Manipulation)ObjectContext.CreateObject("Manipulation");
            manipulation.CurrentStateDefID = Manipulation.States.RequestAcception;
            manipulation.ActionDate = requestDate;
            manipulation.RequestDate = requestDate;
            manipulation.WorkListDate = requestDate;
            manipulation.RequestedByUser = Common.CurrentResource;
            manipulation.MasterAction = (BaseAction)starterEA;

            if (emergency == true)
                manipulation.Emergency = emergency;

            manipulation.SetMandatoryEpisodeActionProperties(starterEA, masterRes, fromRes, setMasterAction);
            if (!fromPatientAdmission)
                manipulation.Update();

            manipulationRequest.Manipulations.Add(manipulation);
            if (!fromPatientAdmission)// hasta kabulden başlatılan Maniplasyonların REquestleri Tamamlandıya çekilemiyor Çünkü Hasta  kabulde bunlar başladığında henüz subepisode hazır değil ve update kodu patlatıyor 
            {
                manipulationRequest.CurrentStateDefID = ManipulationRequest.States.Completed;
                manipulationRequest.Update();
            }

            return (EpisodeAction)manipulation;
        }

        public SubActionProcedure CreateMySubactionProcedure(EpisodeAction ea, ResSection masterRes, ResSection fromRes)
        {
            Manipulation manipulation = (Manipulation)ea;
            ManipulationProcedure manipulationProcedure = (ManipulationProcedure)ObjectContext.CreateObject("ManipulationProcedure");
            SurgeryDefinition surgeryDefinition = (SurgeryDefinition)this;

            manipulationProcedure.ProcedureObject = this;
            manipulationProcedure.EpisodeAction = manipulation;
            manipulationProcedure.ProcedureDepartment = manipulation.MasterResource;
            manipulationProcedure.CreationDate = manipulation.RequestDate;
            manipulationProcedure.ActionDate = manipulation.RequestDate;
            manipulationProcedure.RequestedByUser = manipulation.RequestedByUser;
            manipulationProcedure.CurrentStateDefID = ManipulationProcedure.States.New;

            if (ea.Emergency == true)
                manipulationProcedure.Emergency = true;

            manipulation.SubactionProcedures.Add(manipulationProcedure);

            return (SubActionProcedure)manipulationProcedure;
        }

        public ActionTypeEnum? GetActionTypeEnum()
        {
            return null;
        }

        public string GetMyAlertMessage(Guid eaObjectId)
        {
            return null;
        }

        #endregion Methods

    }
}