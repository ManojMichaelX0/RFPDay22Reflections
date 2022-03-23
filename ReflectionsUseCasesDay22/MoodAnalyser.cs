using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionsUseCasesDay22
{
    public class MoodAnalyser
    {
        public MoodAnalyser() { }
        public string message;
        public MoodAnalyser(string message)
        {
            this.message = message;
        }

        public string AnalyserMood()
        {
            //try
            //{
            //    if (this.message.Contains("Sad"))
            //    {
            //        return "SAD";
            //    }
            //    else
            //    {
            //        return "HAPPY";
            //    }
            //}
            //catch
            //{
            //    return "HAPPY";

            //}
            Console.WriteLine("Enter Your Mood");
            message = Console.ReadLine();
            try
            {
                if (this.message.Equals(string.Empty))
                {
                    throw new MoodAnalyserCustomExeption(MoodAnalyserCustomExeption.ExceptionType.No_Such_Field, "No Such Field Error");
                }
                if (this.message.Contains("Sad"))
                {
                    return "SAD";
                }
                else
                {
                    return "HAPPY";
                }
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomExeption(MoodAnalyserCustomExeption.ExceptionType.Null_Message, "Mood Should Not be Null");
            }
        }
    }
}

