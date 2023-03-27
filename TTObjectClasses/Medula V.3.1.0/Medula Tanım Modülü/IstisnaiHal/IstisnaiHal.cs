
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
    /// İstisnai Hal Tanımları
    /// </summary>
    public partial class IstisnaiHal : TerminologyManagerDef
    {
        public partial class IstisnaiHalDefinitionQuery_Class : TTReportNqlObject
        {
        }

        #region Methods
        public static IstisnaiHal GetIstisnaiHal(string kodu)
        {
            IstisnaiHal retValue = null;
            if (string.IsNullOrEmpty(kodu) == false)
                _allIstisnaiHal.TryGetValue(kodu, out retValue);
            return retValue;
        }

        private static Dictionary<string, IstisnaiHal> _allIstisnaiHal;

        static IstisnaiHal()
        {
            TTObjectContext context = new TTObjectContext(true);
            _allIstisnaiHal = new Dictionary<string, IstisnaiHal>();
            foreach (IstisnaiHal istisnaiHal in context.QueryObjects<IstisnaiHal>())
                _allIstisnaiHal.Add(istisnaiHal.Kodu, istisnaiHal);
        }

        public override string ToString()
        {
            return Kodu + " : " + Adi;
        }

        #endregion Methods
    }
}