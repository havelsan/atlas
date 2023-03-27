
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
    /// XXXXXX
    /// </summary>
    public  partial class ResHospital : ResSection
    {
        public partial class OLAP_ResHospital_Class : TTReportNqlObject 
        {
        }

        public partial class VEM_BINA_Class : TTReportNqlObject 
        {
        }

#region Methods
        public static string ApprovalSignatureBlock
        {
            get
            {
                string signatureBlock = "";
                if (TTObjectClasses.SystemParameter.GetParameterValue("ShowHeadDoctorApproveBlockInReport","TRUE") != "FALSE")
                {
                    if (TTObjectClasses.SystemParameter.GetParameterValue("REPORTAPPROVALPOSITION","HEADDOCTOR") == "IITABIP")
                    {
                        signatureBlock += TTObjectClasses.SystemParameter.GetParameterValue("IITABIP","").ToString() + "\n\r";
                        signatureBlock += TTObjectClasses.SystemParameter.GetParameterValue("IITABIPUNVANI","").ToString() + "\n\r";
                        signatureBlock += TTObjectClasses.SystemParameter.GetParameterValue("IITABIPDURUM",TTUtils.CultureService.GetText("M25987", "II.Tabip")).ToString() + "\n\r";
                         
                    }
                    else
                    {
                        signatureBlock += TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTOR","").ToString() + "\n\r";
                        signatureBlock += TTObjectClasses.SystemParameter.GetParameterValue("HEADDOCTORTITAL","").ToString() + "\n\r";
                        signatureBlock += TTUtils.CultureService.GetText("M25255", "Baştabip");
                    }
                }
                return (string)signatureBlock;
            }
        }
        
#endregion Methods

    }
}