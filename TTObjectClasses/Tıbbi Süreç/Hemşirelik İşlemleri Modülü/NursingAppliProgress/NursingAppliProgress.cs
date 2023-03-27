
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
    /// Hemşire Güncesi Sekmesi
    /// </summary>
    public  partial class NursingAppliProgress : BaseNursingDataEntry
    {
        public partial class GetNursingApplicationProgress_Class : TTReportNqlObject 
        {
        }


        public override string GetApplicationSummary()
        {
            string _tempStr = Description;
            if (HandOverNote == true)
                _tempStr = "Devir Teslim Notu : " + Description;
            return _tempStr == null ? string.Empty : _tempStr.Length > 100 ? _tempStr.Substring(0, 100) : _tempStr;
        }

        public override string GetRowColor()
        {
            return HandOverNote == true? "#F06767" : string.Empty;
        }
    }
}