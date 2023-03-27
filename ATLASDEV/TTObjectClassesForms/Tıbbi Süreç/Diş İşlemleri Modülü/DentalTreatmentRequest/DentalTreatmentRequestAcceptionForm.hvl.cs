
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
    public partial class DentalTreatmentRequestAcceptionForm : EpisodeActionForm
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
        protected ITTTextBox ProtocolNo;
        protected ITTLabel labelProtocolNo;
        protected ITTTabControl SubactionTab;
        protected ITTTabPage SuggestedDentalTreatment;
        protected ITTGrid SuggestedTreatments;
        protected ITTCheckBoxColumn Emergency;
        protected ITTListBoxColumn DentalRequestType;
        protected ITTListBoxColumn SuggestedTreatmentProcedure;
        protected ITTEnumComboBoxColumn ToothNum;
        protected ITTEnumComboBoxColumn DentalPosition;
        protected ITTButtonColumn ToothSchema;
        protected ITTListBoxColumn Department;
        protected ITTButtonColumn Delete;
        override protected void InitializeControls()
        {
            LabelRequestDate = (ITTLabel)AddControl(new Guid("35ac38cc-b26a-4843-8026-9bdad1a67ccf"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("a6293485-e53d-4cb5-b0ea-fce104150119"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("5be75c08-8c19-4b83-a79e-627d9313e6f2"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("1a661214-2f2c-4425-8a18-80a001ef4d31"));
            SubactionTab = (ITTTabControl)AddControl(new Guid("7ffd7518-7dd0-4141-b708-c9c4426e7955"));
            SuggestedDentalTreatment = (ITTTabPage)AddControl(new Guid("90b2e341-3ccf-4d37-9882-4ef565426a7f"));
            SuggestedTreatments = (ITTGrid)AddControl(new Guid("230dd463-3ffb-47eb-9b68-fde884c5efde"));
            Emergency = (ITTCheckBoxColumn)AddControl(new Guid("bf1facce-a8f5-49d5-a8e5-04a4f2fb03a3"));
            DentalRequestType = (ITTListBoxColumn)AddControl(new Guid("2e4929d6-13d9-4f33-ae2c-c13651915241"));
            SuggestedTreatmentProcedure = (ITTListBoxColumn)AddControl(new Guid("54eb3839-c600-4b51-b8ac-24805ccf9617"));
            ToothNum = (ITTEnumComboBoxColumn)AddControl(new Guid("36f0754c-e930-4359-a8d6-2bb036b6d4c7"));
            DentalPosition = (ITTEnumComboBoxColumn)AddControl(new Guid("0b1c8318-0966-4701-80c7-0f17e3a994c8"));
            ToothSchema = (ITTButtonColumn)AddControl(new Guid("3c749cfb-ca67-428f-b668-cdee7a506dbd"));
            Department = (ITTListBoxColumn)AddControl(new Guid("cd8288cc-4e77-4fca-952c-c7037dfe71de"));
            Delete = (ITTButtonColumn)AddControl(new Guid("64216363-d969-4e27-b3b7-ea36034cd66f"));
            base.InitializeControls();
        }

        public DentalTreatmentRequestAcceptionForm() : base("DENTALTREATMENTREQUEST", "DentalTreatmentRequestAcceptionForm")
        {
        }

        protected DentalTreatmentRequestAcceptionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}