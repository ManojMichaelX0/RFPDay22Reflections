using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReflectionsUseCasesDay22;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void GivenSadMoodShouldReturnSad()
        {
            string expected = "SAD";
            string message = " I am in Sad Mood";
            MoodAnalyser moodAnalyser = new MoodAnalyser(message);

            string mood = moodAnalyser.AnalyserMood();

            Assert.AreEqual(expected, mood);
        }
        [TestMethod]
        public void GivenHappyShouldReturnHappy(string message)
        {
            string expected = "HAPPY";
            string message1 = " I am in Happy Mood";
            MoodAnalyser moodAnalyser = new MoodAnalyser(message1);

            string mood = moodAnalyser.AnalyserMood();

            Assert.AreEqual(expected, mood);
        }
        
    }
}

