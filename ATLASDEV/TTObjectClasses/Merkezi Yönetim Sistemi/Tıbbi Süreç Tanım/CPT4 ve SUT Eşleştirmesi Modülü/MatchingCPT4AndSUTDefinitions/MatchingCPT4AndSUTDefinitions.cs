
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
    /// CPT4 ve SUT eşleştirmesi
    /// </summary>
    public  partial class MatchingCPT4AndSUTDefinitions : TerminologyManagerDef
    {
        public partial class GetMatchingCPT4AndSUTDefinitions_Class : TTReportNqlObject 
        {
        }

        public string CPT4DefinitionDescription
        {
            get
            {
                try
                {
#region CPT4DefinitionDescription_GetScript                    
                    if(CPT4Definition != null)
                return CPT4Definition.CPTCode + " " + CPT4Definition.OriginalName;
            else
                return String.Empty;
#endregion CPT4DefinitionDescription_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "CPT4DefinitionDescription") + " : " + ex.Message, ex);
                }
            }
        }

        public string SUTDefinitionDescription
        {
            get
            {
                try
                {
#region SUTDefinitionDescription_GetScript                    
                    if(SUTDefinition != null)
                    return SUTDefinition.Code + " " + SUTDefinition.Name;
                else
                    return String.Empty;
#endregion SUTDefinitionDescription_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "SUTDefinitionDescription") + " : " + ex.Message, ex);
                }
            }
        }

#region Methods
        public override SendDataTypesEnum?  GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.MatchingCPT4AndSUTDefinitionsInfo;
        }
        
#endregion Methods

    }
}