
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
    public partial class MedulaPasswordFormForHeadDoctor : TTForm
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
        protected ITTLabel ttlabel1;
        protected ITTTextBox MedulaUserPassword;
        override protected void InitializeControls()
        {
            cmdPassOK = (ITTButton)AddControl(new Guid("7b34d8fd-cd8a-4951-a50f-ac8222dc31fc"));
            IsRepeated = (ITTCheckBox)AddControl(new Guid("e1f99f26-3332-4c4b-9330-4d05ebac2386"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("21ba53a3-97d2-4883-a6db-da85335f92d7"));
            MedulaUserPassword = (ITTTextBox)AddControl(new Guid("75f2a493-b981-4c25-8bae-a7876c8d0b18"));
            base.InitializeControls();
        }

        public MedulaPasswordFormForHeadDoctor() : base("PARTICIPATNFREEDRUGREPORT", "MedulaPasswordFormForHeadDoctor")
        {
        }

        protected MedulaPasswordFormForHeadDoctor(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}