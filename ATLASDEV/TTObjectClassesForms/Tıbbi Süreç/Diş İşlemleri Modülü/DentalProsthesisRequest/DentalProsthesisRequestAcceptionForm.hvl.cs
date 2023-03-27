
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
    /// Diş Protez 
    /// </summary>
    public partial class DentalProsthesisRequestAcceptionForm : EpisodeActionForm
    {
    /// <summary>
    /// Diş Protez İstek  İşlemlerinin Gerçekleştiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.DentalProsthesisRequest _DentalProsthesisRequest
        {
            get { return (TTObjectClasses.DentalProsthesisRequest)_ttObject; }
        }

        protected ITTLabel LabelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTTextBox ProtocolNo;
        protected ITTTabControl DiagnosisTab;
        protected ITTTabPage SuggestedDentalProthesis;
        protected ITTGrid SuggestedProsthesis;
        protected ITTCheckBoxColumn Emergency;
        protected ITTListBoxColumn SuggestedProsthesisProcedure;
        protected ITTEnumComboBoxColumn ToothNum;
        protected ITTEnumComboBoxColumn DentalPosition;
        protected ITTButtonColumn SuggestedToothSchema;
        protected ITTListBoxColumn Department;
        protected ITTLabel labelProtocolNo;
        override protected void InitializeControls()
        {
            LabelRequestDate = (ITTLabel)AddControl(new Guid("57324273-99c4-4e25-8406-d666304bb255"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("072c8005-006a-4930-a74c-c06944503e9a"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("61395240-ef4a-4c25-a7a3-122ae3bb7a2f"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("08f41647-617f-45d7-ac40-153c57ad684e"));
            SuggestedDentalProthesis = (ITTTabPage)AddControl(new Guid("8d27ec37-1843-4ddd-8830-5e4623eb9385"));
            SuggestedProsthesis = (ITTGrid)AddControl(new Guid("bea1b5eb-6137-4bd2-a08f-73f18475aa1b"));
            Emergency = (ITTCheckBoxColumn)AddControl(new Guid("345b8a98-7f5a-40f7-a27b-8970195840a0"));
            SuggestedProsthesisProcedure = (ITTListBoxColumn)AddControl(new Guid("f7648881-8375-493c-832c-7496786b3a17"));
            ToothNum = (ITTEnumComboBoxColumn)AddControl(new Guid("da377a6f-3afe-4256-9fd7-b9121164f167"));
            DentalPosition = (ITTEnumComboBoxColumn)AddControl(new Guid("ce9262c2-b982-44a0-894b-84d741996466"));
            SuggestedToothSchema = (ITTButtonColumn)AddControl(new Guid("1095e88f-7243-4f96-bee3-0ebad1af3457"));
            Department = (ITTListBoxColumn)AddControl(new Guid("0dbe7a21-8f20-46c5-8028-60f4708c0f0d"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("d61c878f-badc-47f0-9a67-db78ae73a12b"));
            base.InitializeControls();
        }

        public DentalProsthesisRequestAcceptionForm() : base("DENTALPROSTHESISREQUEST", "DentalProsthesisRequestAcceptionForm")
        {
        }

        protected DentalProsthesisRequestAcceptionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}