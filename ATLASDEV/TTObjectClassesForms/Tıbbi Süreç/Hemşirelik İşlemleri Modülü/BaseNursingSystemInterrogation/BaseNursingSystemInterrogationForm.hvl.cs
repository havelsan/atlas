
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
    public partial class BaseNursingSystemInterrogationForm : BaseNursingDataEntryForm
    {
    /// <summary>
    /// Hasta Sistem Sorgulama
    /// </summary>
        protected TTObjectClasses.BaseNursingSystemInterrogation _BaseNursingSystemInterrogation
        {
            get { return (TTObjectClasses.BaseNursingSystemInterrogation)_ttObject; }
        }

        protected ITTGrid NursingSystemInterrogations;
        protected ITTListBoxColumn SystemInterrogationNursingSystemInterrogation;
        protected ITTLabel labelApplicationDate;
        protected ITTDateTimePicker ApplicationDate;
        override protected void InitializeControls()
        {
            NursingSystemInterrogations = (ITTGrid)AddControl(new Guid("9777ea5b-ec24-4521-a2bc-afd7c89647ec"));
            SystemInterrogationNursingSystemInterrogation = (ITTListBoxColumn)AddControl(new Guid("6413441a-a1b8-454d-8084-d62e7790ad34"));
            labelApplicationDate = (ITTLabel)AddControl(new Guid("7d296035-8ae4-41ac-aa18-4e5bf4cf9348"));
            ApplicationDate = (ITTDateTimePicker)AddControl(new Guid("e06075d1-49a7-41ea-a616-3419b733def9"));
            base.InitializeControls();
        }

        public BaseNursingSystemInterrogationForm() : base("BASENURSINGSYSTEMINTERROGATION", "BaseNursingSystemInterrogationForm")
        {
        }

        protected BaseNursingSystemInterrogationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}