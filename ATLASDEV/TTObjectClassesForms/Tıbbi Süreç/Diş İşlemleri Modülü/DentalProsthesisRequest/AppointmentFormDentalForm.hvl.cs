
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
    /// Randevu Formu
    /// </summary>
    public partial class AppointmentFormDental : EpisodeActionForm
    {
    /// <summary>
    /// Diş Protez İstek  İşlemlerinin Gerçekleştiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.DentalProsthesisRequest _DentalProsthesisRequest
        {
            get { return (TTObjectClasses.DentalProsthesisRequest)_ttObject; }
        }

        protected ITTTextBox tttextboxDescription;
        protected ITTTextBox tttextboxProtokolNo;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            tttextboxDescription = (ITTTextBox)AddControl(new Guid("46f5127e-ff6c-4495-bf39-37035891c935"));
            tttextboxProtokolNo = (ITTTextBox)AddControl(new Guid("cc143a5f-9e91-4fe3-9750-43be85eeb208"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("a14aa8f6-6ba1-496d-aff9-ad0fe5f6461e"));
            base.InitializeControls();
        }

        public AppointmentFormDental() : base("DENTALPROSTHESISREQUEST", "AppointmentFormDental")
        {
        }

        protected AppointmentFormDental(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}