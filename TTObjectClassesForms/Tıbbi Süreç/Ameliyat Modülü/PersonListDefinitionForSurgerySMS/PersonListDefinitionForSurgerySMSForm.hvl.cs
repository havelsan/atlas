
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
    /// Rapor Yazılmayan Ameliyatlar İçin Bilgilendirilecekler
    /// </summary>
    public partial class PersonListDefinitionForSurgerySMSForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Rapor Yazılmayan Ameliyatlar İçin Bilgilendirilecekler
    /// </summary>
        protected TTObjectClasses.PersonListDefinitionForSurgerySMS _PersonListDefinitionForSurgerySMS
        {
            get { return (TTObjectClasses.PersonListDefinitionForSurgerySMS)_ttObject; }
        }

        protected ITTLabel labelResUser;
        protected ITTObjectListBox ResUser;
        override protected void InitializeControls()
        {
            labelResUser = (ITTLabel)AddControl(new Guid("108e7049-db59-4945-afe8-4fb865180692"));
            ResUser = (ITTObjectListBox)AddControl(new Guid("ff72f6ae-9292-46eb-a4e5-5a26be2ab5d3"));
            base.InitializeControls();
        }

        public PersonListDefinitionForSurgerySMSForm() : base("PERSONLISTDEFINITIONFORSURGERYSMS", "PersonListDefinitionForSurgerySMSForm")
        {
        }

        protected PersonListDefinitionForSurgerySMSForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}