using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseTest
{

    /// <summary>
    /// Test Morse code decoder
    /// </summary>
    /// 
    [TestFixture]
    public class MorseTest
    {
        private string SWCM; // Single word correct message
        private string MWCM; // Multiple words correct message
        private string ULCM; // Unfined letter correct message
        private string EM; // Empty message
        private string OSM; // One space message

        /// <summary>
        /// Initialize messages
        /// </summary>
        [SetUp]
        protected void SetUp()
        {
            SWCM = Morse.MorseEncoder("Hello");
            MWCM = Morse.MorseEncoder("Hello World");
            ULCM = Morse.MorseEncoder("Hello") + "   ...--- ...--";
            EM = "";
            OSM = " ";

        }

        /// <summary>
        /// Assert correct single word message decoding
        /// </summary>
        /// 
        [Test]
        public void Single_Word_Decoder()
        {
            string expected = "HELLO";
            string decoded_message = Morse.MorseDecoder(SWCM);
            Assert.AreEqual(expected, decoded_message);
        }

        /// <summary>
        /// Assert correct multiple words messsage decoding
        /// </summary>
        /// 
        [Test]
        public void Multiple_Words_Decoder()
        {
            string expected = "HELLO WORLD";
            string decoded_message = Morse.MorseDecoder(MWCM);
            Assert.AreEqual(expected, decoded_message);
        }

        /// <summary>
        /// Assert correct message with unfined letter
        /// </summary>
        /// 
        [Test]
        public void Unfined_Letter_Decoder()
        {
            string expected = "HELLO **";
            string decoded_message = Morse.MorseDecoder(ULCM);
            Assert.AreEqual(expected, decoded_message);
        }

        /// <summary>
        /// Assert decoder throws an excpetion if empty message is passed
        /// </summary>
        /// 
        [Test]
        public void Empty_Message_Decoder()
        {
            var ex = Assert.Throws<ArgumentException>(() => Morse.MorseDecoder(EM));
            Assert.That(ex.Message == "Empty message is passed");
        }

        /// <summary>
        /// Assert decoder throws an exception if empty letter is found
        /// </summary>
        /// 
        [Test]
        public void Space_Message_Decoder()
        {
            var ex = Assert.Throws<ArgumentException>(() => Morse.MorseDecoder(OSM));
            Assert.That(ex.Message == "Empty letter is found");
        }
    }
}
