LogglyAdapter
=============

A loggly adapter for MIG to make it possible to log outcome of the scheduled services to loggly.com


1. Get the dll from, https://onedrive.live.com/?cid=d4f523939586278c&id=D4F523939586278C%219558&ithint=file,dll&authkey=!AM24A0x-_Uzndp8
or build it yourself from the source
1. Add the LogTransformation from below in your ScheduledTask that you want to perform logging for.
2. Set the AssemblyPath to point out the adapter dll.
3. Set up the connectionString so it points to YOUR loggly.com account, in the file below it's a faked link.
4. Set the LogOriginIdentifier parameter to a value that says where it loggs from, will most likely be a customer name. This will help out in filtering the events on loggly.com 

To see a working example, check the ExampleScheduler.xml file in the root folder. Remember that the Loggly url is fake, you need to provide your own.
