
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
    /// Referans Numarası Tanımlama
    /// </summary>
    public partial class ReferanceDetailForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Referans Numarası Tanımlama
    /// </summary>
        protected TTObjectClasses.FixedAssetDetailRefDef _FixedAssetDetailRefDef
        {
            get { return (TTObjectClasses.FixedAssetDetailRefDef)_ttObject; }
        }

        protected ITTLabel labelFixedAssetDetailEdgeDef;
        protected ITTObjectListBox FixedAssetDetailEdgeDef;
        protected ITTLabel labelFixedAssetDetailBodyDef;
        protected ITTObjectListBox FixedAssetDetailBodyDef;
        protected ITTLabel labelFixedAssetDetailMarkDef;
        protected ITTObjectListBox FixedAssetDetailMarkDef;
        protected ITTLabel labelFixedAssetDetailLengthDef;
        protected ITTObjectListBox FixedAssetDetailLengthDef;
        protected ITTLabel labelModelNameFixedAssetDetailModelDef;
        protected ITTObjectListBox FixedAssetDetailModelDef;
        protected ITTLabel labelFixedAssetDetailMainClass;
        protected ITTObjectListBox FixedAssetDetailMainClass;
        protected ITTLabel labelReferance;
        protected ITTTextBox Referance;
        override protected void InitializeControls()
        {
            labelFixedAssetDetailEdgeDef = (ITTLabel)AddControl(new Guid("3b8b4499-468c-413d-9868-3ff00480336b"));
            FixedAssetDetailEdgeDef = (ITTObjectListBox)AddControl(new Guid("95861522-74f2-42aa-a0dd-d3c34c8e7121"));
            labelFixedAssetDetailBodyDef = (ITTLabel)AddControl(new Guid("a010bab8-9ff1-4f20-9fa8-237a22c68e7e"));
            FixedAssetDetailBodyDef = (ITTObjectListBox)AddControl(new Guid("78012105-c47b-4822-9308-0f5197bc9d1b"));
            labelFixedAssetDetailMarkDef = (ITTLabel)AddControl(new Guid("6373e8ba-490c-48d8-b8a5-25d8dfd08a99"));
            FixedAssetDetailMarkDef = (ITTObjectListBox)AddControl(new Guid("46758415-0d74-4871-8cdc-eae1252b406d"));
            labelFixedAssetDetailLengthDef = (ITTLabel)AddControl(new Guid("e7eee240-26b6-424d-8a72-030b385bcc8f"));
            FixedAssetDetailLengthDef = (ITTObjectListBox)AddControl(new Guid("3eef9838-be3d-42ed-b87b-9fdd6eb5c713"));
            labelModelNameFixedAssetDetailModelDef = (ITTLabel)AddControl(new Guid("d8d76ae6-5557-4df0-b532-276fc03da3a2"));
            FixedAssetDetailModelDef = (ITTObjectListBox)AddControl(new Guid("7fb9cd14-d5a8-4a0b-9311-e1ec792949a2"));
            labelFixedAssetDetailMainClass = (ITTLabel)AddControl(new Guid("88cf15cc-633e-444e-b82d-cd11064c445d"));
            FixedAssetDetailMainClass = (ITTObjectListBox)AddControl(new Guid("911c73ef-072e-4d91-b657-13a004ae4043"));
            labelReferance = (ITTLabel)AddControl(new Guid("3314b660-3adb-47a1-8fa3-fc481131cd0a"));
            Referance = (ITTTextBox)AddControl(new Guid("a355ff19-3270-493b-a47a-5274c107648b"));
            base.InitializeControls();
        }

        public ReferanceDetailForm() : base("FIXEDASSETDETAILREFDEF", "ReferanceDetailForm")
        {
        }

        protected ReferanceDetailForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}