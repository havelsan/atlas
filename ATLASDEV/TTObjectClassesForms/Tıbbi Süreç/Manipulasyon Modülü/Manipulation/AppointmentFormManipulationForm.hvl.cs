
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
    public partial class AppointmentFormManipulation : AppointmentFormBase
    {
    /// <summary>
    /// Tıbbi/Cerrahi Uygulama İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Manipulation _Manipulation
        {
            get { return (TTObjectClasses.Manipulation)_ttObject; }
        }

        protected ITTTextBox tttextboxProtokolNo;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            tttextboxProtokolNo = (ITTTextBox)AddControl(new Guid("55e22fea-83cc-4341-b26c-2d0f1219b9ed"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("ef4aa133-b2ee-42c4-a96f-be64cb472903"));
            base.InitializeControls();
        }

        public AppointmentFormManipulation() : base("MANIPULATION", "AppointmentFormManipulation")
        {
        }

        protected AppointmentFormManipulation(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}