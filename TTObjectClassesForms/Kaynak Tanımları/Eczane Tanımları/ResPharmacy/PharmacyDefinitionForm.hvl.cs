
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
    /// Eczane Tanımı
    /// </summary>
    public partial class PharmacyDefinitionForm : TTForm
    {
    /// <summary>
    /// Eczane
    /// </summary>
        protected TTObjectClasses.ResPharmacy _ResPharmacy
        {
            get { return (TTObjectClasses.ResPharmacy)_ttObject; }
        }

        protected ITTCheckBox IsmedicalWaste;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTCheckBox ttcheckbox2;
        protected ITTObjectListBox Hospital;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelLocation;
        protected ITTLabel labelDeskPhoneNumber;
        override protected void InitializeControls()
        {
            IsmedicalWaste = (ITTCheckBox)AddControl(new Guid("d02f3b91-6a8f-4b02-9834-197a3bb12e90"));
            labelStore = (ITTLabel)AddControl(new Guid("e231a972-0bd5-4200-85c0-cd0e47e8c104"));
            Store = (ITTObjectListBox)AddControl(new Guid("400968b9-b813-4251-a2bb-9892acdb3afe"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("a19809ac-3547-493e-9cf2-21100e450e03"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("f5e5a9a1-deae-45fa-87b9-bd717a7b4504"));
            Location = (ITTTextBox)AddControl(new Guid("7bb53d2c-0934-4040-9a68-6bef9ae727b9"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("5e957596-09ae-4670-82c9-0bce4fadd9ad"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("8398bfb3-4f1d-442b-92cd-b6367f70aefc"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("a19d7881-5c55-40d4-9994-cc7cc5911736"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("97c0edf4-4432-43cc-8765-92fb63beae4c"));
            Hospital = (ITTObjectListBox)AddControl(new Guid("48d40848-335b-44bf-afa3-8cebaecf0c83"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("d770e7cc-cfe7-4541-b975-e51588e85b66"));
            labelLocation = (ITTLabel)AddControl(new Guid("406f0e64-1c78-4e48-9f68-ef91ce2c24f0"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("bf6f7100-6c5b-4a36-92c0-0822658a0380"));
            base.InitializeControls();
        }

        public PharmacyDefinitionForm() : base("RESPHARMACY", "PharmacyDefinitionForm")
        {
        }

        protected PharmacyDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}