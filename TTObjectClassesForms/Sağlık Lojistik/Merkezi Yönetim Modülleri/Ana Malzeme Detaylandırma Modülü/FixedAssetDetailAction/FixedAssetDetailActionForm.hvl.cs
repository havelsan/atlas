
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
    /// Ana Malzeme Detaylandırma
    /// </summary>
    public partial class FixedAssetDetailActionForm : TTForm
    {
    /// <summary>
    /// Ana Malzeme Detaylandırma İşlemi
    /// </summary>
        protected TTObjectClasses.FixedAssetDetailAction _FixedAssetDetailAction
        {
            get { return (TTObjectClasses.FixedAssetDetailAction)_ttObject; }
        }

        protected ITTTextBox StoreName;
        protected ITTButton cmdSelectStore;
        protected ITTLabel labelStoreName;
        protected ITTGrid FixedAssetDetailActionDetails;
        protected ITTListBoxColumn FixedAssetMaterialDefinitionFixedAssetDetailActionDet;
        protected ITTCheckBoxColumn IsAccountancyFixedAssetDetailActionDet;
        protected ITTCheckBoxColumn IsBMMFixedAssetDetailActionDet;
        protected ITTTextBoxColumn BMMDesc;
        protected ITTCheckBoxColumn IsETKMFixedAssetDetailActionDet;
        protected ITTTextBoxColumn ETKMDesc;
        protected ITTButton cmdList;
        protected ITTLabel labelStockCard;
        protected ITTObjectListBox StockCard;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelFromSite;
        protected ITTObjectListBox FromSite;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        override protected void InitializeControls()
        {
            StoreName = (ITTTextBox)AddControl(new Guid("5c46685b-c093-460a-a6c8-5cf5de1ab40b"));
            cmdSelectStore = (ITTButton)AddControl(new Guid("af4dcd59-4918-4f6b-abe6-a94964e6b72a"));
            labelStoreName = (ITTLabel)AddControl(new Guid("cbed6ab9-3661-46e8-80b9-a9a904ddfb2a"));
            FixedAssetDetailActionDetails = (ITTGrid)AddControl(new Guid("7169fafc-ba16-4e2e-b6ad-c812a6b4820b"));
            FixedAssetMaterialDefinitionFixedAssetDetailActionDet = (ITTListBoxColumn)AddControl(new Guid("89101bb7-69b9-4f60-8672-c4e1f12ac8c6"));
            IsAccountancyFixedAssetDetailActionDet = (ITTCheckBoxColumn)AddControl(new Guid("7932be89-91ac-4830-aeeb-1be1b049b284"));
            IsBMMFixedAssetDetailActionDet = (ITTCheckBoxColumn)AddControl(new Guid("a46096c2-0d21-492e-bbca-20fdf01945c8"));
            BMMDesc = (ITTTextBoxColumn)AddControl(new Guid("c70d57c1-786f-48b1-a8e4-2a5a4cd9ec18"));
            IsETKMFixedAssetDetailActionDet = (ITTCheckBoxColumn)AddControl(new Guid("46c17ffb-5ab4-49be-9595-870f8278f655"));
            ETKMDesc = (ITTTextBoxColumn)AddControl(new Guid("146437b1-97b0-48c8-a396-63d6482b134f"));
            cmdList = (ITTButton)AddControl(new Guid("9bad5920-70bb-4569-a2fd-6dc2494c7b87"));
            labelStockCard = (ITTLabel)AddControl(new Guid("06d58a94-8bc9-42d8-a25a-215be16b7ea2"));
            StockCard = (ITTObjectListBox)AddControl(new Guid("ea796652-d232-4f2b-af60-05886076532b"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("2e5c841a-12ba-4c39-a633-6a3c55942d97"));
            labelFromSite = (ITTLabel)AddControl(new Guid("f2c9e8b9-16a9-4f8b-983c-d162b6dd0f70"));
            FromSite = (ITTObjectListBox)AddControl(new Guid("d33fab40-291d-4342-add1-446e72111673"));
            labelActionDate = (ITTLabel)AddControl(new Guid("e789b7dd-7fe9-4ac0-ae1d-2cbabf7b1ce4"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("d8d37035-d452-4c4c-ad64-58157805775f"));
            base.InitializeControls();
        }

        public FixedAssetDetailActionForm() : base("FIXEDASSETDETAILACTION", "FixedAssetDetailActionForm")
        {
        }

        protected FixedAssetDetailActionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}