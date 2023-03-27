
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
    /// Öncelik Durumu
    /// </summary>
    public partial class PriorityStatusForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Öncelik Durumu Tanımlama
    /// </summary>
        protected TTObjectClasses.PriorityStatusDefinition _PriorityStatusDefinition
        {
            get { return (TTObjectClasses.PriorityStatusDefinition)_ttObject; }
        }

        protected ITTLabel lblOrder;
        protected ITTTextBox Order;
        protected ITTTextBox Kodu;
        protected ITTTextBox Adi;
        protected ITTLabel lblKod;
        protected ITTLabel lblAdi;
        override protected void InitializeControls()
        {
            lblOrder = (ITTLabel)AddControl(new Guid("f5ab4bd0-15cf-4c28-8c73-409a73ac9c15"));
            Order = (ITTTextBox)AddControl(new Guid("a8e55761-b82e-4c49-ae47-802b86b2a584"));
            Kodu = (ITTTextBox)AddControl(new Guid("88d73f7f-c749-4ebe-8654-3912c1853c66"));
            Adi = (ITTTextBox)AddControl(new Guid("c9193831-ae61-4188-a9bc-0b6a4bb19b7f"));
            lblKod = (ITTLabel)AddControl(new Guid("d4999ddd-4660-4844-9a17-177ba4c860ff"));
            lblAdi = (ITTLabel)AddControl(new Guid("4d01e9d1-85cc-4283-87de-a0767f9c1469"));
            base.InitializeControls();
        }

        public PriorityStatusForm() : base("PRIORITYSTATUSDEFINITION", "PriorityStatusForm")
        {
        }

        protected PriorityStatusForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}