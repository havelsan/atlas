
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
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Demirbaş Durumu Değiştirme
    /// </summary>
    public partial class FixedAssetDataCorrectionForm : BaseDataCorrectionForm
    {
    /// <summary>
    /// Demirbaş Durumu Değiştirme
    /// </summary>
        protected TTObjectClasses.FixedAssetDataCorrection _FixedAssetDataCorrection
        {
            get { return (TTObjectClasses.FixedAssetDataCorrection)_ttObject; }
        }

        protected ITTLabel labelFixedAssetDefinition;
        protected ITTObjectListBox FixedAssetDefinition;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel labelOldCMRStatus;
        protected ITTEnumComboBox OldCMRStatus;
        protected ITTLabel labelNewCMRStatus;
        protected ITTEnumComboBox NewCMRStatus;
        protected ITTLabel labelFixedAssetMaterialDefinition;
        protected ITTObjectListBox FixedAssetMaterialDefinition;
        override protected void InitializeControls()
        {
            labelFixedAssetDefinition = (ITTLabel)AddControl(new Guid("1da2ef74-3dc9-402d-acdc-eb4be7cac37d"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("5b7925cf-1929-4332-b7be-8913a95930cb"));
            labelStore = (ITTLabel)AddControl(new Guid("2303c63d-07b9-4b86-894e-47f5fb288f2d"));
            Store = (ITTObjectListBox)AddControl(new Guid("1360db88-c668-4ad9-a714-8422b4efd1de"));
            labelOldCMRStatus = (ITTLabel)AddControl(new Guid("09f88619-d920-4842-bb6f-584e70a52aff"));
            OldCMRStatus = (ITTEnumComboBox)AddControl(new Guid("5329cd2a-9bd5-4ed4-8169-f76af9bd370e"));
            labelNewCMRStatus = (ITTLabel)AddControl(new Guid("76589940-096c-45b1-b5d5-3be056842d14"));
            NewCMRStatus = (ITTEnumComboBox)AddControl(new Guid("8e109116-cd02-4a2e-a351-b666dd8d2ce6"));
            labelFixedAssetMaterialDefinition = (ITTLabel)AddControl(new Guid("32fa2ce4-09d0-4b60-9699-42a6a8f5e58d"));
            FixedAssetMaterialDefinition = (ITTObjectListBox)AddControl(new Guid("1bd4adf9-2b2b-4b9f-a934-74754e792f2e"));
            base.InitializeControls();
        }

        public FixedAssetDataCorrectionForm() : base("FIXEDASSETDATACORRECTION", "FixedAssetDataCorrectionForm")
        {
        }

        protected FixedAssetDataCorrectionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}