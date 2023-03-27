
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
    /// Tanı
    /// </summary>
    public  partial class ehrDiagnosis : BaseEhr
    {
#region Methods
        public override List<TTObject> getFullPackage()
        {
            List<TTObject> package = base.getFullPackage();
            // Diagnosis bağlı olduğu  ehrImportantMedicalInfo'ları da
            List<TTObject> editedPackage = new List<TTObject>();
            foreach (TTObject ehrObject in package)
            {
                if(ehrObject is ehrDiagnosis)
                {
                    if(((ehrDiagnosis)ehrObject).ehrImportantMedicalInfo!=null)
                    {
                        if(!package.Contains(((ehrDiagnosis)ehrObject).ehrImportantMedicalInfo))
                            editedPackage.Add(((ehrDiagnosis)ehrObject).ehrImportantMedicalInfo);
                    }
                }
                editedPackage.Add(ehrObject);
            }
            return editedPackage;
        }
        
#endregion Methods

    }
}