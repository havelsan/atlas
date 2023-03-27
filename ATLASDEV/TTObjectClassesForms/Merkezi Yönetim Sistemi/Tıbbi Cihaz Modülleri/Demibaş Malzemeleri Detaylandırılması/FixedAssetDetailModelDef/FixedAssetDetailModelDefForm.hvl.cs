
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
    /// Model Tanımı
    /// </summary>
    public partial class FixedAssetDetailModelDefForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.FixedAssetDetailModelDef _FixedAssetDetailModelDef
        {
            get { return (TTObjectClasses.FixedAssetDetailModelDef)_ttObject; }
        }

        protected ITTLabel labelProposedStockcardName;
        protected ITTTextBox ProposedStockcardName;
        protected ITTTextBox ProposedNATOStockNo;
        protected ITTTextBox ModelName;
        protected ITTLabel labelProposedNATOStockNo;
        protected ITTLabel labelFixedAssetDetailMarkDef;
        protected ITTObjectListBox FixedAssetDetailMarkDef;
        protected ITTLabel labelModelName;
        override protected void InitializeControls()
        {
            labelProposedStockcardName = (ITTLabel)AddControl(new Guid("8b16f581-a2d8-4fdb-a797-b680fe4efb47"));
            ProposedStockcardName = (ITTTextBox)AddControl(new Guid("249fcd10-9bbc-4974-846a-e1f4d29b9231"));
            ProposedNATOStockNo = (ITTTextBox)AddControl(new Guid("f5459561-62b2-420e-b529-e6fd99b2c864"));
            ModelName = (ITTTextBox)AddControl(new Guid("400638ef-7add-4cc1-be70-69b9ad7ef2b0"));
            labelProposedNATOStockNo = (ITTLabel)AddControl(new Guid("33657a29-43f8-4683-bcc9-b283acc0866f"));
            labelFixedAssetDetailMarkDef = (ITTLabel)AddControl(new Guid("664f8402-8577-4c54-88ae-4ac151727e1b"));
            FixedAssetDetailMarkDef = (ITTObjectListBox)AddControl(new Guid("8106b68f-de9b-4e94-924a-becbe43c7142"));
            labelModelName = (ITTLabel)AddControl(new Guid("ed69ea82-d314-455a-b02e-dd80d1883893"));
            base.InitializeControls();
        }

        public FixedAssetDetailModelDefForm() : base("FIXEDASSETDETAILMODELDEF", "FixedAssetDetailModelDefForm")
        {
        }

        protected FixedAssetDetailModelDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}