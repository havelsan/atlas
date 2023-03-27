
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
    /// SPTS Tanıları Tanım
    /// </summary>
    public partial class SPTSDiagnosisInfoDefForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.SPTSDiagnosisInfo _SPTSDiagnosisInfo
        {
            get { return (TTObjectClasses.SPTSDiagnosisInfo)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTTextBox ID;
        protected ITTTextBox Code;
        protected ITTLabel labelID;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("a2a41848-820b-4fa5-af04-943261cc1051"));
            Name = (ITTTextBox)AddControl(new Guid("cad7fa65-7bd9-4578-b3d4-82c042c8a6fc"));
            ID = (ITTTextBox)AddControl(new Guid("5604534e-d834-47ad-b14f-660984b12ab4"));
            Code = (ITTTextBox)AddControl(new Guid("02704920-1e3c-4625-a001-d1f25c5cb543"));
            labelID = (ITTLabel)AddControl(new Guid("b23b7b36-d9a3-46bd-b1bd-a60b14e7bc40"));
            labelCode = (ITTLabel)AddControl(new Guid("45877e8e-ad22-4255-a58b-9775ab3ac5a9"));
            base.InitializeControls();
        }

        public SPTSDiagnosisInfoDefForm() : base("SPTSDIAGNOSISINFO", "SPTSDiagnosisInfoDefForm")
        {
        }

        protected SPTSDiagnosisInfoDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}