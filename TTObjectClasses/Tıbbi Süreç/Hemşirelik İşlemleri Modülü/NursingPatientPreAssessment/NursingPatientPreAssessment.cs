
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
    /// Hemşirelik Hizmetleri Hasta Ön Değerlendirmesi
    /// </summary>
    public  partial class NursingPatientPreAssessment : BaseNursingDataEntry
    {
        public override string GetApplicationSummary()
        {
            string tempString = "";
            tempString = "Hemşirelik Hizmetleri Hasta Ön Değerlendirme Formu";
            return tempString;
        }

        public override string GetRowColor()
        {
            return string.Empty;
        }
    }
}