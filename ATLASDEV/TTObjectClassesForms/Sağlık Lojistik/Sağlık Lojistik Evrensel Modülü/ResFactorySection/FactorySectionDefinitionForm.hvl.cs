
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
    /// Fabrika Kısım Tanımı
    /// </summary>
    public partial class FactorySectionDefinitionForm : TTForm
    {
    /// <summary>
    /// Fabrika Kısım Tanımı
    /// </summary>
        protected TTObjectClasses.ResFactorySection _ResFactorySection
        {
            get { return (TTObjectClasses.ResFactorySection)_ttObject; }
        }

        protected ITTObjectListBox Store;
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
        protected ITTLabel labelHospital;
        protected ITTLabel labelLocation;
        protected ITTLabel labelDeskPhoneNumber;
        override protected void InitializeControls()
        {
            Store = (ITTObjectListBox)AddControl(new Guid("8cdd3613-e411-4196-8538-c89d9f960f23"));
            Name = (ITTTextBox)AddControl(new Guid("2a99c46a-86b4-489c-b6d9-e835daafb569"));
            Qref = (ITTTextBox)AddControl(new Guid("c31d9d44-5a3d-46c2-b9ea-73ce15e822e9"));
            Location = (ITTTextBox)AddControl(new Guid("8b52e34f-7bb7-4ed1-a198-b5d81085a8a6"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("a3999909-f9e5-4d3f-bbfd-e52ef629af27"));
            labelQref = (ITTLabel)AddControl(new Guid("99d5e657-15ea-4387-9f4a-9600fb017bcd"));
            labelName = (ITTLabel)AddControl(new Guid("939b9429-365c-459f-bf29-dd7cfe5a2019"));
            Active = (ITTCheckBox)AddControl(new Guid("95474fa5-d99c-40fa-9d7e-62cc839da61f"));
            EnabledType = (ITTEnumComboBox)AddControl(new Guid("e241cbca-6f11-4b11-924f-44ca831f2fdf"));
            labelEnabledType = (ITTLabel)AddControl(new Guid("679616df-592a-4a5d-8482-a702762cc1e5"));
            labelStore = (ITTLabel)AddControl(new Guid("ba5766d5-2cf9-449e-8193-0447486f7a84"));
            Hospital = (ITTObjectListBox)AddControl(new Guid("1ae30059-32f5-4777-90b7-cc5123456359"));
            labelHospital = (ITTLabel)AddControl(new Guid("c8e2cc26-fe5a-44c7-96d8-700659a4367d"));
            labelLocation = (ITTLabel)AddControl(new Guid("f84ca228-ec26-4179-ba6a-d5ffee7ca11c"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("a1710420-95fa-46fc-8a92-e905b996bc86"));
            base.InitializeControls();
        }

        public FactorySectionDefinitionForm() : base("RESFACTORYSECTION", "FactorySectionDefinitionForm")
        {
        }

        protected FactorySectionDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}