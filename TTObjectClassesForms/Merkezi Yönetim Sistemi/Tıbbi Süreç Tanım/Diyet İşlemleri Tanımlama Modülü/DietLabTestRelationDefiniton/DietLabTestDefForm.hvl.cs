
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
    public partial class DietLabTestDefForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Diyette Gösterilecek Testler
    /// </summary>
        protected TTObjectClasses.DietLabTestRelationDefiniton _DietLabTestRelationDefiniton
        {
            get { return (TTObjectClasses.DietLabTestRelationDefiniton)_ttObject; }
        }

        protected ITTLabel labelDietLaboratoryTest;
        protected ITTObjectListBox DietLaboratoryTest;
        override protected void InitializeControls()
        {
            labelDietLaboratoryTest = (ITTLabel)AddControl(new Guid("20581536-4245-4cd3-b555-4ec3b1928306"));
            DietLaboratoryTest = (ITTObjectListBox)AddControl(new Guid("d05f72d1-f8c5-4cce-8886-8f14bafd5392"));
            base.InitializeControls();
        }

        public DietLabTestDefForm() : base("DIETLABTESTRELATIONDEFINITON", "DietLabTestDefForm")
        {
        }

        protected DietLabTestDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}