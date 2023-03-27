
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
    /// Evrak Kayıt
    /// </summary>
    public partial class NewDocumentForm : TTForm
    {
    /// <summary>
    /// Evrak
    /// </summary>
        protected TTObjectClasses.METDocument _METDocument
        {
            get { return (TTObjectClasses.METDocument)_ttObject; }
        }

        protected ITTListDefComboBox TTListDefComboBox1;
        protected ITTLabel TTLabel1;
        protected ITTEnumComboBox TTEnumComboBox1;
        protected ITTLabel labelType;
        protected ITTDateTimePicker DocumentDate;
        protected ITTObjectListBox TTObjectListBox1;
        protected ITTLabel TTLabel2;
        protected ITTTextBox Subject;
        protected ITTLabel labelClassificationDegree;
        protected ITTTextBox Count;
        protected ITTEnumComboBox TTEnumComboBox2;
        protected ITTLabel labelCount;
        protected ITTLabel labelDueDate;
        protected ITTLabel labelSubject;
        protected ITTLabel TTLabel3;
        protected ITTDateTimePicker DueDate;
        override protected void InitializeControls()
        {
            TTListDefComboBox1 = (ITTListDefComboBox)AddControl(new Guid("3615bdb6-7f19-422b-9f25-1b1d30dc82da"));
            TTLabel1 = (ITTLabel)AddControl(new Guid("85391a57-f76e-42db-abd3-2d0c66fac5a3"));
            TTEnumComboBox1 = (ITTEnumComboBox)AddControl(new Guid("33599e86-17cf-4335-9b60-16d852ad0189"));
            labelType = (ITTLabel)AddControl(new Guid("c3a4a3f8-3c7c-4b79-8702-1614cbc1d239"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("fc8a1822-475d-4313-8b1c-2e7143710195"));
            TTObjectListBox1 = (ITTObjectListBox)AddControl(new Guid("5d799145-f826-4026-b0f4-324aece65014"));
            TTLabel2 = (ITTLabel)AddControl(new Guid("b869727b-1fc5-45fc-9377-63519edab8ff"));
            Subject = (ITTTextBox)AddControl(new Guid("9a08f468-2782-46f8-8044-7cb57d5872e5"));
            labelClassificationDegree = (ITTLabel)AddControl(new Guid("a778e2d1-af80-489d-920c-a8d9f80559a1"));
            Count = (ITTTextBox)AddControl(new Guid("568f6353-f26f-4de3-808f-c4865e58c0ea"));
            TTEnumComboBox2 = (ITTEnumComboBox)AddControl(new Guid("fb8578b1-2282-478f-9f9a-db47de57d569"));
            labelCount = (ITTLabel)AddControl(new Guid("9cdc64b4-c961-4e03-8313-c0f8dfa7c512"));
            labelDueDate = (ITTLabel)AddControl(new Guid("072c11f1-0b00-476e-95b5-d704f56a5b3a"));
            labelSubject = (ITTLabel)AddControl(new Guid("47c450d9-c80d-4462-953f-eca838d4a96d"));
            TTLabel3 = (ITTLabel)AddControl(new Guid("62795df0-a561-485f-9960-ee2e21b22c0a"));
            DueDate = (ITTDateTimePicker)AddControl(new Guid("314235eb-a813-426b-bef3-e6b62d9178dd"));
            base.InitializeControls();
        }

        public NewDocumentForm() : base("METDOCUMENT", "NewDocumentForm")
        {
        }

        protected NewDocumentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}