
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
    /// Üretim Merkezi Tanımı
    /// </summary>
    public partial class ProductionCenterDefinitionForm : TTForm
    {
    /// <summary>
    /// Üretim Merkezi Tanımı
    /// </summary>
        protected TTObjectClasses.ResProductionCenter _ResProductionCenter
        {
            get { return (TTObjectClasses.ResProductionCenter)_ttObject; }
        }

        protected ITTLabel labelHospital;
        protected ITTTextBox Name;
        protected ITTTextBox Qref;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTLabel labelQref;
        protected ITTLabel labelName;
        protected ITTCheckBox Active;
        protected ITTEnumComboBox EnabledType;
        protected ITTLabel labelEnabledType;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Hospital;
        protected ITTObjectListBox Store;
        protected ITTLabel labelLocation;
        protected ITTLabel labelDeskPhoneNumber;
        override protected void InitializeControls()
        {
            labelHospital = (ITTLabel)AddControl(new Guid("eb7b1631-e24b-458e-9169-a013ddb1589c"));
            Name = (ITTTextBox)AddControl(new Guid("504d7a08-9c47-4f89-bb84-1ff372bf0b3e"));
            Qref = (ITTTextBox)AddControl(new Guid("73ebd5df-132c-4dc5-9907-4071d9bfc191"));
            Location = (ITTTextBox)AddControl(new Guid("64afd043-c8ca-40cf-a2bb-e3d93b167bd7"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("1696016a-d584-4df8-9187-5c0e8a6752b2"));
            labelQref = (ITTLabel)AddControl(new Guid("28e88b8a-62e4-49eb-bf15-48e425e48520"));
            labelName = (ITTLabel)AddControl(new Guid("108373ef-07a2-4b14-a5bc-9a758516ea2e"));
            Active = (ITTCheckBox)AddControl(new Guid("20bab41e-3e9f-4bee-b2c3-132e8aca94df"));
            EnabledType = (ITTEnumComboBox)AddControl(new Guid("f7e0c5e3-91c9-45b0-b7fa-96b932690a49"));
            labelEnabledType = (ITTLabel)AddControl(new Guid("b55ea7b2-b0c2-4777-b3f7-4bad6f2ac5da"));
            labelStore = (ITTLabel)AddControl(new Guid("ed4da3be-18e9-4e6d-97b2-d8496f0a8c64"));
            Hospital = (ITTObjectListBox)AddControl(new Guid("0ac5c664-1e6d-4220-81fb-bca0729a22a0"));
            Store = (ITTObjectListBox)AddControl(new Guid("e3b01bad-6290-4d34-aeab-e100256edfdc"));
            labelLocation = (ITTLabel)AddControl(new Guid("394e08ad-16c3-4bd2-bc36-57743668425b"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("4acb1c06-6b8f-4fbd-b6bf-4f39174f633e"));
            base.InitializeControls();
        }

        public ProductionCenterDefinitionForm() : base("RESPRODUCTIONCENTER", "ProductionCenterDefinitionForm")
        {
        }

        protected ProductionCenterDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}