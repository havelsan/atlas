
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
    /// İdari Birim Tanımı
    /// </summary>
    public partial class AdministrativeUnitDefinitionForm : TTForm
    {
    /// <summary>
    /// İdari Birim
    /// </summary>
        protected TTObjectClasses.ResAdministrativeUnit _ResAdministrativeUnit
        {
            get { return (TTObjectClasses.ResAdministrativeUnit)_ttObject; }
        }

        protected ITTCheckBox IsmedicalWaste;
        protected ITTLabel labelLocation;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox tttextbox1;
        protected ITTLabel labelDeskPhoneNumber;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelStore;
        protected ITTCheckBox ttcheckbox2;
        protected ITTObjectListBox Store;
        protected ITTObjectListBox Hospital;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel3;
        protected ITTGrid ResourceSpecialities;
        protected ITTListBoxColumn Speciality;
        override protected void InitializeControls()
        {
            IsmedicalWaste = (ITTCheckBox)AddControl(new Guid("fe57b483-312b-46d6-b11a-0e565621f30e"));
            labelLocation = (ITTLabel)AddControl(new Guid("2cef6e95-b154-4c43-8d17-946bf17aad53"));
            Location = (ITTTextBox)AddControl(new Guid("264ccd10-0863-4f93-ba80-efbd8f2e9ab4"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("7db8dd23-5ac8-4118-b9b3-f4012bac7586"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("971a51d2-a4d8-45d6-8c8e-6e46f894cd67"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("a2b7670e-be93-48ae-9a6d-ca3eb0686a18"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("daf6cba5-d635-474c-a8aa-2153a00e2bd4"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("2475949f-3537-468c-ad6d-f3061a8e1071"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("9f018d07-8aba-46f4-826d-cb35e902fcf4"));
            labelStore = (ITTLabel)AddControl(new Guid("11f88dd0-eb7c-43ed-9457-fceb770b9cd9"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("7d96e3ca-1e2c-490e-93ce-884205ecec90"));
            Store = (ITTObjectListBox)AddControl(new Guid("6ef64621-972a-42f6-b98f-937ce30e4c46"));
            Hospital = (ITTObjectListBox)AddControl(new Guid("c6a8a138-bcca-4720-a549-07ec5af392d1"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("3614f128-466f-4419-bc7a-bbad25321873"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("e0a5a6d1-cec0-4f72-8757-daba2803488c"));
            ResourceSpecialities = (ITTGrid)AddControl(new Guid("4717296b-1eb4-481c-8aee-964187755ca4"));
            Speciality = (ITTListBoxColumn)AddControl(new Guid("9a1b128b-1b16-48c5-a5bc-e5458f6585d0"));
            base.InitializeControls();
        }

        public AdministrativeUnitDefinitionForm() : base("RESADMINISTRATIVEUNIT", "AdministrativeUnitDefinitionForm")
        {
        }

        protected AdministrativeUnitDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}