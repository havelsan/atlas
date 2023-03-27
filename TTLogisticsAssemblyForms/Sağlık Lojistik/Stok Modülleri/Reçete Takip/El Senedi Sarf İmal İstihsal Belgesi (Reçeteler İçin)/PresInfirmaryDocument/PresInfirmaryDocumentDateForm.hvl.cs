
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
    /// El Senedi Sarf Belgesi Tarih Giriş
    /// </summary>
    public partial class PresInfirmaryDocumentDateForm : TTForm
    {
    /// <summary>
    /// El Senedi Sarf İmal İstihsal Belgesi (Reçeteler İçin)
    /// </summary>
        protected TTObjectClasses.PresInfirmaryDocument _PresInfirmaryDocument
        {
            get { return (TTObjectClasses.PresInfirmaryDocument)_ttObject; }
        }

        protected ITTLabel labelStartDate;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel labelEndDate;
        protected ITTDateTimePicker EndDate;
        override protected void InitializeControls()
        {
            labelStartDate = (ITTLabel)AddControl(new Guid("b2309f13-7218-4290-9fbb-26f972f21ece"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("1ee14ba2-aa94-4175-a58a-8cf141ce2478"));
            labelEndDate = (ITTLabel)AddControl(new Guid("a9345486-4c97-4fdd-abd0-60e3fc531914"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("bbc5a913-5c46-4a4f-b68a-590beb95f6c7"));
            base.InitializeControls();
        }

        public PresInfirmaryDocumentDateForm() : base("PRESINFIRMARYDOCUMENT", "PresInfirmaryDocumentDateForm")
        {
        }

        protected PresInfirmaryDocumentDateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}