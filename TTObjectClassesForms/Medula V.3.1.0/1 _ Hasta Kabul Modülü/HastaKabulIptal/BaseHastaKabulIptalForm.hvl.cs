
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
    /// BaseHastaKabulIptalForm
    /// </summary>
    public partial class BaseHastaKabulIptalForm : BaseMedulaActionForm
    {
    /// <summary>
    /// Hasta Kabul İptal
    /// </summary>
        protected TTObjectClasses.HastaKabulIptal _HastaKabulIptal
        {
            get { return (TTObjectClasses.HastaKabulIptal)_ttObject; }
        }

        protected ITTLabel labelsaglikTesisKodu;
        protected ITTValueListBox saglikTesisKodu;
        protected ITTLabel labeltakipNo;
        protected ITTTextBox takipNo;
        override protected void InitializeControls()
        {
            labelsaglikTesisKodu = (ITTLabel)AddControl(new Guid("62395d21-db00-45ca-b0d2-ff12110df921"));
            saglikTesisKodu = (ITTValueListBox)AddControl(new Guid("20ed8c32-c6a0-4295-8880-f9e082222715"));
            labeltakipNo = (ITTLabel)AddControl(new Guid("8b7b47e1-6754-4102-9244-dbac2064602a"));
            takipNo = (ITTTextBox)AddControl(new Guid("d5e144c7-bf4d-42cd-b184-5ae2401f1978"));
            base.InitializeControls();
        }

        public BaseHastaKabulIptalForm() : base("HASTAKABULIPTAL", "BaseHastaKabulIptalForm")
        {
        }

        protected BaseHastaKabulIptalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}