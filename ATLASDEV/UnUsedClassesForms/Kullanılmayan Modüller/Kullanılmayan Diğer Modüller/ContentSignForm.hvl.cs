
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
    public partial class ContentSignForm : TTUnboundForm
    {
        protected ITTTextBox txtContentForSign;
        protected ITTLabel ttlabel2;
        protected ITTButton btnSignContent;
        protected ITTButton btnShowSignCertificate;
        protected ITTButton btnCancel;
        protected ITTLabel ttlabel1;
        protected ITTButton btnSelectSignCertificate;
        override protected void InitializeControls()
        {
            txtContentForSign = (ITTTextBox)AddControl(new Guid("91df8915-b8ad-49e0-a768-f4e980eefc49"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("f1be3e91-ef82-4d5b-bdab-f7ec73b07307"));
            btnSignContent = (ITTButton)AddControl(new Guid("22d6a053-1039-41c4-88c7-8f49d73b2bcd"));
            btnShowSignCertificate = (ITTButton)AddControl(new Guid("6877df45-9334-48bf-8a42-db5940e431e2"));
            btnCancel = (ITTButton)AddControl(new Guid("a3d92194-ee9d-46c2-9fdb-25e4aa8a2974"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("370204f0-5cab-4a33-836d-64b214b91419"));
            btnSelectSignCertificate = (ITTButton)AddControl(new Guid("fdea3a78-fe35-48e5-bca7-a83009842f17"));
            base.InitializeControls();
        }

        public ContentSignForm() : base("ContentSignForm")
        {
        }

        protected ContentSignForm(string formDefName) : base(formDefName)
        {
        }
    }
}