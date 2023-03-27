
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
    /// Onay
    /// </summary>
    public partial class IBFDemand_ClinicApproveForm : IBFDemand_BaseForm
    {
    /// <summary>
    /// İBF İstek Modülü ana sınıfıdır
    /// </summary>
        protected TTObjectClasses.IBFDemand _IBFDemand
        {
            get { return (TTObjectClasses.IBFDemand)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox2;
        protected ITTEnumComboBox IBFType;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTButton cmdApproveAll;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelDescription;
        protected ITTMaskedTextBox IBFYear;
        protected ITTLabel IBFYearLabel;
        protected ITTLabel labelActionDate;
        protected ITTLabel IBFTypeLabel;
        protected ITTTextBox RequestNO;
        protected ITTLabel labelID;
        protected ITTTextBox Description;
        protected ITTDateTimePicker RequestDate;
        override protected void InitializeControls()
        {
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("f61a4d8d-3fa6-4de5-990c-3a96ef582330"));
            IBFType = (ITTEnumComboBox)AddControl(new Guid("e1fc084b-221c-4a96-814e-8d8d11da6649"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("ccc9a16a-7860-4dc7-8d77-417ad81c90ae"));
            cmdApproveAll = (ITTButton)AddControl(new Guid("fc8fb950-b70c-4200-9a32-15afe7eea882"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("8c4bc942-0602-4afd-aea5-1dc7dea48f8a"));
            labelDescription = (ITTLabel)AddControl(new Guid("5c498732-2b1a-4afb-bc85-bd0f615b1049"));
            IBFYear = (ITTMaskedTextBox)AddControl(new Guid("db8de80d-e1a5-4beb-b309-0ed45b4e95da"));
            IBFYearLabel = (ITTLabel)AddControl(new Guid("43eb66bf-3c22-468b-9ac8-09b19b7fb77d"));
            labelActionDate = (ITTLabel)AddControl(new Guid("58fd6972-23df-410b-a7ea-cc8c0bdd2200"));
            IBFTypeLabel = (ITTLabel)AddControl(new Guid("db9d02c2-5194-40cf-a0d9-ad3a6814a9a4"));
            RequestNO = (ITTTextBox)AddControl(new Guid("f38d2ef4-4fa5-4367-bfe1-19198f1daff3"));
            labelID = (ITTLabel)AddControl(new Guid("458f02fc-0c65-4cc1-822f-2f964133b30a"));
            Description = (ITTTextBox)AddControl(new Guid("06c4d1ee-1e0f-4815-9d8e-195badfd60f7"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("1d45112e-bd2b-497d-a3ba-5521227af7db"));
            base.InitializeControls();
        }

        public IBFDemand_ClinicApproveForm() : base("IBFDEMAND", "IBFDemand_ClinicApproveForm")
        {
        }

        protected IBFDemand_ClinicApproveForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}