
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
    /// Kan Bankası Kan Ürünü İstek Açıklama Formu
    /// </summary>
    public partial class BloodProductRequestInfoForm : TTForm
    {
    /// <summary>
    /// Kan Ürünü İstek
    /// </summary>
        protected TTObjectClasses.BloodProductRequest _BloodProductRequest
        {
            get { return (TTObjectClasses.BloodProductRequest)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTPanel pnlUrgent;
        protected ITTCheckBox chkWithTest;
        protected ITTCheckBox chkWithoutTests;
        protected ITTCheckBox chkUrgentCross;
        protected ITTCheckBox chkWithoutCross;
        protected ITTCheckBox chkNormal;
        protected ITTDateTimePicker dtTransfused;
        protected ITTDateTimePicker dtPregnancy;
        protected ITTCheckBox chkBlock;
        protected ITTCheckBox chkOther;
        protected ITTCheckBox chkHB;
        protected ITTCheckBox chkPrepare;
        protected ITTLabel ttlabel7;
        protected ITTCheckBox chkSurgery;
        protected ITTLabel ttlabel6;
        protected ITTCheckBox chkPregnancy;
        protected ITTLabel ttlabel5;
        protected ITTCheckBox chkTransfused;
        protected ITTLabel ttlabel4;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel2;
        protected ITTCheckBox chkUrgent;
        protected ITTCheckBox ttcheckbox4;
        protected ITTLabel ttlabel1;
        protected ITTCheckBox ttcheckbox5;
        protected ITTDateTimePicker dtRequirement;
        protected ITTLabel ttlabel3;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("4f5f1e16-8fb2-49df-9c86-ad200499fb5d"));
            pnlUrgent = (ITTPanel)AddControl(new Guid("83c514ee-0d84-4c8f-a046-e86a9980acb7"));
            chkWithTest = (ITTCheckBox)AddControl(new Guid("7e53ab8e-9b15-48cb-a7c8-bfe389c44ddc"));
            chkWithoutTests = (ITTCheckBox)AddControl(new Guid("a492ca60-33c1-4fc8-b61e-77403b3c5306"));
            chkUrgentCross = (ITTCheckBox)AddControl(new Guid("8bcd3d4f-7f53-469d-baed-ee99dd8d3408"));
            chkWithoutCross = (ITTCheckBox)AddControl(new Guid("2e84fa99-dfee-492a-afca-3dc7246e53c4"));
            chkNormal = (ITTCheckBox)AddControl(new Guid("19977e5c-e8d9-4ab7-85f0-127d4dd3068d"));
            dtTransfused = (ITTDateTimePicker)AddControl(new Guid("5a33b80a-891f-49d0-888d-379d8ef4c3a4"));
            dtPregnancy = (ITTDateTimePicker)AddControl(new Guid("176a922a-b98a-4d27-a481-c5fa2985d6e4"));
            chkBlock = (ITTCheckBox)AddControl(new Guid("f3521354-4ff1-40bb-9094-94e3d2fe72ff"));
            chkOther = (ITTCheckBox)AddControl(new Guid("54024d16-12eb-42c4-ad00-354cb4a8756d"));
            chkHB = (ITTCheckBox)AddControl(new Guid("e2c724a0-f14e-4946-88e3-52deb73ed89c"));
            chkPrepare = (ITTCheckBox)AddControl(new Guid("2da534ed-c1e7-4b56-8097-8b9d575e4d0f"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("55b31d05-6edd-4f31-afc4-607235cc497f"));
            chkSurgery = (ITTCheckBox)AddControl(new Guid("1ba70b83-b73a-4f6e-a96d-ef28f42ed3aa"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("4389fb10-1052-46f7-bc5f-61dc20eac084"));
            chkPregnancy = (ITTCheckBox)AddControl(new Guid("0ab6ec85-ec82-4c9f-aa50-ebd004a7b907"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("88ac9442-171e-4f42-9842-ae3d7c8021ca"));
            chkTransfused = (ITTCheckBox)AddControl(new Guid("d4aa9599-4bd2-4db5-b2a0-29deb6c44678"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("5e9eb277-d497-4657-9c4c-37d29ed6e875"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("bc5e3e1a-78cb-4967-b5ee-7449b44ce6d7"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("0fede35f-ef38-4582-af0f-022af2f52b5c"));
            chkUrgent = (ITTCheckBox)AddControl(new Guid("6c8f5b0f-9278-4b5c-8950-9ca4aad1267d"));
            ttcheckbox4 = (ITTCheckBox)AddControl(new Guid("1f3387b6-9140-4cef-a21b-62cc9b8b2d57"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("a9cdc328-1a2f-4220-8535-61545eb96e96"));
            ttcheckbox5 = (ITTCheckBox)AddControl(new Guid("4c2ebd6e-ac2f-4695-a61a-1a88251b7cd7"));
            dtRequirement = (ITTDateTimePicker)AddControl(new Guid("4ead39e9-e8f6-440e-9b19-4226147ffe55"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("402ca5fd-b981-41eb-a734-f23d61c9ae45"));
            base.InitializeControls();
        }

        public BloodProductRequestInfoForm() : base("BLOODPRODUCTREQUEST", "BloodProductRequestInfoForm")
        {
        }

        protected BloodProductRequestInfoForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}