
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
    /// Hasta Grup Tanımı
    /// </summary>
    public  partial class PatientGroupDefinition : TerminologyManagerDef
    {
        public partial class GetPatientGroupDefinition_Class : TTReportNqlObject 
        {
        }

        public partial class GetPatientGroupDefinitionID_Class : TTReportNqlObject 
        {
        }

        public partial class GetPatientGroupDefHC_Class : TTReportNqlObject 
        {
        }

#region Methods
        public bool IsSuitablePatientMedulaHastaKabul(PatientMedulaHastaKabul patientMedulaHastaKabul)
        {
            if (MedulaTedaviTuru != null)
            {
                if (MedulaTedaviTuru != patientMedulaHastaKabul.BaseHastaKabul.provizyonGirisDVO.tedaviTuru)
                    return false;

            }
            if (MedulaTedaviTipi != null)
            {
                if (MedulaTedaviTipi != patientMedulaHastaKabul.BaseHastaKabul.provizyonGirisDVO.tedaviTipi)
                    return false;
            }
            if (MedulaProvizyonTipi != null)
            {
                if (MedulaProvizyonTipi != patientMedulaHastaKabul.BaseHastaKabul.provizyonGirisDVO.provizyonTipi)
                    return false;
            }
            if (MedulaSigortaliTuru != null)
            {
                if (MedulaSigortaliTuru != patientMedulaHastaKabul.BaseHastaKabul.provizyonGirisDVO.sigortaliTuru)
                    return false;
            }
            if (MedulaTakipTipi != null)
            {
                if (MedulaTakipTipi != patientMedulaHastaKabul.BaseHastaKabul.provizyonGirisDVO.takipTipi)
                    return false;
            }
            if (MedulaDevredilenKurum != null)
            {
                if (MedulaDevredilenKurum != patientMedulaHastaKabul.BaseHastaKabul.provizyonGirisDVO.devredilenKurum)
                    return false;
            }
            return true;
        }

        public String GetMedulaRequirementsString()
        {
            string emptyErrorString = "";
            if (MedulaTedaviTuru != null)
                emptyErrorString += "'" + TedaviTuru.GetTedaviTuru(MedulaTedaviTuru.ToString()).tedaviTuruAdi + "' Tedavi Türünde, ";

            if (MedulaTedaviTipi != null)
                emptyErrorString += "'" + TedaviTipi.GetTedaviTipi(MedulaTedaviTipi.ToString()).tedaviTipiAdi + "' Tedavi Tipinde, ";

            if (MedulaProvizyonTipi != null)
                emptyErrorString += "'" + ProvizyonTipi.GetProvizyonTipi(MedulaProvizyonTipi.ToString()).provizyonTipiAdi + "' Provizyon Tipinde, ";

            if (MedulaSigortaliTuru != null)
                emptyErrorString += "'" + SigortaliTuru.GetSigortaliTuru(MedulaSigortaliTuru.ToString()).sigortaliTuruAdi + "' Sigortalı Türünde, ";

            if (MedulaTakipTipi != null)
                emptyErrorString += "'" + TakipTipi.GetTakipTipi(MedulaTakipTipi.ToString()).takipTipiAdi + "' Takip Tipinde, ";

            if (MedulaDevredilenKurum != null)
                emptyErrorString += "'" + DevredilenKurum.GetDevredilenKurum(MedulaDevredilenKurum.ToString()).devredilenKurumAdi + "' Tedavi Türünde, ";

            if (!String.IsNullOrEmpty(emptyErrorString))
                emptyErrorString = "Bu hasta grubu için " + emptyErrorString + " Medula Hasta Kabulü yapılmış olması gerekmektedir.";
            return emptyErrorString;
        }
        
        public override SendDataTypesEnum?  GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.PatientGroupDefinitionInfo;
        }
        
        public override List<string> GetMyLocalPropertyNamesList()
        {
            List<string> localPropertyNamesList = new List<string>();
            return localPropertyNamesList;
        }
        
        private static BindingList<PatientGroupDefinition> _AllPatientGroupDefinitions;
        public static BindingList<PatientGroupDefinition> AllPatientGroupDefinitions
        {
            get 
            { 
                if (_AllPatientGroupDefinitions == null)
                    _AllPatientGroupDefinitions = PatientGroupDefinition.GetAll(new TTObjectContext(true));
                return _AllPatientGroupDefinitions;
            }
        }
        
#endregion Methods

    }
}