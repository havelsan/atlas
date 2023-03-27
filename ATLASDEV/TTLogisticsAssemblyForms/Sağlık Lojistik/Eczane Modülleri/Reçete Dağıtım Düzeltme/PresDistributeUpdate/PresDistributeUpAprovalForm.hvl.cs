
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
    /// Reçete Dağıtım Düzeltme
    /// </summary>
    public partial class PresDistributeUpAprovalForm : TTForm
    {
    /// <summary>
    /// Reçete Dağıtım Düzeltme
    /// </summary>
        protected TTObjectClasses.PresDistributeUpdate _PresDistributeUpdate
        {
            get { return (TTObjectClasses.PresDistributeUpdate)_ttObject; }
        }

        protected ITTButton cmdGetPrescriptionDis;
        protected ITTGrid PresDistributeUpdateDetails;
        protected ITTCheckBoxColumn IsCancelPresDistributeUpdateDetail;
        protected ITTTextBoxColumn PrescriptionNo;
        protected ITTTextBoxColumn PatientNamePresDistributeUpdateDetail;
        protected ITTTextBoxColumn PatientProtocolNoPresDistributeUpdateDetail;
        protected ITTTextBoxColumn PatientQuarantineNoPresDistributeUpdateDetail;
        protected ITTTextBoxColumn PricePresDistributeUpdateDetail;
        protected ITTListBoxColumn ExternalPharmacyPresDistributeUpdateDetail;
        protected ITTListBoxColumn PrescriptionPresDistributeUpdateDetail;
        protected ITTLabel labelID;
        protected ITTTextBox ID;
        protected ITTTextBox DistributeID;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelDistributeID;
        override protected void InitializeControls()
        {
            cmdGetPrescriptionDis = (ITTButton)AddControl(new Guid("ebc9dd29-fc83-4957-b1c3-4492a8d86721"));
            PresDistributeUpdateDetails = (ITTGrid)AddControl(new Guid("170a13d6-986d-45b6-9a30-a775c3d75635"));
            IsCancelPresDistributeUpdateDetail = (ITTCheckBoxColumn)AddControl(new Guid("8b170dbe-fc89-417e-8320-33b9510af4cb"));
            PrescriptionNo = (ITTTextBoxColumn)AddControl(new Guid("4635c66d-1124-418b-906f-0d79718f81e4"));
            PatientNamePresDistributeUpdateDetail = (ITTTextBoxColumn)AddControl(new Guid("f49a4d54-2935-45b3-89e1-6ca715ce587a"));
            PatientProtocolNoPresDistributeUpdateDetail = (ITTTextBoxColumn)AddControl(new Guid("8cbf55f2-108c-43f1-86f3-8d70f43c5c85"));
            PatientQuarantineNoPresDistributeUpdateDetail = (ITTTextBoxColumn)AddControl(new Guid("70f887a3-a50b-458e-b33a-881f6f104531"));
            PricePresDistributeUpdateDetail = (ITTTextBoxColumn)AddControl(new Guid("a566f218-f35e-4207-96d7-9893237e5b60"));
            ExternalPharmacyPresDistributeUpdateDetail = (ITTListBoxColumn)AddControl(new Guid("5a00cc28-defb-4447-b09a-4f88e07c8471"));
            PrescriptionPresDistributeUpdateDetail = (ITTListBoxColumn)AddControl(new Guid("81831dcf-c87f-4f3f-b522-0ce41e3e7a86"));
            labelID = (ITTLabel)AddControl(new Guid("29a2fc25-b2a9-4512-8ad3-a72101c90d0c"));
            ID = (ITTTextBox)AddControl(new Guid("c43c1c3d-d536-4216-b9ca-7ceafb1a9d29"));
            DistributeID = (ITTTextBox)AddControl(new Guid("ee83673a-4fea-4504-aafb-1ebde80303ed"));
            labelActionDate = (ITTLabel)AddControl(new Guid("4367aaad-9783-4132-a89a-e2467789e046"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("a318f521-d466-4bef-adb0-63fc14b06496"));
            labelDistributeID = (ITTLabel)AddControl(new Guid("e5fb496a-19ab-48d5-9d93-e54e8bfc86ab"));
            base.InitializeControls();
        }

        public PresDistributeUpAprovalForm() : base("PRESDISTRIBUTEUPDATE", "PresDistributeUpAprovalForm")
        {
        }

        protected PresDistributeUpAprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}