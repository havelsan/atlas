
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
    public  partial class DiagnosisCondition : RuleConditionBase
    {
#region Methods
        public bool IsSuitable(List<ISUTInstance> sutDiagnosisGrid)
        {
            switch ((int)OperatorType)
            {
                case (int)OperatorTypeEnum.Equal:
                    return ExistDiagnose(sutDiagnosisGrid);
                case (int)OperatorTypeEnum.NotEqual:
                    return !ExistDiagnose(sutDiagnosisGrid);
                default:
                    return false;
            }
        }

        private bool ExistDiagnose(List<ISUTInstance> sutDiagnosisGrid)
        {
            foreach (ISUTInstance sutDiagnosisGrid2 in sutDiagnosisGrid)
                if (Diagnosis.ObjectID == sutDiagnosisGrid2.GetSUTRulableObject().GetObjectID())
                    return true;
            return false;
        }
        
#endregion Methods

    }
}