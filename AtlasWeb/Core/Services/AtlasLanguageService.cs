
using Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using TTConnectionManager;
using TTUtils;

namespace Core.Services
{
    public class AtlasLanguageService : ILanguageService
    {
        private Lazy<IList<ILiteralItem>> _lazyLiterals;
        private Lazy<IList<ILiteralItem>> _lazyLiteralsEmpty;

        private Lazy<IDictionary<string, string>> _lazyLiteralSetEn;
        private Lazy<IDictionary<string, string>> _lazyLiteralSetEmpty;

        public AtlasLanguageService()
        {
            _lazyLiterals = new Lazy<IList<ILiteralItem>>(delegate
            {
                var result = this.GetLiteralList("en");
                return result;
            });

            _lazyLiteralSetEn = new Lazy<IDictionary<string, string>>(delegate
            {
                var result = this.GetLiteralList("en");

                var query = from x in result
                            group x by x.LiteralNative into xg
                            select new
                            {
                                LiteralNative = xg.Key,
                                LiteralEn = xg.FirstOrDefault()?.LiteralEn,
                            };

                return query.ToDictionary(x => x.LiteralNative, x => x.LiteralEn);
            });

            _lazyLiteralSetEmpty = new Lazy<IDictionary<string, string>>(delegate
            {
                return new Dictionary<string, string>();
            });

            _lazyLiteralsEmpty = new Lazy<IList<ILiteralItem>>(delegate
            {
                return new List<ILiteralItem>();
            });
        }

        public Lazy<IDictionary<string, string>> GetLiteralSet(string language)
        {
            if (language == "en")
            {
                return _lazyLiteralSetEn;
            }

            return _lazyLiteralSetEmpty;
        }

        public Lazy<IList<ILiteralItem>> GetLiterals(string language)
        {
            if (language == "en")
            {
                return _lazyLiterals;
            }

            return _lazyLiteralsEmpty;
        }

        private DataTable LoadLiteralList()
        {
            DbConnection dbConnection = ConnectionManager.CreateConnection();
            dbConnection.Open();

            try
            {
                char pc = ConnectionManager.ParameterChar;
                string sql = "SELECT * FROM TTLITERALLIST UNION SELECT* FROM TTLITERALLISTEMIRHAN ORDER BY 1";
                DbCommand cmd = ConnectionManager.CreateCommand(sql, dbConnection);
                var dataTable = new DataTable();
                using (var reader = cmd.ExecuteReader())
                {
                    dataTable.Load(reader);
                }
                return dataTable;
            }
            finally
            {
                dbConnection.Close();
                dbConnection.Dispose();
            }
        }

        public IList<ILiteralItem> GetLiteralList(string language)
        {
            var dataTable = LoadLiteralList();

            var query = from dt in dataTable.Rows.OfType<DataRow>()
                        let literalId = Convert.ToString(dt["LITERALID"])
                        let literalNative = Convert.ToString(dt["LITERALNATIVE"])
                        let literalEn = Convert.ToString(dt["LITERALEN"])
                        select new AtlasLiteralItem
                        {
                            LiteralId = literalId,
                            LiteralNative = literalNative,
                            LiteralEn = literalEn,
                        };

            if ( language == "en")
            {
                return query.OfType<ILiteralItem>().ToList();
            }

            return new List<ILiteralItem>();
        }
    }
}
