
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
    /// Medula Hata Kodları
    /// </summary>
    public  partial class MedulaErrorCodeDefinition : TerminologyManagerDef
    {
        public partial class GetMedulaErrorCode_Class : TTReportNqlObject 
        {
        }

#region Methods
        public override List<string> GetMyLocalPropertyNamesList()
        {
            List<string> localPropertyNamesList = base.GetMyLocalPropertyNamesList();
            if(localPropertyNamesList==null)
                localPropertyNamesList = new List<string>();
            localPropertyNamesList.Add("UserNote");
            return localPropertyNamesList;
        }

        internal static void AddNewInstance(string sonucKodu, string sonucMesaji)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                MedulaErrorCodeDefinition newInstance = new MedulaErrorCodeDefinition(objectContext);
                newInstance.Code = sonucKodu;
                newInstance.Message = sonucMesaji;
                newInstance.Controlled = false;
                objectContext.Save();
            }
        }

        #endregion Methods

    }
}