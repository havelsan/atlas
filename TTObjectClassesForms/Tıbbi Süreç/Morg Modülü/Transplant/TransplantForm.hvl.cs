
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
    /// Hasta Nakil İşlemleri
    /// </summary>
    public partial class TransplantForm : TTForm
    {
        protected TTObjectClasses.Transplant _Transplant
        {
            get { return (TTObjectClasses.Transplant)_ttObject; }
        }

        protected ITTDateTimePicker DateTimeOfDeath;
        protected ITTObjectListBox MernisDeathReason;
        protected ITTLabel labelDoctorFixed;
        protected ITTEnumComboBox StatisticalDeathReason;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelDateTimeOfDeath;
        protected ITTLabel labelReasonForDeath;
        protected ITTLabel labelSenderDoctor;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTObjectListBox DoctorFixed;
        protected ITTObjectListBox SenderDoctor;
        override protected void InitializeControls()
        {
            DateTimeOfDeath = (ITTDateTimePicker)AddControl(new Guid("406a073e-d816-4ae4-9449-3a18ccf5a4a2"));
            MernisDeathReason = (ITTObjectListBox)AddControl(new Guid("abd415ab-85e7-41a2-b814-dd5db5054236"));
            labelDoctorFixed = (ITTLabel)AddControl(new Guid("d5cd911b-12b7-4d08-a444-85593470a772"));
            StatisticalDeathReason = (ITTEnumComboBox)AddControl(new Guid("1adf7d5d-21c0-4409-b9b2-19ac26a60c3d"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("fd7cf5a9-0b4b-49ea-8c34-8a9213765594"));
            labelDateTimeOfDeath = (ITTLabel)AddControl(new Guid("94a1458d-a815-43b1-b0a9-7beb8b8ab198"));
            labelReasonForDeath = (ITTLabel)AddControl(new Guid("18836c1b-1b04-4507-ab15-f1b12afa9676"));
            labelSenderDoctor = (ITTLabel)AddControl(new Guid("19fc0e62-ce3b-4942-93b1-fe462911847e"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("6852e2b0-ac91-4f25-b9a9-8fbe9a7180ee"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("3e6d08b9-84c9-49ed-9f96-4f809334bf3d"));
            DoctorFixed = (ITTObjectListBox)AddControl(new Guid("fff7bee1-31a3-48f2-a9f1-898a76f05c51"));
            SenderDoctor = (ITTObjectListBox)AddControl(new Guid("378b864c-5dbc-4311-ae2f-e5a2ed25c2b0"));
            base.InitializeControls();
        }

        public TransplantForm() : base("TRANSPLANT", "TransplantForm")
        {
        }

        protected TransplantForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}