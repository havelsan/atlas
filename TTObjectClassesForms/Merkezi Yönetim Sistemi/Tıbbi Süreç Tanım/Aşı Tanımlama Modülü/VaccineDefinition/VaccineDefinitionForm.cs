
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    public partial class VaccineDefinitionForm 
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
            base.ClientSidePostScript(transDef);

            if(_VaccineDefinition.AutoAdd == true && _VaccineDefinition.AutoAddAgeType.HasValue == false)
            {
                InfoBox.Show("L�tfen A��n�n Otomatik Eklenece�i Ya� Grubu Aral���n� Se�iniz.");
                return;
            }


        }

    }
}