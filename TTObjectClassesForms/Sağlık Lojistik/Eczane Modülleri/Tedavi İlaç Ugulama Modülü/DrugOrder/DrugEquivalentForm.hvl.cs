
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
    /// Eşdeğer İlaçlar
    /// </summary>
    public partial class DrugEquivalentForm : TTForm
    {
    /// <summary>
    /// İlaç Direktifi
    /// </summary>
        protected TTObjectClasses.DrugOrder _DrugOrder
        {
            get { return (TTObjectClasses.DrugOrder)_ttObject; }
        }

        protected ITTLabel ttlabel1;
        protected ITTButton cmdUserCancelled;
        protected ITTButton cmdChange;
        protected ITTListView Equivalents;
        override protected void InitializeControls()
        {
            ttlabel1 = (ITTLabel)AddControl(new Guid("dc0f0e49-e0fe-467d-876c-c61b4a841394"));
            cmdUserCancelled = (ITTButton)AddControl(new Guid("93b2127e-b7f1-46c5-944b-a05ac24ba488"));
            cmdChange = (ITTButton)AddControl(new Guid("e8c6e6b9-267d-4e85-9d0c-45487f950993"));
            Equivalents = (ITTListView)AddControl(new Guid("55b5e7ec-4d8f-442a-a2b6-2a31b7a84eda"));
            base.InitializeControls();
        }

        public DrugEquivalentForm() : base("DRUGORDER", "DrugEquivalentForm")
        {
        }

        protected DrugEquivalentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}