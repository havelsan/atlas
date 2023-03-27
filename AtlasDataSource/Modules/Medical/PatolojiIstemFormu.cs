using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using TTObjectClasses;
using System.ComponentModel;
using ReportClasses.ReportUtils;

namespace AtlasDataSource.Controllers
{
    public class PatolojiIstemFormu 
    {
        public static PatolojiIstemFormuData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<PatolojiIstemFormuData>(parameters, "GetPatolojiIstemFormuData");
        }

        public static PatolojiIstemFormuData GetPatolojiIstemFormuData(string parameters)
        {
            PatolojiIstemFormuData data = new PatolojiIstemFormuData();
            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<PatolojiIstemParameters>(parameters.ToString());
                BindingList<PathologyRequest.GetPathologyRequestInfo_Class> pathologyRequestInfo = PathologyRequest.GetPathologyRequestInfo(param.ObjectID);//PathologyRequest ObjectID
                if(pathologyRequestInfo.Count > 0)
                {
                    data.HastaAdiSoyadi = pathologyRequestInfo[0].Patientname + " " + pathologyRequestInfo[0].Patientsurname;
                    data.HastaKabulNo = pathologyRequestInfo[0].ProtocolNo == null ? " ": pathologyRequestInfo[0].ProtocolNo.ToString();
                    data.HastaTC = pathologyRequestInfo[0].Patienttrid == null ? " " : pathologyRequestInfo[0].Patienttrid.ToString();
                    data.HastaCinsiyet = pathologyRequestInfo[0].Cinsiyet == null ? " " : pathologyRequestInfo[0].Cinsiyet.ToString();
                    data.IstekTarihi = pathologyRequestInfo[0].Istemtarihi;
                    data.IstemYapanDoktor = pathologyRequestInfo[0].Doctorname;
                    data.IstemYapanDoktorBolum = pathologyRequestInfo[0].Requestedresource;
                    //Patoloji Materyaller
                    BindingList<PathologyMaterial.GetPathologyMaterialsByRequestID_Class> pathologyMaterials = PathologyMaterial.GetPathologyMaterialsByRequestID(param.ObjectID);//PathologyRequest ObjectID
                    data.PatolojiMateryaller = new List<PatolojiMateryalData>();
                    foreach (PathologyMaterial.GetPathologyMaterialsByRequestID_Class material in pathologyMaterials)
                    {

                        PatolojiMateryalData m = new PatolojiMateryalData();
                        m.NumuneAlinmaZamani = material.Sampletakendate;
                        m.MateryalNumarasi = material.Materialno == null ? " " : material.Materialno.ToString();
                        m.AlindigiDokununOzelligi = material.Materialozellik == null ? " " : material.Materialozellik.ToString();
                        m.AlindigiOrgan = material.Materialyerlesimyeri == null ? " " : material.Materialyerlesimyeri.ToString();
                        m.AlinmaSekli = material.Alinmasekli == null ? " " : material.Alinmasekli.ToString();
                        m.KlinikBulgu = material.Klinikbulgu == null ? " " : material.Klinikbulgu.ToString();
                        m.Aciklama = material.Aciklama == null ? " " : material.Aciklama.ToString();
                        m.MaterialObjectID = material.Materialobjectid == null ? Guid.Empty : material.Materialobjectid.Value;
                        m.PatolojiTetkikler = new List<PatolojiTetkikData>();
                        //Patoloji işlemler
                        BindingList<PathologyTestProcedure.GetPathologyProceduresByMaterialObjectID_Class> procedures = PathologyTestProcedure.GetPathologyProceduresByMaterialObjectID(material.Materialobjectid.Value);//PathologyRequest ObjectID
                        if (procedures.Count > 0)
                        {
                            foreach (PathologyTestProcedure.GetPathologyProceduresByMaterialObjectID_Class p in procedures)
                            {
                                PatolojiTetkikData t = new PatolojiTetkikData();
                               
                                t.TetkikKodu = p.Procedurecode;
                                t.TetkikAdi = p.Procedurename;
                                m.PatolojiTetkikler.Add(t);
                            }
                        }

                        data.PatolojiMateryaller.Add(m);
                    }
                }
            }
            return data;
        }
    }

    [Serializable]
    public class PatolojiIstemParameters
    {
        [DataMember]
        public Guid ObjectID { get; set; } //PathologyRequest'in ObjectIDsi

    }
    [Serializable]
    public class PatolojiIstemFormuData
    {
        [DataMember]
        public string HastaAdiSoyadi { get; set; }
        [DataMember]
        public string HastaTC { get; set; }
        [DataMember]
        public string HastaCinsiyet { get; set; }
        [DataMember]
        public string HastaYas { get; set; }
        [DataMember]
        public string HastaKabulNo { get; set; }
        [DataMember]
        public DateTime? IstekTarihi { get; set; }
        [DataMember]
        public string IstemYapanDoktor { get; set; }
        [DataMember]
        public string IstemYapanDoktorTel { get; set; }
        [DataMember]
        public string IstemYapanDoktorBolum { get; set; }
        [DataMember]
        public List<PatolojiMateryalData> PatolojiMateryaller { get; set; }
    }

    [Serializable]
    public class PatolojiMateryalData
    {
        [DataMember]
        public DateTime? NumuneAlinmaZamani { get; set; }
        [DataMember]
        public string MateryalNumarasi { get; set; }
        [DataMember]
        public string AlindigiDokununOzelligi { get; set; }
        [DataMember]
        public string AlinmaSekli { get; set; }
        [DataMember]
        public string AlindigiOrgan { get; set; }
        [DataMember]
        public string KlinikBulgu { get; set; }
        [DataMember]
        public string Aciklama { get; set; }
        [DataMember]
        public Guid MaterialObjectID { get; set; }
        [DataMember]
        public List<PatolojiTetkikData> PatolojiTetkikler { get; set; }


    

    }
    [Serializable]
    public class PatolojiTetkikData
    {
        [DataMember]
        public string TetkikKodu { get; set; }
        [DataMember]
        public string TetkikAdi { get; set; }
    }

}
