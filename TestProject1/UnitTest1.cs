using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReflectionsUseCasesDay22;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        // Test Case 1.1
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
        //Test Case 1.2
        [DataRow("I am in Happy Mood")]
        //Test Case 2.1
        [DataRow(null)]
        public void GivenHappyShouldReturnHappy(string message)
        {
            string expected = "HAPPY";
            string message1 = " I am in Happy Mood";
            MoodAnalyser moodAnalyser = new MoodAnalyser(message1);

            string mood = moodAnalyser.AnalyserMood();

            Assert.AreEqual(expected, mood);
        }

        //Test Case 3.1
        [TestMethod]
        public void Given_Null_Mood_Throw_Null_Mood_Exception()
        {
            try
            {
                string message = null;
                MoodAnalyser moodAnalyser = new MoodAnalyser(message);
                string mood = moodAnalyser.AnalyserMood();
            }
            catch (MoodAnalyserCustomExeption e)
            {
                Assert.AreEqual("Mood Should Not be Null", e.Message);
            }
        }

        //Test Case 3.2
        [TestMethod]
        public void Given_Empty_Mood_Throw_Empty_Mood_Exception()
        {
            try
            {
                string message = " ";
                MoodAnalyser moodAnalyser = new MoodAnalyser(message);
                string mood = moodAnalyser.AnalyserMood();
            }
            catch (MoodAnalyserCustomExeption e)
            {
                Assert.AreEqual("Mood Should Not be Empty", e.Message);
            }
        }
    }
       
}

