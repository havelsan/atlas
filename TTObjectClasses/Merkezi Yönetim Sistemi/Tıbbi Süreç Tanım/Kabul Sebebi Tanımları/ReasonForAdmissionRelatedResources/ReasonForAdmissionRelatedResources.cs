
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
    public  partial class ReasonForAdmissionRelatedResources : TTObject
    {
        public bool? GetAppointmentQueueDefList
        {
            get
            {
                try
                {
#region GetAppointmentQueueDefList_GetScript                    
                    if(Resource != null)
                {
                    if (Resource is ResPoliclinic && ((ResPoliclinic)Resource).PatientCallSystemInUse == true)
                    {
                        if(TTObjectClasses.SystemParameter.GetParameterValue("UsePatientCallSystem", "TRUE").ToUpper() == "TRUE")
                            return true;
                    }
                }
                return false;
#endregion GetAppointmentQueueDefList_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "GetAppointmentQueueDefList") + " : " + ex.Message, ex);
                }
            }
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "ACTIONTYPE":
                    {
                        ActionTypeEnum? value = (ActionTypeEnum?)(int?)newValue;
#region ACTIONTYPE_SetScript
                        if(value!=null)
            {
                if(value == ActionTypeEnum.PatientExamination)
                    GetAuthorizeUserList=true;
            }
#endregion ACTIONTYPE_SetScript
                    }
                    break;
                case "REASONFORADMISSION":
                    {
                        ReasonForAdmission value = (ReasonForAdmission)newValue;
#region REASONFORADMISSION_SetParentScript
                        if(value!=null)
            ActionType=value.DefualtActionType;
#endregion REASONFORADMISSION_SetParentScript
                    }
                    break;

            }
        }

#region Methods
        /// <summary>
        /// ActionTypedan Seçilen Enum değerine karşılık gelen EpisodeAction Kullandığı SubactionProcedureleri bulup Adlarını String olarak döndürür
        /// <summary>
        public string GetProcedureDefinitionNames(){
            string procedureDefNames="";
            string objectDefName = ActionType.ToString().ToUpperInvariant();
            TTObjectDef objDef=null;
            TTObjectDefManager.Instance.ObjectDefs.TryGetValue(objectDefName,out objDef) ;
            if (objDef!=null){
                if (objDef.IsOfType(typeof(EpisodeAction).Name.ToUpperInvariant())){
                    foreach(TTObjectRelationSubtypeDef rSubType in objDef.AllChildRelationsSubtypeDefs){
                        if (rSubType.RelationDef.ParentObjectDef.IsOfType(typeof(EpisodeAction).Name.ToUpperInvariant()) && rSubType.RelationDef.ChildObjectDef.IsOfType(typeof(SubActionProcedure).Name.ToUpperInvariant()))
                        {
                            if(rSubType.ChildObjectDef.AllParentRelationDefs["ProcedureObject"].ParentObjectDef.Name.ToUpperInvariant()!="PROCEDUREDEFINITION")
                            {
                                if(procedureDefNames!="")
                                    procedureDefNames=procedureDefNames + "," ;
                                procedureDefNames = procedureDefNames + "'" + rSubType.ChildObjectDef.AllParentRelationDefs["ProcedureObject"].ParentObjectDef.Name.ToUpperInvariant() + "'";
                            }
                            foreach(TTRelationParentRestrictions parentRestriction in rSubType.ChildObjectDef.ParentRelationRestrictions){
                                if(parentRestriction.RelationDef.ParentObjectDef.IsOfType(typeof(ProcedureDefinition).Name.ToUpperInvariant()))
                                {
                                    foreach(TTObjectDef restrictedObject in  parentRestriction.RestrictedObjectDefs)
                                    {
                                        if(procedureDefNames!="")
                                            procedureDefNames=procedureDefNames + "," ;
                                        procedureDefNames = procedureDefNames + "'" + restrictedObject.Name.ToUpperInvariant() + "'";
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return procedureDefNames;
        }
        
#endregion Methods

    }
}