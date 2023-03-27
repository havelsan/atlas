
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
    /// Tatil Günü Tanımlama
    /// </summary>
    public partial class WorkDayExceptionDefForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.WorkDayExceptionDef _WorkDayExceptionDef
        {
            get { return (TTObjectClasses.WorkDayExceptionDef)_ttObject; }
        }

        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTLabel labelDate;
        protected ITTDateTimePicker Date;
        override protected void InitializeControls()
        {
            labelDescription = (ITTLabel)AddControl(new Guid("13fc8893-2fc6-43e0-8454-beae33c0e4da"));
            Description = (ITTTextBox)AddControl(new Guid("d96c8e77-6e01-4b5d-ac54-35d4bbe51268"));
            labelDate = (ITTLabel)AddControl(new Guid("e9456859-5c3c-4e6b-aa84-8a92d643a7bd"));
            Date = (ITTDateTimePicker)AddControl(new Guid("556fd87b-c9e1-4de0-b167-6d88869ad199"));
            base.InitializeControls();
        }

        public WorkDayExceptionDefForm() : base("WORKDAYEXCEPTIONDEF", "WorkDayExceptionDefForm")
        {
        }

        protected WorkDayExceptionDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}