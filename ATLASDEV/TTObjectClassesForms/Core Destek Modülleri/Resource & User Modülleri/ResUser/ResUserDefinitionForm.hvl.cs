
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
    /// Kullanıcı Bilgileri Yeni
    /// </summary>
    public partial class ResUserDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Kullanıcı
    /// </summary>
        protected TTObjectClasses.ResUser _ResUser
        {
            get { return (TTObjectClasses.ResUser)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTTextBox WorkPlace;
        protected ITTTextBox tttextbox3;
        protected ITTLabel labelWorkPlace;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTLabel labelWork;
        protected ITTGrid UserResources;
        protected ITTListBoxColumn SecMasterDepartment;
        protected ITTGrid ResUserUsableStores;
        protected ITTListBoxColumn StoreResUserUsableStore;
        protected ITTLabel labelEMail;
        protected ITTTextBox EMail;
        protected ITTTextBox txtUserName;
        protected ITTTextBox PhoneNumber;
        protected ITTTextBox Name;
        protected ITTTextBox Surname;
        protected ITTTextBox UniqueRefNo;
        protected ITTLabel lblUserName;
        protected ITTEnumComboBox UserTitle;
        protected ITTLabel labelTitle;
        protected ITTLabel labelUserType;
        protected ITTLabel labelPhoneNumber;
        protected ITTLabel labelUniqueRefNo;
        protected ITTEnumComboBox UserType;
        protected ITTCheckBox Active;
        protected ITTLabel labelName;
        protected ITTLabel labelSurname;
        protected ITTCheckBox chkTakesPerformanceScore;
        protected ITTGrid ResourceSpecialities;
        protected ITTCheckBoxColumn MainSpeciality;
        protected ITTListBoxColumn Speciality;
        protected ITTLabel labelResourceSpecialities;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("ac0ba5b4-202a-4375-a218-eb9fb6642c43"));
            WorkPlace = (ITTTextBox)AddControl(new Guid("a5583c54-f64a-4d76-a76b-6cb6815bd6d8"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("9f0dc4cf-aeb3-4417-bc2d-fa3fd496a67f"));
            labelWorkPlace = (ITTLabel)AddControl(new Guid("ec01de84-598e-47e9-88e3-2a57193aa2d0"));
            labelStore = (ITTLabel)AddControl(new Guid("2205731d-b51d-4499-8ef6-6da10e23c295"));
            Store = (ITTObjectListBox)AddControl(new Guid("3fe69571-b491-4124-b033-6d014fe27ca9"));
            labelWork = (ITTLabel)AddControl(new Guid("824e3dae-242a-4b55-a035-b1c302bada2c"));
            UserResources = (ITTGrid)AddControl(new Guid("37fba512-4c96-4e28-bd98-3355d85ee433"));
            SecMasterDepartment = (ITTListBoxColumn)AddControl(new Guid("186e7d54-4258-4d63-8ed8-4e12ec5a5d75"));
            ResUserUsableStores = (ITTGrid)AddControl(new Guid("3085d707-e529-4d4c-925b-2df20ced8bd6"));
            StoreResUserUsableStore = (ITTListBoxColumn)AddControl(new Guid("ad73ccdd-5741-44b5-a170-c605d8fee74e"));
            labelEMail = (ITTLabel)AddControl(new Guid("2ada0925-dbdf-4beb-94c7-29f0ba2364f9"));
            EMail = (ITTTextBox)AddControl(new Guid("361b5f82-83b9-49c6-a561-ee0260733c0d"));
            txtUserName = (ITTTextBox)AddControl(new Guid("afaa0087-27e4-4fde-b765-67368a494c47"));
            PhoneNumber = (ITTTextBox)AddControl(new Guid("9c93df5c-6874-451b-acab-5f924ebba48f"));
            Name = (ITTTextBox)AddControl(new Guid("fa7b7360-cf69-4ce9-9b42-9bc4e50fa5ea"));
            Surname = (ITTTextBox)AddControl(new Guid("4c872063-6250-4b2d-80c1-21d294c3cf9a"));
            UniqueRefNo = (ITTTextBox)AddControl(new Guid("9ce8f356-82b9-4a0c-a5be-ccee24def582"));
            lblUserName = (ITTLabel)AddControl(new Guid("898786f8-748c-4dac-ae0c-a9dd28b4dc47"));
            UserTitle = (ITTEnumComboBox)AddControl(new Guid("a2d89a3a-9fb2-492c-a75e-29edbeca6c89"));
            labelTitle = (ITTLabel)AddControl(new Guid("5b02c71a-ea7d-4039-b340-869325a60043"));
            labelUserType = (ITTLabel)AddControl(new Guid("8f2cd892-106b-497e-a3f6-2d0122c2d1a3"));
            labelPhoneNumber = (ITTLabel)AddControl(new Guid("56fa72ca-8af5-4f66-b9a8-469bfe5480fa"));
            labelUniqueRefNo = (ITTLabel)AddControl(new Guid("ea0d8d3f-03b1-4c98-86c5-48d76afcf6e8"));
            UserType = (ITTEnumComboBox)AddControl(new Guid("6a4a0958-2340-4c14-971b-4893b44bd4b9"));
            Active = (ITTCheckBox)AddControl(new Guid("09903490-904c-4fa7-9092-c917b5586605"));
            labelName = (ITTLabel)AddControl(new Guid("87befe9a-ff75-49fe-87a9-fd10f171bb9d"));
            labelSurname = (ITTLabel)AddControl(new Guid("2acdbc42-cb95-4669-8925-9ebba009e56e"));
            chkTakesPerformanceScore = (ITTCheckBox)AddControl(new Guid("794f11fa-90a4-4603-8c37-11e06d155879"));
            ResourceSpecialities = (ITTGrid)AddControl(new Guid("c39f7103-a242-4d02-b9a2-51c39347ced6"));
            MainSpeciality = (ITTCheckBoxColumn)AddControl(new Guid("54c246b5-230d-4ead-afa5-293fea0fbdf6"));
            Speciality = (ITTListBoxColumn)AddControl(new Guid("b7dc6782-aaad-4042-be31-e50d6cad70a9"));
            labelResourceSpecialities = (ITTLabel)AddControl(new Guid("2804bb99-fb29-4cee-b8b1-79174372fcdf"));
            base.InitializeControls();
        }

        public ResUserDefinitionForm() : base("RESUSER", "ResUserDefinitionForm")
        {
        }

        protected ResUserDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}