
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
    public partial class MedulaErrorLogForm : TTForm
    {
        protected TTObjectClasses.MedulaErrorLog _MedulaErrorLog
        {
            get { return (TTObjectClasses.MedulaErrorLog)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage errorLogTabpage;
        protected ITTTextBox ErrorException;
        protected ITTTabPage responseXMLTabpage;
        protected ITTTextBox ResponseXML;
        protected ITTTextBox MedulaActionIDBaseMedulaWLAction;
        protected ITTTextBox BaseMedulaActionApplicationName;
        protected ITTLabel labelWorkListDateBaseMedulaWLAction;
        protected ITTDateTimePicker WorkListDateBaseMedulaWLAction;
        protected ITTLabel labelMedulaActionIDBaseMedulaWLAction;
        protected ITTLabel labelErrorDate;
        protected ITTDateTimePicker ErrorDate;
        protected ITTLabel labelBaseMedulaAction;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("ce6a561d-69ef-49c6-b026-4483187e04d0"));
            errorLogTabpage = (ITTTabPage)AddControl(new Guid("9d647741-67a8-433f-825e-80082965558c"));
            ErrorException = (ITTTextBox)AddControl(new Guid("3acd1f54-d1eb-492b-ad75-40084313d9e4"));
            responseXMLTabpage = (ITTTabPage)AddControl(new Guid("3c91e1bd-e5a1-45b5-97a7-bf816b185382"));
            ResponseXML = (ITTTextBox)AddControl(new Guid("7601e038-00a5-4a78-9cfe-ea82cc3867e8"));
            MedulaActionIDBaseMedulaWLAction = (ITTTextBox)AddControl(new Guid("63e243e5-72bb-4c7d-a19d-30f2b8cdde5d"));
            BaseMedulaActionApplicationName = (ITTTextBox)AddControl(new Guid("874577e2-e687-4927-87c6-b72578daea5e"));
            labelWorkListDateBaseMedulaWLAction = (ITTLabel)AddControl(new Guid("311ac40e-bb80-4868-8211-eb7b47c542f4"));
            WorkListDateBaseMedulaWLAction = (ITTDateTimePicker)AddControl(new Guid("5dbdab93-946b-4ea5-8a67-7a697d9f03c3"));
            labelMedulaActionIDBaseMedulaWLAction = (ITTLabel)AddControl(new Guid("ac6b0894-53e0-4334-ab33-2194768d9bde"));
            labelErrorDate = (ITTLabel)AddControl(new Guid("b2b6d742-8871-40a8-83f0-03671dc332c9"));
            ErrorDate = (ITTDateTimePicker)AddControl(new Guid("0b2e5734-4754-4338-90de-2697e5fe19cc"));
            labelBaseMedulaAction = (ITTLabel)AddControl(new Guid("9f5b047c-cebd-4ef3-99fd-1a44e81100e7"));
            base.InitializeControls();
        }

        public MedulaErrorLogForm() : base("MEDULAERRORLOG", "MedulaErrorLogForm")
        {
        }

        protected MedulaErrorLogForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}