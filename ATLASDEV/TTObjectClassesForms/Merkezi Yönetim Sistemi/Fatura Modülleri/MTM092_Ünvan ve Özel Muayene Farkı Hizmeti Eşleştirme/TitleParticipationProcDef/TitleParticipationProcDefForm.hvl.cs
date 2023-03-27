
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
    /// Ünvan ve Özel Muayene Hizmeti Eşleştirme Tanımı
    /// </summary>
    public partial class TitleParticipationProcDefForm : TTDefinitionForm
    {
    /// <summary>
    /// Ünvan ve Özel Muayene Hizmeti Eşleştirme Tanımı
    /// </summary>
        protected TTObjectClasses.TitleParticipationProcDef _TitleParticipationProcDef
        {
            get { return (TTObjectClasses.TitleParticipationProcDef)_ttObject; }
        }

        protected ITTEnumComboBox UserTitle;
        protected ITTLabel labelTitle;
        protected ITTObjectListBox ProcedureDefinition;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            UserTitle = (ITTEnumComboBox)AddControl(new Guid("bc64277b-fa72-4669-989f-7a2c5b1daded"));
            labelTitle = (ITTLabel)AddControl(new Guid("9fbb29aa-913e-4ec4-ba4c-444aee4aacf9"));
            ProcedureDefinition = (ITTObjectListBox)AddControl(new Guid("d6128600-45b6-424b-9876-3c24f2a7293f"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("c3f9f284-01dd-4045-9a18-f1f8f21e6c89"));
            base.InitializeControls();
        }

        public TitleParticipationProcDefForm() : base("TITLEPARTICIPATIONPROCDEF", "TitleParticipationProcDefForm")
        {
        }

        protected TitleParticipationProcDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}