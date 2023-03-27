
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
    /// Personel Sevk Muhtırası İptal
    /// </summary>
    public partial class PersonnelConsignmentCancelledForm : EpisodeActionForm
    {
    /// <summary>
    /// Personel Sevk Muhtırası
    /// </summary>
        protected TTObjectClasses.PersonnelConsignment _PersonnelConsignment
        {
            get { return (TTObjectClasses.PersonnelConsignment)_ttObject; }
        }

        protected ITTTextBox Report;
        protected ITTLabel labelReport;
        protected ITTLabel labelCompanionName;
        protected ITTLabel labelArrivalReagon;
        protected ITTTextBox CompanionName;
        protected ITTTextBox ArrivalReagon;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTCheckBox OnlyCompanion;
        protected ITTCheckBox WithCompanion;
        override protected void InitializeControls()
        {
            Report = (ITTTextBox)AddControl(new Guid("ecf063ac-7517-45fe-9bd6-9f31c9ecedfb"));
            labelReport = (ITTLabel)AddControl(new Guid("6a7db443-df82-4aed-8367-6b9ed5a10d1b"));
            labelCompanionName = (ITTLabel)AddControl(new Guid("116bbd7e-2d06-43db-ac75-1e30e0dbd1b7"));
            labelArrivalReagon = (ITTLabel)AddControl(new Guid("44f5d48d-8e74-4979-8506-e7ca379e5e09"));
            CompanionName = (ITTTextBox)AddControl(new Guid("0b3508d0-2a25-4c5e-846d-bd2263d48f97"));
            ArrivalReagon = (ITTTextBox)AddControl(new Guid("a6e83eae-51e0-4ddb-8a66-4c5fba61a438"));
            labelActionDate = (ITTLabel)AddControl(new Guid("be312e92-cce6-4998-bebe-b002b6dd3eee"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("b9c42185-73f4-4929-bd00-4d78aa43bf73"));
            OnlyCompanion = (ITTCheckBox)AddControl(new Guid("288367b0-fe98-4b30-a5ed-4690c89d63ae"));
            WithCompanion = (ITTCheckBox)AddControl(new Guid("ce913743-6609-43c5-ad51-fe085a21c4f6"));
            base.InitializeControls();
        }

        public PersonnelConsignmentCancelledForm() : base("PERSONNELCONSIGNMENT", "PersonnelConsignmentCancelledForm")
        {
        }

        protected PersonnelConsignmentCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}