using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionsUseCasesDay22
{
    public class MoodAnalyserCustomExeption : Exception
    {
        public enum ExceptionType
        {
            Null_Message, Empty_Message,
            No_Such_Field, No_Such_Method,
            No_Such_Class, Object_Creation_Issue
        }

        private readonly ExceptionType type;

        public MoodAnalyserCustomExeption(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
