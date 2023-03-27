
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
    /// Yatak
    /// </summary>
    public partial class ResBed : ResSection
    {
        public partial class GetEmptyBeds_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetUsedByRelation_Class : TTReportNqlObject
        {
        }

        public partial class GetEmptyBedsByClinic_Class : TTReportNqlObject
        {
        }

        public partial class GetBedDefinition_Class : TTReportNqlObject
        {
        }

        public partial class GetEmptyBedsWithoutIntensiveCare_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetResBed_Class : TTReportNqlObject
        {
        }

        public partial class GetEmptyBedCountByClinic_Class : TTReportNqlObject
        {
        }

        public partial class GetBedCountByClinic_Class : TTReportNqlObject
        {
        }

        public partial class GetUsedBedCount_Class : TTReportNqlObject
        {
        }

        public partial class GetBedsByClinic_Class : TTReportNqlObject
        {
        }

        public partial class GetEmptyBedCount_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_NewBedQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetAllClinicsEmptybedCounts_Class : TTReportNqlObject
        {
        }

        public partial class GetAllClinicsBeds_Class : TTReportNqlObject
        {
        }

        public partial class GetEmptyBedsWithVentilator_Class : TTReportNqlObject
        {
        }

        public partial class GetAllBedsWithVentilator_Class : TTReportNqlObject
        {
        }

        public partial class GetAllBedsKuvez_Class : TTReportNqlObject
        {
        }

        public partial class GetEmptyBedsKuvez_Class : TTReportNqlObject
        {
        }

        public partial class GetAllResBeds_Class : TTReportNqlObject
        {
        }

        public partial class GetBedDef_Class : TTReportNqlObject
        {
        }

        public partial class GetAllResBedByResWard_Class : TTReportNqlObject
        {
        }

        public partial class GetEmptyBedsByResWard_Class : TTReportNqlObject
        {
        }

        public partial class GetAllWardsEmptyBedCounts_Class : TTReportNqlObject
        {
        }

        public partial class VEM_YATAK_Class : TTReportNqlObject
        {
        }

        protected override void PreUpdate()
        {
            #region PreUpdate
            base.PreUpdate();
            CheckIfIntensiveCareBed();
            #endregion PreUpdate
        }

        protected override void PostUpdate()
        {
            #region PostUpdate
            base.PostUpdate();
            CheckIfIntensiveCareBed();
            #endregion PostUpdate
        }

        public void CheckIfIntensiveCareBed()
        {
            if (Room.RoomGroup.Ward.IsIntensiveCare == true)
            {
                BedProcedureTypeEnum bedProcedureType = BedProcedureTypeEnum.Normal;
                if (this.BedProcedureType != null)
                {
                    bedProcedureType = this.BedProcedureType.Value;
                }
                else
                {
                    bedProcedureType = Room.RoomGroup.Ward.BedProcedureType.Value;
                }
                if (bedProcedureType == BedProcedureTypeEnum.IntensiveCare)
                {
                    if (!IsIntensiveCareBedProcedure())
                        throw new Exception("Yetişkin Yoğun Bakım Uzmanlığına Bağlı bir Klinik için 'P552001','P552002','P552003' harici Yatak Hizmeti seçilemez");
                }
                else if (bedProcedureType == BedProcedureTypeEnum.ChildIntensiveCare)
                {
                    if (!IsIntensiveCareBedProcedure())
                        throw new Exception("Çocuk Yoğun Bakım Uzmanlığına Bağlı bir Klinik için 'P552001','P552002','P552003' harici Yatak Hizmeti seçilemez");
                }
                else if (bedProcedureType == BedProcedureTypeEnum.NewBornIntensiveCare)
                {
                    if (!IsNewBornIntensiveCareBedProcedure())
                        throw new Exception("Yenidoğan Yoğun Bakım Uzmanlığına Bağlı bir Klinik için 'P552006','P552007','P552008' harici Yatak Hizmeti seçilemez");
                }
            }
        }

        public bool IsInIntensiveCareClinic()
        {
            foreach (var resourceSpeciality in Room.RoomGroup.Ward.ResourceSpecialities)
            {
                if (resourceSpeciality.Speciality.SpecialityBasedObjectType == SpecialityBasedObjectEnum.IntensiveCare)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsInNewBornIntensiveCareClinic()
        {
            foreach (var resourceSpeciality in Room.RoomGroup.Ward.ResourceSpecialities)
            {
                if (resourceSpeciality.Speciality.SpecialityBasedObjectType == SpecialityBasedObjectEnum.NewBornIntensiveCare)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsIntensiveCareBedProcedure()
        {
            if (BedProcedure != null)
            {
                //P552001 Birinci basamak yoğun bakım hastası
                //P552002 İkinci basamak yoğun bakım hastası
                //P552003 Üçüncü basamak yoğun bakım hastası
                if (BedProcedure.Code == "P552001" || BedProcedure.Code == "P552002" || BedProcedure.Code == "P552003")
                    return true;
            }
            return false;
        }


        public bool IsNewBornIntensiveCareBedProcedure()
        {
            if (BedProcedure != null)
            {
                //P552006 Yenidoğan birinci basamak yoğun bakım hastası
                //P552007 Yenidoğan ikinci basamak yoğun bakım hastası
                //P552008 Yenidoğan üçüncü basamak yoğun bakım hastası
                if (BedProcedure.Code == "P552006" || BedProcedure.Code == "P552007" || BedProcedure.Code == "P552008")
                    return true;
            }
            return false;
        }


        public SKRSYogunBakimSeviyeBilgisi GetSKRSYogunBakimSeviyeBilgisi()
        {
            if (BedProcedure != null)
            {
                //P552001 Birinci basamak yoğun bakım hastası
                //P552002 İkinci basamak yoğun bakım hastası
                //P552003 Üçüncü basamak yoğun bakım hastası
                //P552006 Yenidoğan birinci basamak yoğun bakım hastası
                //P552007 Yenidoğan ikinci basamak yoğun bakım hastası
                //P552008 Yenidoğan üçüncü basamak yoğun bakım hastası
                string Kodu = "";
                if (BedProcedure.Code == "P552001" || BedProcedure.Code == "P552006")
                    Kodu = "1";
                if (BedProcedure.Code == "P552002" || BedProcedure.Code == "P552007")
                    Kodu = "2";
                if (BedProcedure.Code == "P552003" || BedProcedure.Code == "P552008")
                    Kodu = "3";

                foreach (var sKRSYogunBakimSeviyeBilgisi in SKRSYogunBakimSeviyeBilgisi.GetByKodu(ObjectContext, Kodu))
                    return sKRSYogunBakimSeviyeBilgisi;
            }
            return null;
        }
    }
}