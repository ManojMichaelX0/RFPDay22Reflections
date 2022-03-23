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
        // UC 4 Default Constructor
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

        //UC 5 Parameterized Constructor

        public static object CreateMoodAnalyserUsingParameterizedConstructor(string className, string constructorName ,string message)
        {
            Type type = typeof(MoodAnalyser);
            if (type.Name.Equals(className) || type.FullName.Equals(className))
            {
                if (type.Name.Equals(constructorName))
                {
                    ConstructorInfo con = type.GetConstructor(new[] { typeof(string) });
                    object instance = con.Invoke(new object[] {message});
                    return instance;
                }
                else
                {
                    throw new MoodAnalyserCustomExeption(MoodAnalyserCustomExeption.ExceptionType.No_Such_Method, "Constructor is Not Found");
                }
            }
            else
            {
                throw new MoodAnalyserCustomExeption(MoodAnalyserCustomExeption.ExceptionType.No_Such_Class, "Class Not Found");
            }
        }

        //UC 6 Invoke
        public static string InvokeAnalyserMood(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodaAnalyser");
                object moodanalyser=MoodAnalyserFactory.CreateMoodAnalyserUsingParameterizedConstructor("ReflectionsUseCasesDay22.MoodAnalyser", "MoodAnalyser",message);
                MethodInfo analyseMood =type.GetMethod(methodName);
                object mood = analyseMood.Invoke(moodanalyser, null);
                return mood.ToString();
            }
            catch(NullReferenceException)
            {
                throw new MoodAnalyserCustomExeption(MoodAnalyserCustomExeption.ExceptionType.No_Such_Method, "Method is Not Found");
            }
        }
        
    }
}
