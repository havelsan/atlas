
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
    /// Malzeme Türü Tanımlama
    /// </summary>
    public partial class MalzemeTuruDefinitionForm : BaseMedulaDefinitionForm
    {
    /// <summary>
    /// Malzeme Türü
    /// </summary>
        protected TTObjectClasses.MalzemeTuru _MalzemeTuru
        {
            get { return (TTObjectClasses.MalzemeTuru)_ttObject; }
        }

        protected ITTLabel labelmalzemeTuruKodu;
        protected ITTTextBox malzemeTuruKodu;
        protected ITTLabel labelmalzemeTuruAdi;
        protected ITTTextBox malzemeTuruAdi;
        override protected void InitializeControls()
        {
            labelmalzemeTuruKodu = (ITTLabel)AddControl(new Guid("87dd92f6-5a2f-4f2b-8645-08857b40bf25"));
            malzemeTuruKodu = (ITTTextBox)AddControl(new Guid("1107857c-fad1-4d92-9c95-92cd6a228e74"));
            labelmalzemeTuruAdi = (ITTLabel)AddControl(new Guid("36d1ae05-842a-4d00-901c-425857bdd1e9"));
            malzemeTuruAdi = (ITTTextBox)AddControl(new Guid("f8d5b133-05d6-4960-b943-8b7f861b57bf"));
            base.InitializeControls();
        }

        public MalzemeTuruDefinitionForm() : base("MALZEMETURU", "MalzemeTuruDefinitionForm")
        {
        }

        protected MalzemeTuruDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}