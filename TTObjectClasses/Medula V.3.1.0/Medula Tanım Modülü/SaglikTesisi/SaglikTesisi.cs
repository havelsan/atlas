
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
    /// Sağlık Tesisi
    /// </summary>
    public  partial class SaglikTesisi : BaseMedulaDefinition
    {
        public partial class GetSaglikTesisiDefinitionQuery_Class : TTReportNqlObject 
        {
        }

        public partial class SAGLIKTESISLERIReportQuery_Class : TTReportNqlObject 
        {
        }

#region Methods
        private static Dictionary<int, SaglikTesisi> _allSaglikTesisi;
        public static Dictionary<int, SaglikTesisi> AllSaglikTesisi
        {
            get { return _allSaglikTesisi;}
        }

        public static SaglikTesisi GetSaglikTesisi(int tesisKodu)
        {
            SaglikTesisi saglikTesisi = null;
            if (tesisKodu > 0)
                _allSaglikTesisi.TryGetValue(tesisKodu, out saglikTesisi);
            return saglikTesisi;
        }

        static SaglikTesisi()
        {
            TTObjectContext context = new TTObjectContext(true);
            _allSaglikTesisi = new Dictionary<int, SaglikTesisi>();
            foreach (SaglikTesisi saglikTesisi in context.QueryObjects<SaglikTesisi>())
                _allSaglikTesisi.Add(saglikTesisi.tesisKodu.Value, saglikTesisi);
        }
        
        public override string ToString()
        {
            return tesisKodu + "  " + tesisAdi;
        }
        
#endregion Methods

    }
}