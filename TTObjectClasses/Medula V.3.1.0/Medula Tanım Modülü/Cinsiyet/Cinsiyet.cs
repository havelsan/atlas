
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
    /// Cinsiyet
    /// </summary>
    public  partial class Cinsiyet : BaseMedulaDefinition
    {
        public partial class GetCinsiyetDefinitionQuery_Class : TTReportNqlObject 
        {
        }

#region Methods
        public static Cinsiyet GetCinsiyet(string cinsiyetKodu)
        {
            Cinsiyet retValue = null;
            if (string.IsNullOrEmpty(cinsiyetKodu) == false)
                _allCinsiyet.TryGetValue(cinsiyetKodu, out retValue);
            return retValue;
        }

        private static Dictionary<string, Cinsiyet> _allCinsiyet;

        static Cinsiyet()
        {
            TTObjectContext context = new TTObjectContext(true);
            _allCinsiyet = new Dictionary<string, Cinsiyet>();
            foreach (Cinsiyet cinsiyet in context.QueryObjects<Cinsiyet>())
                _allCinsiyet.Add(cinsiyet.cinsiyetKodu, cinsiyet);
        }

        public override string ToString()
        {
            return cinsiyetKodu + " : " + cinsiyetAdi;
        }
        
#endregion Methods

    }
}