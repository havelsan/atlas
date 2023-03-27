
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
    /// New Form
    /// </summary>
    public partial class ImportTestClassForm : TTForm
    {
        protected TTObjectClasses.ImportTestClass _ImportTestClass
        {
            get { return (TTObjectClasses.ImportTestClass)_ttObject; }
        }

        protected ITTGrid ImportTestChildClasses;
        protected ITTListBoxColumn ImportTestClass;
        protected ITTTextBoxColumn Amount;
        protected ITTLabel labelUlke;
        protected ITTTextBox Ulke;
        protected ITTLabel labelSehir;
        protected ITTTextBox Sehir;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        override protected void InitializeControls()
        {
            ImportTestChildClasses = (ITTGrid)AddControl(new Guid("7aa59350-2311-43aa-9af2-7c95512ca26d"));
            ImportTestClass = (ITTListBoxColumn)AddControl(new Guid("2a6a3ca7-af56-49b8-a22f-66eea99db9f9"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("f2f0b64f-c84a-4d3d-824b-b6b5553ea17d"));
            labelUlke = (ITTLabel)AddControl(new Guid("7528c3fd-2b14-4c3f-b47c-d4acab9d200f"));
            Ulke = (ITTTextBox)AddControl(new Guid("86984685-98ac-40c6-963f-44ae5dfa2e8d"));
            labelSehir = (ITTLabel)AddControl(new Guid("d55ce51f-9c84-4934-9e5b-5d02fb993e75"));
            Sehir = (ITTTextBox)AddControl(new Guid("af2239ac-12e7-4866-8383-dc95c68e74a5"));
            labelDescription = (ITTLabel)AddControl(new Guid("2fa6774c-5b73-4b64-ad74-f793a3d26a58"));
            Description = (ITTTextBox)AddControl(new Guid("238c46fe-f925-465c-91bd-9dea2e1c08f4"));
            base.InitializeControls();
        }

        public ImportTestClassForm() : base("IMPORTTESTCLASS", "ImportTestClassForm")
        {
        }

        protected ImportTestClassForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}