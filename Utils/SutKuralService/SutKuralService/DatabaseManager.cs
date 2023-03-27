using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace SutKuralService
{
    static class DatabaseManager
    {
        public static IDbConnection CreateConnection()
        {
            var connectionStringInfo = ConfigurationManager.ConnectionStrings[GlobalConstants.OracleDatabase];

            DbProviderFactory factory = DbProviderFactories.GetFactory(connectionStringInfo.ProviderName);

            var connection = factory.CreateConnection();

            connection.ConnectionString = connectionStringInfo.ConnectionString;

            return connection;
        }

        public static IDbCommand CreateCommand(this IDbConnection connection, string commandText)
        {
            var command = connection.CreateCommand();
            command.CommandText = commandText;
            command.Connection = connection;
            return command;
        }

        public static void SetParameterValue<T>(this IDbCommand command, string parameterName, T parameterValue)
        {
            IDbDataParameter parameter = command.Parameters[parameterName] as IDbDataParameter;
            if (parameter != null)
                parameter.Value = parameterValue;
        }

        public static void AddParameter(this IDbCommand command, string parameterName, DbType parameterType)
        {
            var parameter = command.CreateParameter();
            parameter.DbType = parameterType;
            parameter.Direction = ParameterDirection.Input;
            parameter.ParameterName = parameterName;
            command.Parameters.Add(parameter);
        }

        public static void AddParameter<T>(this IDbCommand command, string parameterName, DbType parameterType, T paramValue)
        {
            var parameter = command.CreateParameter();
            parameter.DbType = parameterType;
            parameter.Direction = ParameterDirection.Input;
            parameter.ParameterName = parameterName;
            parameter.Value = paramValue;

            if (typeof(T) == typeof(string))
            {
                if (string.IsNullOrEmpty(paramValue as string))
                {
                    parameter.Value = DBNull.Value;
                }
            }

            if (paramValue is string)
            {
                if (string.IsNullOrEmpty(paramValue as string))
                {
                    parameter.Value = DBNull.Value;
                }
            }

            command.Parameters.Add(parameter);
        }

        public static object ExecuteScalar(string sql, IEnumerable<CommandParameter> parameterList)
        {
            using (var connection = DatabaseManager.CreateConnection())
            {
                connection.Open();

                var command = connection.CreateCommand(sql);

                if (parameterList != null)
                {

                    foreach (var commandParam in parameterList)
                    {
                        command.AddParameter(commandParam.ParamName, commandParam.ParamType, commandParam.ParamValue);
                    }
                }

                return command.ExecuteScalar();
            }

        }

        public static int ExecuteNonQuery(string sql, IEnumerable<CommandParameter> parameterList)
        {
            using (var connection = DatabaseManager.CreateConnection())
            {
                connection.Open();

                var command = connection.CreateCommand(sql);

                if (parameterList != null)
                {

                    foreach (var commandParam in parameterList)
                    {
                        command.AddParameter(commandParam.ParamName, commandParam.ParamType, commandParam.ParamValue);
                    }

                }

                return command.ExecuteNonQuery();
            }

        }

        public static IDataReader ExecuteDataReader(string sql, IEnumerable<CommandParameter> parameterList)
        {
            var connection = DatabaseManager.CreateConnection();

            connection.Open();

            var command = connection.CreateCommand(sql);

            if (parameterList != null)
            {
                foreach (var commandParam in parameterList)
                {
                    command.AddParameter(commandParam.ParamName, commandParam.ParamType, commandParam.ParamValue);
                }
            }

            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

    }

}
