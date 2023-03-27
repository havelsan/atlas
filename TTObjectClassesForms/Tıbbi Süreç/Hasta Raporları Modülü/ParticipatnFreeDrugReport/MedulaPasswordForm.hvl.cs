
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
    /// Medula Şifre Giriş
    /// </summary>
    public partial class MedulaPasswordForm : TTForm
    {
    /// <summary>
    /// Hasta Katılım Payından Muaf İlaç Raporu
    /// </summary>
        protected TTObjectClasses.ParticipatnFreeDrugReport _ParticipatnFreeDrugReport
        {
            get { return (TTObjectClasses.ParticipatnFreeDrugReport)_ttObject; }
        }

        protected ITTButton cmdPassOK;
        protected ITTCheckBox IsRepeated;
        protected ITTTextBox MedulaUserPassword;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            cmdPassOK = (ITTButton)AddControl(new Guid("82b29b4c-fd7d-4f0d-b818-cb73125fb556"));
            IsRepeated = (ITTCheckBox)AddControl(new Guid("14d1893d-4511-4f28-a143-d55ec10204a5"));
            MedulaUserPassword = (ITTTextBox)AddControl(new Guid("43a800b3-0d5b-4f76-abec-2427bcd0094e"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("23425886-fd61-4c54-a6b5-a14bcc1ad58d"));
            base.InitializeControls();
        }

        public MedulaPasswordForm() : base("PARTICIPATNFREEDRUGREPORT", "MedulaPasswordForm")
        {
        }

        protected MedulaPasswordForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}