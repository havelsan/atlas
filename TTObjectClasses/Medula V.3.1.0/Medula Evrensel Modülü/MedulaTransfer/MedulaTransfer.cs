
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
    /// Medulaya Aktar
    /// </summary>
    public  partial class MedulaTransfer : TTObject
    {
        public partial class GetMedulaTransfersForXXXXXXTransferRQ_Class : TTReportNqlObject 
        {
        }

#region Methods
        public SaglikTesisi HealthFacility
        {
            get
            {
                if (HealthFacilityID.HasValue)
                    return SaglikTesisi.GetSaglikTesisi(HealthFacilityID.Value);
                else
                    return null;
            }
        }
        
        public string PrepareExportXML()
        {
            string retValue = string.Empty;

            List<TTObject> exportableObjects = new List<TTObject>();
            exportableObjects.Add(this);
            foreach(BaseMedulaAction baseMedulaAction in BaseMedulaActions)
            {
                baseMedulaAction.PrepareExportableObjects();
                exportableObjects.AddRange(baseMedulaAction.ExportableObjects);
            }
            
            string exportXMLString = TTObjectContext.ExportToXML(exportableObjects);
            if (string.IsNullOrEmpty(exportXMLString) == false)
            {
                byte[] arr = TTUtils.Helpers.GzipHelper.GzipCompressString(exportXMLString);
                retValue = Convert.ToBase64String(arr);
            }
            return retValue;
        }
        
#endregion Methods

    }
}