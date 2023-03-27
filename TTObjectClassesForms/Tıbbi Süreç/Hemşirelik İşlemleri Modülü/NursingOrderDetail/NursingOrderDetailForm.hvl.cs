
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
    /// Hemşire Takip Gözlem
    /// </summary>
    public partial class NursingOrderDetailForm : SubactionProcedureFlowableForm
    {
    /// <summary>
    /// Hemşire Takip Gözlem Uygulaması (Klinik İşlemleri)
    /// </summary>
        protected TTObjectClasses.NursingOrderDetail _NursingOrderDetail
        {
            get { return (TTObjectClasses.NursingOrderDetail)_ttObject; }
        }

        protected ITTLabel labelNameResource;
        protected ITTTextBox NameResource;
        protected ITTTextBox Note;
        protected ITTMaskedTextBox ttmaskedResult;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel labelExacutionDate;
        protected ITTLabel labelNote;
        protected ITTDateTimePicker ExecutionDate;
        protected ITTLabel labelProcedure;
        protected ITTLabel labelResult;
        protected ITTObjectListBox ProcedureObject;
        protected ITTObjectListBox ResultBySelection;
        protected ITTLabel lableSonucCombo;
        protected ITTLabel labelNabız;
        protected ITTMaskedTextBox ttmaskedResultPulse;
        protected ITTLabel ttlabelBloodPressure;
        protected ITTMaskedTextBox ttmaskedBloodPressure;
        override protected void InitializeControls()
        {
            labelNameResource = (ITTLabel)AddControl(new Guid("7424be76-65cb-4afd-bb22-eb1f89db1d73"));
            NameResource = (ITTTextBox)AddControl(new Guid("22844e60-e9b8-4744-a476-37d874138ace"));
            Note = (ITTTextBox)AddControl(new Guid("56d5ee80-6c38-4aa0-8744-d12095a6b4c4"));
            ttmaskedResult = (ITTMaskedTextBox)AddControl(new Guid("3a462b24-dd74-4f2e-885e-5239aae9faa7"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("f04750ce-4a79-419b-92b8-7a98af3be951"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("6061fbbe-4415-4977-9cb2-6c9fdcf45982"));
            labelExacutionDate = (ITTLabel)AddControl(new Guid("3feec029-5747-4c23-9cb8-54a3e44b95df"));
            labelNote = (ITTLabel)AddControl(new Guid("6a26ea1b-a3e7-439a-8bc0-61c59d91631e"));
            ExecutionDate = (ITTDateTimePicker)AddControl(new Guid("0786e02b-273b-4277-b409-7df20668276e"));
            labelProcedure = (ITTLabel)AddControl(new Guid("22372d77-4c7a-4aa6-acc9-9588202cc0dd"));
            labelResult = (ITTLabel)AddControl(new Guid("30f62683-278f-409c-8ebf-9a1ad6cf5bd5"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("aeb9211a-c65c-48f4-a7d7-b22961e39d94"));
            ResultBySelection = (ITTObjectListBox)AddControl(new Guid("c6edaaa5-edc8-4231-a715-f183bfa203b0"));
            lableSonucCombo = (ITTLabel)AddControl(new Guid("99e1481e-9199-46ae-a28c-3b625caa34f8"));
            labelNabız = (ITTLabel)AddControl(new Guid("cddd6e79-cca1-4dbf-b60c-1d4bfda977de"));
            ttmaskedResultPulse = (ITTMaskedTextBox)AddControl(new Guid("70cf372f-4d51-400b-a9d3-ce2c9620d58d"));
            ttlabelBloodPressure = (ITTLabel)AddControl(new Guid("fa1b6ffa-3b96-428c-9a70-2b888eb32b0d"));
            ttmaskedBloodPressure = (ITTMaskedTextBox)AddControl(new Guid("d8068467-ae4b-49c6-9a5c-5236effec02a"));
            base.InitializeControls();
        }

        public NursingOrderDetailForm() : base("NURSINGORDERDETAIL", "NursingOrderDetailForm")
        {
        }

        protected NursingOrderDetailForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}