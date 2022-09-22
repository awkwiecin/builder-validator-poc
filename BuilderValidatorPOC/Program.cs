using BuilderValidatorPOC;
using System.Reflection;
using System.Resources;

Console.WriteLine("-- Validator POC --");
ResourceManager resourceManager = new ResourceManager("BuilderValidatorPOC.RegexStrings", Assembly.GetExecutingAssembly()); 
ValidatorTest.Run(resourceManager.GetString("EmailRegexString"),
                  resourceManager.GetString("NameRegexString"));
