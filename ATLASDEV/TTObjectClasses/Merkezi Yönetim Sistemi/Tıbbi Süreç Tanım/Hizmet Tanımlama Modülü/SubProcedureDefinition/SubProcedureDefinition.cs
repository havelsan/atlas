
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


namespace TTObjectClasses
{
    /// <summary>
    /// Alt Hizmet Tanımları
    /// </summary>
    public  partial class SubProcedureDefinition : TerminologyManagerDef
    {
        protected override void PostInsert()
        {
#region PostInsert
            base.PostInsert();
            if(ChildProcedureDefinition.Code == "510120" && ChildProcedureDefinition.ObjectID.ToString().ToUpper() != "D15C2D28-D4ED-4ADD-9B25-7C813049FE3B")
            {
                throw new Exception(TTUtils.CultureService.GetText("M25727", "Girmiş olduğunuz gündüz yatak hizmeti bu aşamada kullanılmamaktadır. Diğer gündüz yatak hizmetini seçiniz."));
            }
#endregion PostInsert
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            base.PostUpdate();
            if(ChildProcedureDefinition.Code == "510120" && ChildProcedureDefinition.ObjectID.ToString().ToUpper() != "D15C2D28-D4ED-4ADD-9B25-7C813049FE3B")
            {
                throw new Exception(TTUtils.CultureService.GetText("M25727", "Girmiş olduğunuz gündüz yatak hizmeti bu aşamada kullanılmamaktadır. Diğer gündüz yatak hizmetini seçiniz."));
            }
#endregion PostUpdate
        }

    }
}