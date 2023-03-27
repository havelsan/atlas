
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
    public  partial class DentalTreatmentRequestSuggestedTreatment : TTObject
    {
        public partial class OLAP_GetSuggestedDentalTreatments_Class : TTReportNqlObject 
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

            }
        }

#region Methods
        protected override void OnConstruct()
        {
            base.OnConstruct();
            if(((ITTObject)this).IsNew==true)
                CurrentStateDefID=DentalTreatmentRequestSuggestedTreatment.States.New;
        }
        
        /// <summary>
        /// DentalTreatmentRequest ya da DentalExamination tarafından SplitWithDepartmentsOfDentalTreatments() ve FireDentalProsthesisRequestBySuggestedTreatments() 'de yaratılırken kullanılacak  constract
        /// </summary>
        /// <param name="objectContext"></param>
        /// <param name="suggestedTreatment"></param>
        public DentalTreatmentRequestSuggestedTreatment(TTObjectContext objectContext,DentalTreatmentRequestSuggestedTreatment suggestedTreatment):this(objectContext)
        {
          
            Definition=suggestedTreatment.Definition;
            DentalPosition=suggestedTreatment.DentalPosition;
            DentalRequestType=suggestedTreatment.DentalRequestType;
            Department=suggestedTreatment.Department;
//            this.AddToHistory=suggestedTreatment.AddToHistory;
//            this.Diagnose=suggestedTreatment.Diagnose;
//            this.DiagnoseDate=suggestedTreatment.DiagnoseDate;
//            this.DiagnosisType=suggestedTreatment.DiagnosisType;
//            this.IsMainDiagnose=suggestedTreatment.IsMainDiagnose;
//            this.ResponsibleUser=suggestedTreatment.ResponsibleUser;
            Emergency=suggestedTreatment.Emergency;
            ToothNumber=suggestedTreatment.ToothNumber;

            SuggestedTreatmentProcedure=suggestedTreatment.SuggestedTreatmentProcedure;
        }
        
#endregion Methods

    }
}