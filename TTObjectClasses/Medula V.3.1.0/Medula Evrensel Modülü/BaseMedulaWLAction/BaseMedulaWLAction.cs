
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
    /// Temel İş Listeli İşlemler
    /// </summary>
    public  abstract  partial class BaseMedulaWLAction : TTObject, IMedulaWorkList
    {
        public partial class ISLEMSAYISIDEVAMEDENReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class ISLEMSAYISITAMAMLANMISReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class ISLEMSAYISITAMAMLANMISGRUPLUReportQuery_Class : TTReportNqlObject 
        {
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "HEALTHFACILITYID":
                    {
                        int? value = (int?)newValue;
#region HEALTHFACILITYID_SetScript
                        #if MEDULA
                        if (value.HasValue)
                        {
                            SaglikTesisi saglikTesisi = SaglikTesisi.GetSaglikTesisi(value.Value);
                            if (this is BaseITSAction)
                            {
                                BaseITSAction baseITSAction = (BaseITSAction)this;
                                if (saglikTesisi.ITSGLN.HasValue)
                                    baseITSAction.targetGLN = saglikTesisi.ITSGLN.Value.ToString();
                            }
                            else if (this is BasePTSAction)
                            {
                                BasePTSAction basePTSAction = (BasePTSAction)this;
                                if (saglikTesisi.PTSGLN.HasValue)
                                    basePTSAction.targetGLN = saglikTesisi.PTSGLN.Value.ToString();
                            }
                        }
#endif
#endregion HEALTHFACILITYID_SetScript
                    }
                    break;

            }
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


        override protected void OnConstruct()
        {
            base.OnConstruct();

            ITTObject iTTobject = (ITTObject)this;

            if (iTTobject.IsNew)
                MedulaActionID.GetNextValue();

            _exportableObjects = new List<TTObject>();
        }

        protected List<TTObject> _exportableObjects = null;
        public List<TTObject> ExportableObjects
        {
            get { return _exportableObjects; }
        }

        public virtual void PrepareExportableObjects()
        {
            _exportableObjects.Add(this);
        }

        public string PrepareExportXML()
        {
            PrepareExportableObjects();

            string retValue = string.Empty;
            if (_exportableObjects.Count > 0)
            {
                string exportXMLString = TTObjectContext.ExportToXML(_exportableObjects);
                if (string.IsNullOrEmpty(exportXMLString) == false)
                {
                    byte[] arr = TTUtils.Helpers.GzipHelper.GzipCompressString(exportXMLString);
                    retValue = Convert.ToBase64String(arr);
                }
            }
            return retValue;
        }

        public virtual bool IsExportable
        {
            get
            {
                return false;
            }
        }


#if MEDULA

        protected override void OnSequenceBeforeImport(TTObjectPropertyDef propDef, string value, out bool isEdit)
        {
            base.OnSequenceBeforeImport(propDef, value, out isEdit);

            if (this.MedulaActionID.DataTypeID.Equals(propDef.DataTypeID))
                isEdit = false;
        }

#endif
        
#endregion Methods

    }
}