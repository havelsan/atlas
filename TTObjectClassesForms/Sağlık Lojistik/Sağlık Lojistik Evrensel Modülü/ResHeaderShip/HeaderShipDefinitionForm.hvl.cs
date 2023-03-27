
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
    /// Müdürlük Tanımı
    /// </summary>
    public partial class HeaderShipDefinitionForm : TTForm
    {
    /// <summary>
    /// Müdürlük Tanımı
    /// </summary>
        protected TTObjectClasses.ResHeaderShip _ResHeaderShip
        {
            get { return (TTObjectClasses.ResHeaderShip)_ttObject; }
        }

        protected ITTCheckBox IsmedicalWaste;
        protected ITTObjectListBox Hospital;
        protected ITTTextBox Name;
        protected ITTTextBox Qref;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTLabel labelQref;
        protected ITTLabel labelName;
        protected ITTCheckBox Active;
        protected ITTEnumComboBox EnabledType;
        protected ITTLabel labelHospital;
        protected ITTLabel labelEnabledType;
        protected ITTLabel labelLocation;
        protected ITTLabel labelDeskPhoneNumber;
        override protected void InitializeControls()
        {
            IsmedicalWaste = (ITTCheckBox)AddControl(new Guid("769781eb-04cb-4737-b8a3-de8acc1bf47a"));
            Hospital = (ITTObjectListBox)AddControl(new Guid("f81d2a32-0aee-4913-bc99-db686154b90e"));
            Name = (ITTTextBox)AddControl(new Guid("a5e09f19-f125-4f41-a4e9-f29f2691d26b"));
            Qref = (ITTTextBox)AddControl(new Guid("5e1325e2-dbf4-427a-b586-a8812e1f7335"));
            Location = (ITTTextBox)AddControl(new Guid("dcb991a2-b79f-41c5-ac8e-27af738e240d"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("eaec554a-df01-45cc-8044-39e3cdb081bf"));
            labelQref = (ITTLabel)AddControl(new Guid("484e014b-2f3d-43de-a08f-49042ba84246"));
            labelName = (ITTLabel)AddControl(new Guid("3603f753-a9ff-4439-a755-1208e4826d65"));
            Active = (ITTCheckBox)AddControl(new Guid("3abdc96c-6e48-4ec0-91b9-9c8430002458"));
            EnabledType = (ITTEnumComboBox)AddControl(new Guid("cc3bb751-c213-4251-a86c-2c61eb99731c"));
            labelHospital = (ITTLabel)AddControl(new Guid("2b30a5cb-6053-4c43-97f3-04e48d17e794"));
            labelEnabledType = (ITTLabel)AddControl(new Guid("161ab4eb-6a36-4c4c-8bb0-3699fbc277e8"));
            labelLocation = (ITTLabel)AddControl(new Guid("7be8d59b-fb17-4d8e-80fe-b01840f1099a"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("d4586eb3-97b4-41f8-98b3-9130770015c6"));
            base.InitializeControls();
        }

        public HeaderShipDefinitionForm() : base("RESHEADERSHIP", "HeaderShipDefinitionForm")
        {
        }

        protected HeaderShipDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}