
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
    /// İBF Tamam
    /// </summary>
    public partial class AR_Completed : AR_BaseForm
    {
    /// <summary>
    /// İhtiyaç Bildirim Formu
    /// </summary>
        protected TTObjectClasses.AnnualRequirement _AnnualRequirement
        {
            get { return (TTObjectClasses.AnnualRequirement)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox2;
        protected ITTLabel labelActionDate;
        protected ITTLabel labelID;
        protected ITTEnumComboBox IBFType;
        protected ITTLabel labelAccountancy;
        protected ITTLabel IBFYearLabel;
        protected ITTDateTimePicker ActionDate;
        protected ITTMaskedTextBox IBFYear;
        protected ITTObjectListBox Accountancy;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTTextBox RequestNO;
        override protected void InitializeControls()
        {
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("4f8cd96b-cd74-403b-9b6a-5bb9423741f5"));
            labelActionDate = (ITTLabel)AddControl(new Guid("65827b97-d9a2-4adb-9afb-d18b4dbd6640"));
            labelID = (ITTLabel)AddControl(new Guid("17c297bb-5acf-4240-b6a1-db7c99efa36b"));
            IBFType = (ITTEnumComboBox)AddControl(new Guid("c78bfe87-4351-4276-8c52-508189987882"));
            labelAccountancy = (ITTLabel)AddControl(new Guid("281b30ed-8012-4ad1-a967-31412dcb6fed"));
            IBFYearLabel = (ITTLabel)AddControl(new Guid("d3e06f92-3031-410b-bd18-6ca07ed3fdaa"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("b8347a08-7f04-4af9-a941-41f856d23394"));
            IBFYear = (ITTMaskedTextBox)AddControl(new Guid("cee46baf-8997-4ac4-adb2-e8bd09035eee"));
            Accountancy = (ITTObjectListBox)AddControl(new Guid("09469cbf-1ef5-4df6-bbcd-01e9d7be81b5"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("adee2ddb-cc9f-450c-a792-b11db1e77fc6"));
            labelDescription = (ITTLabel)AddControl(new Guid("e5625280-4c30-44f9-acc3-5b6c373a01bc"));
            Description = (ITTTextBox)AddControl(new Guid("df5ecc49-b1f1-429e-8c0e-3bdb4656d9ee"));
            RequestNO = (ITTTextBox)AddControl(new Guid("6da3b699-c9bc-4a0c-86e0-8fa74c0e98a7"));
            base.InitializeControls();
        }

        public AR_Completed() : base("ANNUALREQUIREMENT", "AR_Completed")
        {
        }

        protected AR_Completed(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}