
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
    public partial class TreatmentDischargeSearchForm : TTUnboundForm
    {
        protected ITTButton cmdListToExcel;
        protected ITTGrid TreatmentsGrid;
        protected ITTTextBoxColumn PatientUniquerefno;
        protected ITTTextBoxColumn PatientNameSurname;
        protected ITTDateTimePickerColumn PatientBirthDate;
        protected ITTTextBoxColumn PatientGender;
        protected ITTTextBoxColumn Emergency;
        protected ITTDateTimePickerColumn RequestDate;
        protected ITTDateTimePickerColumn WorklistDate;
        protected ITTDateTimePickerColumn DischargeDate;
        protected ITTTextBoxColumn DischargeType;
        protected ITTTextBoxColumn DischargeToPlace;
        protected ITTTextBoxColumn Conclusion;
        protected ITTTextBoxColumn ProcedureSpeciality;
        protected ITTTextBoxColumn ProtocolNo;
        protected ITTTextBoxColumn ProcedureDoctor;
        protected ITTButton cmdList;
        protected ITTLabel ttlabel3;
        protected ITTDateTimePicker txtRequestDateMin;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel12;
        protected ITTDateTimePicker txtRequestDateMax;
        protected ITTButton cmdExportToExcel;
        override protected void InitializeControls()
        {
            cmdListToExcel = (ITTButton)AddControl(new Guid("bf9b7e32-6756-4b60-8437-89ba707bfbec"));
            TreatmentsGrid = (ITTGrid)AddControl(new Guid("62d0fcc6-6e3e-4ab0-942b-49cbed614dcd"));
            PatientUniquerefno = (ITTTextBoxColumn)AddControl(new Guid("42fddb52-1363-4d2e-9eea-81d65e419a21"));
            PatientNameSurname = (ITTTextBoxColumn)AddControl(new Guid("37a8046f-9913-4375-8160-5b94d74d78f2"));
            PatientBirthDate = (ITTDateTimePickerColumn)AddControl(new Guid("c7ed269a-341d-47a9-b24b-7e146d3fac71"));
            PatientGender = (ITTTextBoxColumn)AddControl(new Guid("61a2bba2-0e4a-482e-80cf-fdbfa2121376"));
            Emergency = (ITTTextBoxColumn)AddControl(new Guid("861998db-6a2d-4fe6-a84b-68b9c2fbb9eb"));
            RequestDate = (ITTDateTimePickerColumn)AddControl(new Guid("aa2a95bf-8914-4fd2-9f39-47a87dd289c6"));
            WorklistDate = (ITTDateTimePickerColumn)AddControl(new Guid("4dbb2cc4-c2c3-4004-b57b-1df6c0910658"));
            DischargeDate = (ITTDateTimePickerColumn)AddControl(new Guid("95be81bf-2a13-48ad-9625-a97a38633961"));
            DischargeType = (ITTTextBoxColumn)AddControl(new Guid("ccc917e6-747c-4f69-aed7-6c4672302837"));
            DischargeToPlace = (ITTTextBoxColumn)AddControl(new Guid("f114c73f-d62a-47d8-9497-d9a8dc3cfc6a"));
            Conclusion = (ITTTextBoxColumn)AddControl(new Guid("536c9462-a084-4879-a187-23e2c929e317"));
            ProcedureSpeciality = (ITTTextBoxColumn)AddControl(new Guid("33ea4a20-47d5-44ae-ac3d-989917a1a824"));
            ProtocolNo = (ITTTextBoxColumn)AddControl(new Guid("85806623-a10a-4273-979a-b3c6e3c5589d"));
            ProcedureDoctor = (ITTTextBoxColumn)AddControl(new Guid("a99d9bb9-3375-4adc-8636-408cdae91201"));
            cmdList = (ITTButton)AddControl(new Guid("714b1014-9b5f-4791-b288-216f86189815"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("30433444-6ac4-4be2-810b-9e8c21568bb6"));
            txtRequestDateMin = (ITTDateTimePicker)AddControl(new Guid("8fc55cb1-7e4d-42f1-b0d6-1068edf27505"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("64af9f6f-97ee-4e93-9a31-2f9feee697f0"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("240f1540-303b-469f-9a6a-3cee5b950aea"));
            txtRequestDateMax = (ITTDateTimePicker)AddControl(new Guid("c23ec994-e045-429d-8c49-155c097bcb8a"));
            cmdExportToExcel = (ITTButton)AddControl(new Guid("183dd444-8b0d-4f00-8a29-4d4d7a424397"));
            base.InitializeControls();
        }

        public TreatmentDischargeSearchForm() : base("TreatmentDischargeSearchForm")
        {
        }

        protected TreatmentDischargeSearchForm(string formDefName) : base(formDefName)
        {
        }
    }
}