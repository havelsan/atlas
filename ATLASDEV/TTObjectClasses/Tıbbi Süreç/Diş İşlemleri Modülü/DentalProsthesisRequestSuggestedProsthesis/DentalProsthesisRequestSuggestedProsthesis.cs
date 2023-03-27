
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
    public  partial class DentalProsthesisRequestSuggestedProsthesis : TTObject
    {
        public partial class OLAP_GetSuggestedDentalProsthesis_Class : TTReportNqlObject 
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
        /// <summary>
        /// DentalProsthesisRequest ya da DentalExamination tarafından SplitWithDepartmentsOfDentalProsthesis() ve FireDentalProsthesisRequestBySuggestedProsthesis() 'de yaratılırken kullanılacak  constract
        /// </summary>
        /// <param name="objectContext"></param>
        /// <param name="suggestedTreatment"></param>
        public DentalProsthesisRequestSuggestedProsthesis(TTObjectContext objectContext,DentalProsthesisRequestSuggestedProsthesis suggestedProsthesis):this(objectContext)
        {
            
            Definition = suggestedProsthesis.Definition;
            DentalPosition = suggestedProsthesis.DentalPosition;
            Department = suggestedProsthesis.Department;
//            this.AddToHistory = suggestedProsthesis.AddToHistory;
//            this.Diagnose = suggestedProsthesis.Diagnose;
//            this.DiagnoseDate = suggestedProsthesis.DiagnoseDate;
//            this.DiagnosisType = suggestedProsthesis.DiagnosisType;
//            this.ResponsibleUser = suggestedProsthesis.ResponsibleUser;
//            this.IsMainDiagnose = suggestedProsthesis.IsMainDiagnose;
            Emergency = suggestedProsthesis.Emergency;
            ToothNumber = suggestedProsthesis.ToothNumber;
            SuggestedProsthesisProcedure = suggestedProsthesis.SuggestedProsthesisProcedure;
        }
        
#endregion Methods

    }
}