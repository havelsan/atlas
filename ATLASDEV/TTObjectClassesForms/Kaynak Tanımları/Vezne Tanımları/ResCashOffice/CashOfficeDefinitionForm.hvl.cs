
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
    /// Vezne Tanımı
    /// </summary>
    public partial class CashOfficeDefinitionForm : TTForm
    {
    /// <summary>
    /// Vezne
    /// </summary>
        protected TTObjectClasses.ResCashOffice _ResCashOffice
        {
            get { return (TTObjectClasses.ResCashOffice)_ttObject; }
        }

        protected ITTLabel labelLocation;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox tttextbox1;
        protected ITTLabel labelDeskPhoneNumber;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTCheckBox ttcheckbox2;
        protected ITTObjectListBox AdministrativeUnit;
        protected ITTLabel ttlabel4;
        override protected void InitializeControls()
        {
            labelLocation = (ITTLabel)AddControl(new Guid("f415280a-2406-4dc5-9286-05fcf4208554"));
            Location = (ITTTextBox)AddControl(new Guid("f0308346-2d23-4371-9e62-cb50a78e5a10"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("fd1f5ade-ea4f-409d-a89c-76766a9ee77f"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("8f656d86-8a3c-4ef2-889f-0de97138b042"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("89ced15e-cd6a-4fd8-b309-6b05f9f3aa62"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("3e7e19ed-5776-4cf9-abf4-5db47ced5710"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("eefa8357-47ac-432d-a7d9-c09396fbbbcc"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("67ca15a7-be77-4903-b3fc-8ee2c9a5a723"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("1f4182b5-698d-4d26-bdaa-0d24fb44ca21"));
            AdministrativeUnit = (ITTObjectListBox)AddControl(new Guid("cf4dcbab-84ec-468c-bd38-224ecd1fce1a"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("88f07f48-f739-48a3-872e-805eba4986ae"));
            base.InitializeControls();
        }

        public CashOfficeDefinitionForm() : base("RESCASHOFFICE", "CashOfficeDefinitionForm")
        {
        }

        protected CashOfficeDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}