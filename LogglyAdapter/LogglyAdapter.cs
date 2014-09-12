using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MediusTransformer.Log;
using MediusTransformer.Mapping;

namespace LogglyAdapter
{
    public class LogglyAdapter : MediusTransformer.Connection.Custom.ICustom
    {
        Log _log = new Log();

        DataTable _inputData;
        MediusTransformer.Mapping.Mapping _mapping;

        public string Action
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string ConnectionString { get; set; }

        public string DestinationId
        {
            get;
            set;
        }

        public string DestinationPath
        {
            get;
            set;
        }

        public MediusTransformer.Parameters.ParameterCollection Parameters { get; set; }

        public string SelectionStatement { get; set; }

        public void clearData()
        {
            throw new NotImplementedException();
        }

        public void closeConnection()
        {
            throw new NotImplementedException();
        }

        public void connect()
        {
            throw new NotImplementedException();
        }

        public void executeTransaction(ref System.Data.DataTable dtResult, System.Data.DataSet dsSourceData, MediusTransformer.Mapping.MappingCollection colMappings)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataSet getDataSchema()
        {
            throw new NotImplementedException();
        }

        public MediusTransformer.Log.Log getLog()
        {
            return _log;
        }

        public System.Data.DataTable getSerializedSourceSettingsData()
        {
            throw new NotImplementedException();
        }

        private static string createContent(Mapping mapping, DataTable inputDataTable, string logOriginIdentifier)
        {

            string messageBody = "{";

            var dataRow = inputDataTable.Rows[0];

            for (int i=0; i < mapping.MappingValues.Count; i++)
            {
                if (i != 0)
                    messageBody = messageBody + ",";

                var map = mapping.MappingValues[i];
                messageBody = messageBody + generateMap(map.Destination, dataRow[map.Source].ToString());
            }

            messageBody = messageBody + "," + generateMap("LogOriginIdentifier", logOriginIdentifier);

            messageBody = messageBody + "}";

            return messageBody;
        }

        private static string generateMap(string key, string value)
        {
            string template = "\"{0}\" : \"{1}\"";

            return string.Format(template, key, value);
        }

        public void performTransformation()
        {
            _log.addLogMessage("Destination transformation performed");

            var url = ConnectionString;

            var request = System.Net.WebRequest.Create(url);
            request.Method = "POST";

            var identifierParameter = Parameters.getParameterByName("LogOriginIdentifier", true, null);

            var requestBodyContent = createContent(_mapping, _inputData, identifierParameter.Value);

            _log.addLogMessage("Request body to send is: " + requestBodyContent);

            byte[] sentData = Encoding.UTF8.GetBytes(requestBodyContent);
            request.ContentLength = sentData.Length;
            using (System.IO.Stream sendStream = request.GetRequestStream())
            {
                sendStream.Write(sentData, 0, sentData.Length);
                sendStream.Close();
            }

            var response = request.GetResponse();

            _log.addLogMessage(string.Format("The data was sent with response code {0}", response.ToString()));
        }

        public void runAction(string strParameter)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataSet runDataSetSelectStatement(string[] strParameter)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataSet runDataSetSelectStatement()
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable runSelectStatement(string[] strParameter)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable runSelectStatement()
        {
            throw new NotImplementedException();
        }

        public void setColumnMapping(MediusTransformer.Mapping.Mapping objMap)
        {
            _log.addLogMessage("Perform column mapping");
            _mapping = objMap;
        }

        public void setSourceDataTable(System.Data.DataTable dtSourceDataTable)
        {
            _log.addLogMessage("Set source data table to use");
            _inputData = dtSourceDataTable;
        }

        public bool testConnection()
        {
            throw new NotImplementedException();
        }
    }
}
