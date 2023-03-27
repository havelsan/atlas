
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
    /// Tamam
    /// </summary>
    public partial class IBFDemand_CompletedForm : IBFDemand_BaseForm
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
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("f8dec77e-59c7-4f40-ac32-c7e52c107a35"));
            IBFType = (ITTEnumComboBox)AddControl(new Guid("a771dc64-b05b-4e0b-a35f-05d54cc7246a"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("9b342422-f392-4be0-bd59-a7f7415df92b"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("c23ff306-0c5a-46e2-93ff-d9a203fc158b"));
            labelDescription = (ITTLabel)AddControl(new Guid("16ecf617-049a-4491-a2de-8afae8d554b3"));
            IBFYear = (ITTMaskedTextBox)AddControl(new Guid("05605968-7c2f-4e34-86f3-5c3a7ea5121a"));
            IBFYearLabel = (ITTLabel)AddControl(new Guid("0e95e3eb-db7f-4839-9e5d-6d973d9e34d7"));
            labelActionDate = (ITTLabel)AddControl(new Guid("198470a3-ebe2-41bf-a630-77cad7058bae"));
            IBFTypeLabel = (ITTLabel)AddControl(new Guid("ad30f3cc-b505-47a2-9508-25dcde341bbe"));
            RequestNO = (ITTTextBox)AddControl(new Guid("85082e4d-cd40-43b2-9441-7cb0455de7d1"));
            labelID = (ITTLabel)AddControl(new Guid("f69c8100-dfc2-4e56-bfe3-a4edcdac6a1d"));
            Description = (ITTTextBox)AddControl(new Guid("9a0f9666-f148-495b-83e2-1e92c6a5e595"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("9db2f4c2-5941-4d60-9fc1-df9a77d4cc9a"));
            base.InitializeControls();
        }

        public IBFDemand_CompletedForm() : base("IBFDEMAND", "IBFDemand_CompletedForm")
        {
        }

        protected IBFDemand_CompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}