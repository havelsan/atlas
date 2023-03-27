
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
    public partial class IBFDemand_RequisiteEvaluationCommisionForm : IBFDemand_BaseForm
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
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("afcc7481-50bc-4858-b40d-54889cd1fb66"));
            IBFType = (ITTEnumComboBox)AddControl(new Guid("3b635cae-b3bc-4ab9-a0af-ffa5f076bd05"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("ee5b3c69-d8f1-45e0-929d-d80ea1c2f2ab"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("449413ac-9e2d-454d-8139-e1c618ae3698"));
            labelDescription = (ITTLabel)AddControl(new Guid("b43447bc-4da8-4f4f-96dc-b704230cce81"));
            IBFYear = (ITTMaskedTextBox)AddControl(new Guid("ed1b1db7-b8d9-4fa9-9edc-9d33974128f2"));
            IBFYearLabel = (ITTLabel)AddControl(new Guid("836b8d1f-5606-496f-8734-262cb684f256"));
            labelActionDate = (ITTLabel)AddControl(new Guid("a14962a0-0601-4efc-9c53-b6d02b9a2e74"));
            IBFTypeLabel = (ITTLabel)AddControl(new Guid("b6efa81e-2b3e-4020-8724-5a6f662f73ec"));
            RequestNO = (ITTTextBox)AddControl(new Guid("b7ac34f1-4d31-44ae-bfec-762e662ace8e"));
            labelID = (ITTLabel)AddControl(new Guid("497997a7-f33d-4dca-b8fb-2d9f82de6b8e"));
            Description = (ITTTextBox)AddControl(new Guid("ec30cc1a-3249-470f-af15-642745a96b7d"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("5da6c1a5-c470-404f-80cc-10c99cc87882"));
            base.InitializeControls();
        }

        public IBFDemand_RequisiteEvaluationCommisionForm() : base("IBFDEMAND", "IBFDemand_RequisiteEvaluationCommisionForm")
        {
        }

        protected IBFDemand_RequisiteEvaluationCommisionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}