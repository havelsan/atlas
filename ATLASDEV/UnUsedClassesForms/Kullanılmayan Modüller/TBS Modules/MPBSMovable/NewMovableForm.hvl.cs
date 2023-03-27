
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
    /// Menkul Değer Bilgileri
    /// </summary>
    public partial class NewMovableForm : TTForm
    {
    /// <summary>
    /// Menkul
    /// </summary>
        protected TTObjectClasses.MPBSMovable _MPBSMovable
        {
            get { return (TTObjectClasses.MPBSMovable)_ttObject; }
        }

        protected ITTTextBox Value;
        protected ITTLabel labelKind;
        protected ITTTextBox PieceNumber;
        protected ITTLabel labelOfficerPettyOfficer;
        protected ITTDateTimePicker Year;
        protected ITTLabel labelYear;
        protected ITTObjectListBox OfficerPettyOfficer;
        protected ITTLabel labelValue;
        protected ITTLabel labelDeclerationDate;
        protected ITTTextBox Kind;
        protected ITTDateTimePicker DeclerationDate;
        protected ITTLabel labelPieceNumber;
        override protected void InitializeControls()
        {
            Value = (ITTTextBox)AddControl(new Guid("38d36ce5-79e1-4de7-8291-07f13182fea7"));
            labelKind = (ITTLabel)AddControl(new Guid("2091f779-9a68-4138-9ebc-2eb7379a595a"));
            PieceNumber = (ITTTextBox)AddControl(new Guid("fd703afd-f0c7-4e61-a9df-17ef78c51ef5"));
            labelOfficerPettyOfficer = (ITTLabel)AddControl(new Guid("38cf4fb2-306d-4452-a334-35a46da43c24"));
            Year = (ITTDateTimePicker)AddControl(new Guid("c57a8bed-2e7f-4995-8d63-5b1e73e85526"));
            labelYear = (ITTLabel)AddControl(new Guid("bcfc6c4f-8567-472a-a224-882a97762c93"));
            OfficerPettyOfficer = (ITTObjectListBox)AddControl(new Guid("916f745e-52d9-4875-b08c-ac008d837bee"));
            labelValue = (ITTLabel)AddControl(new Guid("fed18ed9-2175-4c82-bdff-993965eee62b"));
            labelDeclerationDate = (ITTLabel)AddControl(new Guid("099a0f7c-a180-479e-a12d-bbea6ceedbbf"));
            Kind = (ITTTextBox)AddControl(new Guid("5995aaaf-4fd8-4d7f-8daf-ea735252bcaa"));
            DeclerationDate = (ITTDateTimePicker)AddControl(new Guid("13d44499-0d40-43df-a253-fc0a6c454257"));
            labelPieceNumber = (ITTLabel)AddControl(new Guid("32f96956-e164-45e7-8039-fcfbbcbe3036"));
            base.InitializeControls();
        }

        public NewMovableForm() : base("MPBSMOVABLE", "NewMovableForm")
        {
        }

        protected NewMovableForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}