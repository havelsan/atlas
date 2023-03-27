
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
    /// Demirbaş Detayları
    /// </summary>
    public partial class DepStoreFirstInActionDetForm : TTForm
    {
        protected TTObjectClasses.DepStoreFirstInActionDet _DepStoreFirstInActionDet
        {
            get { return (TTObjectClasses.DepStoreFirstInActionDet)_ttObject; }
        }

        protected ITTLabel labelMaterial;
        protected ITTObjectListBox Material;
        protected ITTGrid FixedAssetOutDetails;
        protected ITTListBoxColumn FixedAssetMaterialDefinitionFixedAssetOutDetail;
        protected ITTTextBoxColumn FixedAssetNo;
        protected ITTTextBoxColumn Mark;
        protected ITTTextBoxColumn Model;
        protected ITTTextBoxColumn SerialNumber;
        protected ITTEnumComboBoxColumn Status;
        protected ITTLabel labelAmount;
        protected ITTTextBox Amount;
        override protected void InitializeControls()
        {
            labelMaterial = (ITTLabel)AddControl(new Guid("717aa72a-1b7e-46b8-830e-6dce2762ba01"));
            Material = (ITTObjectListBox)AddControl(new Guid("0f317855-1b40-4b15-bde3-a9e220b87f66"));
            FixedAssetOutDetails = (ITTGrid)AddControl(new Guid("61ee396e-0f80-4e04-b108-1beb08803ce8"));
            FixedAssetMaterialDefinitionFixedAssetOutDetail = (ITTListBoxColumn)AddControl(new Guid("84728591-edf8-47c1-b9e7-8caba4229652"));
            FixedAssetNo = (ITTTextBoxColumn)AddControl(new Guid("be9b2c85-1ec5-4fad-b622-6b3bdc0e2f95"));
            Mark = (ITTTextBoxColumn)AddControl(new Guid("c6409c12-45ad-434e-ab80-8e7426080099"));
            Model = (ITTTextBoxColumn)AddControl(new Guid("02fdb7b7-57a0-4618-95e1-ba08e034c8cb"));
            SerialNumber = (ITTTextBoxColumn)AddControl(new Guid("f55c1889-f7cf-4327-bcd7-0783fbeeeea9"));
            Status = (ITTEnumComboBoxColumn)AddControl(new Guid("9afaa9ee-e4f7-45ed-a237-a0185fff7f18"));
            labelAmount = (ITTLabel)AddControl(new Guid("c5189889-056f-4d3f-811e-b6a53c302544"));
            Amount = (ITTTextBox)AddControl(new Guid("3ba82e06-9938-4425-8100-43bc468ecb8f"));
            base.InitializeControls();
        }

        public DepStoreFirstInActionDetForm() : base("DEPSTOREFIRSTINACTIONDET", "DepStoreFirstInActionDetForm")
        {
        }

        protected DepStoreFirstInActionDetForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}