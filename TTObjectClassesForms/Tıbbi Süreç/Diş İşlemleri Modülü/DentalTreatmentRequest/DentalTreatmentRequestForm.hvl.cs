
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
    /// Diş Tedavi
    /// </summary>
    public partial class DentalTreatmentRequestForm : BaseDentalEpisodeActionForm
    {
    /// <summary>
    /// Diş Tedavi İstek
    /// </summary>
        protected TTObjectClasses.DentalTreatmentRequest _DentalTreatmentRequest
        {
            get { return (TTObjectClasses.DentalTreatmentRequest)_ttObject; }
        }

        protected ITTLabel LabelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelDentalExaminationFile;
        protected ITTTextBox DentalExaminationFile;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel labelProtocolNo;
        protected ITTTabControl DiagnosisTab;
        protected ITTTabPage SuggestedDentalTreatment;
        protected ITTGrid SuggestedTreatments;
        protected ITTCheckBoxColumn Emergency;
        protected ITTListBoxColumn DentalRequestType;
        protected ITTListBoxColumn SuggestedTreatmentProcedure;
        protected ITTEnumComboBoxColumn ToothNum;
        protected ITTEnumComboBoxColumn DentalPosition;
        protected ITTButtonColumn ToothSchema;
        protected ITTListBoxColumn Department;
        protected ITTTextBoxColumn Definition;
        override protected void InitializeControls()
        {
            LabelRequestDate = (ITTLabel)AddControl(new Guid("d514bf4e-ee48-4f14-a426-286ea3fb8d6d"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("09c601ad-f108-4833-8b75-a591e2b4cb8c"));
            labelDentalExaminationFile = (ITTLabel)AddControl(new Guid("895e2a75-12df-42de-8bee-461296441ebc"));
            DentalExaminationFile = (ITTTextBox)AddControl(new Guid("77c267b9-9268-4edd-81f6-4a20aee4d260"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("1f2b56ca-303d-4350-b044-74f915dbc28e"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("c619d34a-1931-4d61-a03e-597dce28294c"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("14d107b8-92e7-4dae-9829-91416ec14f25"));
            SuggestedDentalTreatment = (ITTTabPage)AddControl(new Guid("bd8ebcae-9da2-4bb0-8cc9-9e36483e35db"));
            SuggestedTreatments = (ITTGrid)AddControl(new Guid("ee420e80-a3ad-47c3-81df-ec5e8f833a35"));
            Emergency = (ITTCheckBoxColumn)AddControl(new Guid("4dd960e1-e9a1-41b0-b64b-c3bee8e72b4c"));
            DentalRequestType = (ITTListBoxColumn)AddControl(new Guid("d97d5df5-0251-4f0e-bb33-a500de119b3e"));
            SuggestedTreatmentProcedure = (ITTListBoxColumn)AddControl(new Guid("d53cfc01-1ace-4f80-9396-d0a2fb0935f2"));
            ToothNum = (ITTEnumComboBoxColumn)AddControl(new Guid("6fc26b83-36d5-41ee-b9f9-1722fe038b95"));
            DentalPosition = (ITTEnumComboBoxColumn)AddControl(new Guid("c0042330-88ee-45e7-bdfd-4fefd1303dbe"));
            ToothSchema = (ITTButtonColumn)AddControl(new Guid("89901c20-14de-4dac-b4cc-5d9d2531e9d5"));
            Department = (ITTListBoxColumn)AddControl(new Guid("d57af52c-0b10-497e-9b9e-02f94be30e47"));
            Definition = (ITTTextBoxColumn)AddControl(new Guid("d3a10b37-e2ff-46ec-847c-3e9bd81555d8"));
            base.InitializeControls();
        }

        public DentalTreatmentRequestForm() : base("DENTALTREATMENTREQUEST", "DentalTreatmentRequestForm")
        {
        }

        protected DentalTreatmentRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}