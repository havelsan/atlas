
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
    /// İstek Onay
    /// </summary>
    public partial class CalibrationApprovalForm : CalibrationBaseForm
    {
    /// <summary>
    /// Kalibrasyon
    /// </summary>
        protected TTObjectClasses.Calibration _Calibration
        {
            get { return (TTObjectClasses.Calibration)_ttObject; }
        }

        protected ITTObjectListBox Stage;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTLabel labelResponsibleResource;
        protected ITTLabel CalibrationStatusLabel;
        protected ITTGrid ttgrid2;
        protected ITTTextBoxColumn ItemName;
        protected ITTTextBoxColumn Amount;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelFixedAsset;
        protected ITTObjectListBox objFixedAssetMaterial;
        protected ITTTextBox RequestNO;
        protected ITTTextBox Description;
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
        override protected void InitializeControls()
        {
            Stage = (ITTObjectListBox)AddControl(new Guid("8f0d0986-c7e4-424c-8bc0-48e7aacf64f5"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("6acfa293-f597-483b-9a13-7596a4bb35b1"));
            labelResponsibleResource = (ITTLabel)AddControl(new Guid("80e50892-af25-4767-b1f1-5df67b5fbc51"));
            CalibrationStatusLabel = (ITTLabel)AddControl(new Guid("915a86e5-2f8e-4c26-9654-705cac746a3d"));
            ttgrid2 = (ITTGrid)AddControl(new Guid("ad42bbb2-8bca-4538-bdab-2294bf639450"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("6a5a2f20-e701-4d09-9ee1-55b5e0227e4c"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("ea1ea276-a154-4c1f-90f5-f565e46914b9"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("82c165f1-0f9e-40e1-84ff-7a7fcb0e0909"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("74723bee-a2ba-4ec5-91db-3c06ba82935c"));
            objFixedAssetMaterial = (ITTObjectListBox)AddControl(new Guid("23548460-4d7a-47ea-baa4-6ec64820fbfe"));
            RequestNO = (ITTTextBox)AddControl(new Guid("e46be72b-9af5-4ac0-829c-854cc8197e26"));
            Description = (ITTTextBox)AddControl(new Guid("ba57ded1-3c61-4514-9ab2-da72b10a33e1"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("c322d3c9-7f5d-4ace-8042-05e378a93084"));
            labelDescription = (ITTLabel)AddControl(new Guid("2192b491-5a8b-417f-a4ef-d81726302153"));
            WorkShop = (ITTObjectListBox)AddControl(new Guid("0b713800-b59f-4719-9a3c-a2ee25493331"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("24d7dbd2-aa41-48c9-9e71-d781a7a56d69"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("29326e27-0d4e-40a3-b32f-5d7f47db3ef1"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("2911f332-0dee-41f7-82ef-ae6dc97cd827"));
            ToResource = (ITTObjectListBox)AddControl(new Guid("4d8a1094-1f31-4652-8820-4b06643a2843"));
            labelToResource = (ITTLabel)AddControl(new Guid("0fb8c1ad-84c6-4d3d-93d9-0916efff5489"));
            SenderAccountancy = (ITTObjectListBox)AddControl(new Guid("8a148253-d89a-4753-98b3-49b2f1ae6ad3"));
            labelSenderAccountancy = (ITTLabel)AddControl(new Guid("e13100e8-ca81-4d6f-8cd2-fe6b3fae9b62"));
            base.InitializeControls();
        }

        public CalibrationApprovalForm() : base("CALIBRATION", "CalibrationApprovalForm")
        {
        }

        protected CalibrationApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}