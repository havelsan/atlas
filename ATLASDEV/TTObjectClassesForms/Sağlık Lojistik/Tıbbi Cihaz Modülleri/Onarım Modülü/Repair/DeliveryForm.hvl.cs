
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
    /// Teslim Tesellüm
    /// </summary>
    public partial class DeliveryForm : RepairBaseForm
    {
    /// <summary>
    /// Onarım
    /// </summary>
        protected TTObjectClasses.Repair _Repair
        {
            get { return (TTObjectClasses.Repair)_ttObject; }
        }

        protected ITTLabel labelResponsibleWorkShopUser;
        protected ITTObjectListBox ResponsibleWorkShopUser;
        protected ITTObjectListBox DelivererUser;
        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTLabel labelRequestDate;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel6;
        protected ITTTextBox tttextbox4;
        protected ITTTextBox Description;
        protected ITTTextBox RequestNO;
        protected ITTTextBox tttextbox3;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelDescription;
        protected ITTObjectListBox FixedAsset;
        protected ITTLabel labelFromResource;
        protected ITTObjectListBox FromResource;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel ttlabel5;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel ttlabel8;
        protected ITTLabel labelRequestNO;
        protected ITTLabel labelFixedAsset;
        protected ITTGrid ItemEquipmentsGrid;
        protected ITTTextBoxColumn ItemName;
        protected ITTTextBoxColumn Amount;
        protected ITTListBoxColumn DistType;
        protected ITTCheckBoxColumn IsMissing;
        protected ITTCheckBoxColumn IsChanged;
        protected ITTCheckBoxColumn IsDamaged;
        protected ITTCheckBoxColumn Normal;
        protected ITTTextBoxColumn Comments;
        protected ITTLabel ttlabel7;
        override protected void InitializeControls()
        {
            labelResponsibleWorkShopUser = (ITTLabel)AddControl(new Guid("384cf8ab-3dc3-4eb4-a012-093fb67d2fc0"));
            ResponsibleWorkShopUser = (ITTObjectListBox)AddControl(new Guid("5e0c20cd-b045-4154-8b85-b3b1547469f1"));
            DelivererUser = (ITTObjectListBox)AddControl(new Guid("cbb15b5a-b03b-491d-bc50-dcda261d824e"));
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("8adeecf6-ef6e-411e-ab5d-286489812ed4"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("5b9c7e7b-6e95-4429-90a4-004167fd1880"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("a3bcb5eb-bd4c-4959-af25-0711677cff4d"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("d11ca109-a298-4edf-85d2-160420bd2709"));
            tttextbox4 = (ITTTextBox)AddControl(new Guid("c1cba628-4af4-433a-99df-1a95447930f4"));
            Description = (ITTTextBox)AddControl(new Guid("f9dc95b3-cda8-4f36-8490-63a339aee767"));
            RequestNO = (ITTTextBox)AddControl(new Guid("08221147-34f7-4c9f-aa5d-bedf4be55968"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("16ad1089-a683-4ea5-acdc-db728e8a3d25"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("e452e47e-f9ea-483e-b1cf-288a4f856a2a"));
            labelDescription = (ITTLabel)AddControl(new Guid("9c004613-487f-4d36-9a4a-2ca43f5a085f"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("1abe04e3-7ade-4181-a0b9-45c98287b856"));
            labelFromResource = (ITTLabel)AddControl(new Guid("f4019ade-e69f-477c-8867-4e57f79cb95c"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("5027a6b9-6214-4314-a844-526570602197"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("b3bfb549-84f0-4a07-b409-56b06abf9b09"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("dcba9e02-d47c-4421-b9f3-6264344b081c"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("2277f143-484c-435d-b904-86962de2867d"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("a2c752e6-b857-4120-b86a-aa5a65c999c4"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("9863aadf-9487-413f-903b-b5df818ed07d"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("a03babce-7e32-4a1a-8257-c9645cf7dbc2"));
            ItemEquipmentsGrid = (ITTGrid)AddControl(new Guid("845ed827-da8b-43ae-b96f-d296cff8787e"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("81b75be3-1a5d-4769-9924-76f8744da18a"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("d3993688-b33e-45dd-ac0a-3a216b99d882"));
            DistType = (ITTListBoxColumn)AddControl(new Guid("0f8928f1-e8ab-4c30-84f9-2e591c6f1334"));
            IsMissing = (ITTCheckBoxColumn)AddControl(new Guid("bca8e764-d6a3-4d25-aefa-67f267ea55ef"));
            IsChanged = (ITTCheckBoxColumn)AddControl(new Guid("36889224-4a68-494f-91be-dd5ef7a95f03"));
            IsDamaged = (ITTCheckBoxColumn)AddControl(new Guid("f168c7d0-7062-465e-af8f-827f726f1b1f"));
            Normal = (ITTCheckBoxColumn)AddControl(new Guid("1f8c8438-5531-42c2-af1a-610c662c7cc4"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("01b596f1-c5a4-4b58-ab4d-bcc70fa7a5af"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("520cf857-828e-4c81-817b-de9ca3f8e473"));
            base.InitializeControls();
        }

        public DeliveryForm() : base("REPAIR", "DeliveryForm")
        {
        }

        protected DeliveryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}