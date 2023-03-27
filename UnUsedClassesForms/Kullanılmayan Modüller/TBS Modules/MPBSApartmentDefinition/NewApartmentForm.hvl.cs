
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
    /// Lojman Tanımlama
    /// </summary>
    public partial class NewApartmentForm : TTForm
    {
    /// <summary>
    /// Lojman Tanımlama
    /// </summary>
        protected TTObjectClasses.MPBSApartmentDefinition _MPBSApartmentDefinition
        {
            get { return (TTObjectClasses.MPBSApartmentDefinition)_ttObject; }
        }

        protected ITTLabel labelNumberOfFlat;
        protected ITTTextBox NumberOfFloor;
        protected ITTListDefComboBox ApartmentArea;
        protected ITTTextBox No;
        protected ITTTextBox NumberOfFlat;
        protected ITTLabel labelNumberOfFloor;
        protected ITTLabel labelNo;
        protected ITTTextBox Name;
        protected ITTLabel labelName;
        protected ITTLabel labelApartmentArea;
        override protected void InitializeControls()
        {
            labelNumberOfFlat = (ITTLabel)AddControl(new Guid("fe2da104-68b7-43a5-b46d-1187b7b54e5a"));
            NumberOfFloor = (ITTTextBox)AddControl(new Guid("61f673b7-23f4-4bd3-a922-1a0ddef2b94f"));
            ApartmentArea = (ITTListDefComboBox)AddControl(new Guid("62510302-48e8-4f04-8701-24718d97408b"));
            No = (ITTTextBox)AddControl(new Guid("0f653077-ca4f-4f06-926c-6f5d2ee52931"));
            NumberOfFlat = (ITTTextBox)AddControl(new Guid("aa3c5c9e-9cfb-4956-82ca-824cb8ead739"));
            labelNumberOfFloor = (ITTLabel)AddControl(new Guid("f6fce303-25a9-4990-8208-aa04a4984bc6"));
            labelNo = (ITTLabel)AddControl(new Guid("0048ea9b-7303-4d16-b02d-99b432e8a45f"));
            Name = (ITTTextBox)AddControl(new Guid("1647c96d-3eb5-4349-91b4-b7dda79273b6"));
            labelName = (ITTLabel)AddControl(new Guid("2a9d5d3e-e8a3-4781-80e4-c8a20f6443a7"));
            labelApartmentArea = (ITTLabel)AddControl(new Guid("60825213-3c51-4970-b3c0-e49c0a0c99a3"));
            base.InitializeControls();
        }

        public NewApartmentForm() : base("MPBSAPARTMENTDEFINITION", "NewApartmentForm")
        {
        }

        protected NewApartmentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}