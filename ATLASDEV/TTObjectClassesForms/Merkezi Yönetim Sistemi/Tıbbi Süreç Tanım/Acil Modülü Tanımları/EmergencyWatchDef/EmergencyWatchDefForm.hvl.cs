
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
    public partial class EmergencyWatchDefForm : TTDefinitionForm
    {
    /// <summary>
    /// Nöbetçi Personel
    /// </summary>
        protected TTObjectClasses.EmergencyWatchDef _EmergencyWatchDef
        {
            get { return (TTObjectClasses.EmergencyWatchDef)_ttObject; }
        }

        protected ITTGrid EmergencyWatchPersonelDefs;
        protected ITTListBoxColumn ResUserEmergencyWatchPersonelDef;
        protected ITTDateTimePickerColumn BaslangicTarihiEmergencyWatchPersonelDef;
        protected ITTDateTimePickerColumn BitisTarihEmergencyWatchPersonelDef;
        protected ITTCheckBoxColumn BildirildiEmergencyWatchPersonelDef;
        protected ITTCheckBoxColumn IcapciEmergencyWatchPersonelDef;
        protected ITTButton ttbutton1;
        protected ITTLabel labelTarih;
        protected ITTDateTimePicker Tarih;
        override protected void InitializeControls()
        {
            EmergencyWatchPersonelDefs = (ITTGrid)AddControl(new Guid("97c9e9ec-b93f-4e02-8d7a-9bc2c16d0900"));
            ResUserEmergencyWatchPersonelDef = (ITTListBoxColumn)AddControl(new Guid("fb5b0033-8736-48f9-b60f-9047b11874d2"));
            BaslangicTarihiEmergencyWatchPersonelDef = (ITTDateTimePickerColumn)AddControl(new Guid("e87f3e7f-b8f5-4338-86bc-598d9d31c432"));
            BitisTarihEmergencyWatchPersonelDef = (ITTDateTimePickerColumn)AddControl(new Guid("ad9483f4-54ec-4f97-b8b7-04cb256bab0f"));
            BildirildiEmergencyWatchPersonelDef = (ITTCheckBoxColumn)AddControl(new Guid("dcbc99f4-d820-413b-aeb4-4926f2404f40"));
            IcapciEmergencyWatchPersonelDef = (ITTCheckBoxColumn)AddControl(new Guid("6cb3a987-8345-4d97-9255-61ba3df79bda"));
            ttbutton1 = (ITTButton)AddControl(new Guid("4f019e91-4eab-45b0-a632-48246e498b66"));
            labelTarih = (ITTLabel)AddControl(new Guid("1018eb12-4141-4439-9036-6994c5516d54"));
            Tarih = (ITTDateTimePicker)AddControl(new Guid("1ab8dd74-0934-4389-b154-94d583ed11cf"));
            base.InitializeControls();
        }

        public EmergencyWatchDefForm() : base("EMERGENCYWATCHDEF", "EmergencyWatchDefForm")
        {
        }

        protected EmergencyWatchDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}