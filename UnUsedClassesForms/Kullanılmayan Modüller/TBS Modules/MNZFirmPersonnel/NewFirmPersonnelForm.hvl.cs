
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
    /// Yeni Firma Personeli
    /// </summary>
    public partial class NewFirmPersonnel : TTForm
    {
    /// <summary>
    /// Firma Personeli
    /// </summary>
        protected TTObjectClasses.MNZFirmPersonnel _MNZFirmPersonnel
        {
            get { return (TTObjectClasses.MNZFirmPersonnel)_ttObject; }
        }

        protected ITTLabel Ünvanı;
        protected ITTLabel labelSurname;
        protected ITTLabel labelDescription;
        protected ITTTextBox textBoxFatherName;
        protected ITTTextBox textBoxMotherName;
        protected ITTLabel labelFirm;
        protected ITTLabel labelNationalIdentity;
        protected ITTLabel labelHomePhone;
        protected ITTTextBox LisencePlate;
        protected ITTLabel labelMotherName;
        protected ITTLabel labelName;
        protected ITTGrid PersonnelVisitGrid;
        protected ITTLabel labelFatherName;
        protected ITTTextBox CellPhone;
        protected ITTLabel labelTitle;
        protected ITTLabel labelLisencePlate;
        protected ITTLabel labelCellPhone;
        protected ITTTextBox HomePhone;
        protected ITTDateTimePicker dateTimePickerBirthDate;
        protected ITTLabel labelBirthDate;
        protected ITTGroupBox ttgroupbox1;
        protected ITTObjectListBox Firm;
        protected ITTTextBox Name;
        protected ITTObjectListBox ttobjectlistbox3;
        protected ITTTextBox NationalIdentity;
        protected ITTTextBox Description;
        protected ITTTextBox Surname;
        protected ITTTextBox Title;
        override protected void InitializeControls()
        {
            Ünvanı = (ITTLabel)AddControl(new Guid("5dd1b70e-58a4-47d6-9028-08af8da56edc"));
            labelSurname = (ITTLabel)AddControl(new Guid("45f3af2c-bf53-41f7-8bbd-f4ab1de12f13"));
            labelDescription = (ITTLabel)AddControl(new Guid("dfacb9c2-a7cb-4628-a711-fe0fc1212b9c"));
            textBoxFatherName = (ITTTextBox)AddControl(new Guid("a52f3eb5-3bef-4bc6-85f6-fce5e9cdc150"));
            textBoxMotherName = (ITTTextBox)AddControl(new Guid("af6f0ef9-3351-459d-a675-c00aea5508de"));
            labelFirm = (ITTLabel)AddControl(new Guid("f3584384-14c2-4946-b5f6-e9d0aeec2680"));
            labelNationalIdentity = (ITTLabel)AddControl(new Guid("8b1cdbeb-a8f8-4de5-8ae9-c6841279a7c8"));
            labelHomePhone = (ITTLabel)AddControl(new Guid("fe231a96-af9f-4079-a269-de11a548eb28"));
            LisencePlate = (ITTTextBox)AddControl(new Guid("cea19113-7eb8-47c7-95a7-b3ba2fd95747"));
            labelMotherName = (ITTLabel)AddControl(new Guid("1f15dc54-8cd6-4af7-ac6c-ad7b24817de1"));
            labelName = (ITTLabel)AddControl(new Guid("4dc2cfda-510a-4bd1-bfba-9cc8451d91c7"));
            PersonnelVisitGrid = (ITTGrid)AddControl(new Guid("1e72006f-6ff9-4784-831b-6a9562281ac5"));
            labelFatherName = (ITTLabel)AddControl(new Guid("bb24cc38-67d1-4a35-ae1f-6b291118b57a"));
            CellPhone = (ITTTextBox)AddControl(new Guid("1f32df77-4e16-4958-8ebb-66a3677a5710"));
            labelTitle = (ITTLabel)AddControl(new Guid("b59378dc-2a61-46e5-a2b6-4a8246853cbb"));
            labelLisencePlate = (ITTLabel)AddControl(new Guid("de6b8f15-6fdb-4b4a-ba7b-5efef661a5a5"));
            labelCellPhone = (ITTLabel)AddControl(new Guid("82dc203c-a265-4da1-9429-4208e781704c"));
            HomePhone = (ITTTextBox)AddControl(new Guid("a9fcf673-5721-49c1-ae7d-31af231f8fbe"));
            dateTimePickerBirthDate = (ITTDateTimePicker)AddControl(new Guid("7c5449cb-0295-459b-a64f-25db6765099d"));
            labelBirthDate = (ITTLabel)AddControl(new Guid("c77f68fc-73bd-428b-9678-2e88c7fc94a8"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("c553ff86-8cd6-4df4-a778-2b979b08d79c"));
            Firm = (ITTObjectListBox)AddControl(new Guid("4c9f0a0f-d0e0-4117-b4dd-3759d5f1c22d"));
            Name = (ITTTextBox)AddControl(new Guid("bdc34455-9fb7-4d19-95c8-1d1ecc4ad68d"));
            ttobjectlistbox3 = (ITTObjectListBox)AddControl(new Guid("77302614-8e94-4431-b7f2-249c5cf03a97"));
            NationalIdentity = (ITTTextBox)AddControl(new Guid("0710546b-c4d9-4f9a-9795-04d9bc9740b7"));
            Description = (ITTTextBox)AddControl(new Guid("97f7f977-a08a-4df0-874f-082a8f5e9d90"));
            Surname = (ITTTextBox)AddControl(new Guid("2e645ce3-1f05-456a-a930-ee9f0555cd88"));
            Title = (ITTTextBox)AddControl(new Guid("ea51ee2e-c51d-4b81-8336-fb77d18a7dc0"));
            base.InitializeControls();
        }

        public NewFirmPersonnel() : base("MNZFIRMPERSONNEL", "NewFirmPersonnel")
        {
        }

        protected NewFirmPersonnel(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}