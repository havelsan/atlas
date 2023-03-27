
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
    /// Gelen Evrak Bilgileri
    /// </summary>
    public partial class NewIncomingDocumetForm : TTForm
    {
    /// <summary>
    /// Gelen Evrak
    /// </summary>
        protected TTObjectClasses.MPBSIncomingDocument _MPBSIncomingDocument
        {
            get { return (TTObjectClasses.MPBSIncomingDocument)_ttObject; }
        }

        protected ITTDateTimePicker Date;
        protected ITTTextBox Identifier;
        protected ITTDateTimePicker WearLifeDate;
        protected ITTTextBox WhichCupboardIn;
        protected ITTLabel labelDailyDocumentNo;
        protected ITTLabel labelSubject;
        protected ITTLabel labelAdditionalNumber;
        protected ITTLabel labelRegisterDate;
        protected ITTLabel labelSecurityLevel;
        protected ITTDateTimePicker RegisterDate;
        protected ITTLabel labelFrom;
        protected ITTTextBox Subject;
        protected ITTLabel labelWhichFileIn;
        protected ITTLabel labelIdentifier;
        protected ITTLabel labelWearLifeDate;
        protected ITTTextBox ConcernedPosition;
        protected ITTTextBox DocumentNo;
        protected ITTLabel labelWhichCupboardIn;
        protected ITTTextBox From;
        protected ITTLabel labelInternalExternal;
        protected ITTTextBox SecurityLevel;
        protected ITTLabel labelDate;
        protected ITTLabel labelConcernedPosition;
        protected ITTTextBox DailyDocumentNo;
        protected ITTTextBox WhichFileIn;
        protected ITTTextBox PresentationType;
        protected ITTLabel labelPresentationType;
        protected ITTDateTimePicker DistributionDate;
        protected ITTTextBox AdditionalNumber;
        protected ITTLabel labelDistributionDate;
        protected ITTLabel labelDocumentNo;
        protected ITTEnumComboBox InternalExternal;
        override protected void InitializeControls()
        {
            Date = (ITTDateTimePicker)AddControl(new Guid("5a5aa49e-0a88-4b6b-b6c6-0a377bda8dcb"));
            Identifier = (ITTTextBox)AddControl(new Guid("49de7495-7778-4c0b-809e-eb32b34e7432"));
            WearLifeDate = (ITTDateTimePicker)AddControl(new Guid("5502b578-e6c5-4682-a10a-eca5569a96f1"));
            WhichCupboardIn = (ITTTextBox)AddControl(new Guid("ee27035d-2d28-4e22-974d-f2999d47556b"));
            labelDailyDocumentNo = (ITTLabel)AddControl(new Guid("aba0e6ac-0249-4f43-b67e-e3683d1056de"));
            labelSubject = (ITTLabel)AddControl(new Guid("4ff014b0-ecae-4ac0-9116-e2a4cdc38ba8"));
            labelAdditionalNumber = (ITTLabel)AddControl(new Guid("20010cbe-101e-4da3-bd87-cdd163956e5b"));
            labelRegisterDate = (ITTLabel)AddControl(new Guid("38644c62-af2a-45ea-8e2f-c004ba137b76"));
            labelSecurityLevel = (ITTLabel)AddControl(new Guid("275a4f98-291d-46b8-9060-ac245d984160"));
            RegisterDate = (ITTDateTimePicker)AddControl(new Guid("76eea460-e4a6-469c-9450-cdcb2771cd42"));
            labelFrom = (ITTLabel)AddControl(new Guid("7a7b19ed-8225-44cf-aafb-9d5fe7c6876e"));
            Subject = (ITTTextBox)AddControl(new Guid("f580692c-56ca-4a44-b3ff-780fb6de3337"));
            labelWhichFileIn = (ITTLabel)AddControl(new Guid("eacc7707-be8a-417d-9c9c-a1adea469162"));
            labelIdentifier = (ITTLabel)AddControl(new Guid("59c213f9-eb57-44f8-ae90-7af519783f1d"));
            labelWearLifeDate = (ITTLabel)AddControl(new Guid("252bbd99-a7a6-462b-8ed8-8b0e7d07cb9a"));
            ConcernedPosition = (ITTTextBox)AddControl(new Guid("326262c4-cfc0-4fcf-9fc6-5f544fba5c48"));
            DocumentNo = (ITTTextBox)AddControl(new Guid("8eaf810d-7b0b-4ae1-b524-529cef0c726a"));
            labelWhichCupboardIn = (ITTLabel)AddControl(new Guid("de152850-da10-48c4-85d4-5d94b23fbbee"));
            From = (ITTTextBox)AddControl(new Guid("0aac2964-ec5f-46a2-97a2-4768f970a282"));
            labelInternalExternal = (ITTLabel)AddControl(new Guid("46176147-8fed-4730-8d09-514e98197ffd"));
            SecurityLevel = (ITTTextBox)AddControl(new Guid("393b0f67-0584-4d48-9118-6101a992ce8f"));
            labelDate = (ITTLabel)AddControl(new Guid("9614de5d-de8d-44f2-be26-3c415040ca59"));
            labelConcernedPosition = (ITTLabel)AddControl(new Guid("841c551a-8491-454a-827f-2bdf4d8f2c25"));
            DailyDocumentNo = (ITTTextBox)AddControl(new Guid("dd21f6fe-3703-44e4-b38b-420399377840"));
            WhichFileIn = (ITTTextBox)AddControl(new Guid("58b05be9-8734-4296-b2fc-0943001c8f53"));
            PresentationType = (ITTTextBox)AddControl(new Guid("209f195f-1749-4dd0-93b8-0a1ab0979280"));
            labelPresentationType = (ITTLabel)AddControl(new Guid("64c6ece4-b0ee-4c78-b5ff-13c1c8cb3c3e"));
            DistributionDate = (ITTDateTimePicker)AddControl(new Guid("4562fe7a-ae70-401c-9f1a-04df211715b2"));
            AdditionalNumber = (ITTTextBox)AddControl(new Guid("92fd63e4-54e8-40d2-99d1-12e5983ce1d9"));
            labelDistributionDate = (ITTLabel)AddControl(new Guid("1359f770-55c7-440d-9e0d-1fe24807ce16"));
            labelDocumentNo = (ITTLabel)AddControl(new Guid("54d24427-8043-41ba-87fc-ee825162417e"));
            InternalExternal = (ITTEnumComboBox)AddControl(new Guid("b26cb9d5-3c36-4f0e-a663-f0b6f66c0b42"));
            base.InitializeControls();
        }

        public NewIncomingDocumetForm() : base("MPBSINCOMINGDOCUMENT", "NewIncomingDocumetForm")
        {
        }

        protected NewIncomingDocumetForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}