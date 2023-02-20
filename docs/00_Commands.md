# Commands

The table below shows a number of common and usefull .NET commands alongside
with a brief explanation. I'm going to omit the `dotnet` part.

|Command|Description|
|---|---|
|-h/\<cmd\> -h|Display an help page for the `dotnet` command or for the specified command \<cmd\>, wether it's a simple command (new -h) or a composite one (sln add -h)|
|--list-sdks|Shows the installed .NET sdks and their path on the system|
|new|Used to create .NET artifacts, basically a code generator. e.g. `new sln`, `new webapi -n API`|
|sln|Allows the user to perform operations for the solution we are currently working on (pwd, and it's not recursive)|
|run|Compile and run the code. Can use different "launch profiles" defined in `Properties/launchSettings`. One default examples is the one that make use of https (need to enable dev cert in order for it to work)|
|dev-certs https --trust|Enable the dev cert for the current machine|