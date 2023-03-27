
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
    /// Sigortalı Türü
    /// </summary>
    public  partial class SigortaliTuru : BaseMedulaDefinition
    {
        public partial class GetSigortaliTuruDefinitionQuery_Class : TTReportNqlObject 
        {
        }

#region Methods
        public static SigortaliTuru GetSigortaliTuru(string sigortaliTuruKodu)
        {
            SigortaliTuru retValue = null;
            if (string.IsNullOrEmpty(sigortaliTuruKodu) == false)
                _allSigortaliTuru.TryGetValue(sigortaliTuruKodu, out retValue);
            return retValue;
        }

        private static Dictionary<string, SigortaliTuru> _allSigortaliTuru;

        static SigortaliTuru()
        {
            TTObjectContext context = new TTObjectContext(true);
            _allSigortaliTuru = new Dictionary<string, SigortaliTuru>();
            foreach (SigortaliTuru sigortaliTuru in context.QueryObjects<SigortaliTuru>())
                _allSigortaliTuru.Add(sigortaliTuru.sigortaliTuruKodu, sigortaliTuru);
        }

        public override string ToString()
        {
            return sigortaliTuruKodu + " : " + sigortaliTuruAdi;
        }
        
#endregion Methods

    }
}