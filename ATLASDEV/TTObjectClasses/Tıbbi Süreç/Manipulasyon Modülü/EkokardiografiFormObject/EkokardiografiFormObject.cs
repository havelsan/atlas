
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
    /// Ekokardiografi Türünde Manipulasyonların Ortak Objesi
    /// </summary>
    public  partial class EkokardiografiFormObject : ManipulationFormBaseObject
    {
        public EkokardiografiFormObject(Manipulation manipulation) : this(manipulation.ObjectContext)
        {
            Manipulation = manipulation;

            for(int i=0; i<TTObjectDefManager.Instance.DataTypes["AortKapakEnum"].EnumValueDefs.Count; i++)
            {
                AortKapakBulgu aortKapakBulgu = new AortKapakBulgu(manipulation.ObjectContext);
                aortKapakBulgu.EkokardiografiFormObject = this;
                aortKapakBulgu.AortKapakTest = (AortKapakEnum)Common.GetEnumValueDefOfEnumValueV2("AortKapakEnum", i).EnumValue;
            }
            for (int i = 0; i < TTObjectDefManager.Instance.DataTypes["EkokardiografiEnum"].EnumValueDefs.Count; i++)
            {
                EkokardiografiBulgu ekokardiografiBulgu = new EkokardiografiBulgu(manipulation.ObjectContext);
                ekokardiografiBulgu.EkokardiografiFormObject = this;
                ekokardiografiBulgu.EkokardiografiTest = (EkokardiografiEnum)Common.GetEnumValueDefOfEnumValueV2("EkokardiografiEnum", i).EnumValue;
            }
            for (int i = 0; i < TTObjectDefManager.Instance.DataTypes["MitralKapakEnum"].EnumValueDefs.Count; i++)
            {
                MitralKapakBulgu mitralKapakBulgu = new MitralKapakBulgu(manipulation.ObjectContext);
                mitralKapakBulgu.EkokardiografiFormObject = this;
                mitralKapakBulgu.MitralKapakTest = (MitralKapakEnum)Common.GetEnumValueDefOfEnumValueV2("MitralKapakEnum", i).EnumValue;
            }
            for (int i = 0; i < TTObjectDefManager.Instance.DataTypes["PulmonerKapakEnum"].EnumValueDefs.Count; i++)
            {
                PulmonerKapakBulgu pulmonerKapakBulgu = new PulmonerKapakBulgu(manipulation.ObjectContext);
                pulmonerKapakBulgu.EkokardiografiFormObject = this;
                pulmonerKapakBulgu.PulmonerKapakTest = (PulmonerKapakEnum)Common.GetEnumValueDefOfEnumValueV2("PulmonerKapakEnum", i).EnumValue;
            }
            for (int i = 0; i < TTObjectDefManager.Instance.DataTypes["TrikuspitKapakEnum"].EnumValueDefs.Count; i++)
            {
                TrikuspitKapakBulgu trikuspitKapakBulgu = new TrikuspitKapakBulgu(manipulation.ObjectContext);
                trikuspitKapakBulgu.EkokardiografiFormObject = this;
                trikuspitKapakBulgu.TrikuspitKapakTest = (TrikuspitKapakEnum)Common.GetEnumValueDefOfEnumValueV2("TrikuspitKapakEnum", i).EnumValue;
            }
        }
    }
}