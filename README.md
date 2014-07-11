Smokr
=====

The goal of Smokr is to provide a simple tool to assist with evironment validation. The word Smokr comes from the phrase "smoke test", a common QA test.

**Current Tests**
Http validation (Check URL for 200)
Location Validation (Verify that a directory exists)
AppSetting Validation (Verify that the <appSetting> section of a .NET app.config or web.config contains the key/value that one would expect

**Planned Tests**
File Location - Verify the existence of a file
Connection String - Validate that a connection string is in a valid format, and attempt to connect to a resource using that connection string
IIS Installed
IIS Running
Disk Space Requirements
Improve Http validation to allow configurable acceptance of response codes (e.g. 200, 404, 500)
Windows Service Installed
Windows Service Running
