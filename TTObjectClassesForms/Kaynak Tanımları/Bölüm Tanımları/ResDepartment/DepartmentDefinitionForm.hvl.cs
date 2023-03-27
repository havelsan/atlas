
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
    /// Bölüm Tanımı
    /// </summary>
    public partial class DepartmentDefinitionForm : TTForm
    {
    /// <summary>
    /// Bölüm 
    /// </summary>
        protected TTObjectClasses.ResDepartment _ResDepartment
        {
            get { return (TTObjectClasses.ResDepartment)_ttObject; }
        }

        protected ITTCheckBox ShownInKiosk;
        protected ITTObjectListBox Bina;
        protected ITTLabel ttlabel4;
        protected ITTTextBox textContactAddress;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox ActionCancelledTime;
        protected ITTTextBox textContactPhone;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTLabel labelStore;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTCheckBox ttcheckbox2;
        protected ITTObjectListBox Store;
        protected ITTLabel ttlabel3;
        protected ITTGrid ResourceSpecialities;
        protected ITTListBoxColumn Speciality;
        protected ITTLabel labelActionCancelledTime;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel6;
        protected ITTLabel labelLocation;
        protected ITTLabel labelDeskPhoneNumber;
        override protected void InitializeControls()
        {
            ShownInKiosk = (ITTCheckBox)AddControl(new Guid("87f8f415-217a-49eb-9457-25218e4ae7f7"));
            Bina = (ITTObjectListBox)AddControl(new Guid("c1b2ed9a-958b-4905-a15e-ed0810a12bcf"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("20739c8c-480c-4af8-855d-dbf84d4a59ce"));
            textContactAddress = (ITTTextBox)AddControl(new Guid("63c2c8fc-5a87-4602-82a8-c032e92c7a19"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("14f68a55-993c-4ffc-99fa-0dcfb0928481"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("7d0504e7-df4f-46a3-a59e-3ed793574fe9"));
            ActionCancelledTime = (ITTTextBox)AddControl(new Guid("1f9fc8ab-1771-4c82-a9ea-a5b6c2cff0f5"));
            textContactPhone = (ITTTextBox)AddControl(new Guid("f8c3e185-b52c-484f-be3c-fc14e0bf9ad4"));
            Location = (ITTTextBox)AddControl(new Guid("8161183d-16f6-42aa-857f-f782c72342b4"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("d4f2117e-9fd1-4db9-bbdb-97c82f1bcef8"));
            labelStore = (ITTLabel)AddControl(new Guid("0b145009-d16d-4759-82de-9e4566e4f987"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("b5478df6-36ae-4be0-9110-1b492c7b0b00"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("6c0c8cbf-e77c-4a77-a958-a6491b9d3053"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("cf474f8d-1adc-4af1-8b23-08979659d2ab"));
            Store = (ITTObjectListBox)AddControl(new Guid("af345f1e-96a8-461e-92da-3f5a31b2ba3f"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("70e2c49e-98da-4058-8063-fee4fa325889"));
            ResourceSpecialities = (ITTGrid)AddControl(new Guid("b5f34b30-c210-43d0-8e0e-a2f911d7ae05"));
            Speciality = (ITTListBoxColumn)AddControl(new Guid("b4161cfe-d91c-4668-9d03-67e74b54038c"));
            labelActionCancelledTime = (ITTLabel)AddControl(new Guid("8c6d85a4-a00e-443d-9e17-27c5f75e7e9c"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("95721db7-6623-46b1-a11f-0b0e62beb696"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("d1255529-3030-45d5-b20c-cc90acdcba0c"));
            labelLocation = (ITTLabel)AddControl(new Guid("3208d2bf-b4dd-4c8d-83e9-2792013c40c3"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("51dd0756-530c-40bd-844d-5f4c1c864c8c"));
            base.InitializeControls();
        }

        public DepartmentDefinitionForm() : base("RESDEPARTMENT", "DepartmentDefinitionForm")
        {
        }

        protected DepartmentDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}