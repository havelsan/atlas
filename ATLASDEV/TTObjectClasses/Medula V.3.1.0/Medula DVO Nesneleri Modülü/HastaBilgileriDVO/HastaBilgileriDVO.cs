
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
    public  partial class HastaBilgileriDVO : BaseMedulaObject
    {
        public partial class GetHastaBilgileriByTCKimlikNoReportQuery_Class : TTReportNqlObject 
        {
        }

        public string AdiVeSoyadiDesc
        {
            get
            {
                try
                {
#region AdiVeSoyadiDesc_GetScript                    
                    return ad + " " + soyad;
#endregion AdiVeSoyadiDesc_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "AdiVeSoyadiDesc") + " : " + ex.Message, ex);
                }
            }
        }

        public string CinsiyetDesc
        {
            get
            {
                try
                {
#region CinsiyetDesc_GetScript                    
                    if (string.IsNullOrEmpty(this.cinsiyet) == false)
                    {
                        Cinsiyet cinsiyet = Cinsiyet.GetCinsiyet(this.cinsiyet);
                        if (cinsiyet != null)
                            return cinsiyet.ToString();
                    }
                    return this.cinsiyet;
#endregion CinsiyetDesc_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "CinsiyetDesc") + " : " + ex.Message, ex);
                }
            }
        }

        public string SigortaliTuruDesc
        {
            get
            {
                try
                {
#region SigortaliTuruDesc_GetScript                    
                    if (string.IsNullOrEmpty(this.sigortaliTuru) == false)
                    {
                        SigortaliTuru sigortaliTuru = SigortaliTuru.GetSigortaliTuru(this.sigortaliTuru);
                        if (sigortaliTuru != null)
                            return sigortaliTuru.ToString();
                    }
                    return this.sigortaliTuru;
#endregion SigortaliTuruDesc_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "SigortaliTuruDesc") + " : " + ex.Message, ex);
                }
            }
        }

    }
}