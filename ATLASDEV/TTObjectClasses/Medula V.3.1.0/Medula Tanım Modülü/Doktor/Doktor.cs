
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
    /// Doktor
    /// </summary>
    public  partial class Doktor : BaseMedulaDefinition
    {
        public partial class GetDoktorDefinitionQuery_Class : TTReportNqlObject 
        {
        }

#region Methods
        public static Doktor GetDoktor(string tescilNo)
        {
            Doktor retValue = null;
            if (string.IsNullOrEmpty(tescilNo) == false)
                _allDoktor.TryGetValue(tescilNo, out retValue);
            return retValue;
        }

        private static Dictionary<string, Doktor> _allDoktor;

        static Doktor()
        {
            TTObjectContext context = new TTObjectContext(true);
            _allDoktor = new Dictionary<string, Doktor>();
            foreach (Doktor doktor in context.QueryObjects<Doktor>())
                _allDoktor.Add(doktor.drTescilNo, doktor);
        }

        public override string ToString()
        {
            return drTescilNo + " : " + drAdi + " " + drSoyadi;
        }
        
#endregion Methods

    }
}