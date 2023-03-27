
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
    public partial class BaseMuayeneBilgisiSilForm : BaseMedulaActionForm
    {
        override protected void BindControlEvents()
        {
            muayeneGiris.SelectedObjectChanged += new TTControlEventDelegate(muayeneGiris_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            muayeneGiris.SelectedObjectChanged -= new TTControlEventDelegate(muayeneGiris_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void muayeneGiris_SelectedObjectChanged()
        {
#region BaseMuayeneBilgisiSilForm_muayeneGiris_SelectedObjectChanged
   if (this._MuayeneBilgisiSil.muayeneGiris != null)
                this._MuayeneBilgisiSil.muayeneSilGirisDVO.referansNo = this._MuayeneBilgisiSil.muayeneGiris.muayeneGirisDVO.referansNo;
#endregion BaseMuayeneBilgisiSilForm_muayeneGiris_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region BaseMuayeneBilgisiSilForm_PreScript
    base.PreScript();

            ITTObject iTTobject = (ITTObject)this._MuayeneBilgisiSil;
//#if MEDULA
            bool isAccess = false;
            if (_MuayeneBilgisiSil.HealthFacility.IsXXXXXXExist.HasValue == false || _MuayeneBilgisiSil.HealthFacility.IsXXXXXXExist.Value == false)
            {
                isAccess = true;
            }
            else
            {
                if (iTTobject.IsNew == false)
                    isAccess = true;

                if (TTUser.CurrentUser.IsPowerUser == false && TTUser.CurrentUser.IsSuperUser == false && TTUser.CurrentUser.HasRole(new Guid("da93c0e5-d591-4b56-bf28-1bd6e6bba838"))) // Muayene Giriş (Özel Yetki)
                    isAccess = true;
            }

            if (isAccess == false)
                throw new TTException("Bu işlem XXXXXX kullanan sahalarda başlatılamaz.\r\n\r\nXXXXXX kullanan sahalar XXXXXX'dan \"Disket Hazırlama\" yöntemi ile aktarma yapmaları gerekmektedir.");

//#endif

            if (iTTobject.IsNew)
                _MuayeneBilgisiSil.muayeneSilGirisDVO.tesisKodu = _MuayeneBilgisiSil.HealthFacilityID.Value;

            this.muayeneGiris.ListFilterExpression = " HEALTHFACILITYID = " + _MuayeneBilgisiSil.HealthFacilityID.Value;
#endregion BaseMuayeneBilgisiSilForm_PreScript

            }
                }
}