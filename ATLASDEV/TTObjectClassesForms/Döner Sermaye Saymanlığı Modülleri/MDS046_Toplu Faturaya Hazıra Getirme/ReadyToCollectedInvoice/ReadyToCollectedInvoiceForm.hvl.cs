
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
    /// Toplu Faturaya Hazırlama
    /// </summary>
    public partial class ReadyToCollectedInvoiceForm : TTForm
    {
    /// <summary>
    /// Toplu Faturaya Hazırlama İşlemi
    /// </summary>
        protected TTObjectClasses.ReadyToCollectedInvoice _ReadyToCollectedInvoice
        {
            get { return (TTObjectClasses.ReadyToCollectedInvoice)_ttObject; }
        }

        protected ITTLabel labelSTARTDATE;
        protected ITTDateTimePicker STARTDATE;
        protected ITTLabel labelPATIENTSTATUS;
        protected ITTEnumComboBox PATIENTSTATUS;
        protected ITTLabel labelENDDATE;
        protected ITTDateTimePicker ENDDATE;
        protected ITTTextBox CASHIERNAME;
        protected ITTTextBox CASHIERLOGID;
        protected ITTTextBox CASHOFFICENAME;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel11;
        protected ITTGrid GRIDPATIENTLIST;
        protected ITTDateTimePickerColumn OPENINGDATE;
        protected ITTTextBoxColumn TCKIMLIKNO;
        protected ITTTextBoxColumn HOSPITALPROTOCOLNO;
        protected ITTTextBoxColumn PATIENTNAME;
        protected ITTTextBoxColumn PATIENTSURNAME;
        protected ITTTextBoxColumn PTOTALPRICE;
        protected ITTTextBoxColumn ERRORMESSAGE;
        protected ITTStateComboBoxColumn ReadyToCollectedInvoiceCurrentStateDefID;
        protected ITTLabel ttlabel1;
        protected ITTButton MakeNewButton;
        protected ITTEnumComboBox PROCEDUREGROUP;
        protected ITTLabel labelPROCEDUREGROUP;
        override protected void InitializeControls()
        {
            labelSTARTDATE = (ITTLabel)AddControl(new Guid("db721c00-3649-4d5f-a19c-25975a0e5921"));
            STARTDATE = (ITTDateTimePicker)AddControl(new Guid("32426792-5c35-431e-8378-733e8cb9307f"));
            labelPATIENTSTATUS = (ITTLabel)AddControl(new Guid("c0a1c397-7a56-40b8-a4ab-8837708e0222"));
            PATIENTSTATUS = (ITTEnumComboBox)AddControl(new Guid("0bbdce70-c484-4c73-98cd-41b66b8324d5"));
            labelENDDATE = (ITTLabel)AddControl(new Guid("0af8d342-b2fd-4af2-a869-8378127d4b63"));
            ENDDATE = (ITTDateTimePicker)AddControl(new Guid("2cde6f27-4611-443e-95ac-e275d960e638"));
            CASHIERNAME = (ITTTextBox)AddControl(new Guid("614ac94d-98a0-4e89-8b41-15bf83facec6"));
            CASHIERLOGID = (ITTTextBox)AddControl(new Guid("f2b6dd5e-2c7b-4052-84b3-9e2dcad492d9"));
            CASHOFFICENAME = (ITTTextBox)AddControl(new Guid("7d9c8cd8-c3b0-4336-8f9e-a133b1895210"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("683e4500-91c0-4688-a85e-e60d4a1f42b1"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("749769ce-8d76-43fc-99aa-3a8a6a03aa13"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("3edfc99c-e295-48d0-b7f0-66889b3fe5e0"));
            GRIDPATIENTLIST = (ITTGrid)AddControl(new Guid("b36b538e-b76a-4075-b7e0-738bec512a81"));
            OPENINGDATE = (ITTDateTimePickerColumn)AddControl(new Guid("ebe811b7-c3d9-4458-a196-313bb29efc53"));
            TCKIMLIKNO = (ITTTextBoxColumn)AddControl(new Guid("bea5c4fd-4402-426c-afc9-ff626851eee6"));
            HOSPITALPROTOCOLNO = (ITTTextBoxColumn)AddControl(new Guid("130e6f0b-7dad-400b-b194-51215fe1e9e6"));
            PATIENTNAME = (ITTTextBoxColumn)AddControl(new Guid("d5e96646-574c-4094-a205-1f870eafbaf6"));
            PATIENTSURNAME = (ITTTextBoxColumn)AddControl(new Guid("3911e2c2-c3f9-4fdf-979f-5daa7f1fec53"));
            PTOTALPRICE = (ITTTextBoxColumn)AddControl(new Guid("200f4ed7-3c80-4dad-b0f0-4ff2df2e933a"));
            ERRORMESSAGE = (ITTTextBoxColumn)AddControl(new Guid("76e6ac35-6d77-4297-a782-b854ea5ab498"));
            ReadyToCollectedInvoiceCurrentStateDefID = (ITTStateComboBoxColumn)AddControl(new Guid("d879784b-99c5-4d44-8fb7-eca6f9cf3de0"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("29819b7a-d256-4c14-bb04-7a7c6057b1f8"));
            MakeNewButton = (ITTButton)AddControl(new Guid("5e722f81-e253-48b3-9562-32f6c36f1e22"));
            PROCEDUREGROUP = (ITTEnumComboBox)AddControl(new Guid("4894efc1-49bc-41d3-918b-d1d27359f3d3"));
            labelPROCEDUREGROUP = (ITTLabel)AddControl(new Guid("f7527a47-c0d6-4155-b39d-9a7d8898c27c"));
            base.InitializeControls();
        }

        public ReadyToCollectedInvoiceForm() : base("READYTOCOLLECTEDINVOICE", "ReadyToCollectedInvoiceForm")
        {
        }

        protected ReadyToCollectedInvoiceForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}