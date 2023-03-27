
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
    public partial class BaseIlacRaporDuzeltForm : BaseMedulaActionForm
    {
    /// <summary>
    /// Ilaç Raporu Düzelt
    /// </summary>
        protected TTObjectClasses.IlacRaporDuzelt _IlacRaporDuzelt
        {
            get { return (TTObjectClasses.IlacRaporDuzelt)_ttObject; }
        }

        protected ITTLabel labelkullaniciTesisKoduBaseMedulaRaporObject;
        protected ITTValueListBox kullaniciTesisKoduBaseMedulaRaporObject;
        override protected void InitializeControls()
        {
            labelkullaniciTesisKoduBaseMedulaRaporObject = (ITTLabel)AddControl(new Guid("00ad582c-96f0-4b18-9c04-ce910ad9d074"));
            kullaniciTesisKoduBaseMedulaRaporObject = (ITTValueListBox)AddControl(new Guid("52566b3b-10ac-48ca-a242-048ad46ca196"));
            base.InitializeControls();
        }

        public BaseIlacRaporDuzeltForm() : base("ILACRAPORDUZELT", "BaseIlacRaporDuzeltForm")
        {
        }

        protected BaseIlacRaporDuzeltForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}