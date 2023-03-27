
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
    /// Bölge XXXXXX / XXXXXX Onay
    /// </summary>
    public partial class AR_RegionalCommanderApproveForm : AR_BaseForm
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
        protected ITTLabel IBFYearLabel;
        protected ITTLabel labelAccountancy;
        protected ITTMaskedTextBox IBFYear;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox Accountancy;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTTextBox RequestNO;
        override protected void InitializeControls()
        {
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("e57bdb0f-430a-4025-b9f4-88af831a74c3"));
            labelActionDate = (ITTLabel)AddControl(new Guid("b213362f-027d-485c-81b0-30c060f49c4e"));
            labelID = (ITTLabel)AddControl(new Guid("44908a0f-226b-456d-ac58-9169513a23cc"));
            IBFType = (ITTEnumComboBox)AddControl(new Guid("c89a86e3-eee8-4b53-8bc1-1847c3ced4be"));
            IBFYearLabel = (ITTLabel)AddControl(new Guid("27db3cc7-73c0-4b08-861a-f0afb76406eb"));
            labelAccountancy = (ITTLabel)AddControl(new Guid("38f7dd6c-e6d4-4bcb-9fec-3d00d4ad7923"));
            IBFYear = (ITTMaskedTextBox)AddControl(new Guid("071670d1-2267-4a4e-bf95-c74b0f7b9dd3"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("953e9f24-d7b1-4267-a326-55e47115c395"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("e5668451-958e-4fb3-9b90-0177f47bd205"));
            Accountancy = (ITTObjectListBox)AddControl(new Guid("3e7f55b1-60aa-487e-87a3-83461fbac3ce"));
            labelDescription = (ITTLabel)AddControl(new Guid("111f3632-4cd5-4a00-8469-a151de55a3cb"));
            Description = (ITTTextBox)AddControl(new Guid("a1e4da3a-43b6-48a2-a8ca-4c47f21806fa"));
            RequestNO = (ITTTextBox)AddControl(new Guid("eb440988-3699-4cd3-b92d-e0114d836485"));
            base.InitializeControls();
        }

        public AR_RegionalCommanderApproveForm() : base("ANNUALREQUIREMENT", "AR_RegionalCommanderApproveForm")
        {
        }

        protected AR_RegionalCommanderApproveForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}