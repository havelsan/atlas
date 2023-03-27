
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
    /// Damga Vergisi Bilgileri
    /// </summary>
    public partial class StampTaxInfoForm : TTForm
    {
    /// <summary>
    /// Damga Vergisi Bilgileri
    /// </summary>
        protected TTObjectClasses.MhSStampTaxInfo _MhSStampTaxInfo
        {
            get { return (TTObjectClasses.MhSStampTaxInfo)_ttObject; }
        }

        protected ITTTextBox tttextbox6;
        protected ITTLabel labelTaxNumber;
        protected ITTLabel labelSlipJournalNo;
        protected ITTLabel labelPeriod;
        protected ITTLabel labelAddress;
        protected ITTLabel labelTaxDepartment;
        protected ITTTextBox TaxDepartment;
        protected ITTTextBox SlipJournalNo;
        protected ITTLabel labelGrossTotal;
        protected ITTTextBox Address;
        protected ITTTextBox ToWhom;
        protected ITTListDefComboBox ttlistdefcombobox1;
        protected ITTLabel labelToWhom;
        protected ITTTextBox TaxNumber;
        override protected void InitializeControls()
        {
            tttextbox6 = (ITTTextBox)AddControl(new Guid("9c9fb823-921d-4848-8991-0c6b04ddb2c2"));
            labelTaxNumber = (ITTLabel)AddControl(new Guid("3e11afb3-376c-476b-800a-10f2dd825540"));
            labelSlipJournalNo = (ITTLabel)AddControl(new Guid("f8236829-d0c3-47f8-bcbf-426ee9d3e768"));
            labelPeriod = (ITTLabel)AddControl(new Guid("e31d4c7a-9e61-4f04-861c-3c08eb6a9f7f"));
            labelAddress = (ITTLabel)AddControl(new Guid("acd14157-9803-445e-bf35-4dbbcaf6854c"));
            labelTaxDepartment = (ITTLabel)AddControl(new Guid("8175a094-aaec-4b87-a82c-38b4e8a4a838"));
            TaxDepartment = (ITTTextBox)AddControl(new Guid("616a7f6d-ec87-499e-958f-6156e430fd17"));
            SlipJournalNo = (ITTTextBox)AddControl(new Guid("640a1fbc-3d0f-4e1c-8ad4-868a455e1c2b"));
            labelGrossTotal = (ITTLabel)AddControl(new Guid("2a83ab7a-7261-4d6b-a330-a05d1b72a319"));
            Address = (ITTTextBox)AddControl(new Guid("623c5900-9c5c-494b-b9e3-d1e3d2742c09"));
            ToWhom = (ITTTextBox)AddControl(new Guid("78a2206b-e52d-4e1c-83b8-cdb14c4e7680"));
            ttlistdefcombobox1 = (ITTListDefComboBox)AddControl(new Guid("97f923ff-309e-4db2-be4a-c605d5e8272e"));
            labelToWhom = (ITTLabel)AddControl(new Guid("ca6ae848-e54e-426a-a28b-eedf65234361"));
            TaxNumber = (ITTTextBox)AddControl(new Guid("28b464f5-ff3d-4ebe-86e4-e646f2d71b97"));
            base.InitializeControls();
        }

        public StampTaxInfoForm() : base("MHSSTAMPTAXINFO", "StampTaxInfoForm")
        {
        }

        protected StampTaxInfoForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}