
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
    /// Personel Sevk Muhtırası
    /// </summary>
    public partial class PersonnelConsignmentNewForm : EpisodeActionForm
    {
    /// <summary>
    /// Personel Sevk Muhtırası
    /// </summary>
        protected TTObjectClasses.PersonnelConsignment _PersonnelConsignment
        {
            get { return (TTObjectClasses.PersonnelConsignment)_ttObject; }
        }

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
            labelCompanionName = (ITTLabel)AddControl(new Guid("fab86a96-b776-405c-bb62-038937392887"));
            labelArrivalReagon = (ITTLabel)AddControl(new Guid("5cd05cd6-b340-4b5c-8e76-16d6937cfbb2"));
            CompanionName = (ITTTextBox)AddControl(new Guid("c966a8eb-7242-426e-9d71-81ce7be42852"));
            ArrivalReagon = (ITTTextBox)AddControl(new Guid("14939bf9-e62c-43e3-937f-a51f8d4d95ba"));
            labelActionDate = (ITTLabel)AddControl(new Guid("2b3999c5-0131-40e0-8fea-b4744b1f6285"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("94cef2c2-67a1-4ec7-884a-b4d13efb0838"));
            OnlyCompanion = (ITTCheckBox)AddControl(new Guid("cfaaede5-52c4-4fa1-bab9-d8333bcc0b77"));
            WithCompanion = (ITTCheckBox)AddControl(new Guid("796c994c-894f-40a4-a1ee-f72e39d6d01a"));
            base.InitializeControls();
        }

        public PersonnelConsignmentNewForm() : base("PERSONNELCONSIGNMENT", "PersonnelConsignmentNewForm")
        {
        }

        protected PersonnelConsignmentNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}