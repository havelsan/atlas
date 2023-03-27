
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
    /// Yeni Firma Formu
    /// </summary>
    public partial class NewFirmForm : TTForm
    {
    /// <summary>
    /// DE_Firma Tanımı
    /// </summary>
        protected TTObjectClasses.MNZFirm _MNZFirm
        {
            get { return (TTObjectClasses.MNZFirm)_ttObject; }
        }

        protected ITTLabel labelFaxNumber;
        protected ITTLabel labelAddressLine2;
        protected ITTTextBox Name;
        protected ITTTextBox Title;
        protected ITTDateTimePicker EndDate;
        protected ITTGroupBox ttgroupbox3;
        protected ITTTextBox LiablePersonTitle;
        protected ITTLabel labelLiablePersonTitle;
        protected ITTLabel labelDescription;
        protected ITTLabel labelRegistryNo;
        protected ITTLabel labelName;
        protected ITTLabel labelEndDate;
        protected ITTTextBox AddressLine1;
        protected ITTLabel labelTitle;
        protected ITTTextBox LiablePerson;
        protected ITTLabel labelLiablePerson;
        protected ITTLabel labelTown;
        protected ITTTextBox RegistryNo;
        protected ITTTextBox FaxNumber;
        protected ITTLabel labelStartDate;
        protected ITTObjectListBox City;
        protected ITTObjectListBox Town;
        protected ITTLabel labelPhoneNumber;
        protected ITTLabel labelAddressLine1;
        protected ITTGroupBox ttgroupbox2;
        protected ITTTextBox Description;
        protected ITTGrid ttgrid1;
        protected ITTDateTimePicker StartDate;
        protected ITTTextBox AddressLine2;
        protected ITTTextBox PhoneNumber;
        protected ITTLabel labelCity;
        override protected void InitializeControls()
        {
            labelFaxNumber = (ITTLabel)AddControl(new Guid("923801d7-bcc3-4c3b-8d91-1bfea7045bd1"));
            labelAddressLine2 = (ITTLabel)AddControl(new Guid("90c99775-9b95-41f4-9ede-edc373da3bcb"));
            Name = (ITTTextBox)AddControl(new Guid("b561d36c-f6f2-41f1-a056-efbd76ec6d8f"));
            Title = (ITTTextBox)AddControl(new Guid("1abfc631-e6ed-4aa3-8de6-cce36cb1dac9"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("95f0f04c-7bb2-42c0-9e46-bacb90c82159"));
            ttgroupbox3 = (ITTGroupBox)AddControl(new Guid("a46776a9-6e32-4c88-bd89-bd8e6f7ae905"));
            LiablePersonTitle = (ITTTextBox)AddControl(new Guid("f637f5eb-587d-4070-8ae3-a8c1f7bd5b4c"));
            labelLiablePersonTitle = (ITTLabel)AddControl(new Guid("47e71784-1895-4f1c-9dd8-a78eb39a41f2"));
            labelDescription = (ITTLabel)AddControl(new Guid("4803d8f3-f36a-4394-b33b-ac4bd5417165"));
            labelRegistryNo = (ITTLabel)AddControl(new Guid("5bda0180-933d-44f8-b16d-a30d99bd9502"));
            labelName = (ITTLabel)AddControl(new Guid("893b9302-c029-4e9d-b0ba-7e0658477d10"));
            labelEndDate = (ITTLabel)AddControl(new Guid("66e0ce53-a677-4cb3-95e9-822d419753ed"));
            AddressLine1 = (ITTTextBox)AddControl(new Guid("60227b2f-68b9-4fc8-909c-59cd43c46a5e"));
            labelTitle = (ITTLabel)AddControl(new Guid("b26df8aa-cc10-45db-b42e-563c3bf68d7f"));
            LiablePerson = (ITTTextBox)AddControl(new Guid("e587d5d7-a81c-490c-9ccc-ea7156cc3630"));
            labelLiablePerson = (ITTLabel)AddControl(new Guid("23720839-42ff-4d6a-8290-547f19cde553"));
            labelTown = (ITTLabel)AddControl(new Guid("b7feab4f-09be-4e9f-b648-525045c5b0ba"));
            RegistryNo = (ITTTextBox)AddControl(new Guid("a34875bf-5dd0-41ee-a1c6-47fd7a370bbf"));
            FaxNumber = (ITTTextBox)AddControl(new Guid("cfa9ceca-e7c5-4c77-bc5b-7eccb52c77db"));
            labelStartDate = (ITTLabel)AddControl(new Guid("9287fd71-72e9-429d-bbf6-539062758fbe"));
            City = (ITTObjectListBox)AddControl(new Guid("1adf2498-2885-4f79-adff-4e3aec5cafa2"));
            Town = (ITTObjectListBox)AddControl(new Guid("d8007648-82e4-4963-af29-61016853094e"));
            labelPhoneNumber = (ITTLabel)AddControl(new Guid("5da7d22e-b8fd-4f0b-99f3-43ef663630a1"));
            labelAddressLine1 = (ITTLabel)AddControl(new Guid("3cb7207c-6e8a-483b-b471-33e271690555"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("b082cf08-d57a-4ded-886c-212d33ed18d5"));
            Description = (ITTTextBox)AddControl(new Guid("abb6ff77-bed0-42d4-be30-340edb1aa8ef"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("624e728c-48b5-4820-9a17-25cea24365a4"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("1427a0dc-4df6-45aa-8cf4-172a76152f4e"));
            AddressLine2 = (ITTTextBox)AddControl(new Guid("1894370a-9e97-4daa-a6b3-14f4df896054"));
            PhoneNumber = (ITTTextBox)AddControl(new Guid("8026a512-5e67-4a34-8f3e-908aa39cb2ad"));
            labelCity = (ITTLabel)AddControl(new Guid("ee7e8ec6-2541-4e9f-b106-f653d06caad4"));
            base.InitializeControls();
        }

        public NewFirmForm() : base("MNZFIRM", "NewFirmForm")
        {
        }

        protected NewFirmForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}