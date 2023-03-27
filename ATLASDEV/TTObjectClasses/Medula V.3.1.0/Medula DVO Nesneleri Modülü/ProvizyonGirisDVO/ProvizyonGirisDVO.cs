
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
    public  partial class ProvizyonGirisDVO : BaseMedulaObject
    {
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

        public string TakipTipiDesc
        {
            get
            {
                try
                {
#region TakipTipiDesc_GetScript                    
                    if (string.IsNullOrEmpty(this.takipTipi) == false)
                    {
                        TakipTipi takipTipi = TakipTipi.GetTakipTipi(this.takipTipi);
                        if (takipTipi != null)
                            return takipTipi.ToString();
                    }
                    return this.takipTipi;
#endregion TakipTipiDesc_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "TakipTipiDesc") + " : " + ex.Message, ex);
                }
            }
        }

        public string TedaviTipiDesc
        {
            get
            {
                try
                {
#region TedaviTipiDesc_GetScript                    
                    if (string.IsNullOrEmpty(this.tedaviTipi) == false)
                    {
                        TedaviTipi tedaviTipi = TedaviTipi.GetTedaviTipi(this.tedaviTipi);
                        if (tedaviTipi != null)
                            return tedaviTipi.ToString();
                    }
                    return this.tedaviTipi;
#endregion TedaviTipiDesc_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "TedaviTipiDesc") + " : " + ex.Message, ex);
                }
            }
        }

        public string TedaviTuruDesc
        {
            get
            {
                try
                {
#region TedaviTuruDesc_GetScript                    
                    if (string.IsNullOrEmpty(this.tedaviTuru) == false)
                    {
                        TedaviTuru tedaviTuru = TedaviTuru.GetTedaviTuru(this.tedaviTuru);
                        if (tedaviTuru != null)
                            return tedaviTuru.ToString();
                    }
                    return this.tedaviTuru;
#endregion TedaviTuruDesc_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "TedaviTuruDesc") + " : " + ex.Message, ex);
                }
            }
        }

        public string BransDesc
        {
            get
            {
                try
                {
#region BransDesc_GetScript                    
                    if (string.IsNullOrEmpty(bransKodu) == false)
                    {
                        SpecialityDefinition brans = SpecialityDefinition.GetBrans(bransKodu);
                        if (brans != null)
                            return brans.ToString();
                    }
                    return bransKodu;
#endregion BransDesc_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "BransDesc") + " : " + ex.Message, ex);
                }
            }
        }

        public string DevredilenKurumDesc
        {
            get
            {
                try
                {
#region DevredilenKurumDesc_GetScript                    
                    if (string.IsNullOrEmpty(devredilenKurum) == false)
                    {
                        DevredilenKurum devredilenKurum = DevredilenKurum.GetDevredilenKurum(this.devredilenKurum);
                        if (devredilenKurum != null)
                            return devredilenKurum.ToString();
                    }
                    return DevredilenKurumDesc;
#endregion DevredilenKurumDesc_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "DevredilenKurumDesc") + " : " + ex.Message, ex);
                }
            }
        }

        public string ProvizyonTipiDesc
        {
            get
            {
                try
                {
#region ProvizyonTipiDesc_GetScript                    
                    if (string.IsNullOrEmpty(this.provizyonTipi) == false)
                    {
                        ProvizyonTipi provizyonTipi = ProvizyonTipi.GetProvizyonTipi(this.provizyonTipi);
                        if (provizyonTipi != null)
                            return provizyonTipi.ToString();
                    }
                    return this.provizyonTipi;
#endregion ProvizyonTipiDesc_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "ProvizyonTipiDesc") + " : " + ex.Message, ex);
                }
            }
        }

    }
}