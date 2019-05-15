cmake_minimum_required(VERSION 3.14)
project(MobileServer VERSION 1.0 LANGUAGES CSharp)

add_executable(MobileServer
	Program.cs
	Server.cs
	Properties/AssemblyInfo.cs
)

add_executable(MobileClient
	CProgram.cs
	Client.cs
	Properties/CAssemblyInfo.cs
)
	
set_property(TARGET MobileServer PROPERTY VS_DOTNET_REFERENCES
    "Microsoft.CSharp"
    "System"
    "System.Core"
    "System.Data"
    "System.Data.DataSetExtensions"
    "System.Net.Http"
    "System.Xml"
    "System.Xml.Linq"
    "WindowsBase"
)
	
	
set_property(TARGET MobileClient PROPERTY VS_DOTNET_REFERENCES
    "Microsoft.CSharp"
    "System"
    "System.Core"
    "System.Data"
    "System.Data.DataSetExtensions"
    "System.Net.Http"
    "System.Xml"
    "System.Xml.Linq"
    "System.Net"
    "WindowsBase"
)
    