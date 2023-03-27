
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
    /// Patoloji Özel İşlem Tanım Ekranı
    /// </summary>
    public partial class PathologySpecialProcedureDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Patoloji Modülü Tanımları
    /// </summary>
        protected TTObjectClasses.PathologySpecialProcedureDefinition _PathologySpecialProcedureDefinition
        {
            get { return (TTObjectClasses.PathologySpecialProcedureDefinition)_ttObject; }
        }

        protected ITTLabel labelSUTAppendix;
        protected ITTEnumComboBox SUTAppendix;
        protected ITTLabel labelMedulaProcedureType;
        protected ITTEnumComboBox MedulaProcedureType;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox TTListBox;
        protected ITTLabel ttlabel2;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox tttextbox1;
        protected ITTTextBox Code;
        protected ITTLabel ttlabel1;
        protected ITTCheckBox IsActive;
        protected ITTLabel labelCode;
        protected ITTObjectListBox ProcedureTree;
        protected ITTLabel ttlabel4;
        override protected void InitializeControls()
        {
            labelSUTAppendix = (ITTLabel)AddControl(new Guid("deed9d67-86c4-4937-9f8d-336dd5402071"));
            SUTAppendix = (ITTEnumComboBox)AddControl(new Guid("d6187605-5a5a-4f71-9c05-82b7c90bc63e"));
            labelMedulaProcedureType = (ITTLabel)AddControl(new Guid("9a9ec9ee-edc3-4a68-8a50-ed3dc4f5b80d"));
            MedulaProcedureType = (ITTEnumComboBox)AddControl(new Guid("349de9f2-f868-4b7e-aaa7-1a7a0f126d01"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("9806c6b1-2f2a-4f6b-b581-fa983f7f8ee1"));
            TTListBox = (ITTObjectListBox)AddControl(new Guid("1d61a2d3-e2ac-40a4-8199-34a429bca388"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("fedf65fa-8e5f-454a-97e9-c1aec671a397"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("5644a5da-103d-48a0-b0bc-ad6abc07473b"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("5a6a14a3-c50e-4340-ad1d-977325fce74c"));
            Code = (ITTTextBox)AddControl(new Guid("db602a75-f060-4f25-9794-a21996f2881f"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("f2365f40-c262-4397-8adb-24d8654a6626"));
            IsActive = (ITTCheckBox)AddControl(new Guid("2fdc3696-fb93-4aa7-9ab1-82a9f64c3b10"));
            labelCode = (ITTLabel)AddControl(new Guid("e0f53a62-324f-45bb-bc6e-b637ca0f4fe7"));
            ProcedureTree = (ITTObjectListBox)AddControl(new Guid("0942a9c3-d935-4afe-84f9-14f5877f4ef4"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("00dfdb6d-c755-4fff-a6de-09d02e8daedd"));
            base.InitializeControls();
        }

        public PathologySpecialProcedureDefinitionForm() : base("PATHOLOGYSPECIALPROCEDUREDEFINITION", "PathologySpecialProcedureDefinitionForm")
        {
        }

        protected PathologySpecialProcedureDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}