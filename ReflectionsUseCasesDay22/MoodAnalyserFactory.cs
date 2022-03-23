using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ReflectionsUseCasesDay22
{
    public class MoodAnalyserFactory
    {
        public static object CreateMoodAnalyser(string className , string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match result = Regex.Match(className,pattern);

            if (result.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type moodAnalyser = executing.GetType(className);
                    return Activator.CreateInstance(moodAnalyser);
                }
                catch (ArgumentNullException)
                {
                    throw new MoodAnalyserCustomExeption(MoodAnalyserCustomExeption.ExceptionType.No_Such_Class, "Class Not Found");
                }
            }
            else
            {
                throw new MoodAnalyserCustomExeption(MoodAnalyserCustomExeption.ExceptionType.No_Such_Method, "Constructor is Not Found");
            }
        }
    }
}
