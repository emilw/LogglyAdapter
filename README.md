LogglyAdapter
=============

A loggly adapter for MIG to make it possible to log outcome of the scheduled services to loggly.com


1. Get the dll from, https://onedrive.live.com/?cid=d4f523939586278c&id=D4F523939586278C%219558&ithint=file,dll&authkey=!AM24A0x-_Uzndp8
or build it yourself from the source
1. Add the LogTransformation from below in your ScheduledTask that you want to perform logging for.
2. Set the AssemblyPath to point out the adapter dll.
3. Set up the connectionString so it points to YOUR loggly.com account, in the file below it's a faked link.
4. Set the LogOriginIdentifier parameter to a value that says where it loggs from, will most likely be a customer name. This will help out in filtering the events on loggly.com 


'code
<LogTransformation>
            <ConfigParameters />
            <TransformationName />
            <Version>
              <Number>1.0.0.0</Number>
              <Standard>false</Standard>
            </Version>
            <Comment>
				Current Version: 1.0
				ChangeTime: 2014-05-30
			</Comment>
            <Sources />
            <Destinations>
              <Destination>
                <DestinationId>ScheduleLog</DestinationId>
                <Remote />
                <ConnectionType>Custom</ConnectionType>
                <ConnectionSubType>0</ConnectionSubType>
                <AdapterNameSpace>LogglyAdapter.LogglyAdapter</AdapterNameSpace>
                <AssemblyPath>E:\Git\LogglyAdapter\LogglyAdapter\bin\Debug\LogglyAdapter.dll</AssemblyPath>
                <ConnectionString>http://logs-01.loggly.com/inputs/logglyID/tag/http/</ConnectionString>
                <DestinationPath />
                <Parameters>
                  <Parameter>
                    <Name>LogOriginIdentifier</Name>
                    <Value>MyDemoPC</Value>
                    <UseLookUp>false</UseLookUp>
                  </Parameter>
                </Parameters>
              </Destination>
            </Destinations>
            <Mappings>
              <Mapping>
                <SourceId>NoSource</SourceId>
                <DestinationId>ScheduleLog</DestinationId>
                <MappingValues>
                  <MappingValue>
                    <Source>Severity</Source>
                    <Destination>Severity</Destination>
                  </MappingValue>
                  <MappingValue>
                    <Source>InfoText</Source>
                    <Destination>InfoText</Destination>
                  </MappingValue>
                  <MappingValue>
                    <Source>TaskName</Source>
                    <Destination>TaskName</Destination>
                  </MappingValue>
                  <MappingValue>
                    <Source>ErrorText</Source>
                    <Destination>ErrorText</Destination>
                  </MappingValue>
                </MappingValues>
              </Mapping>
            </Mappings>
          </LogTransformation>
'code
