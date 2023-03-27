
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
    /// Kısım Tanımı
    /// </summary>
    public partial class DivisionSectionDefinitionForm : TTForm
    {
    /// <summary>
    /// Kısım Tanımı
    /// </summary>
        protected TTObjectClasses.ResDivisionSection _ResDivisionSection
        {
            get { return (TTObjectClasses.ResDivisionSection)_ttObject; }
        }

        protected ITTObjectListBox Division;
        protected ITTTextBox Name;
        protected ITTTextBox Qref;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTLabel labelQref;
        protected ITTLabel labelName;
        protected ITTCheckBox Active;
        protected ITTEnumComboBox EnabledType;
        protected ITTLabel labelDivision;
        protected ITTLabel labelEnabledType;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel labelLocation;
        protected ITTLabel labelDeskPhoneNumber;
        override protected void InitializeControls()
        {
            Division = (ITTObjectListBox)AddControl(new Guid("690bf9c0-eaa8-43e8-9bbd-16aa29d7f81f"));
            Name = (ITTTextBox)AddControl(new Guid("bde86f21-63f5-4353-96b5-cec131b830cb"));
            Qref = (ITTTextBox)AddControl(new Guid("646514fc-b2fe-483e-895e-a58c30628702"));
            Location = (ITTTextBox)AddControl(new Guid("c7a3fb3b-a5b5-4a14-a636-fcbf7e604ce1"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("a4084bd8-8722-4db4-9e99-dda0932b1de2"));
            labelQref = (ITTLabel)AddControl(new Guid("689c922b-bcfd-4b22-9c1b-2c1ea9a7aaf6"));
            labelName = (ITTLabel)AddControl(new Guid("bb432d33-025f-4c00-ad71-c505bc202991"));
            Active = (ITTCheckBox)AddControl(new Guid("9a2c9f6d-1a14-4747-a37d-3760fb661e80"));
            EnabledType = (ITTEnumComboBox)AddControl(new Guid("d1dfdef7-46f3-400f-8684-043906daaa5e"));
            labelDivision = (ITTLabel)AddControl(new Guid("b2f9dbb1-49b2-473b-8e6e-2e00a9ac7971"));
            labelEnabledType = (ITTLabel)AddControl(new Guid("633e2e9c-5412-4280-ada6-a061512c4f5c"));
            labelStore = (ITTLabel)AddControl(new Guid("1559a943-c028-499d-9861-61e9c9fb46e2"));
            Store = (ITTObjectListBox)AddControl(new Guid("067674ae-406b-493a-8cab-d85059b5c5da"));
            labelLocation = (ITTLabel)AddControl(new Guid("fbeee878-ba24-47f0-abca-0b4c53a2547c"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("a6e42e0a-cacd-4f6b-ba43-b143885919c8"));
            base.InitializeControls();
        }

        public DivisionSectionDefinitionForm() : base("RESDIVISIONSECTION", "DivisionSectionDefinitionForm")
        {
        }

        protected DivisionSectionDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}