
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
    /// Klinik Onay
    /// </summary>
    public partial class ClinicApprovalForm : RepairBaseForm
    {
    /// <summary>
    /// Onarım
    /// </summary>
        protected TTObjectClasses.Repair _Repair
        {
            get { return (TTObjectClasses.Repair)_ttObject; }
        }

        protected ITTObjectListBox ttobjectlistbox2;
        protected ITTLabel labelDescription;
        protected ITTLabel labelRequestNO;
        protected ITTLabel ttlabel4;
        protected ITTDateTimePicker RequestDate;
        protected ITTObjectListBox FixedAsset;
        protected ITTTextBox Description;
        protected ITTTextBox RequestNO;
        protected ITTObjectListBox FromResource;
        protected ITTLabel labelFromResource;
        protected ITTLabel labelFixedAsset;
        protected ITTGrid ItemEquipmentsGrid;
        protected ITTTextBoxColumn ItemName;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn Comments;
        protected ITTLabel ttlabel5;
        protected ITTTextBox tttextbox3;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelRequestDate;
        protected ITTObjectListBox Stage;
        protected ITTLabel ttlabel6;
        override protected void InitializeControls()
        {
            ttobjectlistbox2 = (ITTObjectListBox)AddControl(new Guid("4921d64d-f45f-421f-bc55-8f7617bceae8"));
            labelDescription = (ITTLabel)AddControl(new Guid("425123f5-5928-4e89-8418-10baca7ad945"));
            labelRequestNO = (ITTLabel)AddControl(new Guid("41ff6390-7282-4773-9a59-182e5d0d000b"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("bb32d630-a5ab-4152-8913-2d572d1112f3"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("ef1c2f76-5c9c-47e0-b5bd-304775e0afb0"));
            FixedAsset = (ITTObjectListBox)AddControl(new Guid("216a59a2-7314-4406-ac8f-7fd423da137a"));
            Description = (ITTTextBox)AddControl(new Guid("518971e7-8004-4f7d-8a59-842df286b369"));
            RequestNO = (ITTTextBox)AddControl(new Guid("c34a63b7-4fae-4a1a-b093-89753c76f341"));
            FromResource = (ITTObjectListBox)AddControl(new Guid("d70f5b21-6fd8-4b0b-8efd-b057d2e01f8f"));
            labelFromResource = (ITTLabel)AddControl(new Guid("21ee26e1-a6d4-4fdc-8d8c-c81e16e58581"));
            labelFixedAsset = (ITTLabel)AddControl(new Guid("b2452e4f-33db-4734-a85e-d91ca39adbe5"));
            ItemEquipmentsGrid = (ITTGrid)AddControl(new Guid("c0e5326c-7533-4455-8296-e56ebe404159"));
            ItemName = (ITTTextBoxColumn)AddControl(new Guid("d500b3cc-8277-41e7-81ba-5817ede98341"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("00852f96-5924-4d2d-8c59-ea37a32e0ad0"));
            Comments = (ITTTextBoxColumn)AddControl(new Guid("b01f1701-ee27-41cc-9c2a-fce0eeba5406"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("6dd3ebb5-9a4f-437c-9f79-edc1908b02df"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("e2d448be-154a-4910-9032-f2c515007b81"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("11ee90c5-30b6-4d66-8ba6-fb7aa72458d9"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("bb2b324c-5be0-4120-8ad2-fec605560444"));
            Stage = (ITTObjectListBox)AddControl(new Guid("fdbff9a0-1f3b-4de1-9bdc-e11775fa772c"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("9f860053-62a1-4e9b-83ae-09836f351e98"));
            base.InitializeControls();
        }

        public ClinicApprovalForm() : base("REPAIR", "ClinicApprovalForm")
        {
        }

        protected ClinicApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}