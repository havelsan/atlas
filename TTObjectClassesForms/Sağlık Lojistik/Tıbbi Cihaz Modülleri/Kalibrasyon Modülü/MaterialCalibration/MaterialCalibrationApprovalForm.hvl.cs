
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
    /// İstek Onay[Stok Numaralı]
    /// </summary>
    public partial class MaterialCalibrationApprovalForm : CalibrationBaseForm
    {
    /// <summary>
    /// Kalibrasyon [Stok Numaralı]
    /// </summary>
        protected TTObjectClasses.MaterialCalibration _MaterialCalibration
        {
            get { return (TTObjectClasses.MaterialCalibration)_ttObject; }
        }

        protected ITTTextBox Description;
        protected ITTTextBox RequestNO;
        protected ITTLabel labelResponsibleResource;
        protected ITTLabel CalibrationStatusLabel;
        protected ITTGrid ttgrid2;
        protected ITTTextBoxColumn ItemName;
        protected ITTTextBoxColumn Amount;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTLabel labelRequestNO;
        protected ITTLabel labelDescription;
        protected ITTObjectListBox WorkShop;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel ttlabel5;
        protected ITTObjectListBox ToResource;
        protected ITTLabel labelToResource;
        protected ITTObjectListBox SenderAccountancy;
        protected ITTLabel labelSenderAccountancy;
        protected ITTLabel labelFixedAsset;
        protected ITTObjectListBox FixedAssetDefinition;
        override protected void InitializeControls()
        {
            Description = (ITTTextBox)AddControl(new Guid("a632bd52-7e0e-4a7d-928b-615e0c97d2cc"));
            RequestNO = (ITTTextBox)AddControl(new Guid("cd650783-fc50-4195-b870-df6d106671c2"));
            labelResponsibleResource = (ITTLabel)AddControl(new Guid("9d9bf98a-3634-489a-8d38-b8ebe2194952"));
            CalibrationStatusLabel = (ITTLabel)AddControl(new Guid("49cd2070-b371-411d-abd6-795cd97cd614"));
            ttgrid2 = (ITTGrid)AddControl(new Guid("e114c4d4-226b-4461-b9c3-a7b3e3f81156"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("0ab6bd5a-7c7f-44c8-8892-4a85b05e2857"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("ada8217d-eb7d-41ad-869d-f1397a2de894"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("2227cda8-471e-4c21-9101-c72501f5afe6"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("72fc894d-eeb7-4c32-aaf8-059e4b8305bb"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("ed79f6fa-5705-490b-a8b2-49566f0c153f"));
            labelDescription = (ITTLabel)AddControl(new Guid("90020fd5-27a2-4bf5-a71d-3780240a0e21"));
            WorkShop = (ITTObjectListBox)AddControl(new Guid("f372779e-f950-49e9-b572-b0e80924e681"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("4739d246-a4d8-4d27-8bd6-b4241c472b17"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("b2f2908a-1b21-43e9-a038-037fb7306595"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("dcb4f6d2-be5f-4e90-8f43-284187c66b82"));
            ToResource = (ITTObjectListBox)AddControl(new Guid("5f4c9f4c-395c-4e94-bde8-4655b71e7826"));
            labelToResource = (ITTLabel)AddControl(new Guid("6c4c76d0-e194-4d27-9dbe-8d9a5a4207e8"));
            SenderAccountancy = (ITTObjectListBox)AddControl(new Guid("ee887440-aac9-4086-984e-4f86396bf0ae"));
            labelSenderAccountancy = (ITTLabel)AddControl(new Guid("2892ca20-9461-4994-afbf-cea6ed2c45ca"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("e336cb53-b7eb-4173-9bb5-3aecc40dc2ec"));
            FixedAssetDefinition = (ITTObjectListBox)AddControl(new Guid("45d4baac-1f12-40cb-8141-363d7135c69a"));
            base.InitializeControls();
        }

        public MaterialCalibrationApprovalForm() : base("MATERIALCALIBRATION", "MaterialCalibrationApprovalForm")
        {
        }

        protected MaterialCalibrationApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}