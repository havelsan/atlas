
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
    public partial class BaseNursingFallingDownRiskForm : BaseNursingDataEntryForm
    {
    /// <summary>
    /// Düşme Riski Değerlendirme Formu
    /// </summary>
        protected TTObjectClasses.BaseNursingFallingDownRisk _BaseNursingFallingDownRisk
        {
            get { return (TTObjectClasses.BaseNursingFallingDownRisk)_ttObject; }
        }

        protected ITTLabel labelFallingDownRiskReason;
        protected ITTEnumComboBox FallingDownRiskReason;
        protected ITTGrid NursingFallingDownRisks;
        protected ITTListBoxColumn RiskFactorNursingFallingDownRisk;
        protected ITTLabel labelTotalScore;
        protected ITTTextBox TotalScore;
        protected ITTTextBox Note;
        protected ITTLabel labelNote;
        protected ITTLabel labelApplicationDate;
        protected ITTDateTimePicker ApplicationDate;
        override protected void InitializeControls()
        {
            labelFallingDownRiskReason = (ITTLabel)AddControl(new Guid("aee1c5c3-4fd6-455f-aa4e-b40f9bc2ee5e"));
            FallingDownRiskReason = (ITTEnumComboBox)AddControl(new Guid("d31b6013-43d9-4dea-9be0-fd33aca7f933"));
            NursingFallingDownRisks = (ITTGrid)AddControl(new Guid("327610d4-62db-414f-a648-141a06ae1820"));
            RiskFactorNursingFallingDownRisk = (ITTListBoxColumn)AddControl(new Guid("cb989832-c5d9-4c7a-9528-f2d6946a1f19"));
            labelTotalScore = (ITTLabel)AddControl(new Guid("80db9c36-5fd6-4e06-8bd3-56915e99b9cb"));
            TotalScore = (ITTTextBox)AddControl(new Guid("0b7f52de-2c7d-43c5-82b5-b4d51f1852cb"));
            Note = (ITTTextBox)AddControl(new Guid("25bbfaa6-1045-4f2e-afd2-8dfc21b5dc43"));
            labelNote = (ITTLabel)AddControl(new Guid("4a07d1f3-aa14-4d71-ab86-2c194d3ff81e"));
            labelApplicationDate = (ITTLabel)AddControl(new Guid("6094e26f-a25f-465e-9289-770cea9e2df6"));
            ApplicationDate = (ITTDateTimePicker)AddControl(new Guid("65cc8f28-44b1-4475-bf5e-4bc8e455f934"));
            base.InitializeControls();
        }

        public BaseNursingFallingDownRiskForm() : base("BASENURSINGFALLINGDOWNRISK", "BaseNursingFallingDownRiskForm")
        {
        }

        protected BaseNursingFallingDownRiskForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}