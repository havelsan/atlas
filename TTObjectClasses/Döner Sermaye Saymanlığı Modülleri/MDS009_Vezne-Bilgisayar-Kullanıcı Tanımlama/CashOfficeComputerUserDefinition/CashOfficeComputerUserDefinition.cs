
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
    /// Sayman Mutemetliği / Vezne / Fatura Servisi Bilgisayar Kullanıcı Tanımı
    /// </summary>
    public partial class CashOfficeComputerUserDefinition : TTDefinitionSet
    {
        public partial class GetCashOfficeComputerUserDefinitions_Class : TTReportNqlObject
        {
        }

        protected override void PreInsert()
        {
            #region PreInsert
            base.PreInsert();
            TTObjectContext objectContext = new TTObjectContext(true);
            foreach (CashOfficeComputerUserDefinition cashOfficeUser in CashOfficeComputerUserDefinition.GetAll(objectContext))
            {
                if (ResUser.ToString() == cashOfficeUser.ResUser.ToString() && ComputerName.ToString() == cashOfficeUser.ComputerName.ToString())
                {
                    throw new TTException(SystemMessage.GetMessage(562));
                }
                /*if (this.ResUser.ToString() == cashOfficeUser.ResUser.ToString() && this.ComputerName == cashOfficeUser.ComputerName && this.CashOffice.Name == cashOfficeUser.CashOffice.Name.ToString())
                {
                    throw new TTException(SystemMessage.GetMessage(562));
                    //break;
                }*/
            }
            #endregion PreInsert
        }

        protected override void PostInsert()
        {
            #region PostInsert
            base.PostInsert();

            ResUser.ControlAndCreateAPR();

            #endregion PostInsert
        }

        protected override void PreDelete()
        {
            #region PreDelete
            base.PreDelete();

            #endregion PreDelete
        }

        protected override void PostDelete()
        {
            #region PostDelete

            base.PostDelete();

            #endregion PostDelete
        }

        #region Methods

        #endregion Methods

    }
}